namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class DatabaseSchema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSchema));
            TableTreeView = new TreeView();
            Tables = new Label();
            ColumnsGridView = new DataGridView();
            TableNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ColumnsGridView).BeginInit();
            SuspendLayout();
            // 
            // TableTreeView
            // 
            TableTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TableTreeView.Location = new Point(12, 29);
            TableTreeView.Name = "TableTreeView";
            TableTreeView.Size = new Size(189, 478);
            TableTreeView.TabIndex = 0;
            TableTreeView.AfterSelect += TableTreeView_AfterSelect;
            // 
            // Tables
            // 
            Tables.AutoSize = true;
            Tables.Location = new Point(12, 9);
            Tables.Name = "Tables";
            Tables.Size = new Size(39, 15);
            Tables.TabIndex = 1;
            Tables.Text = "Tables";
            // 
            // ColumnsGridView
            // 
            ColumnsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ColumnsGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            ColumnsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ColumnsGridView.GridColor = Color.FromArgb(21, 21, 21);
            ColumnsGridView.Location = new Point(222, 29);
            ColumnsGridView.Name = "ColumnsGridView";
            ColumnsGridView.Size = new Size(301, 486);
            ColumnsGridView.TabIndex = 2;
            // 
            // TableNameLabel
            // 
            TableNameLabel.AutoSize = true;
            TableNameLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TableNameLabel.Location = new Point(222, 5);
            TableNameLabel.Name = "TableNameLabel";
            TableNameLabel.Size = new Size(51, 20);
            TableNameLabel.TabIndex = 3;
            TableNameLabel.Text = "Name";
            // 
            // DatabaseSchema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 519);
            Controls.Add(TableNameLabel);
            Controls.Add(ColumnsGridView);
            Controls.Add(Tables);
            Controls.Add(TableTreeView);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "DatabaseSchema";
            Text = "Database Schema";
            ((System.ComponentModel.ISupportInitialize)ColumnsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView TableTreeView;
        private Label Tables;
        private DataGridView ColumnsGridView;
        private Label TableNameLabel;
    }
}