namespace TesteIbmMQ.Domain.Services
{
    public interface IQueueService
    {
        Task StartQueueProcessor(Func<string, string, CancellationToken, Task> callBack, string queue, CancellationToken stoppingToken);

        Task SendMessageToQueue(string queue, string message);
    }
}
