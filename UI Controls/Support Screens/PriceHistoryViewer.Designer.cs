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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceHistoryViewer));
            PriceHistoryGridView = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            formattedAverage = new DataGridViewTextBoxColumn();
            formattedLowest = new DataGridViewTextBoxColumn();
            formattedHighest = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            orderCount = new DataGridViewTextBoxColumn();
            average = new DataGridViewTextBoxColumn();
            highest = new DataGridViewTextBoxColumn();
            lowest = new DataGridViewTextBoxColumn();
            PriceHistoryForLabel = new Label();
            SelectedItemImagePanel = new Panel();
            GetImageBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).BeginInit();
            SuspendLayout();
            // 
            // PriceHistoryGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            PriceHistoryGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            PriceHistoryGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PriceHistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PriceHistoryGridView.BackgroundColor = Color.Black;
            PriceHistoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PriceHistoryGridView.Columns.AddRange(new DataGridViewColumn[] { date, formattedAverage, formattedLowest, formattedHighest, volume, orderCount, average, highest, lowest });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            PriceHistoryGridView.DefaultCellStyle = dataGridViewCellStyle2;
            PriceHistoryGridView.GridColor = Color.Black;
            PriceHistoryGridView.Location = new Point(0, 70);
            PriceHistoryGridView.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryGridView.Name = "PriceHistoryGridView";
            PriceHistoryGridView.RowHeadersWidth = 51;
            PriceHistoryGridView.RowTemplate.Height = 29;
            PriceHistoryGridView.Size = new Size(984, 482);
            PriceHistoryGridView.TabIndex = 1;
            // 
            // date
            // 
            date.DataPropertyName = "date";
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 56;
            // 
            // formattedAverage
            // 
            formattedAverage.DataPropertyName = "formattedAverage";
            formattedAverage.HeaderText = "Average";
            formattedAverage.MinimumWidth = 6;
            formattedAverage.Name = "formattedAverage";
            formattedAverage.Width = 75;
            // 
            // formattedLowest
            // 
            formattedLowest.DataPropertyName = "formattedLowest";
            formattedLowest.HeaderText = "Lowest";
            formattedLowest.MinimumWidth = 6;
            formattedLowest.Name = "formattedLowest";
            formattedLowest.Width = 69;
            // 
            // formattedHighest
            // 
            formattedHighest.DataPropertyName = "formattedHighest";
            formattedHighest.HeaderText = "Highest";
            formattedHighest.MinimumWidth = 6;
            formattedHighest.Name = "formattedHighest";
            formattedHighest.Width = 73;
            // 
            // volume
            // 
            volume.DataPropertyName = "volume";
            volume.HeaderText = "Volume";
            volume.MinimumWidth = 6;
            volume.Name = "volume";
            volume.Width = 72;
            // 
            // orderCount
            // 
            orderCount.DataPropertyName = "order_count";
            orderCount.HeaderText = "Order Count";
            orderCount.MinimumWidth = 6;
            orderCount.Name = "orderCount";
            orderCount.Width = 98;
            // 
            // average
            // 
            average.DataPropertyName = "average";
            average.HeaderText = "avg";
            average.MinimumWidth = 6;
            average.Name = "average";
            average.Visible = false;
            average.Width = 62;
            // 
            // highest
            // 
            highest.DataPropertyName = "highest";
            highest.HeaderText = "high";
            highest.MinimumWidth = 6;
            highest.Name = "highest";
            highest.Visible = false;
            highest.Width = 67;
            // 
            // lowest
            // 
            lowest.DataPropertyName = "lowest";
            lowest.HeaderText = "low";
            lowest.MinimumWidth = 6;
            lowest.Name = "lowest";
            lowest.Visible = false;
            lowest.Width = 62;
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
            // PriceHistoryViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(984, 552);
            Controls.Add(SelectedItemImagePanel);
            Controls.Add(PriceHistoryForLabel);
            Controls.Add(PriceHistoryGridView);
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

        private DataGridView PriceHistoryGridView;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn formattedAverage;
        private DataGridViewTextBoxColumn formattedLowest;
        private DataGridViewTextBoxColumn formattedHighest;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn orderCount;
        private DataGridViewTextBoxColumn average;
        private DataGridViewTextBoxColumn highest;
        private DataGridViewTextBoxColumn lowest;
        private Label PriceHistoryForLabel;
        private Panel SelectedItemImagePanel;
        private System.ComponentModel.BackgroundWorker GetImageBackgroundWorker;
    }
}