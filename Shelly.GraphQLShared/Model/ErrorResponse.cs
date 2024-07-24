using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.GraphQLShared.Model
{
    public class ErrorResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("subId")]
        public string SubId { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("headerDefinition")]
        public string HeaderDefinition { get; set; }
        [JsonProperty("footherDefinition")]
        public string FootherDefinition { get; set; }
        [JsonProperty("translationKey")]
        public string TranslationKey { get; set; }
        [JsonProperty("defaultMessage")]
        public string DefaultMessage { get; set; }
        [JsonProperty("stack")]
        public string Stack { get; set; }
    }
}
