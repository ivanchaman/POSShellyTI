namespace Shelly.GraphQLCoreClient
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGraphQLClientServices(this IServiceCollection services, Action<AppSettings> action)
        {
            AppSettings options = new AppSettings();
            action.Invoke(options);
            services.AddSingleton(options);
            services.TryAddScoped<IAuthenticationServices, AuthenticationServices>();
            services.TryAddScoped<IClinicalMedicalServices, ClinicalMedicalServices>();
            services.TryAddScoped<ICompanyServices, CompanyServices>();
            services.TryAddScoped<IPOSServices, POSServices>();
            services.TryAddScoped<IRegistersServices, RegistersServices>();
            services.TryAddScoped<IUserServices, UserServices>();
            return services;
        }
    }
}
