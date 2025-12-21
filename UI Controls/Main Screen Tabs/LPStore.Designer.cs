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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LPStore));
            NPCCorpCombo = new ComboBox();
            LPOfferGridView = new EveHelperWF.Objects.Custom_Controls.EveHelperGridView();
            SearchTextBox = new TextBox();
            SearchButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            InfoLoadingLabel = new Label();
            GetMarketDataPriceWorker = new System.ComponentModel.BackgroundWorker();
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
            LPOfferGridView.AllowUserToOrderColumns = true;
            LPOfferGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LPOfferGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LPOfferGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LPOfferGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            LPOfferGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Gold;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            LPOfferGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            LPOfferGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LPOfferGridView.Columns.AddRange(new DataGridViewColumn[] { AKCost, IskCost, LPCost, ItemName, Quantity, buyvalue, sellvalue, RequiredItems, ProfitBuy, ProfitSell, IskLpBuy, IskLpSell });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.Black;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            LPOfferGridView.DefaultCellStyle = dataGridViewCellStyle8;
            LPOfferGridView.EditableColumns = null;
            LPOfferGridView.EnableHeadersVisualStyles = false;
            LPOfferGridView.GridColor = Color.FromArgb(21, 21, 21);
            LPOfferGridView.Location = new Point(0, 108);
            LPOfferGridView.Margin = new Padding(3, 2, 3, 2);
            LPOfferGridView.Name = "LPOfferGridView";
            LPOfferGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            LPOfferGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            LPOfferGridView.RowHeadersWidth = 51;
            LPOfferGridView.RowTemplate.Height = 29;
            LPOfferGridView.Size = new Size(933, 411);
            LPOfferGridView.TabIndex = 5;
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
            SearchButton.BorderBottom = false;
            SearchButton.BorderFull = true;
            SearchButton.BorderLeft = false;
            SearchButton.BorderRight = false;
            SearchButton.BorderTop = false;
            SearchButton.BorderWidth = 2F;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.FromArgb(234, 234, 234);
            SearchButton.Location = new Point(342, 80);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 8;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
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
            // GetMarketDataPriceWorker
            // 
            GetMarketDataPriceWorker.WorkerSupportsCancellation = true;
            GetMarketDataPriceWorker.DoWork += GetMarketDataPriceWorker_DoWork;
            GetMarketDataPriceWorker.RunWorkerCompleted += GetMarketDataPriceWorker_RunWorkerCompleted;
            // 
            // AKCost
            // 
            AKCost.DataPropertyName = "ak_cost";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            AKCost.DefaultCellStyle = dataGridViewCellStyle2;
            AKCost.HeaderText = "AK Cost";
            AKCost.Name = "AKCost";
            AKCost.ReadOnly = true;
            AKCost.SortMode = DataGridViewColumnSortMode.Programmatic;
            AKCost.Width = 72;
            // 
            // IskCost
            // 
            IskCost.DataPropertyName = "formattedIskCost";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            IskCost.DefaultCellStyle = dataGridViewCellStyle3;
            IskCost.HeaderText = "Isk Cost";
            IskCost.Name = "IskCost";
            IskCost.ReadOnly = true;
            IskCost.SortMode = DataGridViewColumnSortMode.Programmatic;
            IskCost.Width = 71;
            // 
            // LPCost
            // 
            LPCost.DataPropertyName = "lp_cost";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            LPCost.DefaultCellStyle = dataGridViewCellStyle4;
            LPCost.HeaderText = "LP Cost";
            LPCost.Name = "LPCost";
            LPCost.ReadOnly = true;
            LPCost.SortMode = DataGridViewColumnSortMode.Programmatic;
            LPCost.Width = 70;
            // 
            // ItemName
            // 
            ItemName.DataPropertyName = "typeName";
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            ItemName.DefaultCellStyle = dataGridViewCellStyle5;
            ItemName.HeaderText = "Item Name";
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            ItemName.Width = 89;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            Quantity.DefaultCellStyle = dataGridViewCellStyle6;
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            Quantity.Width = 76;
            // 
            // buyvalue
            // 
            buyvalue.DataPropertyName = "totalBuyValue";
            buyvalue.HeaderText = "Buy Value";
            buyvalue.Name = "buyvalue";
            buyvalue.Width = 81;
            // 
            // sellvalue
            // 
            sellvalue.DataPropertyName = "totalSellValue";
            sellvalue.HeaderText = "Sell Value";
            sellvalue.Name = "sellvalue";
            sellvalue.Width = 79;
            // 
            // RequiredItems
            // 
            RequiredItems.DataPropertyName = "requiredItemsString";
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            RequiredItems.DefaultCellStyle = dataGridViewCellStyle7;
            RequiredItems.HeaderText = "Required Items";
            RequiredItems.Name = "RequiredItems";
            RequiredItems.ReadOnly = true;
            RequiredItems.SortMode = DataGridViewColumnSortMode.Programmatic;
            RequiredItems.Width = 109;
            // 
            // ProfitBuy
            // 
            ProfitBuy.DataPropertyName = "ProfitBuyString";
            ProfitBuy.HeaderText = "Profit Buy";
            ProfitBuy.Name = "ProfitBuy";
            ProfitBuy.Width = 82;
            // 
            // ProfitSell
            // 
            ProfitSell.DataPropertyName = "ProfitSellString";
            ProfitSell.HeaderText = "Profit Sell";
            ProfitSell.Name = "ProfitSell";
            ProfitSell.Width = 80;
            // 
            // IskLpBuy
            // 
            IskLpBuy.DataPropertyName = "IskLpBuy";
            IskLpBuy.HeaderText = "Isk / LP (Buy)";
            IskLpBuy.Name = "IskLpBuy";
            IskLpBuy.Width = 99;
            // 
            // IskLpSell
            // 
            IskLpSell.DataPropertyName = "IskLpSell";
            IskLpSell.HeaderText = "Isk / LP (Sell)";
            IskLpSell.Name = "IskLpSell";
            IskLpSell.Width = 97;
            // 
            // LPStore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
        private Objects.Custom_Controls.EveHelperGridView LPOfferGridView;
        private TextBox SearchTextBox;
        private Objects.Custom_Controls.EveHelperButton SearchButton;
        private Label InfoLoadingLabel;
        private System.ComponentModel.BackgroundWorker GetMarketDataPriceWorker;
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