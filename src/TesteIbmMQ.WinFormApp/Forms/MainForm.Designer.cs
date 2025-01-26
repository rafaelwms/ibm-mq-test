namespace TesteIbmMQ.WinFormApp.Forms
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
            saveToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            listView1 = new ListView();
            colMessageAlias = new ColumnHeader();
            colMessageText = new ColumnHeader();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(15, 51);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(704, 306);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Center";
            // 
            // btnConnectionEdit
            // 
            btnConnectionEdit.Location = new Point(273, 250);
            btnConnectionEdit.Name = "btnConnectionEdit";
            btnConnectionEdit.Size = new Size(191, 34);
            btnConnectionEdit.TabIndex = 10;
            btnConnectionEdit.Text = "Edit Connection";
            btnConnectionEdit.UseVisualStyleBackColor = true;
            // 
            // btnConnEdit
            // 
            btnConnEdit.Location = new Point(494, 250);
            btnConnEdit.Name = "btnConnEdit";
            btnConnEdit.Size = new Size(191, 34);
            btnConnEdit.TabIndex = 9;
            btnConnEdit.Text = "New Connection";
            btnConnEdit.UseVisualStyleBackColor = true;
            btnConnEdit.Click += button1_Click;
            // 
            // btnTetst
            // 
            btnTetst.Location = new Point(20, 250);
            btnTetst.Name = "btnTetst";
            btnTetst.Size = new Size(229, 34);
            btnTetst.TabIndex = 8;
            btnTetst.Text = "Test Connection";
            btnTetst.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(273, 33);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 7;
            label2.Text = "Queues";
            // 
            // lvQueues
            // 
            lvQueues.Columns.AddRange(new ColumnHeader[] { colQueueAlias, colQueueName });
            lvQueues.FullRowSelect = true;
            lvQueues.Location = new Point(273, 60);
            lvQueues.Name = "lvQueues";
            lvQueues.Size = new Size(412, 172);
            lvQueues.TabIndex = 6;
            lvQueues.UseCompatibleStateImageBehavior = false;
            lvQueues.View = View.Details;
            // 
            // colQueueAlias
            // 
            colQueueAlias.Text = "Alias";
            colQueueAlias.Width = 100;
            // 
            // colQueueName
            // 
            colQueueName.Text = "Queue";
            colQueueName.Width = 400;
            // 
            // lblQM
            // 
            lblQM.AutoSize = true;
            lblQM.Location = new Point(21, 207);
            lblQM.Name = "lblQM";
            lblQM.Size = new Size(46, 25);
            lblQM.TabIndex = 5;
            lblQM.Text = "QM:";
            // 
            // lblChannel
            // 
            lblChannel.AutoSize = true;
            lblChannel.Location = new Point(21, 173);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new Size(79, 25);
            lblChannel.TabIndex = 4;
            lblChannel.Text = "Channel:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(21, 139);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(48, 25);
            lblPort.TabIndex = 3;
            lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(21, 104);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(54, 25);
            lblHost.TabIndex = 2;
            lblHost.Text = "Host:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 33);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 1;
            label1.Text = "Configuration:";
            // 
            // cbQueueSettings
            // 
            cbQueueSettings.FormattingEnabled = true;
            cbQueueSettings.Location = new Point(21, 60);
            cbQueueSettings.Margin = new Padding(2);
            cbQueueSettings.Name = "cbQueueSettings";
            cbQueueSettings.Size = new Size(229, 33);
            cbQueueSettings.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(2, 1, 0, 1);
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(738, 31);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(270, 34);
            toolStripMenuItem1.Text = "Load";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(270, 34);
            saveToolStripMenuItem.Text = "Save";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(15, 385);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(704, 304);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Message Testing";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 223);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 13;
            label4.Text = "Custom Message";
            // 
            // button2
            // 
            button2.Location = new Point(532, 207);
            button2.Name = "button2";
            button2.Size = new Size(153, 34);
            button2.TabIndex = 12;
            button2.Text = "Send Selected";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(532, 251);
            button1.Name = "button1";
            button1.Size = new Size(153, 34);
            button1.TabIndex = 11;
            button1.Text = "Send Custom";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(21, 251);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(505, 31);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 35);
            label3.Name = "label3";
            label3.Size = new Size(143, 25);
            label3.TabIndex = 3;
            label3.Text = "Saved Messages";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colMessageAlias, colMessageText });
            listView1.Location = new Point(21, 63);
            listView1.Name = "listView1";
            listView1.Size = new Size(664, 138);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // colMessageAlias
            // 
            colMessageAlias.Text = "Alias";
            colMessageAlias.Width = 200;
            // 
            // colMessageText
            // 
            colMessageText.Text = "Message";
            colMessageText.Width = 500;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 719);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IBM MQ® - Connection Tester";
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
        private ListView listView1;
        private Label label4;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private ColumnHeader colMessageAlias;
    }
}