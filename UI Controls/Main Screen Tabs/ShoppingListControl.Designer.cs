﻿namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
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
            NewListButton = new Objects.Custom_Controls.EveHelperButton();
            DeleteListButton = new Objects.Custom_Controls.EveHelperButton();
            ItemSearchResultsGrid = new Objects.Custom_Controls.EveHelperGridView();
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
            SearchButton = new Objects.Custom_Controls.EveHelperButton();
            ItemSearchTextBox = new TextBox();
            label2 = new Label();
            AddItemsButton = new Objects.Custom_Controls.EveHelperButton();
            CopyToClipboardButton = new Objects.Custom_Controls.EveHelperButton();
            label4 = new Label();
            ShoppingListGrid = new Objects.Custom_Controls.EveHelperGridView();
            Bought = new DataGridViewCheckBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
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
            label1.Location = new Point(10, 16);
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
            ShoppingListCombo.Location = new Point(117, 15);
            ShoppingListCombo.Name = "ShoppingListCombo";
            ShoppingListCombo.Size = new Size(242, 23);
            ShoppingListCombo.TabIndex = 1;
            ShoppingListCombo.SelectedIndexChanged += ShoppinglListCombo_SelectedIndexChanged;
            // 
            // NewListButton
            // 
            NewListButton.ForeColor = Color.FromArgb(234, 234, 234);
            NewListButton.Location = new Point(117, 44);
            NewListButton.Name = "NewListButton";
            NewListButton.Size = new Size(118, 23);
            NewListButton.TabIndex = 2;
            NewListButton.Text = "New Shopping List";
            NewListButton.UseVisualStyleBackColor = false;
            NewListButton.Click += NewListButton_Click;
            // 
            // DeleteListButton
            // 
            DeleteListButton.ForeColor = Color.FromArgb(234, 234, 234);
            DeleteListButton.Location = new Point(241, 44);
            DeleteListButton.Name = "DeleteListButton";
            DeleteListButton.Size = new Size(118, 23);
            DeleteListButton.TabIndex = 3;
            DeleteListButton.Text = "Delete List";
            DeleteListButton.UseVisualStyleBackColor = false;
            DeleteListButton.Click += DeleteListButton_Click;
            // 
            // ItemSearchResultsGrid
            // 
            ItemSearchResultsGrid.AllowUserToAddRows = false;
            ItemSearchResultsGrid.AllowUserToDeleteRows = false;
            ItemSearchResultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ItemSearchResultsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ItemSearchResultsGrid.BackgroundColor = Color.FromArgb(21, 21, 21);
            ItemSearchResultsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemSearchResultsGrid.Columns.AddRange(new DataGridViewColumn[] { typeID, typeName, marketGroupName, groupId, description, volume, portionSize, raceId, basePrice, marketGroupId, parentMarketGroupId, iconId, soundId, graphicId, groupName, categoryID, categoryName });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            ItemSearchResultsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            ItemSearchResultsGrid.EditableColumns = null;
            ItemSearchResultsGrid.GridColor = Color.FromArgb(21, 21, 21);
            ItemSearchResultsGrid.Location = new Point(532, 80);
            ItemSearchResultsGrid.Margin = new Padding(3, 2, 3, 2);
            ItemSearchResultsGrid.MultiSelect = false;
            ItemSearchResultsGrid.Name = "ItemSearchResultsGrid";
            ItemSearchResultsGrid.RowHeadersWidth = 51;
            ItemSearchResultsGrid.RowTemplate.Height = 29;
            ItemSearchResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemSearchResultsGrid.Size = new Size(478, 410);
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
            SearchButton.ForeColor = Color.FromArgb(234, 234, 234);
            SearchButton.Location = new Point(903, 11);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 7;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ItemSearchTextBox.Location = new Point(665, 11);
            ItemSearchTextBox.Margin = new Padding(3, 2, 3, 2);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.Size = new Size(223, 23);
            ItemSearchTextBox.TabIndex = 6;
            ItemSearchTextBox.KeyDown += ItemSearchTextBox_KeyDown;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(593, 15);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Item Name";
            // 
            // AddItemsButton
            // 
            AddItemsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddItemsButton.ForeColor = Color.FromArgb(234, 234, 234);
            AddItemsButton.Location = new Point(532, 52);
            AddItemsButton.Name = "AddItemsButton";
            AddItemsButton.Size = new Size(118, 23);
            AddItemsButton.TabIndex = 9;
            AddItemsButton.Text = "Add Items To List";
            AddItemsButton.UseVisualStyleBackColor = false;
            AddItemsButton.Click += AddItemsButton_Click;
            // 
            // CopyToClipboardButton
            // 
            CopyToClipboardButton.ForeColor = Color.FromArgb(234, 234, 234);
            CopyToClipboardButton.Location = new Point(381, 52);
            CopyToClipboardButton.Name = "CopyToClipboardButton";
            CopyToClipboardButton.Size = new Size(138, 23);
            CopyToClipboardButton.TabIndex = 13;
            CopyToClipboardButton.Text = "Copy to Clipboard";
            CopyToClipboardButton.UseVisualStyleBackColor = false;
            CopyToClipboardButton.Click += CopyToClipboard_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(370, 34);
            label4.Name = "label4";
            label4.Size = new Size(151, 15);
            label4.TabIndex = 14;
            label4.Text = "Works with Multibuy in Eve";
            // 
            // ShoppingListGrid
            // 
            dataGridViewCellStyle2.BackColor = Color.DimGray;
            ShoppingListGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            ShoppingListGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ShoppingListGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ShoppingListGrid.BackgroundColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            ShoppingListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ShoppingListGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ShoppingListGrid.Columns.AddRange(new DataGridViewColumn[] { Bought, Quantity, BoughtAtPrice, dataGridViewTextBoxColumn1 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            ShoppingListGrid.DefaultCellStyle = dataGridViewCellStyle6;
            ShoppingListGrid.EditableColumns = "Quantity,BoughtAtPrice,Bought";
            ShoppingListGrid.GridColor = Color.FromArgb(21, 21, 21);
            ShoppingListGrid.Location = new Point(12, 80);
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
            ShoppingListGrid.Size = new Size(507, 410);
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
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.Padding = new Padding(2);
            Quantity.DefaultCellStyle = dataGridViewCellStyle4;
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 78;
            // 
            // BoughtAtPrice
            // 
            BoughtAtPrice.DataPropertyName = "BoughtAtPrice";
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
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1022, 501);
            Controls.Add(ShoppingListGrid);
            Controls.Add(label4);
            Controls.Add(CopyToClipboardButton);
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
        private Objects.Custom_Controls.EveHelperButton NewListButton;
        private Objects.Custom_Controls.EveHelperButton DeleteListButton;
        private Objects.Custom_Controls.EveHelperGridView ItemSearchResultsGrid;
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
        private Objects.Custom_Controls.EveHelperButton SearchButton;
        private TextBox ItemSearchTextBox;
        private Label label2;
        private Objects.Custom_Controls.EveHelperButton AddItemsButton;
        private Objects.Custom_Controls.EveHelperButton CopyToClipboardButton;
        private Label label4;
        private Objects.Custom_Controls.EveHelperGridView ShoppingListGrid;
        private DataGridViewCheckBoxColumn Bought;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn BoughtAtPrice;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}