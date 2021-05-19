using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Saiive.Notification.Telegram
{
    public class TelegramBot : MessageHandler
    {
        private readonly ILogger<TelegramBot> _logger;
        
        public TelegramBot(ILogger<TelegramBot> logger)
        {
            _logger = logger;
        }
        
        public override async Task Send(NotifyMessage message)
        {
            try
            {
                var telegram = new TelegramBotClient(message.ConnectionStringParts["botId"]);
                var msg = $"*{message.PubKey}*\n{message.Message}".Replace("_", "\\_");
                await telegram.SendTextMessageAsync(
                    message.ConnectionStringParts["channelId"],
                    msg,
                    ParseMode.Markdown
                );
            }
            catch (Exception e)
            {
                _logger.LogError("Error sending telegram message...", e);
            }
        }
        
        public override string Type => "telegram";
    }
}
