using System.Text.Json;

namespace Shelly.GraphQLShared.Model
{
     public class GraphQLTokenRequest: GraphQLRequest
     {
          [JsonIgnore]
          public string Token { get; set; }
     }
}
