
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSBatchesInputType : InputObjectGraphType<Batches>	{

	public POSBatchesInputType()
	{

		Name = "POSBatchesInputType";
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
