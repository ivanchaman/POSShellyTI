
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSSalesDetailsInputType : InputObjectGraphType<SalesDetails>	{

	public POSSalesDetailsInputType()
	{

		Name = "POSSalesDetailsInputType";
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
