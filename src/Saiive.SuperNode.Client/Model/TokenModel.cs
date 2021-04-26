
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TokenModel {
    /// <summary>
    /// Gets or Sets Symbol
    /// </summary>
    [DataMember(Name="symbol", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or Sets SymbolKey
    /// </summary>
    [DataMember(Name="symbolKey", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "symbolKey")]
    public string SymbolKey { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets _Decimal
    /// </summary>
    [DataMember(Name="decimal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "decimal")]
    public int? _Decimal { get; set; }

    /// <summary>
    /// Gets or Sets Multiplier
    /// </summary>
    [DataMember(Name="multiplier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "multiplier")]
    public int? Multiplier { get; set; }

    /// <summary>
    /// Gets or Sets Mintable
    /// </summary>
    [DataMember(Name="mintable", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mintable")]
    public bool? Mintable { get; set; }

    /// <summary>
    /// Gets or Sets Tradeable
    /// </summary>
    [DataMember(Name="tradeable", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tradeable")]
    public bool? Tradeable { get; set; }

    /// <summary>
    /// Gets or Sets IsDAT
    /// </summary>
    [DataMember(Name="isDAT", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isDAT")]
    public bool? IsDAT { get; set; }

    /// <summary>
    /// Gets or Sets IsLPS
    /// </summary>
    [DataMember(Name="isLPS", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isLPS")]
    public bool? IsLPS { get; set; }

    /// <summary>
    /// Gets or Sets Finalized
    /// </summary>
    [DataMember(Name="finalized", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "finalized")]
    public bool? Finalized { get; set; }

    /// <summary>
    /// Gets or Sets Minted
    /// </summary>
    [DataMember(Name="minted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minted")]
    public double? Minted { get; set; }

    /// <summary>
    /// Gets or Sets CreationTx
    /// </summary>
    [DataMember(Name="creationTx", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creationTx")]
    public string CreationTx { get; set; }

    /// <summary>
    /// Gets or Sets CreationHeight
    /// </summary>
    [DataMember(Name="creationHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creationHeight")]
    public int? CreationHeight { get; set; }

    /// <summary>
    /// Gets or Sets DestructionTx
    /// </summary>
    [DataMember(Name="destructionTx", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destructionTx")]
    public string DestructionTx { get; set; }

    /// <summary>
    /// Gets or Sets DestructionHeight
    /// </summary>
    [DataMember(Name="destructionHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destructionHeight")]
    public int? DestructionHeight { get; set; }

    /// <summary>
    /// Gets or Sets CollateralAddress
    /// </summary>
    [DataMember(Name="collateralAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "collateralAddress")]
    public string CollateralAddress { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TokenModel {\n");
      sb.Append("  Symbol: ").Append(Symbol).Append("\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  SymbolKey: ").Append(SymbolKey).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  _Decimal: ").Append(_Decimal).Append("\n");
      sb.Append("  Multiplier: ").Append(Multiplier).Append("\n");
      sb.Append("  Mintable: ").Append(Mintable).Append("\n");
      sb.Append("  Tradeable: ").Append(Tradeable).Append("\n");
      sb.Append("  IsDAT: ").Append(IsDAT).Append("\n");
      sb.Append("  IsLPS: ").Append(IsLPS).Append("\n");
      sb.Append("  Finalized: ").Append(Finalized).Append("\n");
      sb.Append("  Minted: ").Append(Minted).Append("\n");
      sb.Append("  CreationTx: ").Append(CreationTx).Append("\n");
      sb.Append("  CreationHeight: ").Append(CreationHeight).Append("\n");
      sb.Append("  DestructionTx: ").Append(DestructionTx).Append("\n");
      sb.Append("  DestructionHeight: ").Append(DestructionHeight).Append("\n");
      sb.Append("  CollateralAddress: ").Append(CollateralAddress).Append("\n");
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
