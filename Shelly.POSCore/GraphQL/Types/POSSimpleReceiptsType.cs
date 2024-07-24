
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSSimpleReceiptsType : ObjectGraphType<SimpleReceipts>	{

	public POSSimpleReceiptsType()
	{

		Name = "POSSimpleReceiptsType";
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
