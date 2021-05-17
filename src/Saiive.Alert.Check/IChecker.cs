﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Abstractions.Model;

namespace Saiive.Alert.Check
{
    public interface IChecker
    {
        Task<(List<NotifyMessage> Notifications, int CurrentBlockHeight)> CheckAlerts(List<SubscriptionsEntity> subscriptions);

        Task<int> GetCurrentBlockHeight();
    }
}