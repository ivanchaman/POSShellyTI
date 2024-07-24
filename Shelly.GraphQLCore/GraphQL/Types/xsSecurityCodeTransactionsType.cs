namespace Shelly.GraphQLCore.GraphQL.Types
{
	internal class xsSecurityCodeTransactionsType : ObjectGraphType<SecurityCodeTransactions>
	{

		public xsSecurityCodeTransactionsType()
		{

			Name = "xsSecurityCodeTransactionsType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Uuid);
			Field(f => f.UserNumber);
			Field(f => f.Code);
			Field(f => f.Timeout);
			Field(f => f.Processed);
			Field(f => f.CreateAt);
			#endregion

		}
	}
}
