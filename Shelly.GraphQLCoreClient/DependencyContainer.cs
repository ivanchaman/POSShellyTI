
namespace Shelly.GraphQLCoreClient
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGraphQLClientServices(this IServiceCollection services, Action<AppSettings> action)
        {
            AppSettings options = new AppSettings();
            action.Invoke(options);
            services.AddSingleton(options);
            services.TryAddScoped<ILoginServices, LoginServices>();
            return services;
        }
    }
}
