
namespace Shelly.GraphQLCoreClient.Model
{
	public class MedicationDetailsResponse
	{
		[JsonProperty("productId")]
		public long ProductId{ get; set; }
		[JsonProperty("medicineName")]
		public string MedicineName{ get; set; }
		[JsonProperty("genericName")]
		public string GenericName{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("activeIngredient")]
		public string ActiveIngredient{ get; set; }
		[JsonProperty("concentration")]
		public string Concentration{ get; set; }
		[JsonProperty("dosageForm")]
		public string DosageForm{ get; set; }
		[JsonProperty("laboratoryName")]
		public string LaboratoryName{ get; set; }
		[JsonProperty("strength")]
		public string Strength{ get; set; }
		[JsonProperty("unitOfMeasureId")]
		public long UnitOfMeasureId{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }

	}
}
