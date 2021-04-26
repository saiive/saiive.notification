
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TransactionRequest {
    /// <summary>
    /// Gets or Sets RawTx
    /// </summary>
    [DataMember(Name="rawTx", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rawTx")]
    public string RawTx { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransactionRequest {\n");
      sb.Append("  RawTx: ").Append(RawTx).Append("\n");
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
