using Shelly.ProviderData.DataContext;
using Shelly.ProviderData.Interfaces;

namespace Shelly.ProviderData
{
    public static class DependencyContainer
     {
          public static IServiceCollection AddProviderDataService(this IServiceCollection services, Action<Shelly.Abstractions.Settings.Options.DataAccess> action)
          {
               Shelly.Abstractions.Settings.Options.DataAccess dataAccessOptions = new Shelly.Abstractions.Settings.Options.DataAccess();
               action.Invoke(dataAccessOptions);
               services.AddSingleton(dataAccessOptions.ConnectionString);
               services.TryAddScoped<IDbConnectContext, DbConnectContext>();
               return services;
          }
     }
}
