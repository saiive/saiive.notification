using System;
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
        BTC
    }

    public class SubscriptionsEntity : TableEntity
    {
        public SubscriptionsEntity()
        {
            Network = Network.Mainnet;
        }

        [JsonProperty("alertType")]
        public AlertType AlertType { get; set; }

        [JsonProperty("interval")]
        [JsonIgnore]
        public Interval Interval { get; set; }

        [JsonProperty("network")]
        public Network Network { get; set; }

        [JsonProperty("coin")]
        public Coin Coin { get; set; }

        [JsonProperty("notificationType")]
        public NotificationType NotificationType { get; set; }

        [JsonIgnore]
        public int LastStateInteger { get; set; }

        [JsonIgnore]
        public double LastStateDouble { get; set; }

        [JsonIgnore]
        public string LastStateString { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notificationSettings")]
        public string NotificationSettings { get; set; }

        [JsonProperty("alertTypeSettings")]
        public string AlertTypeSettings { get; set; }

        [JsonProperty("isEnabled")]
        [JsonIgnore]
        public bool IsEnabled { get; set; }


        [JsonIgnore]
        public string AlertTypeString
        {
            get
            {
                return AlertType.ToString();
            }
            set
            {
                if (Enum.TryParse(typeof(AlertType), value, out object enuValue))
                {
                    AlertType = (AlertType)enuValue;
                }
            }
        }
        [JsonIgnore]
        public string CoinString
        {
            get
            {
                return Coin.ToString();
            }
            set
            {
                if (Enum.TryParse(typeof(Coin), value, out object enuValue))
                {
                    Coin = (Coin)enuValue;
                }
            }
        }
        [JsonIgnore]
        public string NetworkString
        {
            get
            {
                return Network.ToString();
            }
            set
            {
                if (Enum.TryParse(typeof(Network), value, out object enuValue))
                {
                    Network = (Network)enuValue;
                }
            }
        }
        [JsonIgnore]
        public string IntervalString
        {
            get
            {
                return Interval.ToString();
            }
            set
            {
                if (Enum.TryParse(typeof(Interval), value, out object enuValue))
                {
                    Interval = (Interval)enuValue;
                }
            }
        }

        [JsonIgnore]
        public string NotificationTypeString
        {
            get
            {
                return NotificationType.ToString();
            }
            set
            {
                if (Enum.TryParse(typeof(NotificationType), value, out object enuValue))
                {
                    NotificationType = (NotificationType)enuValue;
                }
            }
        }


    }
}
