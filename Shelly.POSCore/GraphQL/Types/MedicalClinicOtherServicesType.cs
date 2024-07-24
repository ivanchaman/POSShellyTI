
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicOtherServicesType : ObjectGraphType<OtherServices>	{

	public MedicalClinicOtherServicesType()
	{

		Name = "MedicalClinicOtherServicesType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.CustomerId);
			Field(f => f.Name);
			Field(f => f.Description);
		#endregion

	}
	}
}
