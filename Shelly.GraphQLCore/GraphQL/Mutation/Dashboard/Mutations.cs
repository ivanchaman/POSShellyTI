namespace Shelly.GraphQLCore.GraphQL.Mutation.Dashboard
{
     public partial class Mutations : ObjectGraphType<object>
     {
          public DashBoardSystem _System;
          public Mutations(DashBoardSystem system)
          {
               _System = system;
               Name = "DashboardMutations";
               FieldsAuthentication();
               FieldsUsers();
               FieldsSettings();
               FieldsCompanies();             
          }
         
     }
}
