﻿using Microsoft.AspNetCore.Builder;
namespace Shelly.POSCore
{
     public static class Endpoints
     {
          public static IEndpointRouteBuilder UsePOSCoreEndpoints(this IEndpointRouteBuilder app, IConfigurationSection section)
          {
               AccountsEndpoints(ref app);
               Shelly.GraphQLCore.Endpoints.EndpointsBlobStorages(ref app);
               return app;
          }

          public static void AccountsEndpoints(ref IEndpointRouteBuilder app)
          {
               app.MapGet("/", () => "Hello World from EvedFood!");
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
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).WithTags("EvedFood");
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
                         return Results.BadRequest(new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } });
                    }
               }).WithTags("EvedFood");

          }
     }
}