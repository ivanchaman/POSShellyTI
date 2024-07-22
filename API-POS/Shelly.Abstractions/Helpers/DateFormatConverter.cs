using Newtonsoft.Json.Converters;

namespace Shelly.Abstractions.Helpers
{
     public class DateFormatConverter : IsoDateTimeConverter
     {
          public DateFormatConverter(string format)
          {
               DateTimeFormat = format;
          }
     }
}
