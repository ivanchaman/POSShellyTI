namespace Shelly.GraphQLShared.Services
{
     public class NetworkEncryptionServices : IDataEncryptionService
     {
          private AppSettings _Options;
          private readonly IEncryptionService _EncryptionService;

          public NetworkEncryptionServices(IEncryptionService encryptionService, AppSettings options)
          {
               _EncryptionService = encryptionService;
               _Options = options;
          }
          public string Decoded(string content)
          {
               return _EncryptionService.DecodedRSA1024(content, _Options.NPrivateKey);
          }

          public string Encrypted(string content)
          {
               return _EncryptionService.EncryptedRSA1024(content, _Options.NPublicKey);
          }
     }
}
