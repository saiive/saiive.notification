using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saiive.Alert.Abstractions.Model;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Saiive.Alert.Messenger
{
    public class EmailMessengerFunction 
    {
        private readonly ISendGridClient _mailHandler;

        public EmailMessengerFunction(ISendGridClient mailHandler)
        {
            _mailHandler = mailHandler;
        }
        [FunctionName("EmailMessageHandler")]
        public async Task Run([ServiceBusTrigger("message", "mail", Connection = "MessageTopic")] Message mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            try
            {
                if (mySbMsg.To != "mail")
                {
                    return;
                }
                var message = JsonConvert.DeserializeObject<NotifyMessage>(Encoding.UTF8.GetString(mySbMsg.Body));


                var msg = MailHelper.CreateSingleEmail(
                    new EmailAddress(Environment.GetEnvironmentVariable("SenderMail"), "Saiive Alert Bot"),
                    new EmailAddress(message.ConnectionStringParts["to"]), $"Saiive Alert Bot ({message.PubKey})",
                    "", message.Message);
                
                var response = await _mailHandler.SendEmailAsync(msg);
                var body = await response.Body.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(body);
                }

            }
            catch(Exception e)
            {
                log.LogError(e, $"Error sending telegram message...");
                //ignore now
            }
        }
    }
}
