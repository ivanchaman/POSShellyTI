
namespace Shelly.GraphQLCoreClient.Model
{
	public class CatalogsResponse
	{
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("version")]
		public double Version{ get; set; }

	}
}
