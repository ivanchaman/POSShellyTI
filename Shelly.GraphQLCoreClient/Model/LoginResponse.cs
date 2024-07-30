namespace Shelly.GraphQLCoreClient.Model
{
     public class LoginResponse
     {
          [JsonProperty("token")]
          public string Token { get; set; }
          [JsonProperty("hasTwoFactor")]
          public bool HasTwoFactor { get; set; }
          [JsonProperty("status")]
          public int Status { get; set; }
          [JsonProperty("hasTermsStatus")]
          public bool HasTermsStatus { get; set; }
          [JsonProperty("hasUserName")]
          public bool HasUserName { get; set; }

          [JsonProperty("termsServices")]
          public List<TermAndConditionDocumentResponse> TermsServices { get; set; }
     }
}
