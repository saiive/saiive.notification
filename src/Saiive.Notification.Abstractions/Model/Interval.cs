using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Saiive.Notification.Abstractions.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Interval
    {
        [EnumMember(Value = "Min_1")]
        Min_1,
        
        [EnumMember(Value = "Min_5")]
        Min_5,

        [EnumMember(Value = "Min_10")]
        Min_10
    }
}