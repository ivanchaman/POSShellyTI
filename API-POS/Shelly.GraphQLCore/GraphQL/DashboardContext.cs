namespace Shelly.GraphQLCore.GraphQL
{
     public class DashboardContext: GraphContext
     {
          
          public DashboardContext(DashBoardSystem system, bool hasSesion):base(system, hasSesion)
          {
              
          }
          protected override Schema GetSchema()
          {
               if (!_hasSesion)
                    return new Schema
                    {
                         Query = new Queries((DashBoardSystem)_System)
                    };
               return new Schema
               {
                    Query = new Shelly.GraphQLCore.GraphQL.Query.Dashboard.Queries((DashBoardSystem)_System),
                    Mutation = new Shelly.GraphQLCore.GraphQL.Mutation.Dashboard.Mutations((DashBoardSystem)_System)
               };
          }
          
          
     }
}
