namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class HunterIntel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HunterIntel));
            label1 = new Label();
            SearchTextBox = new TextBox();
            SearchButton = new Objects.Custom_Controls.EveHelperButton();
            StatsPanel = new Panel();
            LoadLocalScanButton = new Objects.Custom_Controls.EveHelperButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 0;
            label1.Text = "Search text";
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(113, 9);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(374, 23);
            SearchTextBox.TabIndex = 1;
            SearchTextBox.Text = "Enter a name of anything. Must match exactly because ccp";
            SearchTextBox.Enter += SearchTextBox_Enter;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;
            SearchTextBox.Leave += SearchTextBox_Leave;
            // 
            // SearchButton
            // 
            SearchButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchButton.ForeColor = Color.FromArgb(234, 234, 234);
            SearchButton.Location = new Point(493, 5);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(113, 28);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // StatsPanel
            // 
            StatsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatsPanel.Location = new Point(12, 49);
            StatsPanel.Name = "StatsPanel";
            StatsPanel.Size = new Size(909, 458);
            StatsPanel.TabIndex = 3;
            // 
            // LoadLocalScanButton
            // 
            LoadLocalScanButton.ForeColor = Color.FromArgb(234, 234, 234);
            LoadLocalScanButton.Location = new Point(773, 4);
            LoadLocalScanButton.Name = "LoadLocalScanButton";
            LoadLocalScanButton.Size = new Size(148, 34);
            LoadLocalScanButton.TabIndex = 4;
            LoadLocalScanButton.Text = "Load Local Scan";
            LoadLocalScanButton.UseVisualStyleBackColor = false;
            LoadLocalScanButton.Click += LoadLocalScanButton_Click;
            // 
            // HunterIntel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(933, 519);
            Controls.Add(LoadLocalScanButton);
            Controls.Add(StatsPanel);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "HunterIntel";
            Text = "Hunter Intel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox SearchTextBox;
        private Objects.Custom_Controls.EveHelperButton SearchButton;
        private Panel StatsPanel;
        private Objects.Custom_Controls.EveHelperButton LoadLocalScanButton;
    }
}