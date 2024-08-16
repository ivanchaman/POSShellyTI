
namespace Shelly.GraphQLCoreClient.Model
{
	public class PaymentMethodResponse
	{
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("satProductCode")]
		public string SATProductCode{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
