using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Abstractions.Model.Messages;
using Saiive.Notifications.Messenger.Core;

namespace Saiive.Notification.Messenger.Functions
{
    public class NotificationFunction
    {
        private readonly IMessageHandlerFactory _handlerFactory;

        public NotificationFunction(IMessageHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }
        [FunctionName("NotificationHandler")]
        public async Task Run([ServiceBusTrigger("message", "notification", Connection = "MessageTopic")] Message mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            try
            {
                if (String.IsNullOrEmpty(mySbMsg.ContentType))
                {
                    return;
                }
                var message = NotifyMessage.Decode(mySbMsg.ContentType, Encoding.UTF8.GetString(mySbMsg.Body));
                await _handlerFactory.SendNotification(message.Subscription, message);
            }
            catch(Exception e)
            {
                log.LogError(e, $"Error sending telegram message...");
                //ignore now
            }
        }
    }
}
