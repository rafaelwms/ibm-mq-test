using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Infraestructure.Services;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {

            var queueSettings = new QueueSettings();
            configuration.GetSection("QueueSettings").Bind(queueSettings);
            services.AddSingleton(queueSettings);

            services.AddScoped<IQueueService, QueueService>();

            return services;
        }
    }
}
