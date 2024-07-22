namespace Shelly.POSCore.GraphQl
{
     internal class EvedFoodContext : Shelly.GraphQLCore.GraphQl.AccountsContext
     {
          
          public EvedFoodContext(AccountSystem system, bool hasSesion) : base(system, hasSesion)
          {
              
          }
          protected override Schema GetSchema()
          {
               if (!_hasSesion)
                    return new Schema
                    {  
                         Mutation = new Shelly.POSCore.GraphQL.Mutation.Mutations((AccountSystem)_System),
                         Query = new Shelly.POSCore.GraphQL.Query.Queries((AccountSystem)_System) 
                    };
               return new Schema
               { 
                    Query = new Shelly.POSCore.GraphQL.Query.Accounts.Queries((AccountSystem)_System),
                    Mutation = new Shelly.POSCore.GraphQL.Mutation.Accounts.Mutations((AccountSystem)_System) 
               };
          }
         
     }
}
