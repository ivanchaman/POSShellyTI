namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class CompaniesAddressType : ObjectGraphType<CompaniesAddress>
	{

		public CompaniesAddressType()
		{

			Name = "CompaniesAddressType";
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
