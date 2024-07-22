

namespace Shelly.GraphQLCore.Interface
{
     public interface IGraphQLServices
     {         
          public Task<GenericResponse> ExecutionResultAccountsSchemaWithoutSession();
          public Task<GenericResponse> ExecutionResultAccountsSchemaWithSession();

          public Task<GenericResponse> ExecutionResultDashboardSchemaWithoutSession();
          public Task<GenericResponse> ExecutionResultDashboardSchemaWithSession();
     }
}
