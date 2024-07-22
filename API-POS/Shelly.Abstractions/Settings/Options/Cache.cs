namespace Shelly.Abstractions.Settings.Options
{
     public class Cache
     {
          public const string SectionKey = "Cache";
          public string? Type { get; set; }
          public string? Host { get; set; }
          public int Port { get; set; }
          public int TimeoutAuth { get; set; }
          public int TimeoutRecovery { get; set; }
          public int TimeoutRegister { get; set; }
          public int TimeoutActive { get; set; }
          public int TimeoutTwoFactors { get; set; }
     }
}
