using Microsoft.Extensions.Configuration;
using Shelly.ProviderData.Interfaces;
using Shelly.ProviderData.Repository.SP;
using Shelly.Abstractions.Model;

namespace Shelly.GraphQLCore.Services
{
     public class DataBlobStorageServices : IDataBlobStorageServices
     {
          private readonly IDbConnectContext _context;
          private readonly ICacheContext _cache;
          private readonly IInfoSessionServices _infoSesion;
          private readonly IConfiguration _section;
          public DataBlobStorageServices(IDbConnectContext context, ICacheContext cache, IInfoSessionServices infoSesion, IConfiguration section)
          {
               _context = context;
               _cache = cache;
               _infoSesion = infoSesion;
               _section = section;
          }
          public async Task<BlobStorageSettings?> GetCredentials(int enviroment, int blobStorageType)
          {
               AccountSystem system = new AccountSystem(_context.GetDataAccess(), _cache, _section);
               LoginInfo? loginInfo = _infoSesion.GetInfoSession();
               if (loginInfo != null)
               {                    
                    system.LogIn(loginInfo.UserNumber, loginInfo.Company);
                    system.InfoSessionToken = loginInfo;
               }
               using ConnectionHandler manager = new ConnectionHandler(system.Connection);
               spGetBlobStorageCredentials credentials = new spGetBlobStorageCredentials(system.Connection)
               {                
                    ProductsType = blobStorageType,
                    Environment = enviroment
               };
               BlobStorageSettings? settings = credentials.GetList<BlobStorageSettings>().FirstOrDefault();
               if (settings == null)
                    throw new CoreException(Errors.E00000105, "BlobStorageCredentials");
               return settings;
          }
          public long BlobStoragesLogs( string fileName, string extension, string url, string provider)
          {
               AccountSystem system = new AccountSystem(_context.GetDataAccess(), _cache, _section);
               LoginInfo? loginInfo = _infoSesion.GetInfoSession();
               if (loginInfo != null)
               {
                    system.LogIn(loginInfo.UserNumber, loginInfo.Company);
                    system.InfoSessionToken = loginInfo;
               }
               BlobStorages log = new BlobStorages(system);
               log.New();
               log.UserNumber = system.Session.User.Number;
               log.FileName = fileName;
               log.FileExtension = extension;
               log.FileUrl = url;
               log.BlobStorageName = provider;
               log.CreateAt = DateTime.Now;
               log.Save();
               return log.Id;
          }
     }
}
