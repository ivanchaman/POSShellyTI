namespace Shelly.Abstractions.Interfaces
{
     public interface IMessageLocalizer
     {
          string this[string key] { get; }
     }
}
