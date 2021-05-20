using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notifications.Messenger.Core;

namespace Saiive.Notification.Messenger.Functions
{
    public class LifecycleFunction
    {
        private readonly IMessageHandlerFactory _factory;

        public LifecycleFunction(IMessageHandlerFactory factory)
        {
            _factory = factory;
        }


        [FunctionName("LifecycleAdded")]
        public async Task LifecycleAdded([ServiceBusTrigger("message", "added", Connection = "MessageTopic")]
            Message mySbMsg,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger log)
        {

            try
            {
                var subscription = JsonConvert.DeserializeObject<SubscriptionsEntity>(Encoding.UTF8.GetString(mySbMsg.Body));

                var info = new AddedInformation
                {
                    Host = mySbMsg.ReplyTo
                };
                var msg = await _factory.Added(subscription, info);

                var message = new Message
                {
                    To = "notification",
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg)),
                    ContentType = msg.GetType().Name

                };
                await notificationBus.AddAsync(message);
            }
            catch (Exception e)
            {
                log.LogError(e, "Unhandled error occured...");
            }

        }

        [FunctionName("LifecycleActivate")]
        public async Task LifecycleActivate([ServiceBusTrigger("message", "activated", Connection = "MessageTopic")]
            Message mySbMsg,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger log)
        {
            try
            {
                var subscription = JsonConvert.DeserializeObject<SubscriptionsEntity>(Encoding.UTF8.GetString(mySbMsg.Body));

                var info = new ActivateInformation
                {
                    Host = mySbMsg.ReplyTo
                };
                var msg = await _factory.Activated(subscription, info);
                var message = new Message
                {
                    To = "notification",
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg)),
                    ContentType = msg.GetType().Name

                };
                await notificationBus.AddAsync(message);
            }
            catch (Exception e)
            {
                log.LogError(e, "Unhandled error occured...");
            }

        }

        [FunctionName("LifecycleDeactivate")]
        public async Task LifecycleDeactivate([ServiceBusTrigger("message", "deactivated", Connection = "MessageTopic")]
            Message mySbMsg,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger log)
        {

            try
            {
                var subscription = JsonConvert.DeserializeObject<SubscriptionsEntity>(Encoding.UTF8.GetString(mySbMsg.Body));

                var info = new DeactivateInformation
                {
                    Host = mySbMsg.ReplyTo
                };
                var msg = await _factory.Deactivated(subscription, info);

                var message = new Message
                {
                    To = "notification",
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg)),
                    ContentType = msg.GetType().Name

                };
                await notificationBus.AddAsync(message);
            }
            catch (Exception e)
            {
                log.LogError(e, "Unhandled error occured...");
            }

        }
    }
}
