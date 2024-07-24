using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class CatalogsDataType : ObjectGraphType<CatalogsData>
     {

          public CatalogsDataType()
          {

               Name = "CatalogsDataType";
               #region Fields

               Field(f => f.Id);
               Field(f => f.Name);
               Field(f => f.Description);
               Field(f => f.Version);
               Field(f => f.Data);
               #endregion

          }
     }
}
