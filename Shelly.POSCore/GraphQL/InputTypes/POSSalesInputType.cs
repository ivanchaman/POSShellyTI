
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSSalesInputType : InputObjectGraphType<Sales>	{

	public POSSalesInputType()
	{

		Name = "POSSalesInputType";
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
