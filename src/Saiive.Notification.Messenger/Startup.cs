using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Saiive.Notification.Messenger;
using Saiive.Notification.Telegram;
using SendGrid.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Saiive.Notification.Messenger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTelegramBot();

            builder.Services.AddSendGrid(options =>
            {
                options.ApiKey = Environment.GetEnvironmentVariable("SendGridApiKey");
            });
        }
    }
}