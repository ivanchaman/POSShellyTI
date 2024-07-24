namespace ShellyPOS
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRadzenServices(this IServiceCollection services)
        {            
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            return services;
        }
    }
}
