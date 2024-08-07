namespace Shelly.GraphQLCoreClient.Services
{
     public class UserServices: IUserServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public UserServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }
     }
}
