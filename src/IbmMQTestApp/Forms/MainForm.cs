using Newtonsoft.Json;
using IbmMQTestApp.Settings;
using IbmMQTestApp.Utils;
using IbmMQTestApp.Services;
using IbmMQTestApp.Common;

namespace IbmMQTestApp.Forms
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
                var newSettings =  CurrentSettings.CopySettings();
                
                if (CommonFormActions.ShowAskInformationMessage("Do you want to copy current settings?", "NEW CONNECTION") == false)
                {
                    newSettings = new QueueConfigurationSettings();
                    
                }
                
                ConnectionForm connectionForm = new ConnectionForm(this, newSettings);
                connectionForm.ShowDialog();

            }
            else
            {
                var newSettings = new QueueConfigurationSettings();
                ConnectionForm connectionForm = new ConnectionForm(this, newSettings);
                connectionForm.ShowDialog();
            }
            

            
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
            if (CurrentSettings == null)
            {
                return;
            }
            lvQueues.LoadListViewFromDictionary(CurrentSettings.QueueSettings.Queues);
        }

        public void LoadMessages()
        {
            if (CurrentSettings == null)
            {
                return;
            }
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
            LoadForm();
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
                    SaveConfigurationFile(filePath);
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
            LoadForm();
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
                    string defaultFileContent = CriptoUtil.EncryptString(filePath);
                    FileUtil.WriteFile(Environment.CurrentDirectory + "\\Settings.dll", defaultFileContent);
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                CommonFormActions.ShowWarningMessage("Not a valid configuration file.", "ERROR");
            }
        }

        private void SaveConfigurationFile(string filePath)
        {
            string fileContent = CriptoUtil.EncryptString(JsonConvert.SerializeObject(AppSettings));
            AppSettings.ConfigFile = filePath;
            FileUtil.WriteFile(filePath, fileContent);
            string defaultFileContent = CriptoUtil.EncryptString(filePath);
            FileUtil.WriteFile(Environment.CurrentDirectory + "\\Settings.dll", defaultFileContent);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((AppSettings != null && string.IsNullOrEmpty(AppSettings.ConfigFile) == false) && CommonFormActions.ShowAskInformationMessage("Do you want to save the current configuration before quit?", "SAVE CONFIGURATION"))
            {
                SaveConfigurationFile(AppSettings.ConfigFile);
            }
        }

        private void LoadForm()
        {
            LoadComboBox();
            LoadQueues();
            LoadMessages();
            LoadLabels();
            CheckFileLoaded();
        }

        private void CheckFileLoaded()
        {
            if (AppSettings == null || string.IsNullOrEmpty(AppSettings.ConfigFile))
            {
                menuItemSave.Enabled = false;
            }
            else
            {
                menuItemSave.Enabled = true;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AppSettings == null || string.IsNullOrEmpty(AppSettings.ConfigFile))
            {
                CommonFormActions.ShowWarningMessage("No file or configuration to save.", "WARNING");
                return;
            }
            SaveConfigurationFile(AppSettings.ConfigFile);
        }
    }
}
