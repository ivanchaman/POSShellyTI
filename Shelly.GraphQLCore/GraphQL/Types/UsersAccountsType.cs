namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class UsersAccountsType : ObjectGraphType<UsersAccounts>
	{

		public UsersAccountsType()
		{

			Name = "UsersAccountsType";
			#region Fields

			Field(f => f.UserNumber);
               Field<UsersType>("User");               
			Field(f => f.FirstName);
               Field(f => f.MiddleName);
               Field(f => f.LastName);
			Field(f => f.AvatarImageId);
			Field(f => f.SSNNationalId);
			Field(f => f.Birthday);
			Field(f => f.Gender);
			Field(f => f.IsComplete);
               Field(f => f.UseBillingToShipping);
               Field(f => f.Nationality);
               Field(f => f.PlaceOfBirth);
               Field(f => f.CreatedAt);
               Field<xsBlobStoragesType>("ImageData").Resolve(Query.Accounts.Queries.GetImageData);
               #endregion

          }
	}
}
