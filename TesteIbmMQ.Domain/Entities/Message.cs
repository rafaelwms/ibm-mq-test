using Newtonsoft.Json;

namespace TesteIbmMQ.Domain.Entities
{
    public class Message
    {
        public List<KeyValuePair<string, string>>? Header { get; set; }

        public object? Body { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Message FromString(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                return default;
            }
            return JsonConvert.DeserializeObject<Message>(message);
        }

        public Message()
        {
            
        }

        public Message(object message)
        {
            if (message == null)
            {
                return;
            }
            Body = message;
        }
        public Message(object message, int retries, DateTime nextRetry) 
        { 
            if(message != null)
            {
                Body = message;
            }
            Header = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("RETRY_QUANTITY", retries.ToString()),
                new KeyValuePair<string, string>("DATE_WAIT_READ", nextRetry.ToString("yyyy-MM-dd HH:mm:ss"))
            };

        }
    }
}