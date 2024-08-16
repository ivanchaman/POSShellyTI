
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientsNotesResponse
	{
		[JsonProperty("medicalServicesId")]
		public long MedicalServicesId{ get; set; }
		[JsonProperty("reasons")]
		public string Reasons{ get; set; }
		[JsonProperty("peea")]
		public string PEEA{ get; set; }
		[JsonProperty("laboratoryResults")]
		public string LaboratoryResults{ get; set; }
		[JsonProperty("diagnostics")]
		public string Diagnostics{ get; set; }
		[JsonProperty("remarks")]
		public string Remarks{ get; set; }
		[JsonProperty("forecasts")]
		public string Forecasts{ get; set; }
		[JsonProperty("heartRate")]
		public string HeartRate{ get; set; }
		[JsonProperty("respiratoryRate")]
		public string RespiratoryRate{ get; set; }
		[JsonProperty("oximetry")]
		public double Oximetry{ get; set; }
		[JsonProperty("temperature")]
		public double Temperature{ get; set; }
		[JsonProperty("arterialTension")]
		public string ArterialTension{ get; set; }
		[JsonProperty("height")]
		public double Height{ get; set; }
		[JsonProperty("weight")]
		public double Weight{ get; set; }
		[JsonProperty("waist")]
		public double Waist{ get; set; }
		[JsonProperty("hip")]
		public double Hip{ get; set; }
		[JsonProperty("bmi")]
		public double BMI{ get; set; }
		[JsonProperty("recommendations")]
		public string Recommendations{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
