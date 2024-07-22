
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSSimpleReceiptsInputType : InputObjectGraphType<SimpleReceipts>	{

	public POSSimpleReceiptsInputType()
	{

		Name = "POSSimpleReceiptsInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.SaleId);
			Field(f => f.ReceiptNumber);
			Field(f => f.IssueDate);
			Field(f => f.TotalAmount);
			Field(f => f.CreatedAt);
			Field(f => f.SatFolio);
			Field(f => f.SatUuid);
			Field(f => f.SatStatus);
		#endregion

	}
	}
}
