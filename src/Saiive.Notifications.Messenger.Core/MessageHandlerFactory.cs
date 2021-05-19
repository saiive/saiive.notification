using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notifications.Messenger.Core
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly Dictionary<string, MessageHandler> _handlers = new Dictionary<string, MessageHandler>();

        public MessageHandlerFactory(IEnumerable<MessageHandler> services)
        {
            foreach (var service in services)
            {
                _handlers.Add(service.Type, service);
            }
        }

        public Task SendNotification(NotifyMessage message)
        {
            if (_handlers.ContainsKey(message.Type))
            {
                return _handlers[message.Type].Send(message);
            }

            throw new ArgumentException($"Type {message.Type} has no resolver registered!");
        }

        public Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information)
        {
            var notifyMessage = new NotifyMessage(subscription.NotificationConnectionString, "", "");
            if (_handlers.ContainsKey(notifyMessage.Type))
            {
                return _handlers[notifyMessage.Type].Added(subscription, information);
            }

            throw new ArgumentException($"Type {notifyMessage.Type} has no resolver registered!");
        }

        public Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            var notifyMessage = new NotifyMessage(subscription.NotificationConnectionString, "", "");
            if (_handlers.ContainsKey(notifyMessage.Type))
            {
                return _handlers[notifyMessage.Type].Activated(subscription, information);
            }

            throw new ArgumentException($"Type {notifyMessage.Type} has no resolver registered!");
        }

        public Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            var notifyMessage = new NotifyMessage(subscription.NotificationConnectionString, "", "");
            if (_handlers.ContainsKey(notifyMessage.Type))
            {
                return _handlers[notifyMessage.Type].Deactivated(subscription, information);
            }

            throw new ArgumentException($"Type {notifyMessage.Type} has no resolver registered!");
        }
    }
}
