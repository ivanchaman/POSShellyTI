
namespace Shelly.GraphQLCoreClient.Model
{
	public class SaleTaxDetailsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("saleId")]
		public long SaleId{ get; set; }
		[JsonProperty("taxId")]
		public long TaxId{ get; set; }
		[JsonProperty("amount")]
		public double Amount{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
