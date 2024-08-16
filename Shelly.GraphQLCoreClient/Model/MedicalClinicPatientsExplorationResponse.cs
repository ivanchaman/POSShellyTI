
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientsExplorationResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("medicalServicesId")]
		public long MedicalServicesId{ get; set; }
		[JsonProperty("type")]
		public int Type{ get; set; }
		[JsonProperty("observations")]
		public string Observations{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
