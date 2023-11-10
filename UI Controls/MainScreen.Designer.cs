namespace EveHelperWF.UI_Controls
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            BlueprintBrowserButton = new Button();
            PlanetPlannerButton = new Button();
            LootAppraisalButton = new Button();
            SystemFinderButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // BlueprintBrowserButton
            // 
            BlueprintBrowserButton.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 0);
            BlueprintBrowserButton.FlatAppearance.BorderSize = 6;
            BlueprintBrowserButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            BlueprintBrowserButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            BlueprintBrowserButton.ForeColor = Color.Black;
            BlueprintBrowserButton.Image = (Image)resources.GetObject("BlueprintBrowserButton.Image");
            BlueprintBrowserButton.Location = new Point(56, 40);
            BlueprintBrowserButton.Name = "BlueprintBrowserButton";
            BlueprintBrowserButton.Size = new Size(150, 150);
            BlueprintBrowserButton.TabIndex = 0;
            BlueprintBrowserButton.UseVisualStyleBackColor = true;
            BlueprintBrowserButton.Click += BlueprintBrowserButton_Click;
            // 
            // PlanetPlannerButton
            // 
            PlanetPlannerButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            PlanetPlannerButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            PlanetPlannerButton.ForeColor = Color.Black;
            PlanetPlannerButton.Image = (Image)resources.GetObject("PlanetPlannerButton.Image");
            PlanetPlannerButton.Location = new Point(266, 40);
            PlanetPlannerButton.Name = "PlanetPlannerButton";
            PlanetPlannerButton.Size = new Size(150, 150);
            PlanetPlannerButton.TabIndex = 1;
            PlanetPlannerButton.UseVisualStyleBackColor = true;
            PlanetPlannerButton.Click += PlanetPlannerButton_Click;
            // 
            // LootAppraisalButton
            // 
            LootAppraisalButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            LootAppraisalButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            LootAppraisalButton.ForeColor = Color.Black;
            LootAppraisalButton.Image = (Image)resources.GetObject("LootAppraisalButton.Image");
            LootAppraisalButton.Location = new Point(56, 240);
            LootAppraisalButton.Name = "LootAppraisalButton";
            LootAppraisalButton.Size = new Size(150, 150);
            LootAppraisalButton.TabIndex = 2;
            LootAppraisalButton.Text = "'";
            LootAppraisalButton.UseVisualStyleBackColor = true;
            LootAppraisalButton.Click += LootAppraisalButton_Click;
            // 
            // SystemFinderButton
            // 
            SystemFinderButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            SystemFinderButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            SystemFinderButton.ForeColor = Color.Black;
            SystemFinderButton.Image = (Image)resources.GetObject("SystemFinderButton.Image");
            SystemFinderButton.Location = new Point(266, 240);
            SystemFinderButton.Name = "SystemFinderButton";
            SystemFinderButton.Size = new Size(150, 150);
            SystemFinderButton.TabIndex = 3;
            SystemFinderButton.UseVisualStyleBackColor = true;
            SystemFinderButton.Click += SystemFinderButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(80, 193);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 4;
            label1.Text = "Blueprints";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(248, 193);
            label2.Name = "label2";
            label2.Size = new Size(193, 25);
            label2.TabIndex = 5;
            label2.Text = "Planetary Interaction";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(276, 393);
            label3.Name = "label3";
            label3.Size = new Size(131, 25);
            label3.TabIndex = 6;
            label3.Text = "System Finder";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(65, 393);
            label4.Name = "label4";
            label4.Size = new Size(135, 25);
            label4.TabIndex = 7;
            label4.Text = "Loot Appraisal";
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SystemFinderButton);
            Controls.Add(LootAppraisalButton);
            Controls.Add(PlanetPlannerButton);
            Controls.Add(BlueprintBrowserButton);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainScreen";
            Text = "Eve Helper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BlueprintBrowserButton;
        private Button PlanetPlannerButton;
        private Button LootAppraisalButton;
        private Button SystemFinderButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}