namespace Shelly.ProviderBlobStorages
{
     public static class DependencyContainer
     {
          public static IServiceCollection AddProviderBlobStorageService(this IServiceCollection services)
          {
               services.AddScoped<IBlobStorageServices, BlobStorageServices>();
               
               return services;
          }
          public static IServiceCollection AddProviderBlobStorageService(this IServiceCollection services, Action<Shelly.Abstractions.Settings.Options.BlobStorages> action)
          {
               Shelly.Abstractions.Settings.Options.BlobStorages options = new Shelly.Abstractions.Settings.Options.BlobStorages();
               action.Invoke(options);
               services.AddSingleton(options);
               services.TryAddScoped<IBlobStorageServices, BlobStorageServices>();
               return services;
          }
     }
}
