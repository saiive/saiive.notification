using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;
using Saiive.SuperNode.Client.Api;
using Saiive.SuperNode.Client.Client;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Saiive.Notification.Check.CheckTypes
{
    public abstract class BaseChecker : IChecker
    {
        protected readonly AddressApi AddressApi;
        protected readonly TransactionApi TxApi;
        protected readonly BlockApi BlockApi;
        protected readonly CoingecokApi CoingeckoApi;

        protected readonly ApiClient Client;

        protected readonly IOptions<AlertConfig> Config;
        protected readonly ILogger Logger;

        protected BaseChecker(IOptions<AlertConfig> config, ILogger<BaseChecker> logger)
        {
            Config = config;
            Logger = logger;

            Client = new ApiClient(config.Value.SuperNodeUrl);
            AddressApi = new AddressApi(Client);
            TxApi = new TransactionApi(Client);
            BlockApi = new BlockApi(Client);
            CoingeckoApi = new CoingecokApi(Client);
        }

        protected abstract Task<bool> CheckIsValid(SubscriptionsEntity subscription,
            Dictionary<string, string> alertSettings);

        protected abstract Task<List<NotifyMessage>> OnCheckAlert(SubscriptionsEntity subscription,
            Dictionary<string, string> alertSettings);

        public async Task<bool> IsValid(SubscriptionsEntity subscription)
        {
            var alertSettings = subscription.AlertTypeSettings.Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Split(new char[] { '=' }, 2))
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

            return await CheckIsValid(subscription, alertSettings);
        }

        public async Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions)
        {
            var ret = new List<NotifyMessage>();
            try
            {
                var tasks = new List<Task>();
                foreach (var subscription in subscriptions)
                {
                    var task = new Task(async () =>
                    {
                        var alertSettings = subscription.AlertTypeSettings
                            .Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Select(t => t.Split(new char[] {'='}, 2))
                            .ToDictionary(t => t[0].Trim(), t => t[1].Trim(),
                                StringComparer.InvariantCultureIgnoreCase);

                        var msg = await OnCheckAlert(subscription, alertSettings);

                        if (msg != null)
                        {
                            ret.AddRange(msg);
                        }
                    });
                    tasks.Add(task);
                    task.Start();
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                Logger.LogError("Unknown error,...", e);
            }

            return ret;
        }
        public abstract AlertType Type { get; }

        public Task<int> GetCurrentBlockHeight(SubscriptionsEntity subscription)
        {
            var blockTip = BlockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
                subscription.Network.ToString());

            return Task.FromResult(blockTip.Height.Value);
        }
    }
}
