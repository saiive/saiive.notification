using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Check.Options;
using Saiive.SuperNode.Client.Api;
using Saiive.SuperNode.Client.Client;

namespace Saiive.Alert.Check
{
    internal class AlertCheck : IAlertCheck
    {
        private readonly IOptions<AlertConfig> _config;
        private readonly IAlertPublisher _publisher;
        private readonly ILogger<AlertCheck> _logger;
        private readonly ApiClient _client;

        private readonly AddressApi _addressApi;
        private readonly TransactionApi _txApi;
        private readonly BlockApi _blockApi;

        private int _lastBlockHeight = -1;

        public AlertCheck(IOptions<AlertConfig> config, IAlertPublisher publisher, ILogger<AlertCheck> logger)
        {
            _config = config;
            _publisher = publisher;
            _logger = logger;

            _client = new ApiClient(config.Value.SuperNodeUrl);
            _addressApi = new AddressApi(_client);
            _txApi = new TransactionApi(_client);
            _blockApi = new BlockApi(_client);
        }

       
        public async Task CheckAlerts()
        {
            try
            {
                var tasks = new List<Task>();
                var blockTip = _blockApi.ApiV1NetworkCoinBlockTipGet(_config.Value.Coin.ToUpperInvariant(),
                    _config.Value.Network.ToLowerInvariant());

                _logger.LogInformation($"Polling information at blockheight {blockTip.Height}..");
                foreach (var pub in _config.Value.PubKeys)
                {
                    var task = new Task(async () =>
                    {
                        try
                        {
                            var txs = _addressApi.ApiV1NetworkCoinTxsAddressGet(
                                _config.Value.Coin.ToUpperInvariant(), _config.Value.Network.ToLowerInvariant(),
                                pub.pubKey);

                            _logger.LogInformation($"Check for {pub.name} with pubKey {pub.pubKey}");
                            foreach (var tx in txs.Where(a =>
                                a.Coinbase.HasValue && a.Coinbase.Value && a.MintHeight.HasValue &&
                                a.MintHeight > _lastBlockHeight))
                            {
                                var explorerUrl =
                                    $"[Explorer]({_config.Value.ExplorerBaseUrl}{_config.Value.ExplorerTxPrefix}{tx.MintTxId})";
                                await _publisher.Notify(new NotifyMessage
                                {
                                    PubKey = pub.pubKey,
                                    Message =
                                        $"🎉🎉 {pub.name} Minted new coinbase\nRewards received {tx.Value / 100000000} $DFI\n\nTxId {tx.MintTxId}@{tx.MintHeight.Value}\n{explorerUrl}\n\n🍻🍻"
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
                _lastBlockHeight = blockTip.Height.Value;
            }
            catch(Exception e)
            {
                _logger.LogError("Unknown error,...", e);
            }
        }
    }
}
