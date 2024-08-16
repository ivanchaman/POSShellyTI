
namespace Shelly.GraphQLCoreClient.Model
{
	public class TaxesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("rate")]
		public double Rate{ get; set; }
		[JsonProperty("satTaxCode")]
		public string SATTaxCode{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
