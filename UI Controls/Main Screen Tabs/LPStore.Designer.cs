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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            NPCCorpCombo = new ComboBox();
            LPOfferGridView = new DataGridView();
            AKCost = new DataGridViewTextBoxColumn();
            IskCost = new DataGridViewTextBoxColumn();
            LPCost = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            RequiredItems = new DataGridViewTextBoxColumn();
            HiddenOfferId = new DataGridViewTextBoxColumn();
            hidden_isk_cost = new DataGridViewTextBoxColumn();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
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
            LPOfferGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LPOfferGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LPOfferGridView.BackgroundColor = Color.Black;
            LPOfferGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LPOfferGridView.Columns.AddRange(new DataGridViewColumn[] { AKCost, IskCost, LPCost, ItemName, Quantity, RequiredItems, HiddenOfferId, hidden_isk_cost });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            LPOfferGridView.DefaultCellStyle = dataGridViewCellStyle4;
            LPOfferGridView.Dock = DockStyle.Bottom;
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
            AKCost.DefaultCellStyle = dataGridViewCellStyle1;
            AKCost.HeaderText = "AK Cost";
            AKCost.Name = "AKCost";
            AKCost.ReadOnly = true;
            AKCost.Width = 74;
            // 
            // IskCost
            // 
            IskCost.DataPropertyName = "formattedIskCost";
            IskCost.HeaderText = "Isk Cost";
            IskCost.Name = "IskCost";
            IskCost.ReadOnly = true;
            IskCost.Width = 73;
            // 
            // LPCost
            // 
            LPCost.DataPropertyName = "lp_cost";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            LPCost.DefaultCellStyle = dataGridViewCellStyle2;
            LPCost.HeaderText = "LP Cost";
            LPCost.Name = "LPCost";
            LPCost.ReadOnly = true;
            LPCost.Width = 72;
            // 
            // ItemName
            // 
            ItemName.DataPropertyName = "typeName";
            ItemName.HeaderText = "Item Name";
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            ItemName.Width = 91;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 78;
            // 
            // RequiredItems
            // 
            RequiredItems.DataPropertyName = "requiredItemsString";
            RequiredItems.HeaderText = "Required Items";
            RequiredItems.Name = "RequiredItems";
            RequiredItems.ReadOnly = true;
            RequiredItems.Width = 111;
            // 
            // HiddenOfferId
            // 
            HiddenOfferId.DataPropertyName = "offer_id";
            HiddenOfferId.HeaderText = "Hidden Offer Id";
            HiddenOfferId.Name = "HiddenOfferId";
            HiddenOfferId.ReadOnly = true;
            HiddenOfferId.Visible = false;
            HiddenOfferId.Width = 114;
            // 
            // hidden_isk_cost
            // 
            hidden_isk_cost.DataPropertyName = "isk_cost";
            hidden_isk_cost.HeaderText = "hidden isk cost";
            hidden_isk_cost.Name = "hidden_isk_cost";
            hidden_isk_cost.ReadOnly = true;
            hidden_isk_cost.Visible = false;
            hidden_isk_cost.Width = 111;
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
            // LPStore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label2);
            Controls.Add(LPOfferGridView);
            Controls.Add(NPCCorpCombo);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "LPStore";
            Text = "LPStore";
            ((System.ComponentModel.ISupportInitialize)LPOfferGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox NPCCorpCombo;
        private DataGridView LPOfferGridView;
        private DataGridViewTextBoxColumn AKCost;
        private DataGridViewTextBoxColumn IskCost;
        private DataGridViewTextBoxColumn LPCost;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn RequiredItems;
        private DataGridViewTextBoxColumn HiddenOfferId;
        private DataGridViewTextBoxColumn hidden_isk_cost;
        private TextBox SearchTextBox;
        private Button SearchButton;
    }
}