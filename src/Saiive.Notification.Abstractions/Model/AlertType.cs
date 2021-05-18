using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Saiive.Notification.Abstractions.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlertType
    {
        [EnumMember(Value = "Coinbase")]
        Coinbase,
        [EnumMember(Value = "Utxo")]
        Utxo
    }
}