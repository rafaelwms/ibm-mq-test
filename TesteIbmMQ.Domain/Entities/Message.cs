using Newtonsoft.Json;
using TesteIbmMQ.Domain.Utils;

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

        public Message(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            Header = message.GetPropertyValue<List<KeyValuePair<string, string>>>("Header");
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
            Body = message;
        }
        public Message(object message, int retries, DateTime nextRetry)
        {
            if (message != null)
            {
                Body = message;
            }
            Header = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("RETRY_QUANTITY", retries.ToString()),
                new KeyValuePair<string, string>("DATE_WAIT_READ", nextRetry.ToString("yyyy-MM-dd HH:mm:ss"))
            };

        }

        public bool IsOverRetryQuantity(int maxRetries)
        {
            if (Header == null)
            {
                return false;
            }
            var retryQuantity = Header.FirstOrDefault(x => x.Key == "RETRY_QUANTITY");
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
            var dateWaitRead = Header.FirstOrDefault(x => x.Key == "DATE_WAIT_READ");
            if (dateWaitRead.Value == null)
            {
                return true;
            }
            return DateTime.Parse(dateWaitRead.Value) >= DateTime.Now;

        }
    }
}