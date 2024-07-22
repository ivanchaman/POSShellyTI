namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class UsersAddressType : ObjectGraphType<UsersAddress>
	{

		public UsersAddressType()
		{

			Name = "UsersAddressType";
			#region Fields

			Field(f => f.UserNumber);
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
