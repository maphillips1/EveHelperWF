namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class SystemFinder
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
            Label label8;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemFinder));
            SolarSystemResultsGrid = new DataGridView();
            regionName = new DataGridViewTextBoxColumn();
            constellationName = new DataGridViewTextBoxColumn();
            systemName = new DataGridViewTextBoxColumn();
            security = new DataGridViewTextBoxColumn();
            regionID = new DataGridViewTextBoxColumn();
            constellationID = new DataGridViewTextBoxColumn();
            solarSystemID = new DataGridViewTextBoxColumn();
            SearchButton = new Button();
            TemperateCheckbox = new CheckBox();
            PlasmaCheckbox = new CheckBox();
            StormCheckbox = new CheckBox();
            BarrenCheckbox = new CheckBox();
            LavaCheckbox = new CheckBox();
            OceanicCheckbox = new CheckBox();
            GasCheckBox = new CheckBox();
            IceCheckBox = new CheckBox();
            MinSecurityUpDown = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            MaxSecurityUpDown = new NumericUpDown();
            WormholesCheckbox = new CheckBox();
            IncludePochvenCheckbox = new CheckBox();
            PlanetSearchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            LoadingLabel = new Label();
            label3 = new Label();
            label4 = new Label();
            RegionCombobox = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            SystemNameTextBox = new TextBox();
            label7 = new Label();
            StationComboBox = new ComboBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)SolarSystemResultsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSecurityUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxSecurityUpDown).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(390, 214);
            label8.Name = "label8";
            label8.Size = new Size(157, 15);
            label8.TabIndex = 26;
            label8.Text = "Double-Click to view system";
            // 
            // SolarSystemResultsGrid
            // 
            SolarSystemResultsGrid.BackgroundColor = Color.Black;
            SolarSystemResultsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SolarSystemResultsGrid.Columns.AddRange(new DataGridViewColumn[] { regionName, constellationName, systemName, security, regionID, constellationID, solarSystemID });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            SolarSystemResultsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            SolarSystemResultsGrid.Dock = DockStyle.Bottom;
            SolarSystemResultsGrid.GridColor = Color.Black;
            SolarSystemResultsGrid.Location = new Point(0, 231);
            SolarSystemResultsGrid.Margin = new Padding(3, 2, 3, 2);
            SolarSystemResultsGrid.MultiSelect = false;
            SolarSystemResultsGrid.Name = "SolarSystemResultsGrid";
            SolarSystemResultsGrid.RowHeadersWidth = 51;
            SolarSystemResultsGrid.RowTemplate.Height = 29;
            SolarSystemResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SolarSystemResultsGrid.Size = new Size(559, 342);
            SolarSystemResultsGrid.TabIndex = 15;
            SolarSystemResultsGrid.DoubleClick += SolarSystemResultsGrid_DoubleClick;
            // 
            // regionName
            // 
            regionName.DataPropertyName = "regionName";
            regionName.HeaderText = "Region";
            regionName.MinimumWidth = 6;
            regionName.Name = "regionName";
            regionName.Width = 125;
            // 
            // constellationName
            // 
            constellationName.DataPropertyName = "constellationName";
            constellationName.HeaderText = "Constellation";
            constellationName.MinimumWidth = 6;
            constellationName.Name = "constellationName";
            constellationName.Width = 125;
            // 
            // systemName
            // 
            systemName.DataPropertyName = "solarSystemName";
            systemName.HeaderText = "System";
            systemName.MinimumWidth = 6;
            systemName.Name = "systemName";
            systemName.Width = 125;
            // 
            // security
            // 
            security.DataPropertyName = "security";
            security.HeaderText = "Security";
            security.MinimumWidth = 6;
            security.Name = "security";
            security.Width = 125;
            // 
            // regionID
            // 
            regionID.DataPropertyName = "regionID";
            regionID.HeaderText = "Region ID";
            regionID.MinimumWidth = 6;
            regionID.Name = "regionID";
            regionID.Visible = false;
            regionID.Width = 125;
            // 
            // constellationID
            // 
            constellationID.DataPropertyName = "constellationID";
            constellationID.HeaderText = "Constellation ID";
            constellationID.MinimumWidth = 6;
            constellationID.Name = "constellationID";
            constellationID.Visible = false;
            constellationID.Width = 125;
            // 
            // solarSystemID
            // 
            solarSystemID.DataPropertyName = "solarSystemID";
            solarSystemID.HeaderText = "solarSystemID";
            solarSystemID.MinimumWidth = 6;
            solarSystemID.Name = "solarSystemID";
            solarSystemID.Visible = false;
            solarSystemID.Width = 125;
            // 
            // SearchButton
            // 
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(7, 191);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // TemperateCheckbox
            // 
            TemperateCheckbox.AutoSize = true;
            TemperateCheckbox.Location = new Point(10, 31);
            TemperateCheckbox.Margin = new Padding(3, 2, 3, 2);
            TemperateCheckbox.Name = "TemperateCheckbox";
            TemperateCheckbox.Size = new Size(81, 19);
            TemperateCheckbox.TabIndex = 1;
            TemperateCheckbox.Text = "Temperate";
            TemperateCheckbox.UseVisualStyleBackColor = true;
            // 
            // PlasmaCheckbox
            // 
            PlasmaCheckbox.AutoSize = true;
            PlasmaCheckbox.Location = new Point(482, 31);
            PlasmaCheckbox.Margin = new Padding(3, 2, 3, 2);
            PlasmaCheckbox.Name = "PlasmaCheckbox";
            PlasmaCheckbox.Size = new Size(64, 19);
            PlasmaCheckbox.TabIndex = 2;
            PlasmaCheckbox.Text = "Plasma";
            PlasmaCheckbox.UseVisualStyleBackColor = true;
            // 
            // StormCheckbox
            // 
            StormCheckbox.AutoSize = true;
            StormCheckbox.Location = new Point(415, 31);
            StormCheckbox.Margin = new Padding(3, 2, 3, 2);
            StormCheckbox.Name = "StormCheckbox";
            StormCheckbox.Size = new Size(58, 19);
            StormCheckbox.TabIndex = 3;
            StormCheckbox.Text = "Storm";
            StormCheckbox.UseVisualStyleBackColor = true;
            // 
            // BarrenCheckbox
            // 
            BarrenCheckbox.AutoSize = true;
            BarrenCheckbox.Location = new Point(345, 31);
            BarrenCheckbox.Margin = new Padding(3, 2, 3, 2);
            BarrenCheckbox.Name = "BarrenCheckbox";
            BarrenCheckbox.Size = new Size(60, 19);
            BarrenCheckbox.TabIndex = 4;
            BarrenCheckbox.Text = "Barren";
            BarrenCheckbox.UseVisualStyleBackColor = true;
            // 
            // LavaCheckbox
            // 
            LavaCheckbox.AutoSize = true;
            LavaCheckbox.Location = new Point(286, 31);
            LavaCheckbox.Margin = new Padding(3, 2, 3, 2);
            LavaCheckbox.Name = "LavaCheckbox";
            LavaCheckbox.Size = new Size(50, 19);
            LavaCheckbox.TabIndex = 5;
            LavaCheckbox.Text = "Lava";
            LavaCheckbox.UseVisualStyleBackColor = true;
            // 
            // OceanicCheckbox
            // 
            OceanicCheckbox.AutoSize = true;
            OceanicCheckbox.Location = new Point(207, 31);
            OceanicCheckbox.Margin = new Padding(3, 2, 3, 2);
            OceanicCheckbox.Name = "OceanicCheckbox";
            OceanicCheckbox.Size = new Size(69, 19);
            OceanicCheckbox.TabIndex = 6;
            OceanicCheckbox.Text = "Oceanic";
            OceanicCheckbox.UseVisualStyleBackColor = true;
            // 
            // GasCheckBox
            // 
            GasCheckBox.AutoSize = true;
            GasCheckBox.Location = new Point(154, 31);
            GasCheckBox.Margin = new Padding(3, 2, 3, 2);
            GasCheckBox.Name = "GasCheckBox";
            GasCheckBox.Size = new Size(45, 19);
            GasCheckBox.TabIndex = 7;
            GasCheckBox.Text = "Gas";
            GasCheckBox.UseVisualStyleBackColor = true;
            // 
            // IceCheckBox
            // 
            IceCheckBox.AutoSize = true;
            IceCheckBox.Location = new Point(105, 31);
            IceCheckBox.Margin = new Padding(3, 2, 3, 2);
            IceCheckBox.Name = "IceCheckBox";
            IceCheckBox.Size = new Size(41, 19);
            IceCheckBox.TabIndex = 8;
            IceCheckBox.Text = "Ice";
            IceCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinSecurityUpDown
            // 
            MinSecurityUpDown.DecimalPlaces = 1;
            MinSecurityUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            MinSecurityUpDown.Location = new Point(46, 80);
            MinSecurityUpDown.Margin = new Padding(3, 2, 3, 2);
            MinSecurityUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            MinSecurityUpDown.Name = "MinSecurityUpDown";
            MinSecurityUpDown.Size = new Size(131, 23);
            MinSecurityUpDown.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 83);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 10;
            label1.Text = "Min";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 110);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(30, 15);
            label2.TabIndex = 12;
            label2.Text = "Max";
            // 
            // MaxSecurityUpDown
            // 
            MaxSecurityUpDown.DecimalPlaces = 1;
            MaxSecurityUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            MaxSecurityUpDown.Location = new Point(46, 104);
            MaxSecurityUpDown.Margin = new Padding(3, 2, 3, 2);
            MaxSecurityUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            MaxSecurityUpDown.Name = "MaxSecurityUpDown";
            MaxSecurityUpDown.Size = new Size(131, 23);
            MaxSecurityUpDown.TabIndex = 11;
            // 
            // WormholesCheckbox
            // 
            WormholesCheckbox.AutoSize = true;
            WormholesCheckbox.Location = new Point(192, 80);
            WormholesCheckbox.Margin = new Padding(3, 2, 3, 2);
            WormholesCheckbox.Name = "WormholesCheckbox";
            WormholesCheckbox.Size = new Size(129, 19);
            WormholesCheckbox.TabIndex = 13;
            WormholesCheckbox.Text = "Include Wormholes";
            WormholesCheckbox.UseVisualStyleBackColor = true;
            // 
            // IncludePochvenCheckbox
            // 
            IncludePochvenCheckbox.AutoSize = true;
            IncludePochvenCheckbox.Location = new Point(192, 102);
            IncludePochvenCheckbox.Margin = new Padding(3, 2, 3, 2);
            IncludePochvenCheckbox.Name = "IncludePochvenCheckbox";
            IncludePochvenCheckbox.Size = new Size(114, 19);
            IncludePochvenCheckbox.TabIndex = 14;
            IncludePochvenCheckbox.Text = "Include Pochven";
            IncludePochvenCheckbox.UseVisualStyleBackColor = true;
            // 
            // PlanetSearchBackgroundWorker
            // 
            PlanetSearchBackgroundWorker.DoWork += PlanetSearchBackgroundWorker_DoWork;
            PlanetSearchBackgroundWorker.RunWorkerCompleted += PlanetSearchBackgroundWorker_RunWorkerCompleted;
            // 
            // LoadingLabel
            // 
            LoadingLabel.AutoSize = true;
            LoadingLabel.Location = new Point(114, 194);
            LoadingLabel.Name = "LoadingLabel";
            LoadingLabel.Size = new Size(56, 15);
            LoadingLabel.TabIndex = 16;
            LoadingLabel.Text = "Loading..";
            LoadingLabel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(10, 7);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 18;
            label3.Text = "Has Planets";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(10, 58);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 19;
            label4.Text = "Security";
            // 
            // RegionCombobox
            // 
            RegionCombobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            RegionCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            RegionCombobox.DropDownStyle = ComboBoxStyle.DropDown;
            RegionCombobox.FormattingEnabled = true;
            RegionCombobox.Location = new Point(70, 151);
            RegionCombobox.Margin = new Padding(3, 2, 3, 2);
            RegionCombobox.Name = "RegionCombobox";
            RegionCombobox.Size = new Size(133, 23);
            RegionCombobox.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 153);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 21;
            label5.Text = "Region";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(224, 153);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 22;
            label6.Text = "System Name";
            // 
            // SystemNameTextBox
            // 
            SystemNameTextBox.Location = new Point(317, 151);
            SystemNameTextBox.Margin = new Padding(3, 2, 3, 2);
            SystemNameTextBox.Name = "SystemNameTextBox";
            SystemNameTextBox.Size = new Size(110, 23);
            SystemNameTextBox.TabIndex = 23;
            SystemNameTextBox.KeyDown += SystemNameTextBox_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(434, 57);
            label7.Name = "label7";
            label7.Size = new Size(54, 19);
            label7.TabIndex = 24;
            label7.Text = "Station";
            // 
            // StationComboBox
            // 
            StationComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            StationComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            StationComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            StationComboBox.FormattingEnabled = true;
            StationComboBox.Location = new Point(399, 81);
            StationComboBox.Margin = new Padding(3, 2, 3, 2);
            StationComboBox.Name = "StationComboBox";
            StationComboBox.Size = new Size(133, 23);
            StationComboBox.TabIndex = 25;
            // 
            // SystemFinder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 573);
            Controls.Add(label8);
            Controls.Add(StationComboBox);
            Controls.Add(label7);
            Controls.Add(SystemNameTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(RegionCombobox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(LoadingLabel);
            Controls.Add(SolarSystemResultsGrid);
            Controls.Add(IncludePochvenCheckbox);
            Controls.Add(WormholesCheckbox);
            Controls.Add(label2);
            Controls.Add(MaxSecurityUpDown);
            Controls.Add(label1);
            Controls.Add(MinSecurityUpDown);
            Controls.Add(IceCheckBox);
            Controls.Add(GasCheckBox);
            Controls.Add(OceanicCheckbox);
            Controls.Add(LavaCheckbox);
            Controls.Add(BarrenCheckbox);
            Controls.Add(StormCheckbox);
            Controls.Add(PlasmaCheckbox);
            Controls.Add(TemperateCheckbox);
            Controls.Add(SearchButton);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "SystemFinder";
            Text = "System Finder";
            ((System.ComponentModel.ISupportInitialize)SolarSystemResultsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinSecurityUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxSecurityUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private CheckBox TemperateCheckbox;
        private CheckBox PlasmaCheckbox;
        private CheckBox StormCheckbox;
        private CheckBox BarrenCheckbox;
        private CheckBox LavaCheckbox;
        private CheckBox OceanicCheckbox;
        private CheckBox GasCheckBox;
        private CheckBox IceCheckBox;
        private NumericUpDown MinSecurityUpDown;
        private Label label1;
        private Label label2;
        private NumericUpDown MaxSecurityUpDown;
        private CheckBox WormholesCheckbox;
        private CheckBox IncludePochvenCheckbox;
        private DataGridView SolarSystemResultsGrid;
        private System.ComponentModel.BackgroundWorker PlanetSearchBackgroundWorker;
        private Label LoadingLabel;
        private Label label3;
        private Label label4;
        private ComboBox RegionCombobox;
        private Label label5;
        private Label label6;
        private TextBox SystemNameTextBox;
        private Label label7;
        private ComboBox StationComboBox;
        private DataGridViewTextBoxColumn regionName;
        private DataGridViewTextBoxColumn constellationName;
        private DataGridViewTextBoxColumn systemName;
        private DataGridViewTextBoxColumn security;
        private DataGridViewTextBoxColumn regionID;
        private DataGridViewTextBoxColumn constellationID;
        private DataGridViewTextBoxColumn solarSystemID;
    }
}