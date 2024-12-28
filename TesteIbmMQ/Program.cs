using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TesteIbmMQ.CrossCutting.Extensions;

namespace TesteIbmMQ.Worker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .Build();
            return Host.CreateDefaultBuilder(args)
                 .ConfigureWorkerHealthCheck(configuration)
                 .ConfigureServices((hostingContext, services) =>
                 {
                     services.AddLogging();
                     services.AddHealthChecks();
                     services.AddFilaTesteMediator();
                     services.AddRepository(configuration);
                     services.AddFilaTesteSettings(configuration);
                     services.AddHttpContextAccessor();
                     services.AddHostedService<ConsumerService>();
                 });
        }
    }
}