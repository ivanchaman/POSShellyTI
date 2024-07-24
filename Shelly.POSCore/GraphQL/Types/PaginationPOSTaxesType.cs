
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSTaxesType : ObjectGraphType<Pagination<Taxes>>	{

	public PaginationPOSTaxesType()
	{

		Name = "PaginationPOSTaxesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSTaxesType>>("Data");
		#endregion

	}
	}
}
