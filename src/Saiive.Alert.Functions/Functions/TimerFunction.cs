using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Saiive.Alert.Check;

namespace Saiive.Alert.Functions.Functions
{
    public class TimerFunction
    {
        private readonly IAlertCheck _check;

        public TimerFunction(IAlertCheck check)
        {
            _check = check;
        }

        [FunctionName("Timer10MinNewCoinbase")]
        public async Task Run([TimerTrigger("0 */10 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _check.CheckAlerts();
        }
    }
}
