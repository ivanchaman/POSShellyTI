using Shelly.Abstractions.Enumerations;

namespace Shelly.Abstractions.Settings
{
     public class UserSettings
     {
          public long Number { get; set; }
          public long WalletId { get; set; }
          public string? Uuid { get; set; }
          public string? UserName { get; set; }
          public int Status { get; set; }
          public int Profile { get; set; }
          public bool IsSuperUser { get; set; }
          public string? Email { get; set; }
          public string? PhoneNumber { get; set; }
          public string? PhoneCode { get; set; }
          public int LevelFee { get; set; }
          public string? FirstName { get; set; }
          public string? LastName { get; set; }
     }
}