using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;
using Saiive.SuperNode.Client.Model;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class UtxoChecker : BaseChecker
    {
        private readonly string _defaultTemplateTo =
            "🎉🎉 {0} New transaction detected\nReceived funds\n\nAmount {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";
        private readonly string _defaultTemplateFrom =
            "🎉🎉 {0} New transaction detected\nFunds sent\n\nAmount {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";

        public UtxoChecker(IOptions<AlertConfig> config, ILogger<BaseChecker> logger) : base(config, logger)
        {
        }

        public override async Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions)
        {
            var ret = new List<NotifyMessage>();

            try
            {
                var tasks = new List<Task>();

                foreach (var subscription in subscriptions)
                {
                    var task = new Task(() =>
                    {
                        try
                        {
                            var blockTip = BlockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
                                subscription.Network.ToString());
                            Logger.LogInformation($"Polling information at blockheight {blockTip.Height}..");

                            var txs = AddressApi.ApiV1NetworkCoinTxsAddressGet(subscription.Coin.ToString(),
                                subscription.Network.ToString(),
                                subscription.PublicKey);

                            Logger.LogInformation(
                                $"Check for {subscription.Name} with pubKey {subscription.PublicKey}");

                            var conString = subscription.AlertTypeSettings.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                .Select(t => t.Split(new char[] { '=' }, 2))
                                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

                            var template = "";
                            if (conString.ContainsKey("direction"))
                            {
                                var foundTxs = new List<TransactionModel>(); 
                                var newTx = txs.Where(a => a.MintHeight.HasValue &&
                                                           a.MintHeight > subscription.LastBlockHeight).ToList();

                                if (conString["direction"] == "to")
                                {
                                    template = _defaultTemplateTo;
                                    foreach (var tx in newTx)
                                    {
                                        var specificTx = TxApi.ApiV1NetworkCoinTxIdTxIdGet(subscription.Coin.ToString(),
                                            subscription.Network.ToString(), tx.MintTxId);

                                        if (specificTx.Details.Outputs.Any(a => a.Address == subscription.PublicKey))
                                        {
                                            if(foundTxs.All(a => a.MintTxId != tx.MintTxId))
                                                foundTxs.Add(tx);
                                        }
                                    }
                                }
                                else if (conString["direction"] == "from")
                                {
                                    template = _defaultTemplateFrom;
                                    foreach (var tx in newTx)
                                    {
                                        var specificTx = TxApi.ApiV1NetworkCoinTxIdTxIdGet(subscription.Coin.ToString(),
                                            subscription.Network.ToString(), tx.MintTxId);

                                        if (specificTx.Details.Inputs.Any(a => a.Address == subscription.PublicKey))
                                        {
                                            if (foundTxs.All(a => a.MintTxId != tx.MintTxId))
                                                foundTxs.Add(tx);
                                        }
                                    }
                                }
                                foreach (var tx in foundTxs)
                                {

                                    var explorerUrl =
                                        $"[Explorer]({Config.Value.ExplorerBaseUrl}{String.Format(Config.Value.ExplorerTxPrefix, subscription.Network)}{tx.MintTxId})";
                                    var msg = String.Format(template, subscription.PublicKey,
                                        tx.Value / 100000000, tx.MintTxId, tx.MintHeight.Value, explorerUrl);

                                    ret.Add(new NotifyMessage(subscription.NotificationConnectionString,
                                        subscription.RowKey, subscription.PartitionKey)
                                    {
                                        PubKey = subscription.PublicKey,
                                        Message = msg
                                    });
                                }
                            }
                            else
                            {
                                Logger.LogInformation($"Misconfigured type found, missing direction ({subscription.RowKey}-{subscription.PartitionKey})");
                            }

                            subscription.LastBlockHeight = blockTip.Height.Value;
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Error fetching address data...", e);
                        }
                    });

                    tasks.Add(task);
                    task.Start();
                }

                await Task.WhenAll(tasks);

            }
            catch (Exception e)
            {
                Logger.LogError("Unknown error,...", e);
            }

            return ret;
        }


        public override AlertType Type => AlertType.Utxo;
    }
}
