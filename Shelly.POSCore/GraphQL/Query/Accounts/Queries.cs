namespace Shelly.POSCore.GraphQL.Query.Accounts
{
     internal partial class Queries : Shelly.GraphQLCore.GraphQL.Query.Accounts.Queries
     {
        
          public Queries(AccountSystem system) :base(system)
          {
               FieldsPOS();
               FieldsClinical();
          }                   
     }
}
