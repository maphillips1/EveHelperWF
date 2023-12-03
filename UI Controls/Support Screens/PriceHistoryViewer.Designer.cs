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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceHistoryViewer));
            PriceHistoryForLabel = new Label();
            SelectedItemImagePanel = new Panel();
            GetImageBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            PriceHistoryGridView = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            Avg = new DataGridViewTextBoxColumn();
            Low = new DataGridViewTextBoxColumn();
            High = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            orderCount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).BeginInit();
            SuspendLayout();
            // 
            // PriceHistoryForLabel
            // 
            PriceHistoryForLabel.AutoSize = true;
            PriceHistoryForLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
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
            // PriceHistoryGridView
            // 
            PriceHistoryGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PriceHistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PriceHistoryGridView.BackgroundColor = Color.Black;
            PriceHistoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PriceHistoryGridView.Columns.AddRange(new DataGridViewColumn[] { date, Avg, Low, High, volume, orderCount });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            PriceHistoryGridView.DefaultCellStyle = dataGridViewCellStyle7;
            PriceHistoryGridView.GridColor = Color.Black;
            PriceHistoryGridView.Location = new Point(0, 90);
            PriceHistoryGridView.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryGridView.Name = "PriceHistoryGridView";
            PriceHistoryGridView.RowHeadersWidth = 51;
            PriceHistoryGridView.RowTemplate.Height = 29;
            PriceHistoryGridView.Size = new Size(984, 462);
            PriceHistoryGridView.TabIndex = 4;
            // 
            // date
            // 
            date.DataPropertyName = "date";
            dataGridViewCellStyle1.Padding = new Padding(2);
            date.DefaultCellStyle = dataGridViewCellStyle1;
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 56;
            // 
            // Avg
            // 
            Avg.DataPropertyName = "average";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.Padding = new Padding(2);
            Avg.DefaultCellStyle = dataGridViewCellStyle2;
            Avg.HeaderText = "avg";
            Avg.MinimumWidth = 6;
            Avg.Name = "Avg";
            Avg.Width = 51;
            // 
            // Low
            // 
            Low.DataPropertyName = "lowest";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.Padding = new Padding(2);
            Low.DefaultCellStyle = dataGridViewCellStyle3;
            Low.HeaderText = "low";
            Low.MinimumWidth = 6;
            Low.Name = "Low";
            Low.Width = 51;
            // 
            // High
            // 
            High.DataPropertyName = "highest";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.Padding = new Padding(2);
            High.DefaultCellStyle = dataGridViewCellStyle4;
            High.HeaderText = "high";
            High.MinimumWidth = 6;
            High.Name = "High";
            High.Width = 56;
            // 
            // volume
            // 
            volume.DataPropertyName = "volume";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.Padding = new Padding(2);
            volume.DefaultCellStyle = dataGridViewCellStyle5;
            volume.HeaderText = "Volume";
            volume.MinimumWidth = 6;
            volume.Name = "volume";
            volume.Width = 72;
            // 
            // orderCount
            // 
            orderCount.DataPropertyName = "order_count";
            dataGridViewCellStyle6.Padding = new Padding(2);
            orderCount.DefaultCellStyle = dataGridViewCellStyle6;
            orderCount.HeaderText = "Order Count";
            orderCount.MinimumWidth = 6;
            orderCount.Name = "orderCount";
            orderCount.Width = 98;
            // 
            // PriceHistoryViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(984, 552);
            Controls.Add(PriceHistoryGridView);
            Controls.Add(SelectedItemImagePanel);
            Controls.Add(PriceHistoryForLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PriceHistoryViewer";
            Text = "Price History";
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label PriceHistoryForLabel;
        private Panel SelectedItemImagePanel;
        private System.ComponentModel.BackgroundWorker GetImageBackgroundWorker;
        private DataGridView PriceHistoryGridView;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn Avg;
        private DataGridViewTextBoxColumn Low;
        private DataGridViewTextBoxColumn High;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn orderCount;
    }
}