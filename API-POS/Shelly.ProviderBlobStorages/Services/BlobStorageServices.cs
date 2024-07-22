using Shelly.Abstractions.Interfaces;
using Shelly.ProviderBlobStorages.Model;
using Azure.Storage.Blobs;

namespace Shelly.ProviderBlobStorages.Services
{
     public class BlobStorageServices : IBlobStorageServices
     {
          private BlobStorages _Options;
          private AWSBlobStorageServices _aWSBlobStorageServices;
          private IDataBlobStorageServices _blobStorageDataServices;

          public BlobStorageServices(IDataBlobStorageServices data, BlobStorages option)
          {
               _blobStorageDataServices = data;
               _Options = option;
          }
          public async Task<long> UploadFile(Files file)
          {
               var data = await _blobStorageDataServices.GetCredentials(_Options.Enviroment, _Options.BlobStorageType);
               string url;
               switch ((BlobStorageType)_Options?.BlobStorageType)
               {
                    case BlobStorageType.AmazonS3:                       
                         _aWSBlobStorageServices = new AWSBlobStorageServices(new AWSBlobStorageSettings()
                         {
                              User = data.Usr,
                              Password = data.Pwd,
                              Region = data.Region,
                              Acl = data.Acl,
                              Bucket = data.Bucket,
                         });
                         url = await _aWSBlobStorageServices.UploadFile(file);
                         return _blobStorageDataServices.BlobStoragesLogs(file.RandomName, file.Extension, url, $"{BlobStorageType.AmazonS3}");                         
                    case BlobStorageType.AzureBlob:
                         BlobContainerClient containerClient = new BlobContainerClient($"DefaultEndpointsProtocol=https;AccountName={data.AccountName};AccountKey={data.AccountKey};EndpointSuffix=core.windows.net", data.ContainerName);
                         await containerClient.CreateIfNotExistsAsync();
                         BlobClient blobClient = containerClient.GetBlobClient(file.OriginalName);
                         await blobClient.UploadAsync(file.File, overwrite: true);
                         url = blobClient.Uri.ToString ();
                         return _blobStorageDataServices.BlobStoragesLogs(file.Name, file.Extension, url, $"{BlobStorageType.AzureBlob}");                         
                    default:
                         return 0;
               }
          }          
     }
}
