namespace TesteIbmMQ.Domain.Settings
{
    public class WinAppSettings
    {   
        public string ConfigFile { get; set; }
        public List<QueueConfigurationSettings> SavedSettings { get; set; }

        public void SaveSetings(QueueConfigurationSettings settings)
        {
            if (SavedSettings == null)
            {
                SavedSettings = new List<QueueConfigurationSettings>();
            }

            if(SavedSettings.Where(st=> st.Id == settings.Id).Any())
            {
                SavedSettings.Remove(settings);
            }

            SavedSettings.Add(settings);
        }
    }
}
