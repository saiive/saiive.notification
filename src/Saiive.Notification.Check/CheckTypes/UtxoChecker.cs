using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class UtxoChecker : BaseChecker
    {
        public UtxoChecker(IOptions<AlertConfig> config, ILogger<BaseChecker> logger) : base(config, logger)
        {
        }

        public override Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions)
        {
            throw new NotImplementedException();
        }
    }
}
