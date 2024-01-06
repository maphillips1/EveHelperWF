namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class UpdateMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMessageBox));
            UpdateTextLabel = new Label();
            ReleaseLinkLabel = new LinkLabel();
            ReleaseNotesTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // UpdateTextLabel
            // 
            UpdateTextLabel.AutoSize = true;
            UpdateTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            UpdateTextLabel.ForeColor = Color.Gold;
            UpdateTextLabel.Location = new Point(12, 9);
            UpdateTextLabel.Name = "UpdateTextLabel";
            UpdateTextLabel.Size = new Size(147, 21);
            UpdateTextLabel.TabIndex = 0;
            UpdateTextLabel.Text = "Update Text Label";
            // 
            // ReleaseLinkLabel
            // 
            ReleaseLinkLabel.AutoSize = true;
            ReleaseLinkLabel.LinkColor = Color.Cyan;
            ReleaseLinkLabel.Location = new Point(12, 65);
            ReleaseLinkLabel.Name = "ReleaseLinkLabel";
            ReleaseLinkLabel.Size = new Size(60, 15);
            ReleaseLinkLabel.TabIndex = 1;
            ReleaseLinkLabel.TabStop = true;
            ReleaseLinkLabel.Text = "linkLabel1";
            ReleaseLinkLabel.LinkClicked += ReleaseLinkLabel_LinkClicked;
            // 
            // ReleaseNotesTextBox
            // 
            ReleaseNotesTextBox.Location = new Point(12, 148);
            ReleaseNotesTextBox.Multiline = true;
            ReleaseNotesTextBox.Name = "ReleaseNotesTextBox";
            ReleaseNotesTextBox.ReadOnly = true;
            ReleaseNotesTextBox.Size = new Size(909, 359);
            ReleaseNotesTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 3;
            label1.Text = "Release Notes:";
            // 
            // UpdateMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(label1);
            Controls.Add(ReleaseNotesTextBox);
            Controls.Add(ReleaseLinkLabel);
            Controls.Add(UpdateTextLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "UpdateMessageBox";
            Text = "New Release Available";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UpdateTextLabel;
        private LinkLabel ReleaseLinkLabel;
        private TextBox ReleaseNotesTextBox;
        private Label label1;
    }
}