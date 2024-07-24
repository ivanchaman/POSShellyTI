namespace Shelly.Abstractions.Settings.Options
{
     public class HttpServices
     {

          public const string SectionKey = "HttpServices";
          public int Fireblocks { get; set; }
          public int Dwolla { get; set; }
          public int Finicity { get; set; }
          public int Kraken { get; set; }
          public int PaymetGateway { get; set; }
          public int Viacarte { get; set; }
          public int CointMarketCap { get; set; }
          public int Email { get; set; }
     }
}
