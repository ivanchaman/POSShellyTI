
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSProductsTaxInputType : InputObjectGraphType<ProductsTax>	{

	public POSProductsTaxInputType()
	{

		Name = "POSProductsTaxInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.ProductId);
			Field(f => f.TaxId);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
