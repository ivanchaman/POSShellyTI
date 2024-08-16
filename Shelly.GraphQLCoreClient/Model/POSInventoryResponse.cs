
namespace Shelly.GraphQLCoreClient.Model
{
	public class InventoryResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("batchId")]
		public long BatchId{ get; set; }
		[JsonProperty("quantity")]
		public int Quantity{ get; set; }
		[JsonProperty("saleProfitPercentage")]
		public double SaleProfitPercentage{ get; set; }
		[JsonProperty("salePrice")]
		public double SalePrice{ get; set; }
		[JsonProperty("wholeSalePrice")]
		public double WholeSalePrice{ get; set; }
		[JsonProperty("maximun")]
		public int Maximun{ get; set; }
		[JsonProperty("minimun")]
		public int Minimun{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
