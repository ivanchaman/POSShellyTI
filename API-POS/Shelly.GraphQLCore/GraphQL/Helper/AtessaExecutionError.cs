namespace Shelly.GraphQLCore.GraphQL
{
     internal class ShellyExecutionError : ExecutionError
     {
          public string ErrorId { get; set; }
          public string AdditionalMessage { get; set; }
          public Exception Exception { get; set; }
          public ShellyExecutionError(string message) : base(message)
          {
               ErrorId = message;
          }
          public ShellyExecutionError(string message, string additionalmessage) : base(message)
          {
               ErrorId = message;
               AdditionalMessage = additionalmessage;
          }
          public ShellyExecutionError(string message, Exception exception) : base(message)
          {
               Exception = exception;
          }
     }
}
