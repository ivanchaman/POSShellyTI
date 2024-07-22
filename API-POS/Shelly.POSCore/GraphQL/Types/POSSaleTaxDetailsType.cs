
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSSaleTaxDetailsType : ObjectGraphType<SaleTaxDetails>	{

	public POSSaleTaxDetailsType()
	{

		Name = "POSSaleTaxDetailsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.SaleId);
			Field(f => f.TaxId);
			Field(f => f.Amount);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
