using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Alert.Check.Options;

namespace Saiive.Alert.Check
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlertCheckerFunction(this IServiceCollection services)
        {
            services.AddSingleton<IChecker, CoinbaseChecker>();

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<AlertConfig>(
                configuration.GetSection(nameof(AlertConfig)));

            return services;
        }
    }
}
