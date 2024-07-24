using Shelly.GraphQLCore.Interface;
using Shelly.ProviderData.Interfaces;

namespace Shelly.GraphQLCore.Services
{
    public class BlobStorageServices : IBlobStorageServices
     {
          private readonly IDbConnectContext _context;
          private readonly ICacheContext _cache;
          private ProviderBlobStorages.Interface.IBlobStorageServices _blobStorages;
          private readonly IHttpContextAccessor _httpContextAccessor;
          public BlobStorageServices(IDbConnectContext context, ICacheContext cache, ProviderBlobStorages.Interface.IBlobStorageServices blobStorage, IHttpContextAccessor httpContextAccessor)
          {
               _context = context;
               _cache = cache;
               _blobStorages = blobStorage;
               _httpContextAccessor = httpContextAccessor;
          }
          public ICacheContext GetCache()
          {
               return _cache;
          }

          public DataAccess GetDataAccess()
          {
               return _context.GetDataAccess();
          }
          public async Task<GenericResponse> UploadFile(IFormFile file)
          {
               //Validations validation = new Validations(_httpContextAccessor.HttpContext.Request, _context.GetDataAccess(), _cache);
               //if (!validation.IsHeaderValid(out LoginInfo? loginInfo, out string error))
               //     return new GenericResponse(_context.GetDataAccess(), error);
               try
               {
                    if (file == null || file.Length == 0)
                    {
                         return new GenericResponse(GetDataAccess(), "E00000006");
                    }
                    using (Stream stream = file.OpenReadStream())
                    {
                         long id = await _blobStorages.UploadFile(new ProviderBlobStorages.Model.Files(file.FileName, stream));
                         dynamic? data = null;
                         data = new { data = id };
                         return new GenericResponse() { Result = true, Data = data };
                    }
               }
               catch(CoreException cx)
               {
                    return new GenericResponse(GetDataAccess(), cx.ErrorId);
               }
               catch(Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }
     }
}
