namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class CompaniesUsersType : ObjectGraphType<CompaniesUsers>
	{

		public CompaniesUsersType()
		{

			Name = "CompaniesUsersType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.UserNumber);
			Field(f => f.CurrencyCode);
			#endregion

		}
	}
}
