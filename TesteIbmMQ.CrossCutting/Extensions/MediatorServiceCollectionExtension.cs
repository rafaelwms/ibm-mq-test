using Microsoft.Extensions.DependencyInjection;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class MediatorServiceCollectionExtension
    {
        public static IServiceCollection AddFilaTesteMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("TesteIbmMQ.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
