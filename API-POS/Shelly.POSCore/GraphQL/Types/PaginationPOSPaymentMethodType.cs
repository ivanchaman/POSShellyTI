
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSPaymentMethodType : ObjectGraphType<Pagination<PaymentMethod>>	{

	public PaginationPOSPaymentMethodType()
	{

		Name = "PaginationPOSPaymentMethodType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSPaymentMethodType>>("Data");
		#endregion

	}
	}
}
