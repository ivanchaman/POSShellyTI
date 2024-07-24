using Shelly.GraphQLCore.GraphQL;

namespace Shelly.POSCore.GraphQL
{
     internal class POSDashboardContext: DashboardContext
     {
          public POSDashboardContext(DashBoardSystem system, bool hasSesion) : base(system, hasSesion)
          {

          }
          protected override Schema GetSchema()
          {
               if (!_hasSesion)
                    return new Schema
                    {
                         Mutation = new Shelly.POSCore.GraphQL.Mutation.Mutations((DashBoardSystem)_System),
                         Query = new Shelly.POSCore.GraphQL.Query.Queries((DashBoardSystem)_System)
                    };
               return new Schema
               {
                    Query = new Shelly.POSCore.GraphQL.Query.Dashboard.Queries((DashBoardSystem)_System),
                    Mutation = new Shelly.POSCore.GraphQL.Mutation.Dashboard.Mutations((DashBoardSystem)_System)
               };
          }
     }
}
