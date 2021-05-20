using System.Threading.Tasks;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notifications.Messenger.Core
{
    public interface IMessageHandlerFactory
    {
        Task SendNotification(SubscriptionsEntity subscription, NotifyMessage message);

        Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information);
        Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information);
        Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information);
        Task<bool> IsValid(SubscriptionsEntity subscription);
    }
}
