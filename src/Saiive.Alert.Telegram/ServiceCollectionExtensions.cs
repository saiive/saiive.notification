using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Alert.Telegram.Options;

namespace Saiive.Alert.Telegram
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services)
        {
            services.AddHostedService<TelegramBot>();

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.Configure<TelegramConfig>(
                configuration.GetSection(nameof(TelegramConfig)));
            return services;
        }
    }
}
