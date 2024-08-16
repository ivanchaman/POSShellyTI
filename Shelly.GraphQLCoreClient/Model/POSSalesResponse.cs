
namespace Shelly.GraphQLCoreClient.Model
{
	public class SalesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("customerNumber")]
		public long CustomerNumber{ get; set; }
		[JsonProperty("folio")]
		public string Folio{ get; set; }
		[JsonProperty("totalAmount")]
		public double TotalAmount{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
