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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
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
            typeName = new DataGridViewTextBoxColumn();
            typeID = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            sellPriceTotal = new DataGridViewTextBoxColumn();
            buyPriceTotal = new DataGridViewTextBoxColumn();
            sellPricePer = new DataGridViewTextBoxColumn();
            buyPricePer = new DataGridViewTextBoxColumn();
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
            ResultsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ResultsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ResultsGridView.BackgroundColor = SystemColors.WindowFrame;
            ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsGridView.Columns.AddRange(new DataGridViewColumn[] { typeName, typeID, quantity, sellPriceTotal, buyPriceTotal, sellPricePer, buyPricePer });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            ResultsGridView.DefaultCellStyle = dataGridViewCellStyle6;
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
            // typeName
            // 
            typeName.DataPropertyName = "typeName";
            typeName.HeaderText = "Item Name";
            typeName.MinimumWidth = 6;
            typeName.Name = "typeName";
            typeName.Width = 103;
            // 
            // typeID
            // 
            typeID.DataPropertyName = "typeID";
            typeID.HeaderText = "typeID";
            typeID.MinimumWidth = 6;
            typeID.Name = "typeID";
            typeID.Visible = false;
            typeID.Width = 125;
            // 
            // quantity
            // 
            quantity.DataPropertyName = "quantity";
            quantity.HeaderText = "Quantity";
            quantity.MinimumWidth = 6;
            quantity.Name = "quantity";
            quantity.Width = 94;
            // 
            // sellPriceTotal
            // 
            sellPriceTotal.DataPropertyName = "sellPriceTotal";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            sellPriceTotal.DefaultCellStyle = dataGridViewCellStyle2;
            sellPriceTotal.HeaderText = "Sell Price Total";
            sellPriceTotal.MinimumWidth = 6;
            sellPriceTotal.Name = "sellPriceTotal";
            sellPriceTotal.Width = 124;
            // 
            // buyPriceTotal
            // 
            buyPriceTotal.DataPropertyName = "buyPriceTotal";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            buyPriceTotal.DefaultCellStyle = dataGridViewCellStyle3;
            buyPriceTotal.HeaderText = "Buy Price Total";
            buyPriceTotal.MinimumWidth = 6;
            buyPriceTotal.Name = "buyPriceTotal";
            buyPriceTotal.Width = 124;
            // 
            // sellPricePer
            // 
            sellPricePer.DataPropertyName = "sellPricePer";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0.00";
            sellPricePer.DefaultCellStyle = dataGridViewCellStyle4;
            sellPricePer.HeaderText = "Sell Price Per";
            sellPricePer.MinimumWidth = 6;
            sellPricePer.Name = "sellPricePer";
            sellPricePer.Width = 94;
            // 
            // buyPricePer
            // 
            buyPricePer.DataPropertyName = "buyPricePer";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            buyPricePer.DefaultCellStyle = dataGridViewCellStyle5;
            buyPricePer.HeaderText = "Buy Price Per";
            buyPricePer.MinimumWidth = 6;
            buyPricePer.Name = "buyPricePer";
            buyPricePer.Width = 94;
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
        private DataGridViewTextBoxColumn typeName;
        private DataGridViewTextBoxColumn typeID;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn sellPriceTotal;
        private DataGridViewTextBoxColumn buyPriceTotal;
        private DataGridViewTextBoxColumn sellPricePer;
        private DataGridViewTextBoxColumn buyPricePer;
    }
}