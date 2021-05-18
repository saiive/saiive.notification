using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace Saiive.Notification.Abstractions.Model
{
    public enum Network
    {
        Mainnet,
        Testnet
    }

    public enum Coin
    {
        DFI
    }

    public class SubscriptionsEntity : TableEntity
    {
        private AlertType _alertType;
        private Interval _interval;

        public SubscriptionsEntity()
        {
            Network = Network.Mainnet;
        }

        [JsonProperty("type")]
        public AlertType AlertType
        {
            get => _alertType;
            set { _alertType = value; SetPartitionKey(); }
        }

        [JsonProperty("interval")]
        public Interval Interval
        {
            get => _interval;
            set { _interval = value;
                SetPartitionKey();
            }
        }

        [JsonProperty("network")]
        public Network Network { get; set; }

        [JsonProperty("coin")]
        public Coin Coin { get; set; }

        [JsonProperty("lastBlockHeight")]
        public int LastBlockHeight { get; set; }

        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notificationConnectionString")]
        public string NotificationConnectionString{ get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        private void SetPartitionKey()
        {
            PartitionKey = $"{AlertType}_{Interval}";
        }

    }
}
