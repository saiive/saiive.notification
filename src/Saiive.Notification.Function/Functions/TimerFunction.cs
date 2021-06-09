using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check;

namespace Saiive.Notification.Function.Functions
{
    public class TimerFunction
    {
        private readonly ICheckerFactory _check;

        public TimerFunction(ICheckerFactory check)
        {
            _check = check;
        }

        [FunctionName("Timer1Min")]
        public async Task Timer1Min([TimerTrigger("0 */1 * * * *", RunOnStartup = true)]
            TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")]
            CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")]
            IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(Timer1Min)}] executed at: {DateTime.Now}");


            await Check(cloudTable, Interval.Min_1, notificationBus);
        }


        [FunctionName("Timer5Min")]
        public async Task Timer5Min([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(Timer5Min)}] executed at: {DateTime.Now}");

            await Check(cloudTable, Interval.Min_5, notificationBus);
        }

        [FunctionName("Timer10Min")]
        public async Task Timer10Min([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(Timer10Min)}] executed at: {DateTime.Now}");

            await Check(cloudTable, Interval.Min_10, notificationBus);
        }

        private async Task Check(CloudTable cloudTable, Interval interval, IAsyncCollector<Message> notificationBus)
        {
            var rangeQuery = new TableQuery<SubscriptionsEntity>().Where(TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("IntervalString", QueryComparisons.Equal,
                    interval.ToString()),
                TableOperators.And,
                TableQuery.GenerateFilterConditionForBool("IsEnabled", QueryComparisons.Equal,
                    true)));

            var entities = await cloudTable.ExecuteQuerySegmentedAsync(rangeQuery, null);
            var notifications = await _check.CheckAlerts(entities.Results);

            foreach (var notification in notifications)
            {
                var message = new Message
                {
                    CorrelationId = notification.Title,
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification)),
                    To = "notification",
                    ContentType = notification.GetType().Name

                };
                await notificationBus.AddAsync(message);
            }

            foreach (var sub in entities)
            {
                var operation = TableOperation.Replace(sub);
                await cloudTable.ExecuteAsync(operation);
            }
        }
    }
}
