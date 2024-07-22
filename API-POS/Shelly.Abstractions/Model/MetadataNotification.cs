using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class MetadataNotification
     {
          [JsonProperty("type")]
          public string Type { get; set; }

          [JsonProperty("timestamp")]
          public long Timestamp { get; set; }

          [JsonProperty("data")]
          public object Data { get; set; }
     }
}
