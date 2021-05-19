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
        private readonly ICheckerFactory _check;

        public ApiFunction(ICheckerFactory check)
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
            subscription.IsEnabled = false;
            
            var context = (DefaultHttpContext)req.Properties["HttpContext"];
            var host = context.Request.Host;
            var protocol = context.Request.IsHttps ? "https" : "http";
            var addedMessage = new Message
            {
                To = "added",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(subscription)),
                ReplyTo = $"{protocol}://{host}"

            };

            await notificationBus.AddAsync(addedMessage);

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

            var activateMessage = new Message
            {
                To = "activated",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(subscription)),
                ReplyTo = $"{protocol}://{host}"

            };

            await notificationBus.AddAsync(activateMessage);

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

            subscription.IsEnabled = false;
            var operation = TableOperation.Replace(subscription);
            await cloudTable.ExecuteAsync(operation);

            var context = (DefaultHttpContext)req.Properties["HttpContext"];
            var host = context.Request.Host;
            var protocol = context.Request.IsHttps ? "https" : "http";
          
            var deactivateMessage = new Message
            {
                To = "deactivated",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(subscription)),
                ReplyTo = $"{protocol}://{host}"

            };

            await notificationBus.AddAsync(deactivateMessage);
            return new OkObjectResult("Subscription is now live!");
        }

    }
}
