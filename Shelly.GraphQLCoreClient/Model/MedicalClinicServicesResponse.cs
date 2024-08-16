
namespace Shelly.GraphQLCoreClient.Model
{
	public class ServicesResponse
	{
		[JsonProperty("id")]
		public long Id { get; set; }
		[JsonProperty("company")]
		public long Company { get; set; }
		[JsonProperty("productId")]
		public long ProductId { get; set; }
		[JsonProperty("time")]
		public int Time { get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt { get; set; }

	}
}
