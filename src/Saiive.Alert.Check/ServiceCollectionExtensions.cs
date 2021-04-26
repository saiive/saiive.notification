using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Alert.Check.Abstractions;
using Saiive.Alert.Check.Options;

namespace Saiive.Alert.Check
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlertChecker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<AlertCheck>();
            services.AddSingleton<AlertDispatcher>();

            services.AddSingleton<IAlertPublisher>(a => a.GetRequiredService<AlertDispatcher>());
            services.AddSingleton<IAlertNotifier>(a => a.GetRequiredService<AlertDispatcher>());
            
            services.Configure<AlertConfig>(
                configuration.GetSection(nameof(AlertConfig)));

            return services;
        }
    }
}
