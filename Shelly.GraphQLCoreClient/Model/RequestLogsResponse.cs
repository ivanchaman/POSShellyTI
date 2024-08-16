
namespace Shelly.GraphQLCoreClient.Model
{
	public class RequestLogsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("dateLog")]
		public DateTime DateLog{ get; set; }
		[JsonProperty("product")]
		public string Product{ get; set; }
		[JsonProperty("ipAddress")]
		public string IpAddress{ get; set; }
		[JsonProperty("request")]
		public string Request{ get; set; }
		[JsonProperty("userAgent")]
		public string UserAgent{ get; set; }
		[JsonProperty("queryGraphql")]
		public string QueryGraphql{ get; set; }
		[JsonProperty("variablesGraphql")]
		public string VariablesGraphql{ get; set; }
		[JsonProperty("stack")]
		public string Stack{ get; set; }
		[JsonProperty("valueToken")]
		public string ValueToken{ get; set; }
		[JsonProperty("contentHash")]
		public string ContentHash{ get; set; }
		[JsonProperty("diffTimeHash")]
		public double DiffTimeHash{ get; set; }

	}
}
