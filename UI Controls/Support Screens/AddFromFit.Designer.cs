namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class AddFromFitForm
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
            Label InfoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFromFitForm));
            FitTextBox = new TextBox();
            SaveButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            CancelButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            InfoLabel = new Label();
            SuspendLayout();
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InfoLabel.Location = new Point(12, 9);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(269, 20);
            InfoLabel.TabIndex = 0;
            InfoLabel.Text = "Copy and Paste From Fitting Window";
            // 
            // FitTextBox
            // 
            FitTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FitTextBox.Location = new Point(12, 32);
            FitTextBox.Multiline = true;
            FitTextBox.Name = "FitTextBox";
            FitTextBox.PlaceholderText = "Copy and Paste from the Fitting Window";
            FitTextBox.ScrollBars = ScrollBars.Vertical;
            FitTextBox.Size = new Size(909, 398);
            FitTextBox.TabIndex = 1;
            FitTextBox.TextChanged += FitTextBox_TextChanged;
            // 
            // SaveButton
            // 
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.FromArgb(234, 234, 234);
            SaveButton.Location = new Point(12, 457);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(155, 23);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.ForeColor = Color.FromArgb(234, 234, 234);
            CancelButton.Location = new Point(218, 457);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(155, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddFromFitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(FitTextBox);
            Controls.Add(InfoLabel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddFromFitForm";
            Text = "Add From Fit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FitTextBox;
        private Objects.Custom_Controls.EveHelperButton SaveButton;
        private Objects.Custom_Controls.EveHelperButton CancelButton;
    }
}