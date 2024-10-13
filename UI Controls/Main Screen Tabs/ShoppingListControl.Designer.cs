namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class ShoppingListControl
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingListControl));
            label1 = new Label();
            ShoppingListCombo = new ComboBox();
            NewListButton = new Button();
            DeleteListButton = new Button();
            ItemSearchResultsGrid = new DataGridView();
            typeID = new DataGridViewTextBoxColumn();
            typeName = new DataGridViewTextBoxColumn();
            marketGroupName = new DataGridViewTextBoxColumn();
            groupId = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            portionSize = new DataGridViewTextBoxColumn();
            raceId = new DataGridViewTextBoxColumn();
            basePrice = new DataGridViewTextBoxColumn();
            marketGroupId = new DataGridViewTextBoxColumn();
            parentMarketGroupId = new DataGridViewTextBoxColumn();
            iconId = new DataGridViewTextBoxColumn();
            soundId = new DataGridViewTextBoxColumn();
            graphicId = new DataGridViewTextBoxColumn();
            groupName = new DataGridViewTextBoxColumn();
            categoryID = new DataGridViewTextBoxColumn();
            categoryName = new DataGridViewTextBoxColumn();
            SearchButton = new Button();
            ItemSearchTextBox = new TextBox();
            label2 = new Label();
            AddItemsButton = new Button();
            label3 = new Label();
            CopyToClipboardButton = new Button();
            label4 = new Label();
            ShoppingListGrid = new DataGridView();
            Bought = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            BoughtAtPrice = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ItemSearchResultsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShoppingListGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 17);
            label1.TabIndex = 0;
            label1.Text = "Shopping List: ";
            // 
            // ShoppingListCombo
            // 
            ShoppingListCombo.DropDownHeight = 150;
            ShoppingListCombo.FormattingEnabled = true;
            ShoppingListCombo.IntegralHeight = false;
            ShoppingListCombo.Location = new Point(119, 8);
            ShoppingListCombo.Name = "ShoppingListCombo";
            ShoppingListCombo.Size = new Size(242, 23);
            ShoppingListCombo.TabIndex = 1;
            ShoppingListCombo.SelectedIndexChanged += ShoppinglListCombo_SelectedIndexChanged;
            // 
            // NewListButton
            // 
            NewListButton.ForeColor = Color.Black;
            NewListButton.Location = new Point(119, 37);
            NewListButton.Name = "NewListButton";
            NewListButton.Size = new Size(118, 23);
            NewListButton.TabIndex = 2;
            NewListButton.Text = "New Shopping List";
            NewListButton.UseVisualStyleBackColor = true;
            NewListButton.Click += NewListButton_Click;
            // 
            // DeleteListButton
            // 
            DeleteListButton.ForeColor = Color.Black;
            DeleteListButton.Location = new Point(243, 37);
            DeleteListButton.Name = "DeleteListButton";
            DeleteListButton.Size = new Size(118, 23);
            DeleteListButton.TabIndex = 3;
            DeleteListButton.Text = "Delete List";
            DeleteListButton.UseVisualStyleBackColor = true;
            DeleteListButton.Click += DeleteListButton_Click;
            // 
            // ItemSearchResultsGrid
            // 
            ItemSearchResultsGrid.AllowUserToAddRows = false;
            ItemSearchResultsGrid.AllowUserToDeleteRows = false;
            ItemSearchResultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ItemSearchResultsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ItemSearchResultsGrid.BackgroundColor = Color.Black;
            ItemSearchResultsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemSearchResultsGrid.Columns.AddRange(new DataGridViewColumn[] { typeID, typeName, marketGroupName, groupId, description, volume, portionSize, raceId, basePrice, marketGroupId, parentMarketGroupId, iconId, soundId, graphicId, groupName, categoryID, categoryName });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            ItemSearchResultsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            ItemSearchResultsGrid.GridColor = Color.Black;
            ItemSearchResultsGrid.Location = new Point(462, 125);
            ItemSearchResultsGrid.Margin = new Padding(3, 2, 3, 2);
            ItemSearchResultsGrid.MultiSelect = false;
            ItemSearchResultsGrid.Name = "ItemSearchResultsGrid";
            ItemSearchResultsGrid.RowHeadersWidth = 51;
            ItemSearchResultsGrid.RowTemplate.Height = 29;
            ItemSearchResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemSearchResultsGrid.Size = new Size(548, 383);
            ItemSearchResultsGrid.TabIndex = 8;
            ItemSearchResultsGrid.DoubleClick += AddItemsButton_Click;
            // 
            // typeID
            // 
            typeID.DataPropertyName = "typeId";
            typeID.HeaderText = "Type ID";
            typeID.MinimumWidth = 6;
            typeID.Name = "typeID";
            typeID.Width = 70;
            // 
            // typeName
            // 
            typeName.DataPropertyName = "typeName";
            typeName.HeaderText = "Type Name";
            typeName.MinimumWidth = 6;
            typeName.Name = "typeName";
            typeName.Width = 91;
            // 
            // marketGroupName
            // 
            marketGroupName.DataPropertyName = "marketGroupName";
            marketGroupName.HeaderText = "Group";
            marketGroupName.MinimumWidth = 6;
            marketGroupName.Name = "marketGroupName";
            marketGroupName.Width = 65;
            // 
            // groupId
            // 
            groupId.DataPropertyName = "groupId";
            groupId.HeaderText = "GroupID";
            groupId.MinimumWidth = 6;
            groupId.Name = "groupId";
            groupId.Visible = false;
            groupId.Width = 125;
            // 
            // description
            // 
            description.DataPropertyName = "description";
            description.HeaderText = "Description";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.Visible = false;
            description.Width = 125;
            // 
            // volume
            // 
            volume.DataPropertyName = "volume";
            volume.HeaderText = "Volume";
            volume.MinimumWidth = 6;
            volume.Name = "volume";
            volume.Visible = false;
            volume.Width = 125;
            // 
            // portionSize
            // 
            portionSize.DataPropertyName = "portionSize";
            portionSize.HeaderText = "Portion Size";
            portionSize.MinimumWidth = 6;
            portionSize.Name = "portionSize";
            portionSize.Visible = false;
            portionSize.Width = 125;
            // 
            // raceId
            // 
            raceId.DataPropertyName = "raceId";
            raceId.HeaderText = "Race ID";
            raceId.MinimumWidth = 6;
            raceId.Name = "raceId";
            raceId.Visible = false;
            raceId.Width = 125;
            // 
            // basePrice
            // 
            basePrice.DataPropertyName = "basePrice";
            basePrice.HeaderText = "Base Price";
            basePrice.MinimumWidth = 6;
            basePrice.Name = "basePrice";
            basePrice.Visible = false;
            basePrice.Width = 125;
            // 
            // marketGroupId
            // 
            marketGroupId.DataPropertyName = "marketGroupId";
            marketGroupId.HeaderText = "Market Gorup ID";
            marketGroupId.MinimumWidth = 6;
            marketGroupId.Name = "marketGroupId";
            marketGroupId.Visible = false;
            marketGroupId.Width = 125;
            // 
            // parentMarketGroupId
            // 
            parentMarketGroupId.DataPropertyName = "parentMarketGroupId";
            parentMarketGroupId.HeaderText = "Parent Parket Group ID";
            parentMarketGroupId.MinimumWidth = 6;
            parentMarketGroupId.Name = "parentMarketGroupId";
            parentMarketGroupId.Visible = false;
            parentMarketGroupId.Width = 125;
            // 
            // iconId
            // 
            iconId.DataPropertyName = "iconId";
            iconId.HeaderText = "Icon Id";
            iconId.MinimumWidth = 6;
            iconId.Name = "iconId";
            iconId.Visible = false;
            iconId.Width = 125;
            // 
            // soundId
            // 
            soundId.DataPropertyName = "soundId";
            soundId.HeaderText = "Sound ID";
            soundId.MinimumWidth = 6;
            soundId.Name = "soundId";
            soundId.Visible = false;
            soundId.Width = 125;
            // 
            // graphicId
            // 
            graphicId.DataPropertyName = "graphicId";
            graphicId.HeaderText = "Graphic Id";
            graphicId.MinimumWidth = 6;
            graphicId.Name = "graphicId";
            graphicId.Visible = false;
            graphicId.Width = 125;
            // 
            // groupName
            // 
            groupName.DataPropertyName = "groupName";
            groupName.HeaderText = "Group Name";
            groupName.MinimumWidth = 6;
            groupName.Name = "groupName";
            groupName.Visible = false;
            groupName.Width = 125;
            // 
            // categoryID
            // 
            categoryID.DataPropertyName = "categoryID";
            categoryID.HeaderText = "Category ID";
            categoryID.MinimumWidth = 6;
            categoryID.Name = "categoryID";
            categoryID.Visible = false;
            categoryID.Width = 125;
            // 
            // categoryName
            // 
            categoryName.DataPropertyName = "categoryName";
            categoryName.HeaderText = "CategoryName";
            categoryName.MinimumWidth = 6;
            categoryName.Name = "categoryName";
            categoryName.Visible = false;
            categoryName.Width = 125;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(903, 56);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 7;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemSearchTextBox.Location = new Point(462, 56);
            ItemSearchTextBox.Margin = new Padding(3, 2, 3, 2);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.Size = new Size(426, 23);
            ItemSearchTextBox.TabIndex = 6;
            ItemSearchTextBox.KeyDown += ItemSearchTextBox_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 59);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Item Name";
            // 
            // AddItemsButton
            // 
            AddItemsButton.ForeColor = Color.Black;
            AddItemsButton.Location = new Point(462, 97);
            AddItemsButton.Name = "AddItemsButton";
            AddItemsButton.Size = new Size(118, 23);
            AddItemsButton.TabIndex = 9;
            AddItemsButton.Text = "Add Items To List";
            AddItemsButton.UseVisualStyleBackColor = true;
            AddItemsButton.Click += AddItemsButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 107);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 12;
            label3.Text = "Bought";
            // 
            // CopyToClipboardButton
            // 
            CopyToClipboardButton.ForeColor = Color.Black;
            CopyToClipboardButton.Location = new Point(223, 96);
            CopyToClipboardButton.Name = "CopyToClipboardButton";
            CopyToClipboardButton.Size = new Size(138, 23);
            CopyToClipboardButton.TabIndex = 13;
            CopyToClipboardButton.Text = "Copy to Clipboard";
            CopyToClipboardButton.UseVisualStyleBackColor = true;
            CopyToClipboardButton.Click += CopyToClipboard_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 73);
            label4.Name = "label4";
            label4.Size = new Size(151, 15);
            label4.TabIndex = 14;
            label4.Text = "Works with Multibuy in Eve";
            // 
            // ShoppingListGrid
            // 
            dataGridViewCellStyle2.BackColor = Color.DimGray;
            ShoppingListGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            ShoppingListGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ShoppingListGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ShoppingListGrid.BackgroundColor = Color.Black;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            ShoppingListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ShoppingListGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ShoppingListGrid.Columns.AddRange(new DataGridViewColumn[] { Bought, dataGridViewTextBoxColumn3, BoughtAtPrice, dataGridViewTextBoxColumn1 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            ShoppingListGrid.DefaultCellStyle = dataGridViewCellStyle6;
            ShoppingListGrid.GridColor = Color.Black;
            ShoppingListGrid.Location = new Point(12, 125);
            ShoppingListGrid.Margin = new Padding(3, 2, 3, 2);
            ShoppingListGrid.Name = "ShoppingListGrid";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            ShoppingListGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            ShoppingListGrid.RowHeadersWidth = 51;
            ShoppingListGrid.RowTemplate.Height = 29;
            ShoppingListGrid.Size = new Size(419, 391);
            ShoppingListGrid.TabIndex = 15;
            ShoppingListGrid.CellValidating += ShoppingListGrid_CellValidating;
            ShoppingListGrid.CellValueChanged += ShoppingListGrid_CellValueChanged;
            ShoppingListGrid.CellValueNeeded += ShoppingListGrid_CellValueNeeded;
            ShoppingListGrid.CellValuePushed += ShppingListGrid_CellValuePushed;
            ShoppingListGrid.DataError += ShoppingListyGrid_DataError;
            ShoppingListGrid.EditingControlShowing += ShoppingListGrid_EditingControlShowing;
            // 
            // Bought
            // 
            Bought.DataPropertyName = "Bought";
            Bought.HeaderText = "Bought";
            Bought.Name = "Bought";
            Bought.Resizable = DataGridViewTriState.True;
            Bought.SortMode = DataGridViewColumnSortMode.Automatic;
            Bought.Width = 71;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "QuantityString";
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.Padding = new Padding(2);
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn3.HeaderText = "Quantity";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 78;
            // 
            // BoughtAtPrice
            // 
            BoughtAtPrice.DataPropertyName = "BoughtAtPriceString";
            BoughtAtPrice.HeaderText = "Price";
            BoughtAtPrice.Name = "BoughtAtPrice";
            BoughtAtPrice.Width = 58;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "typeName";
            dataGridViewCellStyle5.Padding = new Padding(2);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewTextBoxColumn1.HeaderText = "Type Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 91;
            // 
            // ShoppingListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 519);
            Controls.Add(ShoppingListGrid);
            Controls.Add(label4);
            Controls.Add(CopyToClipboardButton);
            Controls.Add(label3);
            Controls.Add(AddItemsButton);
            Controls.Add(ItemSearchResultsGrid);
            Controls.Add(SearchButton);
            Controls.Add(ItemSearchTextBox);
            Controls.Add(label2);
            Controls.Add(DeleteListButton);
            Controls.Add(NewListButton);
            Controls.Add(ShoppingListCombo);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ShoppingListControl";
            Text = "ShoppingList";
            FormClosing += ShoppingListControl_FormClosing;
            ((System.ComponentModel.ISupportInitialize)ItemSearchResultsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShoppingListGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox ShoppingListCombo;
        private Button NewListButton;
        private Button DeleteListButton;
        private DataGridView ItemSearchResultsGrid;
        private DataGridViewTextBoxColumn typeID;
        private DataGridViewTextBoxColumn typeName;
        private DataGridViewTextBoxColumn marketGroupName;
        private DataGridViewTextBoxColumn groupId;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn portionSize;
        private DataGridViewTextBoxColumn raceId;
        private DataGridViewTextBoxColumn basePrice;
        private DataGridViewTextBoxColumn marketGroupId;
        private DataGridViewTextBoxColumn parentMarketGroupId;
        private DataGridViewTextBoxColumn iconId;
        private DataGridViewTextBoxColumn soundId;
        private DataGridViewTextBoxColumn graphicId;
        private DataGridViewTextBoxColumn groupName;
        private DataGridViewTextBoxColumn categoryID;
        private DataGridViewTextBoxColumn categoryName;
        private Button SearchButton;
        private TextBox ItemSearchTextBox;
        private Label label2;
        private Button AddItemsButton;
        private Label label3;
        private Button CopyToClipboardButton;
        private Label label4;
        private DataGridView ShoppingListGrid;
        private DataGridViewCheckBoxColumn Bought;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn BoughtAtPrice;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}