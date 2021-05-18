﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Notification.Check.CheckTypes;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlertCheckerFunction(this IServiceCollection services)
        {
            services.AddSingleton<IChecker, CheckFactory>();

            services.AddSingleton<CoinbaseChecker>();
            services.AddSingleton<UtxoChecker>();

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<AlertConfig>(
                configuration.GetSection(nameof(AlertConfig)));

            return services;
        }
    }
}
