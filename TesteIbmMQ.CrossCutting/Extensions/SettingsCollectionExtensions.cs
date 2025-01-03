using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Infraestructure.Services;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class SettingsCollectionExtensions
    {
        public static IServiceCollection AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();

            var queueSettings = new QueueSettings();
            configuration.GetSection("QueueSettings").Bind(queueSettings);
            services.AddSingleton(queueSettings);

            var retrySettings = new RetrySettings();
            configuration.GetSection("RetrySettings").Bind(retrySettings);
            services.AddSingleton(retrySettings);

            return services;
        }
    }
}
