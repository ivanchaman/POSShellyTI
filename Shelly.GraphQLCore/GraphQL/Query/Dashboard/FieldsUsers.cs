using Shelly.ProviderData.GenericRepository.Entity;

namespace Shelly.GraphQLCore.GraphQL.Query.Dashboard
{
     public partial class Queries
     {
          #region Queries
          public void FieldsUsers()
          {
               Field<Boolean>("getValidateUserName")
                    .Argument<string>("userName")
                    .Resolve(GetValidateUserName);
               Field<PaginationUsersAccountsType>("getUsersInformation")
                    .Resolve(GetUsersInformation);
               Field<PaginationUsersAddressType>("getUsersAddresses")
                    .Argument<int>("id")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetUsersAddresses);
          }
          #endregion
          #region Users
          private bool GetValidateUserName(IResolveFieldContext context) => context.TryLogged(() =>
          {
               Users users = new Users(_System);
               string userName = context.GetArgument<string>("userName");
               users.Load(x => x.UserName == userName);
               return users.EOF;
          });
          private Pagination<UsersAccounts>? GetUsersInformation(IResolveFieldContext context) => context.TryLogged(() =>
          {
               return new UsersAccountsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage"));
          });        
          private Pagination<UsersAddress>? GetUsersAddresses(IResolveFieldContext context) => context.TryLogged(() =>
          {
               int id = context.GetArgument<int>("pageNumber");
               return new UsersAddressCollection(_System).Where(x => x.UserNumber == id, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage"));
          });


          #endregion
     }
}
