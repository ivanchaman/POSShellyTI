namespace Shelly.GraphQLShared.Model
{
    public class GraphQLRequest: IGraphQLRequest
     {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }

    }
}
