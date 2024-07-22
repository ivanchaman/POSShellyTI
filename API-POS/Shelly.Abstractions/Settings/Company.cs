using Shelly.Abstractions.Enumerations;

namespace Shelly.Abstractions.Settings
{    
     public class Company
     {
          public long Number { get; set; }
          public long WalletId { get; set; }
          public string BusinessName { get; set; }
          public CountryType Country { get; set; }
          public string Email { get; set; }

     }
}