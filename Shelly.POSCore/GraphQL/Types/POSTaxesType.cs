
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSTaxesType : ObjectGraphType<Taxes>	{

	public POSTaxesType()
	{

		Name = "POSTaxesType";
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
