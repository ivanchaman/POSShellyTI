
namespace Shelly.POSCore.GraphQL.Types
{
	public class MedicalClinicServicesType : ObjectGraphType<Shelly.POSProviderData.Repository.Entity.Services>
	{

		public MedicalClinicServicesType()
		{

			Name = "MedicalClinicServicesType";
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
