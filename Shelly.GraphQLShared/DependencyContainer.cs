namespace Shelly.GraphQLShared
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGraphQLSharedServices(this IServiceCollection services, Action<AppSettings> action)
        {
            AppSettings options = new AppSettings();
            action.Invoke(options);
            services.AddSingleton(options);
            services.TryAddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IHttpGraphQLClientService, HttpGraphQLClientService>();               
            return services;
        }
    }
}
