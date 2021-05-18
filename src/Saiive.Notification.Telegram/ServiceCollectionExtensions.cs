using Microsoft.Extensions.DependencyInjection;

namespace Saiive.Notification.Telegram
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services)
        {
            services.AddSingleton<ITelegramHandler, TelegramBot>();

            return services;
        }
    }
}
