using Newtonsoft.Json;
using TesteIbmMQ.Domain.Utils;

namespace TesteIbmMQ.Domain.Entities
{
    public class Message
    {
        public Dictionary<string, string>? Header { get; set; }

        public object? Body { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Message(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            Header = message.GetPropertyValue<Dictionary<string, string>>("Header");
            Body = message.GetPropertyValue<object>("Body");
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
            Body = message is string ? JsonConvert.DeserializeObject<object>((string)message) : message;
        }
        public Message(object message, int retries, DateTime nextRetry)
        {
            if (message != null)
            {
                Body = message is string ? JsonConvert.DeserializeObject<object>((string) message) : message ;
            }
            Header = new Dictionary<string, string>
            {
                {"RetryQtd", retries.ToString() },
                {"NextRetry", nextRetry.ToString("yyyy-MM-dd HH:mm:ss") }
            };

        }

        public bool IsOverRetryQuantity(int maxRetries)
        {
            if (Header == null)
            {
                return false;
            }
            var retryQuantity = Header.FirstOrDefault(x => x.Key == "RetryQtd");
            if (retryQuantity.Value == null)
            {
                return false;
            }
            return int.Parse(retryQuantity.Value) >= maxRetries;
        }

        public bool IsAllowedToRetry()
        {
            if (Header == null)
            {
                return true;
            }
            DateTime? dateWaitRead = DateTime.Parse(Header.FirstOrDefault(x => x.Key == "NextRetry").Value);
            if (dateWaitRead == null)
            {
                return true;
            }
            return dateWaitRead.Value <= DateTime.Now;

        }

        public string GetTimeToRead()
        {
            if (Header == null)
            {
                return string.Empty;
            }
            var dateWaitRead = Header.FirstOrDefault(x => x.Key == "NextRetry");
            return dateWaitRead.Value;
        }
    }
}