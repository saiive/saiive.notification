using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CoinPrice {
    /// <summary>
    /// Gets or Sets Coin
    /// </summary>
    [DataMember(Name="coin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "coin")]
    public string Coin { get; set; }

    /// <summary>
    /// Gets or Sets Fiat
    /// </summary>
    [DataMember(Name="fiat", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fiat")]
    public double? Fiat { get; set; }

    /// <summary>
    /// Gets or Sets IdToken
    /// </summary>
    [DataMember(Name="idToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// Gets or Sets Currency
    /// </summary>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CoinPrice {\n");
      sb.Append("  Coin: ").Append(Coin).Append("\n");
      sb.Append("  Fiat: ").Append(Fiat).Append("\n");
      sb.Append("  IdToken: ").Append(IdToken).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
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
