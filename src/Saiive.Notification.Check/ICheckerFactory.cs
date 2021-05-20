﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Check
{
    public interface ICheckerFactory
    {
        Task<bool> IsValid(SubscriptionsEntity subscription);
        Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions);

        Task<int> GetCurrentBlockHeight(SubscriptionsEntity subscription);
    }
}
