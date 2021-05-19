using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saiive.Notification.Abstractions.Model;
using Saiive.Notification.Check.Options;
using Saiive.SuperNode.Client.Api;
using Saiive.SuperNode.Client.Client;

namespace Saiive.Notification.Check.CheckTypes
{
    public abstract class BaseChecker : IChecker
    {
        protected readonly AddressApi AddressApi;
        protected readonly TransactionApi TxApi;
        protected readonly BlockApi BlockApi;

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
        }

        public abstract Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions);
        public abstract AlertType Type { get; }

        public Task<int> GetCurrentBlockHeight(SubscriptionsEntity subscription)
        {
            var blockTip = BlockApi.ApiV1NetworkCoinBlockTipGet(subscription.Coin.ToString(),
                subscription.Network.ToString());

            return Task.FromResult(blockTip.Height.Value);
        }
    }
}
