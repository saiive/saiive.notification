using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saiive.Alert.Abstractions.Model;
using Saiive.Alert.Telegram;

namespace Saiive.Alert.Messenger
{
    public class TelegramMessengerFunction
    {
        private readonly ITelegramHandler _telegramHandler;

        public TelegramMessengerFunction(ITelegramHandler telegramHandler)
        {
            _telegramHandler = telegramHandler;
        }
        [FunctionName("TelegramMessageHandler")]
        public async Task Run([ServiceBusTrigger("message", "telegram", Connection = "MessageTopic")]Message mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            try
            {
                var message = JsonConvert.DeserializeObject<NotifyMessage>(Encoding.UTF8.GetString(mySbMsg.Body));
                await _telegramHandler.Send(message);
            }
            catch(Exception e)
            {
                log.LogError(e, $"Error sending telegram message...");
                //ignore now
            }
        }
    }
}
