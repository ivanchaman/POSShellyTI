
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSTaxesInputType : InputObjectGraphType<Taxes>	{

	public POSTaxesInputType()
	{

		Name = "POSTaxesInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.Name);
			Field(f => f.Rate);
			Field(f => f.SATTaxCode);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
