namespace Shelly.GraphQLCoreClient.Model
{
     public class LogoutRequest : GraphQLTokenRequest
     {          

          public LogoutRequest()
          {
               NamedQuery = "query";
               OperationName = "getLogin";
               Query = @"query{ getLogout }";
          }
     }
}
