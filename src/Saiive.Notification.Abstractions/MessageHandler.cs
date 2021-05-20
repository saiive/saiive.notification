using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Abstractions.Model.Messages;

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

            var notification = new UrlTextMessage(subscription,
                "You need to confirm your subscription with opening the link below",  subscription.Name, confirmMessage, "Activate");
            
            return Task.FromResult(notification as NotifyMessage);
        }


        public virtual Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            var deactivateLink = $"{information.Host}/api/deactivate/{subscription.RowKey}/{subscription.PartitionKey}";
          
            var notification = new UrlTextMessage(subscription,
                "Your subscription has been activated. To disable it use the link below", subscription.Name, deactivateLink, "Disable");


            return Task.FromResult(notification as NotifyMessage);
        }

        public virtual Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            var activateLink = $"{information.Host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";
           
            var notification = new UrlTextMessage(subscription,
                "Your subscription has been deactivated. To activate it use the link below", subscription.Name, activateLink, "Activate");

            return Task.FromResult(notification as NotifyMessage);
        }


    }
}
