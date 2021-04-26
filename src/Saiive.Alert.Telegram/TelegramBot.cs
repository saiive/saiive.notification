using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Alert.Check.Abstractions;
using Saiive.Alert.Telegram.Options;
using Telegram.Bot;

namespace Saiive.Alert.Telegram
{
    public class TelegramBot : IHostedService
    {
        private readonly IAlertNotifier _notifier;
        private readonly IOptions<TelegramConfig> _config;
        private readonly ILogger<TelegramBot> _logger;
        private readonly ITelegramBotClient _telegram;
        private Guid _handleId;

        public TelegramBot(IAlertNotifier notifier, IOptions<TelegramConfig> config, ILogger<TelegramBot> logger)
        {
            _notifier = notifier;
            _config = config;
            _logger = logger;
            _telegram = new TelegramBotClient(config.Value.BotId);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {

                await _telegram.SendTextMessageAsync(
                   chatId: _config.Value.ChannelId,
                   text: $"Hello. Your friendly masternode alert-service has started 🎉"
               );
            }
            catch (Exception e)
            {
                _logger.LogError("Error sending telegram message...", e);
            }

            _handleId = await _notifier.Register(async message =>
            {
                try {
                
                    await _telegram.SendTextMessageAsync(
                    chatId: _config.Value.ChannelId,
                    text: $"{message.PubKey}:\n{message.Message}"
                );
                }
                catch (Exception e)
                {
                    _logger.LogError("Error sending telegram message...", e);
                }
            });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _telegram.SendTextMessageAsync(
                chatId: _config.Value.ChannelId,
                text: $"GoodBye. Your friendly masternode stopped! 😭😭😭"
            );
            await _notifier.UnRegister(_handleId);
        }
    }
}
