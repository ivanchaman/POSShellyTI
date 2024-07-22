
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSPaymentMethodInputType : InputObjectGraphType<PaymentMethod>	{

	public POSPaymentMethodInputType()
	{

		Name = "POSPaymentMethodInputType";
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
