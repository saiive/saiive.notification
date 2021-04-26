using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class FeeEstimateModel {
    /// <summary>
    /// Gets or Sets Blocks
    /// </summary>
    [DataMember(Name="blocks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blocks")]
    public int? Blocks { get; set; }

    /// <summary>
    /// Gets or Sets FeeRate
    /// </summary>
    [DataMember(Name="feeRate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feeRate")]
    public double? FeeRate { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class FeeEstimateModel {\n");
      sb.Append("  Blocks: ").Append(Blocks).Append("\n");
      sb.Append("  FeeRate: ").Append(FeeRate).Append("\n");
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
