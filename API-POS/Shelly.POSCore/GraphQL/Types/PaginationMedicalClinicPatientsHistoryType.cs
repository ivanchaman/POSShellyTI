
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicPatientsHistoryType : ObjectGraphType<Pagination<PatientsHistory>>	{

	public PaginationMedicalClinicPatientsHistoryType()
	{

		Name = "PaginationMedicalClinicPatientsHistoryType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicPatientsHistoryType>>("Data");
		#endregion

	}
	}
}
