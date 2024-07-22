
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSInventoryType : ObjectGraphType<Pagination<Inventory>>	{

	public PaginationPOSInventoryType()
	{

		Name = "PaginationPOSInventoryType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSInventoryType>>("Data");
		#endregion

	}
	}
}
