namespace IbmMQTestApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ColumnHeader colMessageText;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new GroupBox();
            lblUser = new Label();
            btnConnectionEdit = new Button();
            btnConnEdit = new Button();
            btnTetst = new Button();
            label2 = new Label();
            lvQueues = new ListView();
            colQueueAlias = new ColumnHeader();
            colQueueName = new ColumnHeader();
            lblQM = new Label();
            lblChannel = new Label();
            lblPort = new Label();
            lblHost = new Label();
            label1 = new Label();
            cbQueueSettings = new ComboBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            saveToolStripMenuItem1 = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            tbCustomMessage = new TextBox();
            label3 = new Label();
            lvMessages = new ListView();
            colMessageAlias = new ColumnHeader();
            colMessageText = new ColumnHeader();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // colMessageText
            // 
            colMessageText.Text = "Message";
            colMessageText.Width = 2000;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblUser);
            groupBox1.Controls.Add(btnConnectionEdit);
            groupBox1.Controls.Add(btnConnEdit);
            groupBox1.Controls.Add(btnTetst);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lvQueues);
            groupBox1.Controls.Add(lblQM);
            groupBox1.Controls.Add(lblChannel);
            groupBox1.Controls.Add(lblPort);
            groupBox1.Controls.Add(lblHost);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbQueueSettings);
            groupBox1.Location = new Point(26, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1197, 539);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Center";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(36, 397);
            lblUser.Margin = new Padding(5, 0, 5, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(85, 41);
            lblUser.TabIndex = 11;
            lblUser.Text = "User:";
            // 
            // btnConnectionEdit
            // 
            btnConnectionEdit.Location = new Point(464, 463);
            btnConnectionEdit.Margin = new Padding(5);
            btnConnectionEdit.Name = "btnConnectionEdit";
            btnConnectionEdit.Size = new Size(325, 56);
            btnConnectionEdit.TabIndex = 10;
            btnConnectionEdit.Text = "Edit Connection";
            btnConnectionEdit.UseVisualStyleBackColor = true;
            btnConnectionEdit.Click += btnConnectionEdit_Click;
            // 
            // btnConnEdit
            // 
            btnConnEdit.Location = new Point(840, 463);
            btnConnEdit.Margin = new Padding(5);
            btnConnEdit.Name = "btnConnEdit";
            btnConnEdit.Size = new Size(325, 56);
            btnConnEdit.TabIndex = 9;
            btnConnEdit.Text = "New Connection";
            btnConnEdit.UseVisualStyleBackColor = true;
            btnConnEdit.Click += button1_Click;
            // 
            // btnTetst
            // 
            btnTetst.Location = new Point(34, 463);
            btnTetst.Margin = new Padding(5);
            btnTetst.Name = "btnTetst";
            btnTetst.Size = new Size(389, 56);
            btnTetst.TabIndex = 8;
            btnTetst.Text = "Test Connection";
            btnTetst.UseVisualStyleBackColor = true;
            btnTetst.Click += btnTetst_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(464, 54);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 41);
            label2.TabIndex = 7;
            label2.Text = "Queues";
            // 
            // lvQueues
            // 
            lvQueues.Columns.AddRange(new ColumnHeader[] { colQueueAlias, colQueueName });
            lvQueues.FullRowSelect = true;
            lvQueues.Location = new Point(464, 98);
            lvQueues.Margin = new Padding(5);
            lvQueues.MultiSelect = false;
            lvQueues.Name = "lvQueues";
            lvQueues.Size = new Size(698, 340);
            lvQueues.TabIndex = 6;
            lvQueues.UseCompatibleStateImageBehavior = false;
            lvQueues.View = View.Details;
            lvQueues.MouseDoubleClick += lvQueues_MouseDoubleClick;
            // 
            // colQueueAlias
            // 
            colQueueAlias.Text = "Alias";
            colQueueAlias.Width = 250;
            // 
            // colQueueName
            // 
            colQueueName.Text = "Queue";
            colQueueName.Width = 1000;
            // 
            // lblQM
            // 
            lblQM.AutoSize = true;
            lblQM.Location = new Point(36, 339);
            lblQM.Margin = new Padding(5, 0, 5, 0);
            lblQM.Name = "lblQM";
            lblQM.Size = new Size(75, 41);
            lblQM.TabIndex = 5;
            lblQM.Text = "QM:";
            // 
            // lblChannel
            // 
            lblChannel.AutoSize = true;
            lblChannel.Location = new Point(36, 284);
            lblChannel.Margin = new Padding(5, 0, 5, 0);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new Size(133, 41);
            lblChannel.TabIndex = 4;
            lblChannel.Text = "Channel:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(36, 228);
            lblPort.Margin = new Padding(5, 0, 5, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(79, 41);
            lblPort.TabIndex = 3;
            lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(36, 171);
            lblHost.Margin = new Padding(5, 0, 5, 0);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(87, 41);
            lblHost.TabIndex = 2;
            lblHost.Text = "Host:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 54);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(207, 41);
            label1.TabIndex = 1;
            label1.Text = "Configuration:";
            // 
            // cbQueueSettings
            // 
            cbQueueSettings.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQueueSettings.FormattingEnabled = true;
            cbQueueSettings.Location = new Point(36, 98);
            cbQueueSettings.Name = "cbQueueSettings";
            cbQueueSettings.Size = new Size(386, 49);
            cbQueueSettings.TabIndex = 0;
            cbQueueSettings.SelectedIndexChanged += cbQueueSettings_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1255, 52);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, saveToolStripMenuItem1, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(87, 48);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(448, 54);
            toolStripMenuItem1.Text = "Load";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.Size = new Size(448, 54);
            saveToolStripMenuItem1.Text = "Save";
            saveToolStripMenuItem1.Click += saveToolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(448, 54);
            saveToolStripMenuItem.Text = "Save As...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(104, 48);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(287, 54);
            aboutToolStripMenuItem.Text = "About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(tbCustomMessage);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lvMessages);
            groupBox2.Location = new Point(26, 631);
            groupBox2.Margin = new Padding(5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5);
            groupBox2.Size = new Size(1197, 499);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Message Testing";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 366);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(247, 41);
            label4.TabIndex = 13;
            label4.Text = "Custom Message";
            // 
            // button2
            // 
            button2.Location = new Point(904, 339);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(260, 56);
            button2.TabIndex = 12;
            button2.Text = "Send Selected";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(904, 412);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(260, 56);
            button1.TabIndex = 11;
            button1.Text = "Send Custom";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // tbCustomMessage
            // 
            tbCustomMessage.Location = new Point(36, 412);
            tbCustomMessage.Margin = new Padding(5);
            tbCustomMessage.Name = "tbCustomMessage";
            tbCustomMessage.Size = new Size(856, 47);
            tbCustomMessage.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 57);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(236, 41);
            label3.TabIndex = 3;
            label3.Text = "Saved Messages";
            // 
            // lvMessages
            // 
            lvMessages.Columns.AddRange(new ColumnHeader[] { colMessageAlias, colMessageText });
            lvMessages.FullRowSelect = true;
            lvMessages.Location = new Point(36, 103);
            lvMessages.Margin = new Padding(5);
            lvMessages.MultiSelect = false;
            lvMessages.Name = "lvMessages";
            lvMessages.Size = new Size(1126, 224);
            lvMessages.TabIndex = 0;
            lvMessages.UseCompatibleStateImageBehavior = false;
            lvMessages.View = View.Details;
            // 
            // colMessageAlias
            // 
            colMessageAlias.Text = "Alias";
            colMessageAlias.Width = 250;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 1179);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(1287, 1267);
            MinimumSize = new Size(1287, 1267);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IBM MQ® - Connection Tester";
            FormClosing += MainForm_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ComboBox cbQueueSettings;
        private Label label1;
        private Label label2;
        private ListView lvQueues;
        private Label lblQM;
        private Label lblChannel;
        private Label lblPort;
        private Label lblHost;
        private ColumnHeader colQueueAlias;
        private ColumnHeader colQueueName;
        private Button btnConnEdit;
        private Button btnTetst;
        private Button btnConnectionEdit;
        private GroupBox groupBox2;
        private Label label3;
        private ListView lvMessages;
        private Label label4;
        private Button button2;
        private Button button1;
        private TextBox tbCustomMessage;
        private ColumnHeader colMessageAlias;
        private Label lblUser;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
    }
}