
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSInventoryType : ObjectGraphType<Inventory>	{

	public POSInventoryType()
	{

		Name = "POSInventoryType";
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
