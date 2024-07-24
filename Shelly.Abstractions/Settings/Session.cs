namespace Shelly.Abstractions.Settings
{
     public class Session
     {
          public Company Company { get; set; }
          public UserSettings User { get; set; }
          public Session()
          {
               Company = new Company();
               User = new UserSettings();
          }

        
     }
}