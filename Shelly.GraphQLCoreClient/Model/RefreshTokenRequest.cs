
namespace Shelly.GraphQLCoreClient.Model
{
     public class RefreshTokenRequest : GraphQLTokenRequest
     {
          public RefreshTokenRequest()
          {
               NamedQuery = "query";
               OperationName = "getLogin";
               Query = @"query{ getLogout }";
          }
     }
}
