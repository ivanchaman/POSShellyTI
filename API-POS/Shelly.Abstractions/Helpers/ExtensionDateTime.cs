namespace Shelly.Abstractions.Helpers
{
     public static class ExtensionDateTime
     {
          private static readonly DateTime Date1970 = new DateTime(1970, 1, 1);
          public static long ToUnixEpoch(this DateTime dateTime)
          {
               return GetMillisecondsSince1970(dateTime);
          }
          public static long GetMillisecondsSince1970(this DateTime datetime)
          {
               var ts = datetime.Subtract(Date1970);
               return (long)ts.TotalMilliseconds;
          }
     }
}
