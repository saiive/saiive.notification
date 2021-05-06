using Saiive.Alert.Functions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Saiive.Alert.Check;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Saiive.Alert.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAlertCheckerFunction();
        }
    }
}