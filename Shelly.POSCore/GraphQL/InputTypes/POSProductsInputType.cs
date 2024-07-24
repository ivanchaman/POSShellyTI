
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSProductsInputType : InputObjectGraphType<Products>	{

	public POSProductsInputType()
	{

		Name = "POSProductsInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.BarCode);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.CategoryId);
			Field(f => f.UnitOfMeasureId);
			Field(f => f.SATProductCode);
			Field(f => f.SATUnitCode);
			Field(f => f.ImageId);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
