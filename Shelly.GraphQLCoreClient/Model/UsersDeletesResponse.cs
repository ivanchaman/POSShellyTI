
namespace Shelly.GraphQLCoreClient.Model
{
	public class DeletesResponse
	{
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
