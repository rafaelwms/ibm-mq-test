using IbmMQTestApp.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbmMQTestApp.Utils
{
    public static class QueueSettingsUtil
    {
        public static QueueConfigurationSettings CopySettings(this QueueConfigurationSettings settings)
        {
            var newSettings = new QueueConfigurationSettings();
            newSettings.SavedMessages = settings.SavedMessages;
            newSettings.QueueSettings = settings.QueueSettings;
            newSettings.SettingsName = settings.SettingsName;
            return newSettings;
        }
    }
}
