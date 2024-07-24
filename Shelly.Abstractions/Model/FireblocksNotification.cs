using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class FireblocksNotification
     {
          [JsonProperty("type")]
          public string? Type { get; set; }

          [JsonProperty("tenantId")]
          public string? TenantId { get; set; }

          [JsonProperty("timestamp")]
          public long Timestamp { get; set; }

          [JsonProperty("data")]
          public object? Data { get; set; }
     }
}
