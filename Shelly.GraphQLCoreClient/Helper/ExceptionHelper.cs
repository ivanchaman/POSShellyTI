namespace Shelly.GraphQLCoreClient.Helper
{
     public static class ExceptionHelper
     {
          public static async Task<GenericResponse<T>> Try<T>(Func<Task<GenericResponse<T>>> function)
          {
               try
               {
                    return await function();
               }
               catch (Exception ex)
               {
                    return new GenericResponse<T>()
                    {
                         Result = false,
                         Errors = new List<ErrorResponse>()
                         {
                              new ErrorResponse ()
                              {
                                   Id = "-1",
                                   Stack =ex.Message
                              }
                         }
                    };
               }            
          }
     }
}
