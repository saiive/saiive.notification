using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Abstractions.Model;
using Saiive.Alert.Check;

namespace Saiive.Alert.Functions.Functions
{
    public class TimerFunction
    {
        private readonly IAlertCheck _check;

        public TimerFunction(IAlertCheck check)
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

            await CheckNewCoinbases(cloudTable, SubscriptionConstants.PartitionKeyCoinbase1Min, notificationBus);
        }

        [FunctionName("Timer5MinNewCoinbase")]
        public async Task CheckNewCoinbaseTx5Min([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(CheckNewCoinbaseTx5Min)}] executed at: {DateTime.Now}");

            await CheckNewCoinbases(cloudTable, SubscriptionConstants.PartitionKeyCoinbase5Min, notificationBus);
        }

        [FunctionName("Timer10MinNewCoinbase")]
        public async Task CheckNewCoinbaseTx10Min([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer,
            [Table("%SubscriptionsTable%", Connection = "Subscriptions")] CloudTable cloudTable,
            [ServiceBus("message", Connection = "MessageTopic")] IAsyncCollector<Message> notificationBus,
            ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function [{nameof(CheckNewCoinbaseTx10Min)}] executed at: {DateTime.Now}");

            await CheckNewCoinbases(cloudTable, SubscriptionConstants.PartitionKeyCoinbase10Min, notificationBus);
        }

        private async Task CheckNewCoinbases(CloudTable cloudTable, string paritionKey, IAsyncCollector<Message> notificationBus)
        {
            var rangeQuery = new TableQuery<SubscriptionsEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                    paritionKey));


            var entities = await cloudTable.ExecuteQuerySegmentedAsync(rangeQuery, null);
            var notifications = await _check.CheckAlerts(entities.Results);

            foreach (var notification in notifications.Notifications)
            {
                var message = new Message
                {
                    CorrelationId = notification.PubKey,
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification)),
                    To = notification.Type
                };
                await notificationBus.AddAsync(message);
            }

            foreach (var sub in entities)
            {
                sub.LastBlockHeight = notifications.CurrentBlockHeight.ToString(CultureInfo.InvariantCulture);

                var operation = TableOperation.Replace(sub);
                await cloudTable.ExecuteAsync(operation);
            }
        }
    }
}
