namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class BuildPlanPlanetMaterialsTab
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
            Label label57;
            PlanetMatsTotalTreeview = new TreeView();
            PlanetMaterialsTreeView = new TreeView();
            label57 = new Label();
            SuspendLayout();
            // 
            // label57
            // 
            label57.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label57.AutoSize = true;
            label57.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label57.ForeColor = Color.WhiteSmoke;
            label57.Location = new Point(624, 5);
            label57.Name = "label57";
            label57.Size = new Size(134, 20);
            label57.TabIndex = 5;
            label57.Text = "Total of each type";
            // 
            // PlanetMatsTotalTreeview
            // 
            PlanetMatsTotalTreeview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            PlanetMatsTotalTreeview.BackColor = Color.FromArgb(21, 21, 21);
            PlanetMatsTotalTreeview.BorderStyle = BorderStyle.None;
            PlanetMatsTotalTreeview.ForeColor = Color.White;
            PlanetMatsTotalTreeview.Location = new Point(624, 33);
            PlanetMatsTotalTreeview.MinimumSize = new Size(716, 456);
            PlanetMatsTotalTreeview.Name = "PlanetMatsTotalTreeview";
            PlanetMatsTotalTreeview.Size = new Size(716, 485);
            PlanetMatsTotalTreeview.TabIndex = 4;
            // 
            // PlanetMaterialsTreeView
            // 
            PlanetMaterialsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlanetMaterialsTreeView.BackColor = Color.FromArgb(21, 21, 21);
            PlanetMaterialsTreeView.BorderStyle = BorderStyle.None;
            PlanetMaterialsTreeView.Font = new Font("Segoe UI", 12F);
            PlanetMaterialsTreeView.ForeColor = Color.White;
            PlanetMaterialsTreeView.Location = new Point(3, 13);
            PlanetMaterialsTreeView.Name = "PlanetMaterialsTreeView";
            PlanetMaterialsTreeView.Size = new Size(515, 500);
            PlanetMaterialsTreeView.TabIndex = 3;
            PlanetMaterialsTreeView.TabStop = false;
            // 
            // BuildPlanPlanetMaterialsTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label57);
            Controls.Add(PlanetMatsTotalTreeview);
            Controls.Add(PlanetMaterialsTreeView);
            Name = "BuildPlanPlanetMaterialsTab";
            Size = new Size(1346, 531);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView PlanetMatsTotalTreeview;
        private TreeView PlanetMaterialsTreeView;
    }
}
