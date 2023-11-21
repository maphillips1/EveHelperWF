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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)SolarSystemResultsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSecurityUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxSecurityUpDown).BeginInit();
            SuspendLayout();
            // 
            // SolarSystemResultsGrid
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.ForeColor = Color.White;
            SolarSystemResultsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            SolarSystemResultsGrid.BackgroundColor = Color.Black;
            SolarSystemResultsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SolarSystemResultsGrid.Columns.AddRange(new DataGridViewColumn[] { regionName, constellationName, systemName, security, regionID, constellationID, solarSystemID });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            SolarSystemResultsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            SolarSystemResultsGrid.Dock = DockStyle.Bottom;
            SolarSystemResultsGrid.Location = new Point(0, 307);
            SolarSystemResultsGrid.MultiSelect = false;
            SolarSystemResultsGrid.Name = "SolarSystemResultsGrid";
            SolarSystemResultsGrid.RowHeadersWidth = 51;
            SolarSystemResultsGrid.RowTemplate.Height = 29;
            SolarSystemResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SolarSystemResultsGrid.Size = new Size(695, 457);
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
            SearchButton.Location = new Point(8, 255);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 29);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // TemperateCheckbox
            // 
            TemperateCheckbox.AutoSize = true;
            TemperateCheckbox.Location = new Point(12, 41);
            TemperateCheckbox.Name = "TemperateCheckbox";
            TemperateCheckbox.Size = new Size(102, 24);
            TemperateCheckbox.TabIndex = 1;
            TemperateCheckbox.Text = "Temperate";
            TemperateCheckbox.UseVisualStyleBackColor = true;
            // 
            // PlasmaCheckbox
            // 
            PlasmaCheckbox.AutoSize = true;
            PlasmaCheckbox.Location = new Point(551, 41);
            PlasmaCheckbox.Name = "PlasmaCheckbox";
            PlasmaCheckbox.Size = new Size(78, 24);
            PlasmaCheckbox.TabIndex = 2;
            PlasmaCheckbox.Text = "Plasma";
            PlasmaCheckbox.UseVisualStyleBackColor = true;
            // 
            // StormCheckbox
            // 
            StormCheckbox.AutoSize = true;
            StormCheckbox.Location = new Point(474, 41);
            StormCheckbox.Name = "StormCheckbox";
            StormCheckbox.Size = new Size(71, 24);
            StormCheckbox.TabIndex = 3;
            StormCheckbox.Text = "Storm";
            StormCheckbox.UseVisualStyleBackColor = true;
            // 
            // BarrenCheckbox
            // 
            BarrenCheckbox.AutoSize = true;
            BarrenCheckbox.Location = new Point(394, 41);
            BarrenCheckbox.Name = "BarrenCheckbox";
            BarrenCheckbox.Size = new Size(74, 24);
            BarrenCheckbox.TabIndex = 4;
            BarrenCheckbox.Text = "Barren";
            BarrenCheckbox.UseVisualStyleBackColor = true;
            // 
            // LavaCheckbox
            // 
            LavaCheckbox.AutoSize = true;
            LavaCheckbox.Location = new Point(327, 41);
            LavaCheckbox.Name = "LavaCheckbox";
            LavaCheckbox.Size = new Size(61, 24);
            LavaCheckbox.TabIndex = 5;
            LavaCheckbox.Text = "Lava";
            LavaCheckbox.UseVisualStyleBackColor = true;
            // 
            // OceanicCheckbox
            // 
            OceanicCheckbox.AutoSize = true;
            OceanicCheckbox.Location = new Point(237, 41);
            OceanicCheckbox.Name = "OceanicCheckbox";
            OceanicCheckbox.Size = new Size(84, 24);
            OceanicCheckbox.TabIndex = 6;
            OceanicCheckbox.Text = "Oceanic";
            OceanicCheckbox.UseVisualStyleBackColor = true;
            // 
            // GasCheckBox
            // 
            GasCheckBox.AutoSize = true;
            GasCheckBox.Location = new Point(176, 41);
            GasCheckBox.Name = "GasCheckBox";
            GasCheckBox.Size = new Size(55, 24);
            GasCheckBox.TabIndex = 7;
            GasCheckBox.Text = "Gas";
            GasCheckBox.UseVisualStyleBackColor = true;
            // 
            // IceCheckBox
            // 
            IceCheckBox.AutoSize = true;
            IceCheckBox.Location = new Point(120, 41);
            IceCheckBox.Name = "IceCheckBox";
            IceCheckBox.Size = new Size(50, 24);
            IceCheckBox.TabIndex = 8;
            IceCheckBox.Text = "Ice";
            IceCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinSecurityUpDown
            // 
            MinSecurityUpDown.DecimalPlaces = 1;
            MinSecurityUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            MinSecurityUpDown.Location = new Point(52, 106);
            MinSecurityUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            MinSecurityUpDown.Name = "MinSecurityUpDown";
            MinSecurityUpDown.Size = new Size(150, 27);
            MinSecurityUpDown.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 111);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 10;
            label1.Text = "Min";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 146);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(37, 20);
            label2.TabIndex = 12;
            label2.Text = "Max";
            // 
            // MaxSecurityUpDown
            // 
            MaxSecurityUpDown.DecimalPlaces = 1;
            MaxSecurityUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            MaxSecurityUpDown.Location = new Point(52, 139);
            MaxSecurityUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            MaxSecurityUpDown.Name = "MaxSecurityUpDown";
            MaxSecurityUpDown.Size = new Size(150, 27);
            MaxSecurityUpDown.TabIndex = 11;
            // 
            // WormholesCheckbox
            // 
            WormholesCheckbox.AutoSize = true;
            WormholesCheckbox.Location = new Point(219, 106);
            WormholesCheckbox.Name = "WormholesCheckbox";
            WormholesCheckbox.Size = new Size(158, 24);
            WormholesCheckbox.TabIndex = 13;
            WormholesCheckbox.Text = "Include Wormholes";
            WormholesCheckbox.UseVisualStyleBackColor = true;
            // 
            // IncludePochvenCheckbox
            // 
            IncludePochvenCheckbox.AutoSize = true;
            IncludePochvenCheckbox.Location = new Point(219, 136);
            IncludePochvenCheckbox.Name = "IncludePochvenCheckbox";
            IncludePochvenCheckbox.Size = new Size(137, 24);
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
            LoadingLabel.Location = new Point(130, 259);
            LoadingLabel.Name = "LoadingLabel";
            LoadingLabel.Size = new Size(72, 20);
            LoadingLabel.TabIndex = 16;
            LoadingLabel.Text = "Loading..";
            LoadingLabel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 18;
            label3.Text = "Has Planets";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(12, 78);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 19;
            label4.Text = "Security";
            // 
            // RegionCombobox
            // 
            RegionCombobox.FormattingEnabled = true;
            RegionCombobox.Location = new Point(80, 201);
            RegionCombobox.Name = "RegionCombobox";
            RegionCombobox.Size = new Size(151, 28);
            RegionCombobox.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 204);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 21;
            label5.Text = "Region";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(256, 204);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 22;
            label6.Text = "System Name";
            // 
            // SystemNameTextBox
            // 
            SystemNameTextBox.Location = new Point(362, 201);
            SystemNameTextBox.Name = "SystemNameTextBox";
            SystemNameTextBox.Size = new Size(125, 27);
            SystemNameTextBox.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(496, 76);
            label7.Name = "label7";
            label7.Size = new Size(64, 23);
            label7.TabIndex = 24;
            label7.Text = "Station";
            // 
            // StationComboBox
            // 
            StationComboBox.FormattingEnabled = true;
            StationComboBox.Location = new Point(456, 108);
            StationComboBox.Name = "StationComboBox";
            StationComboBox.Size = new Size(151, 28);
            StationComboBox.TabIndex = 25;
            // 
            // SystemFinder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 764);
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