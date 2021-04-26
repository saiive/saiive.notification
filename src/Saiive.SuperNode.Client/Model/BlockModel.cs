using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class BlockModel {
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
    /// Gets or Sets Hash
    /// </summary>
    [DataMember(Name="hash", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hash")]
    public string Hash { get; set; }

    /// <summary>
    /// Gets or Sets Size
    /// </summary>
    [DataMember(Name="size", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "size")]
    public int? Size { get; set; }

    /// <summary>
    /// Gets or Sets Height
    /// </summary>
    [DataMember(Name="height", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "height")]
    public int? Height { get; set; }

    /// <summary>
    /// Gets or Sets MerkleRoot
    /// </summary>
    [DataMember(Name="merkleRoot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "merkleRoot")]
    public string MerkleRoot { get; set; }

    /// <summary>
    /// Gets or Sets Time
    /// </summary>
    [DataMember(Name="time", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "time")]
    public string Time { get; set; }

    /// <summary>
    /// Gets or Sets Nonce
    /// </summary>
    [DataMember(Name="nonce", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nonce")]
    public long? Nonce { get; set; }

    /// <summary>
    /// Gets or Sets Bits
    /// </summary>
    [DataMember(Name="bits", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bits")]
    public long? Bits { get; set; }

    /// <summary>
    /// Gets or Sets PreviousBlockHash
    /// </summary>
    [DataMember(Name="previousBlockHash", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "previousBlockHash")]
    public string PreviousBlockHash { get; set; }

    /// <summary>
    /// Gets or Sets NextBlockHash
    /// </summary>
    [DataMember(Name="nextBlockHash", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nextBlockHash")]
    public string NextBlockHash { get; set; }

    /// <summary>
    /// Gets or Sets Reward
    /// </summary>
    [DataMember(Name="reward", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reward")]
    public double? Reward { get; set; }

    /// <summary>
    /// Gets or Sets TransactionCount
    /// </summary>
    [DataMember(Name="transactionCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transactionCount")]
    public int? TransactionCount { get; set; }

    /// <summary>
    /// Gets or Sets Confirmations
    /// </summary>
    [DataMember(Name="confirmations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmations")]
    public int? Confirmations { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BlockModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Chain: ").Append(Chain).Append("\n");
      sb.Append("  Network: ").Append(Network).Append("\n");
      sb.Append("  Hash: ").Append(Hash).Append("\n");
      sb.Append("  Size: ").Append(Size).Append("\n");
      sb.Append("  Height: ").Append(Height).Append("\n");
      sb.Append("  MerkleRoot: ").Append(MerkleRoot).Append("\n");
      sb.Append("  Time: ").Append(Time).Append("\n");
      sb.Append("  Nonce: ").Append(Nonce).Append("\n");
      sb.Append("  Bits: ").Append(Bits).Append("\n");
      sb.Append("  PreviousBlockHash: ").Append(PreviousBlockHash).Append("\n");
      sb.Append("  NextBlockHash: ").Append(NextBlockHash).Append("\n");
      sb.Append("  Reward: ").Append(Reward).Append("\n");
      sb.Append("  TransactionCount: ").Append(TransactionCount).Append("\n");
      sb.Append("  Confirmations: ").Append(Confirmations).Append("\n");
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
