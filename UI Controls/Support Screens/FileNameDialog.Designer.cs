namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class FileNameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileNameDialog));
            label1 = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            FileNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(207, 17);
            label1.TabIndex = 0;
            label1.Text = "This is a placeholder for the name";
            // 
            // SaveButton
            // 
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(12, 69);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.ForeColor = Color.Black;
            CancelButton.Location = new Point(344, 69);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // FileNameTextBox
            // 
            FileNameTextBox.Location = new Point(225, 29);
            FileNameTextBox.Name = "FileNameTextBox";
            FileNameTextBox.Size = new Size(194, 23);
            FileNameTextBox.TabIndex = 3;
            FileNameTextBox.KeyDown += FileNameTextBox_KeyDown;
            // 
            // FileNameDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 142);
            Controls.Add(FileNameTextBox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FileNameDialog";
            Text = "File Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button SaveButton;
        private Button CancelButton;
        public TextBox FileNameTextBox;
    }
}