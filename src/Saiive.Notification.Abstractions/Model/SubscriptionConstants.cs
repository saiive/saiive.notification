namespace Saiive.Notification.Abstractions.Model
{
    public class SubscriptionConstants
    {
        public static string PartitionKeyCoinbase1Min = $"{AlertType.Coinbase}_{Interval.Min_1}";
        public static string PartitionKeyCoinbase5Min = $"{AlertType.Coinbase}_{Interval.Min_5}";
        public static string PartitionKeyCoinbase10Min = $"{AlertType.Coinbase}_{Interval.Min_10}";
    }
}