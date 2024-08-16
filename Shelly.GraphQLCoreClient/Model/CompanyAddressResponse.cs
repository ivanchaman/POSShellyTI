
namespace Shelly.GraphQLCoreClient.Model
{
	public class AddressResponse
	{
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("city")]
		public string City{ get; set; }
		[JsonProperty("country")]
		public int Country{ get; set; }
		[JsonProperty("state")]
		public string State{ get; set; }
		[JsonProperty("street")]
		public string Street{ get; set; }
		[JsonProperty("zipCode")]
		public string ZipCode{ get; set; }
		[JsonProperty("isComplete")]
		public bool IsComplete{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
