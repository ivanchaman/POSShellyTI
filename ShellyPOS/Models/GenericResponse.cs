using Newtonsoft.Json;

namespace ShellyPOS.Models
{
    public class GenericResponse<T>
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("errors")]
        public List<ErrorResponse> Errors { get; set; }
       
    }
}
