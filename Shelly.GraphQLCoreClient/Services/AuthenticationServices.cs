namespace Shelly.GraphQLCoreClient.Services
{
     public class AuthenticationServices : IAuthenticationServices
     {
          private IHttpGraphQLClientService _HttpService;
          private AppSettings _Options;
          public AuthenticationServices(IHttpGraphQLClientService httpService, AppSettings options)
          {
               _HttpService = httpService;
               _Options = options;
          }

          public async Task<GenericResponse<LoginResponse>> Login(LoginData data)
          {
               return await ExceptionHelper.Try<LoginResponse>(async () =>
               {
                    GenericResponse<LoginResponse> response = await _HttpService.Get<LoginResponse, LoginData>(new LoginRequest<LoginData>()
                    {
                         Variables = new LoginData()
                         {
                              User = data.User,
                              Password = data.Password,
                              Company = _Options.Company
                         }
                    });
                    if (response.Result)
                         response.Response = response.Data.First().Value;
                    return response;
               });
          }

          public async Task<GenericResponse<bool>> Logout(string token)
          {
               return await ExceptionHelper.Try<bool>(async () =>
               {
                    GenericResponse<bool> response = await _HttpService.Post<bool, GraphQLTokenRequest>(new LogoutRequest() { Token = token } );
                    if (response.Result)
                         response.Response = response.Data.First().Value;
                    return response;
               });
          }

          public async Task<GenericResponse<bool>> RefreshToken(string token)
          {
               return await ExceptionHelper.Try<bool>(async () =>
               {
                    GenericResponse<bool> response = await _HttpService.Post<bool, GraphQLTokenRequest>(new RefreshTokenRequest() { Token = token });
                    if (response.Result)
                         response.Response = response.Data.First().Value;
                    return response;
               });
          }
     }
}
