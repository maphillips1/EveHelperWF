namespace EveHelperWF.Objects.Custom_Controls
{
    partial class PriceHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tabControl1 = new TabControl();
            tablePage = new TabPage();
            PriceHistoryGridView = new EveHelperGridView();
            date = new DataGridViewTextBoxColumn();
            Avg = new DataGridViewTextBoxColumn();
            Low = new DataGridViewTextBoxColumn();
            High = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            orderCount = new DataGridViewTextBoxColumn();
            GraphPage = new TabPage();
            PriceHistoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            DateRangeCombo = new ComboBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tablePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).BeginInit();
            GraphPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PriceHistoryChart).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CausesValidation = false;
            label1.Location = new Point(7, 13);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "Show Data For";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tablePage);
            tabControl1.Controls.Add(GraphPage);
            tabControl1.Location = new Point(0, 39);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(604, 411);
            tabControl1.TabIndex = 0;
            // 
            // tablePage
            // 
            tablePage.Controls.Add(PriceHistoryGridView);
            tablePage.Location = new Point(4, 24);
            tablePage.Name = "tablePage";
            tablePage.Padding = new Padding(3);
            tablePage.Size = new Size(596, 383);
            tablePage.TabIndex = 0;
            tablePage.Text = "Table";
            tablePage.UseVisualStyleBackColor = true;
            // 
            // PriceHistoryGridView
            // 
            PriceHistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PriceHistoryGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            PriceHistoryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            PriceHistoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PriceHistoryGridView.Columns.AddRange(new DataGridViewColumn[] { date, Avg, Low, High, volume, orderCount });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(15, 15, 15);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            PriceHistoryGridView.DefaultCellStyle = dataGridViewCellStyle3;
            PriceHistoryGridView.Dock = DockStyle.Fill;
            PriceHistoryGridView.EditableColumns = null;
            PriceHistoryGridView.GridColor = Color.FromArgb(21, 21, 21);
            PriceHistoryGridView.Location = new Point(3, 3);
            PriceHistoryGridView.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryGridView.Name = "PriceHistoryGridView";
            PriceHistoryGridView.RowHeadersWidth = 51;
            PriceHistoryGridView.RowTemplate.Height = 29;
            PriceHistoryGridView.Size = new Size(590, 377);
            PriceHistoryGridView.TabIndex = 6;
            // 
            // date
            // 
            date.DataPropertyName = "date";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(234, 234, 234);
            date.DefaultCellStyle = dataGridViewCellStyle2;
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 56;
            // 
            // Avg
            // 
            Avg.DataPropertyName = "average";
            Avg.HeaderText = "avg";
            Avg.MinimumWidth = 6;
            Avg.Name = "Avg";
            Avg.Width = 51;
            // 
            // Low
            // 
            Low.DataPropertyName = "lowest";
            Low.HeaderText = "low";
            Low.MinimumWidth = 6;
            Low.Name = "Low";
            Low.Width = 51;
            // 
            // High
            // 
            High.DataPropertyName = "highest";
            High.HeaderText = "high";
            High.MinimumWidth = 6;
            High.Name = "High";
            High.Width = 56;
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
            // GraphPage
            // 
            GraphPage.Controls.Add(PriceHistoryChart);
            GraphPage.Location = new Point(4, 24);
            GraphPage.Name = "GraphPage";
            GraphPage.Padding = new Padding(3);
            GraphPage.Size = new Size(596, 383);
            GraphPage.TabIndex = 1;
            GraphPage.Text = "Graph";
            GraphPage.UseVisualStyleBackColor = true;
            // 
            // PriceHistoryChart
            // 
            PriceHistoryChart.CausesValidation = false;
            chartArea1.Name = "ChartArea1";
            PriceHistoryChart.ChartAreas.Add(chartArea1);
            PriceHistoryChart.Dock = DockStyle.Fill;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            PriceHistoryChart.Legends.Add(legend1);
            PriceHistoryChart.Location = new Point(3, 3);
            PriceHistoryChart.Name = "PriceHistoryChart";
            PriceHistoryChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Average";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueMembers = "average";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Low";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "High";
            PriceHistoryChart.Series.Add(series1);
            PriceHistoryChart.Series.Add(series2);
            PriceHistoryChart.Series.Add(series3);
            PriceHistoryChart.Size = new Size(590, 377);
            PriceHistoryChart.SuppressExceptions = true;
            PriceHistoryChart.TabIndex = 0;
            PriceHistoryChart.Text = "chart1";
            // 
            // DateRangeCombo
            // 
            DateRangeCombo.FormattingEnabled = true;
            DateRangeCombo.Location = new Point(96, 10);
            DateRangeCombo.Name = "DateRangeCombo";
            DateRangeCombo.Size = new Size(121, 23);
            DateRangeCombo.TabIndex = 2;
            DateRangeCombo.SelectedIndexChanged += DateRangeCombo_SelectedIndexChanged;
            // 
            // PriceHistory
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(DateRangeCombo);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "PriceHistory";
            Size = new Size(607, 453);
            tabControl1.ResumeLayout(false);
            tablePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).EndInit();
            GraphPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PriceHistoryChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tablePage;
        private TabPage GraphPage;
        private EveHelperGridView PriceHistoryGridView;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn Avg;
        private DataGridViewTextBoxColumn Low;
        private DataGridViewTextBoxColumn High;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn orderCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart PriceHistoryChart;
        private ComboBox DateRangeCombo;
    }
}
