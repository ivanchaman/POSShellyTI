using Shelly.GraphQLCore.Interface;
using Microsoft.Extensions.Configuration;

namespace Shelly.GraphQLCore
{
     public static class Endpoints
     {
          public static IEndpointRouteBuilder UseCoreEndpoints(this IEndpointRouteBuilder app, IConfigurationSection section)
          {
               AccountsEndpoints(ref app);               
               EndpointsBlobStorages(ref app);
               return app;
          }

          public static void AccountsEndpoints(ref IEndpointRouteBuilder app)
          {
               app.MapGet("/", () => "Hello World from Shelly!");
               app.MapGet("/exec", async (IGraphQLServices controller) =>
               {
                    try
                    {                         
                         var result = await controller.ExecutionResultAccountsSchemaWithoutSession();
                         if (!result.Result)
                              return Results.BadRequest(result);
                         return Results.Ok(result);
                    }
                    catch (Exception ex)
                    {
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).WithTags("Accounts");
               app.MapPost("/exec", async (IGraphQLServices controller) =>
               {
                    try
                    {
                         // Llamar al método                        
                         var result = await controller.ExecutionResultAccountsSchemaWithSession();
                         if (!result.Result)
                              return Results.BadRequest(result);
                         return Results.Ok(result);
                    }
                    catch (Exception ex)
                    {
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).WithTags("Accounts");

          }
          public static void DashboardEndpoints(ref IEndpointRouteBuilder app)
          {
               app.MapGet("/exec_d", async (IGraphQLServices controller) =>
               {
                    // Llamar al método 
                    try
                    {
                         var result = await controller.ExecutionResultDashboardSchemaWithoutSession();
                         // Devolver el resultado
                         if (!result.Result)
                              return Results.BadRequest(result);
                         return Results.Ok(result);
                    }
                    catch (Exception ex)
                    {
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).WithTags("Dashboard");
               app.MapPost("/exec_d", async (IGraphQLServices controller) =>
               {
                    // Llamar al método 
                    try
                    {                         
                         var result = await controller.ExecutionResultDashboardSchemaWithSession();
                         if (!result.Result)
                              return Results.BadRequest(result);
                         return Results.Ok(result);
                    }
                    catch (Exception ex)
                    {
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).WithTags("Dashboard");

          }

         
          public static void EndpointsBlobStorages(ref IEndpointRouteBuilder app)
          {
               app.MapPost("/uploadFile", async (IBlobStorageServices controller, IFormFile file) =>
               {
                    try
                    {
                         // Llamar al método                        
                         var result = await controller.UploadFile(file);
                         if (!result.Result)
                              return Results.BadRequest(result);
                         return Results.Ok(result);
                    }
                    catch (Exception ex)
                    {
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).DisableAntiforgery().WithTags("BlobStorages");
          }         
     }
}
