using System.Collections.Generic;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Abstractions
{
    public interface IMessageHandler
    {
        Task Send(NotifyMessage message, Dictionary<string, string> connectionSettings);


        Task<bool> IsValid(SubscriptionsEntity entity);

        Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information);
        Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information);
        Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information);

        NotificationType Type { get; }
    }
}
