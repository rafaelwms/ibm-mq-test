using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Domain.Utils;
using TesteIbmMQ.Infraestructure.Services;

namespace TesteIbmMQ.WinFormApp.Forms
{
    public partial class ConnectionForm : Form
    {
        public MainForm MainForm { get; set; }
        public QueueConfigurationSettings Settings { get; set; }
        public ConnectionForm()
        {
            InitializeComponent();
        }

        public ConnectionForm(MainForm mainForm, QueueConfigurationSettings settings)
        {
            InitializeComponent();
            MainForm = mainForm;
            Settings = settings;

        }


        private void btnConnectionTest_Click(object sender, EventArgs e)
        {
            if (Settings == null)
            {
                Settings = ContentFileUtil.INITIAL_SETTINGS;
                FillForm(Settings);
                return;
            }
            Settings = FormToSettings();

            var queueService = new QueueTransientService(Settings.QueueSettings);

            try
            {
                if (Settings.QueueSettings.Queues.Any())
                {
                    foreach (var queue in Settings.QueueSettings.Queues)
                    {
                        queueService.InitQueue(queue.Key);
                    }
                    MessageBox.Show($"Connection successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Failed");
            }


        }

        private void btnQueueAdd_Click(object sender, EventArgs e)
        {
            var aliasTextForm = new AliasTextForm(this, true);
            aliasTextForm.ShowDialog();
        }

        private void btnMessageAdd_Click(object sender, EventArgs e)
        {
            var aliasTextForm = new AliasTextForm(this, false);
            aliasTextForm.ShowDialog();
        }

        public void LoadQueueData()
        {
            lvQueues.Items.Clear();
            foreach (var item in Settings.QueueSettings.Queues)
            {
                lvQueues.Items.Add(item.Key).SubItems.AddRange(new string[] { item.Value });
            }
            lvQueues.Refresh();
        }

        public void LoadMessageData()
        {
            lvMessages.Items.Clear();
            foreach (var item in Settings.SavedMessages)
            {
                lvMessages.Items.Add(item.Key).SubItems.AddRange(new string[] { item.Value });
            }
            lvMessages.Refresh();
        }

        private void lvQueues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var alias = lvQueues.SelectedItems[0].Text.ToString();
            var queueName = lvQueues.SelectedItems[0].SubItems[1].Text.ToString();

            var aliasTextForm = new AliasTextForm(this, alias, queueName, true);
            aliasTextForm.ShowDialog();
        }

        private void lvMessages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var alias = lvMessages.SelectedItems[0].Text.ToString();
            var queueName = lvMessages.SelectedItems[0].SubItems[1].Text.ToString();

            var aliasTextForm = new AliasTextForm(this, alias, queueName, false);
            aliasTextForm.ShowDialog();
        }

        private void btnQueueRemove_Click(object sender, EventArgs e)
        {
            if (lvQueues.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a queue to remove");
                return;
            }
            var alias = lvQueues.SelectedItems[0].Text.ToString();
            if (alias != null)
            {
                Settings.QueueSettings.RemoveQueue(alias);
                LoadQueueData();
            }
        }

        private void btnMessageRemove_Click(object sender, EventArgs e)
        {
            if (lvMessages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a message to remove");
                return;
            }
            var alias = lvMessages.SelectedItems[0].Text.ToString();
            if (alias != null)
            {
                Settings.RemoveMessage(alias);
                LoadMessageData();
            }
        }

        private void FillForm(QueueConfigurationSettings settings)
        {
            this.tbConnName.Text = settings.SettingsName;
            this.tbConnChannel.Text = settings.QueueSettings.Channel;
            this.tbConnHost.Text = settings.QueueSettings.Host;
            this.tbConnPort.Text = settings.QueueSettings.Port.ToString();
            this.tbConnQueueManager.Text = settings.QueueSettings.QueueManagerName;
            this.tbConnUser.Text = settings.QueueSettings.Username;
            this.tbConnPassword.Text = settings.QueueSettings.Password;
            this.LoadQueueData();
            this.LoadMessageData();
        }

        private QueueConfigurationSettings FormToSettings()
        {
            var settings = new QueueConfigurationSettings();
            settings.QueueSettings = new QueueSettings();
            settings.SettingsName = tbConnName.Text;
            settings.QueueSettings.Channel = tbConnChannel.Text;
            settings.QueueSettings.Host = tbConnHost.Text;
            settings.QueueSettings.Port = tbConnPort.Text;
            settings.QueueSettings.QueueManagerName = tbConnQueueManager.Text;
            settings.QueueSettings.Username = tbConnUser.Text;
            settings.QueueSettings.Password = tbConnPassword.Text;
            settings.QueueSettings.Queues = GetKeyValuePairs(lvQueues);
            settings.SavedMessages = GetKeyValuePairs(lvMessages);
            return settings;
        }

        private Dictionary<string, string> GetKeyValuePairs(ListView lv)
        {
            var dict = new Dictionary<string, string>();
            foreach (ListViewItem item in lv.Items)
            {
                dict.Add(item.Text, item.SubItems[1].Text);
            }
            return dict;
        }

        private void btnConnectionSave_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            Settings = FormToSettings();
            MainForm.SaveSettings(Settings);
            this.Close();
        }

        private void gbConnections_Enter(object sender, EventArgs e)
        {

        }
        private void ConnectionForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Settings = ContentFileUtil.INITIAL_SETTINGS;
            FillForm(Settings);
            return;

        }
    }
}
