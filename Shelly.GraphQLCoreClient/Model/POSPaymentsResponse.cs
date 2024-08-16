
namespace Shelly.GraphQLCoreClient.Model
{
	public class PaymentsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("saleId")]
		public long SaleId{ get; set; }
		[JsonProperty("amount")]
		public double Amount{ get; set; }
		[JsonProperty("paymentMethodId")]
		public int PaymentMethodId{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
