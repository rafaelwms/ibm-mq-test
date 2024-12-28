using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;
using System.Text.Json;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class Extensions
    {
        public static T GetConfig<T>(this IConfiguration config) where T : new()
        {
            T obj = new();
            config.Bind(typeof(T).Name, obj);
            return obj;
        }
        public static Task WriteHealthResponse(this HttpContext context, HealthReport health)
        {
            context.Response.ContentType = "application/json";
            var options = new JsonWriterOptions { Indented = true };
            using var memoryStream = new MemoryStream();
            using var jsonWriter = new Utf8JsonWriter(memoryStream, options);
            jsonWriter.WriteStartObject();
            foreach (var healthEntry in health.Entries)
            {
                jsonWriter.WriteString($"status_{healthEntry.Key}", healthEntry.Value.Status == HealthStatus.Healthy ? "UP" : "DOWN");
            }
            jsonWriter.WriteEndObject();

            return context.Response.WriteAsync(Encoding.UTF8.GetString(memoryStream.ToArray()));
        }
    }
}
