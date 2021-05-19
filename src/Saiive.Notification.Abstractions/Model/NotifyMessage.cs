using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiive.Notification.Abstractions.Model
{
    public class NotifyMessage
    {
        public NotifyMessage(string connectionString, string rowKey, string partitionKey)
        {
            ConnectionString = connectionString;
            RowKey = rowKey;
            PartitionKey = partitionKey;
            ConnectionStringParts = connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Split(new char[] { '=' }, 2))
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

            Type = ConnectionStringParts["type"];
        }

        public Dictionary<string, string> ConnectionStringParts { get; }

        public string Type { get; }
        public string ConnectionString { get;  }
        public string PubKey { get; set; }
        public string Message { get; set; }

        public string RowKey { get;  }
        public string PartitionKey { get; }
    }
}
