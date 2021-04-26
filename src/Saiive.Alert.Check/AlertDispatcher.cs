using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Check.Abstractions;

namespace Saiive.Alert.Check
{
    internal class AlertDispatcher : IAlertNotifier, IAlertPublisher
    {
        private readonly Dictionary<Guid, Action<NotifyMessage>> _callbacks =
            new Dictionary<Guid, Action<NotifyMessage>>();

        public Task<Guid> Register(Action<NotifyMessage> notifyAction)
        {
            var id = Guid.NewGuid();
            _callbacks.Add(id, notifyAction);
            return Task.FromResult(id);
        }

        public Task UnRegister(Guid handle)
        {
            if (_callbacks.ContainsKey(handle))
            {
                _callbacks.Remove(handle);
            }

            return Task.CompletedTask;
        }

        public Task Notify(NotifyMessage message)
        {
            foreach (var callback in _callbacks)
            {
                callback.Value(message);
            }

            return Task.CompletedTask;
        }
    }
}
