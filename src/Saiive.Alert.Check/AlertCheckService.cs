using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Alert.Check.Options;
using Saiive.SuperNode.Client.Api;
using Saiive.SuperNode.Client.Client;

namespace Saiive.Alert.Check
{
    internal class AlertCheckService : IHostedService
    {
        private readonly IOptions<AlertConfig> _config;
        private readonly IAlertCheck _alertCheck;
        private readonly ILogger<AlertCheck> _logger;
        private readonly ApiClient _client;
        
        private readonly BlockApi _blockApi;

        private int _lastBlockHeight = -1;

        private Timer _pollingTimer;

        public AlertCheckService(IOptions<AlertConfig> config, IAlertCheck alertCheck, ILogger<AlertCheck> logger)
        {
            _config = config;
            _alertCheck = alertCheck;
            _logger = logger;

            _client = new ApiClient(config.Value.SuperNodeUrl);
            _blockApi = new BlockApi(_client);
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            var blockTip = _blockApi.ApiV1NetworkCoinBlockTipGet(_config.Value.Coin.ToUpperInvariant(),
                _config.Value.Network.ToLowerInvariant());
            _lastBlockHeight = blockTip.Height.Value;

            if (Debugger.IsAttached)
            {
                _lastBlockHeight = 807936;
            }

            _logger.LogInformation($"Starting at blockheight {_lastBlockHeight}");

            _pollingTimer = new Timer(async (s) => await _alertCheck.CheckAlerts(), null, TimeSpan.FromMilliseconds(1), _config.Value.Interval);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _pollingTimer.Dispose();
            return Task.CompletedTask;
        }

    }
}
