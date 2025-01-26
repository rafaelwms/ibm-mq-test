using TesteIbmMQ.Domain.Settings;

namespace TesteIbmMQ.WinFormApp.Forms
{
    public partial class AliasTextForm : Form
    {
        public bool InsertMode { get; set; }
        public bool IsQueueData { get; set; }
        public string Alias { get; set; }
        public string DataText { get; set; }
        public string Mode { get; set; }

        public ConnectionForm ConnForm { get; set; }

        public AliasTextForm()
        {
            InitializeComponent();
        }

        public AliasTextForm(ConnectionForm settings, string alias, string text, bool isQueueData)
        {
            InitializeComponent();
            ConnForm = settings;
            InsertMode = false;
            IsQueueData = isQueueData;
            AliasTextForm_Load(isQueueData, "Edit");
            Alias = tbAlias.Text = alias;
            DataText = tbText.Text = text;

        }

        public AliasTextForm(ConnectionForm settings, bool isQueueData)
        {
            InitializeComponent();
            ConnForm = settings;
            InsertMode = true;
            IsQueueData = isQueueData;
            AliasTextForm_Load(isQueueData, "Insert");
            Alias =
            DataText = string.Empty;

        }

        private void AliasTextForm_Load(bool isQueueData, string mode)
        {
            this.Text = mode + " Message";
            if (isQueueData)
            {
                this.Text = mode + " Queue";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbAlias.Text.Trim()) || string.IsNullOrEmpty(tbText.Text.Trim()))
            {
                MessageBox.Show($"Alias and {(IsQueueData ? "Queue" : "Message")} are required fields.", "WARNING",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                return;
            }

            var alias = tbAlias.Text.Trim();
            var text = tbText.Text.Trim();

            if (ConnForm.Settings == null)
            {
                ConnForm.Settings = new QueueConfigurationSettings();
                ConnForm.Settings.QueueSettings = new QueueSettings();
                ConnForm.Settings.SavedMessages = new Dictionary<string, string>();
                ConnForm.Settings.QueueSettings.Queues = new Dictionary<string, string>();
            }

            if (string.IsNullOrEmpty(Alias))
            {
                if (IsQueueData)
                {
                    ConnForm.Settings.QueueSettings.SaveQueue(alias, text);
                }
                else
                {
                    ConnForm.Settings.SaveMessage(alias, text);
                }
            }
            else
            {
                if (IsQueueData)
                {
                    ConnForm.Settings.QueueSettings.RemoveQueue(Alias);
                    ConnForm.Settings.QueueSettings.SaveQueue(alias, text);
                }
                else
                {
                    ConnForm.Settings.RemoveMessage(Alias);
                    ConnForm.Settings.SaveMessage(alias, text);
                }
            }
            this.Dispose();
            ConnForm.LoadQueueData();
            ConnForm.LoadMessageData();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
