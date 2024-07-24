
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSInventoryInputType : InputObjectGraphType<Inventory>	{

	public POSInventoryInputType()
	{

		Name = "POSInventoryInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.BatchId);
			Field(f => f.Quantity);
			Field(f => f.SaleProfitPercentage);
			Field(f => f.SalePrice);
			Field(f => f.WholeSalePrice);
			Field(f => f.Maximun);
			Field(f => f.Minimun);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
