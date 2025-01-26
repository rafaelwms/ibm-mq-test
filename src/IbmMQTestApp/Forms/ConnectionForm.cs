using IbmMQTestApp.Utils;
using IbmMQTestApp.Common;
using IbmMQTestApp.Settings;

namespace IbmMQTestApp.Forms
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
            tbConnPort.AllowOnlyNumbers();
            MainForm = mainForm;
            Settings = settings;
            FillForm(Settings);
        }


        private void btnConnectionTest_Click(object sender, EventArgs e)
        {
            Settings = FormToSettings();
            Settings.QueueSettings.CheckConnection();
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
            this.tbConnPort.Text = settings.QueueSettings.Port;
            this.tbConnQueueManager.Text = settings.QueueSettings.QueueManagerName;
            this.tbConnUser.Text = settings.QueueSettings.Username;
            this.tbConnPassword.Text = settings.QueueSettings.Password;
            this.LoadQueueData();
            this.LoadMessageData();
        }

        private QueueConfigurationSettings FormToSettings()
        {
            if (Settings == null)
            {
                Settings = new QueueConfigurationSettings();
                Settings.QueueSettings = new QueueSettings();

            }
            Settings.QueueSettings = new QueueSettings();
            Settings.SettingsName = tbConnName.Text;
            Settings.QueueSettings.Channel = tbConnChannel.Text;
            Settings.QueueSettings.Host = tbConnHost.Text;
            Settings.QueueSettings.Port = tbConnPort.Text;
            Settings.QueueSettings.QueueManagerName = tbConnQueueManager.Text;
            Settings.QueueSettings.Username = tbConnUser.Text;
            Settings.QueueSettings.Password = tbConnPassword.Text;
            Settings.QueueSettings.Queues = GetKeyValuePairs(lvQueues);
            Settings.SavedMessages = GetKeyValuePairs(lvMessages);
            return Settings;
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

        private void btnConnectionCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
