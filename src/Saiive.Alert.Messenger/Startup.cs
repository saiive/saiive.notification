using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Saiive.Alert.Messenger;
using Saiive.Alert.Telegram;
using SendGrid.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Saiive.Alert.Messenger
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