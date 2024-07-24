using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shelly.Abstractions.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Shelly.ProviderCache
{
    public static class DependencyContainer
     {
          public static IServiceCollection AddProviderCacheService(this IServiceCollection services, Action<Shelly.Abstractions.Settings.Options.Cache> action)
          {
               Shelly.Abstractions.Settings.Options.Cache dataAccessOptions = new Shelly.Abstractions.Settings.Options.Cache();
               action.Invoke(dataAccessOptions);
               services.AddSingleton(dataAccessOptions);
               services.TryAddScoped<ICacheContext, CacheContext>();
               services.TryAddSingleton<IMemoryCache, Microsoft.Extensions.Caching.Memory.MemoryCache>();
               return services;
          }
     }
}
