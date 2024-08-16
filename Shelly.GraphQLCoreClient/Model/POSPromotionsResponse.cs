
namespace Shelly.GraphQLCoreClient.Model
{
	public class PromotionsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("startDate")]
		public string StartDate{ get; set; }
		[JsonProperty("endDate")]
		public string EndDate{ get; set; }
		[JsonProperty("discountPercentage")]
		public double DiscountPercentage{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("type")]
		public int Type{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }

	}
}
