using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Infraestructure.Services;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IQueueService, QueueService>();
            return services;
        }
    }
}
