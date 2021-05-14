using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Saiive.Alert.Messenger
{
    public static class TelegramMessengerFunction
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("message", "telegram", Connection = "%MessageTopic%")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
