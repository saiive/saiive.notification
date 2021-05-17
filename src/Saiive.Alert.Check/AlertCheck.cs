using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Abstractions.Model;
using Saiive.Alert.Check.Options;
using Saiive.SuperNode.Client.Api;
using Saiive.SuperNode.Client.Client;

namespace Saiive.Alert.Check
{
    internal class AlertCheck : IAlertCheck
    {
        private readonly IOptions<AlertConfig> _config;
        private readonly ILogger<AlertCheck> _logger;
        private readonly ApiClient _client;

        private readonly AddressApi _addressApi;
        private readonly TransactionApi _txApi;
        private readonly BlockApi _blockApi;

        private readonly string _defaultTemplate =
            "🎉🎉 {0} Minted new coinbase\nRewards received {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";


        public AlertCheck(IOptions<AlertConfig> config,ILogger<AlertCheck> logger)
        {
            _config = config;
            _logger = logger;

            _client = new ApiClient(config.Value.SuperNodeUrl);
            _addressApi = new AddressApi(_client);
            _txApi = new TransactionApi(_client);
            _blockApi = new BlockApi(_client);
        }

       
        public async Task<(List<NotifyMessage> Notifications, int CurrentBlockHeight)> CheckAlerts(List<SubscriptionsEntity> subscriptions)
        {
            var ret = new List<NotifyMessage>();
            var currentBlockHeight = 0;
            try
            {
                var tasks = new List<Task>();
                var blockTip = _blockApi.ApiV1NetworkCoinBlockTipGet(_config.Value.Coin.ToUpperInvariant(),
                    _config.Value.Network.ToLowerInvariant());

                _logger.LogInformation($"Polling information at blockheight {blockTip.Height}..");
                foreach (var subscription in subscriptions)
                {
                    var task = new Task(() =>
                    {
                        try
                        {
                            var txs = _addressApi.ApiV1NetworkCoinTxsAddressGet(
                                _config.Value.Coin.ToUpperInvariant(), _config.Value.Network.ToLowerInvariant(),
                                subscription.PublicKey);

                            _logger.LogInformation($"Check for {subscription.Name} with pubKey {subscription.PublicKey}");
                            foreach (var tx in txs.Where(a =>
                                a.Coinbase.HasValue && a.Coinbase.Value && a.MintHeight.HasValue &&
                                a.MintHeight > subscription.LastBlockHeight))
                            {
                                var explorerUrl =
                                    $"[Explorer]({_config.Value.ExplorerBaseUrl}{_config.Value.ExplorerTxPrefix}{tx.MintTxId})";
                                ret.Add(new NotifyMessage(subscription.NotificationConnectionString)
                                {
                                    PubKey = subscription.PublicKey,
                                    Message = String.Format(_defaultTemplate, subscription.PublicKey, (tx.Value/ 100000000), tx.MintTxId, tx.MintHeight.Value, explorerUrl)
                                });
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.LogError("Error fetching address data...", e);
                        }
                    });

                    tasks.Add(task);
                    task.Start();
                }

                await Task.WhenAll(tasks);
                currentBlockHeight = blockTip.Height.Value;

            }
            catch (Exception e)
            {
                _logger.LogError("Unknown error,...", e);
            }
            return (ret, currentBlockHeight);
        }
    }
}
