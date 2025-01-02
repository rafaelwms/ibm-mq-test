using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Repositories;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Infraestructure.Repositories;
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
            var retrySettings = new RetrySettings();
            configuration.GetSection("RetrySettings").Bind(retrySettings);
            services.AddSingleton(retrySettings);

            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IFilaTesteRepository, FilaTesteRepository>();

            return services;
        }
    }
}
