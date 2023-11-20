namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class AbyssTracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbyssTracker));
            splitContainer1 = new SplitContainer();
            AddRunButton = new Button();
            label5 = new Label();
            LootTextBox = new TextBox();
            SuccessCheckbox = new CheckBox();
            ShipTypeCombo = new ComboBox();
            FilamentTypeCombo = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            DeleteRunButton = new Button();
            AverageLootLabel = new Label();
            TotalFilamentCostLabel = new Label();
            TotalLootValueLabel = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            AbyssTrackerGridView = new DataGridView();
            abyssRunID = new DataGridViewTextBoxColumn();
            FilamentName = new DataGridViewTextBoxColumn();
            FilamentCost = new DataGridViewTextBoxColumn();
            LootValue = new DataGridViewTextBoxColumn();
            Success = new DataGridViewTextBoxColumn();
            ShipType = new DataGridViewTextBoxColumn();
            loot = new DataGridViewTextBoxColumn();
            FilamentType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AbyssTrackerGridView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(AddRunButton);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(LootTextBox);
            splitContainer1.Panel1.Controls.Add(SuccessCheckbox);
            splitContainer1.Panel1.Controls.Add(ShipTypeCombo);
            splitContainer1.Panel1.Controls.Add(FilamentTypeCombo);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DeleteRunButton);
            splitContainer1.Panel2.Controls.Add(AverageLootLabel);
            splitContainer1.Panel2.Controls.Add(TotalFilamentCostLabel);
            splitContainer1.Panel2.Controls.Add(TotalLootValueLabel);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(AbyssTrackerGridView);
            splitContainer1.Size = new Size(1415, 751);
            splitContainer1.SplitterDistance = 491;
            splitContainer1.TabIndex = 0;
            // 
            // AddRunButton
            // 
            AddRunButton.ForeColor = Color.Black;
            AddRunButton.Location = new Point(380, 192);
            AddRunButton.Name = "AddRunButton";
            AddRunButton.Size = new Size(94, 29);
            AddRunButton.TabIndex = 10;
            AddRunButton.Text = "Add Run";
            AddRunButton.UseVisualStyleBackColor = true;
            AddRunButton.Click += AddRunButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 196);
            label5.Name = "label5";
            label5.Size = new Size(180, 20);
            label5.TabIndex = 9;
            label5.Text = "Copy and Paste Loot Here";
            // 
            // LootTextBox
            // 
            LootTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LootTextBox.Location = new Point(12, 229);
            LootTextBox.Multiline = true;
            LootTextBox.Name = "LootTextBox";
            LootTextBox.Size = new Size(462, 510);
            LootTextBox.TabIndex = 8;
            LootTextBox.TextChanged += LootTextBox_TextChanged;
            // 
            // SuccessCheckbox
            // 
            SuccessCheckbox.AutoSize = true;
            SuccessCheckbox.Location = new Point(133, 143);
            SuccessCheckbox.Name = "SuccessCheckbox";
            SuccessCheckbox.Size = new Size(18, 17);
            SuccessCheckbox.TabIndex = 7;
            SuccessCheckbox.UseVisualStyleBackColor = true;
            // 
            // ShipTypeCombo
            // 
            ShipTypeCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            ShipTypeCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            ShipTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ShipTypeCombo.FormattingEnabled = true;
            ShipTypeCombo.Location = new Point(133, 109);
            ShipTypeCombo.Name = "ShipTypeCombo";
            ShipTypeCombo.Size = new Size(151, 28);
            ShipTypeCombo.TabIndex = 6;
            // 
            // FilamentTypeCombo
            // 
            FilamentTypeCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            FilamentTypeCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            FilamentTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            FilamentTypeCombo.FormattingEnabled = true;
            FilamentTypeCombo.Location = new Point(133, 74);
            FilamentTypeCombo.Name = "FilamentTypeCombo";
            FilamentTypeCombo.Size = new Size(151, 28);
            FilamentTypeCombo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 140);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 3;
            label4.Text = "Success";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 109);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Ship Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(115, 23);
            label2.TabIndex = 1;
            label2.Text = "Filament Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(154, 28);
            label1.TabIndex = 0;
            label1.Text = "Add Abyss Run";
            // 
            // DeleteRunButton
            // 
            DeleteRunButton.ForeColor = Color.Black;
            DeleteRunButton.Location = new Point(494, 192);
            DeleteRunButton.Name = "DeleteRunButton";
            DeleteRunButton.Size = new Size(94, 29);
            DeleteRunButton.TabIndex = 7;
            DeleteRunButton.Text = "Delete Run";
            DeleteRunButton.UseVisualStyleBackColor = true;
            DeleteRunButton.Click += DeleteRunButton_Click;
            // 
            // AverageLootLabel
            // 
            AverageLootLabel.AutoSize = true;
            AverageLootLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            AverageLootLabel.Location = new Point(240, 94);
            AverageLootLabel.Name = "AverageLootLabel";
            AverageLootLabel.Size = new Size(192, 25);
            AverageLootLabel.TabIndex = 6;
            AverageLootLabel.Text = "[Average Loot / Run]";
            // 
            // TotalFilamentCostLabel
            // 
            TotalFilamentCostLabel.AutoSize = true;
            TotalFilamentCostLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            TotalFilamentCostLabel.Location = new Point(240, 56);
            TotalFilamentCostLabel.Name = "TotalFilamentCostLabel";
            TotalFilamentCostLabel.Size = new Size(188, 25);
            TotalFilamentCostLabel.TabIndex = 5;
            TotalFilamentCostLabel.Text = "[Total Filament Cost]";
            // 
            // TotalLootValueLabel
            // 
            TotalLootValueLabel.AutoSize = true;
            TotalLootValueLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            TotalLootValueLabel.Location = new Point(240, 22);
            TotalLootValueLabel.Name = "TotalLootValueLabel";
            TotalLootValueLabel.Size = new Size(163, 25);
            TotalLootValueLabel.TabIndex = 4;
            TotalLootValueLabel.Text = "[Total Loot Value]";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(18, 94);
            label8.Name = "label8";
            label8.Size = new Size(178, 25);
            label8.TabIndex = 3;
            label8.Text = "Average Loot / Run";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(22, 56);
            label7.Name = "label7";
            label7.Size = new Size(174, 25);
            label7.TabIndex = 2;
            label7.Text = "Total Filament Cost";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(47, 22);
            label6.Name = "label6";
            label6.Size = new Size(149, 25);
            label6.TabIndex = 1;
            label6.Text = "Total Loot Value";
            // 
            // AbyssTrackerGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            AbyssTrackerGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            AbyssTrackerGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AbyssTrackerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AbyssTrackerGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AbyssTrackerGridView.BackgroundColor = Color.Black;
            AbyssTrackerGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AbyssTrackerGridView.Columns.AddRange(new DataGridViewColumn[] { abyssRunID, FilamentName, FilamentCost, LootValue, Success, ShipType, loot, FilamentType });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            AbyssTrackerGridView.DefaultCellStyle = dataGridViewCellStyle3;
            AbyssTrackerGridView.GridColor = Color.White;
            AbyssTrackerGridView.Location = new Point(22, 229);
            AbyssTrackerGridView.MultiSelect = false;
            AbyssTrackerGridView.Name = "AbyssTrackerGridView";
            AbyssTrackerGridView.ReadOnly = true;
            AbyssTrackerGridView.RowHeadersWidth = 51;
            AbyssTrackerGridView.RowTemplate.Height = 29;
            AbyssTrackerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AbyssTrackerGridView.Size = new Size(886, 510);
            AbyssTrackerGridView.TabIndex = 0;
            // 
            // abyssRunID
            // 
            abyssRunID.DataPropertyName = "AbyssRunID";
            abyssRunID.HeaderText = "Run ID";
            abyssRunID.MinimumWidth = 6;
            abyssRunID.Name = "abyssRunID";
            abyssRunID.ReadOnly = true;
            abyssRunID.Width = 82;
            // 
            // FilamentName
            // 
            FilamentName.DataPropertyName = "FilamentName";
            FilamentName.HeaderText = "Filament Name";
            FilamentName.MinimumWidth = 6;
            FilamentName.Name = "FilamentName";
            FilamentName.ReadOnly = true;
            FilamentName.Width = 139;
            // 
            // FilamentCost
            // 
            FilamentCost.DataPropertyName = "FilamentCost";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            FilamentCost.DefaultCellStyle = dataGridViewCellStyle2;
            FilamentCost.HeaderText = "FilamentCost";
            FilamentCost.MinimumWidth = 6;
            FilamentCost.Name = "FilamentCost";
            FilamentCost.ReadOnly = true;
            FilamentCost.Width = 124;
            // 
            // LootValue
            // 
            LootValue.DataPropertyName = "LootValue";
            LootValue.HeaderText = "Loot Value (Buy)";
            LootValue.MinimumWidth = 6;
            LootValue.Name = "LootValue";
            LootValue.ReadOnly = true;
            LootValue.Width = 146;
            // 
            // Success
            // 
            Success.DataPropertyName = "Success";
            Success.HeaderText = "Success";
            Success.MinimumWidth = 6;
            Success.Name = "Success";
            Success.ReadOnly = true;
            Success.Width = 88;
            // 
            // ShipType
            // 
            ShipType.DataPropertyName = "ShipType";
            ShipType.HeaderText = "Ship Type";
            ShipType.MinimumWidth = 6;
            ShipType.Name = "ShipType";
            ShipType.ReadOnly = true;
            ShipType.Width = 102;
            // 
            // loot
            // 
            loot.DataPropertyName = "Loot";
            loot.HeaderText = "Loot";
            loot.MinimumWidth = 6;
            loot.Name = "loot";
            loot.ReadOnly = true;
            loot.Visible = false;
            loot.Width = 68;
            // 
            // FilamentType
            // 
            FilamentType.DataPropertyName = "FilamentType";
            FilamentType.HeaderText = "Filament Type";
            FilamentType.MinimumWidth = 6;
            FilamentType.Name = "FilamentType";
            FilamentType.ReadOnly = true;
            FilamentType.Visible = false;
            FilamentType.Width = 130;
            // 
            // AbyssTracker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1415, 751);
            Controls.Add(splitContainer1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AbyssTracker";
            Text = "Abyss Tracker";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AbyssTrackerGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private CheckBox SuccessCheckbox;
        private ComboBox ShipTypeCombo;
        private ComboBox FilamentTypeCombo;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox LootTextBox;
        private Label label5;
        private Button AddRunButton;
        private DataGridView AbyssTrackerGridView;
        private Label AverageLootLabel;
        private Label TotalFilamentCostLabel;
        private Label TotalLootValueLabel;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button DeleteRunButton;
        private DataGridViewTextBoxColumn abyssRunID;
        private DataGridViewTextBoxColumn FilamentName;
        private DataGridViewTextBoxColumn FilamentCost;
        private DataGridViewTextBoxColumn LootValue;
        private DataGridViewTextBoxColumn Success;
        private DataGridViewTextBoxColumn ShipType;
        private DataGridViewTextBoxColumn loot;
        private DataGridViewTextBoxColumn FilamentType;
    }
}