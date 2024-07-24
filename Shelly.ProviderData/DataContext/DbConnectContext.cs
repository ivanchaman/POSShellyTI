using Shelly.ProviderData.Interfaces;

namespace Shelly.ProviderData.DataContext
{
    public class DbConnectContext : IDbConnectContext
    {
        private DataAccess _connection;
        public DbConnectContext(string connectionString)
        {
            _connection = new DataAccess(connectionString);
        }
        public DataAccess GetDataAccess()
        {
            return _connection;
        }

        public void Dispose() => _connection = null;
    }
}
