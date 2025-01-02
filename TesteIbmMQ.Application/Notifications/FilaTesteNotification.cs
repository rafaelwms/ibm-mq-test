using MediatR;
using Newtonsoft.Json;
using TesteIbmMQ.Domain.Entities;
using TesteIbmMQ.Domain.Utils;


namespace TesteIbmMQ.Application.Notifications
{
    public class FilaTesteNotification : INotification
    {
        public EstruturaFila? Message { get; set; }
        public int? Retries { get; set; }
        public DateTime? NextRetry { get; set; }



        public FilaTesteNotification(string jsonString) 
        {
            if (jsonString == null)
                return;


            try
            {
                Retries = jsonString.GetPropertyValue<int?>("Retries");
                NextRetry = jsonString.GetPropertyValue<DateTime?>("NextRetry");
                Message = jsonString.GetPropertyValue<EstruturaFila>("Message");

            }
            catch (JsonException ex)
            {
                // Handle deserialization error
                // Log the error or throw an exception
                throw new InvalidOperationException("Failed to deserialize message", ex);
            }
        }

    }
}
