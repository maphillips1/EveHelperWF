namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class HunterIntelSearchResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HunterIntelSearchResult));
            label1 = new Label();
            SearchResultsGrid = new Objects.Custom_Controls.EveHelperGridView();
            ResultName = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            ResultType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)SearchResultsGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(444, 21);
            label1.TabIndex = 0;
            label1.Text = "Select from the list of results below by double-clicking the row.";
            // 
            // SearchResultsGrid
            // 
            SearchResultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SearchResultsGrid.BackgroundColor = Color.FromArgb(21, 21, 21);
            SearchResultsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchResultsGrid.Columns.AddRange(new DataGridViewColumn[] { ResultName, ID, ResultType });
            SearchResultsGrid.EditableColumns = null;
            SearchResultsGrid.GridColor = Color.FromArgb(21, 21, 21);
            SearchResultsGrid.Location = new Point(12, 59);
            SearchResultsGrid.MultiSelect = false;
            SearchResultsGrid.Name = "SearchResultsGrid";
            SearchResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SearchResultsGrid.Size = new Size(558, 448);
            SearchResultsGrid.TabIndex = 1;
            SearchResultsGrid.DoubleClick += SearchResultsGrid_DoubleClick;
            // 
            // ResultName
            // 
            ResultName.DataPropertyName = "name";
            dataGridViewCellStyle1.BackColor = Color.FromArgb(21, 21, 21);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(234, 234, 234);
            ResultName.DefaultCellStyle = dataGridViewCellStyle1;
            ResultName.HeaderText = "Name";
            ResultName.Name = "ResultName";
            // 
            // ID
            // 
            ID.DataPropertyName = "id";
            ID.DefaultCellStyle = dataGridViewCellStyle1;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // ResultType
            // 
            ResultType.DataPropertyName = "resultType";
            ResultType.DefaultCellStyle = dataGridViewCellStyle1;
            ResultType.HeaderText = "ResultType";
            ResultType.Name = "ResultType";
            // 
            // HunterIntelSearchResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 519);
            Controls.Add(SearchResultsGrid);
            Controls.Add(label1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "HunterIntelSearchResult";
            Text = "HunterIntelSearchResult";
            ((System.ComponentModel.ISupportInitialize)SearchResultsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Objects.Custom_Controls.EveHelperGridView SearchResultsGrid;
        private DataGridViewTextBoxColumn ResultName;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ResultType;
    }
}