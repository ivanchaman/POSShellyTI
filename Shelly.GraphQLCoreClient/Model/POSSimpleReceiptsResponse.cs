
namespace Shelly.GraphQLCoreClient.Model
{
	public class SimpleReceiptsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("saleId")]
		public long SaleId{ get; set; }
		[JsonProperty("receiptNumber")]
		public string ReceiptNumber{ get; set; }
		[JsonProperty("issueDate")]
		public DateTime IssueDate{ get; set; }
		[JsonProperty("totalAmount")]
		public double TotalAmount{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("satFolio")]
		public string SatFolio{ get; set; }
		[JsonProperty("satUuid")]
		public string SatUuid{ get; set; }
		[JsonProperty("satStatus")]
		public string SatStatus{ get; set; }

	}
}
