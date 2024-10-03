namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class LPStore
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
            Label label1;
            Label label2;
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LPStore));
            NPCCorpCombo = new ComboBox();
            LPOfferGridView = new DataGridView();
            AKCost = new DataGridViewTextBoxColumn();
            IskCost = new DataGridViewTextBoxColumn();
            LPCost = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            buyvalue = new DataGridViewTextBoxColumn();
            sellvalue = new DataGridViewTextBoxColumn();
            RequiredItems = new DataGridViewTextBoxColumn();
            ProfitBuy = new DataGridViewTextBoxColumn();
            ProfitSell = new DataGridViewTextBoxColumn();
            IskLpBuy = new DataGridViewTextBoxColumn();
            IskLpSell = new DataGridViewTextBoxColumn();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            InfoLoadingLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)LPOfferGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 0;
            label1.Text = "Select Corporation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 6;
            label2.Text = "Search Text : ";
            // 
            // NPCCorpCombo
            // 
            NPCCorpCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            NPCCorpCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            NPCCorpCombo.DropDownHeight = 150;
            NPCCorpCombo.FormattingEnabled = true;
            NPCCorpCombo.IntegralHeight = false;
            NPCCorpCombo.Location = new Point(196, 14);
            NPCCorpCombo.MaxDropDownItems = 15;
            NPCCorpCombo.Name = "NPCCorpCombo";
            NPCCorpCombo.Size = new Size(316, 23);
            NPCCorpCombo.TabIndex = 1;
            NPCCorpCombo.SelectedIndexChanged += NPCCorpCombo_SelectedIndexChanged;
            // 
            // LPOfferGridView
            // 
            LPOfferGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LPOfferGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LPOfferGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LPOfferGridView.BackgroundColor = Color.Black;
            LPOfferGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LPOfferGridView.Columns.AddRange(new DataGridViewColumn[] { AKCost, IskCost, LPCost, ItemName, Quantity, buyvalue, sellvalue, RequiredItems, ProfitBuy, ProfitSell, IskLpBuy, IskLpSell });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            LPOfferGridView.DefaultCellStyle = dataGridViewCellStyle7;
            LPOfferGridView.GridColor = Color.Black;
            LPOfferGridView.Location = new Point(0, 108);
            LPOfferGridView.Margin = new Padding(3, 2, 3, 2);
            LPOfferGridView.Name = "LPOfferGridView";
            LPOfferGridView.RowHeadersWidth = 51;
            LPOfferGridView.RowTemplate.Height = 29;
            LPOfferGridView.Size = new Size(933, 411);
            LPOfferGridView.TabIndex = 5;
            // 
            // AKCost
            // 
            AKCost.DataPropertyName = "ak_cost";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            AKCost.DefaultCellStyle = dataGridViewCellStyle1;
            AKCost.HeaderText = "AK Cost";
            AKCost.Name = "AKCost";
            AKCost.ReadOnly = true;
            AKCost.SortMode = DataGridViewColumnSortMode.Programmatic;
            AKCost.Width = 74;
            // 
            // IskCost
            // 
            IskCost.DataPropertyName = "formattedIskCost";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            IskCost.DefaultCellStyle = dataGridViewCellStyle2;
            IskCost.HeaderText = "Isk Cost";
            IskCost.Name = "IskCost";
            IskCost.ReadOnly = true;
            IskCost.SortMode = DataGridViewColumnSortMode.Programmatic;
            IskCost.Width = 73;
            // 
            // LPCost
            // 
            LPCost.DataPropertyName = "lp_cost";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            LPCost.DefaultCellStyle = dataGridViewCellStyle3;
            LPCost.HeaderText = "LP Cost";
            LPCost.Name = "LPCost";
            LPCost.ReadOnly = true;
            LPCost.SortMode = DataGridViewColumnSortMode.Programmatic;
            LPCost.Width = 72;
            // 
            // ItemName
            // 
            ItemName.DataPropertyName = "typeName";
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            ItemName.DefaultCellStyle = dataGridViewCellStyle4;
            ItemName.HeaderText = "Item Name";
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            ItemName.SortMode = DataGridViewColumnSortMode.Programmatic;
            ItemName.Width = 91;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            Quantity.DefaultCellStyle = dataGridViewCellStyle5;
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            Quantity.Width = 78;
            // 
            // buyvalue
            // 
            buyvalue.DataPropertyName = "totalBuyValue";
            buyvalue.HeaderText = "Buy Value";
            buyvalue.Name = "buyvalue";
            buyvalue.Width = 83;
            // 
            // sellvalue
            // 
            sellvalue.DataPropertyName = "totalSellValue";
            sellvalue.HeaderText = "Sell Value";
            sellvalue.Name = "sellvalue";
            sellvalue.Width = 81;
            // 
            // RequiredItems
            // 
            RequiredItems.DataPropertyName = "requiredItemsString";
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            RequiredItems.DefaultCellStyle = dataGridViewCellStyle6;
            RequiredItems.HeaderText = "Required Items";
            RequiredItems.Name = "RequiredItems";
            RequiredItems.ReadOnly = true;
            RequiredItems.SortMode = DataGridViewColumnSortMode.Programmatic;
            RequiredItems.Width = 111;
            // 
            // ProfitBuy
            // 
            ProfitBuy.DataPropertyName = "ProfitBuyString";
            ProfitBuy.HeaderText = "Profit Buy";
            ProfitBuy.Name = "ProfitBuy";
            ProfitBuy.Width = 84;
            // 
            // ProfitSell
            // 
            ProfitSell.DataPropertyName = "ProfitSellString";
            ProfitSell.HeaderText = "Profit Sell";
            ProfitSell.Name = "ProfitSell";
            ProfitSell.Width = 82;
            // 
            // IskLpBuy
            // 
            IskLpBuy.DataPropertyName = "IskLpBuy";
            IskLpBuy.HeaderText = "Isk / LP (Buy)";
            IskLpBuy.Name = "IskLpBuy";
            IskLpBuy.Width = 101;
            // 
            // IskLpSell
            // 
            IskLpSell.DataPropertyName = "IskLpSell";
            IskLpSell.HeaderText = "Isk / LP (Sell)";
            IskLpSell.Name = "IskLpSell";
            IskLpSell.Width = 99;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(113, 80);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(223, 23);
            SearchTextBox.TabIndex = 7;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;
            // 
            // SearchButton
            // 
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(342, 80);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 8;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // InfoLoadingLabel
            // 
            InfoLoadingLabel.AutoSize = true;
            InfoLoadingLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InfoLoadingLabel.Location = new Point(605, 81);
            InfoLoadingLabel.Name = "InfoLoadingLabel";
            InfoLoadingLabel.Size = new Size(316, 20);
            InfoLoadingLabel.TabIndex = 9;
            InfoLoadingLabel.Text = "Information is Loading. This may take a while...";
            // 
            // LPStore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(InfoLoadingLabel);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label2);
            Controls.Add(LPOfferGridView);
            Controls.Add(NPCCorpCombo);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LPStore";
            Text = "LPStore";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)LPOfferGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox NPCCorpCombo;
        private DataGridView LPOfferGridView;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Label InfoLoadingLabel;
        private DataGridViewTextBoxColumn AKCost;
        private DataGridViewTextBoxColumn IskCost;
        private DataGridViewTextBoxColumn LPCost;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn buyvalue;
        private DataGridViewTextBoxColumn sellvalue;
        private DataGridViewTextBoxColumn RequiredItems;
        private DataGridViewTextBoxColumn ProfitBuy;
        private DataGridViewTextBoxColumn ProfitSell;
        private DataGridViewTextBoxColumn IskLpBuy;
        private DataGridViewTextBoxColumn IskLpSell;
    }
}