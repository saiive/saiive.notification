using System;
using System.Collections.Generic;
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
        
        private const string ToProperty = "to";

        public MailHandler(ISendGridClient mailHandler, ILogger<MailHandler> log)
        {
            _mailHandler = mailHandler;
            _log = log;
        }
        public override NotificationType Type => NotificationType.Mail;

        protected override Task<bool> CheckIsValid(SubscriptionsEntity subscription, Dictionary<string, string> connectionSettings)
        {
            if (!connectionSettings.ContainsKey(ToProperty))
            {
                throw new ArgumentException($"{ToProperty} must be set!", ToProperty);
            }

            return Task.FromResult(true);
        }

        public override async Task Send(NotifyMessage message, Dictionary<string, string> connectionSettings)
        {
            try
            {
                var msg = MailHelper.CreateSingleEmail(
                    new EmailAddress(Environment.GetEnvironmentVariable("SenderMail"), "Saiive Alert Bot"),
                    new EmailAddress(connectionSettings[ToProperty]), $"Saiive Alert Bot ({message.Title})",
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
                _log.LogError(e, $"Error sending mail message...");
                //ignore now
            }
        }

    }
}
