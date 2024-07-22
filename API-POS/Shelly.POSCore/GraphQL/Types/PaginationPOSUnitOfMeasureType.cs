
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSUnitOfMeasureType : ObjectGraphType<Pagination<UnitOfMeasure>>	{

	public PaginationPOSUnitOfMeasureType()
	{

		Name = "PaginationPOSUnitOfMeasureType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSUnitOfMeasureType>>("Data");
		#endregion

	}
	}
}
