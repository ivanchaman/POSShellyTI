using System;
using System.Text.Json.Serialization;

namespace Shelly.ProviderData.Helper
{
    public class PropertyValue<T> : Property
    {
        [JsonIgnore]
        public T Value { get; set; }

        [JsonIgnore]
        public T OldValue { get; set; }

        [JsonIgnore]
        public T DefaultValue { get; set; }

        public static implicit operator PropertyValue<T>(PropertyValue<byte[]> v)
        {
            throw new NotImplementedException();
        }
    }
}