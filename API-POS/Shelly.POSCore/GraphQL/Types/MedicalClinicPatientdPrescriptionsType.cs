
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicPatientdPrescriptionsType : ObjectGraphType<PatientdPrescriptions>	{

	public MedicalClinicPatientdPrescriptionsType()
	{

		Name = "MedicalClinicPatientdPrescriptionsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.MedicalServicesId);
			Field(f => f.Quantity);
			Field(f => f.Drug);
			Field(f => f.Dosage);
			Field(f => f.Frequency);
			Field(f => f.Duration);
			Field(f => f.Substance);
			Field(f => f.Via);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
