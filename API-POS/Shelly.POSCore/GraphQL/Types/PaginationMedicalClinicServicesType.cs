
namespace Shelly.POSCore.GraphQL.Types
{
	public class PaginationMedicalClinicServicesType : ObjectGraphType<Pagination<Shelly.POSProviderData.Repository.Entity.Services>>
	{

		public PaginationMedicalClinicServicesType()
		{

			Name = "PaginationMedicalClinicServicesType";
			#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicServicesType>>("Data");
			#endregion

		}
	}
}
