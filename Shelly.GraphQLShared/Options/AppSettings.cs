namespace Shelly.GraphQLShared.Options
{
     public class AppSettings
     {
          public const string SectionKey = "AppSettings";
          public int Company { get; set; }
          public string APIUrl { get; set; }
          public string NPublicKey { get; set; }
          public string NPrivateKey { get; set; }
          public string DBPublicKey { get; set; }
          public string DBPrivateKey { get; set; }
     }
}
