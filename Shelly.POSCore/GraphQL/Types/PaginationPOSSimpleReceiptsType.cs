
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSSimpleReceiptsType : ObjectGraphType<Pagination<SimpleReceipts>>	{

	public PaginationPOSSimpleReceiptsType()
	{

		Name = "PaginationPOSSimpleReceiptsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSSimpleReceiptsType>>("Data");
		#endregion

	}
	}
}
