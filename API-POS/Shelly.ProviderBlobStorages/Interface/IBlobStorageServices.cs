using Shelly.ProviderBlobStorages.Model;

namespace Shelly.ProviderBlobStorages.Interface
{
     public interface IBlobStorageServices
     {
          public Task<long> UploadFile(Files file);         
     }
}
