
namespace Shelly.GraphQLCoreClient.Model
{
	public class ProductsTaxResponse
	{
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("productId")]
		public long ProductId{ get; set; }
		[JsonProperty("taxId")]
		public long TaxId{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
