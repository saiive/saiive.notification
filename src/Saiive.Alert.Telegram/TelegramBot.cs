using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Saiive.Alert.Abstractions;
using Saiive.Alert.Abstractions.Model;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Saiive.Alert.Telegram
{
    public interface ITelegramHandler : IMessageHandler
    {

    }

    public class TelegramBot : ITelegramHandler
    {
        private readonly ILogger<TelegramBot> _logger;
        
        public TelegramBot(ILogger<TelegramBot> logger)
        {
            _logger = logger;
        }
        
        public async Task Send(NotifyMessage message)
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
    }
}
