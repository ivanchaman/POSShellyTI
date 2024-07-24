namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
     internal class UsersAddressInputType : InputObjectGraphType<UsersAddress>
	{

		public UsersAddressInputType()
		{

			Name = "UsersAddressInputType";
			#region Fields
			
			Field(f => f.Id);
			Field(f => f.City);
			Field(f => f.Country);
			Field(f => f.State);
			Field(f => f.Street);
			Field(f => f.ZipCode);
			Field(f => f.IsComplete);
			#endregion

		}
	}
}
