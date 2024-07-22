namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
     internal class CatalogVersionInputType : InputObjectGraphType<CatalogVersion>
     {

          public CatalogVersionInputType()
          {

               Name = "CatalogVersionInputType";
               #region Fields

               Field(f => f.Id);
               Field(f => f.Version);
               
               #endregion

          }
     }
}
