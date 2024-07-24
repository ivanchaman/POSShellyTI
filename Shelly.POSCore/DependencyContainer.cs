namespace Shelly.POSCore
{
     public static class DependencyContainer
     {
          public static IServiceCollection AddPosCoreServices(this IServiceCollection services)
          {
               services.AddTransient<IGraphQLServices, GraphQLServices>();   //graph
               services.AddScoped<IDataBlobStorageServices, DataBlobStorageServices>();
               services.AddScoped<Shelly.GraphQLCore.Interface.IBlobStorageServices, Shelly.GraphQLCore.Services.BlobStorageServices>();
               services.AddScoped<IInfoSessionServices, InfoSessionServices>();
               return services;
          }
     }
}
