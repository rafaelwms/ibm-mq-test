using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Settings;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class SettingsCollectionExtensions
    {
        public static IServiceCollection AddFilaTesteSettings(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.GetConfig<RetrySettings>();
            return services;
        }
    }
}
