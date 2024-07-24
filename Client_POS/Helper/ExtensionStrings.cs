using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ShellyPOS.Helper
{
    public static class ExtensionStrings
    {
        public static T? ConvertJsonToObject<T>(this object input)
        {
            return ConvertJsonToObject<T?>(Convert.ToString(input));
        }
        public static string PathURLFormat(this string inputString)
        {
            string lastChar = inputString.Substring(inputString.Length - 1, 1);
            if (lastChar == "/") return inputString;
            else return $"{inputString}/";
        }
        public static T? ConvertJsonToObject<T>(this string? inputString)
        {
            if (String.IsNullOrEmpty(inputString))
                return default;
            try
            {
                return JsonConvert.DeserializeObject<T>(inputString);
            }
            catch
            {
                return default;
            }
        }
        public static T ConvertJObjectToObject<T>(this JObject input)
        {
            if (input == null)
                return default;
            try
            {
                return input.ToObject<T>();
            }
            catch
            {
                return default;
            }
        }
        public static string ConvertObjectToJson(this object inputObject)
        {
            if (inputObject == null)
                return "";
            return JsonConvert.SerializeObject(inputObject);
        }
    }
}
