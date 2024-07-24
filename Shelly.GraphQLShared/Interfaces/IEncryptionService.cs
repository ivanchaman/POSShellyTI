namespace Shelly.GraphQLShared.Interfaces
{
    public interface IEncryptionService
    {
        string EncryptedRSA1024(string content);
        string DecodedRSA1024(string content);
    }
}
