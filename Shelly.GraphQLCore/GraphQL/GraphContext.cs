using Shelly.Abstractions.Settings;

namespace Shelly.GraphQLCore.GraphQL
{
     public class GraphContext
     {
          protected  BaseSystem _System;
          protected bool _hasSesion;

          public GraphContext(AccountSystem system, bool hasSesion)
          {
               _System = system;
               _hasSesion = hasSesion;
          }
          public GraphContext(DashBoardSystem system, bool hasSesion)
          {
               _System = system;
               _hasSesion = hasSesion;
          }
          protected virtual Schema GetSchema()
          {
               return new Schema ();
          }
          private Inputs GetInputsExtension()
          {
               Dictionary<string, object?> inputs = new(new Dictionary<string, object?>());
               if (_System.InfoSessionToken != null)
                    inputs?.Add("AuthConstant", $"{_System.InfoSessionToken.AuthConstant}");
               return new Inputs(inputs);
          }
          public async Task<GenericResponse> ExecutionResult(GraphQLQuery query)
          {
               try
               {

                    using (var schema = GetSchema())
                    {

                         var result = await new DocumentExecuter().ExecuteAsync(x =>
                         {
                              x.Schema = schema;
                              x.Variables = query.Variables == null ? Inputs.Empty : new GraphQLSerializer().Deserialize<Inputs>(query.Variables.ToString()); //version 5
                              x.Query = query.Query;
                              x.Extensions = GetInputsExtension();
                         });

                         if (result.Errors?.Count > 0)
                         {
                              List<Shelly.GraphQLCore.Model.ErrorSystem>? error = [];
                              foreach (var errorMessage in result.Errors)
                              {

                                   if (errorMessage is ShellyExecutionError)
                                   {
                                        ShellyExecutionError? ShellyExecutionError = errorMessage as ShellyExecutionError;
                                        if (ShellyExecutionError?.Exception is null)
                                             error.Add(new Shelly.GraphQLCore.Model.ErrorSystem(_System.Connection, (errorMessage as ShellyExecutionError)?.ErrorId, (errorMessage as ShellyExecutionError)?.AdditionalMessage));
                                        else
                                             error.Add(new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ShellyExecutionError.ErrorId, Stack = ShellyExecutionError.Exception.ToString() });
                                   }
                                   else
                                        error.Add(new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = errorMessage.Message, Stack = errorMessage.ToString() });
                              }
                              _System.WriteLog(error.ConvertObjectToJson());
                              return new GenericResponse() { Result = false, Errors = error };
                              
                         }
                         dynamic? data = null;
                         if (result.Data == null)
                              data = new { data = "{}" };
                         else
                         {
                              ExecutionNode? info = result.Data as ExecutionNode;
                              object? dataValue = info?.ToValue();
                              data = dataValue;

                         }
                         return new GenericResponse() { Result = true, Data = data };
                    }
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message } } };
               }

          }
     }
}
