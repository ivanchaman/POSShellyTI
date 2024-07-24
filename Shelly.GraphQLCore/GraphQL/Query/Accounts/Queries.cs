namespace Shelly.GraphQLCore.GraphQL.Query.Accounts
{
     public partial class Queries : ObjectGraphType
     {
          protected AccountSystem _System;
          public Queries(AccountSystem system)
          {
               _System = system;
               Name = "AccountQueries";
               FieldsAuthentication();
               FieldsUsers();               
          }                   
     }
}
