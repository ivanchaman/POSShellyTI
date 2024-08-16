
namespace Shelly.GraphQLCoreClient.Model
{
	public class UnitOfMeasureResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
