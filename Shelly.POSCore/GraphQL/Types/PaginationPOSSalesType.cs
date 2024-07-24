
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSSalesType : ObjectGraphType<Pagination<Sales>>	{

	public PaginationPOSSalesType()
	{

		Name = "PaginationPOSSalesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSSalesType>>("Data");
		#endregion

	}
	}
}
