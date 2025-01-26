namespace IbmMQTestApp.Settings
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

            var saved = SavedSettings.FirstOrDefault(x => x.Id == settings.Id);

            if (saved != null)
            {
                SavedSettings.Remove(saved);
            }

            SavedSettings.Add(settings);
        }
    }
}
