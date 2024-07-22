
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicPatientsExplorationType : ObjectGraphType<Pagination<PatientsExploration>>	{

	public PaginationMedicalClinicPatientsExplorationType()
	{

		Name = "PaginationMedicalClinicPatientsExplorationType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicPatientsExplorationType>>("Data");
		#endregion

	}
	}
}
