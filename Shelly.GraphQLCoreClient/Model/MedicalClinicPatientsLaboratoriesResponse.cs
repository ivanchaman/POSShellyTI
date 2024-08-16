
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientsLaboratoriesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("medicalServicesId")]
		public long MedicalServicesId{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("imageId")]
		public long ImageId{ get; set; }
		[JsonProperty("laboratoryId")]
		public long LaboratoryId{ get; set; }
		[JsonProperty("typeLaboratoryId")]
		public long TypeLaboratoryId{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
