using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class InfoUser
     {
          [JsonProperty("id")]
          public string Id { get; set; }
          [JsonProperty("fullName")]
          public string FullName { get; set; }
          [JsonProperty("email")]
          public string Email { get; set; }
     }
}
