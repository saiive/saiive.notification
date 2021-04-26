
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class YieldFramingModel {
    /// <summary>
    /// Gets or Sets Apr
    /// </summary>
    [DataMember(Name="apr", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "apr")]
    public double? Apr { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Pair
    /// </summary>
    [DataMember(Name="pair", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pair")]
    public string Pair { get; set; }

    /// <summary>
    /// Gets or Sets Logo
    /// </summary>
    [DataMember(Name="logo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logo")]
    public string Logo { get; set; }

    /// <summary>
    /// Gets or Sets PoolRewards
    /// </summary>
    [DataMember(Name="poolRewards", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "poolRewards")]
    public List<string> PoolRewards { get; set; }

    /// <summary>
    /// Gets or Sets PairLink
    /// </summary>
    [DataMember(Name="pairLink", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pairLink")]
    public string PairLink { get; set; }

    /// <summary>
    /// Gets or Sets Apy
    /// </summary>
    [DataMember(Name="apy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "apy")]
    public double? Apy { get; set; }

    /// <summary>
    /// Gets or Sets IdTokenA
    /// </summary>
    [DataMember(Name="idTokenA", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "idTokenA")]
    public string IdTokenA { get; set; }

    /// <summary>
    /// Gets or Sets IdTokenB
    /// </summary>
    [DataMember(Name="idTokenB", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "idTokenB")]
    public string IdTokenB { get; set; }

    /// <summary>
    /// Gets or Sets TotalStaked
    /// </summary>
    [DataMember(Name="totalStaked", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalStaked")]
    public double? TotalStaked { get; set; }

    /// <summary>
    /// Gets or Sets PoolPairId
    /// </summary>
    [DataMember(Name="poolPairId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "poolPairId")]
    public string PoolPairId { get; set; }

    /// <summary>
    /// Gets or Sets ReserveA
    /// </summary>
    [DataMember(Name="reserveA", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reserveA")]
    public double? ReserveA { get; set; }

    /// <summary>
    /// Gets or Sets ReserveB
    /// </summary>
    [DataMember(Name="reserveB", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reserveB")]
    public double? ReserveB { get; set; }

    /// <summary>
    /// Gets or Sets VolumeA
    /// </summary>
    [DataMember(Name="volumeA", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "volumeA")]
    public double? VolumeA { get; set; }

    /// <summary>
    /// Gets or Sets VolumeB
    /// </summary>
    [DataMember(Name="volumeB", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "volumeB")]
    public double? VolumeB { get; set; }

    /// <summary>
    /// Gets or Sets TokenASymbol
    /// </summary>
    [DataMember(Name="tokenASymbol", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tokenASymbol")]
    public string TokenASymbol { get; set; }

    /// <summary>
    /// Gets or Sets TokenBSymbol
    /// </summary>
    [DataMember(Name="tokenBSymbol", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tokenBSymbol")]
    public string TokenBSymbol { get; set; }

    /// <summary>
    /// Gets or Sets PriceA
    /// </summary>
    [DataMember(Name="priceA", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priceA")]
    public double? PriceA { get; set; }

    /// <summary>
    /// Gets or Sets PriceB
    /// </summary>
    [DataMember(Name="priceB", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priceB")]
    public double? PriceB { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class YieldFramingModel {\n");
      sb.Append("  Apr: ").Append(Apr).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Pair: ").Append(Pair).Append("\n");
      sb.Append("  Logo: ").Append(Logo).Append("\n");
      sb.Append("  PoolRewards: ").Append(PoolRewards).Append("\n");
      sb.Append("  PairLink: ").Append(PairLink).Append("\n");
      sb.Append("  Apy: ").Append(Apy).Append("\n");
      sb.Append("  IdTokenA: ").Append(IdTokenA).Append("\n");
      sb.Append("  IdTokenB: ").Append(IdTokenB).Append("\n");
      sb.Append("  TotalStaked: ").Append(TotalStaked).Append("\n");
      sb.Append("  PoolPairId: ").Append(PoolPairId).Append("\n");
      sb.Append("  ReserveA: ").Append(ReserveA).Append("\n");
      sb.Append("  ReserveB: ").Append(ReserveB).Append("\n");
      sb.Append("  VolumeA: ").Append(VolumeA).Append("\n");
      sb.Append("  VolumeB: ").Append(VolumeB).Append("\n");
      sb.Append("  TokenASymbol: ").Append(TokenASymbol).Append("\n");
      sb.Append("  TokenBSymbol: ").Append(TokenBSymbol).Append("\n");
      sb.Append("  PriceA: ").Append(PriceA).Append("\n");
      sb.Append("  PriceB: ").Append(PriceB).Append("\n");
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
