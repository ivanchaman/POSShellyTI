
namespace Shelly.GraphQLCoreClient.Model
{
	public class OtherServicesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("customerId")]
		public long CustomerId{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }

	}
}
