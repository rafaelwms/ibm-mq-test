namespace TesteIbmMQ.Domain.Settings
{
    public class QueueSettings
    {
        public string Host { get; set; }
        public string Channel { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string QueueManagerName { get; set; }
        public Dictionary<string, string> Queues { get; set; }

        public void SaveQueue(string alias, string queueName)
        {
            if (Queues.ContainsKey(alias))
            {
                Queues[alias] = queueName;
            }
            else
            {
                Queues.Add(alias, queueName);
            }
        }

        public void RemoveQueue(string alias) 
        {
            if (Queues.ContainsKey(alias))
            {
                Queues.Remove(alias);
            }
        }

        public QueueSettings()
        {
            Queues = new Dictionary<string, string>();
            Channel =
            Host = 
            Password =
            QueueManagerName =
            Port = 
            Username = string.Empty;
        }
    }
}
