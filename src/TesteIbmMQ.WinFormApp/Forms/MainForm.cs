using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteIbmMQ.Domain.Settings;

namespace TesteIbmMQ.WinFormApp.Forms
{
    public partial class MainForm : Form
    {

        public WinAppSettings AppSettings { get; set; }

        public QueueConfigurationSettings CurrentSettings { get; set; }

        public MainForm()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AppSettings == null) {
                AppSettings = new WinAppSettings();
                AppSettings.SavedSettings = new List<QueueConfigurationSettings>();
            }
            if(CurrentSettings == null)
            {
                CurrentSettings = new QueueConfigurationSettings();
                CurrentSettings.Id = Guid.NewGuid().ToString();
            }
            ConnectionForm connectionForm = new ConnectionForm(this, CurrentSettings);
            connectionForm.ShowDialog();
        }

        public void LoadComboBox()
        {
            cbQueueSettings.Items.Clear();

            if (AppSettings != null && AppSettings.SavedSettings.Any())
            {
                foreach (var item in AppSettings.SavedSettings)
                {
                    cbQueueSettings.Items.Add(item);
                }
            }

            cbQueueSettings.DisplayMember = "SettingsName";
            cbQueueSettings.ValueMember = "Id";

            if (CurrentSettings != null)
            {
                cbQueueSettings.SelectedValue = CurrentSettings.Id;
            }
        }

        public void LoadQueues()
        {
            lvQueues.Items.Clear();
            if (CurrentSettings != null && CurrentSettings.QueueSettings.Queues.Any())
            {
                foreach (var item in CurrentSettings.QueueSettings.Queues)
                {
                    lvQueues.Items.Add(item.Key).SubItems.AddRange(new string[] { item.Value });
                }
            }
            lvQueues.Refresh();
        }

        public void LoadMessages()
        {
            listView1.Items.Clear();
            if (CurrentSettings != null && CurrentSettings.SavedMessages.Any())
            {
                foreach (var item in CurrentSettings.SavedMessages)
                {
                    listView1.Items.Add(item.Key).SubItems.AddRange(new string[] { item.Value });
                }
            }
            listView1.Refresh();
        }

        public void SaveSettings(QueueConfigurationSettings settings)
        {
            if (AppSettings == null)
            {
                AppSettings = new WinAppSettings();
                AppSettings.SavedSettings = new List<QueueConfigurationSettings>();
            }
            AppSettings.SaveSetings(settings);
            CurrentSettings = settings;
            LoadComboBox();
            LoadQueues();
            LoadMessages();
            LoadLabels();
        }

        private void LoadLabels()
        {
            if (CurrentSettings != null)
            {
                lblHost.Text = "Host: " + CurrentSettings.QueueSettings.Host;
                lblChannel.Text = "Channel: " + CurrentSettings.QueueSettings.Channel;
                lblPort.Text = "Port: " + CurrentSettings.QueueSettings.Port;
                lblQM.Text = "QM: " + CurrentSettings.QueueSettings.QueueManagerName;
            }
        }
    }
}
