namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class AddFromFitForm
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
            Label InfoLabel;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFromFitForm));
            FitTextBox = new TextBox();
            SaveButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            CancelButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            FinalProductGrid = new EveHelperWF.Objects.Custom_Controls.EveHelperGridView();
            DeleteItem = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            finalProductTypeName = new DataGridViewTextBoxColumn();
            InfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)FinalProductGrid).BeginInit();
            SuspendLayout();
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InfoLabel.Location = new Point(12, 9);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(269, 20);
            InfoLabel.TabIndex = 0;
            InfoLabel.Text = "Copy and Paste From Fitting Window";
            // 
            // FitTextBox
            // 
            FitTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FitTextBox.Location = new Point(12, 32);
            FitTextBox.Multiline = true;
            FitTextBox.Name = "FitTextBox";
            FitTextBox.PlaceholderText = "Copy and Paste from the Fitting Window";
            FitTextBox.ScrollBars = ScrollBars.Vertical;
            FitTextBox.Size = new Size(909, 229);
            FitTextBox.TabIndex = 1;
            FitTextBox.TextChanged += FitTextBox_TextChanged;
            // 
            // SaveButton
            // 
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.FromArgb(234, 234, 234);
            SaveButton.Location = new Point(12, 699);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(155, 23);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.ForeColor = Color.FromArgb(234, 234, 234);
            CancelButton.Location = new Point(218, 699);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(155, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // FinalProductGrid
            // 
            FinalProductGrid.AllowUserToAddRows = false;
            FinalProductGrid.AllowUserToResizeRows = false;
            FinalProductGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FinalProductGrid.BackgroundColor = Color.FromArgb(21, 21, 21);
            FinalProductGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Gold;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            FinalProductGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            FinalProductGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FinalProductGrid.Columns.AddRange(new DataGridViewColumn[] { finalProductTypeName });
            FinalProductGrid.EnableHeadersVisualStyles = false;
            FinalProductGrid.GridColor = Color.FromArgb(21, 21, 21);
            FinalProductGrid.Location = new Point(12, 360);
            FinalProductGrid.Name = "FinalProductGrid";
            FinalProductGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            FinalProductGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            FinalProductGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FinalProductGrid.Size = new Size(901, 299);
            FinalProductGrid.TabIndex = 4;
            // 
            // DeleteItem
            // 
            DeleteItem.FlatAppearance.BorderSize = 0;
            DeleteItem.FlatStyle = FlatStyle.Flat;
            DeleteItem.ForeColor = Color.FromArgb(234, 234, 234);
            DeleteItem.Location = new Point(12, 331);
            DeleteItem.Name = "DeleteItem";
            DeleteItem.Size = new Size(197, 23);
            DeleteItem.TabIndex = 5;
            DeleteItem.Text = "Delete Item";
            DeleteItem.UseVisualStyleBackColor = false;
            DeleteItem.Click += DeleteItem_Click;
            // 
            // finalProductTypeName
            // 
            finalProductTypeName.DataPropertyName = "finalProductTypeName";
            finalProductTypeName.HeaderText = "Blueprint Name";
            finalProductTypeName.Name = "finalProductTypeName";
            // 
            // AddFromFitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 743);
            Controls.Add(DeleteItem);
            Controls.Add(FinalProductGrid);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(FitTextBox);
            Controls.Add(InfoLabel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddFromFitForm";
            Text = "Add From Fit";
            ((System.ComponentModel.ISupportInitialize)FinalProductGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FitTextBox;
        private Objects.Custom_Controls.EveHelperButton SaveButton;
        private Objects.Custom_Controls.EveHelperButton CancelButton;
        private Objects.Custom_Controls.EveHelperGridView FinalProductGrid;
        private Objects.Custom_Controls.EveHelperButton DeleteItem;
        private DataGridViewTextBoxColumn finalProductTypeName;
    }
}