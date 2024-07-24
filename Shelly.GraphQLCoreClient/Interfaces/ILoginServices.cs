namespace Shelly.GraphQLCoreClient.Interfaces
{
    public interface ILoginServices
    {     
        Task<GenericResponse<LoginResponse>> Login(LoginData data);
    }
}
