using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Masternode {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets OwnerAuthAddress
    /// </summary>
    [DataMember(Name="ownerAuthAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ownerAuthAddress")]
    public string OwnerAuthAddress { get; set; }

    /// <summary>
    /// Gets or Sets OperatorAuthAddress
    /// </summary>
    [DataMember(Name="operatorAuthAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "operatorAuthAddress")]
    public string OperatorAuthAddress { get; set; }

    /// <summary>
    /// Gets or Sets CreationHeight
    /// </summary>
    [DataMember(Name="creationHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creationHeight")]
    public int? CreationHeight { get; set; }

    /// <summary>
    /// Gets or Sets ResignHeight
    /// </summary>
    [DataMember(Name="resignHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "resignHeight")]
    public int? ResignHeight { get; set; }

    /// <summary>
    /// Gets or Sets ResignTx
    /// </summary>
    [DataMember(Name="resignTx", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "resignTx")]
    public string ResignTx { get; set; }

    /// <summary>
    /// Gets or Sets BanHeight
    /// </summary>
    [DataMember(Name="banHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "banHeight")]
    public int? BanHeight { get; set; }

    /// <summary>
    /// Gets or Sets BanTx
    /// </summary>
    [DataMember(Name="banTx", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "banTx")]
    public string BanTx { get; set; }

    /// <summary>
    /// Gets or Sets State
    /// </summary>
    [DataMember(Name="state", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }

    /// <summary>
    /// Gets or Sets MintedBlocks
    /// </summary>
    [DataMember(Name="mintedBlocks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mintedBlocks")]
    public int? MintedBlocks { get; set; }

    /// <summary>
    /// Gets or Sets OwnerIsMine
    /// </summary>
    [DataMember(Name="ownerIsMine", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ownerIsMine")]
    public bool? OwnerIsMine { get; set; }

    /// <summary>
    /// Gets or Sets OperatorIsMine
    /// </summary>
    [DataMember(Name="operatorIsMine", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "operatorIsMine")]
    public bool? OperatorIsMine { get; set; }

    /// <summary>
    /// Gets or Sets LocalMasternode
    /// </summary>
    [DataMember(Name="localMasternode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "localMasternode")]
    public bool? LocalMasternode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Masternode {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  OwnerAuthAddress: ").Append(OwnerAuthAddress).Append("\n");
      sb.Append("  OperatorAuthAddress: ").Append(OperatorAuthAddress).Append("\n");
      sb.Append("  CreationHeight: ").Append(CreationHeight).Append("\n");
      sb.Append("  ResignHeight: ").Append(ResignHeight).Append("\n");
      sb.Append("  ResignTx: ").Append(ResignTx).Append("\n");
      sb.Append("  BanHeight: ").Append(BanHeight).Append("\n");
      sb.Append("  BanTx: ").Append(BanTx).Append("\n");
      sb.Append("  State: ").Append(State).Append("\n");
      sb.Append("  MintedBlocks: ").Append(MintedBlocks).Append("\n");
      sb.Append("  OwnerIsMine: ").Append(OwnerIsMine).Append("\n");
      sb.Append("  OperatorIsMine: ").Append(OperatorIsMine).Append("\n");
      sb.Append("  LocalMasternode: ").Append(LocalMasternode).Append("\n");
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
