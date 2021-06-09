using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Abstractions.Model.Messages;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class CoinbaseChecker : PublicKeyCheckerBase
    {
        private readonly string _defaultTemplate =
            "🎉🎉 {0} Minted new coinbase\nRewards received {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";


        public CoinbaseChecker(IOptions<AlertConfig> config,ILogger<CoinbaseChecker> logger) : base(config, logger)
        {
        }

        public override Task<bool> CheckIsValidInternal(SubscriptionsEntity subscriptions, Dictionary<string, string> alertSettings)
        {
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
                foreach (var tx in txs.Where(a =>
                    a.Coinbase.HasValue && a.Coinbase.Value && a.MintHeight.HasValue &&
                    a.MintHeight > subscription.LastStateInteger))
                {
                    var explorerUrl =
                        $"[Explorer]({Config.Value.ExplorerBaseUrl}{String.Format(Config.Value.ExplorerTxPrefix, subscription.Network)}{tx.MintTxId})";

                    var msg = String.Format(_defaultTemplate, alertSettings[PublicKeyProperty],
                        (tx.Value / 100000000), tx.MintTxId, tx.MintHeight.Value, explorerUrl);

                    ret.Add(new SimpleTextMessage(subscription , msg, alertSettings[PublicKeyProperty]));
                }

                subscription.LastStateInteger = blockTip.Height.Value;
            }
            catch (Exception e)
            {
                Logger.LogError("Error fetching address data...", e);
            }

            return ret;
        }

        public override AlertType Type => AlertType.Coinbase;

    }
}
