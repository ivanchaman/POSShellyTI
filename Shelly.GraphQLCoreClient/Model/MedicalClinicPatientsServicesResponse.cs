
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientsServicesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("doctorsId")]
		public long DoctorsId{ get; set; }
		[JsonProperty("customerId")]
		public long CustomerId{ get; set; }
		[JsonProperty("serviceId")]
		public long ServiceId{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
