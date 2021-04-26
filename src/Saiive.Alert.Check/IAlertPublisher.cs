using System.Threading.Tasks;
using Saiive.Alert.Abstractions;

namespace Saiive.Alert.Check
{
    internal interface IAlertPublisher
    {
        Task Notify(NotifyMessage message);
    }
}
