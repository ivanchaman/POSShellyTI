namespace Shelly.GraphQLCoreClient.Interfaces
{
     public interface IAuthenticationServices
     {
          Task<GenericResponse<LoginResponse>> Login(LoginData data);
          Task<GenericResponse<Boolean>> Logout(string token);
          Task<GenericResponse<Boolean>> RefreshToken(string token);
     }
}
