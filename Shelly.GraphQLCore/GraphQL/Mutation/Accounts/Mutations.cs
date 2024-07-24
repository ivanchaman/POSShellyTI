namespace Shelly.GraphQLCore.GraphQL.Mutation.Accounts
{
     public partial class Mutations : ObjectGraphType<object>
     {
          private AccountSystem _System;
          public Mutations(AccountSystem system)
          {
               _System = system;
               Name = "AccountsMutations";

               FieldsAuthentication();
               FieldsUsers();
          }
     }
}
