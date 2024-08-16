
namespace Shelly.GraphQLCoreClient.Model
{
	public class SecurityCodeTransactionsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("uuid")]
		public string Uuid{ get; set; }
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("code")]
		public string Code{ get; set; }
		[JsonProperty("timeout")]
		public int Timeout{ get; set; }
		[JsonProperty("processed")]
		public bool Processed{ get; set; }
		[JsonProperty("createAt")]
		public DateTime CreateAt{ get; set; }

	}
}
