using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class TiersCards
     {
          [JsonProperty("tier")]
          public int Tier { get; set; }
          [JsonProperty("total")]
          public int Total { get; set; }

          [JsonProperty("CustomCard")]
          public bool CustomCard { get; set; }
     }
}
