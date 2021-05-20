using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Abstractions.Model.Messages;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class WhaleChecker : BaseChecker
    {
        private readonly string _defaultTemplate =
            "🎉🎉 {0} Minted new coinbase\nRewards received {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";

        private const string ThresholdProperty = "threshold";
        private const string ThresholdTypeProperty = "thresholdType";

        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);

        public WhaleChecker(IOptions<AlertConfig> config,ILogger<CoinbaseChecker> logger) : base(config, logger)
        {
        }


        protected override Task<bool> CheckIsValid(SubscriptionsEntity subscription, Dictionary<string, string> alertSettings)
        {
            if (!alertSettings.ContainsKey(ThresholdProperty))
            {
                throw new ArgumentException($"{ThresholdProperty} is missing", ThresholdProperty);
            }
            if (!alertSettings.ContainsKey(ThresholdTypeProperty))
            {
                throw new ArgumentException($"{ThresholdTypeProperty} is missing [EUR, USD, COIN]", ThresholdTypeProperty);
            }
            return Task.FromResult(true);
        }

        protected override async Task<List<NotifyMessage>> OnCheckAlert(SubscriptionsEntity subscription,
            Dictionary<string, string> alertSettings)
        {
            var ret = new List<NotifyMessage>();
            
            if (await _semaphoreSlim.WaitAsync(TimeSpan.FromMilliseconds(1)))
            {
                try
                {
                    var thresholdType = alertSettings[ThresholdTypeProperty];
                    var threshold = Convert.ToDouble(alertSettings[ThresholdProperty]);

                    var priceName = "defichain";

                    if (subscription.Coin == Coin.BTC)
                    {
                        priceName = "bitcoin";
                    }

                    if (thresholdType.ToLower() == "eur")
                    {
                        var price = CoingeckoApi.ApiV1NetworkCoinCoinPriceCurrencyGet(subscription.Coin.ToString(),
                            subscription.Network.ToString(), "EUR");
                        threshold = (threshold / price[priceName].Fiat.Value) * 100000000;
                    }
                    else if (thresholdType.ToLower() == "usd")
                    {
                        var price = CoingeckoApi.ApiV1NetworkCoinCoinPriceCurrencyGet(subscription.Coin.ToString(),
                            subscription.Network.ToString(), "USD");
                        threshold = (threshold / price[priceName].Fiat.Value) * 100000000;
                    }
                    else if (thresholdType.ToLower() == "coin")
                    {
                        // do nothing
                    }



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
                                    if (output.Value >= threshold)
                                    {
                                        var message = new SimpleTextMessage(subscription,
                                            $"{output.Value / 100000000} transferred to {output.Address}\n\n{explorerUrl}",
                                            subscription.Name);
                                        ret.Add(message);
                                    }
                                }

                                foreach (var input in tx.Details.Inputs)
                                {
                                    if (input.Value >= threshold)
                                    {
                                        var message = new SimpleTextMessage(subscription, $"{input.Value / 100000000} transferred from {input.Address}\n\n{explorerUrl}", subscription.Name);
                                        ret.Add(message);
                                    }
                                }
                            }

                        }
                    }

                    subscription.LastStateInteger = blockTip.Height.Value;
                }
                finally
                {
                    _semaphoreSlim.Release(1);
                }
            }

            return ret;
        }

        public override AlertType Type => AlertType.Whale;
    }
}
