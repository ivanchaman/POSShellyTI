
namespace Shelly.GraphQLCoreClient.Model
{
	public class PromotionsProductResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("promotionId")]
		public long PromotionId{ get; set; }
		[JsonProperty("productId")]
		public long ProductId{ get; set; }

	}
}
