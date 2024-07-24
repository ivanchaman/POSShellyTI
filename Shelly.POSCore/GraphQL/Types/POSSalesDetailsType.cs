
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSSalesDetailsType : ObjectGraphType<SalesDetails>	{

	public POSSalesDetailsType()
	{

		Name = "POSSalesDetailsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.SaleId);
			Field(f => f.ProductId);
			Field(f => f.BatchId);
			Field(f => f.Quantity);
			Field(f => f.UnitPrice);
			Field(f => f.TotalPrice);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
