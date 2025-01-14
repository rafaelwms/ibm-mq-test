using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TesteIbmMQ.Domain.Utils
{
    public static class SerializationUtil
    {

        public static T? GetPropertyValue<T>(this string jsonString, string property)
        {
            var jObject = JObject.Parse(jsonString);

            if (!jObject.TryGetValue(property, out JToken? token))
            {
                return default;
            }

            return token.ToObject<T>();
        }

        public static Dictionary<string, string> GetDictionaryFromJson(string jsonContent, string propertyName)
        {
            if (string.IsNullOrEmpty(jsonContent))
            {
                return new Dictionary<string, string>();
            }

            var jObject = JObject.Parse(jsonContent);
            var propertyToken = jObject[propertyName];

            if (propertyToken == null)
            {
                return new Dictionary<string, string>();
            }

            var keyValuePairs = propertyToken.ToObject<KeyValuePair<string, string>[]>();
            var dictionary = new Dictionary<string, string>();

            if (keyValuePairs != null)
            {
                foreach (var kvp in keyValuePairs)
                {
                    dictionary[kvp.Key] = kvp.Value;
                }
            }
            return dictionary;
        }
    }
}
