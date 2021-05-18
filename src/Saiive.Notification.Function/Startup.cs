using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Saiive.Notification.Check;
using Saiive.Notification.Function;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Saiive.Notification.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAlertCheckerFunction();
        }
    }
}