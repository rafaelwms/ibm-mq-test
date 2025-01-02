using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TesteIbmMQ.Application.Notifications;
using TesteIbmMQ.Domain.Repositories;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Domain.Utils;

namespace TesteIbmMQ.Application.Commands.FilaTeste
{
    public class FilaTesteHandler(ILogger<FilaTesteHandler> logger, IQueueService queueService, RetrySettings retrySettings, IFilaTesteRepository repository) : INotificationHandler<FilaTesteNotification>
    {
        public async Task Handle(FilaTesteNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Processando mensagem da fila: {JsonConvert.SerializeObject(notification.Message, Formatting.Indented)}");
        }
        private void SetRetryProperties(FilaTesteNotification notification)
        {
            if (notification.NextRetry.HasValue!)
            {
                notification.NextRetry = DateTime.Now.AddMinutes(5);
            }

            if (notification.Retries.HasValue!) notification.Retries = 1;
            else notification.Retries++;
        }





        private bool MessageIsAllowToRetry(FilaTesteNotification notification)
        {
            return (notification.Retries < retrySettings.MaxRetries);
        }


        private async Task ProcessMessage(FilaTesteNotification notification)
        {
            try
            {
                if (notification.Retries.HasValue)
                    await ProcessRetryQueue(notification);
                else
                    await SendToFilaTesteProcedure(notification);
            }
            catch (Exception ex)
            {
                SetRetryProperties(notification);
                await SendRetryQueue(notification);
            }
        }


        private async Task SendToFilaTesteProcedure(FilaTesteNotification notification)
        {
            logger.LogInformation("Sending to Fila Teste Procedure.");
            await repository.ProcessCredit(notification.Message);
        }


        private async Task SendRetryQueue(FilaTesteNotification notification)
        {
            try
            {
                logger.LogInformation("Sending to Retry Credit Queue.");
                await queueService.SendMessageToQueue("QL.GDC.DP.Teste_RETRY", ToStringMessage(notification));
            }
            catch (Exception)
            {
                logger.LogError("Sending to Retry Credit Queue.");
                throw;
            }
        }

        private async Task SendDeadLetterQueue(FilaTesteNotification notification)
        {
            try
            {
                logger.LogInformation("Sending to DL Credit Queue.");
                await queueService.SendMessageToQueue("QL.GDC.DP.Teste_DLQ", ToStringMessage(notification));
            }
            catch (Exception)
            {
                logger.LogError("Sending to DL Credit Queue.");
                throw;
            }
        }

        private async Task ProcessRetryQueue(FilaTesteNotification notification)
        {
            if (MessageIsAllowToRetry(notification))
            {
                TimeUtil.WaitUntil(notification.NextRetry.Value);
                await ProcessMessage(notification);
            }
            else
            {
                await SendDeadLetterQueue(notification);
            }
        }

        private string ToStringMessage(FilaTesteNotification notification)
        {
            return notification == null ? string.Empty : Newtonsoft.Json.JsonConvert.SerializeObject(notification);
        }

    }
}
