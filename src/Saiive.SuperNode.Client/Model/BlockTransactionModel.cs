using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model
{
    [DataContract]
    public class BlockTransactionModel
    {
        [DataMember(Name = "_id", EmitDefaultValue = false)]
        [JsonProperty("_id")]
        string Id { get; set; }

        [DataMember(Name = "txid", EmitDefaultValue = false)]
        [JsonProperty("txid")]
        public string Txid { get; set; }

        [DataMember(Name = "network", EmitDefaultValue = false)]
        [JsonProperty("network")]
        public string Network { get; set; }

        [DataMember(Name = "chain", EmitDefaultValue = false)]
        [JsonProperty("chain")]
        public string Chain { get; set; }

        [DataMember(Name = "blockHeight", EmitDefaultValue = false)]
        [JsonProperty("blockHeight")]
        public long BlockHeight { get; set; }

        [DataMember(Name = "blockHash", EmitDefaultValue = false)]
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [DataMember(Name = "blockTime", EmitDefaultValue = false)]
        [JsonProperty("blockTime")]
        public DateTime BlockTime { get; set; }

        [DataMember(Name = "blockTimeNormalized", EmitDefaultValue = false)]
        [JsonProperty("blockTimeNormalized")]
        public DateTime BlockTimeNormalized { get; set; }

        [DataMember(Name = "coinbase", EmitDefaultValue = false)]
        [JsonProperty("coinbase")]
        public bool Coinbase { get; set; }

        [DataMember(Name = "locktime", EmitDefaultValue = false)]
        [JsonProperty("locktime")]
        public long Locktime { get; set; }

        [DataMember(Name = "inputCount", EmitDefaultValue = false)]
        [JsonProperty("inputCount")]
        public long InputCount { get; set; }

        [DataMember(Name = "outputCount", EmitDefaultValue = false)]
        [JsonProperty("outputCount")]
        public long OutputCount { get; set; }

        [DataMember(Name = "size", EmitDefaultValue = false)]
        [JsonProperty("size")]
        public long Size { get; set; }

        [DataMember(Name = "fee", EmitDefaultValue = false)]
        [JsonProperty("fee")]
        public long Fee { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty("value")]
        public long Value { get; set; }

        [DataMember(Name = "isCustom", EmitDefaultValue = false)]
        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [DataMember(Name = "txType", EmitDefaultValue = false)]
        [JsonProperty("txType")]
        public object TxType { get; set; }

        [DataMember(Name = "customData", EmitDefaultValue = false)]
        [JsonProperty("customData")]
        public object CustomData { get; set; }

        [DataMember(Name = "confirmations", EmitDefaultValue = false)]
        [JsonProperty("confirmations")]
        public long Confirmations { get; set; }

        [DataMember(Name = "details", EmitDefaultValue = false)]
        [JsonProperty("details")]
        public TransactionDetailModel Details { get; set; }

    }
}
