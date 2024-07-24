namespace Shelly.Abstractions.Attributes
{
     [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
     public sealed class HttpStatusCodeAttribute : Attribute
     {
          public int StatusCode { get; }
          public HttpStatusCodeAttribute(int statusCode)
          {
               StatusCode = statusCode;
          }
     }
}
