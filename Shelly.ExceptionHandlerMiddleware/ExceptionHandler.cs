

namespace Shelly.ExceptionHandlerMiddleware
{
     internal class ExceptionHandler
     {
          public static async Task<bool> WriteResponseAsync(HttpContext context, IMessageLocalizer localizer)
          {
               IExceptionHandlerFeature exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
               Exception exception = exceptionHandler?.Error;

               if (exception == null)
                    return true;

               await WriteProblemDetailsAsync(
                       context,
                       GetHttpStatusCode(exception),
                       localizer[exception.GetType().Name] == exception.GetType().Name ? exception.Message : localizer[exception.GetType().Name],
                       exception.GetType().Name
                   );
               return false;
          }
          static async Task WriteProblemDetailsAsync(HttpContext context, int statusCode, string title, string instance, object extensions = null)
          {
               ProblemDetails problem = new ProblemDetails()
               {
                    Status = statusCode,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    Title = title,
                    Instance = $"problemDetails/{instance}"
               };
               if (extensions != null)
                    problem.Extensions.Add("errors", extensions);

               await WriteProblemDetailsAsync(context, problem);
          }
          static async Task WriteProblemDetailsAsync(HttpContext context, ProblemDetails problem)
          {
               context.Response.ContentType = "application/problem+json";
               context.Response.StatusCode = problem.Status.Value;

               var stream = context.Response.Body;
               await JsonSerializer.SerializeAsync(stream, problem);
          }
          static int GetHttpStatusCode(Exception exception)
          {
               var httpStatusCodeAttr = exception.GetType().GetCustomAttribute<HttpStatusCodeAttribute>();
               return httpStatusCodeAttr != null ? httpStatusCodeAttr.StatusCode : 500;
          }
     }
}
