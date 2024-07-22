
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSSalesType : ObjectGraphType<Sales>	{

	public POSSalesType()
	{

		Name = "POSSalesType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.UserNumber);
			Field(f => f.CustomerNumber);
			Field(f => f.Folio);
			Field(f => f.TotalAmount);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
