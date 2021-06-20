using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PoolPairModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Symbol
    /// </summary>
    [DataMember(Name="symbol", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public bool? Status { get; set; }

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
    /// Gets or Sets Commission
    /// </summary>
    [DataMember(Name="commission", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commission")]
    public double? Commission { get; set; }

    /// <summary>
    /// Gets or Sets TotalLiquidity
    /// </summary>
    [DataMember(Name="totalLiquidity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalLiquidity")]
    public double? TotalLiquidity { get; set; }

    /// <summary>
    /// Gets or Sets ReserveADivReserveB
    /// </summary>
    [DataMember(Name="reserveADivReserveB", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reserveADivReserveB")]
    public double? ReserveADivReserveB { get; set; }

    /// <summary>
    /// Gets or Sets ReserveBDivReserveA
    /// </summary>
    [DataMember(Name="reserveBDivReserveA", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reserveBDivReserveA")]
    public double? ReserveBDivReserveA { get; set; }

    /// <summary>
    /// Gets or Sets TradeEnabled
    /// </summary>
    [DataMember(Name="tradeEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tradeEnabled")]
    public bool? TradeEnabled { get; set; }

    /// <summary>
    /// Gets or Sets OwnerAddress
    /// </summary>
    [DataMember(Name="ownerAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ownerAddress")]
    public string OwnerAddress { get; set; }

    /// <summary>
    /// Gets or Sets BlockCommissionA
    /// </summary>
    [DataMember(Name="blockCommissionA", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockCommissionA")]
    public double? BlockCommissionA { get; set; }

    /// <summary>
    /// Gets or Sets BlockCommissionB
    /// </summary>
    [DataMember(Name="blockCommissionB", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockCommissionB")]
    public double? BlockCommissionB { get; set; }

    /// <summary>
    /// Gets or Sets RewardPct
    /// </summary>
    [DataMember(Name="rewardPct", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rewardPct")]
    public double? RewardPct { get; set; }

    /// <summary>
    /// Gets or Sets CustomRewards
    /// </summary>
    [DataMember(Name="customRewards", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customRewards")]
    public List<string> CustomRewards { get; set; }

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
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PoolPairModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Symbol: ").Append(Symbol).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  IdTokenA: ").Append(IdTokenA).Append("\n");
      sb.Append("  IdTokenB: ").Append(IdTokenB).Append("\n");
      sb.Append("  ReserveA: ").Append(ReserveA).Append("\n");
      sb.Append("  ReserveB: ").Append(ReserveB).Append("\n");
      sb.Append("  Commission: ").Append(Commission).Append("\n");
      sb.Append("  TotalLiquidity: ").Append(TotalLiquidity).Append("\n");
      sb.Append("  ReserveADivReserveB: ").Append(ReserveADivReserveB).Append("\n");
      sb.Append("  ReserveBDivReserveA: ").Append(ReserveBDivReserveA).Append("\n");
      sb.Append("  TradeEnabled: ").Append(TradeEnabled).Append("\n");
      sb.Append("  OwnerAddress: ").Append(OwnerAddress).Append("\n");
      sb.Append("  BlockCommissionA: ").Append(BlockCommissionA).Append("\n");
      sb.Append("  BlockCommissionB: ").Append(BlockCommissionB).Append("\n");
      sb.Append("  RewardPct: ").Append(RewardPct).Append("\n");
      sb.Append("  CustomRewards: ").Append(CustomRewards).Append("\n");
      sb.Append("  CreationTx: ").Append(CreationTx).Append("\n");
      sb.Append("  CreationHeight: ").Append(CreationHeight).Append("\n");
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
