
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Saiive.SuperNode.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TransactionDetailModel {
    /// <summary>
    /// Gets or Sets Inputs
    /// </summary>
    [DataMember(Name="inputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inputs")]
    public List<TransactionModel> Inputs { get; set; }

    /// <summary>
    /// Gets or Sets Outputs
    /// </summary>
    [DataMember(Name="outputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "outputs")]
    public List<TransactionModel> Outputs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransactionDetailModel {\n");
      sb.Append("  Inputs: ").Append(Inputs).Append("\n");
      sb.Append("  Outputs: ").Append(Outputs).Append("\n");
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
