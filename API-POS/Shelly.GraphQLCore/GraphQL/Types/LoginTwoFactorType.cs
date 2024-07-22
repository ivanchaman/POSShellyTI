namespace Shelly.GraphQLCore.GraphQL.Types
{
     public class LoginTwoFactorType : ObjectGraphType<LoginInfo>
     {
          /// <summary>
          /// Initializes a new instance of the <see cref="LoginType"/> class.
          /// </summary>
          public LoginTwoFactorType()
          {
               Name = "LogginTwoFactorType";
               #region Fields
               Field(f => f.SecreteCode).Description("SecretCode");
               Field(f => f.QrCodeUrl).Description("QrCodeUrl");

               #endregion Fields
          }
     }
}
