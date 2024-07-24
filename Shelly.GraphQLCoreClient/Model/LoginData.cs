namespace Shelly.GraphQLCoreClient.Model
{
    public class LoginData
    {
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("company")]
        public int Company { get; set; }
    }
}
