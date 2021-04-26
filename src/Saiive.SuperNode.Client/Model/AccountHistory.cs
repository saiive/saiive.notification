using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AccountHistory {
    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Gets or Sets BlockHeight
    /// </summary>
    [DataMember(Name="blockHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockHeight")]
    public int? BlockHeight { get; set; }

    /// <summary>
    /// Gets or Sets BlockHash
    /// </summary>
    [DataMember(Name="blockHash", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockHash")]
    public string BlockHash { get; set; }

    /// <summary>
    /// Gets or Sets BlockTime
    /// </summary>
    [DataMember(Name="blockTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockTime")]
    public int? BlockTime { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets PoolID
    /// </summary>
    [DataMember(Name="poolID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "poolID")]
    public string PoolID { get; set; }

    /// <summary>
    /// Gets or Sets Txn
    /// </summary>
    [DataMember(Name="txn", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "txn")]
    public int? Txn { get; set; }

    /// <summary>
    /// Gets or Sets TxId
    /// </summary>
    [DataMember(Name="txId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "txId")]
    public string TxId { get; set; }

    /// <summary>
    /// Gets or Sets Amounts
    /// </summary>
    [DataMember(Name="amounts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amounts")]
    public List<string> Amounts { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AccountHistory {\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  BlockHeight: ").Append(BlockHeight).Append("\n");
      sb.Append("  BlockHash: ").Append(BlockHash).Append("\n");
      sb.Append("  BlockTime: ").Append(BlockTime).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  PoolID: ").Append(PoolID).Append("\n");
      sb.Append("  Txn: ").Append(Txn).Append("\n");
      sb.Append("  TxId: ").Append(TxId).Append("\n");
      sb.Append("  Amounts: ").Append(Amounts).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
