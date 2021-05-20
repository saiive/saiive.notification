using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Abstractions
{
    public abstract class MessageHandler : IMessageHandler
    {
        public abstract NotificationType Type { get; }
        public abstract Task Send(NotifyMessage message, Dictionary<string, string> connectionSettings);
        public Task<bool> IsValid(SubscriptionsEntity subscription)
        {
            var notificationSettings = subscription.NotificationSettings.Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Split(new char[] { '=' }, 2))
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);
            return CheckIsValid(subscription, notificationSettings);
        }

        protected abstract Task<bool> CheckIsValid(SubscriptionsEntity subscription,
            Dictionary<string, string> connectionSettings);

        public virtual Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information)
        {
            subscription.IsEnabled = false;
            var confirmMessage = $"{information.Host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";

            var notification = new NotifyMessage(subscription)
            {
                Message = confirmMessage
            };

            return Task.FromResult(notification);
        }


        public virtual Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            var deactivateLink = $"{information.Host}/api/deactivate/{subscription.RowKey}/{subscription.PartitionKey}";
            var confirmMessage = $"Your subscription has been activated. To disable it use this link: {deactivateLink}";

            var notification = new NotifyMessage(subscription)
            {
                Message = confirmMessage
            };


            return Task.FromResult(notification);
        }

        public virtual Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            var activateLink = $"{information.Host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";
            var confirmMessage = $"Your subscription has been deactivated. To activate it use this link: {activateLink}";

            var notification = new NotifyMessage(subscription)
            {
                Message = confirmMessage
            };


            return Task.FromResult(notification);
        }


    }
}
