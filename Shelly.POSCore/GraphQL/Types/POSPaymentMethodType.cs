
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSPaymentMethodType : ObjectGraphType<PaymentMethod>	{

	public POSPaymentMethodType()
	{

		Name = "POSPaymentMethodType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.SATProductCode);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
