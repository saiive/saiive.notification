using System;
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
        private readonly IChecker _check;

        public TimerFunction(IChecker check)
        {
            _check = check;
        }

        [FunctionName("Timer1MinNewCoinbase")]
        public async Task CheckNewCoinbaseTx1Min([TimerTrigger("0 */1 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(CheckNewCoinbaseTx1Min)}] executed at: {DateTime.Now}");

            await CheckNewCoinbases(cloudTable, Interval.Min_1 , notificationBus);
        }

        [FunctionName("Timer5MinNewCoinbase")]
        public async Task CheckNewCoinbaseTx5Min([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(CheckNewCoinbaseTx5Min)}] executed at: {DateTime.Now}");

            await CheckNewCoinbases(cloudTable, Interval.Min_5, notificationBus);
        }

        [FunctionName("Timer10MinNewCoinbase")]
        public async Task CheckNewCoinbaseTx10Min([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(CheckNewCoinbaseTx10Min)}] executed at: {DateTime.Now}");

            await CheckNewCoinbases(cloudTable, Interval.Min_10, notificationBus);
        }

        private async Task CheckNewCoinbases(CloudTable cloudTable, Interval interval, IAsyncCollector<Message> notificationBus)
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
                    CorrelationId = notification.PubKey,
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification)),
                    To = notification.Type,
                    
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
