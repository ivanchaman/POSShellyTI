using Newtonsoft.Json;
using Shelly.Abstractions.Helpers;

namespace Shelly.Abstractions.Model
{
     public class MetadataTransaction
     {
          [JsonProperty("id")]
          public long Id { get; set; }
          [JsonProperty("pool")]
          public long Pool { get; set; }
          [JsonProperty("company")]
          public long Company { get; set; }
          [JsonProperty("userId")]
          public string UserId { get; set; }
          [JsonProperty("amount")]
          public double Amount { get; set; }
          [JsonProperty("description")]
          public string Description { get; set; }
          [JsonProperty("type")]
          public string Type { get; set; }
          [JsonProperty("status")]
          public string Status { get; set; }
          [JsonProperty("createDate")]
          [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ssZ")]
          public DateTime CreateDate { get; set; }
     }
}
