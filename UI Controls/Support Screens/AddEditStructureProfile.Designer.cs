namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class AddEditStructureProfile
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
            Label ProfileNameLabel;
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditStructureProfile));
            ProfileNameTextBox = new TextBox();
            StructureTypeCombo = new ComboBox();
            SolarSystemCombo = new ComboBox();
            MERigCombo = new ComboBox();
            TERigCombo = new ComboBox();
            TaxAmountNumeric = new NumericUpDown();
            SaveButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            CancelButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            ProfileNameLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)TaxAmountNumeric).BeginInit();
            SuspendLayout();
            // 
            // ProfileNameLabel
            // 
            ProfileNameLabel.AutoSize = true;
            ProfileNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProfileNameLabel.Location = new Point(21, 46);
            ProfileNameLabel.Name = "ProfileNameLabel";
            ProfileNameLabel.Size = new Size(101, 21);
            ProfileNameLabel.TabIndex = 1;
            ProfileNameLabel.Text = "Profile Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 126);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 2;
            label1.Text = "Solar System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 86);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 3;
            label2.Text = "Structure Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 166);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 4;
            label3.Text = "ME Rig";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 206);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 5;
            label4.Text = "TE Rig";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 246);
            label5.Name = "label5";
            label5.Size = new Size(31, 21);
            label5.TabIndex = 6;
            label5.Text = "Tax";
            // 
            // ProfileNameTextBox
            // 
            ProfileNameTextBox.Location = new Point(146, 46);
            ProfileNameTextBox.MaxLength = 256;
            ProfileNameTextBox.Name = "ProfileNameTextBox";
            ProfileNameTextBox.Size = new Size(361, 23);
            ProfileNameTextBox.TabIndex = 0;
            // 
            // StructureTypeCombo
            // 
            StructureTypeCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            StructureTypeCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            StructureTypeCombo.FormattingEnabled = true;
            StructureTypeCombo.Location = new Point(146, 88);
            StructureTypeCombo.Name = "StructureTypeCombo";
            StructureTypeCombo.Size = new Size(361, 23);
            StructureTypeCombo.TabIndex = 7;
            // 
            // SolarSystemCombo
            // 
            SolarSystemCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            SolarSystemCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            SolarSystemCombo.FormattingEnabled = true;
            SolarSystemCombo.Location = new Point(146, 128);
            SolarSystemCombo.Name = "SolarSystemCombo";
            SolarSystemCombo.Size = new Size(361, 23);
            SolarSystemCombo.TabIndex = 8;
            // 
            // MERigCombo
            // 
            MERigCombo.FormattingEnabled = true;
            MERigCombo.Location = new Point(146, 168);
            MERigCombo.Name = "MERigCombo";
            MERigCombo.Size = new Size(361, 23);
            MERigCombo.TabIndex = 9;
            // 
            // TERigCombo
            // 
            TERigCombo.FormattingEnabled = true;
            TERigCombo.Location = new Point(146, 208);
            TERigCombo.Name = "TERigCombo";
            TERigCombo.Size = new Size(361, 23);
            TERigCombo.TabIndex = 10;
            // 
            // TaxAmountNumeric
            // 
            TaxAmountNumeric.DecimalPlaces = 2;
            TaxAmountNumeric.Location = new Point(146, 249);
            TaxAmountNumeric.Name = "TaxAmountNumeric";
            TaxAmountNumeric.Size = new Size(120, 23);
            TaxAmountNumeric.TabIndex = 11;
            // 
            // SaveButton
            // 
            SaveButton.BorderBottom = false;
            SaveButton.BorderFull = true;
            SaveButton.BorderLeft = false;
            SaveButton.BorderRight = false;
            SaveButton.BorderTop = false;
            SaveButton.BorderWidth = 2F;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.FromArgb(234, 234, 234);
            SaveButton.Location = new Point(21, 5);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // CancelButton
            // 
            CancelButton.BorderBottom = false;
            CancelButton.BorderFull = true;
            CancelButton.BorderLeft = false;
            CancelButton.BorderRight = false;
            CancelButton.BorderTop = false;
            CancelButton.BorderWidth = 2F;
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.ForeColor = Color.FromArgb(234, 234, 234);
            CancelButton.Location = new Point(111, 5);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            // 
            // AddEditStructureProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 289);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(TaxAmountNumeric);
            Controls.Add(TERigCombo);
            Controls.Add(MERigCombo);
            Controls.Add(SolarSystemCombo);
            Controls.Add(StructureTypeCombo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ProfileNameLabel);
            Controls.Add(ProfileNameTextBox);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddEditStructureProfile";
            Text = "Structure Profile Info";
            ((System.ComponentModel.ISupportInitialize)TaxAmountNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ProfileNameTextBox;
        private ComboBox StructureTypeCombo;
        private ComboBox SolarSystemCombo;
        private ComboBox MERigCombo;
        private ComboBox TERigCombo;
        private NumericUpDown TaxAmountNumeric;
        public Objects.Custom_Controls.EveHelperButton SaveButton;
        public Objects.Custom_Controls.EveHelperButton CancelButton;
    }
}