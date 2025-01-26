namespace TesteIbmMQ.WinFormApp.Forms
{
    partial class AliasTextForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AliasTextForm));
            groupBox1 = new GroupBox();
            label2 = new Label();
            tbText = new TextBox();
            label1 = new Label();
            tbAlias = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbText);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbAlias);
            groupBox1.Location = new Point(34, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1185, 185);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(341, 58);
            label2.Name = "label2";
            label2.Size = new Size(78, 41);
            label2.TabIndex = 6;
            label2.Text = "Text:";
            // 
            // tbText
            // 
            tbText.Location = new Point(341, 102);
            tbText.Name = "tbText";
            tbText.Size = new Size(813, 47);
            tbText.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 58);
            label1.Name = "label1";
            label1.Size = new Size(86, 41);
            label1.TabIndex = 4;
            label1.Text = "Alias:";
            // 
            // tbAlias
            // 
            tbAlias.Location = new Point(18, 102);
            tbAlias.Name = "tbAlias";
            tbAlias.Size = new Size(292, 47);
            tbAlias.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(898, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(290, 58);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(520, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(290, 58);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AliasTextForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 310);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1287, 398);
            MinimizeBox = false;
            MinimumSize = new Size(1287, 398);
            Name = "AliasTextForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insert Values";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private TextBox tbText;
        private Label label1;
        private TextBox tbAlias;
        private Button btnSave;
        private Button btnCancel;
    }
}