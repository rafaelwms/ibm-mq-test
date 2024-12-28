using MediatR;
using TesteIbmMQ.Domain.Entities;


namespace TesteIbmMQ.Application.Notifications
{
    public class FilaTesteNotification : INotification
    {
        public EstruturaFila Message { get; set; }
        public int? Retries { get; set; }
        public DateTime? NextRetry { get; set; }

        public FilaTesteNotification(string message) 
        {
            if (message == null)
                return;

            var messageObj = Newtonsoft.Json.JsonConvert.DeserializeObject<FilaTesteNotification>(message);

            Message = messageObj?.Message;
            Retries = messageObj?.Retries;
            NextRetry = messageObj?.NextRetry;
        }

    }
}
