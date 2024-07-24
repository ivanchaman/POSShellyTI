using Microsoft.Extensions.DependencyInjection.Extensions;
using Shelly.GraphQLCore.Interface;
using Shelly.GraphQLCore.Services;
using Shelly.GraphQLShared.Interfaces;
using Shelly.GraphQLShared.Options;
using Shelly.GraphQLShared.Services;

namespace Shelly.GraphQLCore
{
     public static class DependencyContainer
     {
          public static IServiceCollection AddCoreServices(this IServiceCollection services)
          {
               services.AddTransient<IGraphQLServices, GraphQLServices>();   //graph
               services.AddScoped<IDataBlobStorageServices, DataBlobStorageServices>();
               services.AddScoped<Shelly.GraphQLCore.Interface.IBlobStorageServices, Shelly.GraphQLCore.Services.BlobStorageServices>();
               services.AddScoped<IInfoSessionServices, InfoSessionServices>();
               services.AddScoped<IHeaderValidationServices, HeaderValidationServices>();
               return services;
          }
          public static IServiceCollection AddGraphQLSharedServices(this IServiceCollection services, Action<AppSettings> action)
          {
               AppSettings options = new AppSettings();
               action.Invoke(options);
               services.AddSingleton(options);
               services.TryAddScoped<IEncryptionService, EncryptionService>();
               services.AddScoped<IHeaderValidationServices, HeaderValidationServices>();
               return services;
          }
     }
}
