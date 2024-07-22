namespace Shelly.POSCore.GraphQL.Query.Dashboard
{
     internal partial class Queries : Shelly.GraphQLCore.GraphQL.Query.Dashboard.Queries
     {

          public Queries(DashBoardSystem system) : base(system)
          {
               FieldsPOS();
          }
     }
}
