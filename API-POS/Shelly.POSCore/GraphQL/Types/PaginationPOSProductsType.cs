
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSProductsType : ObjectGraphType<Pagination<Products>>	{

	public PaginationPOSProductsType()
	{

		Name = "PaginationPOSProductsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSProductsType>>("Data");
		#endregion

	}
	}
}
