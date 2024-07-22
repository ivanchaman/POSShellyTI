namespace Shelly.GraphQLCore.GraphQL.Mutation.Dashboard
{
     internal partial class Mutations : ObjectGraphType<object>
     {
          private DashBoardSystem _System;
          public Mutations(DashBoardSystem system)
          {
               _System = system;
               Name = "DashboardMutations";
               FieldsAuthentication();
          }
         
     }
}
