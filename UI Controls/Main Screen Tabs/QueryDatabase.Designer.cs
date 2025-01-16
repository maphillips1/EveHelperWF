namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class QueryDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryDatabase));
            QueryPanel = new Panel();
            eveHelperButton2 = new Objects.Custom_Controls.EveHelperButton();
            RunQueryButton = new Objects.Custom_Controls.EveHelperButton();
            label1 = new Label();
            QueryTextBox = new TextBox();
            ResultPanel = new Panel();
            ResultsGridView = new DataGridView();
            QueryPanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
            SuspendLayout();
            // 
            // QueryPanel
            // 
            QueryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            QueryPanel.Controls.Add(eveHelperButton2);
            QueryPanel.Controls.Add(RunQueryButton);
            QueryPanel.Controls.Add(label1);
            QueryPanel.Controls.Add(QueryTextBox);
            QueryPanel.Location = new Point(-1, 2);
            QueryPanel.Name = "QueryPanel";
            QueryPanel.Size = new Size(435, 520);
            QueryPanel.TabIndex = 0;
            // 
            // eveHelperButton2
            // 
            eveHelperButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            eveHelperButton2.ForeColor = Color.FromArgb(234, 234, 234);
            eveHelperButton2.Location = new Point(3, 447);
            eveHelperButton2.Name = "eveHelperButton2";
            eveHelperButton2.Size = new Size(123, 58);
            eveHelperButton2.TabIndex = 4;
            eveHelperButton2.Text = "Database Schema";
            eveHelperButton2.UseVisualStyleBackColor = false;
            eveHelperButton2.Click += eveHelperButton2_Click;
            // 
            // RunQueryButton
            // 
            RunQueryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RunQueryButton.ForeColor = Color.FromArgb(234, 234, 234);
            RunQueryButton.Location = new Point(309, 447);
            RunQueryButton.Name = "RunQueryButton";
            RunQueryButton.Size = new Size(123, 58);
            RunQueryButton.TabIndex = 2;
            RunQueryButton.Text = "Execute Query";
            RunQueryButton.UseVisualStyleBackColor = false;
            RunQueryButton.Click += RunQueryButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 7);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Query";
            // 
            // QueryTextBox
            // 
            QueryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            QueryTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            QueryTextBox.Location = new Point(3, 37);
            QueryTextBox.Multiline = true;
            QueryTextBox.Name = "QueryTextBox";
            QueryTextBox.Size = new Size(429, 404);
            QueryTextBox.TabIndex = 0;
            QueryTextBox.TabStop = false;
            QueryTextBox.KeyDown += QueryTextBox_KeyDown;
            // 
            // ResultPanel
            // 
            ResultPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultPanel.Controls.Add(ResultsGridView);
            ResultPanel.Location = new Point(440, 2);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(490, 520);
            ResultPanel.TabIndex = 1;
            // 
            // ResultsGridView
            // 
            ResultsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultsGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsGridView.GridColor = Color.FromArgb(21, 21, 21);
            ResultsGridView.Location = new Point(3, 7);
            ResultsGridView.Name = "ResultsGridView";
            ResultsGridView.Size = new Size(484, 498);
            ResultsGridView.TabIndex = 0;
            // 
            // QueryDatabase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(ResultPanel);
            Controls.Add(QueryPanel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "QueryDatabase";
            Text = "Query Database";
            QueryPanel.ResumeLayout(false);
            QueryPanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel QueryPanel;
        private Panel ResultPanel;
        private Label label1;
        private TextBox QueryTextBox;
        private DataGridView ResultsGridView;
        private Objects.Custom_Controls.EveHelperButton RunQueryButton;
        private Objects.Custom_Controls.EveHelperButton eveHelperButton2;
    }
}