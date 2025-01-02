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
    }
}
