using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Abstractions
{
    public interface IMessageHandler
    {
        Task Send(NotifyMessage message);
    }
}
