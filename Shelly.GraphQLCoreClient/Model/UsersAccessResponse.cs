
namespace Shelly.GraphQLCoreClient.Model
{
	public class AccessResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("product")]
		public int Product{ get; set; }
		[JsonProperty("dateAccess")]
		public DateTime DateAccess{ get; set; }
		[JsonProperty("status")]
		public bool Status{ get; set; }

	}
}
