using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Saiive.Notification.Abstractions;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Abstractions.Model.Messages;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Saiive.Notification.Telegram
{
    public class TelegramBot : MessageHandler
    {
        private readonly ILogger<TelegramBot> _logger;

        private const string BotIdProperty = "botId";
        private const string ChannelIdProperty = "channelId";

        public TelegramBot(ILogger<TelegramBot> logger)
        {
            _logger = logger;
        }
        protected override Task<bool> CheckIsValid(SubscriptionsEntity subscription, Dictionary<string, string> connectionSettings)
        {
            if (!connectionSettings.ContainsKey(BotIdProperty))
            {
                throw new ArgumentException($"{BotIdProperty} must be set!", BotIdProperty);
            }

            if (!connectionSettings.ContainsKey(ChannelIdProperty))
            {
                throw new ArgumentException($"{ChannelIdProperty} must be set!", ChannelIdProperty);
            }

            return Task.FromResult(true);
        }

        public override async Task Send(NotifyMessage message, Dictionary<string, string> connectionSettings)
        {
            try
            {
                var telegram = new TelegramBotClient(connectionSettings[BotIdProperty]);
                switch (message)
                {
                    case UrlTextMessage urlMessage:
                        var urlMessageText = $"{urlMessage.Text}".Replace("_", "\\_");
                        await telegram.SendTextMessageAsync(
                            connectionSettings[ChannelIdProperty],
                            urlMessageText,
                            ParseMode.Markdown,
                            replyMarkup:new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(urlMessage.UrlText, urlMessage.Url))
                        );
                        break;
                    default:
                        var msg = $"*{message.Title}*\n{await message.ToMessage()}".Replace("_", "\\_");



                        await telegram.SendTextMessageAsync(
                            connectionSettings[ChannelIdProperty],
                            msg,
                            ParseMode.Markdown
                        );
                        break;
                }

              
            
            }
            catch (Exception e)
            {
                _logger.LogError("Error sending telegram message...", e);
            }
        }
        
        public override NotificationType Type => NotificationType.Telegram;
    }
}
