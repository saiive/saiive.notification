using System;
using System.Threading.Tasks;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Abstractions.Model;

namespace Saiive.Alert.Check.Abstractions
{
    public interface IAlertNotifier
    {
        Task<Guid> Register(Action<NotifyMessage> notifyAction);
        Task UnRegister(Guid handle);
    }
}
