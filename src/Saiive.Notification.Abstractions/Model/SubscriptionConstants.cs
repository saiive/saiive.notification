namespace Saiive.Notification.Abstractions.Model
{
    public class SubscriptionConstants
    {
        public static string PartitionKey1Min = $"{Interval.Min_1}";
        public static string PartitionKey5Min = $"{Interval.Min_5}";
        public static string PartitionKey10Min = $"{Interval.Min_10}";
    }
}