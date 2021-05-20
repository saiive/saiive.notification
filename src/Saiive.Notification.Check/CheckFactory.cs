using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.CheckTypes;
using Saiive.Notification.Check.Options;
using Saiive.SuperNode.Client.Api;
using Saiive.SuperNode.Client.Client;

namespace Saiive.Notification.Check
{
    internal class CheckFactory : ICheckerFactory
    {
        private readonly Dictionary<AlertType, IChecker> _checker;

        private readonly BlockApi _blockApi;

        public CheckFactory(IOptions<AlertConfig> config, ILogger<BaseChecker> logger, IEnumerable<IChecker> checkerServices)
        {
            _checker = new Dictionary<AlertType, IChecker>();
            
            foreach (var service in checkerServices)
            {
                _checker.Add(service.Type, service);
            }

            var client = new ApiClient(config.Value.SuperNodeUrl);
            _blockApi = new BlockApi(client);
        }

        public Task<bool> IsValid(SubscriptionsEntity subscription)
        {
            if (_checker.ContainsKey(subscription.AlertType))
            {
                return _checker[subscription.AlertType].IsValid(subscription);
            }

            return Task.FromResult(false);
        }

        public async Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions)
        {
            var ret = new List<NotifyMessage>();

            if (subscriptions.Count == 0)
            {
                return ret;
            }
            foreach (var key in _checker.Keys)
            {
                if (!_checker.ContainsKey(key))
                {
                    continue;
                }
                var subs = subscriptions.Where(a => a.AlertType == key).ToList();

                var notifications = await _checker[key].CheckAlerts(subs);
                ret.AddRange(notifications);
            }

            return ret;
        }

        public Task<int> GetCurrentBlockHeight(SubscriptionsEntity subscription)
        {
            var blockTip = _blockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
                subscription.Network.ToString());

            return Task.FromResult(blockTip.Height.Value);
        }
    }
}
