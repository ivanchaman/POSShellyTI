namespace Shelly.GraphQLShared.Interfaces
{
     public interface IDataEncryptionService
     { 
          string Encrypted(string content);
          string Decoded(string content);
     }
}
