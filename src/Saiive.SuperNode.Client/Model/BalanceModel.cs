using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class BalanceModel {
    /// <summary>
    /// Gets or Sets Confirmed
    /// </summary>
    [DataMember(Name="confirmed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmed")]
    public double? Confirmed { get; set; }

    /// <summary>
    /// Gets or Sets Unconfirmed
    /// </summary>
    [DataMember(Name="unconfirmed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unconfirmed")]
    public double? Unconfirmed { get; set; }

    /// <summary>
    /// Gets or Sets Balance
    /// </summary>
    [DataMember(Name="balance", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "balance")]
    public double? Balance { get; set; }

    /// <summary>
    /// Gets or Sets Address
    /// </summary>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public string Address { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BalanceModel {\n");
      sb.Append("  Confirmed: ").Append(Confirmed).Append("\n");
      sb.Append("  Unconfirmed: ").Append(Unconfirmed).Append("\n");
      sb.Append("  Balance: ").Append(Balance).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
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
