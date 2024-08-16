
namespace Shelly.GraphQLCoreClient.Model
{
	public class LaboratoriesTypeResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
