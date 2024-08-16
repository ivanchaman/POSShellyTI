
namespace Shelly.GraphQLCoreClient.Model
{
	public class TransactionsQueueResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("startDate")]
		public DateTime StartDate{ get; set; }
		[JsonProperty("endDate")]
		public DateTime EndDate{ get; set; }
		[JsonProperty("module")]
		public int Module{ get; set; }
		[JsonProperty("process")]
		public int Process{ get; set; }
		[JsonProperty("keyValue")]
		public string KeyValue{ get; set; }
		[JsonProperty("inputs")]
		public string Inputs{ get; set; }
		[JsonProperty("outputs")]
		public string Outputs{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("processed")]
		public bool Processed{ get; set; }

	}
}
