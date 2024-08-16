
namespace Shelly.GraphQLCoreClient.Model
{
	public class SalesDetailsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("saleId")]
		public long SaleId{ get; set; }
		[JsonProperty("productId")]
		public long ProductId{ get; set; }
		[JsonProperty("batchId")]
		public long BatchId{ get; set; }
		[JsonProperty("quantity")]
		public int Quantity{ get; set; }
		[JsonProperty("unitPrice")]
		public double UnitPrice{ get; set; }
		[JsonProperty("totalPrice")]
		public double TotalPrice{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
