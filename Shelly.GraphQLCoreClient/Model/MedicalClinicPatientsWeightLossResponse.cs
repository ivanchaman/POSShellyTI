
namespace Shelly.GraphQLCoreClient.Model
{
	public class PatientsWeightLossResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("customerId")]
		public long CustomerId{ get; set; }
		[JsonProperty("waist")]
		public double Waist{ get; set; }
		[JsonProperty("hip")]
		public double Hip{ get; set; }
		[JsonProperty("weight")]
		public double Weight{ get; set; }
		[JsonProperty("bmi")]
		public double BMI{ get; set; }
		[JsonProperty("fatPercentage")]
		public double FatPercentage{ get; set; }
		[JsonProperty("viceralFatPercentage")]
		public double ViceralFatPercentage{ get; set; }
		[JsonProperty("musclePercentage")]
		public double MusclePercentage{ get; set; }
		[JsonProperty("waterPercentage")]
		public double WaterPercentage{ get; set; }
		[JsonProperty("bonePercentage")]
		public double BonePercentage{ get; set; }
		[JsonProperty("proteinPercentage")]
		public double ProteinPercentage{ get; set; }
		[JsonProperty("metabolism")]
		public double Metabolism{ get; set; }
		[JsonProperty("physicalAge")]
		public double PhysicalAge{ get; set; }
		[JsonProperty("biologicalAge")]
		public double BiologicalAge{ get; set; }
		[JsonProperty("createdAt")]
		public string CreatedAt{ get; set; }

	}
}
