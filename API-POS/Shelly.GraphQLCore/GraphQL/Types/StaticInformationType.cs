using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class StaticInformationType : ObjectGraphType<StaticInformation>
     {
          public StaticInformationType()
          {

               Name = "StaticInformationType";
               #region Fields             
               Field<BrandingType>("Branding");
               Field<ListGraphType<CatalogsDataType>>("Catalogs");
               #endregion

          }
     }
}
