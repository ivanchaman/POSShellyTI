using Shelly.Abstractions.Constants;
using Shelly.Abstractions.Interfaces;

namespace Shelly.MessagesLocalizer
{
     public class MessageLocalizer : IMessageLocalizer
     {
          readonly Dictionary<string, string> Messages_Es = new()
          {
               { MessageKeys.ExampleMessagesWarning,"Este es un error de ejemplo para incorporación del sistema" },             
          };
          public string this[string key]
          {
               get
               {
                    Messages_Es.TryGetValue(key, out var message);
                    return string.IsNullOrWhiteSpace(message) ? key : message;
               }
          }
     }
}
