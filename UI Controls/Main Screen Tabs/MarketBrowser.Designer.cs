﻿namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class MarketBrowser
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketBrowser));
            SelectedItemImageWorker = new System.ComponentModel.BackgroundWorker();
            TheraButton = new Objects.Custom_Controls.EveHelperButton();
            SystemCombo = new ComboBox();
            SelectedItemImagePanel = new Panel();
            SearchButton = new Objects.Custom_Controls.EveHelperButton();
            MarketListTreeView = new TreeView();
            SelectedItemTabPanel = new TabControl();
            OrdersTabPage = new TabPage();
            MarketVolumeLabel = new Label();
            label5 = new Label();
            label3 = new Label();
            SellOrdersGridView = new Objects.Custom_Controls.EveHelperGridView();
            range = new DataGridViewTextBoxColumn();
            volumeRemaining = new DataGridViewTextBoxColumn();
            formattedPrice = new DataGridViewTextBoxColumn();
            locationName = new DataGridViewTextBoxColumn();
            minVolume = new DataGridViewTextBoxColumn();
            duration = new DataGridViewTextBoxColumn();
            issued = new DataGridViewTextBoxColumn();
            isBuyOrder = new DataGridViewTextBoxColumn();
            locationID = new DataGridViewTextBoxColumn();
            orderID = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            systemID = new DataGridViewTextBoxColumn();
            typeID = new DataGridViewTextBoxColumn();
            volumeTotal = new DataGridViewTextBoxColumn();
            BuyOrdersGridView = new Objects.Custom_Controls.EveHelperGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            formattedPriceColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            label4 = new Label();
            PriceHistoryTabPage = new TabPage();
            PriceHistoryControl = new Objects.Custom_Controls.PriceHistory();
            RensButton = new Objects.Custom_Controls.EveHelperButton();
            label2 = new Label();
            label1 = new Label();
            SelectedItemLabel = new Label();
            SearchTextBox = new TextBox();
            AmarrButton = new Objects.Custom_Controls.EveHelperButton();
            DodixieButton = new Objects.Custom_Controls.EveHelperButton();
            JitaButton = new Objects.Custom_Controls.EveHelperButton();
            RegionCombo = new ComboBox();
            SearchResultsTreeView = new TreeView();
            ClearSystemButton = new Objects.Custom_Controls.EveHelperButton();
            ClearRegionButton = new Objects.Custom_Controls.EveHelperButton();
            HighSecCheckbox = new CheckBox();
            LowsecCheckbox = new CheckBox();
            NullSechCheckbox = new CheckBox();
            SelectedItemTabPanel.SuspendLayout();
            OrdersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SellOrdersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BuyOrdersGridView).BeginInit();
            PriceHistoryTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // SelectedItemImageWorker
            // 
            SelectedItemImageWorker.DoWork += SelectedItemImageWorker_DoWork;
            SelectedItemImageWorker.RunWorkerCompleted += SelectedItemImageWorker_RunWorkerCompleted;
            // 
            // TheraButton
            // 
            TheraButton.BorderBottom = false;
            TheraButton.BorderFull = true;
            TheraButton.BorderLeft = false;
            TheraButton.BorderRight = false;
            TheraButton.BorderTop = false;
            TheraButton.BorderWidth = 2F;
            TheraButton.FlatAppearance.BorderSize = 0;
            TheraButton.FlatStyle = FlatStyle.Flat;
            TheraButton.ForeColor = Color.FromArgb(234, 234, 234);
            TheraButton.Location = new Point(760, 50);
            TheraButton.Margin = new Padding(3, 2, 3, 2);
            TheraButton.Name = "TheraButton";
            TheraButton.Size = new Size(82, 22);
            TheraButton.TabIndex = 30;
            TheraButton.Text = "Thera";
            TheraButton.UseVisualStyleBackColor = false;
            TheraButton.Click += TheraButton_Click;
            // 
            // SystemCombo
            // 
            SystemCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            SystemCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            SystemCombo.DropDownHeight = 150;
            SystemCombo.FormattingEnabled = true;
            SystemCombo.IntegralHeight = false;
            SystemCombo.Location = new Point(433, 76);
            SystemCombo.Margin = new Padding(3, 2, 3, 2);
            SystemCombo.Name = "SystemCombo";
            SystemCombo.Size = new Size(133, 23);
            SystemCombo.TabIndex = 29;
            SystemCombo.SelectionChangeCommitted += SystemCombo_SelectedIndexChanged;
            // 
            // SelectedItemImagePanel
            // 
            SelectedItemImagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            SelectedItemImagePanel.Location = new Point(288, 46);
            SelectedItemImagePanel.Margin = new Padding(3, 2, 3, 2);
            SelectedItemImagePanel.Name = "SelectedItemImagePanel";
            SelectedItemImagePanel.Size = new Size(56, 48);
            SelectedItemImagePanel.TabIndex = 28;
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
            SearchButton.Location = new Point(153, 2);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(97, 24);
            SearchButton.TabIndex = 21;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // MarketListTreeView
            // 
            MarketListTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            MarketListTreeView.BackColor = Color.FromArgb(21, 21, 21);
            MarketListTreeView.ForeColor = Color.White;
            MarketListTreeView.Location = new Point(2, 166);
            MarketListTreeView.Margin = new Padding(3, 2, 3, 2);
            MarketListTreeView.Name = "MarketListTreeView";
            MarketListTreeView.Size = new Size(248, 466);
            MarketListTreeView.TabIndex = 15;
            MarketListTreeView.TabStop = false;
            MarketListTreeView.AfterSelect += MarketListTreeView_AfterSelect;
            // 
            // SelectedItemTabPanel
            // 
            SelectedItemTabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedItemTabPanel.Controls.Add(OrdersTabPage);
            SelectedItemTabPanel.Controls.Add(PriceHistoryTabPage);
            SelectedItemTabPanel.Location = new Point(256, 138);
            SelectedItemTabPanel.Margin = new Padding(3, 2, 3, 2);
            SelectedItemTabPanel.Name = "SelectedItemTabPanel";
            SelectedItemTabPanel.Padding = new Point(10, 5);
            SelectedItemTabPanel.SelectedIndex = 0;
            SelectedItemTabPanel.Size = new Size(723, 494);
            SelectedItemTabPanel.TabIndex = 27;
            // 
            // OrdersTabPage
            // 
            OrdersTabPage.BackColor = Color.FromArgb(21, 21, 21);
            OrdersTabPage.Controls.Add(MarketVolumeLabel);
            OrdersTabPage.Controls.Add(label5);
            OrdersTabPage.Controls.Add(label3);
            OrdersTabPage.Controls.Add(SellOrdersGridView);
            OrdersTabPage.Controls.Add(BuyOrdersGridView);
            OrdersTabPage.Controls.Add(label4);
            OrdersTabPage.Location = new Point(4, 28);
            OrdersTabPage.Margin = new Padding(3, 2, 3, 2);
            OrdersTabPage.Name = "OrdersTabPage";
            OrdersTabPage.Padding = new Padding(3, 2, 3, 2);
            OrdersTabPage.Size = new Size(715, 462);
            OrdersTabPage.TabIndex = 0;
            OrdersTabPage.Text = "Orders";
            // 
            // MarketVolumeLabel
            // 
            MarketVolumeLabel.AutoSize = true;
            MarketVolumeLabel.Location = new Point(264, 4);
            MarketVolumeLabel.Name = "MarketVolumeLabel";
            MarketVolumeLabel.Size = new Size(0, 15);
            MarketVolumeLabel.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(128, 4);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(130, 19);
            label5.TabIndex = 8;
            label5.Text = "Volume on Market: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(6, 4);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(75, 19);
            label3.TabIndex = 5;
            label3.Text = "Sell Orders";
            // 
            // SellOrdersGridView
            // 
            SellOrdersGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SellOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SellOrdersGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            SellOrdersGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            SellOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SellOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { range, volumeRemaining, formattedPrice, locationName, minVolume, duration, issued, isBuyOrder, locationID, orderID, price, systemID, typeID, volumeTotal });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            SellOrdersGridView.DefaultCellStyle = dataGridViewCellStyle3;
            SellOrdersGridView.EditableColumns = null;
            SellOrdersGridView.GridColor = Color.FromArgb(21, 21, 21);
            SellOrdersGridView.Location = new Point(9, 25);
            SellOrdersGridView.Margin = new Padding(3, 2, 3, 2);
            SellOrdersGridView.Name = "SellOrdersGridView";
            SellOrdersGridView.RowHeadersWidth = 51;
            SellOrdersGridView.RowTemplate.Height = 29;
            SellOrdersGridView.Size = new Size(700, 191);
            SellOrdersGridView.TabIndex = 4;
            // 
            // range
            // 
            range.DataPropertyName = "range";
            range.HeaderText = "Range";
            range.MinimumWidth = 6;
            range.Name = "range";
            range.Width = 65;
            // 
            // volumeRemaining
            // 
            volumeRemaining.DataPropertyName = "volume_remain";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            volumeRemaining.DefaultCellStyle = dataGridViewCellStyle1;
            volumeRemaining.HeaderText = "Remaining";
            volumeRemaining.MinimumWidth = 6;
            volumeRemaining.Name = "volumeRemaining";
            volumeRemaining.Width = 89;
            // 
            // formattedPrice
            // 
            formattedPrice.DataPropertyName = "FormattedPriceString";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            formattedPrice.DefaultCellStyle = dataGridViewCellStyle2;
            formattedPrice.HeaderText = "Price";
            formattedPrice.MinimumWidth = 6;
            formattedPrice.Name = "formattedPrice";
            formattedPrice.Width = 58;
            // 
            // locationName
            // 
            locationName.DataPropertyName = "LocationName";
            locationName.HeaderText = "Location";
            locationName.MinimumWidth = 6;
            locationName.Name = "locationName";
            locationName.Width = 78;
            // 
            // minVolume
            // 
            minVolume.DataPropertyName = "min_volume";
            minVolume.HeaderText = "Min Volume";
            minVolume.MinimumWidth = 6;
            minVolume.Name = "minVolume";
            minVolume.Width = 96;
            // 
            // duration
            // 
            duration.DataPropertyName = "duration";
            duration.HeaderText = "Duration";
            duration.MinimumWidth = 6;
            duration.Name = "duration";
            duration.Width = 78;
            // 
            // issued
            // 
            issued.DataPropertyName = "issued";
            issued.HeaderText = "Issued";
            issued.MinimumWidth = 6;
            issued.Name = "issued";
            issued.Width = 65;
            // 
            // isBuyOrder
            // 
            isBuyOrder.DataPropertyName = "is_buy_order";
            isBuyOrder.HeaderText = "Is Buy Order";
            isBuyOrder.MinimumWidth = 6;
            isBuyOrder.Name = "isBuyOrder";
            isBuyOrder.Visible = false;
            isBuyOrder.Width = 96;
            // 
            // locationID
            // 
            locationID.DataPropertyName = "location_id";
            locationID.HeaderText = "Location ID";
            locationID.MinimumWidth = 6;
            locationID.Name = "locationID";
            locationID.Visible = false;
            locationID.Width = 92;
            // 
            // orderID
            // 
            orderID.DataPropertyName = "order_id";
            orderID.HeaderText = "OrderID";
            orderID.MinimumWidth = 6;
            orderID.Name = "orderID";
            orderID.Visible = false;
            orderID.Width = 73;
            // 
            // price
            // 
            price.DataPropertyName = "price";
            price.HeaderText = "Price";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.Visible = false;
            price.Width = 58;
            // 
            // systemID
            // 
            systemID.DataPropertyName = "system_id";
            systemID.HeaderText = "System ID";
            systemID.MinimumWidth = 6;
            systemID.Name = "systemID";
            systemID.Visible = false;
            systemID.Width = 84;
            // 
            // typeID
            // 
            typeID.DataPropertyName = "type_id";
            typeID.HeaderText = "Type ID";
            typeID.MinimumWidth = 6;
            typeID.Name = "typeID";
            typeID.Visible = false;
            typeID.Width = 70;
            // 
            // volumeTotal
            // 
            volumeTotal.DataPropertyName = "volume_total";
            volumeTotal.HeaderText = "Volume Total";
            volumeTotal.MinimumWidth = 6;
            volumeTotal.Name = "volumeTotal";
            volumeTotal.Visible = false;
            // 
            // BuyOrdersGridView
            // 
            BuyOrdersGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BuyOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BuyOrdersGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            BuyOrdersGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            BuyOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BuyOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, formattedPriceColumn, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(234, 234, 234);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            BuyOrdersGridView.DefaultCellStyle = dataGridViewCellStyle6;
            BuyOrdersGridView.EditableColumns = null;
            BuyOrdersGridView.GridColor = Color.FromArgb(21, 21, 21);
            BuyOrdersGridView.Location = new Point(9, 253);
            BuyOrdersGridView.Margin = new Padding(3, 2, 3, 2);
            BuyOrdersGridView.Name = "BuyOrdersGridView";
            BuyOrdersGridView.RowHeadersWidth = 51;
            BuyOrdersGridView.RowTemplate.Height = 29;
            BuyOrdersGridView.Size = new Size(700, 204);
            BuyOrdersGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "range";
            dataGridViewTextBoxColumn1.HeaderText = "Range";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "volume_remain";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn2.HeaderText = "Remaining";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 89;
            // 
            // formattedPriceColumn
            // 
            formattedPriceColumn.DataPropertyName = "FormattedPriceString";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            formattedPriceColumn.DefaultCellStyle = dataGridViewCellStyle5;
            formattedPriceColumn.HeaderText = "Price";
            formattedPriceColumn.MinimumWidth = 6;
            formattedPriceColumn.Name = "formattedPriceColumn";
            formattedPriceColumn.Width = 58;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "LocationName";
            dataGridViewTextBoxColumn5.HeaderText = "Location";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "min_volume";
            dataGridViewTextBoxColumn3.HeaderText = "Min Volume";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 96;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "duration";
            dataGridViewTextBoxColumn6.HeaderText = "Duration";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 78;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "issued";
            dataGridViewTextBoxColumn7.HeaderText = "Issued";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 65;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "is_buy_order";
            dataGridViewTextBoxColumn8.HeaderText = "Is Buy Order";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Visible = false;
            dataGridViewTextBoxColumn8.Width = 96;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "location_id";
            dataGridViewTextBoxColumn9.HeaderText = "Location ID";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Visible = false;
            dataGridViewTextBoxColumn9.Width = 92;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "order_id";
            dataGridViewTextBoxColumn10.HeaderText = "OrderID";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Visible = false;
            dataGridViewTextBoxColumn10.Width = 73;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "price";
            dataGridViewTextBoxColumn4.HeaderText = "Price";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Visible = false;
            dataGridViewTextBoxColumn4.Width = 58;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "system_id";
            dataGridViewTextBoxColumn11.HeaderText = "System ID";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Visible = false;
            dataGridViewTextBoxColumn11.Width = 84;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.DataPropertyName = "type_id";
            dataGridViewTextBoxColumn12.HeaderText = "Type ID";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Visible = false;
            dataGridViewTextBoxColumn12.Width = 70;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "volume_total";
            dataGridViewTextBoxColumn13.HeaderText = "Volume Total";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(6, 232);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 6;
            label4.Text = "Buy Orders";
            // 
            // PriceHistoryTabPage
            // 
            PriceHistoryTabPage.BackColor = Color.FromArgb(54, 57, 53);
            PriceHistoryTabPage.Controls.Add(PriceHistoryControl);
            PriceHistoryTabPage.Location = new Point(4, 28);
            PriceHistoryTabPage.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryTabPage.Name = "PriceHistoryTabPage";
            PriceHistoryTabPage.Padding = new Padding(3, 2, 3, 2);
            PriceHistoryTabPage.Size = new Size(715, 462);
            PriceHistoryTabPage.TabIndex = 1;
            PriceHistoryTabPage.Text = "Price History";
            // 
            // PriceHistoryControl
            // 
            PriceHistoryControl.AutoScroll = true;
            PriceHistoryControl.AutoSize = true;
            PriceHistoryControl.BackColor = Color.FromArgb(21, 21, 21);
            PriceHistoryControl.Dock = DockStyle.Fill;
            PriceHistoryControl.ForeColor = Color.FromArgb(234, 234, 234);
            PriceHistoryControl.Location = new Point(3, 2);
            PriceHistoryControl.Name = "PriceHistoryControl";
            PriceHistoryControl.Size = new Size(709, 458);
            PriceHistoryControl.TabIndex = 0;
            // 
            // RensButton
            // 
            RensButton.BorderBottom = false;
            RensButton.BorderFull = true;
            RensButton.BorderLeft = false;
            RensButton.BorderRight = false;
            RensButton.BorderTop = false;
            RensButton.BorderWidth = 2F;
            RensButton.FlatAppearance.BorderSize = 0;
            RensButton.FlatStyle = FlatStyle.Flat;
            RensButton.ForeColor = Color.FromArgb(234, 234, 234);
            RensButton.Location = new Point(672, 50);
            RensButton.Margin = new Padding(3, 2, 3, 2);
            RensButton.Name = "RensButton";
            RensButton.Size = new Size(82, 22);
            RensButton.TabIndex = 25;
            RensButton.Text = "Rens";
            RensButton.UseVisualStyleBackColor = false;
            RensButton.Click += RensButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(370, 75);
            label2.Name = "label2";
            label2.Size = new Size(57, 19);
            label2.TabIndex = 18;
            label2.Text = "System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(370, 49);
            label1.Name = "label1";
            label1.Size = new Size(56, 19);
            label1.TabIndex = 17;
            label1.Text = "Region";
            // 
            // SelectedItemLabel
            // 
            SelectedItemLabel.AutoSize = true;
            SelectedItemLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            SelectedItemLabel.ForeColor = Color.Gold;
            SelectedItemLabel.Location = new Point(256, 3);
            SelectedItemLabel.Name = "SelectedItemLabel";
            SelectedItemLabel.Size = new Size(108, 21);
            SelectedItemLabel.TabIndex = 16;
            SelectedItemLabel.Text = "Selected Item";
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(3, 2);
            SearchTextBox.Margin = new Padding(3, 2, 3, 2);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(144, 23);
            SearchTextBox.TabIndex = 19;
            SearchTextBox.KeyUp += SearchTextBox_KeyDown;
            // 
            // AmarrButton
            // 
            AmarrButton.BorderBottom = false;
            AmarrButton.BorderFull = true;
            AmarrButton.BorderLeft = false;
            AmarrButton.BorderRight = false;
            AmarrButton.BorderTop = false;
            AmarrButton.BorderWidth = 2F;
            AmarrButton.FlatAppearance.BorderSize = 0;
            AmarrButton.FlatStyle = FlatStyle.Flat;
            AmarrButton.ForeColor = Color.FromArgb(234, 234, 234);
            AmarrButton.Location = new Point(585, 77);
            AmarrButton.Margin = new Padding(3, 2, 3, 2);
            AmarrButton.Name = "AmarrButton";
            AmarrButton.Size = new Size(82, 22);
            AmarrButton.TabIndex = 26;
            AmarrButton.Text = "Amarr";
            AmarrButton.UseVisualStyleBackColor = false;
            AmarrButton.Click += AmarrButton_Click;
            // 
            // DodixieButton
            // 
            DodixieButton.BorderBottom = false;
            DodixieButton.BorderFull = true;
            DodixieButton.BorderLeft = false;
            DodixieButton.BorderRight = false;
            DodixieButton.BorderTop = false;
            DodixieButton.BorderWidth = 2F;
            DodixieButton.FlatAppearance.BorderSize = 0;
            DodixieButton.FlatStyle = FlatStyle.Flat;
            DodixieButton.ForeColor = Color.FromArgb(234, 234, 234);
            DodixieButton.Location = new Point(672, 77);
            DodixieButton.Margin = new Padding(3, 2, 3, 2);
            DodixieButton.Name = "DodixieButton";
            DodixieButton.Size = new Size(82, 22);
            DodixieButton.TabIndex = 24;
            DodixieButton.Text = "Dodixie";
            DodixieButton.UseVisualStyleBackColor = false;
            DodixieButton.Click += DodixieButton_Click;
            // 
            // JitaButton
            // 
            JitaButton.BorderBottom = false;
            JitaButton.BorderFull = true;
            JitaButton.BorderLeft = false;
            JitaButton.BorderRight = false;
            JitaButton.BorderTop = false;
            JitaButton.BorderWidth = 2F;
            JitaButton.FlatAppearance.BorderSize = 0;
            JitaButton.FlatStyle = FlatStyle.Flat;
            JitaButton.ForeColor = Color.FromArgb(234, 234, 234);
            JitaButton.Location = new Point(585, 50);
            JitaButton.Margin = new Padding(3, 2, 3, 2);
            JitaButton.Name = "JitaButton";
            JitaButton.Size = new Size(82, 22);
            JitaButton.TabIndex = 22;
            JitaButton.Text = "Jita";
            JitaButton.UseVisualStyleBackColor = false;
            JitaButton.Click += JitaButton_Click;
            // 
            // RegionCombo
            // 
            RegionCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            RegionCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            RegionCombo.DropDownHeight = 150;
            RegionCombo.FormattingEnabled = true;
            RegionCombo.IntegralHeight = false;
            RegionCombo.Location = new Point(433, 49);
            RegionCombo.Margin = new Padding(3, 2, 3, 2);
            RegionCombo.Name = "RegionCombo";
            RegionCombo.Size = new Size(133, 23);
            RegionCombo.TabIndex = 20;
            RegionCombo.SelectionChangeCommitted += RegionCombo_SelectedIndexChanged;
            // 
            // SearchResultsTreeView
            // 
            SearchResultsTreeView.BackColor = Color.FromArgb(21, 21, 21);
            SearchResultsTreeView.CausesValidation = false;
            SearchResultsTreeView.ForeColor = SystemColors.ControlLight;
            SearchResultsTreeView.HideSelection = false;
            SearchResultsTreeView.HotTracking = true;
            SearchResultsTreeView.Location = new Point(3, 28);
            SearchResultsTreeView.Margin = new Padding(2);
            SearchResultsTreeView.Name = "SearchResultsTreeView";
            SearchResultsTreeView.Size = new Size(247, 134);
            SearchResultsTreeView.TabIndex = 23;
            SearchResultsTreeView.TabStop = false;
            SearchResultsTreeView.AfterSelect += SearchResultsTreeView_AfterSelect;
            // 
            // ClearSystemButton
            // 
            ClearSystemButton.BorderBottom = false;
            ClearSystemButton.BorderFull = true;
            ClearSystemButton.BorderLeft = false;
            ClearSystemButton.BorderRight = false;
            ClearSystemButton.BorderTop = false;
            ClearSystemButton.BorderWidth = 2F;
            ClearSystemButton.FlatAppearance.BorderSize = 0;
            ClearSystemButton.FlatStyle = FlatStyle.Flat;
            ClearSystemButton.ForeColor = Color.FromArgb(234, 234, 234);
            ClearSystemButton.Location = new Point(388, 103);
            ClearSystemButton.Margin = new Padding(3, 2, 3, 2);
            ClearSystemButton.Name = "ClearSystemButton";
            ClearSystemButton.Size = new Size(178, 22);
            ClearSystemButton.TabIndex = 31;
            ClearSystemButton.Text = "All Systems in Region";
            ClearSystemButton.UseVisualStyleBackColor = false;
            ClearSystemButton.Click += ClearSystemButton_Click;
            // 
            // ClearRegionButton
            // 
            ClearRegionButton.BorderBottom = false;
            ClearRegionButton.BorderFull = true;
            ClearRegionButton.BorderLeft = false;
            ClearRegionButton.BorderRight = false;
            ClearRegionButton.BorderTop = false;
            ClearRegionButton.BorderWidth = 2F;
            ClearRegionButton.FlatAppearance.BorderSize = 0;
            ClearRegionButton.FlatStyle = FlatStyle.Flat;
            ClearRegionButton.ForeColor = Color.FromArgb(234, 234, 234);
            ClearRegionButton.Location = new Point(266, 103);
            ClearRegionButton.Margin = new Padding(3, 2, 3, 2);
            ClearRegionButton.Name = "ClearRegionButton";
            ClearRegionButton.Size = new Size(113, 22);
            ClearRegionButton.TabIndex = 32;
            ClearRegionButton.Text = "All Regions";
            ClearRegionButton.UseVisualStyleBackColor = false;
            ClearRegionButton.Click += ClearRegionButton_Click;
            // 
            // HighSecCheckbox
            // 
            HighSecCheckbox.AutoSize = true;
            HighSecCheckbox.Checked = true;
            HighSecCheckbox.CheckState = CheckState.Checked;
            HighSecCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            HighSecCheckbox.ForeColor = Color.FromArgb(128, 255, 128);
            HighSecCheckbox.Location = new Point(861, 50);
            HighSecCheckbox.Margin = new Padding(2);
            HighSecCheckbox.Name = "HighSecCheckbox";
            HighSecCheckbox.Size = new Size(87, 23);
            HighSecCheckbox.TabIndex = 37;
            HighSecCheckbox.Text = "High Sec";
            HighSecCheckbox.UseVisualStyleBackColor = true;
            HighSecCheckbox.CheckedChanged += HisecCheckbox_CheckedChanged;
            // 
            // LowsecCheckbox
            // 
            LowsecCheckbox.AutoSize = true;
            LowsecCheckbox.Checked = true;
            LowsecCheckbox.CheckState = CheckState.Checked;
            LowsecCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LowsecCheckbox.ForeColor = Color.FromArgb(255, 192, 128);
            LowsecCheckbox.Location = new Point(861, 80);
            LowsecCheckbox.Margin = new Padding(2);
            LowsecCheckbox.Name = "LowsecCheckbox";
            LowsecCheckbox.Size = new Size(82, 23);
            LowsecCheckbox.TabIndex = 38;
            LowsecCheckbox.Text = "Low Sec";
            LowsecCheckbox.UseVisualStyleBackColor = true;
            LowsecCheckbox.CheckedChanged += LowsecCheckbox_CheckedChanged;
            // 
            // NullSechCheckbox
            // 
            NullSechCheckbox.AutoSize = true;
            NullSechCheckbox.Checked = true;
            NullSechCheckbox.CheckState = CheckState.Checked;
            NullSechCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            NullSechCheckbox.ForeColor = Color.FromArgb(255, 128, 128);
            NullSechCheckbox.Location = new Point(861, 110);
            NullSechCheckbox.Margin = new Padding(2);
            NullSechCheckbox.Name = "NullSechCheckbox";
            NullSechCheckbox.Size = new Size(48, 23);
            NullSechCheckbox.TabIndex = 39;
            NullSechCheckbox.Text = "0.0";
            NullSechCheckbox.UseVisualStyleBackColor = true;
            NullSechCheckbox.CheckedChanged += NullSechCheckbox_CheckedChanged;
            // 
            // MarketBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(991, 634);
            Controls.Add(NullSechCheckbox);
            Controls.Add(LowsecCheckbox);
            Controls.Add(HighSecCheckbox);
            Controls.Add(ClearRegionButton);
            Controls.Add(ClearSystemButton);
            Controls.Add(TheraButton);
            Controls.Add(SystemCombo);
            Controls.Add(SelectedItemImagePanel);
            Controls.Add(SearchButton);
            Controls.Add(MarketListTreeView);
            Controls.Add(SelectedItemTabPanel);
            Controls.Add(RensButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SelectedItemLabel);
            Controls.Add(SearchTextBox);
            Controls.Add(AmarrButton);
            Controls.Add(DodixieButton);
            Controls.Add(JitaButton);
            Controls.Add(RegionCombo);
            Controls.Add(SearchResultsTreeView);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MarketBrowser";
            Text = "Market Browser";
            SelectedItemTabPanel.ResumeLayout(false);
            OrdersTabPage.ResumeLayout(false);
            OrdersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SellOrdersGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)BuyOrdersGridView).EndInit();
            PriceHistoryTabPage.ResumeLayout(false);
            PriceHistoryTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabPage tabPage1;
        private System.ComponentModel.BackgroundWorker SelectedItemImageWorker;
        private Objects.Custom_Controls.EveHelperButton TheraButton;
        private ComboBox SystemCombo;
        private Panel SelectedItemImagePanel;
        private Objects.Custom_Controls.EveHelperButton SearchButton;
        private TreeView MarketListTreeView;
        private TabControl SelectedItemTabPanel;
        private TabPage OrdersTabPage;
        private TabPage PriceHistoryTabPage;
        private Objects.Custom_Controls.EveHelperButton RensButton;
        private Label label2;
        private Label label1;
        private Label SelectedItemLabel;
        private TextBox SearchTextBox;
        private Objects.Custom_Controls.EveHelperButton AmarrButton;
        private Objects.Custom_Controls.EveHelperButton DodixieButton;
        private Objects.Custom_Controls.EveHelperButton JitaButton;
        private ComboBox RegionCombo;
        private TreeView SearchResultsTreeView;
        private Label label3;
        private Objects.Custom_Controls.EveHelperGridView SellOrdersGridView;
        private Objects.Custom_Controls.EveHelperGridView BuyOrdersGridView;
        private Label label4;
        private Objects.Custom_Controls.EveHelperButton ClearSystemButton;
        private Objects.Custom_Controls.EveHelperButton ClearRegionButton;
        private CheckBox HighSecCheckbox;
        private CheckBox LowsecCheckbox;
        private CheckBox NullSechCheckbox;
        private DataGridViewTextBoxColumn range;
        private DataGridViewTextBoxColumn volumeRemaining;
        private DataGridViewTextBoxColumn formattedPrice;
        private DataGridViewTextBoxColumn locationName;
        private DataGridViewTextBoxColumn minVolume;
        private DataGridViewTextBoxColumn duration;
        private DataGridViewTextBoxColumn issued;
        private DataGridViewTextBoxColumn isBuyOrder;
        private DataGridViewTextBoxColumn locationID;
        private DataGridViewTextBoxColumn orderID;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn systemID;
        private DataGridViewTextBoxColumn typeID;
        private DataGridViewTextBoxColumn volumeTotal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn formattedPriceColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Objects.Custom_Controls.PriceHistory PriceHistoryControl;
        private Label label5;
        private Label MarketVolumeLabel;
    }
}