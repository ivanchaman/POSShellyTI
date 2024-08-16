
namespace Shelly.GraphQLCoreClient.Model
{
	public class XSLOGSResponse
	{
		[JsonProperty("id")]
		public long ID{ get; set; }
		[JsonProperty("type")]
		public string Type{ get; set; }
		[JsonProperty("dateLog")]
		public DateTime DateLog{ get; set; }
		[JsonProperty("message")]
		public string Message{ get; set; }
		[JsonProperty("stack")]
		public string Stack{ get; set; }
		[JsonProperty("query")]
		public string Query{ get; set; }
		[JsonProperty("reporter")]
		public bool Reporter{ get; set; }

	}
}
