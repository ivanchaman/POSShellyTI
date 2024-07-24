
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicPatientsServicesInputType : InputObjectGraphType<PatientsServices>	{

	public MedicalClinicPatientsServicesInputType()
	{

		Name = "MedicalClinicPatientsServicesInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.DoctorsId);
			Field(f => f.CustomerId);
			Field(f => f.ServiceId);
			Field(f => f.Description);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
