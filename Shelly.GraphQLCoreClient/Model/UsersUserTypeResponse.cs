
namespace Shelly.GraphQLCoreClient.Model
{
	public class UserTypeResponse
	{
		[JsonProperty("id")]
		public int ID{ get; set; }
		[JsonProperty("type")]
		public string Type{ get; set; }
		[JsonProperty("active")]
		public bool Active{ get; set; }

	}
}
