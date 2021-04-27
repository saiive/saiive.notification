using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Alert.Check.Abstractions;
using Saiive.Alert.Telegram.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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
            if (!Debugger.IsAttached)
            {
                try
                {

                    await _telegram.SendTextMessageAsync(
                        _config.Value.ChannelId,
                        $"Hello. Your friendly masternode alert-service has started 🎉"
                    );
                }
                catch (Exception e)
                {
                    _logger.LogError("Error sending telegram message...", e);
                }
            }

            _handleId = await _notifier.Register(async message =>
            {
                try
                {

                    var msg = $"*{message.PubKey}*\n{message.Message}".Replace("_", "\\_");
                    await _telegram.SendTextMessageAsync(
                    _config.Value.ChannelId,
                    msg, 
                    ParseMode.Markdown
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
                _config.Value.ChannelId,
                $"GoodBye. Your friendly masternode stopped! 😭😭😭"
            );
            await _notifier.UnRegister(_handleId);
        }
    }
}
