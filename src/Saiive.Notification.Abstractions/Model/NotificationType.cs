using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Saiive.Notification.Abstractions.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationType
    {
        [EnumMember(Value = "telegram")]
        Telegram,
        [EnumMember(Value = "sms")]
        Sms,
        [EnumMember(Value = "mail")]
        Mail,
        [EnumMember(Value = "twitter")]
        Twitter
    }
}