using System.Threading.Tasks;
using Saiive.Alert.Abstractions.Model;

namespace Saiive.Alert.Abstractions
{
    public interface IMessageHandler
    {
        Task Send(NotifyMessage message);
    }
}
