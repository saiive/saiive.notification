using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Saiive.Notification.Abstractions.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationType
    {
        [EnumMember(Value = "Telegram")]
        Telegram,
        [EnumMember(Value = "Sms")]
        Sms,
        [EnumMember(Value = "Email")]
        Email
    }
}