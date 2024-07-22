using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class FinicityNotification
     {

          [JsonProperty("customerId")]
          public string CustomerId { get; set; }

          [JsonProperty("eventType")]
          public string EventType { get; set; }

          [JsonProperty("eventId")]
          public string EventId { get; set; }

          [JsonProperty("payload")]
          public object Payload { get; set; }

     }
}
