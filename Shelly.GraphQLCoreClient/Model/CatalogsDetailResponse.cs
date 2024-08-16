
namespace Shelly.GraphQLCoreClient.Model
{
	public class CatalogsDetailResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("status")]
		public bool Status{ get; set; }
		[JsonProperty("catalogId")]
		public long CatalogId{ get; set; }

	}
}
