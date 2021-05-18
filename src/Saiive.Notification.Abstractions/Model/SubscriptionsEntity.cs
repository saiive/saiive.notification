using System.Runtime.Serialization;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Saiive.Notification.Abstractions.Model
{
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Network
    {
        [EnumMember(Value = "mainnet")]
        Mainnet,
        [EnumMember(Value = "testnet")]
        Testnet
    }


    [JsonConverter(typeof(StringEnumConverter))]
    public enum Coin
    {
        [EnumMember(Value = "DFI")]
        DFI,
        [EnumMember(Value = "BTC")]
        Bitcoin
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
        [JsonIgnore]
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
        [JsonIgnore]
        public int LastBlockHeight { get; set; }

        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notificationConnectionString")]
        public string NotificationConnectionString{ get; set; }

        [JsonProperty("isEnabled")]
        [JsonIgnore]
        public bool IsEnabled { get; set; }

        private void SetPartitionKey()
        {
            PartitionKey = $"{AlertType}_{Interval}";
        }

    }
}
