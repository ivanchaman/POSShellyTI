using Shelly.ProviderBlobStorages.Model;

namespace Shelly.ProviderBlobStorages.Interface
{
     internal interface IAWSBlobStorageServices
     {
          Task<string> UploadFile(Files file);
     }
}
