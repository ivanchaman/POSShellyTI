namespace Shelly.GraphQLCoreClient.Model
{
    public class TermAndConditionDocumentResponse
    {
          [JsonProperty("id")]
          public int Id { get; set; }
          [JsonProperty("name")]
          public string Name { get; set; }
          [JsonProperty("description")]
          public string Description { get; set; }
          [JsonProperty("urlDocument")]
          public string UrlDocument { get; set; }
          [JsonProperty("status")]
          public int Status { get; set; }
          [JsonProperty("createdAt")]
          public DateTime CreatedAt { get; set; }
          [JsonProperty("signatureDate")]
          public DateTime SignatureDate { get; set; }
    }
}
