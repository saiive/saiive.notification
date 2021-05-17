namespace Saiive.Alert.Abstractions.Model
{
    public class ConfigEntity
    {
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }
        public string Value { get; set; }

    }
}
