using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Saiive.Notification.Abstractions.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlertType
    {
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "coinbase")]
        Coinbase,
        [EnumMember(Value = "utxo")]
        Utxo,
        [EnumMember(Value = "whale")]
        Whale,
        [EnumMember(Value = "price")]
        Price
    }
}