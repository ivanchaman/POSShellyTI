
namespace Shelly.GraphQLCoreClient.Model
{
	public class SecurityResponse
	{
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("keyValue")]
		public string KeyValue{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("code")]
		public string Code{ get; set; }

	}
}
