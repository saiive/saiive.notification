using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class WhaleChecker : BaseChecker
    {
        private readonly string _defaultTemplate =
            "🎉🎉 {0} Minted new coinbase\nRewards received {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";


        public WhaleChecker(IOptions<AlertConfig> config,ILogger<CoinbaseChecker> logger) : base(config, logger)
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
                            var conString = subscription.AlertTypeSettings.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                .Select(t => t.Split(new char[] { '=' }, 2))
                                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

                            

                                var blockTip = BlockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
                                subscription.Network.ToString());
                            Logger.LogInformation($"Polling information at blockheight {blockTip.Height}..");

                            var lastBlockHeight = subscription.LastBlockHeight + 1;
                            for (int i = lastBlockHeight; i <= blockTip.Height.Value; i++)
                            {
                                var txs = TxApi.ApiV1NetworkCoinTxHeightHeightGet(subscription.Coin.ToString(),
                                    subscription.Network.ToString(),
                                    i);


                                foreach (var tx in txs.Where(a => !a.Coinbase))
                                {
                                    var explorerUrl =
                                        $"[Explorer]({Config.Value.ExplorerBaseUrl}{String.Format(Config.Value.ExplorerTxPrefix, subscription.Network)}{tx.Txid})";

                                    if (tx.Details != null)
                                    {
                                        foreach (var output in tx.Details.Outputs)
                                        {
                                            if ((output.Value / 100000000) >= Convert.ToDouble(conString["threshold"]))
                                            {
                                                var message = new NotifyMessage(
                                                    subscription.NotificationConnectionString,
                                                    subscription.RowKey, subscription.PartitionKey)
                                                {
                                                    PubKey = null,
                                                    Message =
                                                        $"{output.Value / 100000000} transferred to {output.Address}\n\n{explorerUrl}"
                                                };
                                                ret.Add(message);
                                            }
                                        }

                                        foreach (var input in tx.Details.Inputs)
                                        {
                                            if ((input.Value / 100000000) >= Convert.ToDouble(conString["threshold"]))
                                            {
                                                var message = new NotifyMessage(
                                                    subscription.NotificationConnectionString,
                                                    subscription.RowKey, subscription.PartitionKey)
                                                {
                                                    PubKey = null,
                                                    Message =
                                                        $"{input.Value / 100000000} transferred from {input.Address}\n\n{explorerUrl}"
                                                };
                                                ret.Add(message);
                                            }
                                        }
                                    }

                                }
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

        public override AlertType Type => AlertType.Whale;
    }
}
