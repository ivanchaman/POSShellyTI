
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSSaleTaxDetailsInputType : InputObjectGraphType<SaleTaxDetails>	{

	public POSSaleTaxDetailsInputType()
	{

		Name = "POSSaleTaxDetailsInputType";
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
