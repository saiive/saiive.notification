using System;
using Microsoft.Extensions.DependencyInjection;
using Saiive.Notification.Abstractions;
using SendGrid.Extensions.DependencyInjection;

namespace Saiive.Notification.Mail
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMail(this IServiceCollection services)
        {
            services.AddSingleton<MailHandler>();
            services.AddSingleton<MessageHandler>(a => a.GetService<MailHandler>());
            services.AddSendGrid(options =>
            {
                options.ApiKey = Environment.GetEnvironmentVariable("SendGridApiKey");
            });
            return services;
        }
    }
}
