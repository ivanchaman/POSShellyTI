namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class PaginationUserSearchType : ObjectGraphType<Pagination<UserSearch>>
     {
          public PaginationUserSearchType()
          {

               Name = "PaginationUserSearchType";
               #region Fields

               Field(f => f.TotalRows);
               Field(f => f.PageNumber);
               Field(f => f.RowsOfPage);
               Field<ListGraphType<UserSearchType>>("Data");
               #endregion

          }
     }
}
