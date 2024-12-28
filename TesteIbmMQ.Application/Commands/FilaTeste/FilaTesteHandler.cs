using MediatR;
using Microsoft.Extensions.Logging;
using TesteIbmMQ.Application.Notifications;
using TesteIbmMQ.Domain.Services;

namespace TesteIbmMQ.Application.Commands.FilaTeste
{
    public class FilaTesteHandler(ILogger logger, IQueueService queueService) : INotificationHandler<FilaTesteNotification>
    {
        public async Task Handle(FilaTesteNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Processando mensagem da fila: {notification.Message.Nome}");
        }
    }
}
