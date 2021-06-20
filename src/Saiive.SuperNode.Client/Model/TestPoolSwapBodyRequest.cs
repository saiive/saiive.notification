using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TestPoolSwapBodyRequest {
    /// <summary>
    /// Gets or Sets From
    /// </summary>
    [DataMember(Name="from", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "from")]
    public string From { get; set; }

    /// <summary>
    /// Gets or Sets TokenFrom
    /// </summary>
    [DataMember(Name="tokenFrom", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tokenFrom")]
    public string TokenFrom { get; set; }

    /// <summary>
    /// Gets or Sets AmountFrom
    /// </summary>
    [DataMember(Name="amountFrom", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amountFrom")]
    public double? AmountFrom { get; set; }

    /// <summary>
    /// Gets or Sets To
    /// </summary>
    [DataMember(Name="to", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "to")]
    public string To { get; set; }

    /// <summary>
    /// Gets or Sets TokenTo
    /// </summary>
    [DataMember(Name="tokenTo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tokenTo")]
    public string TokenTo { get; set; }

    /// <summary>
    /// Gets or Sets MaxPrice
    /// </summary>
    [DataMember(Name="maxPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxPrice")]
    public double? MaxPrice { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TestPoolSwapBodyRequest {\n");
      sb.Append("  From: ").Append(From).Append("\n");
      sb.Append("  TokenFrom: ").Append(TokenFrom).Append("\n");
      sb.Append("  AmountFrom: ").Append(AmountFrom).Append("\n");
      sb.Append("  To: ").Append(To).Append("\n");
      sb.Append("  TokenTo: ").Append(TokenTo).Append("\n");
      sb.Append("  MaxPrice: ").Append(MaxPrice).Append("\n");
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
