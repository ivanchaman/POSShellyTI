
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSCategoriesType : ObjectGraphType<Pagination<Categories>>	{

	public PaginationPOSCategoriesType()
	{

		Name = "PaginationPOSCategoriesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSCategoriesType>>("Data");
		#endregion

	}
	}
}
