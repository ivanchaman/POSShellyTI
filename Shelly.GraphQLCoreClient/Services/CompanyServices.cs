namespace Shelly.GraphQLCoreClient.Services
{
     public class CompanyServices: ICompanyServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public CompanyServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }
     }
}
