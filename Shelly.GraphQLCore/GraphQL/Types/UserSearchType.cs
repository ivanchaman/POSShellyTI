namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class UserSearchType : ObjectGraphType<UserSearch>
     {
          public UserSearchType()
          {

               Name = "UserSearchType";
               #region Fields

               Field(f => f.Company);
               Field(f => f.CompanyName);
               Field(f => f.WalletId);
               Field(f => f.AvatarImage);
               Field(f => f.FirstName);
               Field(f => f.LastName);
               Field(f => f.Email);
               Field(f => f.PhoneCode);
               Field(f => f.PhoneNumber);
               #endregion

          }
     }
}
