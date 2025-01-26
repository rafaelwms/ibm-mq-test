namespace IbmMQTestApp.Forms
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
            gbConnections.Location = new Point(24, 56);
            gbConnections.Margin = new Padding(2, 3, 2, 3);
            gbConnections.Name = "gbConnections";
            gbConnections.Padding = new Padding(2, 3, 2, 3);
            gbConnections.Size = new Size(454, 871);
            gbConnections.TabIndex = 0;
            gbConnections.TabStop = false;
            gbConnections.Text = "Connection";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 741);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(150, 41);
            label7.TabIndex = 14;
            label7.Text = "Password:";
            // 
            // tbConnPassword
            // 
            tbConnPassword.Location = new Point(36, 784);
            tbConnPassword.Margin = new Padding(2, 3, 2, 3);
            tbConnPassword.Name = "tbConnPassword";
            tbConnPassword.PasswordChar = '●';
            tbConnPassword.Size = new Size(349, 47);
            tbConnPassword.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 623);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(85, 41);
            label6.TabIndex = 12;
            label6.Text = "User:";
            // 
            // tbConnUser
            // 
            tbConnUser.Location = new Point(36, 667);
            tbConnUser.Margin = new Padding(2, 3, 2, 3);
            tbConnUser.Name = "tbConnUser";
            tbConnUser.Size = new Size(349, 47);
            tbConnUser.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 507);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(240, 41);
            label5.TabIndex = 10;
            label5.Text = "Queue Manager:";
            // 
            // tbConnQueueManager
            // 
            tbConnQueueManager.Location = new Point(36, 553);
            tbConnQueueManager.Margin = new Padding(2, 3, 2, 3);
            tbConnQueueManager.Name = "tbConnQueueManager";
            tbConnQueueManager.Size = new Size(349, 47);
            tbConnQueueManager.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 276);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 41);
            label4.TabIndex = 8;
            label4.Text = "Port:";
            // 
            // tbConnPort
            // 
            tbConnPort.Location = new Point(36, 320);
            tbConnPort.Margin = new Padding(2, 3, 2, 3);
            tbConnPort.Name = "tbConnPort";
            tbConnPort.Size = new Size(162, 47);
            tbConnPort.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 390);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(133, 41);
            label3.TabIndex = 6;
            label3.Text = "Channel:";
            // 
            // tbConnChannel
            // 
            tbConnChannel.Location = new Point(36, 435);
            tbConnChannel.Margin = new Padding(2, 3, 2, 3);
            tbConnChannel.Name = "tbConnChannel";
            tbConnChannel.Size = new Size(349, 47);
            tbConnChannel.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 159);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 41);
            label2.TabIndex = 4;
            label2.Text = "Host:";
            // 
            // tbConnHost
            // 
            tbConnHost.Location = new Point(36, 202);
            tbConnHost.Margin = new Padding(2, 3, 2, 3);
            tbConnHost.Name = "tbConnHost";
            tbConnHost.Size = new Size(349, 47);
            tbConnHost.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 44);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 41);
            label1.TabIndex = 2;
            label1.Text = "Name:";
            // 
            // tbConnName
            // 
            tbConnName.Location = new Point(36, 87);
            tbConnName.Margin = new Padding(2, 3, 2, 3);
            tbConnName.Name = "tbConnName";
            tbConnName.Size = new Size(349, 47);
            tbConnName.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnQueueRemove);
            groupBox1.Controls.Add(btnQueueAdd);
            groupBox1.Controls.Add(lvQueues);
            groupBox1.Location = new Point(496, 56);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(712, 481);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Queues";
            // 
            // btnQueueRemove
            // 
            btnQueueRemove.Location = new Point(398, 389);
            btnQueueRemove.Margin = new Padding(2, 3, 2, 3);
            btnQueueRemove.Name = "btnQueueRemove";
            btnQueueRemove.Size = new Size(289, 57);
            btnQueueRemove.TabIndex = 2;
            btnQueueRemove.Text = "Remove Queue";
            btnQueueRemove.UseVisualStyleBackColor = true;
            btnQueueRemove.Click += btnQueueRemove_Click;
            // 
            // btnQueueAdd
            // 
            btnQueueAdd.Location = new Point(22, 389);
            btnQueueAdd.Margin = new Padding(2, 3, 2, 3);
            btnQueueAdd.Name = "btnQueueAdd";
            btnQueueAdd.Size = new Size(289, 57);
            btnQueueAdd.TabIndex = 1;
            btnQueueAdd.Text = "Add Queue";
            btnQueueAdd.UseVisualStyleBackColor = true;
            btnQueueAdd.Click += btnQueueAdd_Click;
            // 
            // lvQueues
            // 
            lvQueues.Columns.AddRange(new ColumnHeader[] { chQueueAlias, chQueueAddress });
            lvQueues.FullRowSelect = true;
            lvQueues.Location = new Point(22, 67);
            lvQueues.Margin = new Padding(2, 3, 2, 3);
            lvQueues.MultiSelect = false;
            lvQueues.Name = "lvQueues";
            lvQueues.Size = new Size(667, 296);
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
            groupBox2.Location = new Point(496, 558);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(712, 369);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Example Messages";
            // 
            // btnMessageRemove
            // 
            btnMessageRemove.Location = new Point(398, 267);
            btnMessageRemove.Margin = new Padding(2, 3, 2, 3);
            btnMessageRemove.Name = "btnMessageRemove";
            btnMessageRemove.Size = new Size(289, 57);
            btnMessageRemove.TabIndex = 2;
            btnMessageRemove.Text = "Remove Message";
            btnMessageRemove.UseVisualStyleBackColor = true;
            btnMessageRemove.Click += btnMessageRemove_Click;
            // 
            // btnMessageAdd
            // 
            btnMessageAdd.Location = new Point(22, 267);
            btnMessageAdd.Margin = new Padding(2, 3, 2, 3);
            btnMessageAdd.Name = "btnMessageAdd";
            btnMessageAdd.Size = new Size(289, 57);
            btnMessageAdd.TabIndex = 1;
            btnMessageAdd.Text = "Add Message";
            btnMessageAdd.UseVisualStyleBackColor = true;
            btnMessageAdd.Click += btnMessageAdd_Click;
            // 
            // lvMessages
            // 
            lvMessages.Columns.AddRange(new ColumnHeader[] { chMessageAlias, chMessageText });
            lvMessages.FullRowSelect = true;
            lvMessages.Location = new Point(22, 67);
            lvMessages.Margin = new Padding(2, 3, 2, 3);
            lvMessages.MultiSelect = false;
            lvMessages.Name = "lvMessages";
            lvMessages.Size = new Size(667, 173);
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
            btnConnectionCancel.Location = new Point(537, 946);
            btnConnectionCancel.Margin = new Padding(2, 3, 2, 3);
            btnConnectionCancel.Name = "btnConnectionCancel";
            btnConnectionCancel.Size = new Size(289, 57);
            btnConnectionCancel.TabIndex = 3;
            btnConnectionCancel.Text = "Cancel";
            btnConnectionCancel.UseVisualStyleBackColor = true;
            btnConnectionCancel.Click += btnConnectionCancel_Click;
            // 
            // btnConnectionSave
            // 
            btnConnectionSave.Location = new Point(916, 946);
            btnConnectionSave.Margin = new Padding(2, 3, 2, 3);
            btnConnectionSave.Name = "btnConnectionSave";
            btnConnectionSave.Size = new Size(289, 57);
            btnConnectionSave.TabIndex = 4;
            btnConnectionSave.Text = "Save";
            btnConnectionSave.UseVisualStyleBackColor = true;
            btnConnectionSave.Click += btnConnectionSave_Click;
            // 
            // btnConnectionTest
            // 
            btnConnectionTest.Location = new Point(63, 946);
            btnConnectionTest.Margin = new Padding(2, 3, 2, 3);
            btnConnectionTest.Name = "btnConnectionTest";
            btnConnectionTest.Size = new Size(289, 57);
            btnConnectionTest.TabIndex = 5;
            btnConnectionTest.Text = "Test Connection";
            btnConnectionTest.UseVisualStyleBackColor = true;
            btnConnectionTest.Click += btnConnectionTest_Click;
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 1014);
            Controls.Add(btnConnectionTest);
            Controls.Add(btnConnectionSave);
            Controls.Add(btnConnectionCancel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gbConnections);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MaximumSize = new Size(1256, 1102);
            MinimumSize = new Size(1256, 985);
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
