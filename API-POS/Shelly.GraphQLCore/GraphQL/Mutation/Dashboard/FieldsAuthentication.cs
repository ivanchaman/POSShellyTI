namespace Shelly.GraphQLCore.GraphQL.Mutation.Dashboard
{
     internal partial class Mutations
     {
          public void FieldsAuthentication()
          {
               Field<Boolean>("setUserName")
                  .Argument<string>("data")
                  .Resolve(SetUserName);

          }
          private bool SetUserName(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Users user = new Users(_System);
               user.SetUserName(context.GetArgument<string>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
     }
}
