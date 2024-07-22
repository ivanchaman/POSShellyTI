namespace Shelly.Abstractions.Settings.Options
{
     public class DataAccess
    {
        public const string SectionKey = "ConnectionString";
        public string? ConnectionString { get; set; }
    }
}
