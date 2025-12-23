namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class BlueprintValueControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueprintValueControl));
            MELabel = new Label();
            TELabel = new Label();
            MaxRunsLabel = new Label();
            MEUpDown = new NumericUpDown();
            TEUpDown = new NumericUpDown();
            MaxRunsUpDown = new NumericUpDown();
            SaveButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            CancelButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            label1 = new Label();
            ExcludeFPCheckbox = new CheckBox();
            ExcludeFPLabel = new Label();
            MakeItemCombo = new ComboBox();
            StructureProfileCombo = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)MEUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TEUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxRunsUpDown).BeginInit();
            SuspendLayout();
            // 
            // MELabel
            // 
            MELabel.AutoSize = true;
            MELabel.Font = new Font("Segoe UI", 12F);
            MELabel.Location = new Point(12, 63);
            MELabel.Name = "MELabel";
            MELabel.Size = new Size(32, 21);
            MELabel.TabIndex = 0;
            MELabel.Text = "ME";
            // 
            // TELabel
            // 
            TELabel.AutoSize = true;
            TELabel.Font = new Font("Segoe UI", 12F);
            TELabel.Location = new Point(12, 103);
            TELabel.Name = "TELabel";
            TELabel.Size = new Size(26, 21);
            TELabel.TabIndex = 1;
            TELabel.Text = "TE";
            // 
            // MaxRunsLabel
            // 
            MaxRunsLabel.AutoSize = true;
            MaxRunsLabel.Font = new Font("Segoe UI", 12F);
            MaxRunsLabel.Location = new Point(12, 23);
            MaxRunsLabel.Name = "MaxRunsLabel";
            MaxRunsLabel.Size = new Size(78, 21);
            MaxRunsLabel.TabIndex = 2;
            MaxRunsLabel.Text = "Max Runs";
            // 
            // MEUpDown
            // 
            MEUpDown.Location = new Point(140, 63);
            MEUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            MEUpDown.Name = "MEUpDown";
            MEUpDown.Size = new Size(120, 23);
            MEUpDown.TabIndex = 3;
            MEUpDown.KeyDown += Numeric_KeyDown;
            // 
            // TEUpDown
            // 
            TEUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            TEUpDown.Location = new Point(140, 103);
            TEUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            TEUpDown.Name = "TEUpDown";
            TEUpDown.Size = new Size(120, 23);
            TEUpDown.TabIndex = 4;
            TEUpDown.KeyDown += Numeric_KeyDown;
            // 
            // MaxRunsUpDown
            // 
            MaxRunsUpDown.Location = new Point(140, 23);
            MaxRunsUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            MaxRunsUpDown.Name = "MaxRunsUpDown";
            MaxRunsUpDown.Size = new Size(120, 23);
            MaxRunsUpDown.TabIndex = 5;
            MaxRunsUpDown.KeyDown += Numeric_KeyDown;
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
            SaveButton.Font = new Font("Segoe UI", 9.75F);
            SaveButton.ForeColor = Color.FromArgb(234, 234, 234);
            SaveButton.Location = new Point(31, 284);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
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
            CancelButton.Font = new Font("Segoe UI", 9.75F);
            CancelButton.ForeColor = Color.FromArgb(234, 234, 234);
            CancelButton.Location = new Point(140, 284);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 143);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 8;
            label1.Text = "Make Item";
            // 
            // ExcludeFPCheckbox
            // 
            ExcludeFPCheckbox.AutoSize = true;
            ExcludeFPCheckbox.Checked = true;
            ExcludeFPCheckbox.CheckState = CheckState.Checked;
            ExcludeFPCheckbox.Location = new Point(165, 235);
            ExcludeFPCheckbox.Name = "ExcludeFPCheckbox";
            ExcludeFPCheckbox.Size = new Size(15, 14);
            ExcludeFPCheckbox.TabIndex = 11;
            ExcludeFPCheckbox.UseVisualStyleBackColor = true;
            // 
            // ExcludeFPLabel
            // 
            ExcludeFPLabel.AutoSize = true;
            ExcludeFPLabel.Font = new Font("Segoe UI", 12F);
            ExcludeFPLabel.Location = new Point(2, 228);
            ExcludeFPLabel.Name = "ExcludeFPLabel";
            ExcludeFPLabel.Size = new Size(157, 21);
            ExcludeFPLabel.TabIndex = 10;
            ExcludeFPLabel.Text = "Exclude Final Product";
            // 
            // MakeItemCombo
            // 
            MakeItemCombo.FormattingEnabled = true;
            MakeItemCombo.Location = new Point(140, 143);
            MakeItemCombo.Name = "MakeItemCombo";
            MakeItemCombo.Size = new Size(121, 23);
            MakeItemCombo.TabIndex = 12;
            // 
            // StructureProfileCombo
            // 
            StructureProfileCombo.FormattingEnabled = true;
            StructureProfileCombo.Location = new Point(140, 183);
            StructureProfileCombo.Name = "StructureProfileCombo";
            StructureProfileCombo.Size = new Size(121, 23);
            StructureProfileCombo.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 183);
            label2.Name = "label2";
            label2.Size = new Size(122, 21);
            label2.TabIndex = 13;
            label2.Text = "Structure Profile";
            // 
            // BlueprintValueControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 337);
            Controls.Add(StructureProfileCombo);
            Controls.Add(label2);
            Controls.Add(MakeItemCombo);
            Controls.Add(ExcludeFPCheckbox);
            Controls.Add(ExcludeFPLabel);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(MaxRunsUpDown);
            Controls.Add(TEUpDown);
            Controls.Add(MEUpDown);
            Controls.Add(MaxRunsLabel);
            Controls.Add(TELabel);
            Controls.Add(MELabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "BlueprintValueControl";
            Text = "BP Values";
            ((System.ComponentModel.ISupportInitialize)MEUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)TEUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxRunsUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MELabel;
        private Label TELabel;
        private Label MaxRunsLabel;
        public NumericUpDown MEUpDown;
        public NumericUpDown TEUpDown;
        public NumericUpDown MaxRunsUpDown;
        private Objects.Custom_Controls.EveHelperButton SaveButton;
        private Objects.Custom_Controls.EveHelperButton CancelButton;
        private Label label1;
        public CheckBox ExcludeFPCheckbox;
        private Label ExcludeFPLabel;
        public ComboBox MakeItemCombo;
        public ComboBox StructureProfileCombo;
        private Label label2;
    }
}