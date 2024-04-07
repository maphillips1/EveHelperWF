namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class BuildPlanSummaryHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildPlanSummaryHelp));
            HelpTextbox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // HelpTextbox
            // 
            HelpTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HelpTextbox.BackColor = Color.FromArgb(2, 23, 38);
            HelpTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            HelpTextbox.ForeColor = Color.White;
            HelpTextbox.Location = new Point(12, 50);
            HelpTextbox.Multiline = true;
            HelpTextbox.Name = "HelpTextbox";
            HelpTextbox.ReadOnly = true;
            HelpTextbox.ScrollBars = ScrollBars.Vertical;
            HelpTextbox.Size = new Size(776, 388);
            HelpTextbox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 1;
            label1.Text = "Build Plan - Summary";
            // 
            // BuildPlanSummaryHelp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(HelpTextbox);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BuildPlanSummaryHelp";
            Text = "Build Plan - Help";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HelpTextbox;
        private Label label1;
    }
}