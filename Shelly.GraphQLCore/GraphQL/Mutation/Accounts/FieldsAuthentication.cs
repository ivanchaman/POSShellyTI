namespace Shelly.GraphQLCore.GraphQL.Mutation.Accounts
{
     public partial class Mutations
     {
          public void FieldsAuthentication()
          {           
               Field<Boolean>("setUserName")
                  .Argument<string>("data")
                  .Resolve(SetUserName);
               Field<Boolean>("setUpdateTemporaryPassword")
                 .Argument<string>("data")
                 .Resolve(SetUpdateTemporaryPassword);
               
          }

          #region Authentication
          private bool SetUserName(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Users user = new Users(_System);
               user.SetUserName(context.GetArgument<string>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetUpdateTemporaryPassword(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Users user = new Users(_System);
               user.SetUpdateTemporaryPassword(context.GetArgument<string>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          
          #endregion
     }
}
