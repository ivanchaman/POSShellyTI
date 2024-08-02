namespace Shelly.GraphQLShared.Interfaces
{
    public interface IEncryptionService
    {
        string EncryptedRSA1024(string content, string key);
        string DecodedRSA1024(string content, string key);
    }
}
