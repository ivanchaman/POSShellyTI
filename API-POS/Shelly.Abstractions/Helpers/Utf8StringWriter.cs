using System.IO;
using System.Text;

namespace Shelly.Abstractions.Helpers
{
     /// <summary>
     ///  Clase para la codificaicon UTF8
     /// </summary>
     public sealed class Utf8StringWriter : StringWriter
     {
          /// <summary>
          /// Encoding
          /// </summary>
          public override Encoding Encoding
          {
               get
               {
                    return Encoding.UTF8;
               }
          }
     }
}