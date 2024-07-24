
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicExplorationTypeType : ObjectGraphType<Pagination<ExplorationType>>	{

	public PaginationMedicalClinicExplorationTypeType()
	{

		Name = "PaginationMedicalClinicExplorationTypeType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicExplorationTypeType>>("Data");
		#endregion

	}
	}
}
