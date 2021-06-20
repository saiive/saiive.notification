using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TransactionModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Chain
    /// </summary>
    [DataMember(Name="chain", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "chain")]
    public string Chain { get; set; }

    /// <summary>
    /// Gets or Sets Network
    /// </summary>
    [DataMember(Name="network", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "network")]
    public string Network { get; set; }

    /// <summary>
    /// Gets or Sets Coinbase
    /// </summary>
    [DataMember(Name="coinbase", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "coinbase")]
    public bool Coinbase { get; set; }

    /// <summary>
    /// Gets or Sets MintIndex
    /// </summary>
    [DataMember(Name="mintIndex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mintIndex")]
    public int? MintIndex { get; set; }

    /// <summary>
    /// Gets or Sets SpentTxId
    /// </summary>
    [DataMember(Name="spentTxId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "spentTxId")]
    public string SpentTxId { get; set; }

    /// <summary>
    /// Gets or Sets MintTxId
    /// </summary>
    [DataMember(Name="mintTxId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mintTxId")]
    public string MintTxId { get; set; }

    /// <summary>
    /// Gets or Sets MintHeight
    /// </summary>
    [DataMember(Name="mintHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mintHeight")]
    public int? MintHeight { get; set; }

    /// <summary>
    /// Gets or Sets SpentHeight
    /// </summary>
    [DataMember(Name="spentHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "spentHeight")]
    public int? SpentHeight { get; set; }

    /// <summary>
    /// Gets or Sets Address
    /// </summary>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public string Address { get; set; }

    /// <summary>
    /// Gets or Sets Script
    /// </summary>
    [DataMember(Name="script", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "script")]
    public string Script { get; set; }

    /// <summary>
    /// Gets or Sets Value
    /// </summary>
    [DataMember(Name="value", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "value")]
    public double? Value { get; set; }

    /// <summary>
    /// Gets or Sets Confirmations
    /// </summary>
    [DataMember(Name="confirmations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmations")]
    public long? Confirmations { get; set; }

    /// <summary>
    /// Gets or Sets Details
    /// </summary>
    [DataMember(Name="details", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "details")]
    public TransactionDetailModel Details { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransactionModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Chain: ").Append(Chain).Append("\n");
      sb.Append("  Network: ").Append(Network).Append("\n");
      sb.Append("  Coinbase: ").Append(Coinbase).Append("\n");
      sb.Append("  MintIndex: ").Append(MintIndex).Append("\n");
      sb.Append("  SpentTxId: ").Append(SpentTxId).Append("\n");
      sb.Append("  MintTxId: ").Append(MintTxId).Append("\n");
      sb.Append("  MintHeight: ").Append(MintHeight).Append("\n");
      sb.Append("  SpentHeight: ").Append(SpentHeight).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  Script: ").Append(Script).Append("\n");
      sb.Append("  Value: ").Append(Value).Append("\n");
      sb.Append("  Confirmations: ").Append(Confirmations).Append("\n");
      sb.Append("  Details: ").Append(Details).Append("\n");
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
