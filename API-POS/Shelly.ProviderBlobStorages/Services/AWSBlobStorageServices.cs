using Shelly.ProviderBlobStorages.Model;

namespace Shelly.ProviderBlobStorages.Services
{
     internal class AWSBlobStorageServices : IAWSBlobStorageServices
     {
          private AmazonS3Client _S3Client;
          private AWSBlobStorageSettings _Options;
          
          public AWSBlobStorageServices(AWSBlobStorageSettings option)
          {
               _S3Client = ConfigureSesClient(option);
               _Options = option;
          }

          private AmazonS3Client ConfigureSesClient(AWSBlobStorageSettings option)
          {
               switch (option.Region)
               {
                    case "USEast1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USEast1);

                    case "CACentral1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.CACentral1);

                    case "CNNorthWest1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.CNNorthWest1);

                    case "CNNorth1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.CNNorth1);

                    case "USGovCloudWest1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USGovCloudWest1);

                    case "USGovCloudEast1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USGovCloudEast1);

                    case "SAEast1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.SAEast1);

                    case "APSoutheast2":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APSoutheast2);

                    case "APSouth1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APSouth1);

                    case "APNortheast3":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APNortheast3);

                    case "APNortheast2":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APNortheast2);

                    case "APSoutheast1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APSoutheast1);

                    case "APEast1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APEast1);

                    case "USEast2":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USEast2);

                    case "APNortheast1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.APNortheast1);

                    case "USWest2":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USWest2);

                    case "EUNorth1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.EUNorth1);

                    case "USWest1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USWest1);

                    case "EUWest2":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.EUWest2);

                    case "EUWest3":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.EUWest3);

                    case "EUCentral1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.EUCentral1);

                    case "EUWest1":
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.EUWest1);

                    default:
                         return new AmazonS3Client(option.User, option.Password, RegionEndpoint.USWest2);
               }
          }

          public async Task<string> UploadFile(Files file)
          {
               var objReq = new PutObjectRequest
               {
                    Key = $"{file.RandomName}",
                    InputStream = file.File,
                    ContentType = file.ContentType,
                    BucketName = _Options.Bucket
               };
               switch (_Options.Acl)
               {
                    case "public-read":
                         objReq.CannedACL = S3CannedACL.PublicRead;
                         break;
                    case "noacl":
                         objReq.CannedACL = S3CannedACL.NoACL;
                         break;
                    case "private":
                         objReq.CannedACL = S3CannedACL.Private;
                         break;
                    case "publicreadwrite":
                         objReq.CannedACL = S3CannedACL.PublicReadWrite;
                         break;
                    case "authenticatedread":
                         objReq.CannedACL = S3CannedACL.AuthenticatedRead;
                         break;
                    case "awsexecread":
                         objReq.CannedACL = S3CannedACL.AWSExecRead;
                         break;
                    case "bucketownerread":
                         objReq.CannedACL = S3CannedACL.BucketOwnerRead;
                         break;
                    case "bucketownerfullcontrol":
                         objReq.CannedACL = S3CannedACL.BucketOwnerFullControl;
                         break;
                    case "logdeliverywrite":
                         objReq.CannedACL = S3CannedACL.LogDeliveryWrite;
                         break;
               }
               PutObjectResponse response = await _S3Client.PutObjectAsync(objReq);
               if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return $"https://{_Options.Bucket}.{_S3Client.Config.AuthenticationServiceName}-{_S3Client.Config.RegionEndpoint.SystemName}.{_S3Client.Config.RegionEndpoint.PartitionDnsSuffix}/{file.RandomName}";
               return "";
          }        
     }
}
