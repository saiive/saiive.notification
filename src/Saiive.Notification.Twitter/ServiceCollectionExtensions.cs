using Microsoft.Extensions.DependencyInjection;
using Saiive.Notification.Abstractions;

namespace Saiive.Notification.Twitter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTwitter(this IServiceCollection services)
        {
            services.AddSingleton<TwitterHandler>();
            services.AddSingleton<MessageHandler>(a => a.GetService<TwitterHandler>());

            return services;
        }
    }
}
