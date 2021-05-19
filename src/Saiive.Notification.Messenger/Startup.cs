using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Saiive.Notification.Messenger;
using Saiive.Notifications.Messenger.Core;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Saiive.Notification.Messenger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMessengerCore();
        }
    }
}