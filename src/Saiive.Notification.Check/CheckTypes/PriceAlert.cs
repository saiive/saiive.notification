using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    internal class PriceAlertChecker : BaseChecker
    {
        private readonly string _defaultTemplate =
            "🎉🎉 {0} Minted new coinbase\nRewards received {1} $DFI\n\nTxId {2}@{3}\n{4}\n\n🍻🍻";


        public PriceAlertChecker(IOptions<AlertConfig> config,ILogger<CoinbaseChecker> logger) : base(config, logger)
        {
        }


        protected override Task<bool> CheckIsValid(SubscriptionsEntity subscription, Dictionary<string, string> alertSettings)
        {
            throw new NotImplementedException();
        }

        protected override Task<List<NotifyMessage>> OnCheckAlert(SubscriptionsEntity subscription, Dictionary<string, string> alertSettings)
        {
            throw new NotImplementedException();
        }

        public override AlertType Type => AlertType.Price;
    }
}
