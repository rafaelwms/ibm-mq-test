using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Infraestructure.Services;

namespace TesteIbmMQ.WinFormApp.Common
{
    public static class CommonFormActions
    {
        public static void LoadComboBoxFromSettingList(this ComboBox comboBox, List<QueueConfigurationSettings>? settings)
        {
            comboBox.Items.Clear();
            if (settings != null && settings.Any())
            {
                foreach (var item in settings)
                {
                    comboBox.Items.Add(item);
                }
            }
            comboBox.DisplayMember = "SettingsName";
            comboBox.ValueMember = "Id";
            comboBox.Refresh();
        }
        public static void LoadListViewFromDictionary(this ListView listView, Dictionary<string,string>? dictionary)
        {
            listView.Items.Clear();
            if (dictionary != null && dictionary.Any())
            {
                foreach (var item in dictionary)
                {
                    listView.Items.Add(item.Key).SubItems.AddRange(new string[] { item.Value });
                }
            }
            listView.Refresh();
        }

        public static void AllowOnlyNumbers(this TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }

        public static bool CheckConnection(this QueueSettings settings)
        {

            if (settings.CheckSettings() == false)
            {
                ShowWarningMessage("Please, set up your connection.", "WARNING");
                return false;
            }

            var queueService = new QueueTransientService(settings);
            try
            {
                if (settings.Queues.Any())
                {
                    foreach (var queue in settings.Queues)
                    {
                        queueService.InitQueue(queue.Key);
                    }
                    ShowInformationMessage($"Connection to all Queues successful.", "SUCCESS");
         
                    return true;
                }
                else 
                {
                    ShowWarningMessage($"No Queues to test your connection.", "WARNING");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ShowWarningMessage(ex.Message, "Connection Failed");
                return false;
            }
        }

        public static bool IsListViewItemSelected(this ListView listView)
        {
            return listView.SelectedItems.Count == 1;
        }

        public static string GetKeyItemSelected(this ListView listView)
        {
            return listView.SelectedItems[0].Text;
        }

        public static string GetValueItemSelected(this ListView listView)
        {
            return listView.SelectedItems[0].SubItems[1].Text;
        }

        public static void ShowInformationMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarningMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool ShowAskInformationMessage(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        }
        public static bool ShowAskWarningMessage(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}
