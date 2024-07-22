namespace Shelly.Abstractions.Model
{
     public class DwollaSettings
     {
          public bool Sandbox { get; set; }
          public string Key { get; set; }
          public string Secret { get; set; }
          public string? BankType { get; set; }
          public string? SourceStandard { get; set; }
          public string? DestinationStandard { get; set; }
          public string SourceSameDay { get; set; }
          public string DestinationSameDay { get; set; }
     }
}
