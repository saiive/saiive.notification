using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Alert.Telegram.Options;

namespace Saiive.Alert.Telegram
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<TelegramBot>();


            services.Configure<TelegramConfig>(
                configuration.GetSection(nameof(TelegramConfig)));
            return services;
        }
    }
}
