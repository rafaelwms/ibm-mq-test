namespace IbmMQTestApp.Settings
{
    public class QueueConfigurationSettings
    {
        public string Id { get; set; }
        public string SettingsName { get; set; }
        public QueueSettings QueueSettings { get; set; }
        public Dictionary<string, string> SavedMessages { get; set; }

        public void SaveMessage(string alias, string queueName)
        {
            if (SavedMessages.ContainsKey(alias))
            {
                SavedMessages[alias] = queueName;
            }
            else
            {
                SavedMessages.Add(alias, queueName);
            }
        }

        public void RemoveMessage(string alias)
        {
            if (SavedMessages.ContainsKey(alias))
            {
                SavedMessages.Remove(alias);
            }
        }

        public QueueConfigurationSettings() 
        {
            Id = Guid.NewGuid().ToString();
            SavedMessages = new Dictionary<string, string>();
            QueueSettings = new QueueSettings();
            SettingsName = string.Empty;
        }
    }
}
