using System.Runtime.Serialization;

namespace Shelly.Abstractions.Exceptions
{
     public class CoreException: Exception
     {
          public string ErrorId { get; set; }
          public string AdditionalMessage { get; set; }
          public CoreException() : base("E00000000")
          {
          }

          public CoreException(string errorId) : base(errorId)
          {
               ErrorId = errorId;
               
          }
          public CoreException(string errorId, string message) : base(errorId)
          {
               ErrorId = errorId;
               AdditionalMessage = message;
          }

          public CoreException(string message, Exception exception) : base(message, exception)
          {
          }

          public CoreException(SerializationInfo information, StreamingContext context) : base(information, context)
          {
          }
     }
}
