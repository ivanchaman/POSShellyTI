
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientsHistoryResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("customerId")]
		public long CustomerId{ get; set; }
		[JsonProperty("type")]
		public string Type{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("familiar")]
		public string Familiar{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("diagnostico")]
		public string Diagnostico{ get; set; }

	}
}
