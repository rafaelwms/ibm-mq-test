using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.Domain.Repositories;
using TesteIbmMQ.Infraestructure.Repositories;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddScoped<IFilaTesteRepository, FilaTesteRepository>();

            return services;
        }
    }
}
