using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class UpgradeCard
     {
          [JsonProperty("id")]
          public int Id { get; set; }
          [JsonProperty("tier")]
          public int Tier { get; set; }
          [JsonProperty("oldTier")]
          public int OldTier { get; set; }
          [JsonProperty("customCard")]
          public bool CustomCard { get; set; }
     }
}
