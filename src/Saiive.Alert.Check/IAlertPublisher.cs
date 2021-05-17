using System.Threading.Tasks;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Abstractions.Model;

namespace Saiive.Alert.Check
{
    internal interface IAlertPublisher
    {
        Task Notify(NotifyMessage message);
    }
}
