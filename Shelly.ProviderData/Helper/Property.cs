using Newtonsoft.Json;

namespace Shelly.ProviderData.Helper
{
    public class Property
    {
        [JsonIgnore]
        public bool IsIncludeHours { get; set; }

        [JsonIgnore]
        public int Length { get; set; }

        [JsonIgnore]
        public int Precision { get; set; }

        [JsonIgnore]
        public bool IsRequiredInDataBase { get; set; }

        [JsonIgnore]
        public bool IsPrimaryKey { get; set; }

        public int FieldId { get; set; }

        [JsonIgnore]
        public string Description { get; set; }

        [JsonIgnore]
        public bool IsIdentity { get; set; }

        [JsonIgnore]
        public Type DataType { get; set; }

        [JsonIgnore]
        public bool IsCompanyField { get; set; }

        [JsonIgnore]
        public bool IsPeriodYearField { get; set; }

        [JsonIgnore]
        public bool IsOrder { get; set; }

        [JsonIgnore]
        public bool IsPassword { get; set; }

        [JsonIgnore]
        public bool IsEncrypted { get; set; }

        [JsonIgnore]
        public bool IsVirtualField { get; set; }
        public bool IsChildField { get; set; }
        [JsonIgnore]
        public string NameQl { get; set; }


        public string ValueQl { get; set; }
        public bool IsGuid { get; set; }
        public string TypeName { get; set; }

        public string Name { get; set; }
    }
}