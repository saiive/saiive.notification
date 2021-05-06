using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Alert.Check.Abstractions;
using Saiive.Alert.Check.Options;

namespace Saiive.Alert.Check
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlertChecker(this IServiceCollection services)
        {
            services.AddHostedService<AlertCheckService>();
            services.AddSingleton<AlertDispatcher>();

            services.AddSingleton<IAlertCheck, AlertCheck>();
            services.AddSingleton<IAlertPublisher>(a => a.GetRequiredService<AlertDispatcher>());
            services.AddSingleton<IAlertNotifier>(a => a.GetRequiredService<AlertDispatcher>());


            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<AlertConfig>(
                configuration.GetSection(nameof(AlertConfig)));

            return services;
        }
        public static IServiceCollection AddAlertCheckerFunction(this IServiceCollection services)
        {
            services.AddSingleton<AlertDispatcher>();

            services.AddSingleton<IAlertCheck, AlertCheck>();
            services.AddSingleton<IAlertPublisher>(a => a.GetRequiredService<AlertDispatcher>());
            services.AddSingleton<IAlertNotifier>(a => a.GetRequiredService<AlertDispatcher>());


            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<AlertConfig>(
                configuration.GetSection(nameof(AlertConfig)));

            return services;
        }
    }
}
