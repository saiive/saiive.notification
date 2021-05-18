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
    internal class CoinbaseChecker : BaseChecker
    {
        private readonly string _defaultTemplate =
            "🎉🎉 {0} Minted new coinbase\nRewards received {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";


        public CoinbaseChecker(IOptions<AlertConfig> config,ILogger<CoinbaseChecker> logger) : base(config, logger)
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
                            foreach (var tx in txs.Where(a =>
                                a.Coinbase.HasValue && a.Coinbase.Value && a.MintHeight.HasValue &&
                                a.MintHeight > subscription.LastBlockHeight))
                            {
                                var explorerUrl =
                                    $"[Explorer]({Config.Value.ExplorerBaseUrl}{String.Format(Config.Value.ExplorerTxPrefix, subscription.Network)}{tx.MintTxId})";
                                ret.Add(new NotifyMessage(subscription.NotificationConnectionString,
                                    subscription.RowKey, subscription.PartitionKey)
                                {
                                    PubKey = subscription.PublicKey,
                                    Message = String.Format(_defaultTemplate, subscription.PublicKey,
                                        (tx.Value / 100000000), tx.MintTxId, tx.MintHeight.Value, explorerUrl)
                                });
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
    }
}
