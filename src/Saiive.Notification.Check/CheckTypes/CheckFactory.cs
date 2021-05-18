using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class CheckFactory : BaseChecker
    {
        private readonly Dictionary<AlertType, BaseChecker> _checker;

        public CheckFactory(IOptions<AlertConfig> config, ILogger<BaseChecker> logger, CoinbaseChecker coinbaseChecker, UtxoChecker utxoChecker) : base(config, logger)
        {
            _checker = new Dictionary<AlertType, BaseChecker>();
            _checker.Add(AlertType.Coinbase, coinbaseChecker);
            _checker.Add(AlertType.Utxo, utxoChecker);
        }

        public override async Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions)
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
    }
}
