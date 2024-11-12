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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LootAppraisal));
            InputTextMultiLine = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ResultsGridView = new Objects.Custom_Controls.EveHelperGridView();
            typeName = new DataGridViewTextBoxColumn();
            typeID = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            sellPriceTotal = new DataGridViewTextBoxColumn();
            buyPriceTotal = new DataGridViewTextBoxColumn();
            sellPricePer = new DataGridViewTextBoxColumn();
            buyPricePer = new DataGridViewTextBoxColumn();
            AppraiseButton = new Objects.Custom_Controls.EveHelperButton();
            GetPricesWorker = new System.ComponentModel.BackgroundWorker();
            label3 = new Label();
            TotalBuyValueLabel = new Label();
            TotalSellValueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
            SuspendLayout();
            // 
            // InputTextMultiLine
            // 
            InputTextMultiLine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            InputTextMultiLine.BackColor = Color.WhiteSmoke;
            InputTextMultiLine.Location = new Point(10, 86);
            InputTextMultiLine.Margin = new Padding(3, 2, 3, 2);
            InputTextMultiLine.Multiline = true;
            InputTextMultiLine.Name = "InputTextMultiLine";
            InputTextMultiLine.Size = new Size(378, 349);
            InputTextMultiLine.TabIndex = 0;
            InputTextMultiLine.TextChanged += InputTextMultiLine_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(93, 58);
            label1.Name = "label1";
            label1.Size = new Size(153, 21);
            label1.TabIndex = 1;
            label1.Text = "Copy and Paste Here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(481, 7);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 3;
            label2.Text = "Sell Value";
            // 
            // ResultsGridView
            // 
            ResultsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ResultsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ResultsGridView.BackgroundColor = Color.Black;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ResultsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsGridView.Columns.AddRange(new DataGridViewColumn[] { typeName, typeID, quantity, sellPriceTotal, buyPriceTotal, sellPricePer, buyPricePer });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            ResultsGridView.DefaultCellStyle = dataGridViewCellStyle6;
            ResultsGridView.GridColor = Color.Black;
            ResultsGridView.Location = new Point(422, 86);
            ResultsGridView.Margin = new Padding(3, 2, 3, 2);
            ResultsGridView.Name = "ResultsGridView";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            ResultsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            ResultsGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = Color.Black;
            dataGridViewCellStyle8.ForeColor = Color.White;
            ResultsGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            ResultsGridView.RowTemplate.Height = 29;
            ResultsGridView.Size = new Size(719, 348);
            ResultsGridView.TabIndex = 4;
            // 
            // typeName
            // 
            typeName.DataPropertyName = "typeName";
            typeName.HeaderText = "Item Name";
            typeName.MinimumWidth = 6;
            typeName.Name = "typeName";
            typeName.Width = 91;
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
            quantity.Width = 78;
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
            sellPriceTotal.Width = 107;
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
            buyPriceTotal.Width = 109;
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
            sellPricePer.Width = 99;
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
            buyPricePer.Width = 101;
            // 
            // AppraiseButton
            // 
            AppraiseButton.ForeColor = Color.Black;
            AppraiseButton.Location = new Point(305, 59);
            AppraiseButton.Margin = new Padding(3, 2, 3, 2);
            AppraiseButton.Name = "AppraiseButton";
            AppraiseButton.Size = new Size(82, 22);
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
            label3.Location = new Point(481, 44);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 6;
            label3.Text = "Buy Value";
            // 
            // TotalBuyValueLabel
            // 
            TotalBuyValueLabel.AutoSize = true;
            TotalBuyValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TotalBuyValueLabel.Location = new Point(598, 44);
            TotalBuyValueLabel.Name = "TotalBuyValueLabel";
            TotalBuyValueLabel.Size = new Size(114, 21);
            TotalBuyValueLabel.TabIndex = 8;
            TotalBuyValueLabel.Text = "Total Buy Value";
            // 
            // TotalSellValueLabel
            // 
            TotalSellValueLabel.AutoSize = true;
            TotalSellValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TotalSellValueLabel.Location = new Point(598, 7);
            TotalSellValueLabel.Name = "TotalSellValueLabel";
            TotalSellValueLabel.Size = new Size(113, 21);
            TotalSellValueLabel.TabIndex = 7;
            TotalSellValueLabel.Text = "Total Sell Value";
            // 
            // LootAppraisal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 461);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Objects.Custom_Controls.EveHelperGridView ResultsGridView;
        private Objects.Custom_Controls.EveHelperButton AppraiseButton;
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