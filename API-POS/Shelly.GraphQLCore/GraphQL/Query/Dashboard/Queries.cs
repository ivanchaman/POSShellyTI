namespace Shelly.GraphQLCore.GraphQL.Query.Dashboard
{
     internal partial class Queries : ObjectGraphType
     {
          private DashBoardSystem _System;
          public Queries(DashBoardSystem system)
          {
               _System = system;
               Name = "DashboardQueries";
               FieldsAuthentication();
          }
         
     }
}
