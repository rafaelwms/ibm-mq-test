using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using TesteIbmMQ.CrossCutting.Health;

namespace TesteIbmMQ.CrossCutting.Extensions
{
    public static class HealthCheckCollectionExtension
    {
        public static IServiceCollection AddHealthChecksInjection(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<ExampleHealthCheck>("Example_Healthy");
            return services;
        }

        public static IServiceCollection AddHealthChecksInjection(this IServiceCollection services, IConfiguration configuration)
        {
            using var provider = services.BuildServiceProvider();
            /*
            var dbConfig = configuration.GetConfig<DBConfig>();

            services.AddHealthChecks()
                .AddOracle(dbConfig.ConnectionString, name: "oracle", failureStatus: HealthStatus.Unhealthy);
            */
            return services;
        }

        public static IWebHostBuilder ConfigureHealthCheck(this IWebHostBuilder builder)
        {
            return builder.Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                    {
                        ResponseWriter = (context, health) => context.WriteHealthResponse(health)
                    });
                });
            });
        }

        public static IHostBuilder ConfigureWorkerHealthCheck(this IHostBuilder builder, IConfiguration configuration)
        {
            return builder.ConfigureWebHostDefaults(web =>
            {
                web.ConfigureServices(services => services.AddHealthChecksInjection(configuration));
                web.ConfigureHealthCheck();
            });
        }
    }
}
