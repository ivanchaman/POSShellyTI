namespace Shelly.GraphQLShared.Options
{
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";
        public int Company { get; set; }
        public string APIUrl { get; set; }
        public string PublicKey { get; set; }
        public string Privatekey { get; set; }
    }
}
