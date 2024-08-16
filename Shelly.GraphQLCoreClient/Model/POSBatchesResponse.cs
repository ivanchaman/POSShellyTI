
namespace Shelly.GraphQLCoreClient.Model
{
	public class BatchesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("productId")]
		public long ProductId{ get; set; }
		[JsonProperty("supplierId")]
		public long SupplierId{ get; set; }
		[JsonProperty("batchNumber")]
		public string BatchNumber{ get; set; }
		[JsonProperty("expirationDate")]
		public string ExpirationDate{ get; set; }
		[JsonProperty("costPrice")]
		public double CostPrice{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
