namespace Shelly.ProviderData.Interfaces
{
    public interface IDbConnectContext : IDisposable
    {
        DataAccess GetDataAccess();
    }
}
