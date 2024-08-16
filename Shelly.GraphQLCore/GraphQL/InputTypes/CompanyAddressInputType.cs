
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  CompanyAddressInputType : InputObjectGraphType<CompaniesAddress>	{

	public CompanyAddressInputType()
	{

		Name = "CompanyAddressInputType";
		#region Fields

			Field(f => f.Company);
			Field(f => f.Id);
			Field(f => f.City);
			Field(f => f.Country);
			Field(f => f.State);
			Field(f => f.Street);
			Field(f => f.ZipCode);
			Field(f => f.IsComplete);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
