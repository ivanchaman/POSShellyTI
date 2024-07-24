namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
     internal class UsersAccountsInputType : InputObjectGraphType<UsersAccounts>
	{

		public UsersAccountsInputType()
		{

			Name = "UsersAccountsInputType";
			#region Fields

			Field(f => f.FirstName);
               Field(f => f.MiddleName);
               Field(f => f.LastName);
			Field(f => f.AvatarImageId);
			Field(f => f.SSNNationalId);
			Field(f => f.Birthday);
			Field(f => f.Gender);
			Field(f => f.IsComplete);			
               Field(f => f.Nationality);
               Field(f => f.PlaceOfBirth);
			Field(f => f.UseBillingToShipping);
               #endregion

          }
	}
}
