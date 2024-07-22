using GraphQL.Types;
using Shelly.Abstractions.Model;

namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class LoginType : ObjectGraphType<LoginInfo>
     {
          public LoginType()
          {
               Name = "LogginType";
               #region Fields
               Field(f => f.Token);
               Field(f => f.Company);
               Field(f => f.UserNumber);
               Field(f => f.Uuid);
               Field(f => f.HasTwoFactor);                                             
               Field(f => f.HasUserName);
               Field(f => f.Status);
               Field<ListGraphType<TermAndConditionDocumentsType>>("TermsServices");
               #endregion Fields
          }
     }
}
