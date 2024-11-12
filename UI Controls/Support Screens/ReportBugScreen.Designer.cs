namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class ReportBugScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBugScreen));
            label1 = new Label();
            ToolCombobox = new ComboBox();
            label2 = new Label();
            TypeIssueTextBox = new TextBox();
            DetailsTextBox = new TextBox();
            label3 = new Label();
            button1 = new Objects.Custom_Controls.EveHelperButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(218, 20);
            label1.TabIndex = 0;
            label1.Text = "Tool you're having an issue with";
            // 
            // ToolCombobox
            // 
            ToolCombobox.FormattingEnabled = true;
            ToolCombobox.Location = new Point(12, 41);
            ToolCombobox.Name = "ToolCombobox";
            ToolCombobox.Size = new Size(218, 23);
            ToolCombobox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(500, 20);
            label2.TabIndex = 2;
            label2.Text = "Type of Issue. Full crash/Problem on screen/Incorrect information/numbers";
            // 
            // TypeIssueTextBox
            // 
            TypeIssueTextBox.Location = new Point(12, 102);
            TypeIssueTextBox.MaxLength = 256;
            TypeIssueTextBox.Name = "TypeIssueTextBox";
            TypeIssueTextBox.Size = new Size(218, 23);
            TypeIssueTextBox.TabIndex = 3;
            // 
            // DetailsTextBox
            // 
            DetailsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DetailsTextBox.Location = new Point(12, 175);
            DetailsTextBox.Multiline = true;
            DetailsTextBox.Name = "DetailsTextBox";
            DetailsTextBox.Size = new Size(909, 332);
            DetailsTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 141);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 5;
            label3.Text = "Details";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(117, 141);
            button1.Name = "button1";
            button1.Size = new Size(113, 28);
            button1.TabIndex = 6;
            button1.Text = "Send Report";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ReportBugScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(DetailsTextBox);
            Controls.Add(TypeIssueTextBox);
            Controls.Add(label2);
            Controls.Add(ToolCombobox);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReportBugScreen";
            Text = "Report Issue";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox ToolCombobox;
        private Label label2;
        private TextBox TypeIssueTextBox;
        private TextBox DetailsTextBox;
        private Label label3;
        private Objects.Custom_Controls.EveHelperButton button1;
    }
}