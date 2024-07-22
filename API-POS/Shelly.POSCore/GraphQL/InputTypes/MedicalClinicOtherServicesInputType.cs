
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicOtherServicesInputType : InputObjectGraphType<OtherServices>	{

	public MedicalClinicOtherServicesInputType()
	{

		Name = "MedicalClinicOtherServicesInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.CustomerId);
			Field(f => f.Name);
			Field(f => f.Description);
		#endregion

	}
	}
}
