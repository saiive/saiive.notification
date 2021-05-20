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
    internal class UtxoChecker : PublicKeyCheckerBase
    {
        private readonly string _defaultTemplateTo =
            "🎉🎉 {0} New transaction detected\nReceived funds\n\nAmount {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";
        private readonly string _defaultTemplateFrom =
            "🎉🎉 {0} New transaction detected\nFunds sent\n\nAmount {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";

        private const string DirectionProperty = "direction";

        public UtxoChecker(IOptions<AlertConfig> config, ILogger<BaseChecker> logger) : base(config, logger)
        {
        }

        public override Task<bool> CheckIsValidInternal(SubscriptionsEntity subscriptions, Dictionary<string, string> alertSettings)
        {
            if (!alertSettings.ContainsKey(DirectionProperty))
            {
                throw new ArgumentException($"{DirectionProperty} is missing [from, to]", DirectionProperty);
            }

            return Task.FromResult(true);

        }

        protected override async Task<List<NotifyMessage>> OnCheckAlert(SubscriptionsEntity subscription, Dictionary<string, string> alertSettings)
        {
            var ret = new List<NotifyMessage>();
            await Task.CompletedTask;

            try
            {
                var blockTip = BlockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
                    subscription.Network.ToString());
                Logger.LogInformation($"Polling information at blockheight {blockTip.Height}..");

                var txs = AddressApi.ApiV1NetworkCoinTxsAddressGet(subscription.Coin.ToString(),
                    subscription.Network.ToString(),
                    alertSettings[PublicKeyProperty]);

                Logger.LogInformation(
                    $"Check for {subscription.Name} with pubKey {alertSettings[PublicKeyProperty]}");


                var template = "";
                var foundTxs = new List<TransactionModel>();
                var newTx = txs.Where(a => a.MintHeight.HasValue &&
                                           a.MintHeight > subscription.LastStateInteger).ToList();

                if (alertSettings[DirectionProperty] == "to")
                {
                    template = _defaultTemplateTo;
                    foreach (var tx in newTx)
                    {
                        var specificTx = TxApi.ApiV1NetworkCoinTxIdTxIdGet(subscription.Coin.ToString(),
                            subscription.Network.ToString(), tx.MintTxId);

                        if (specificTx.Details.Outputs.Any(a => a.Address == alertSettings[PublicKeyProperty]))
                        {
                            if (foundTxs.All(a => a.MintTxId != tx.MintTxId))
                                foundTxs.Add(tx);
                        }
                    }
                }
                else if (alertSettings[DirectionProperty] == "from")
                {
                    template = _defaultTemplateFrom;
                    foreach (var tx in newTx)
                    {
                        var specificTx = TxApi.ApiV1NetworkCoinTxIdTxIdGet(subscription.Coin.ToString(),
                            subscription.Network.ToString(), tx.MintTxId);

                        if (specificTx.Details.Inputs.Any(a => a.Address == alertSettings[PublicKeyProperty]))
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
                    var msg = String.Format(template, alertSettings[PublicKeyProperty],
                        tx.Value / 100000000, tx.MintTxId, tx.MintHeight.Value, explorerUrl);

                    ret.Add(new NotifyMessage(subscription)
                    {
                        Title = alertSettings[PublicKeyProperty],
                        Message = msg
                    });
                }


                subscription.LastStateInteger = blockTip.Height.Value;
            }

            catch (Exception e)
            {
                Logger.LogError("Error fetching address data...", e);
            }

            return ret;
        }
        public override AlertType Type => AlertType.Utxo;

    }
}
