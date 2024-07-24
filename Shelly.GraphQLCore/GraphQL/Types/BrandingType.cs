using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class BrandingType : ObjectGraphType<Branding>
     {
          public BrandingType()
          {

               Name = "BrandingType";
               #region Fields

               Field(f => f.Id);
               Field(f => f.Version);
               Field<ListGraphType<DictionaryValueType>>("Data");
               #endregion

          }
     }
}
