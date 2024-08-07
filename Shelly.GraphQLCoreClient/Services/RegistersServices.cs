namespace Shelly.GraphQLCoreClient.Services
{
     public class RegistersServices: IRegistersServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public RegistersServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }
     }
}
