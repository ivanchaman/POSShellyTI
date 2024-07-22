
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSMedicationDetailsType : ObjectGraphType<MedicationDetails>	{

	public POSMedicationDetailsType()
	{

		Name = "POSMedicationDetailsType";
		#region Fields

			Field(f => f.ProductId);
			Field(f => f.MedicineName);
			Field(f => f.GenericName);
			Field(f => f.Description);
			Field(f => f.ActiveIngredient);
			Field(f => f.Concentration);
			Field(f => f.DosageForm);
			Field(f => f.LaboratoryName);
			Field(f => f.Strength);
			Field(f => f.UnitOfMeasureId);
			Field(f => f.CreatedAt);
			Field(f => f.Status);
		#endregion

	}
	}
}
