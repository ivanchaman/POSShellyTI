namespace Shelly.GraphQLCoreClient.Services
{
     public class POSServices: IPOSServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public POSServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }
     }
}
