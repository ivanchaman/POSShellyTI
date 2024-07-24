
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSSalesDetailsType : ObjectGraphType<Pagination<SalesDetails>>	{

	public PaginationPOSSalesDetailsType()
	{

		Name = "PaginationPOSSalesDetailsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSSalesDetailsType>>("Data");
		#endregion

	}
	}
}
