namespace Shelly.GraphQLCore.GraphQl
{
     public class AccountsContext : GraphContext
     {
          
          public AccountsContext(AccountSystem system, bool hasSesion) : base(system, hasSesion)
          {
              
          }
          protected override Schema GetSchema()
          {
               if (!_hasSesion)
                    return new Schema
                    {                          
                         Query = new Queries((AccountSystem)_System) 
                    };
               return new Schema
               { 
                    Query = new Shelly.GraphQLCore.GraphQL.Query.Accounts.Queries((AccountSystem)_System),
                    Mutation = new Shelly.GraphQLCore.GraphQL.Mutation.Accounts.Mutations((AccountSystem)_System) 
               };
          }
         
     }
}
