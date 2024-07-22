namespace Shelly.POSCore.GraphQL.Mutation.Accounts
{
     internal partial class Mutations : Shelly.GraphQLCore.GraphQL.Mutation.Accounts.Mutations
     {         
          public Mutations(AccountSystem system) : base(system)
          {
               FieldsUserDinner();
          }
     }
}
