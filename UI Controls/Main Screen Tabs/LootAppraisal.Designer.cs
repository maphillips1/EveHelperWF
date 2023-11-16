namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class LootAppraisal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LootAppraisal));
            InputTextMultiLine = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ResultsGridView = new DataGridView();
            AppraiseButton = new Button();
            GetPricesWorker = new System.ComponentModel.BackgroundWorker();
            label3 = new Label();
            TotalBuyValueLabel = new Label();
            TotalSellValueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
            SuspendLayout();
            // 
            // InputTextMultiLine
            // 
            InputTextMultiLine.BackColor = Color.WhiteSmoke;
            InputTextMultiLine.Location = new Point(12, 114);
            InputTextMultiLine.Multiline = true;
            InputTextMultiLine.Name = "InputTextMultiLine";
            InputTextMultiLine.Size = new Size(431, 644);
            InputTextMultiLine.TabIndex = 0;
            InputTextMultiLine.TextChanged += InputTextMultiLine_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(106, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 28);
            label1.TabIndex = 1;
            label1.Text = "Copy and Paste Here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(550, 9);
            label2.Name = "label2";
            label2.Size = new Size(95, 28);
            label2.TabIndex = 3;
            label2.Text = "Sell Value";
            // 
            // ResultsGridView
            // 
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            ResultsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ResultsGridView.BackgroundColor = SystemColors.WindowFrame;
            ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ResultsGridView.DefaultCellStyle = dataGridViewCellStyle2;
            ResultsGridView.Location = new Point(550, 114);
            ResultsGridView.Name = "ResultsGridView";
            ResultsGridView.RowHeadersWidth = 51;
            ResultsGridView.RowTemplate.Height = 29;
            ResultsGridView.Size = new Size(756, 644);
            ResultsGridView.TabIndex = 4;
            // 
            // AppraiseButton
            // 
            AppraiseButton.ForeColor = Color.Black;
            AppraiseButton.Location = new Point(450, 395);
            AppraiseButton.Name = "AppraiseButton";
            AppraiseButton.Size = new Size(94, 29);
            AppraiseButton.TabIndex = 5;
            AppraiseButton.Text = "Appraise";
            AppraiseButton.UseVisualStyleBackColor = true;
            AppraiseButton.Click += AppraiseButton_Click;
            // 
            // GetPricesWorker
            // 
            GetPricesWorker.DoWork += GetPricesWorker_DoWork;
            GetPricesWorker.RunWorkerCompleted += GetPricesWorker_RunWorkerCompleted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(550, 59);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 6;
            label3.Text = "Buy Value";
            // 
            // TotalBuyValueLabel
            // 
            TotalBuyValueLabel.AutoSize = true;
            TotalBuyValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TotalBuyValueLabel.Location = new Point(683, 59);
            TotalBuyValueLabel.Name = "TotalBuyValueLabel";
            TotalBuyValueLabel.Size = new Size(143, 28);
            TotalBuyValueLabel.TabIndex = 8;
            TotalBuyValueLabel.Text = "Total Buy Value";
            // 
            // TotalSellValueLabel
            // 
            TotalSellValueLabel.AutoSize = true;
            TotalSellValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TotalSellValueLabel.Location = new Point(683, 9);
            TotalSellValueLabel.Name = "TotalSellValueLabel";
            TotalSellValueLabel.Size = new Size(142, 28);
            TotalSellValueLabel.TabIndex = 7;
            TotalSellValueLabel.Text = "Total Sell Value";
            // 
            // LootAppraisal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1318, 794);
            Controls.Add(TotalBuyValueLabel);
            Controls.Add(TotalSellValueLabel);
            Controls.Add(label3);
            Controls.Add(AppraiseButton);
            Controls.Add(ResultsGridView);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(InputTextMultiLine);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LootAppraisal";
            Text = "Loot Appraisal";
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputTextMultiLine;
        private Label label1;
        private Label label2;
        private DataGridView ResultsGridView;
        private Button AppraiseButton;
        private System.ComponentModel.BackgroundWorker GetPricesWorker;
        private Label label3;
        private Label TotalBuyValueLabel;
        private Label TotalSellValueLabel;
    }
}