﻿using Newtonsoft.Json;
using TesteIbmMQ.Domain.Settings;
using TesteIbmMQ.Domain.Utils;
using TesteIbmMQ.Infraestructure.Services;
using TesteIbmMQ.WinFormApp.Common;

namespace TesteIbmMQ.WinFormApp.Forms
{
    public partial class MainForm : Form
    {

        public WinAppSettings AppSettings { get; set; }

        public QueueConfigurationSettings CurrentSettings { get; set; }

        public MainForm()
        {
            InitializeComponent();
            GetLastConfiguration();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (AppSettings == null)
            {
                AppSettings = new WinAppSettings();
                AppSettings.SavedSettings = new List<QueueConfigurationSettings>();
            }

            if (CurrentSettings != null && string.IsNullOrEmpty(CurrentSettings.SettingsName) == false)
            {
                if (CommonFormActions.ShowAskInformationMessage("Do you want to copy current settings?", "NEW CONNECTION") == false)
                {
                    CurrentSettings = new QueueConfigurationSettings();
                }
            }
            else 
            { 
                CurrentSettings = new QueueConfigurationSettings(); 
            }
            CurrentSettings.Id = Guid.NewGuid().ToString();

            ConnectionForm connectionForm = new ConnectionForm(this, CurrentSettings);
            connectionForm.ShowDialog();
        }

        public void LoadComboBox()
        {
            if (AppSettings != null)
                cbQueueSettings.LoadComboBoxFromSettingList(AppSettings.SavedSettings);

            if (CurrentSettings != null)
            {
                cbQueueSettings.SelectedItem = CurrentSettings;
            }
        }

        public void LoadQueues()
        {
            lvQueues.LoadListViewFromDictionary(CurrentSettings.QueueSettings.Queues);
        }

        public void LoadMessages()
        {
            lvMessages.LoadListViewFromDictionary(CurrentSettings.SavedMessages);
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
                lblUser.Text = "User: " + CurrentSettings.QueueSettings.Username;
            }
        }

        private void cbQueueSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentSettings = (QueueConfigurationSettings)cbQueueSettings.SelectedItem;
            LoadQueues();
            LoadMessages();
            LoadLabels();
        }

        private void btnConnectionEdit_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm(this, CurrentSettings);
            connectionForm.ShowDialog();
        }

        private void btnTetst_Click(object sender, EventArgs e)
        {
            var connectionCheck = CurrentSettings.QueueSettings.CheckConnection();

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (lvQueues.IsListViewItemSelected() == false)
            {
                CommonFormActions.ShowWarningMessage("Select a queue to send a message", "WARNING");
                lvQueues.Focus();
                return;
            }

            if (lvMessages.IsListViewItemSelected() == false)
            {
                CommonFormActions.ShowWarningMessage("Select a message to send", "WARNING");
                lvMessages.Focus();
                return;
            }

            var queue = lvQueues.GetValueItemSelected();
            var message = lvMessages.GetValueItemSelected();

            try
            {
                var queueService = new QueueTransientService(CurrentSettings.QueueSettings);
                await queueService.SendMessageToQueue(queue, message);
                CommonFormActions.ShowInformationMessage("Message sent", "SUCCESS");
            }
            catch (Exception ex)
            {
                CommonFormActions.ShowWarningMessage(ex.Message, "ERROR");
            }
        }

        private void lvQueues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var queue = lvQueues.GetKeyItemSelected();
            try
            {
                var queueService = new QueueTransientService(CurrentSettings.QueueSettings);
                var messages = queueService.GetQueueDepth(queue);
                if (messages == 0)
                {
                    CommonFormActions.ShowInformationMessage($"Queue {queue} is empty", "INFO");
                }
                else
                {
                    CommonFormActions.ShowInformationMessage($"Has {messages} message(s).", $"Queue: {queue}");
                }
            }
            catch (Exception ex)
            {
                CommonFormActions.ShowWarningMessage(ex.Message, "ERROR");
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (lvQueues.IsListViewItemSelected() == false)
            {
                CommonFormActions.ShowWarningMessage("Select a queue to send a message", "WARNING");
                lvQueues.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbCustomMessage.Text))
            {
                CommonFormActions.ShowWarningMessage("Write a message to send", "WARNING");
                tbCustomMessage.Focus();
                return;
            }

            var queue = lvQueues.GetValueItemSelected();
            var message = tbCustomMessage.Text;

            try
            {
                var queueService = new QueueTransientService(CurrentSettings.QueueSettings);
                await queueService.SendMessageToQueue(queue, message);
                CommonFormActions.ShowInformationMessage("Message sent", "SUCCESS");
            }
            catch (Exception ex)
            {
                CommonFormActions.ShowWarningMessage(ex.Message, "ERROR");
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Configuration files (*.cfg)|*.cfg|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string defaultFile = Environment.CurrentDirectory + "\\Settings.dll";
                    string filePath = saveFileDialog.FileName;
                    AppSettings.ConfigFile = filePath;
                    string fileContent = CriptoUtil.EncryptString(JsonConvert.SerializeObject(AppSettings));
                    string defaultFileContent = CriptoUtil.EncryptString(filePath);

                    // Save the file content here
                    File.WriteAllText(filePath, fileContent);
                    File.WriteAllText(defaultFile, defaultFileContent);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Configuration files (*.cfg)|*.cfg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadConfigurationFile(filePath);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void GetLastConfiguration() 
        {
            string defaultFile = Environment.CurrentDirectory + "\\Settings.dll";
            if (FileUtil.FileExists(defaultFile))
            {
                string fileContent = FileUtil.ReadEncriptedFile(defaultFile);

                LoadConfigurationFile(fileContent);
            }
        }

        private void LoadConfigurationFile(string filePath)
        {
            try
            {
                if (FileUtil.FileExists(filePath))
                {
                    string decriptedContent = FileUtil.ReadEncriptedFile(filePath);
                    AppSettings = JsonConvert.DeserializeObject<WinAppSettings>(decriptedContent);
                    CurrentSettings = AppSettings.SavedSettings.FirstOrDefault();
                    LoadComboBox();
                    LoadQueues();
                    LoadMessages();
                    LoadLabels();
                }
            }
            catch (Exception ex)
            {
                CommonFormActions.ShowWarningMessage("Not a valid configuration file.", "ERROR");
            }
        }
    }
}
