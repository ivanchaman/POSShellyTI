namespace Shelly.GraphQLCore.GraphQL.Query.Dashboard
{
     public partial class Queries : ObjectGraphType
     {
          public DashBoardSystem _System;
          public Queries(DashBoardSystem system)
          {
               _System = system;
               Name = "DashboardQueries";
               FieldsAuthentication();
               FieldsCompanies();
               FieldsUsers();
          }
         
     }
}
