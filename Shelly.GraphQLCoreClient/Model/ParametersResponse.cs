
namespace Shelly.GraphQLCoreClient.Model
{
	public class ParametersResponse
	{
		[JsonProperty("company")]
		public int Company{ get; set; }
		[JsonProperty("parameter")]
		public string Parameter{ get; set; }
		[JsonProperty("value")]
		public string Value{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }

	}
}
