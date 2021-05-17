using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace Saiive.Alert.Abstractions.Model
{
    public class SubscriptionsEntity : TableEntity
    {
        private AlertType _alertType;
        private Interval _interval;

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

        [JsonProperty("lastBlockHeight")]
        public string LastBlockHeight { get; set; }

        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notificationConnectionString")]
        public string NotificationConnectionString{ get; set; }

        private void SetPartitionKey()
        {
            PartitionKey = $"{AlertType}_{Interval}";
        }

    }
}
