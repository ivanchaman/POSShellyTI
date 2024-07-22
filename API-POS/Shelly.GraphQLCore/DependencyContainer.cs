using Shelly.GraphQLCore.Interface;
using Shelly.GraphQLCore.Services;

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
               return services;
          }
     }
}
