namespace TesteIbmMQ.WinFormApp.Forms
{
    partial class ConnectionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            gbConnections = new GroupBox();
            label7 = new Label();
            tbConnPassword = new TextBox();
            label6 = new Label();
            tbConnUser = new TextBox();
            label5 = new Label();
            tbConnQueueManager = new TextBox();
            label4 = new Label();
            tbConnPort = new TextBox();
            label3 = new Label();
            tbConnChannel = new TextBox();
            label2 = new Label();
            tbConnHost = new TextBox();
            label1 = new Label();
            tbConnName = new TextBox();
            groupBox1 = new GroupBox();
            btnQueueRemove = new Button();
            btnQueueAdd = new Button();
            lvQueues = new ListView();
            chQueueAlias = new ColumnHeader();
            chQueueAddress = new ColumnHeader();
            groupBox2 = new GroupBox();
            btnMessageRemove = new Button();
            btnMessageAdd = new Button();
            lvMessages = new ListView();
            chMessageAlias = new ColumnHeader();
            chMessageText = new ColumnHeader();
            btnConnectionCancel = new Button();
            btnConnectionSave = new Button();
            btnConnectionTest = new Button();
            gbConnections.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // gbConnections
            // 
            gbConnections.Controls.Add(label7);
            gbConnections.Controls.Add(tbConnPassword);
            gbConnections.Controls.Add(label6);
            gbConnections.Controls.Add(tbConnUser);
            gbConnections.Controls.Add(label5);
            gbConnections.Controls.Add(tbConnQueueManager);
            gbConnections.Controls.Add(label4);
            gbConnections.Controls.Add(tbConnPort);
            gbConnections.Controls.Add(label3);
            gbConnections.Controls.Add(tbConnChannel);
            gbConnections.Controls.Add(label2);
            gbConnections.Controls.Add(tbConnHost);
            gbConnections.Controls.Add(label1);
            gbConnections.Controls.Add(tbConnName);
            gbConnections.Location = new Point(14, 34);
            gbConnections.Margin = new Padding(1, 2, 1, 2);
            gbConnections.Name = "gbConnections";
            gbConnections.Padding = new Padding(1, 2, 1, 2);
            gbConnections.Size = new Size(267, 531);
            gbConnections.TabIndex = 0;
            gbConnections.TabStop = false;
            gbConnections.Text = "Connection";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 452);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(91, 25);
            label7.TabIndex = 14;
            label7.Text = "Password:";
            // 
            // tbConnPassword
            // 
            tbConnPassword.Location = new Point(21, 478);
            tbConnPassword.Margin = new Padding(1, 2, 1, 2);
            tbConnPassword.Name = "tbConnPassword";
            tbConnPassword.PasswordChar = '●';
            tbConnPassword.Size = new Size(207, 31);
            tbConnPassword.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 380);
            label6.Margin = new Padding(1, 0, 1, 0);
            label6.Name = "label6";
            label6.Size = new Size(51, 25);
            label6.TabIndex = 12;
            label6.Text = "User:";
            // 
            // tbConnUser
            // 
            tbConnUser.Location = new Point(21, 407);
            tbConnUser.Margin = new Padding(1, 2, 1, 2);
            tbConnUser.Name = "tbConnUser";
            tbConnUser.Size = new Size(207, 31);
            tbConnUser.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 309);
            label5.Margin = new Padding(1, 0, 1, 0);
            label5.Name = "label5";
            label5.Size = new Size(143, 25);
            label5.TabIndex = 10;
            label5.Text = "Queue Manager:";
            // 
            // tbConnQueueManager
            // 
            tbConnQueueManager.Location = new Point(21, 337);
            tbConnQueueManager.Margin = new Padding(1, 2, 1, 2);
            tbConnQueueManager.Name = "tbConnQueueManager";
            tbConnQueueManager.Size = new Size(207, 31);
            tbConnQueueManager.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 168);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 8;
            label4.Text = "Port:";
            // 
            // tbConnPort
            // 
            tbConnPort.Location = new Point(21, 195);
            tbConnPort.Margin = new Padding(1, 2, 1, 2);
            tbConnPort.Name = "tbConnPort";
            tbConnPort.Size = new Size(97, 31);
            tbConnPort.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 238);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 6;
            label3.Text = "Channel:";
            // 
            // tbConnChannel
            // 
            tbConnChannel.Location = new Point(21, 265);
            tbConnChannel.Margin = new Padding(1, 2, 1, 2);
            tbConnChannel.Name = "tbConnChannel";
            tbConnChannel.Size = new Size(207, 31);
            tbConnChannel.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 97);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 4;
            label2.Text = "Host:";
            // 
            // tbConnHost
            // 
            tbConnHost.Location = new Point(21, 123);
            tbConnHost.Margin = new Padding(1, 2, 1, 2);
            tbConnHost.Name = "tbConnHost";
            tbConnHost.Size = new Size(207, 31);
            tbConnHost.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 27);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 2;
            label1.Text = "Name:";
            // 
            // tbConnName
            // 
            tbConnName.Location = new Point(21, 53);
            tbConnName.Margin = new Padding(1, 2, 1, 2);
            tbConnName.Name = "tbConnName";
            tbConnName.Size = new Size(207, 31);
            tbConnName.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnQueueRemove);
            groupBox1.Controls.Add(btnQueueAdd);
            groupBox1.Controls.Add(lvQueues);
            groupBox1.Location = new Point(292, 34);
            groupBox1.Margin = new Padding(1, 2, 1, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1, 2, 1, 2);
            groupBox1.Size = new Size(419, 293);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Queues";
            // 
            // btnQueueRemove
            // 
            btnQueueRemove.Location = new Point(234, 237);
            btnQueueRemove.Margin = new Padding(1, 2, 1, 2);
            btnQueueRemove.Name = "btnQueueRemove";
            btnQueueRemove.Size = new Size(170, 35);
            btnQueueRemove.TabIndex = 2;
            btnQueueRemove.Text = "Remove Queue";
            btnQueueRemove.UseVisualStyleBackColor = true;
            btnQueueRemove.Click += btnQueueRemove_Click;
            // 
            // btnQueueAdd
            // 
            btnQueueAdd.Location = new Point(13, 237);
            btnQueueAdd.Margin = new Padding(1, 2, 1, 2);
            btnQueueAdd.Name = "btnQueueAdd";
            btnQueueAdd.Size = new Size(170, 35);
            btnQueueAdd.TabIndex = 1;
            btnQueueAdd.Text = "Add Queue";
            btnQueueAdd.UseVisualStyleBackColor = true;
            btnQueueAdd.Click += btnQueueAdd_Click;
            // 
            // lvQueues
            // 
            lvQueues.Columns.AddRange(new ColumnHeader[] { chQueueAlias, chQueueAddress });
            lvQueues.FullRowSelect = true;
            lvQueues.Location = new Point(13, 41);
            lvQueues.Margin = new Padding(1, 2, 1, 2);
            lvQueues.Name = "lvQueues";
            lvQueues.Size = new Size(394, 182);
            lvQueues.TabIndex = 0;
            lvQueues.UseCompatibleStateImageBehavior = false;
            lvQueues.View = View.Details;
            lvQueues.MouseDoubleClick += lvQueues_MouseDoubleClick;
            // 
            // chQueueAlias
            // 
            chQueueAlias.Text = "Alias";
            chQueueAlias.Width = 200;
            // 
            // chQueueAddress
            // 
            chQueueAddress.Text = "Queue";
            chQueueAddress.Width = 450;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnMessageRemove);
            groupBox2.Controls.Add(btnMessageAdd);
            groupBox2.Controls.Add(lvMessages);
            groupBox2.Location = new Point(292, 340);
            groupBox2.Margin = new Padding(1, 2, 1, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(1, 2, 1, 2);
            groupBox2.Size = new Size(419, 225);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Example Messages";
            // 
            // btnMessageRemove
            // 
            btnMessageRemove.Location = new Point(234, 163);
            btnMessageRemove.Margin = new Padding(1, 2, 1, 2);
            btnMessageRemove.Name = "btnMessageRemove";
            btnMessageRemove.Size = new Size(170, 35);
            btnMessageRemove.TabIndex = 2;
            btnMessageRemove.Text = "Remove Message";
            btnMessageRemove.UseVisualStyleBackColor = true;
            btnMessageRemove.Click += btnMessageRemove_Click;
            // 
            // btnMessageAdd
            // 
            btnMessageAdd.Location = new Point(13, 163);
            btnMessageAdd.Margin = new Padding(1, 2, 1, 2);
            btnMessageAdd.Name = "btnMessageAdd";
            btnMessageAdd.Size = new Size(170, 35);
            btnMessageAdd.TabIndex = 1;
            btnMessageAdd.Text = "Add Message";
            btnMessageAdd.UseVisualStyleBackColor = true;
            btnMessageAdd.Click += btnMessageAdd_Click;
            // 
            // lvMessages
            // 
            lvMessages.Columns.AddRange(new ColumnHeader[] { chMessageAlias, chMessageText });
            lvMessages.FullRowSelect = true;
            lvMessages.Location = new Point(13, 41);
            lvMessages.Margin = new Padding(1, 2, 1, 2);
            lvMessages.Name = "lvMessages";
            lvMessages.Size = new Size(394, 107);
            lvMessages.TabIndex = 0;
            lvMessages.UseCompatibleStateImageBehavior = false;
            lvMessages.View = View.Details;
            lvMessages.MouseDoubleClick += lvMessages_MouseDoubleClick;
            // 
            // chMessageAlias
            // 
            chMessageAlias.Text = "Alias";
            chMessageAlias.Width = 200;
            // 
            // chMessageText
            // 
            chMessageText.Text = "Message";
            chMessageText.Width = 450;
            // 
            // btnConnectionCancel
            // 
            btnConnectionCancel.Location = new Point(316, 577);
            btnConnectionCancel.Margin = new Padding(1, 2, 1, 2);
            btnConnectionCancel.Name = "btnConnectionCancel";
            btnConnectionCancel.Size = new Size(170, 35);
            btnConnectionCancel.TabIndex = 3;
            btnConnectionCancel.Text = "Cancel";
            btnConnectionCancel.UseVisualStyleBackColor = true;
            // 
            // btnConnectionSave
            // 
            btnConnectionSave.Location = new Point(539, 577);
            btnConnectionSave.Margin = new Padding(1, 2, 1, 2);
            btnConnectionSave.Name = "btnConnectionSave";
            btnConnectionSave.Size = new Size(170, 35);
            btnConnectionSave.TabIndex = 4;
            btnConnectionSave.Text = "Save";
            btnConnectionSave.UseVisualStyleBackColor = true;
            btnConnectionSave.Click += btnConnectionSave_Click;
            // 
            // btnConnectionTest
            // 
            btnConnectionTest.Location = new Point(37, 577);
            btnConnectionTest.Margin = new Padding(1, 2, 1, 2);
            btnConnectionTest.Name = "btnConnectionTest";
            btnConnectionTest.Size = new Size(170, 35);
            btnConnectionTest.TabIndex = 5;
            btnConnectionTest.Text = "Test Connection";
            btnConnectionTest.UseVisualStyleBackColor = true;
            btnConnectionTest.Click += btnConnectionTest_Click;
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 630);
            Controls.Add(btnConnectionTest);
            Controls.Add(btnConnectionSave);
            Controls.Add(btnConnectionCancel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gbConnections);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1, 2, 1, 2);
            MaximizeBox = false;
            MaximumSize = new Size(752, 706);
            MinimumSize = new Size(752, 635);
            Name = "ConnectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connection Settings";
            MouseDoubleClick += ConnectionForm_MouseDoubleClick;
            gbConnections.ResumeLayout(false);
            gbConnections.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbConnections;
        private TextBox tbConnName;
        private Label label1;
        private Label label2;
        private TextBox tbConnHost;
        private Label label5;
        private TextBox tbConnQueueManager;
        private Label label4;
        private TextBox tbConnPort;
        private Label label3;
        private TextBox tbConnChannel;
        private Label label6;
        private TextBox tbConnUser;
        private Label label7;
        private TextBox tbConnPassword;
        private GroupBox groupBox1;
        private ListView lvQueues;
        private Button btnQueueRemove;
        private Button btnQueueAdd;
        private ColumnHeader chQueueAlias;
        private ColumnHeader chQueueAddress;
        private GroupBox groupBox2;
        private Button btnMessageRemove;
        private Button btnMessageAdd;
        private ListView lvMessages;
        private Button btnConnectionCancel;
        private Button btnConnectionSave;
        private ColumnHeader chMessageAlias;
        private ColumnHeader chMessageText;
        private Button btnConnectionTest;
    }
}
