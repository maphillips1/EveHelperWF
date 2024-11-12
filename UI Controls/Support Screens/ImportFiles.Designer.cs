namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class ImportFiles
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
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFiles));
            FileTypeCombo = new ComboBox();
            SelectFilesButton = new Objects.Custom_Controls.EveHelperButton();
            FileNamesTextBox = new TextBox();
            importButton = new Objects.Custom_Controls.EveHelperButton();
            ImportFileDialog = new OpenFileDialog();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(93, 21);
            label1.TabIndex = 0;
            label1.Text = "Import Type";
            // 
            // FileTypeCombo
            // 
            FileTypeCombo.FormattingEnabled = true;
            FileTypeCombo.Location = new Point(111, 22);
            FileTypeCombo.Name = "FileTypeCombo";
            FileTypeCombo.Size = new Size(185, 23);
            FileTypeCombo.TabIndex = 1;
            // 
            // SelectFilesButton
            // 
            SelectFilesButton.ForeColor = Color.Black;
            SelectFilesButton.Location = new Point(12, 65);
            SelectFilesButton.Name = "SelectFilesButton";
            SelectFilesButton.Size = new Size(284, 23);
            SelectFilesButton.TabIndex = 2;
            SelectFilesButton.Text = "Select Files";
            SelectFilesButton.UseVisualStyleBackColor = true;
            SelectFilesButton.Click += SelectFilesButton_Click;
            // 
            // FileNamesTextBox
            // 
            FileNamesTextBox.Enabled = false;
            FileNamesTextBox.Location = new Point(12, 123);
            FileNamesTextBox.MaximumSize = new Size(284, 156);
            FileNamesTextBox.Multiline = true;
            FileNamesTextBox.Name = "FileNamesTextBox";
            FileNamesTextBox.ReadOnly = true;
            FileNamesTextBox.ScrollBars = ScrollBars.Vertical;
            FileNamesTextBox.Size = new Size(284, 156);
            FileNamesTextBox.TabIndex = 3;
            // 
            // importButton
            // 
            importButton.ForeColor = Color.Black;
            importButton.Location = new Point(12, 94);
            importButton.Name = "importButton";
            importButton.Size = new Size(112, 23);
            importButton.TabIndex = 4;
            importButton.Text = "Import";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += importButton_Click;
            // 
            // ImportFileDialog
            // 
            ImportFileDialog.DefaultExt = "json";
            ImportFileDialog.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.Download)";
            // 
            // ImportFiles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 347);
            Controls.Add(importButton);
            Controls.Add(FileNamesTextBox);
            Controls.Add(SelectFilesButton);
            Controls.Add(FileTypeCombo);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ImportFiles";
            Text = "Import Files";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox FileTypeCombo;
        private Objects.Custom_Controls.EveHelperButton SelectFilesButton;
        private TextBox FileNamesTextBox;
        private Objects.Custom_Controls.EveHelperButton importButton;
        private OpenFileDialog ImportFileDialog;
    }
}