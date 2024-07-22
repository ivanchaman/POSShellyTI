using Microsoft.AspNetCore.Http;

namespace Shelly.GraphQLCore.Interface
{
     public interface IBlobStorageServices
     {
          public DataAccess GetDataAccess();
          public ICacheContext GetCache();
          public Task<GenericResponse> UploadFile(IFormFile file);
     }
}
