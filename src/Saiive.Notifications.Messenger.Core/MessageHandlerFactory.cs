using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notifications.Messenger.Core
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly Dictionary<NotificationType, IMessageHandler> _handlers = new Dictionary<NotificationType, IMessageHandler>();

        public MessageHandlerFactory(IEnumerable<MessageHandler> services)
        {
            foreach (var service in services)
            {
                _handlers.Add(service.Type, service);
            }
        }

        public Task SendNotification(SubscriptionsEntity subscription, NotifyMessage message)
        {
            if (_handlers.ContainsKey(subscription.NotificationType))
            {

                var notificationSettings = subscription.NotificationSettings.Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => t.Split(new char[] { '=' }, 2))
                    .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

                return _handlers[subscription.NotificationType].Send(message, notificationSettings);
            }

            throw new ArgumentException($"Type {subscription.NotificationType} has no resolver registered!");
        }

        public Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information)
        {
            if (_handlers.ContainsKey(subscription.NotificationType))
            {
                return _handlers[subscription.NotificationType].Added(subscription, information);
            }

            throw new ArgumentException($"Type {subscription.NotificationType} has no resolver registered!");
        }

        public Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            if (_handlers.ContainsKey(subscription.NotificationType))
            {
                return _handlers[subscription.NotificationType].Activated(subscription, information);
            }

            throw new ArgumentException($"Type {subscription.NotificationType} has no resolver registered!");
        }

        public Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            if (_handlers.ContainsKey(subscription.NotificationType))
            {
                return _handlers[subscription.NotificationType].Deactivated(subscription, information);
            }

            throw new ArgumentException($"Type {subscription.NotificationType} has no resolver registered!");
        }

        public Task<bool> IsValid(SubscriptionsEntity subscription)
        {
            if (_handlers.ContainsKey(subscription.NotificationType))
            {
                return _handlers[subscription.NotificationType].IsValid(subscription);
            }

            throw new ArgumentException($"Type {subscription.NotificationType} has no resolver registered!");
        }
    }
}
