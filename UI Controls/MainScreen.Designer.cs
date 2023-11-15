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
            label5 = new Label();
            DefaultsButtonClick = new Button();
            label6 = new Label();
            MarketBrowserButton = new Button();
            label7 = new Label();
            AbyssTrackerButton = new Button();
            label8 = new Label();
            FuzzworksLinkLabel = new LinkLabel();
            label9 = new Label();
            PriceHistoryButton = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            fileLocationsToolStripMenuItem = new ToolStripMenuItem();
            backupFilesToolStripMenuItem = new ToolStripMenuItem();
            FreyaLinkLabel = new LinkLabel();
            label10 = new Label();
            label11 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BlueprintBrowserButton
            // 
            BlueprintBrowserButton.Cursor = Cursors.Hand;
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
            PlanetPlannerButton.Cursor = Cursors.Hand;
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
            LootAppraisalButton.Cursor = Cursors.Hand;
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
            SystemFinderButton.Cursor = Cursors.Hand;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(670, 393);
            label5.Name = "label5";
            label5.Size = new Size(172, 25);
            label5.TabIndex = 9;
            label5.Text = "Configure Defaults";
            // 
            // DefaultsButtonClick
            // 
            DefaultsButtonClick.Cursor = Cursors.Hand;
            DefaultsButtonClick.FlatAppearance.MouseDownBackColor = Color.Cyan;
            DefaultsButtonClick.FlatAppearance.MouseOverBackColor = Color.Teal;
            DefaultsButtonClick.ForeColor = Color.Black;
            DefaultsButtonClick.Image = (Image)resources.GetObject("DefaultsButtonClick.Image");
            DefaultsButtonClick.Location = new Point(679, 240);
            DefaultsButtonClick.Name = "DefaultsButtonClick";
            DefaultsButtonClick.Size = new Size(150, 150);
            DefaultsButtonClick.TabIndex = 8;
            DefaultsButtonClick.UseVisualStyleBackColor = true;
            DefaultsButtonClick.Click += DefaultsButtonClick_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(475, 193);
            label6.Name = "label6";
            label6.Size = new Size(147, 25);
            label6.TabIndex = 11;
            label6.Text = "Market Browser";
            // 
            // MarketBrowserButton
            // 
            MarketBrowserButton.Cursor = Cursors.Hand;
            MarketBrowserButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            MarketBrowserButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            MarketBrowserButton.ForeColor = Color.Black;
            MarketBrowserButton.Image = (Image)resources.GetObject("MarketBrowserButton.Image");
            MarketBrowserButton.Location = new Point(475, 40);
            MarketBrowserButton.Name = "MarketBrowserButton";
            MarketBrowserButton.Size = new Size(150, 150);
            MarketBrowserButton.TabIndex = 10;
            MarketBrowserButton.UseVisualStyleBackColor = true;
            MarketBrowserButton.Click += MarketBrowserButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(690, 193);
            label7.Name = "label7";
            label7.Size = new Size(130, 25);
            label7.TabIndex = 13;
            label7.Text = "Abyss Tracker";
            // 
            // AbyssTrackerButton
            // 
            AbyssTrackerButton.Cursor = Cursors.Hand;
            AbyssTrackerButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            AbyssTrackerButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            AbyssTrackerButton.ForeColor = Color.Black;
            AbyssTrackerButton.Image = (Image)resources.GetObject("AbyssTrackerButton.Image");
            AbyssTrackerButton.Location = new Point(679, 40);
            AbyssTrackerButton.Name = "AbyssTrackerButton";
            AbyssTrackerButton.Size = new Size(150, 150);
            AbyssTrackerButton.TabIndex = 12;
            AbyssTrackerButton.UseVisualStyleBackColor = true;
            AbyssTrackerButton.Click += AbyssTrackerButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label8.Location = new Point(56, 439);
            label8.Name = "label8";
            label8.Size = new Size(689, 25);
            label8.TabIndex = 14;
            label8.Text = "Special thank you to Fuzzworks who provides the static data dump in SQLite format. ";
            // 
            // FuzzworksLinkLabel
            // 
            FuzzworksLinkLabel.AutoSize = true;
            FuzzworksLinkLabel.LinkColor = Color.FromArgb(128, 255, 255);
            FuzzworksLinkLabel.Location = new Point(751, 444);
            FuzzworksLinkLabel.Name = "FuzzworksLinkLabel";
            FuzzworksLinkLabel.Size = new Size(133, 20);
            FuzzworksLinkLabel.TabIndex = 15;
            FuzzworksLinkLabel.TabStop = true;
            FuzzworksLinkLabel.Text = "Fuzzworks Website";
            FuzzworksLinkLabel.LinkClicked += FuzzworksLinkLabel_LinkClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(459, 393);
            label9.Name = "label9";
            label9.Size = new Size(179, 25);
            label9.TabIndex = 17;
            label9.Text = "Price History Utility";
            // 
            // PriceHistoryButton
            // 
            PriceHistoryButton.Cursor = Cursors.Hand;
            PriceHistoryButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            PriceHistoryButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            PriceHistoryButton.ForeColor = Color.Black;
            PriceHistoryButton.Image = (Image)resources.GetObject("PriceHistoryButton.Image");
            PriceHistoryButton.Location = new Point(472, 240);
            PriceHistoryButton.Name = "PriceHistoryButton";
            PriceHistoryButton.Size = new Size(150, 150);
            PriceHistoryButton.TabIndex = 16;
            PriceHistoryButton.UseVisualStyleBackColor = true;
            PriceHistoryButton.Click += PriceHistoryButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(939, 28);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fileLocationsToolStripMenuItem, backupFilesToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // fileLocationsToolStripMenuItem
            // 
            fileLocationsToolStripMenuItem.Name = "fileLocationsToolStripMenuItem";
            fileLocationsToolStripMenuItem.Size = new Size(182, 26);
            fileLocationsToolStripMenuItem.Text = "File Locations";
            fileLocationsToolStripMenuItem.Click += fileLocationsToolStripMenuItem_Click;
            // 
            // backupFilesToolStripMenuItem
            // 
            backupFilesToolStripMenuItem.Name = "backupFilesToolStripMenuItem";
            backupFilesToolStripMenuItem.Size = new Size(182, 26);
            backupFilesToolStripMenuItem.Text = "Backup Files";
            backupFilesToolStripMenuItem.Click += backupFilesToolStripMenuItem_Click;
            // 
            // FreyaLinkLabel
            // 
            FreyaLinkLabel.AutoSize = true;
            FreyaLinkLabel.LinkColor = Color.FromArgb(128, 255, 255);
            FreyaLinkLabel.Location = new Point(518, 505);
            FreyaLinkLabel.Name = "FreyaLinkLabel";
            FreyaLinkLabel.Size = new Size(105, 20);
            FreyaLinkLabel.TabIndex = 20;
            FreyaLinkLabel.TabStop = true;
            FreyaLinkLabel.Text = "Freya Partanen";
            FreyaLinkLabel.LinkClicked += FreyaLinkLabel_LinkClicked;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label10.Location = new Point(56, 475);
            label10.Name = "label10";
            label10.Size = new Size(448, 25);
            label10.TabIndex = 19;
            label10.Text = "To donate to this project, send isk to \"Freya Partanen\".";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label11.Location = new Point(56, 500);
            label11.Name = "label11";
            label11.Size = new Size(456, 25);
            label11.TabIndex = 21;
            label11.Text = "All donations are voluntary and very much appreciated.";
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 563);
            Controls.Add(label11);
            Controls.Add(FreyaLinkLabel);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(PriceHistoryButton);
            Controls.Add(FuzzworksLinkLabel);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(AbyssTrackerButton);
            Controls.Add(label6);
            Controls.Add(MarketBrowserButton);
            Controls.Add(label5);
            Controls.Add(DefaultsButtonClick);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SystemFinderButton);
            Controls.Add(LootAppraisalButton);
            Controls.Add(PlanetPlannerButton);
            Controls.Add(BlueprintBrowserButton);
            Controls.Add(menuStrip1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainScreen";
            Text = "Eve Helper";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private Label label5;
        private Button DefaultsButtonClick;
        private Label label6;
        private Button MarketBrowserButton;
        private Label label7;
        private Button AbyssTrackerButton;
        private Label label8;
        private LinkLabel FuzzworksLinkLabel;
        private Label label9;
        private Button PriceHistoryButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem fileLocationsToolStripMenuItem;
        private ToolStripMenuItem backupFilesToolStripMenuItem;
        private LinkLabel FreyaLinkLabel;
        private Label label10;
        private Label label11;
    }
}