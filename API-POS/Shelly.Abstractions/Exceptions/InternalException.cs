using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Exceptions
{
     public class InternalException : Exception
     {
          public string ErrorId { get; set; }
          public InternalException() : base("E00000000")
          {
          }

          public InternalException(string message) : base(message)
          {
               ErrorId = message;
          }

          public InternalException(string message, Exception exception) : base(message, exception)
          {
          }

          public InternalException(SerializationInfo information, StreamingContext context) : base(information, context)
          {
          }
     }
}
