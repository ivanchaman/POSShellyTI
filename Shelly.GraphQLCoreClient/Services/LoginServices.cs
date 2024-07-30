namespace Shelly.GraphQLCoreClient.Services
{
     public class LoginServices : ILoginServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public LoginServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }

          public async Task<GenericResponse<LoginResponse>> Login(LoginData data)
          {
               try
               {
                    var response = await _HttpService.Get<LoginResponse, LoginData>(new LoginRequest<LoginData>()
                    {
                         Variables = new LoginData()
                         {
                              User = data.User,
                              Password = data.Password,
                              Company = _Options.Company
                         }
                    });
                    if(response.Result)
                         response.Response = response.Data.First().Value;
                    return response;
               }
               catch (Exception ex)
               {
                    return new GenericResponse<LoginResponse>()
                    {
                         Result = false,
                         Errors = new List<ErrorResponse>() 
                         {
                              new ErrorResponse ()
                              { 
                                   Id = "-1", 
                                   Stack =ex.Message  
                              }
                         }
                    };
               }

          }
     }
}
