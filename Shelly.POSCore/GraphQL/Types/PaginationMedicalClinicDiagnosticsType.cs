
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicDiagnosticsType : ObjectGraphType<Pagination<Diagnostics>>	{

	public PaginationMedicalClinicDiagnosticsType()
	{

		Name = "PaginationMedicalClinicDiagnosticsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicDiagnosticsType>>("Data");
		#endregion

	}
	}
}
