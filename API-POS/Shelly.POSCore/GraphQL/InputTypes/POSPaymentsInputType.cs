
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSPaymentsInputType : InputObjectGraphType<Payments>	{

	public POSPaymentsInputType()
	{

		Name = "POSPaymentsInputType";
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
