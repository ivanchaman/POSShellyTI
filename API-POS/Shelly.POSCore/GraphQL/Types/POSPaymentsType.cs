
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSPaymentsType : ObjectGraphType<Payments>	{

	public POSPaymentsType()
	{

		Name = "POSPaymentsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.SaleId);
			Field(f => f.Amount);
			Field(f => f.PaymentMethodId);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
