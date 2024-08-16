
namespace Shelly.GraphQLCoreClient.Model
{
	public class ExplorationTypeResponse
	{
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
