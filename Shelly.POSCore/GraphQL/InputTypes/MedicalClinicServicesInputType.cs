
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicServicesInputType : InputObjectGraphType<Shelly.POSProviderData.Repository.Entity.Services>	{

	public MedicalClinicServicesInputType()
	{

		Name = "MedicalClinicServicesInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.ProductId);
			Field(f => f.Time);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
