
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientdPrescriptionsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("medicalServicesId")]
		public long MedicalServicesId{ get; set; }
		[JsonProperty("quantity")]
		public double Quantity{ get; set; }
		[JsonProperty("drug")]
		public string Drug{ get; set; }
		[JsonProperty("dosage")]
		public string Dosage{ get; set; }
		[JsonProperty("frequency")]
		public string Frequency{ get; set; }
		[JsonProperty("duration")]
		public string Duration{ get; set; }
		[JsonProperty("substance")]
		public string Substance{ get; set; }
		[JsonProperty("via")]
		public int Via{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
