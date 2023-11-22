namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketBrowser));
            MarketBrowserSplitContainer = new SplitContainer();
            SearchResultsTreeView = new TreeView();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            MarketListTreeView = new TreeView();
            TheraButton = new Button();
            SystemCombo = new ComboBox();
            SelectedItemImagePanel = new Panel();
            SelectedItemTabPanel = new TabControl();
            OrdersTabPage = new TabPage();
            OrdersSplitContainer = new SplitContainer();
            label3 = new Label();
            SellOrdersGridView = new DataGridView();
            range = new DataGridViewTextBoxColumn();
            volumeRemaining = new DataGridViewTextBoxColumn();
            minVolume = new DataGridViewTextBoxColumn();
            formattedPrice = new DataGridViewTextBoxColumn();
            locationName = new DataGridViewTextBoxColumn();
            duration = new DataGridViewTextBoxColumn();
            issued = new DataGridViewTextBoxColumn();
            isBuyOrder = new DataGridViewTextBoxColumn();
            locationID = new DataGridViewTextBoxColumn();
            orderID = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            systemID = new DataGridViewTextBoxColumn();
            typeID = new DataGridViewTextBoxColumn();
            volumeTotal = new DataGridViewTextBoxColumn();
            BuyOrdersGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            formattedPriceColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
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
            PriceHistoryGridView = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            formattedAverage = new DataGridViewTextBoxColumn();
            formattedLowest = new DataGridViewTextBoxColumn();
            formattedHighest = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            orderCount = new DataGridViewTextBoxColumn();
            average = new DataGridViewTextBoxColumn();
            highest = new DataGridViewTextBoxColumn();
            lowest = new DataGridViewTextBoxColumn();
            AmarrButton = new Button();
            RensButton = new Button();
            DodixieButton = new Button();
            JitaButton = new Button();
            RegionCombo = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            SelectedItemLabel = new Label();
            SelectedItemImageWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)MarketBrowserSplitContainer).BeginInit();
            MarketBrowserSplitContainer.Panel1.SuspendLayout();
            MarketBrowserSplitContainer.Panel2.SuspendLayout();
            MarketBrowserSplitContainer.SuspendLayout();
            SelectedItemTabPanel.SuspendLayout();
            OrdersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrdersSplitContainer).BeginInit();
            OrdersSplitContainer.Panel1.SuspendLayout();
            OrdersSplitContainer.Panel2.SuspendLayout();
            OrdersSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SellOrdersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BuyOrdersGridView).BeginInit();
            PriceHistoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).BeginInit();
            SuspendLayout();
            // 
            // MarketBrowserSplitContainer
            // 
            MarketBrowserSplitContainer.BackColor = Color.FromArgb(57, 54, 53);
            MarketBrowserSplitContainer.Dock = DockStyle.Fill;
            MarketBrowserSplitContainer.Location = new Point(0, 0);
            MarketBrowserSplitContainer.Name = "MarketBrowserSplitContainer";
            // 
            // MarketBrowserSplitContainer.Panel1
            // 
            MarketBrowserSplitContainer.Panel1.Controls.Add(SearchResultsTreeView);
            MarketBrowserSplitContainer.Panel1.Controls.Add(SearchButton);
            MarketBrowserSplitContainer.Panel1.Controls.Add(SearchTextBox);
            MarketBrowserSplitContainer.Panel1.Controls.Add(MarketListTreeView);
            // 
            // MarketBrowserSplitContainer.Panel2
            // 
            MarketBrowserSplitContainer.Panel2.BackColor = Color.FromArgb(2, 23, 38);
            MarketBrowserSplitContainer.Panel2.Controls.Add(TheraButton);
            MarketBrowserSplitContainer.Panel2.Controls.Add(SystemCombo);
            MarketBrowserSplitContainer.Panel2.Controls.Add(SelectedItemImagePanel);
            MarketBrowserSplitContainer.Panel2.Controls.Add(SelectedItemTabPanel);
            MarketBrowserSplitContainer.Panel2.Controls.Add(AmarrButton);
            MarketBrowserSplitContainer.Panel2.Controls.Add(RensButton);
            MarketBrowserSplitContainer.Panel2.Controls.Add(DodixieButton);
            MarketBrowserSplitContainer.Panel2.Controls.Add(JitaButton);
            MarketBrowserSplitContainer.Panel2.Controls.Add(RegionCombo);
            MarketBrowserSplitContainer.Panel2.Controls.Add(label2);
            MarketBrowserSplitContainer.Panel2.Controls.Add(label1);
            MarketBrowserSplitContainer.Panel2.Controls.Add(SelectedItemLabel);
            MarketBrowserSplitContainer.Size = new Size(1646, 853);
            MarketBrowserSplitContainer.SplitterDistance = 315;
            MarketBrowserSplitContainer.SplitterWidth = 10;
            MarketBrowserSplitContainer.TabIndex = 0;
            // 
            // SearchResultsTreeView
            // 
            SearchResultsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchResultsTreeView.BackColor = Color.FromArgb(2, 23, 38);
            SearchResultsTreeView.CausesValidation = false;
            SearchResultsTreeView.ForeColor = SystemColors.ControlLight;
            SearchResultsTreeView.HideSelection = false;
            SearchResultsTreeView.HotTracking = true;
            SearchResultsTreeView.Location = new Point(3, 35);
            SearchResultsTreeView.Margin = new Padding(2);
            SearchResultsTreeView.Name = "SearchResultsTreeView";
            SearchResultsTreeView.Size = new Size(310, 195);
            SearchResultsTreeView.TabIndex = 7;
            SearchResultsTreeView.AfterSelect += SearchResultsTreeView_AfterSelect;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(199, 3);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(111, 29);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextBox.Location = new Point(3, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(190, 27);
            SearchTextBox.TabIndex = 5;
            SearchTextBox.KeyDown += SearchTextBox_KeyDown;
            // 
            // MarketListTreeView
            // 
            MarketListTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MarketListTreeView.BackColor = Color.FromArgb(2, 23, 38);
            MarketListTreeView.ForeColor = Color.White;
            MarketListTreeView.Location = new Point(0, 232);
            MarketListTreeView.Name = "MarketListTreeView";
            MarketListTreeView.Size = new Size(315, 621);
            MarketListTreeView.TabIndex = 0;
            MarketListTreeView.AfterSelect += MarketListTreeView_AfterSelect;
            // 
            // TheraButton
            // 
            TheraButton.ForeColor = Color.Black;
            TheraButton.Location = new Point(588, 58);
            TheraButton.Name = "TheraButton";
            TheraButton.Size = new Size(94, 29);
            TheraButton.TabIndex = 14;
            TheraButton.Text = "Thera";
            TheraButton.UseVisualStyleBackColor = true;
            TheraButton.Click += TheraButton_Click;
            // 
            // SystemCombo
            // 
            SystemCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            SystemCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            SystemCombo.DropDownHeight = 150;
            SystemCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            SystemCombo.FormattingEnabled = true;
            SystemCombo.IntegralHeight = false;
            SystemCombo.Location = new Point(209, 95);
            SystemCombo.Name = "SystemCombo";
            SystemCombo.Size = new Size(151, 28);
            SystemCombo.TabIndex = 13;
            SystemCombo.SelectedIndexChanged += SystemCombo_SelectedIndexChanged;
            // 
            // SelectedItemImagePanel
            // 
            SelectedItemImagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            SelectedItemImagePanel.Location = new Point(23, 53);
            SelectedItemImagePanel.Name = "SelectedItemImagePanel";
            SelectedItemImagePanel.Size = new Size(64, 64);
            SelectedItemImagePanel.TabIndex = 12;
            // 
            // SelectedItemTabPanel
            // 
            SelectedItemTabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedItemTabPanel.Controls.Add(OrdersTabPage);
            SelectedItemTabPanel.Controls.Add(PriceHistoryTabPage);
            SelectedItemTabPanel.Location = new Point(0, 143);
            SelectedItemTabPanel.Name = "SelectedItemTabPanel";
            SelectedItemTabPanel.SelectedIndex = 0;
            SelectedItemTabPanel.Size = new Size(1321, 710);
            SelectedItemTabPanel.TabIndex = 11;
            // 
            // OrdersTabPage
            // 
            OrdersTabPage.Controls.Add(OrdersSplitContainer);
            OrdersTabPage.Location = new Point(4, 29);
            OrdersTabPage.Name = "OrdersTabPage";
            OrdersTabPage.Padding = new Padding(3);
            OrdersTabPage.Size = new Size(1313, 677);
            OrdersTabPage.TabIndex = 0;
            OrdersTabPage.Text = "Orders";
            OrdersTabPage.UseVisualStyleBackColor = true;
            // 
            // OrdersSplitContainer
            // 
            OrdersSplitContainer.Dock = DockStyle.Fill;
            OrdersSplitContainer.Location = new Point(3, 3);
            OrdersSplitContainer.Name = "OrdersSplitContainer";
            OrdersSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // OrdersSplitContainer.Panel1
            // 
            OrdersSplitContainer.Panel1.BackColor = Color.FromArgb(2, 23, 38);
            OrdersSplitContainer.Panel1.Controls.Add(label3);
            OrdersSplitContainer.Panel1.Controls.Add(SellOrdersGridView);
            // 
            // OrdersSplitContainer.Panel2
            // 
            OrdersSplitContainer.Panel2.BackColor = Color.FromArgb(2, 23, 38);
            OrdersSplitContainer.Panel2.Controls.Add(BuyOrdersGridView);
            OrdersSplitContainer.Panel2.Controls.Add(label4);
            OrdersSplitContainer.Size = new Size(1307, 671);
            OrdersSplitContainer.SplitterDistance = 335;
            OrdersSplitContainer.SplitterWidth = 10;
            OrdersSplitContainer.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 13);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(92, 23);
            label3.TabIndex = 1;
            label3.Text = "Sell Orders";
            // 
            // SellOrdersGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            SellOrdersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            SellOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SellOrdersGridView.BackgroundColor = Color.Black;
            SellOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SellOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { range, volumeRemaining, minVolume, formattedPrice, locationName, duration, issued, isBuyOrder, locationID, orderID, price, systemID, typeID, volumeTotal });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            SellOrdersGridView.DefaultCellStyle = dataGridViewCellStyle3;
            SellOrdersGridView.Dock = DockStyle.Bottom;
            SellOrdersGridView.GridColor = Color.White;
            SellOrdersGridView.Location = new Point(0, 57);
            SellOrdersGridView.Name = "SellOrdersGridView";
            SellOrdersGridView.RowHeadersWidth = 51;
            SellOrdersGridView.RowTemplate.Height = 29;
            SellOrdersGridView.Size = new Size(1307, 278);
            SellOrdersGridView.TabIndex = 0;
            // 
            // range
            // 
            range.DataPropertyName = "range";
            range.HeaderText = "Range";
            range.MinimumWidth = 6;
            range.Name = "range";
            range.Width = 80;
            // 
            // volumeRemaining
            // 
            volumeRemaining.DataPropertyName = "volume_remain";
            volumeRemaining.HeaderText = "Remaining";
            volumeRemaining.MinimumWidth = 6;
            volumeRemaining.Name = "volumeRemaining";
            volumeRemaining.Width = 109;
            // 
            // minVolume
            // 
            minVolume.DataPropertyName = "min_volume";
            minVolume.HeaderText = "Min Volume";
            minVolume.MinimumWidth = 6;
            minVolume.Name = "minVolume";
            minVolume.Width = 117;
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
            formattedPrice.Width = 70;
            // 
            // locationName
            // 
            locationName.DataPropertyName = "LocationName";
            locationName.HeaderText = "Location";
            locationName.MinimumWidth = 6;
            locationName.Name = "locationName";
            locationName.Width = 95;
            // 
            // duration
            // 
            duration.DataPropertyName = "duration";
            duration.HeaderText = "Duration";
            duration.MinimumWidth = 6;
            duration.Name = "duration";
            duration.Width = 96;
            // 
            // issued
            // 
            issued.DataPropertyName = "issued";
            issued.HeaderText = "Issued";
            issued.MinimumWidth = 6;
            issued.Name = "issued";
            issued.Width = 79;
            // 
            // isBuyOrder
            // 
            isBuyOrder.DataPropertyName = "is_buy_order";
            isBuyOrder.HeaderText = "Is Buy Order";
            isBuyOrder.MinimumWidth = 6;
            isBuyOrder.Name = "isBuyOrder";
            isBuyOrder.Visible = false;
            isBuyOrder.Width = 118;
            // 
            // locationID
            // 
            locationID.DataPropertyName = "location_id";
            locationID.HeaderText = "Location ID";
            locationID.MinimumWidth = 6;
            locationID.Name = "locationID";
            locationID.Visible = false;
            locationID.Width = 114;
            // 
            // orderID
            // 
            orderID.DataPropertyName = "order_id";
            orderID.HeaderText = "OrderID";
            orderID.MinimumWidth = 6;
            orderID.Name = "orderID";
            orderID.Visible = false;
            orderID.Width = 91;
            // 
            // price
            // 
            price.DataPropertyName = "price";
            price.HeaderText = "Price";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.Visible = false;
            price.Width = 70;
            // 
            // systemID
            // 
            systemID.DataPropertyName = "system_id";
            systemID.HeaderText = "System ID";
            systemID.MinimumWidth = 6;
            systemID.Name = "systemID";
            systemID.Visible = false;
            systemID.Width = 104;
            // 
            // typeID
            // 
            typeID.DataPropertyName = "type_id";
            typeID.HeaderText = "Type ID";
            typeID.MinimumWidth = 6;
            typeID.Name = "typeID";
            typeID.Visible = false;
            typeID.Width = 88;
            // 
            // volumeTotal
            // 
            volumeTotal.DataPropertyName = "volume_total";
            volumeTotal.HeaderText = "Volume Total";
            volumeTotal.MinimumWidth = 6;
            volumeTotal.Name = "volumeTotal";
            volumeTotal.Visible = false;
            volumeTotal.Width = 125;
            // 
            // BuyOrdersGridView
            // 
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.White;
            BuyOrdersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            BuyOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BuyOrdersGridView.BackgroundColor = Color.Black;
            BuyOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BuyOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, formattedPriceColumn, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            BuyOrdersGridView.DefaultCellStyle = dataGridViewCellStyle6;
            BuyOrdersGridView.Dock = DockStyle.Bottom;
            BuyOrdersGridView.GridColor = Color.White;
            BuyOrdersGridView.Location = new Point(0, 45);
            BuyOrdersGridView.Name = "BuyOrdersGridView";
            BuyOrdersGridView.RowHeadersWidth = 51;
            BuyOrdersGridView.RowTemplate.Height = 29;
            BuyOrdersGridView.Size = new Size(1307, 281);
            BuyOrdersGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "range";
            dataGridViewTextBoxColumn1.HeaderText = "Range";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "volume_remain";
            dataGridViewTextBoxColumn2.HeaderText = "Remaining";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 109;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "min_volume";
            dataGridViewTextBoxColumn3.HeaderText = "Min Volume";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 117;
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
            formattedPriceColumn.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "LocationName";
            dataGridViewTextBoxColumn5.HeaderText = "Location";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 95;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "duration";
            dataGridViewTextBoxColumn6.HeaderText = "Duration";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 96;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "issued";
            dataGridViewTextBoxColumn7.HeaderText = "Issued";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 79;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "is_buy_order";
            dataGridViewTextBoxColumn8.HeaderText = "Is Buy Order";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Visible = false;
            dataGridViewTextBoxColumn8.Width = 118;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "location_id";
            dataGridViewTextBoxColumn9.HeaderText = "Location ID";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Visible = false;
            dataGridViewTextBoxColumn9.Width = 114;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "order_id";
            dataGridViewTextBoxColumn10.HeaderText = "OrderID";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Visible = false;
            dataGridViewTextBoxColumn10.Width = 91;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "price";
            dataGridViewTextBoxColumn4.HeaderText = "Price";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Visible = false;
            dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "system_id";
            dataGridViewTextBoxColumn11.HeaderText = "System ID";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Visible = false;
            dataGridViewTextBoxColumn11.Width = 104;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.DataPropertyName = "type_id";
            dataGridViewTextBoxColumn12.HeaderText = "Type ID";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Visible = false;
            dataGridViewTextBoxColumn12.Width = 88;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "volume_total";
            dataGridViewTextBoxColumn13.HeaderText = "Volume Total";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Visible = false;
            dataGridViewTextBoxColumn13.Width = 125;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 12);
            label4.Name = "label4";
            label4.Size = new Size(94, 23);
            label4.TabIndex = 2;
            label4.Text = "Buy Orders";
            // 
            // PriceHistoryTabPage
            // 
            PriceHistoryTabPage.BackColor = Color.FromArgb(54, 57, 53);
            PriceHistoryTabPage.Controls.Add(PriceHistoryGridView);
            PriceHistoryTabPage.Location = new Point(4, 29);
            PriceHistoryTabPage.Name = "PriceHistoryTabPage";
            PriceHistoryTabPage.Padding = new Padding(3);
            PriceHistoryTabPage.Size = new Size(1313, 677);
            PriceHistoryTabPage.TabIndex = 1;
            PriceHistoryTabPage.Text = "Price History";
            // 
            // PriceHistoryGridView
            // 
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.White;
            PriceHistoryGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            PriceHistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PriceHistoryGridView.BackgroundColor = Color.Black;
            PriceHistoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PriceHistoryGridView.Columns.AddRange(new DataGridViewColumn[] { date, formattedAverage, formattedLowest, formattedHighest, volume, orderCount, average, highest, lowest });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.Black;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            PriceHistoryGridView.DefaultCellStyle = dataGridViewCellStyle8;
            PriceHistoryGridView.Dock = DockStyle.Fill;
            PriceHistoryGridView.GridColor = Color.White;
            PriceHistoryGridView.Location = new Point(3, 3);
            PriceHistoryGridView.Name = "PriceHistoryGridView";
            PriceHistoryGridView.RowHeadersWidth = 51;
            PriceHistoryGridView.RowTemplate.Height = 29;
            PriceHistoryGridView.Size = new Size(1307, 671);
            PriceHistoryGridView.TabIndex = 0;
            // 
            // date
            // 
            date.DataPropertyName = "date";
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 70;
            // 
            // formattedAverage
            // 
            formattedAverage.DataPropertyName = "formattedAverage";
            formattedAverage.HeaderText = "Average";
            formattedAverage.MinimumWidth = 6;
            formattedAverage.Name = "formattedAverage";
            formattedAverage.Width = 93;
            // 
            // formattedLowest
            // 
            formattedLowest.DataPropertyName = "formattedLowest";
            formattedLowest.HeaderText = "Lowest";
            formattedLowest.MinimumWidth = 6;
            formattedLowest.Name = "formattedLowest";
            formattedLowest.Width = 84;
            // 
            // formattedHighest
            // 
            formattedHighest.DataPropertyName = "formattedHighest";
            formattedHighest.HeaderText = "Highest";
            formattedHighest.MinimumWidth = 6;
            formattedHighest.Name = "formattedHighest";
            formattedHighest.Width = 89;
            // 
            // volume
            // 
            volume.DataPropertyName = "volume";
            volume.HeaderText = "Volume";
            volume.MinimumWidth = 6;
            volume.Name = "volume";
            volume.Width = 88;
            // 
            // orderCount
            // 
            orderCount.DataPropertyName = "order_count";
            orderCount.HeaderText = "Order Count";
            orderCount.MinimumWidth = 6;
            orderCount.Name = "orderCount";
            orderCount.Width = 119;
            // 
            // average
            // 
            average.DataPropertyName = "average";
            average.HeaderText = "avg";
            average.MinimumWidth = 6;
            average.Name = "average";
            average.Visible = false;
            average.Width = 62;
            // 
            // highest
            // 
            highest.DataPropertyName = "highest";
            highest.HeaderText = "high";
            highest.MinimumWidth = 6;
            highest.Name = "highest";
            highest.Visible = false;
            highest.Width = 67;
            // 
            // lowest
            // 
            lowest.DataPropertyName = "lowest";
            lowest.HeaderText = "low";
            lowest.MinimumWidth = 6;
            lowest.Name = "lowest";
            lowest.Visible = false;
            lowest.Width = 62;
            // 
            // AmarrButton
            // 
            AmarrButton.ForeColor = Color.Black;
            AmarrButton.Location = new Point(388, 94);
            AmarrButton.Name = "AmarrButton";
            AmarrButton.Size = new Size(94, 29);
            AmarrButton.TabIndex = 10;
            AmarrButton.Text = "Amarr";
            AmarrButton.UseVisualStyleBackColor = true;
            AmarrButton.Click += AmarrButton_Click;
            // 
            // RensButton
            // 
            RensButton.ForeColor = Color.Black;
            RensButton.Location = new Point(488, 57);
            RensButton.Name = "RensButton";
            RensButton.Size = new Size(94, 29);
            RensButton.TabIndex = 9;
            RensButton.Text = "Rens";
            RensButton.UseVisualStyleBackColor = true;
            RensButton.Click += RensButton_Click;
            // 
            // DodixieButton
            // 
            DodixieButton.ForeColor = Color.Black;
            DodixieButton.Location = new Point(488, 94);
            DodixieButton.Name = "DodixieButton";
            DodixieButton.Size = new Size(94, 29);
            DodixieButton.TabIndex = 8;
            DodixieButton.Text = "Dodixie";
            DodixieButton.UseVisualStyleBackColor = true;
            DodixieButton.Click += DodixieButton_Click;
            // 
            // JitaButton
            // 
            JitaButton.ForeColor = Color.Black;
            JitaButton.Location = new Point(388, 57);
            JitaButton.Name = "JitaButton";
            JitaButton.Size = new Size(94, 29);
            JitaButton.TabIndex = 7;
            JitaButton.Text = "Jita";
            JitaButton.UseVisualStyleBackColor = true;
            JitaButton.Click += JitaButton_Click;
            // 
            // RegionCombo
            // 
            RegionCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            RegionCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            RegionCombo.DropDownHeight = 150;
            RegionCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            RegionCombo.FormattingEnabled = true;
            RegionCombo.IntegralHeight = false;
            RegionCombo.Location = new Point(209, 58);
            RegionCombo.Name = "RegionCombo";
            RegionCombo.Size = new Size(151, 28);
            RegionCombo.TabIndex = 5;
            RegionCombo.SelectedIndexChanged += RegionCombo_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(137, 94);
            label2.Name = "label2";
            label2.Size = new Size(68, 23);
            label2.TabIndex = 4;
            label2.Text = "System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(137, 59);
            label1.Name = "label1";
            label1.Size = new Size(66, 23);
            label1.TabIndex = 3;
            label1.Text = "Region";
            // 
            // SelectedItemLabel
            // 
            SelectedItemLabel.AutoSize = true;
            SelectedItemLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            SelectedItemLabel.ForeColor = Color.Gold;
            SelectedItemLabel.Location = new Point(137, 9);
            SelectedItemLabel.Name = "SelectedItemLabel";
            SelectedItemLabel.Size = new Size(136, 28);
            SelectedItemLabel.TabIndex = 2;
            SelectedItemLabel.Text = "Selected Item";
            // 
            // SelectedItemImageWorker
            // 
            SelectedItemImageWorker.DoWork += SelectedItemImageWorker_DoWork;
            SelectedItemImageWorker.RunWorkerCompleted += SelectedItemImageWorker_RunWorkerCompleted;
            // 
            // MarketBrowser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1646, 853);
            Controls.Add(MarketBrowserSplitContainer);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MarketBrowser";
            Text = "Market Browser";
            MarketBrowserSplitContainer.Panel1.ResumeLayout(false);
            MarketBrowserSplitContainer.Panel1.PerformLayout();
            MarketBrowserSplitContainer.Panel2.ResumeLayout(false);
            MarketBrowserSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MarketBrowserSplitContainer).EndInit();
            MarketBrowserSplitContainer.ResumeLayout(false);
            SelectedItemTabPanel.ResumeLayout(false);
            OrdersTabPage.ResumeLayout(false);
            OrdersSplitContainer.Panel1.ResumeLayout(false);
            OrdersSplitContainer.Panel1.PerformLayout();
            OrdersSplitContainer.Panel2.ResumeLayout(false);
            OrdersSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OrdersSplitContainer).EndInit();
            OrdersSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SellOrdersGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)BuyOrdersGridView).EndInit();
            PriceHistoryTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer MarketBrowserSplitContainer;
        private TreeView MarketListTreeView;
        private Label label2;
        private Label label1;
        private Label SelectedItemLabel;
        private ComboBox RegionCombo;
        private TabControl SelectedItemTabPanel;
        private TabPage OrdersTabPage;
        private TabPage PriceHistoryTabPage;
        private Button AmarrButton;
        private Button RensButton;
        private Button DodixieButton;
        private Button JitaButton;
        private TabPage tabPage1;
        private SplitContainer OrdersSplitContainer;
        private DataGridView SellOrdersGridView;
        private Panel SelectedItemImagePanel;
        private System.ComponentModel.BackgroundWorker SelectedItemImageWorker;
        private ComboBox SystemCombo;
        private Label label3;
        private Label label4;
        private DataGridView BuyOrdersGridView;
        private Button TheraButton;
        private DataGridView PriceHistoryGridView;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn formattedAverage;
        private DataGridViewTextBoxColumn formattedLowest;
        private DataGridViewTextBoxColumn formattedHighest;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn orderCount;
        private DataGridViewTextBoxColumn average;
        private DataGridViewTextBoxColumn highest;
        private DataGridViewTextBoxColumn lowest;
        private DataGridViewTextBoxColumn range;
        private DataGridViewTextBoxColumn volumeRemaining;
        private DataGridViewTextBoxColumn minVolume;
        private DataGridViewTextBoxColumn formattedPrice;
        private DataGridViewTextBoxColumn locationName;
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn formattedPriceColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private TreeView SearchResultsTreeView;
        private Button SearchButton;
        private TextBox SearchTextBox;
    }
}