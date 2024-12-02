namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class PriceHistoryViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceHistoryViewer));
            PriceHistoryForLabel = new Label();
            SelectedItemImagePanel = new Panel();
            GetImageBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            PriceHistoryControl = new Objects.Custom_Controls.PriceHistory();
            SuspendLayout();
            // 
            // PriceHistoryForLabel
            // 
            PriceHistoryForLabel.AutoSize = true;
            PriceHistoryForLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            PriceHistoryForLabel.ForeColor = Color.Gold;
            PriceHistoryForLabel.Location = new Point(72, 7);
            PriceHistoryForLabel.Name = "PriceHistoryForLabel";
            PriceHistoryForLabel.Size = new Size(140, 21);
            PriceHistoryForLabel.TabIndex = 2;
            PriceHistoryForLabel.Text = "Price History For ";
            // 
            // SelectedItemImagePanel
            // 
            SelectedItemImagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            SelectedItemImagePanel.Location = new Point(10, 9);
            SelectedItemImagePanel.Margin = new Padding(3, 2, 3, 2);
            SelectedItemImagePanel.Name = "SelectedItemImagePanel";
            SelectedItemImagePanel.Size = new Size(56, 48);
            SelectedItemImagePanel.TabIndex = 3;
            // 
            // GetImageBackgroundWorker
            // 
            GetImageBackgroundWorker.DoWork += GetImageBackgroundWorker_DoWork;
            GetImageBackgroundWorker.RunWorkerCompleted += GetImageBackgroundWorker_RunWorkerCompleted;
            // 
            // PriceHistoryControl
            // 
            PriceHistoryControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PriceHistoryControl.AutoScroll = true;
            PriceHistoryControl.AutoSize = true;
            PriceHistoryControl.BackColor = Color.FromArgb(21, 21, 21);
            PriceHistoryControl.ForeColor = Color.FromArgb(234, 234, 234);
            PriceHistoryControl.Location = new Point(-1, 62);
            PriceHistoryControl.Name = "PriceHistoryControl";
            PriceHistoryControl.Size = new Size(984, 490);
            PriceHistoryControl.TabIndex = 4;
            // 
            // PriceHistoryViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(984, 552);
            Controls.Add(PriceHistoryControl);
            Controls.Add(SelectedItemImagePanel);
            Controls.Add(PriceHistoryForLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PriceHistoryViewer";
            Text = "Price History";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label PriceHistoryForLabel;
        private Panel SelectedItemImagePanel;
        private System.ComponentModel.BackgroundWorker GetImageBackgroundWorker;
        private Objects.Custom_Controls.PriceHistory PriceHistoryControl;
    }
}