namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class BuildPlanDetailsTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label44;
            Label label48;
            Label label46;
            Label label47;
            Label label45;
            Label label20;
            Label label43;
            Label label42;
            Label label17;
            Label label16;
            Label label12;
            ClearCompletedButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            ExportBuildList = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            TotalManufacturingSlotsLabel = new Label();
            TotalReactionSlotsLabel = new Label();
            OptimizedBuildTreeView = new TreeView();
            CollapseAllButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            MaterialsTreeView = new TreeView();
            DetailsProductLabel = new Label();
            DetailsImagePanel = new Panel();
            SaveFileDialog = new SaveFileDialog();
            label44 = new Label();
            label48 = new Label();
            label46 = new Label();
            label47 = new Label();
            label45 = new Label();
            label20 = new Label();
            label43 = new Label();
            label42 = new Label();
            label17 = new Label();
            label16 = new Label();
            label12 = new Label();
            SuspendLayout();
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label44.ForeColor = Color.Tomato;
            label44.Location = new Point(771, 278);
            label44.Name = "label44";
            label44.Size = new Size(160, 17);
            label44.TabIndex = 45;
            label44.Text = "This list is in build order";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label48.Location = new Point(297, 50);
            label48.Name = "label48";
            label48.Size = new Size(180, 17);
            label48.TabIndex = 42;
            label48.Text = "Total Industry Slots Needed";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label46.Location = new Point(281, 72);
            label46.Name = "label46";
            label46.Size = new Size(99, 17);
            label46.TabIndex = 41;
            label46.Text = "Manufacturing";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label47.Location = new Point(313, 91);
            label47.Name = "label47";
            label47.Size = new Size(67, 17);
            label47.TabIndex = 40;
            label47.Text = "Reactions";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label45.Location = new Point(78, 108);
            label45.Name = "label45";
            label45.Size = new Size(201, 21);
            label45.TabIndex = 39;
            label45.Text = "Optimum Build Schedule";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label20.Location = new Point(771, 246);
            label20.Name = "label20";
            label20.Size = new Size(162, 17);
            label20.TabIndex = 37;
            label20.Text = "Other Gathered Resource";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label43.ForeColor = Color.Chartreuse;
            label43.Location = new Point(771, 166);
            label43.Name = "label43";
            label43.Size = new Size(92, 17);
            label43.TabIndex = 36;
            label43.Text = "Raw Resource";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label42.ForeColor = Color.Cyan;
            label42.Location = new Point(771, 186);
            label42.Name = "label42";
            label42.Size = new Size(126, 17);
            label42.TabIndex = 35;
            label42.Text = "Manufactured Item";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label17.ForeColor = Color.DarkOrange;
            label17.Location = new Point(771, 226);
            label17.Name = "label17";
            label17.Size = new Size(128, 17);
            label17.TabIndex = 34;
            label17.Text = "Planetary Materials";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label16.ForeColor = Color.MediumPurple;
            label16.Location = new Point(771, 206);
            label16.Name = "label16";
            label16.Size = new Size(88, 17);
            label16.TabIndex = 33;
            label16.Text = "Reacted Item";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label12.Location = new Point(771, 144);
            label12.Name = "label12";
            label12.Size = new Size(53, 17);
            label12.TabIndex = 32;
            label12.Text = "Legend";
            // 
            // ClearCompletedButton
            // 
            ClearCompletedButton.BorderBottom = false;
            ClearCompletedButton.BorderFull = true;
            ClearCompletedButton.BorderLeft = false;
            ClearCompletedButton.BorderRight = false;
            ClearCompletedButton.BorderTop = false;
            ClearCompletedButton.BorderWidth = 2F;
            ClearCompletedButton.FlatAppearance.BorderSize = 0;
            ClearCompletedButton.FlatStyle = FlatStyle.Flat;
            ClearCompletedButton.ForeColor = Color.FromArgb(234, 234, 234);
            ClearCompletedButton.Location = new Point(78, 44);
            ClearCompletedButton.Name = "ClearCompletedButton";
            ClearCompletedButton.Size = new Size(169, 23);
            ClearCompletedButton.TabIndex = 47;
            ClearCompletedButton.Text = "Clear Completed Builds";
            ClearCompletedButton.UseVisualStyleBackColor = false;
            // 
            // ExportBuildList
            // 
            ExportBuildList.BorderBottom = false;
            ExportBuildList.BorderFull = true;
            ExportBuildList.BorderLeft = false;
            ExportBuildList.BorderRight = false;
            ExportBuildList.BorderTop = false;
            ExportBuildList.BorderWidth = 2F;
            ExportBuildList.FlatAppearance.BorderSize = 0;
            ExportBuildList.FlatStyle = FlatStyle.Flat;
            ExportBuildList.ForeColor = Color.FromArgb(234, 234, 234);
            ExportBuildList.Location = new Point(78, 77);
            ExportBuildList.Name = "ExportBuildList";
            ExportBuildList.Size = new Size(169, 23);
            ExportBuildList.TabIndex = 46;
            ExportBuildList.Text = "Export Build List";
            ExportBuildList.UseVisualStyleBackColor = false;
            ExportBuildList.Click += ExportBuildListButton_Click;
            // 
            // TotalManufacturingSlotsLabel
            // 
            TotalManufacturingSlotsLabel.AutoSize = true;
            TotalManufacturingSlotsLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            TotalManufacturingSlotsLabel.ForeColor = Color.Cyan;
            TotalManufacturingSlotsLabel.Location = new Point(390, 72);
            TotalManufacturingSlotsLabel.Name = "TotalManufacturingSlotsLabel";
            TotalManufacturingSlotsLabel.Size = new Size(99, 17);
            TotalManufacturingSlotsLabel.TabIndex = 44;
            TotalManufacturingSlotsLabel.Text = "Manufacturing";
            // 
            // TotalReactionSlotsLabel
            // 
            TotalReactionSlotsLabel.AutoSize = true;
            TotalReactionSlotsLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            TotalReactionSlotsLabel.ForeColor = Color.MediumPurple;
            TotalReactionSlotsLabel.Location = new Point(390, 91);
            TotalReactionSlotsLabel.Name = "TotalReactionSlotsLabel";
            TotalReactionSlotsLabel.Size = new Size(67, 17);
            TotalReactionSlotsLabel.TabIndex = 43;
            TotalReactionSlotsLabel.Text = "Reactions";
            // 
            // OptimizedBuildTreeView
            // 
            OptimizedBuildTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            OptimizedBuildTreeView.BackColor = Color.FromArgb(21, 21, 21);
            OptimizedBuildTreeView.BorderStyle = BorderStyle.None;
            OptimizedBuildTreeView.CausesValidation = false;
            OptimizedBuildTreeView.CheckBoxes = true;
            OptimizedBuildTreeView.Font = new Font("Segoe UI", 12F);
            OptimizedBuildTreeView.ForeColor = Color.White;
            OptimizedBuildTreeView.HotTracking = true;
            OptimizedBuildTreeView.ItemHeight = 30;
            OptimizedBuildTreeView.Location = new Point(8, 133);
            OptimizedBuildTreeView.MinimumSize = new Size(483, 393);
            OptimizedBuildTreeView.Name = "OptimizedBuildTreeView";
            OptimizedBuildTreeView.Size = new Size(757, 393);
            OptimizedBuildTreeView.TabIndex = 38;
            OptimizedBuildTreeView.TabStop = false;
            OptimizedBuildTreeView.AfterSelect += OptimizedBuildTreeView_AfterSelect;
            // 
            // CollapseAllButton
            // 
            CollapseAllButton.BorderBottom = false;
            CollapseAllButton.BorderFull = true;
            CollapseAllButton.BorderLeft = false;
            CollapseAllButton.BorderRight = false;
            CollapseAllButton.BorderTop = false;
            CollapseAllButton.BorderWidth = 2F;
            CollapseAllButton.FlatAppearance.BorderSize = 0;
            CollapseAllButton.FlatStyle = FlatStyle.Flat;
            CollapseAllButton.ForeColor = Color.FromArgb(234, 234, 234);
            CollapseAllButton.Location = new Point(939, 70);
            CollapseAllButton.Name = "CollapseAllButton";
            CollapseAllButton.Size = new Size(94, 23);
            CollapseAllButton.TabIndex = 31;
            CollapseAllButton.Text = "Collapse All";
            CollapseAllButton.UseVisualStyleBackColor = false;
            CollapseAllButton.Click += CollapseAllButton_Click;
            // 
            // MaterialsTreeView
            // 
            MaterialsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MaterialsTreeView.BackColor = Color.FromArgb(21, 21, 21);
            MaterialsTreeView.BorderStyle = BorderStyle.None;
            MaterialsTreeView.CausesValidation = false;
            MaterialsTreeView.Font = new Font("Segoe UI", 12F);
            MaterialsTreeView.ForeColor = Color.White;
            MaterialsTreeView.HotTracking = true;
            MaterialsTreeView.ItemHeight = 30;
            MaterialsTreeView.Location = new Point(939, 109);
            MaterialsTreeView.MinimumSize = new Size(400, 406);
            MaterialsTreeView.Name = "MaterialsTreeView";
            MaterialsTreeView.Size = new Size(400, 414);
            MaterialsTreeView.TabIndex = 30;
            MaterialsTreeView.TabStop = false;
            // 
            // DetailsProductLabel
            // 
            DetailsProductLabel.AutoSize = true;
            DetailsProductLabel.Font = new Font("Segoe UI", 14.25F);
            DetailsProductLabel.ForeColor = Color.Gold;
            DetailsProductLabel.Location = new Point(78, 4);
            DetailsProductLabel.Name = "DetailsProductLabel";
            DetailsProductLabel.Size = new Size(140, 25);
            DetailsProductLabel.TabIndex = 29;
            DetailsProductLabel.Text = "[Product Label]";
            // 
            // DetailsImagePanel
            // 
            DetailsImagePanel.BackgroundImageLayout = ImageLayout.Center;
            DetailsImagePanel.Location = new Point(8, 4);
            DetailsImagePanel.Name = "DetailsImagePanel";
            DetailsImagePanel.Size = new Size(64, 64);
            DetailsImagePanel.TabIndex = 28;
            // 
            // SaveFileDialog
            // 
            SaveFileDialog.DefaultExt = "csv";
            SaveFileDialog.Filter = "CSV | *.csv";
            // 
            // BuildPlanDetailsTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ClearCompletedButton);
            Controls.Add(ExportBuildList);
            Controls.Add(label44);
            Controls.Add(TotalManufacturingSlotsLabel);
            Controls.Add(TotalReactionSlotsLabel);
            Controls.Add(label48);
            Controls.Add(label46);
            Controls.Add(label47);
            Controls.Add(label45);
            Controls.Add(OptimizedBuildTreeView);
            Controls.Add(label20);
            Controls.Add(label43);
            Controls.Add(label42);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label12);
            Controls.Add(CollapseAllButton);
            Controls.Add(MaterialsTreeView);
            Controls.Add(DetailsProductLabel);
            Controls.Add(DetailsImagePanel);
            Name = "BuildPlanDetailsTab";
            Size = new Size(1346, 531);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Objects.Custom_Controls.EveHelperButton ClearCompletedButton;
        private Objects.Custom_Controls.EveHelperButton ExportBuildList;
        private Label TotalManufacturingSlotsLabel;
        private Label TotalReactionSlotsLabel;
        public TreeView OptimizedBuildTreeView;
        private Objects.Custom_Controls.EveHelperButton CollapseAllButton;
        private TreeView MaterialsTreeView;
        public Label DetailsProductLabel;
        public Panel DetailsImagePanel;
        private SaveFileDialog SaveFileDialog;
    }
}
