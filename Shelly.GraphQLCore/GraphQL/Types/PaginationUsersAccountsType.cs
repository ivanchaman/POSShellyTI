namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class PaginationUsersAccountsType : ObjectGraphType<Pagination<Users>>
     {
          public PaginationUsersAccountsType()
          {

               Name = "PaginationUsersAccountsType";
               #region Fields

               Field(f => f.TotalRows);
               Field(f => f.PageNumber);
               Field(f => f.RowsOfPage);
               Field<ListGraphType<UsersType>>("Data");
               #endregion

          }
     }
}
