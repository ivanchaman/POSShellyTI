using Newtonsoft.Json;

namespace ShellyPOS.Models
{
    public class LoginModel
    {
        [JsonProperty ("user")]
        public string User { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("company")]
        public int Company { get; set; }
    }
}
