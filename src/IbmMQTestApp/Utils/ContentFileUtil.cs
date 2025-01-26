using IbmMQTestApp.Settings;

namespace IbmMQTestApp.Utils
{
    public static class ContentFileUtil
    {
        public static QueueConfigurationSettings INITIAL_SETTINGS = new QueueConfigurationSettings
        {
            Id = Guid.NewGuid().ToString(),
            SettingsName = "Local App Settings",
            QueueSettings = new QueueSettings
            {
                Host = "localhost",
                Channel = "DEV.APP.SVRCONN",
                Port = "1414",
                Username = "app",
                Password = "passw0rd",
                QueueManagerName = "QM1",
                Queues = new Dictionary<string, string>
                {
                    { "1.Standard", "DEV.QUEUE.1" },
                    { "2.Retry", "DEV.QUEUE.2" },
                    { "3.DeadLetter", "DEV.QUEUE.3" }
                }
            },
            SavedMessages = new Dictionary<string, string>
                {
                    { "Test Message", @"{ ""Data"" : { ""Name"" : ""Example"" }}" }
                },

        };

    }
}
