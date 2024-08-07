namespace Shelly.GraphQLCoreClient.Services
{
     public class ClinicalMedicalServices : IClinicalMedicalServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public ClinicalMedicalServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }
     }
}
