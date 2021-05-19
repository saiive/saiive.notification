using Microsoft.Extensions.DependencyInjection;
using Saiive.Notification.Abstractions;

namespace Saiive.Notification.Telegram
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services)
        {
            services.AddSingleton<TelegramBot>();
            services.AddSingleton<MessageHandler>(a => a.GetService<TelegramBot>());

            return services;
        }
    }
}
