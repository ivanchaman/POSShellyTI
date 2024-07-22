using Shelly.ProviderData.GenericRepository.Entity;

namespace Shelly.GraphQLCore.GraphQL.Query.Accounts
{
     public partial class Queries
     {
          #region Queries
          public void FieldsUsers()
          {
               Field<Boolean>("getValidateUserName")
                    .Argument<string>("userName")
                    .Resolve(GetValidateUserName);
               Field<UsersAccountsType>("getInformation")
                    .Resolve(GetInformation);
               Field<PaginationUsersAddressType>("getAddresses")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetAddresses);               
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
          private UsersAccounts? GetInformation(IResolveFieldContext context) => context.TryLogged(() =>
          {
               UsersAccounts usersAccounts = new UsersAccounts(_System);
               usersAccounts.Load(_System.Session.User.Number);
               usersAccounts.User = new Users(_System);
               usersAccounts.User.Load(_System.Session.User.Number);
               return usersAccounts;
          });
          public static BlobStorages? GetImageData(IResolveFieldContext context) => context.Try(() =>
          {
               StaticEntity? data = context.Source as StaticEntity;               
               if (data == null)
                    return null;
               BlobStorages bob = new BlobStorages(data.System);
               switch (data)
               {
                    case UsersAccounts accounts:
                         bob.Load((data as UsersAccounts).AvatarImageId);
                         break;
                    case Companies accounts:
                         bob.Load((data as Companies).AvatarImageId);
                         break;

               }               
               return bob;
          });
          private Pagination<UsersAddress>? GetAddresses(IResolveFieldContext context) => context.TryLogged(() =>
          {
               return new UsersAddressCollection(_System).Where(x => x.UserNumber == _System.Session.User.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage"));
          });

               
          #endregion
     }
}
