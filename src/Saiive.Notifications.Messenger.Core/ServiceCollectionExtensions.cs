using Microsoft.Extensions.DependencyInjection;
using Saiive.Notification.Mail;
using Saiive.Notification.Telegram;
using Saiive.Notification.Twitter;

namespace Saiive.Notifications.Messenger.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessengerCore(this IServiceCollection services)
        {
            services.AddTelegramBot();
            services.AddMail();
            services.AddTwitter();

            services.AddSingleton<IMessageHandlerFactory, MessageHandlerFactory>();
            return services;
        }
    }
}
