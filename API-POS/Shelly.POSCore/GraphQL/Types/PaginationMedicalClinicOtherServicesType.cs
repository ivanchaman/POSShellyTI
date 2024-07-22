
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicOtherServicesType : ObjectGraphType<Pagination<OtherServices>>	{

	public PaginationMedicalClinicOtherServicesType()
	{

		Name = "PaginationMedicalClinicOtherServicesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicOtherServicesType>>("Data");
		#endregion

	}
	}
}
