
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSProductsTaxType : ObjectGraphType<ProductsTax>	{

	public POSProductsTaxType()
	{

		Name = "POSProductsTaxType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.ProductId);
			Field(f => f.TaxId);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
