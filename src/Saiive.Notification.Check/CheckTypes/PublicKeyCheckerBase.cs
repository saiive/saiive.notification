using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;

namespace Saiive.Notification.Check.CheckTypes
{
    public abstract class PublicKeyCheckerBase : BaseChecker
    {

        protected const string PublicKeyProperty = "publicKey";
        protected PublicKeyCheckerBase(IOptions<AlertConfig> config, ILogger<BaseChecker> logger) : base(config, logger)
        {
        }

        public abstract Task<bool> CheckIsValidInternal(SubscriptionsEntity subscriptions, Dictionary<string, string> alertSettings);

        protected override async Task<bool> CheckIsValid(SubscriptionsEntity subscription,
            Dictionary<string, string> alertSettings)
        {
            if (!alertSettings.ContainsKey(PublicKeyProperty))
            {
                throw new ArgumentException($"{PublicKeyProperty} is missing!", PublicKeyProperty);
            }


            return await CheckIsValidInternal(subscription, alertSettings);
        }
    }
}
