namespace Shelly.ExceptionHandlerMiddleware
{
     public static class DependencyContainer
     {
          public static IApplicationBuilder UseShellyExceptionHandler(this IApplicationBuilder app)
          {
               app.UseExceptionHandler(build =>
               {
                    build.Run(async context =>
                    {
                         await ExceptionHandler
                             .WriteResponseAsync(context, app.ApplicationServices.GetRequiredService<IMessageLocalizer>());
                    });
               });
               return app;
          }
     }
}
