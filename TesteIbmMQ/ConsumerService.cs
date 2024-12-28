using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TesteIbmMQ.Application.Notifications;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;

namespace TesteIbmMQ.Worker
{
    public class ConsumerService(ILogger<ConsumerService> logger,
                                 IQueueService queueProcessor,
                                 IServiceScopeFactory scopeFactory,
                               QueueSettings settings) : BackgroundService
    {
        protected async Task Process(string queue, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Iniciando processamento da fila: {queue}");
            await queueProcessor.StartQueueProcessor(ProcessMessage, queue, cancellationToken);
            logger.LogInformation($"Finalizando processamento da fila:{queue}");
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            foreach (var queue in settings.Queues)
            {
                await Task.Factory.StartNew(() => Process(queue.Key, cancellationToken), TaskCreationOptions.LongRunning);
            }
        }

        public async Task ProcessMessage(string queue, string message, CancellationToken cancellationToken)
        {
            using var scope = scopeFactory.CreateScope();
            var mediatr = scope.ServiceProvider.GetRequiredService<IMediator>();

            var notification = new FilaTesteNotification(message);

            await mediatr.Publish(notification, cancellationToken);
        }
    }
}
