
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSBatchesType : ObjectGraphType<Batches>	{

	public POSBatchesType()
	{

		Name = "POSBatchesType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.ProductId);
			Field(f => f.SupplierId);
			Field(f => f.BatchNumber);
			Field(f => f.ExpirationDate);
			Field(f => f.CostPrice);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
