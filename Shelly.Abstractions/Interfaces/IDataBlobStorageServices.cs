namespace Shelly.Abstractions.Interfaces
{
     public interface IDataBlobStorageServices
     {
          Task<BlobStorageSettings?> GetCredentials( int enviroment, int blobStorageType);
          long BlobStoragesLogs( string fileName, string extension, string url, string provider);
     }
}
