namespace TesteIbmMQ.Domain.Settings
{
    public class QueueSettings
    {
        public string Host { get; set; }
        public string Channel { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string QueueManagerName { get; set; }
        public Dictionary<string, string> Queues { get; set; }
    }
}
