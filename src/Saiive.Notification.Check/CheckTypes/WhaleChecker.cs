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

        private const string ThresholdProperty = "threshold";

        public WhaleChecker(IOptions<AlertConfig> config,ILogger<CoinbaseChecker> logger) : base(config, logger)
        {
        }


        protected override Task<bool> CheckIsValid(SubscriptionsEntity subscription, Dictionary<string, string> alertSettings)
        {
            if (!alertSettings.ContainsKey(ThresholdProperty))
            {
                throw new ArgumentException($"{ThresholdProperty} is missing", ThresholdProperty);
            }
            return Task.FromResult(true);
        }

        protected override async Task<List<NotifyMessage>> OnCheckAlert(SubscriptionsEntity subscription, Dictionary<string, string> alertSettings)
        {
            var ret = new List<NotifyMessage>();
            await Task.CompletedTask;


            var blockTip = BlockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
            subscription.Network.ToString());
            Logger.LogInformation($"Polling information at blockheight {blockTip.Height}..");

            var lastBlockHeight = subscription.LastStateInteger + 1;
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
                            if ((output.Value / 100000000) >= Convert.ToDouble(alertSettings[ThresholdProperty]))
                            {
                                var message = new NotifyMessage(subscription)
                                {
                                    Message =
                                        $"{output.Value / 100000000} transferred to {output.Address}\n\n{explorerUrl}"
                                };
                                ret.Add(message);
                            }
                        }

                        foreach (var input in tx.Details.Inputs)
                        {
                            if ((input.Value / 100000000) >= Convert.ToDouble(alertSettings[ThresholdProperty]))
                            {
                                var message = new NotifyMessage(subscription)
                                {
                                    Message =
                                        $"{input.Value / 100000000} transferred from {input.Address}\n\n{explorerUrl}"
                                };
                                ret.Add(message);
                            }
                        }
                    }

                }
            }

            subscription.LastStateInteger = blockTip.Height.Value;

            return ret;
        }
        
        public override AlertType Type => AlertType.Whale;
    }
}
