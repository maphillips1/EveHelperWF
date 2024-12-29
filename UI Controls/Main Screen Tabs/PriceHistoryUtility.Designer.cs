namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class PriceHistoryUtility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceHistoryUtility));
            splitContainer1 = new SplitContainer();
            TrackItemsButton = new Objects.Custom_Controls.EveHelperButton();
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
            label1 = new Label();
            CancelButton = new Objects.Custom_Controls.EveHelperButton();
            ViewPriceHistoryButton = new Objects.Custom_Controls.EveHelperButton();
            ProgressLabel = new Label();
            UpdateHistoryProgressBar = new ProgressBar();
            TrackedTypesGrid = new Objects.Custom_Controls.EveHelperGridView();
            trackedTypeId = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            RegionCombo = new ComboBox();
            label4 = new Label();
            DeleteTrackedItemButton = new Objects.Custom_Controls.EveHelperButton();
            label3 = new Label();
            UpdatePriceHistoryButton = new Objects.Custom_Controls.EveHelperButton();
            UpdatePriceHistoryWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemSearchResultsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackedTypesGrid).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TrackItemsButton);
            splitContainer1.Panel1.Controls.Add(ItemSearchResultsGrid);
            splitContainer1.Panel1.Controls.Add(SearchButton);
            splitContainer1.Panel1.Controls.Add(ItemSearchTextBox);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(CancelButton);
            splitContainer1.Panel2.Controls.Add(ViewPriceHistoryButton);
            splitContainer1.Panel2.Controls.Add(ProgressLabel);
            splitContainer1.Panel2.Controls.Add(UpdateHistoryProgressBar);
            splitContainer1.Panel2.Controls.Add(TrackedTypesGrid);
            splitContainer1.Panel2.Controls.Add(RegionCombo);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(DeleteTrackedItemButton);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(UpdatePriceHistoryButton);
            splitContainer1.Size = new Size(1078, 550);
            splitContainer1.SplitterDistance = 563;
            splitContainer1.TabIndex = 0;
            // 
            // TrackItemsButton
            // 
            TrackItemsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TrackItemsButton.ForeColor = Color.FromArgb(234, 234, 234);
            TrackItemsButton.Location = new Point(460, 478);
            TrackItemsButton.Margin = new Padding(3, 2, 3, 2);
            TrackItemsButton.Name = "TrackItemsButton";
            TrackItemsButton.Size = new Size(82, 22);
            TrackItemsButton.TabIndex = 5;
            TrackItemsButton.Text = "Track Items";
            TrackItemsButton.UseVisualStyleBackColor = false;
            TrackItemsButton.Click += TrackItemsButton_Click;
            // 
            // ItemSearchResultsGrid
            // 
            ItemSearchResultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            ItemSearchResultsGrid.Location = new Point(10, 106);
            ItemSearchResultsGrid.Margin = new Padding(3, 2, 3, 2);
            ItemSearchResultsGrid.Name = "ItemSearchResultsGrid";
            ItemSearchResultsGrid.RowHeadersWidth = 51;
            ItemSearchResultsGrid.RowTemplate.Height = 29;
            ItemSearchResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemSearchResultsGrid.Size = new Size(532, 368);
            ItemSearchResultsGrid.TabIndex = 4;
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
            SearchButton.Location = new Point(440, 70);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemSearchTextBox.Location = new Point(88, 70);
            ItemSearchTextBox.Margin = new Padding(3, 2, 3, 2);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.Size = new Size(337, 23);
            ItemSearchTextBox.TabIndex = 2;
            ItemSearchTextBox.KeyDown += ItemSearchTextBox_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 73);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Item Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(171, 7);
            label1.Name = "label1";
            label1.Size = new Size(166, 21);
            label1.TabIndex = 0;
            label1.Text = "Select Items to Track";
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CancelButton.ForeColor = Color.Black;
            CancelButton.Location = new Point(353, 70);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(82, 22);
            CancelButton.TabIndex = 17;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // ViewPriceHistoryButton
            // 
            ViewPriceHistoryButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ViewPriceHistoryButton.ForeColor = Color.Black;
            ViewPriceHistoryButton.Location = new Point(369, 478);
            ViewPriceHistoryButton.Margin = new Padding(3, 2, 3, 2);
            ViewPriceHistoryButton.Name = "ViewPriceHistoryButton";
            ViewPriceHistoryButton.Size = new Size(131, 22);
            ViewPriceHistoryButton.TabIndex = 16;
            ViewPriceHistoryButton.Text = "View Price History";
            ViewPriceHistoryButton.UseVisualStyleBackColor = true;
            ViewPriceHistoryButton.Click += ViewPriceHistoryButton_Click;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            ProgressLabel.Location = new Point(20, 73);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(62, 19);
            ProgressLabel.TabIndex = 15;
            ProgressLabel.Text = "Progress";
            // 
            // UpdateHistoryProgressBar
            // 
            UpdateHistoryProgressBar.Location = new Point(91, 70);
            UpdateHistoryProgressBar.Margin = new Padding(3, 2, 3, 2);
            UpdateHistoryProgressBar.Name = "UpdateHistoryProgressBar";
            UpdateHistoryProgressBar.Size = new Size(251, 22);
            UpdateHistoryProgressBar.TabIndex = 14;
            // 
            // TrackedTypesGrid
            // 
            TrackedTypesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TrackedTypesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TrackedTypesGrid.BackgroundColor = Color.FromArgb(21, 21, 21);
            TrackedTypesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TrackedTypesGrid.Columns.AddRange(new DataGridViewColumn[] { trackedTypeId, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            TrackedTypesGrid.DefaultCellStyle = dataGridViewCellStyle2;
            TrackedTypesGrid.EditableColumns = null;
            TrackedTypesGrid.GridColor = Color.FromArgb(21, 21, 21);
            TrackedTypesGrid.Location = new Point(23, 106);
            TrackedTypesGrid.Margin = new Padding(3, 2, 3, 2);
            TrackedTypesGrid.MultiSelect = false;
            TrackedTypesGrid.Name = "TrackedTypesGrid";
            TrackedTypesGrid.RowHeadersWidth = 51;
            TrackedTypesGrid.RowTemplate.Height = 29;
            TrackedTypesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TrackedTypesGrid.Size = new Size(478, 368);
            TrackedTypesGrid.TabIndex = 13;
            TrackedTypesGrid.DoubleClick += TrackedTypesGrid_DoubleClick;
            // 
            // trackedTypeId
            // 
            trackedTypeId.DataPropertyName = "typeId";
            trackedTypeId.HeaderText = "Type ID";
            trackedTypeId.MinimumWidth = 6;
            trackedTypeId.Name = "trackedTypeId";
            trackedTypeId.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "typeName";
            dataGridViewTextBoxColumn2.HeaderText = "Type Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 91;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "marketGroupName";
            dataGridViewTextBoxColumn3.HeaderText = "Group";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "groupId";
            dataGridViewTextBoxColumn4.HeaderText = "GroupID";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Visible = false;
            dataGridViewTextBoxColumn4.Width = 94;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "description";
            dataGridViewTextBoxColumn5.HeaderText = "Description";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Visible = false;
            dataGridViewTextBoxColumn5.Width = 114;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "volume";
            dataGridViewTextBoxColumn6.HeaderText = "Volume";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Visible = false;
            dataGridViewTextBoxColumn6.Width = 88;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "portionSize";
            dataGridViewTextBoxColumn7.HeaderText = "Portion Size";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Visible = false;
            dataGridViewTextBoxColumn7.Width = 116;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "raceId";
            dataGridViewTextBoxColumn8.HeaderText = "Race ID";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Visible = false;
            dataGridViewTextBoxColumn8.Width = 89;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "basePrice";
            dataGridViewTextBoxColumn9.HeaderText = "Base Price";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Visible = false;
            dataGridViewTextBoxColumn9.Width = 105;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "marketGroupId";
            dataGridViewTextBoxColumn10.HeaderText = "Market Gorup ID";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Visible = false;
            dataGridViewTextBoxColumn10.Width = 148;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "parentMarketGroupId";
            dataGridViewTextBoxColumn11.HeaderText = "Parent Parket Group ID";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Visible = false;
            dataGridViewTextBoxColumn11.Width = 187;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.DataPropertyName = "iconId";
            dataGridViewTextBoxColumn12.HeaderText = "Icon Id";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Visible = false;
            dataGridViewTextBoxColumn12.Width = 83;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "soundId";
            dataGridViewTextBoxColumn13.HeaderText = "Sound ID";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Visible = false;
            dataGridViewTextBoxColumn13.Width = 99;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.DataPropertyName = "graphicId";
            dataGridViewTextBoxColumn14.HeaderText = "Graphic Id";
            dataGridViewTextBoxColumn14.MinimumWidth = 6;
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.Visible = false;
            dataGridViewTextBoxColumn14.Width = 106;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.DataPropertyName = "groupName";
            dataGridViewTextBoxColumn15.HeaderText = "Group Name";
            dataGridViewTextBoxColumn15.MinimumWidth = 6;
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.Visible = false;
            dataGridViewTextBoxColumn15.Width = 123;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.DataPropertyName = "categoryID";
            dataGridViewTextBoxColumn16.HeaderText = "Category ID";
            dataGridViewTextBoxColumn16.MinimumWidth = 6;
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.Visible = false;
            dataGridViewTextBoxColumn16.Width = 117;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.DataPropertyName = "categoryName";
            dataGridViewTextBoxColumn17.HeaderText = "CategoryName";
            dataGridViewTextBoxColumn17.MinimumWidth = 6;
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.Visible = false;
            dataGridViewTextBoxColumn17.Width = 138;
            // 
            // RegionCombo
            // 
            RegionCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            RegionCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            RegionCombo.DropDownHeight = 150;
            RegionCombo.FormattingEnabled = true;
            RegionCombo.IntegralHeight = false;
            RegionCombo.Location = new Point(353, 40);
            RegionCombo.Margin = new Padding(3, 2, 3, 2);
            RegionCombo.Name = "RegionCombo";
            RegionCombo.Size = new Size(133, 23);
            RegionCombo.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(265, 40);
            label4.Name = "label4";
            label4.Size = new Size(77, 19);
            label4.TabIndex = 9;
            label4.Text = "For Region";
            // 
            // DeleteTrackedItemButton
            // 
            DeleteTrackedItemButton.ForeColor = Color.FromArgb(234, 234, 234);
            DeleteTrackedItemButton.Location = new Point(23, 478);
            DeleteTrackedItemButton.Margin = new Padding(3, 2, 3, 2);
            DeleteTrackedItemButton.Name = "DeleteTrackedItemButton";
            DeleteTrackedItemButton.Size = new Size(148, 22);
            DeleteTrackedItemButton.TabIndex = 8;
            DeleteTrackedItemButton.Text = "Delete Tracked Item";
            DeleteTrackedItemButton.UseVisualStyleBackColor = false;
            DeleteTrackedItemButton.Click += DeleteTrackedItemButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(185, 7);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 7;
            label3.Text = "Tracked Items";
            // 
            // UpdatePriceHistoryButton
            // 
            UpdatePriceHistoryButton.ForeColor = Color.FromArgb(234, 234, 234);
            UpdatePriceHistoryButton.Location = new Point(23, 39);
            UpdatePriceHistoryButton.Margin = new Padding(3, 2, 3, 2);
            UpdatePriceHistoryButton.Name = "UpdatePriceHistoryButton";
            UpdatePriceHistoryButton.Size = new Size(234, 22);
            UpdatePriceHistoryButton.TabIndex = 0;
            UpdatePriceHistoryButton.Text = "Update Price History For All Items";
            UpdatePriceHistoryButton.UseVisualStyleBackColor = false;
            UpdatePriceHistoryButton.Click += UpdatePriceHistoryButton_Click;
            // 
            // UpdatePriceHistoryWorker
            // 
            UpdatePriceHistoryWorker.WorkerReportsProgress = true;
            UpdatePriceHistoryWorker.WorkerSupportsCancellation = true;
            UpdatePriceHistoryWorker.DoWork += UpdatePriceHistoryWorker_DoWork;
            UpdatePriceHistoryWorker.ProgressChanged += UpdatePriceHistoryWorker_ProgressChanged;
            UpdatePriceHistoryWorker.RunWorkerCompleted += UpdatePriceHistoryWorker_RunWorkerCompleted;
            // 
            // PriceHistoryUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1078, 550);
            Controls.Add(splitContainer1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PriceHistoryUtility";
            Text = "Price History Utility";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ItemSearchResultsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackedTypesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox ItemSearchTextBox;
        private Label label2;
        private Label label1;
        private Objects.Custom_Controls.EveHelperButton SearchButton;
        private Objects.Custom_Controls.EveHelperGridView ItemSearchResultsGrid;
        private Objects.Custom_Controls.EveHelperButton TrackItemsButton;
        private Objects.Custom_Controls.EveHelperButton UpdatePriceHistoryButton;
        private Label label3;
        private Objects.Custom_Controls.EveHelperButton DeleteTrackedItemButton;
        private Label label4;
        private ComboBox RegionCombo;
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
        private Objects.Custom_Controls.EveHelperGridView TrackedTypesGrid;
        private System.ComponentModel.BackgroundWorker UpdatePriceHistoryWorker;
        private Label ProgressLabel;
        private ProgressBar UpdateHistoryProgressBar;
        private DataGridViewTextBoxColumn trackedTypeId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private Objects.Custom_Controls.EveHelperButton ViewPriceHistoryButton;
        private Objects.Custom_Controls.EveHelperButton CancelButton;
    }
}