namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class BackupFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupFiles));
            PriceHistoryCheckbox = new CheckBox();
            DefaultValuesCheckbox = new CheckBox();
            AbyssRunsCheckbox = new CheckBox();
            TrackedItemsCheckbox = new CheckBox();
            BackupFilesButton = new Button();
            BackupFilesDialog = new FolderBrowserDialog();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // PriceHistoryCheckbox
            // 
            PriceHistoryCheckbox.AutoSize = true;
            PriceHistoryCheckbox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            PriceHistoryCheckbox.Location = new Point(12, 12);
            PriceHistoryCheckbox.Name = "PriceHistoryCheckbox";
            PriceHistoryCheckbox.Size = new Size(140, 27);
            PriceHistoryCheckbox.TabIndex = 0;
            PriceHistoryCheckbox.Text = "Price Histories";
            PriceHistoryCheckbox.UseVisualStyleBackColor = true;
            // 
            // DefaultValuesCheckbox
            // 
            DefaultValuesCheckbox.AutoSize = true;
            DefaultValuesCheckbox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            DefaultValuesCheckbox.Location = new Point(12, 111);
            DefaultValuesCheckbox.Name = "DefaultValuesCheckbox";
            DefaultValuesCheckbox.Size = new Size(142, 27);
            DefaultValuesCheckbox.TabIndex = 1;
            DefaultValuesCheckbox.Text = "Default Values";
            DefaultValuesCheckbox.UseVisualStyleBackColor = true;
            // 
            // AbyssRunsCheckbox
            // 
            AbyssRunsCheckbox.AutoSize = true;
            AbyssRunsCheckbox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            AbyssRunsCheckbox.Location = new Point(12, 78);
            AbyssRunsCheckbox.Name = "AbyssRunsCheckbox";
            AbyssRunsCheckbox.Size = new Size(119, 27);
            AbyssRunsCheckbox.TabIndex = 2;
            AbyssRunsCheckbox.Text = "Abyss Runs";
            AbyssRunsCheckbox.UseVisualStyleBackColor = true;
            // 
            // TrackedItemsCheckbox
            // 
            TrackedItemsCheckbox.AutoSize = true;
            TrackedItemsCheckbox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            TrackedItemsCheckbox.Location = new Point(12, 45);
            TrackedItemsCheckbox.Name = "TrackedItemsCheckbox";
            TrackedItemsCheckbox.Size = new Size(138, 27);
            TrackedItemsCheckbox.TabIndex = 3;
            TrackedItemsCheckbox.Text = "Tracked Items";
            TrackedItemsCheckbox.UseVisualStyleBackColor = true;
            // 
            // BackupFilesButton
            // 
            BackupFilesButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            BackupFilesButton.ForeColor = Color.Black;
            BackupFilesButton.Location = new Point(8, 168);
            BackupFilesButton.Name = "BackupFilesButton";
            BackupFilesButton.Size = new Size(142, 29);
            BackupFilesButton.TabIndex = 4;
            BackupFilesButton.Text = "Backup Files";
            BackupFilesButton.UseVisualStyleBackColor = true;
            BackupFilesButton.Click += BackupFilesButton_Click;
            // 
            // BackupFilesDialog
            // 
            BackupFilesDialog.Description = "Backup Location";
            BackupFilesDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
            BackupFilesDialog.UseDescriptionForTitle = true;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(2, 23, 38);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(228, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 203);
            textBox1.TabIndex = 5;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // BackupFiles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 227);
            Controls.Add(textBox1);
            Controls.Add(BackupFilesButton);
            Controls.Add(TrackedItemsCheckbox);
            Controls.Add(AbyssRunsCheckbox);
            Controls.Add(DefaultValuesCheckbox);
            Controls.Add(PriceHistoryCheckbox);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BackupFiles";
            Text = "Backup Files";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox PriceHistoryCheckbox;
        private CheckBox DefaultValuesCheckbox;
        private CheckBox AbyssRunsCheckbox;
        private CheckBox TrackedItemsCheckbox;
        private Button BackupFilesButton;
        private FolderBrowserDialog BackupFilesDialog;
        private TextBox textBox1;
    }
}