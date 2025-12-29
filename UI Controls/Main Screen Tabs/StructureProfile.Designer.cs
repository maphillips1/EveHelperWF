namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class StructureProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureProfile));
            StructureProfilesGrid = new EveHelperWF.Objects.Custom_Controls.EveHelperGridView();
            profileName = new DataGridViewTextBoxColumn();
            solarSystemID = new DataGridViewTextBoxColumn();
            structureTypeId = new DataGridViewTextBoxColumn();
            MERig = new DataGridViewTextBoxColumn();
            TERig = new DataGridViewTextBoxColumn();
            taxAmount = new DataGridViewTextBoxColumn();
            AddButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            EditButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            DeleteButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            ((System.ComponentModel.ISupportInitialize)StructureProfilesGrid).BeginInit();
            SuspendLayout();
            // 
            // StructureProfilesGrid
            // 
            StructureProfilesGrid.AllowUserToAddRows = false;
            StructureProfilesGrid.AllowUserToResizeRows = false;
            StructureProfilesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StructureProfilesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StructureProfilesGrid.BackgroundColor = Color.FromArgb(21, 21, 21);
            StructureProfilesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Gold;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            StructureProfilesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            StructureProfilesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StructureProfilesGrid.Columns.AddRange(new DataGridViewColumn[] { profileName, solarSystemID, structureTypeId, MERig, TERig, taxAmount });
            StructureProfilesGrid.EditableColumns = null;
            StructureProfilesGrid.EnableHeadersVisualStyles = false;
            StructureProfilesGrid.GridColor = Color.FromArgb(21, 21, 21);
            StructureProfilesGrid.Location = new Point(-1, 54);
            StructureProfilesGrid.MultiSelect = false;
            StructureProfilesGrid.Name = "StructureProfilesGrid";
            StructureProfilesGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            StructureProfilesGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            StructureProfilesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StructureProfilesGrid.Size = new Size(934, 464);
            StructureProfilesGrid.TabIndex = 0;
            StructureProfilesGrid.CellFormatting += StructureProfilesGrid_CellFormatting;
            // 
            // profileName
            // 
            profileName.DataPropertyName = "profileName";
            profileName.HeaderText = "Name";
            profileName.Name = "profileName";
            // 
            // solarSystemID
            // 
            solarSystemID.DataPropertyName = "solarSystemID";
            solarSystemID.HeaderText = "Solar System";
            solarSystemID.Name = "solarSystemID";
            // 
            // structureTypeId
            // 
            structureTypeId.DataPropertyName = "structureTypeId";
            structureTypeId.HeaderText = "structureTypeId";
            structureTypeId.Name = "structureTypeId";
            // 
            // MERig
            // 
            MERig.DataPropertyName = "MERig";
            MERig.HeaderText = "ME";
            MERig.Name = "MERig";
            // 
            // TERig
            // 
            TERig.DataPropertyName = "TERig";
            TERig.HeaderText = "TE";
            TERig.Name = "TERig";
            // 
            // taxAmount
            // 
            taxAmount.DataPropertyName = "taxAmount";
            taxAmount.HeaderText = "Tax";
            taxAmount.Name = "taxAmount";
            // 
            // AddButton
            // 
            AddButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AddButton.BorderBottom = false;
            AddButton.BorderFull = true;
            AddButton.BorderLeft = false;
            AddButton.BorderRight = false;
            AddButton.BorderTop = false;
            AddButton.BorderWidth = 2F;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.ForeColor = Color.FromArgb(234, 234, 234);
            AddButton.Location = new Point(10, 10);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(148, 38);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add Structure";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            EditButton.BorderBottom = false;
            EditButton.BorderFull = true;
            EditButton.BorderLeft = false;
            EditButton.BorderRight = false;
            EditButton.BorderTop = false;
            EditButton.BorderWidth = 2F;
            EditButton.FlatAppearance.BorderSize = 0;
            EditButton.FlatStyle = FlatStyle.Flat;
            EditButton.ForeColor = Color.FromArgb(234, 234, 234);
            EditButton.Location = new Point(174, 10);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(148, 38);
            EditButton.TabIndex = 2;
            EditButton.Text = "Edit Structure";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteButton.BorderBottom = false;
            DeleteButton.BorderFull = true;
            DeleteButton.BorderLeft = false;
            DeleteButton.BorderRight = false;
            DeleteButton.BorderTop = false;
            DeleteButton.BorderWidth = 2F;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.ForeColor = Color.FromArgb(234, 234, 234);
            DeleteButton.Location = new Point(339, 10);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(148, 38);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Delete Structure";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // StructureProfile
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(933, 519);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(StructureProfilesGrid);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "StructureProfile";
            Text = "Structure Profiles";
            FormClosing += StructureProfile_FormClosing;
            ((System.ComponentModel.ISupportInitialize)StructureProfilesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Objects.Custom_Controls.EveHelperGridView StructureProfilesGrid;
        private Objects.Custom_Controls.EveHelperButton AddButton;
        private Objects.Custom_Controls.EveHelperButton EditButton;
        private Objects.Custom_Controls.EveHelperButton DeleteButton;
        private DataGridViewTextBoxColumn profileName;
        private DataGridViewTextBoxColumn solarSystemID;
        private DataGridViewTextBoxColumn structureTypeId;
        private DataGridViewTextBoxColumn MERig;
        private DataGridViewTextBoxColumn TERig;
        private DataGridViewTextBoxColumn taxAmount;
    }
}