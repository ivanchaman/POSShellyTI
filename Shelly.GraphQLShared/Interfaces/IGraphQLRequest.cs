namespace Shelly.GraphQLShared.Interfaces
{
     public interface IGraphQLRequest
     {
          string OperationName { get; set; }
          string NamedQuery { get; set; }
          string Query { get; set; }
     }
}
