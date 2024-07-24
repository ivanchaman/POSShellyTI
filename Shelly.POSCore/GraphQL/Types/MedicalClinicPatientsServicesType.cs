
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicPatientsServicesType : ObjectGraphType<PatientsServices>	{

	public MedicalClinicPatientsServicesType()
	{

		Name = "MedicalClinicPatientsServicesType";
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
