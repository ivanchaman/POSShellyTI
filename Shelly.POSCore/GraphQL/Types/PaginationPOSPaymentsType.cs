
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSPaymentsType : ObjectGraphType<Pagination<Payments>>	{

	public PaginationPOSPaymentsType()
	{

		Name = "PaginationPOSPaymentsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSPaymentsType>>("Data");
		#endregion

	}
	}
}
