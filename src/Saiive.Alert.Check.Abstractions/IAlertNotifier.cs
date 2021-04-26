using System;
using System.Threading.Tasks;
using Saiive.Alert.Abstractions;

namespace Saiive.Alert.Check.Abstractions
{
    public interface IAlertNotifier
    {
        Task<Guid> Register(Action<NotifyMessage> notifyAction);
        Task UnRegister(Guid handle);
    }
}
