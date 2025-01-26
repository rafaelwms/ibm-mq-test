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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new GroupBox();
            cbQueueSettings = new ComboBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbQueueSettings);
            groupBox1.Location = new Point(26, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1197, 319);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Center";
            // 
            // cbQueueSettings
            // 
            cbQueueSettings.FormattingEnabled = true;
            cbQueueSettings.Location = new Point(17, 84);
            cbQueueSettings.Name = "cbQueueSettings";
            cbQueueSettings.Size = new Size(387, 49);
            cbQueueSettings.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1255, 49);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(87, 45);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(249, 54);
            toolStripMenuItem1.Text = "Load";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(249, 54);
            saveToolStripMenuItem.Text = "Save";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 617);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "IBM MQ® - Connection Tester";
            groupBox1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}