using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
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
        private readonly ITelegramBotClient _telegram;
        private Guid _handleId;

        public TelegramBot(IAlertNotifier notifier, IOptions<TelegramConfig> config)
        {
            _notifier = notifier;
            _config = config;
            _telegram = new TelegramBotClient(config.Value.BotId);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _handleId = await _notifier.Register(async message =>
            {
                await _telegram.SendTextMessageAsync(
                    chatId: _config.Value.ChannelId,
                    text: $"{message.PubKey}:\n{message.Message}"
                );
            });

            
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _notifier.UnRegister(_handleId);
        }
    }
}
