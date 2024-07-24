using Shelly.Abstractions.Interfaces;

namespace Shelly.MessagesLocalizer
{
     public static class DependencyContainer
     {
          public static IServiceCollection AddMessageLocalizer(this IServiceCollection services)
          {
               services.AddSingleton<IMessageLocalizer, MessageLocalizer>();

               return services;
          }
     }
}
