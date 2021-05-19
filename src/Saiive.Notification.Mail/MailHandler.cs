using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Saiive.Notification.Mail
{
    public class MailHandler : MessageHandler
    {
        private readonly ISendGridClient _mailHandler;
        private readonly ILogger<MailHandler> _log;

        public MailHandler(ISendGridClient mailHandler, ILogger<MailHandler> log)
        {
            _mailHandler = mailHandler;
            _log = log;
        }
        public override string Type => "mail";

        public override async Task Send(NotifyMessage message)
        {
            try
            {
                if (!message.ConnectionString.Contains("to"))
                {
                    throw new ArgumentException("'to' must be set as parameter!");
                }
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
            catch (Exception e)
            {
                _log.LogError(e, $"Error sending telegram message...");
                //ignore now
            }
        }

        

    }
}
