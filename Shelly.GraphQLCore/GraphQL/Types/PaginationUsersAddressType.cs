namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class PaginationUsersAddressType : ObjectGraphType<Pagination<UsersAddress>>
     {
          public PaginationUsersAddressType()
          {

               Name = "PaginationUsersAddressType";
               #region Fields

               Field(f => f.TotalRows);
               Field(f => f.PageNumber);
               Field(f => f.RowsOfPage);
               Field<ListGraphType<UsersAddressType>>("Data");
               #endregion

          }
     }
}
