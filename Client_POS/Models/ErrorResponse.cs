using Newtonsoft.Json;

namespace ShellyPOS.Models
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
