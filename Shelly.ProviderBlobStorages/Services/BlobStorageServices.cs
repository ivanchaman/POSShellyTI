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
              
               string url;
               switch ((BlobStorageType)_Options?.BlobStorageType)
               {
                    case BlobStorageType.Local:
                         var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.RandomName);
                         if(!Directory.Exists (Path.GetDirectoryName(path)))
                              Directory.CreateDirectory(Path.GetDirectoryName(path));
                         using (var stream = new FileStream(path, FileMode.Create))
                         {
                              await file.File.CopyToAsync(stream);
                         }
                         return _blobStorageDataServices.BlobStoragesLogs(file.RandomName, file.Extension, path, $"{BlobStorageType.Local}");
                        
                    case BlobStorageType.AmazonS3:
                         var dataAmazonS3 = await _blobStorageDataServices.GetCredentials(_Options.Enviroment, _Options.BlobStorageType);
                         _aWSBlobStorageServices = new AWSBlobStorageServices(new AWSBlobStorageSettings()
                         {
                              User = dataAmazonS3.Usr,
                              Password = dataAmazonS3.Pwd,
                              Region = dataAmazonS3.Region,
                              Acl = dataAmazonS3.Acl,
                              Bucket = dataAmazonS3.Bucket,
                         });
                         url = await _aWSBlobStorageServices.UploadFile(file);
                         return _blobStorageDataServices.BlobStoragesLogs(file.RandomName, file.Extension, url, $"{BlobStorageType.AmazonS3}");                         
                    case BlobStorageType.AzureBlob:
                         var dataAzureBlob = await _blobStorageDataServices.GetCredentials(_Options.Enviroment, _Options.BlobStorageType);
                         BlobContainerClient containerClient = new BlobContainerClient($"DefaultEndpointsProtocol=https;AccountName={dataAzureBlob.AccountName};AccountKey={dataAzureBlob.AccountKey};EndpointSuffix=core.windows.net", dataAzureBlob.ContainerName);
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
