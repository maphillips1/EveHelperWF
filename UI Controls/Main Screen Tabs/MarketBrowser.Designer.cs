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
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketBrowser));
            SelectedItemImageWorker = new System.ComponentModel.BackgroundWorker();
            TheraButton = new Button();
            SystemCombo = new ComboBox();
            SelectedItemImagePanel = new Panel();
            SearchButton = new Button();
            MarketListTreeView = new TreeView();
            SelectedItemTabPanel = new TabControl();
            OrdersTabPage = new TabPage();
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
            Avg = new DataGridViewTextBoxColumn();
            Low = new DataGridViewTextBoxColumn();
            High = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            orderCount = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            priceHistoryGraph1 = new Objects.Custom_Controls.PriceHistoryGraph();
            RensButton = new Button();
            label2 = new Label();
            label1 = new Label();
            SelectedItemLabel = new Label();
            SearchTextBox = new TextBox();
            AmarrButton = new Button();
            DodixieButton = new Button();
            JitaButton = new Button();
            RegionCombo = new ComboBox();
            SearchResultsTreeView = new TreeView();
            ClearSystemButton = new Button();
            ClearRegionButton = new Button();
            HighSecCheckbox = new CheckBox();
            LowsecCheckbox = new CheckBox();
            NullSechCheckbox = new CheckBox();
            SelectedItemTabPanel.SuspendLayout();
            OrdersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SellOrdersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BuyOrdersGridView).BeginInit();
            PriceHistoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // SelectedItemImageWorker
            // 
            SelectedItemImageWorker.DoWork += SelectedItemImageWorker_DoWork;
            SelectedItemImageWorker.RunWorkerCompleted += SelectedItemImageWorker_RunWorkerCompleted;
            // 
            // TheraButton
            // 
            TheraButton.ForeColor = Color.Black;
            TheraButton.Location = new Point(760, 50);
            TheraButton.Margin = new Padding(3, 2, 3, 2);
            TheraButton.Name = "TheraButton";
            TheraButton.Size = new Size(82, 22);
            TheraButton.TabIndex = 30;
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
            SelectedItemImagePanel.Location = new Point(256, 49);
            SelectedItemImagePanel.Margin = new Padding(3, 2, 3, 2);
            SelectedItemImagePanel.Name = "SelectedItemImagePanel";
            SelectedItemImagePanel.Size = new Size(56, 48);
            SelectedItemImagePanel.TabIndex = 28;
            // 
            // SearchButton
            // 
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(153, 2);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(97, 24);
            SearchButton.TabIndex = 21;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // MarketListTreeView
            // 
            MarketListTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            MarketListTreeView.BackColor = Color.FromArgb(2, 23, 38);
            MarketListTreeView.ForeColor = Color.White;
            MarketListTreeView.Location = new Point(2, 166);
            MarketListTreeView.Margin = new Padding(3, 2, 3, 2);
            MarketListTreeView.Name = "MarketListTreeView";
            MarketListTreeView.Size = new Size(248, 466);
            MarketListTreeView.TabIndex = 15;
            MarketListTreeView.AfterSelect += MarketListTreeView_AfterSelect;
            // 
            // SelectedItemTabPanel
            // 
            SelectedItemTabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedItemTabPanel.Controls.Add(OrdersTabPage);
            SelectedItemTabPanel.Controls.Add(PriceHistoryTabPage);
            SelectedItemTabPanel.Controls.Add(tabPage2);
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
            OrdersTabPage.BackColor = Color.FromArgb(2, 23, 38);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
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
            SellOrdersGridView.BackgroundColor = Color.Black;
            SellOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SellOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { range, volumeRemaining, minVolume, formattedPrice, locationName, duration, issued, isBuyOrder, locationID, orderID, price, systemID, typeID, volumeTotal });
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.Black;
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle16.ForeColor = Color.White;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            SellOrdersGridView.DefaultCellStyle = dataGridViewCellStyle16;
            SellOrdersGridView.GridColor = Color.Black;
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
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = "0";
            volumeRemaining.DefaultCellStyle = dataGridViewCellStyle14;
            volumeRemaining.HeaderText = "Remaining";
            volumeRemaining.MinimumWidth = 6;
            volumeRemaining.Name = "volumeRemaining";
            volumeRemaining.Width = 89;
            // 
            // minVolume
            // 
            minVolume.DataPropertyName = "min_volume";
            minVolume.HeaderText = "Min Volume";
            minVolume.MinimumWidth = 6;
            minVolume.Name = "minVolume";
            minVolume.Width = 96;
            // 
            // formattedPrice
            // 
            formattedPrice.DataPropertyName = "FormattedPriceString";
            dataGridViewCellStyle15.Format = "C2";
            dataGridViewCellStyle15.NullValue = null;
            formattedPrice.DefaultCellStyle = dataGridViewCellStyle15;
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
            volumeTotal.Width = 125;
            // 
            // BuyOrdersGridView
            // 
            BuyOrdersGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BuyOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BuyOrdersGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            BuyOrdersGridView.BackgroundColor = Color.Black;
            BuyOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BuyOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, formattedPriceColumn, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13 });
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.Black;
            dataGridViewCellStyle19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle19.ForeColor = Color.White;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.False;
            BuyOrdersGridView.DefaultCellStyle = dataGridViewCellStyle19;
            BuyOrdersGridView.GridColor = Color.Black;
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
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = "0";
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewTextBoxColumn2.HeaderText = "Remaining";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 89;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "min_volume";
            dataGridViewTextBoxColumn3.HeaderText = "Min Volume";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 96;
            // 
            // formattedPriceColumn
            // 
            formattedPriceColumn.DataPropertyName = "FormattedPriceString";
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = null;
            formattedPriceColumn.DefaultCellStyle = dataGridViewCellStyle18;
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
            dataGridViewTextBoxColumn13.Width = 125;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 232);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 6;
            label4.Text = "Buy Orders";
            // 
            // PriceHistoryTabPage
            // 
            PriceHistoryTabPage.BackColor = Color.FromArgb(54, 57, 53);
            PriceHistoryTabPage.Controls.Add(PriceHistoryGridView);
            PriceHistoryTabPage.Location = new Point(4, 28);
            PriceHistoryTabPage.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryTabPage.Name = "PriceHistoryTabPage";
            PriceHistoryTabPage.Padding = new Padding(3, 2, 3, 2);
            PriceHistoryTabPage.Size = new Size(715, 462);
            PriceHistoryTabPage.TabIndex = 1;
            PriceHistoryTabPage.Text = "Price History";
            // 
            // PriceHistoryGridView
            // 
            PriceHistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PriceHistoryGridView.BackgroundColor = Color.Black;
            PriceHistoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PriceHistoryGridView.Columns.AddRange(new DataGridViewColumn[] { date, Avg, Low, High, volume, orderCount });
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = Color.Black;
            dataGridViewCellStyle26.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle26.ForeColor = Color.White;
            dataGridViewCellStyle26.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.False;
            PriceHistoryGridView.DefaultCellStyle = dataGridViewCellStyle26;
            PriceHistoryGridView.Dock = DockStyle.Fill;
            PriceHistoryGridView.GridColor = Color.Black;
            PriceHistoryGridView.Location = new Point(3, 2);
            PriceHistoryGridView.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryGridView.Name = "PriceHistoryGridView";
            PriceHistoryGridView.RowHeadersWidth = 51;
            PriceHistoryGridView.RowTemplate.Height = 29;
            PriceHistoryGridView.Size = new Size(709, 458);
            PriceHistoryGridView.TabIndex = 0;
            // 
            // date
            // 
            date.DataPropertyName = "date";
            dataGridViewCellStyle20.Padding = new Padding(2);
            date.DefaultCellStyle = dataGridViewCellStyle20;
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 56;
            // 
            // Avg
            // 
            Avg.DataPropertyName = "average";
            dataGridViewCellStyle21.Format = "N0";
            dataGridViewCellStyle21.NullValue = "0";
            dataGridViewCellStyle21.Padding = new Padding(2);
            Avg.DefaultCellStyle = dataGridViewCellStyle21;
            Avg.HeaderText = "avg";
            Avg.MinimumWidth = 6;
            Avg.Name = "Avg";
            Avg.Width = 51;
            // 
            // Low
            // 
            Low.DataPropertyName = "lowest";
            dataGridViewCellStyle22.Format = "N0";
            dataGridViewCellStyle22.NullValue = "0";
            dataGridViewCellStyle22.Padding = new Padding(2);
            Low.DefaultCellStyle = dataGridViewCellStyle22;
            Low.HeaderText = "low";
            Low.MinimumWidth = 6;
            Low.Name = "Low";
            Low.Width = 51;
            // 
            // High
            // 
            High.DataPropertyName = "highest";
            dataGridViewCellStyle23.Format = "N0";
            dataGridViewCellStyle23.NullValue = "0";
            dataGridViewCellStyle23.Padding = new Padding(2);
            High.DefaultCellStyle = dataGridViewCellStyle23;
            High.HeaderText = "high";
            High.MinimumWidth = 6;
            High.Name = "High";
            High.Width = 56;
            // 
            // volume
            // 
            volume.DataPropertyName = "volume";
            dataGridViewCellStyle24.Format = "N0";
            dataGridViewCellStyle24.NullValue = "0";
            dataGridViewCellStyle24.Padding = new Padding(2);
            volume.DefaultCellStyle = dataGridViewCellStyle24;
            volume.HeaderText = "Volume";
            volume.MinimumWidth = 6;
            volume.Name = "volume";
            volume.Width = 72;
            // 
            // orderCount
            // 
            orderCount.DataPropertyName = "order_count";
            dataGridViewCellStyle25.Padding = new Padding(2);
            orderCount.DefaultCellStyle = dataGridViewCellStyle25;
            orderCount.HeaderText = "Order Count";
            orderCount.MinimumWidth = 6;
            orderCount.Name = "orderCount";
            orderCount.Width = 98;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(2, 23, 38);
            tabPage2.Controls.Add(priceHistoryGraph1);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(715, 462);
            tabPage2.TabIndex = 2;
            tabPage2.Text = "Price History Graph";
            // 
            // priceHistoryGraph1
            // 
            priceHistoryGraph1.Dock = DockStyle.Fill;
            priceHistoryGraph1.DrawDashedLines = false;
            priceHistoryGraph1.Location = new Point(0, 0);
            priceHistoryGraph1.Name = "priceHistoryGraph1";
            priceHistoryGraph1.SelectedTimePeriod = 0;
            priceHistoryGraph1.Size = new Size(715, 462);
            priceHistoryGraph1.TabIndex = 0;
            // 
            // RensButton
            // 
            RensButton.ForeColor = Color.Black;
            RensButton.Location = new Point(672, 50);
            RensButton.Margin = new Padding(3, 2, 3, 2);
            RensButton.Name = "RensButton";
            RensButton.Size = new Size(82, 22);
            RensButton.TabIndex = 25;
            RensButton.Text = "Rens";
            RensButton.UseVisualStyleBackColor = true;
            RensButton.Click += RensButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(370, 75);
            label2.Name = "label2";
            label2.Size = new Size(57, 19);
            label2.TabIndex = 18;
            label2.Text = "System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(370, 49);
            label1.Name = "label1";
            label1.Size = new Size(56, 19);
            label1.TabIndex = 17;
            label1.Text = "Region";
            // 
            // SelectedItemLabel
            // 
            SelectedItemLabel.AutoSize = true;
            SelectedItemLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
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
            AmarrButton.ForeColor = Color.Black;
            AmarrButton.Location = new Point(585, 77);
            AmarrButton.Margin = new Padding(3, 2, 3, 2);
            AmarrButton.Name = "AmarrButton";
            AmarrButton.Size = new Size(82, 22);
            AmarrButton.TabIndex = 26;
            AmarrButton.Text = "Amarr";
            AmarrButton.UseVisualStyleBackColor = true;
            AmarrButton.Click += AmarrButton_Click;
            // 
            // DodixieButton
            // 
            DodixieButton.ForeColor = Color.Black;
            DodixieButton.Location = new Point(672, 77);
            DodixieButton.Margin = new Padding(3, 2, 3, 2);
            DodixieButton.Name = "DodixieButton";
            DodixieButton.Size = new Size(82, 22);
            DodixieButton.TabIndex = 24;
            DodixieButton.Text = "Dodixie";
            DodixieButton.UseVisualStyleBackColor = true;
            DodixieButton.Click += DodixieButton_Click;
            // 
            // JitaButton
            // 
            JitaButton.ForeColor = Color.Black;
            JitaButton.Location = new Point(585, 50);
            JitaButton.Margin = new Padding(3, 2, 3, 2);
            JitaButton.Name = "JitaButton";
            JitaButton.Size = new Size(82, 22);
            JitaButton.TabIndex = 22;
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
            RegionCombo.Location = new Point(433, 49);
            RegionCombo.Margin = new Padding(3, 2, 3, 2);
            RegionCombo.Name = "RegionCombo";
            RegionCombo.Size = new Size(133, 23);
            RegionCombo.TabIndex = 20;
            RegionCombo.SelectionChangeCommitted += RegionCombo_SelectedIndexChanged;
            // 
            // SearchResultsTreeView
            // 
            SearchResultsTreeView.BackColor = Color.FromArgb(2, 23, 38);
            SearchResultsTreeView.CausesValidation = false;
            SearchResultsTreeView.ForeColor = SystemColors.ControlLight;
            SearchResultsTreeView.HideSelection = false;
            SearchResultsTreeView.HotTracking = true;
            SearchResultsTreeView.Location = new Point(3, 28);
            SearchResultsTreeView.Margin = new Padding(2);
            SearchResultsTreeView.Name = "SearchResultsTreeView";
            SearchResultsTreeView.Size = new Size(247, 134);
            SearchResultsTreeView.TabIndex = 23;
            SearchResultsTreeView.AfterSelect += SearchResultsTreeView_AfterSelect;
            // 
            // ClearSystemButton
            // 
            ClearSystemButton.ForeColor = Color.Black;
            ClearSystemButton.Location = new Point(388, 103);
            ClearSystemButton.Margin = new Padding(3, 2, 3, 2);
            ClearSystemButton.Name = "ClearSystemButton";
            ClearSystemButton.Size = new Size(178, 22);
            ClearSystemButton.TabIndex = 31;
            ClearSystemButton.Text = "All Systems in Region";
            ClearSystemButton.UseVisualStyleBackColor = true;
            ClearSystemButton.Click += ClearSystemButton_Click;
            // 
            // ClearRegionButton
            // 
            ClearRegionButton.ForeColor = Color.Black;
            ClearRegionButton.Location = new Point(266, 103);
            ClearRegionButton.Margin = new Padding(3, 2, 3, 2);
            ClearRegionButton.Name = "ClearRegionButton";
            ClearRegionButton.Size = new Size(113, 22);
            ClearRegionButton.TabIndex = 32;
            ClearRegionButton.Text = "All Regions";
            ClearRegionButton.UseVisualStyleBackColor = true;
            ClearRegionButton.Click += ClearRegionButton_Click;
            // 
            // HighSecCheckbox
            // 
            HighSecCheckbox.AutoSize = true;
            HighSecCheckbox.Checked = true;
            HighSecCheckbox.CheckState = CheckState.Checked;
            HighSecCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
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
            LowsecCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
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
            NullSechCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
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
            ((System.ComponentModel.ISupportInitialize)PriceHistoryGridView).EndInit();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabPage tabPage1;
        private System.ComponentModel.BackgroundWorker SelectedItemImageWorker;
        private Button TheraButton;
        private ComboBox SystemCombo;
        private Panel SelectedItemImagePanel;
        private Button SearchButton;
        private TreeView MarketListTreeView;
        private TabControl SelectedItemTabPanel;
        private TabPage OrdersTabPage;
        private TabPage PriceHistoryTabPage;
        private DataGridView PriceHistoryGridView;
        private Button RensButton;
        private Label label2;
        private Label label1;
        private Label SelectedItemLabel;
        private TextBox SearchTextBox;
        private Button AmarrButton;
        private Button DodixieButton;
        private Button JitaButton;
        private ComboBox RegionCombo;
        private TreeView SearchResultsTreeView;
        private Label label3;
        private DataGridView SellOrdersGridView;
        private DataGridView BuyOrdersGridView;
        private Label label4;
        private Button ClearSystemButton;
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
        private TabPage tabPage2;
        private Objects.Custom_Controls.PriceHistoryGraph priceHistoryGraph1;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn Avg;
        private DataGridViewTextBoxColumn Low;
        private DataGridViewTextBoxColumn High;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn orderCount;
        private Button ClearRegionButton;
        private CheckBox HighSecCheckbox;
        private CheckBox LowsecCheckbox;
        private CheckBox NullSechCheckbox;
    }
}