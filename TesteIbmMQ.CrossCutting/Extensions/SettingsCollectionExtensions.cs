using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Infraestructure.Services;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class SettingsCollectionExtensions
    {
        public static IServiceCollection AddFilaTesteSettings(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.GetConfig<RetrySettings>();
            services.AddLogging();
            return services;
        }
    }
}
