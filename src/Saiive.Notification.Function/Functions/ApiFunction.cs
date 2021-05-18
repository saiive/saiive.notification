using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aliencube.AzureFunctions.Extensions.OpenApi.Core.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check;

namespace Saiive.Notification.Function.Functions
{

    public class IdRequest : TableEntity
    {
    }

    public class ApiFunction
    {
        private const string FunctionNameAddress = "api/";
        private readonly IChecker _check;

        public ApiFunction(IChecker check)
        {
            _check = check;
        }

        [FunctionName("AddSubscription")]
        [OpenApiOperation(FunctionNameAddress + "AddSubscription", "AddSubscription")]
        [OpenApiRequestBody("application/json", typeof(SubscriptionsEntity))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(SubscriptionsEntity))]
        public async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "add")]
            HttpRequestMessage  req,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var body = await req.Content.ReadAsStringAsync();
            var subscription = JsonConvert.DeserializeObject<SubscriptionsEntity>(body);
            var curBlockHeight = await _check.GetCurrentBlockHeight(subscription);


            subscription.RowKey = Guid.NewGuid().ToString();
            subscription.Interval = Interval.Min_10;
            subscription.LastBlockHeight = curBlockHeight;
            subscription.AlertType = subscription.AlertType;
            subscription.PartitionKey = "free";

            var connectionString = subscription.NotificationConnectionString.Split(';')
                .Select(t => t.Split(new char[] { '=' }, 2))
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

            var type = connectionString["type"];


            if (type == "mail")
            {
                subscription.IsEnabled = false;

                var context = (DefaultHttpContext)req.Properties["HttpContext"];
                var host = context.Request.Host;
                var protocol = context.Request.IsHttps ? "https" : "http";
                var confirmEmail = $"{protocol}://{host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";

                var notification = new NotifyMessage(subscription.NotificationConnectionString, subscription.RowKey,
                    subscription.PartitionKey)
                {
                    Message = confirmEmail,
                    PubKey = subscription.PublicKey
                };

                var message = new Message
                {
                    To = type,
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification))

                };
                await notificationBus.AddAsync(message);

            }
            else
            {
                subscription.IsEnabled = true;
            }

            var operation = TableOperation.Insert(subscription);
            await cloudTable.ExecuteAsync(operation);

            return new OkObjectResult(JsonConvert.SerializeObject(subscription));
        }

        [FunctionName("RemoveSubscription")]
        [OpenApiOperation(FunctionNameAddress + "RemoveSubscription", "RemoveSubscription")]
        [OpenApiRequestBody("application/json", typeof(SubscriptionsEntity))]
        [OpenApiResponseWithBody(HttpStatusCode.NoContent, "application/json", typeof(void))]
        public async Task<IActionResult> Remove(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "remove")]
            IdRequest req,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await Task.CompletedTask;
            req.ETag = "*";
            var operation = TableOperation.Delete(req);
            await cloudTable.ExecuteAsync(operation);

            return new NoContentResult();
        }



        [FunctionName("ActivateSubscription")]
        public async Task<IActionResult> Activate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "activate/{rowKey}/{partitionKey}")]
            HttpRequestMessage  req,

            [Table("%SubscriptionsTable%", "{partitionKey}", "{rowKey}",
                Connection = "Subscriptions")]
            SubscriptionsEntity subscription,

            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            string partitionKey, string rowKey,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (subscription == null)
            {
                return new BadRequestObjectResult("subscription not found");
            }

            subscription.IsEnabled = true;
            var operation = TableOperation.Replace(subscription);
            await cloudTable.ExecuteAsync(operation);

            var context = (DefaultHttpContext)req.Properties["HttpContext"];
            var host = context.Request.Host;
            var protocol = context.Request.IsHttps ? "https" : "http";

            var deactivateLink = $"{protocol}://{host}/api/deactivate/{subscription.RowKey}/{subscription.PartitionKey}";
            var confirmEmail = $"Your subscription has been activated. To disable it use this link: {deactivateLink}";

            var notification = new NotifyMessage(subscription.NotificationConnectionString, subscription.RowKey,
                subscription.PartitionKey)
            {
                Message = confirmEmail,
                PubKey = subscription.PublicKey
            };

            var message = new Message
            {
                To = "mail",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification))

            };
            await notificationBus.AddAsync(message);

            return new OkObjectResult("Subscription is now live!");
        }

        [FunctionName("DeactivateSubscription")]
        public async Task<IActionResult> Deactivate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "deactivate/{rowKey}/{partitionKey}")]
            HttpRequestMessage  req,

            [Table("%SubscriptionsTable%", "{partitionKey}", "{rowKey}",
                Connection = "Subscriptions")]
            SubscriptionsEntity subscription,

            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            string partitionKey, string rowKey,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (subscription == null)
            {
                return new BadRequestObjectResult("subscription not found");
            }

            subscription.IsEnabled = true;
            var operation = TableOperation.Replace(subscription);
            await cloudTable.ExecuteAsync(operation);

            var context = (DefaultHttpContext)req.Properties["HttpContext"];
            var host = context.Request.Host;
            var protocol = context.Request.IsHttps ? "https" : "http";
            var activateLink = $"{protocol}://{host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";
            var confirmEmail = $"Your subscription has been deactivated. To activate it use this link: {activateLink}";

            var notification = new NotifyMessage(subscription.NotificationConnectionString, subscription.RowKey,
                subscription.PartitionKey)
            {
                Message = confirmEmail,
                PubKey = subscription.PublicKey
            };

            var message = new Message
            {
                To = "mail",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification))

            };
            await notificationBus.AddAsync(message);

            return new OkObjectResult("Subscription is now live!");
        }

    }
}
