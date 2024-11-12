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
            BlueprintBrowserButton = new Objects.Custom_Controls.EveHelperButton();
            PlanetPlannerButton = new Objects.Custom_Controls.EveHelperButton();
            LootAppraisalButton = new Objects.Custom_Controls.EveHelperButton();
            SystemFinderButton = new Objects.Custom_Controls.EveHelperButton();
            DefaultsButtonClick = new Objects.Custom_Controls.EveHelperButton();
            MarketBrowserButton = new Objects.Custom_Controls.EveHelperButton();
            AbyssTrackerButton = new Objects.Custom_Controls.EveHelperButton();
            PriceHistoryButton = new Objects.Custom_Controls.EveHelperButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            backupFilesToolStripMenuItem = new ToolStripMenuItem();
            importFIlesToolStripMenuItem = new ToolStripMenuItem();
            updateEveDataToolStripMenuItem = new ToolStripMenuItem();
            reportIssueToolStripMenuItem = new ToolStripMenuItem();
            FreyaLinkLabel = new LinkLabel();
            label10 = new Label();
            InitLongLoadingWorker = new System.ComponentModel.BackgroundWorker();
            ShoppingListButton = new Objects.Custom_Controls.EveHelperButton();
            BuildPlansButton = new Objects.Custom_Controls.EveHelperButton();
            UpdateWorker = new System.ComponentModel.BackgroundWorker();
            CheckInternetBGWorker = new System.ComponentModel.BackgroundWorker();
            DocumentationLabel = new LinkLabel();
            LPOfferButton = new Objects.Custom_Controls.EveHelperButton();
            ThemePickerButton = new Objects.Custom_Controls.EveHelperButton();
            linkLabel1 = new LinkLabel();
            HunterIntelButton = new Objects.Custom_Controls.EveHelperButton();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BlueprintBrowserButton
            // 
            BlueprintBrowserButton.BackgroundImageLayout = ImageLayout.None;
            BlueprintBrowserButton.Cursor = Cursors.Hand;
            BlueprintBrowserButton.Enabled = false;
            BlueprintBrowserButton.FlatAppearance.BorderColor = Color.Gray;
            BlueprintBrowserButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            BlueprintBrowserButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            BlueprintBrowserButton.ForeColor = Color.FromArgb(234, 234, 234);
            BlueprintBrowserButton.Location = new Point(142, 26);
            BlueprintBrowserButton.Margin = new Padding(3, 2, 3, 2);
            BlueprintBrowserButton.MaximumSize = new Size(120, 120);
            BlueprintBrowserButton.Name = "BlueprintBrowserButton";
            BlueprintBrowserButton.Size = new Size(120, 50);
            BlueprintBrowserButton.TabIndex = 0;
            BlueprintBrowserButton.Text = "Blueprints";
            BlueprintBrowserButton.UseVisualStyleBackColor = false;
            BlueprintBrowserButton.Click += BlueprintBrowserButton_Click;
            // 
            // PlanetPlannerButton
            // 
            PlanetPlannerButton.Cursor = Cursors.Hand;
            PlanetPlannerButton.Enabled = false;
            PlanetPlannerButton.FlatAppearance.BorderColor = Color.Gray;
            PlanetPlannerButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            PlanetPlannerButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            PlanetPlannerButton.ForeColor = Color.FromArgb(234, 234, 234);
            PlanetPlannerButton.Location = new Point(142, 188);
            PlanetPlannerButton.Margin = new Padding(3, 2, 3, 2);
            PlanetPlannerButton.MaximumSize = new Size(120, 120);
            PlanetPlannerButton.Name = "PlanetPlannerButton";
            PlanetPlannerButton.Size = new Size(120, 50);
            PlanetPlannerButton.TabIndex = 1;
            PlanetPlannerButton.Text = "Planetary Interaction";
            PlanetPlannerButton.UseVisualStyleBackColor = false;
            PlanetPlannerButton.Click += PlanetPlannerButton_Click;
            // 
            // LootAppraisalButton
            // 
            LootAppraisalButton.Cursor = Cursors.Hand;
            LootAppraisalButton.Enabled = false;
            LootAppraisalButton.FlatAppearance.BorderColor = Color.Gray;
            LootAppraisalButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            LootAppraisalButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            LootAppraisalButton.ForeColor = Color.FromArgb(234, 234, 234);
            LootAppraisalButton.Location = new Point(9, 134);
            LootAppraisalButton.Margin = new Padding(3, 2, 3, 2);
            LootAppraisalButton.MaximumSize = new Size(120, 120);
            LootAppraisalButton.Name = "LootAppraisalButton";
            LootAppraisalButton.Size = new Size(120, 50);
            LootAppraisalButton.TabIndex = 2;
            LootAppraisalButton.Text = "Loot Appraisal";
            LootAppraisalButton.UseVisualStyleBackColor = false;
            LootAppraisalButton.Click += LootAppraisalButton_Click;
            // 
            // SystemFinderButton
            // 
            SystemFinderButton.Cursor = Cursors.Hand;
            SystemFinderButton.Enabled = false;
            SystemFinderButton.FlatAppearance.BorderColor = Color.Gray;
            SystemFinderButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            SystemFinderButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            SystemFinderButton.ForeColor = Color.FromArgb(234, 234, 234);
            SystemFinderButton.Location = new Point(142, 296);
            SystemFinderButton.Margin = new Padding(3, 2, 3, 2);
            SystemFinderButton.MaximumSize = new Size(120, 120);
            SystemFinderButton.Name = "SystemFinderButton";
            SystemFinderButton.Size = new Size(120, 50);
            SystemFinderButton.TabIndex = 3;
            SystemFinderButton.Text = "System Finder";
            SystemFinderButton.UseVisualStyleBackColor = false;
            SystemFinderButton.Click += SystemFinderButton_Click;
            // 
            // DefaultsButtonClick
            // 
            DefaultsButtonClick.Cursor = Cursors.Hand;
            DefaultsButtonClick.Enabled = false;
            DefaultsButtonClick.FlatAppearance.BorderColor = Color.Gray;
            DefaultsButtonClick.FlatAppearance.MouseDownBackColor = Color.Cyan;
            DefaultsButtonClick.FlatAppearance.MouseOverBackColor = Color.Teal;
            DefaultsButtonClick.ForeColor = Color.FromArgb(234, 234, 234);
            DefaultsButtonClick.Location = new Point(142, 242);
            DefaultsButtonClick.Margin = new Padding(3, 2, 3, 2);
            DefaultsButtonClick.MaximumSize = new Size(120, 120);
            DefaultsButtonClick.Name = "DefaultsButtonClick";
            DefaultsButtonClick.Size = new Size(120, 50);
            DefaultsButtonClick.TabIndex = 8;
            DefaultsButtonClick.Text = "Settings";
            DefaultsButtonClick.UseVisualStyleBackColor = false;
            DefaultsButtonClick.Click += DefaultsButtonClick_Click;
            // 
            // MarketBrowserButton
            // 
            MarketBrowserButton.Cursor = Cursors.Hand;
            MarketBrowserButton.Enabled = false;
            MarketBrowserButton.FlatAppearance.BorderColor = Color.Gray;
            MarketBrowserButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            MarketBrowserButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            MarketBrowserButton.ForeColor = Color.FromArgb(234, 234, 234);
            MarketBrowserButton.Location = new Point(9, 188);
            MarketBrowserButton.Margin = new Padding(3, 2, 3, 2);
            MarketBrowserButton.MaximumSize = new Size(120, 120);
            MarketBrowserButton.Name = "MarketBrowserButton";
            MarketBrowserButton.Size = new Size(120, 50);
            MarketBrowserButton.TabIndex = 10;
            MarketBrowserButton.Text = "Market Browser";
            MarketBrowserButton.UseVisualStyleBackColor = false;
            MarketBrowserButton.Click += MarketBrowserButton_Click;
            // 
            // AbyssTrackerButton
            // 
            AbyssTrackerButton.Cursor = Cursors.Hand;
            AbyssTrackerButton.Enabled = false;
            AbyssTrackerButton.FlatAppearance.BorderColor = Color.Gray;
            AbyssTrackerButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            AbyssTrackerButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            AbyssTrackerButton.ForeColor = Color.FromArgb(234, 234, 234);
            AbyssTrackerButton.Location = new Point(9, 26);
            AbyssTrackerButton.Margin = new Padding(3, 2, 3, 2);
            AbyssTrackerButton.MaximumSize = new Size(120, 120);
            AbyssTrackerButton.Name = "AbyssTrackerButton";
            AbyssTrackerButton.Size = new Size(120, 50);
            AbyssTrackerButton.TabIndex = 12;
            AbyssTrackerButton.Text = "Abyss Tracker";
            AbyssTrackerButton.UseVisualStyleBackColor = false;
            AbyssTrackerButton.Click += AbyssTrackerButton_Click;
            // 
            // PriceHistoryButton
            // 
            PriceHistoryButton.Cursor = Cursors.Hand;
            PriceHistoryButton.Enabled = false;
            PriceHistoryButton.FlatAppearance.BorderColor = Color.Gray;
            PriceHistoryButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            PriceHistoryButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            PriceHistoryButton.ForeColor = Color.FromArgb(234, 234, 234);
            PriceHistoryButton.Location = new Point(9, 242);
            PriceHistoryButton.Margin = new Padding(3, 2, 3, 2);
            PriceHistoryButton.MaximumSize = new Size(120, 120);
            PriceHistoryButton.Name = "PriceHistoryButton";
            PriceHistoryButton.Size = new Size(120, 50);
            PriceHistoryButton.TabIndex = 16;
            PriceHistoryButton.Text = "Price History";
            PriceHistoryButton.UseVisualStyleBackColor = false;
            PriceHistoryButton.Click += PriceHistoryButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, backupFilesToolStripMenuItem, importFIlesToolStripMenuItem, updateEveDataToolStripMenuItem, reportIssueToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(397, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(91, 20);
            fileToolStripMenuItem.Text = "File Locations";
            fileToolStripMenuItem.Click += fileLocationsToolStripMenuItem_Click;
            // 
            // backupFilesToolStripMenuItem
            // 
            backupFilesToolStripMenuItem.Name = "backupFilesToolStripMenuItem";
            backupFilesToolStripMenuItem.Size = new Size(84, 20);
            backupFilesToolStripMenuItem.Text = "Backup Files";
            backupFilesToolStripMenuItem.Click += backupFilesToolStripMenuItem_Click;
            // 
            // importFIlesToolStripMenuItem
            // 
            importFIlesToolStripMenuItem.ForeColor = Color.Black;
            importFIlesToolStripMenuItem.Name = "importFIlesToolStripMenuItem";
            importFIlesToolStripMenuItem.Size = new Size(81, 20);
            importFIlesToolStripMenuItem.Text = "Import FIles";
            importFIlesToolStripMenuItem.Click += importFIlesToolStripMenuItem_Click;
            // 
            // updateEveDataToolStripMenuItem
            // 
            updateEveDataToolStripMenuItem.Name = "updateEveDataToolStripMenuItem";
            updateEveDataToolStripMenuItem.Size = new Size(105, 20);
            updateEveDataToolStripMenuItem.Text = "Update Eve Data";
            updateEveDataToolStripMenuItem.Visible = false;
            updateEveDataToolStripMenuItem.Click += updateEveDataToolStripMenuItem_Click;
            // 
            // reportIssueToolStripMenuItem
            // 
            reportIssueToolStripMenuItem.ForeColor = Color.Black;
            reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            reportIssueToolStripMenuItem.Size = new Size(83, 20);
            reportIssueToolStripMenuItem.Text = "Report Issue";
            reportIssueToolStripMenuItem.Click += reportIssueToolStripMenuItem_Click;
            // 
            // FreyaLinkLabel
            // 
            FreyaLinkLabel.AutoSize = true;
            FreyaLinkLabel.LinkColor = Color.FromArgb(128, 255, 255);
            FreyaLinkLabel.Location = new Point(96, 417);
            FreyaLinkLabel.Name = "FreyaLinkLabel";
            FreyaLinkLabel.Size = new Size(85, 15);
            FreyaLinkLabel.TabIndex = 20;
            FreyaLinkLabel.TabStop = true;
            FreyaLinkLabel.Text = "Freya Partanen";
            FreyaLinkLabel.LinkClicked += FreyaLinkLabel_LinkClicked;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic);
            label10.Location = new Point(10, 414);
            label10.Name = "label10";
            label10.Size = new Size(88, 20);
            label10.TabIndex = 19;
            label10.Text = "Donate ISK ";
            // 
            // InitLongLoadingWorker
            // 
            InitLongLoadingWorker.DoWork += InitLongLoadingWorker_DoWork;
            InitLongLoadingWorker.RunWorkerCompleted += InitLongLoadingWorker_RunWorkerCompleted;
            // 
            // ShoppingListButton
            // 
            ShoppingListButton.Cursor = Cursors.Hand;
            ShoppingListButton.Enabled = false;
            ShoppingListButton.FlatAppearance.BorderColor = Color.Gray;
            ShoppingListButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            ShoppingListButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            ShoppingListButton.ForeColor = Color.FromArgb(234, 234, 234);
            ShoppingListButton.Location = new Point(10, 296);
            ShoppingListButton.Margin = new Padding(3, 2, 3, 2);
            ShoppingListButton.MaximumSize = new Size(120, 120);
            ShoppingListButton.Name = "ShoppingListButton";
            ShoppingListButton.Size = new Size(120, 50);
            ShoppingListButton.TabIndex = 22;
            ShoppingListButton.Text = "Shopping List";
            ShoppingListButton.UseVisualStyleBackColor = false;
            ShoppingListButton.Click += ShoppingListButton_Click;
            // 
            // BuildPlansButton
            // 
            BuildPlansButton.Cursor = Cursors.Hand;
            BuildPlansButton.Enabled = false;
            BuildPlansButton.FlatAppearance.BorderColor = Color.Gray;
            BuildPlansButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            BuildPlansButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            BuildPlansButton.ForeColor = Color.FromArgb(234, 234, 234);
            BuildPlansButton.Location = new Point(9, 80);
            BuildPlansButton.Margin = new Padding(3, 2, 3, 2);
            BuildPlansButton.MaximumSize = new Size(120, 120);
            BuildPlansButton.Name = "BuildPlansButton";
            BuildPlansButton.Size = new Size(120, 50);
            BuildPlansButton.TabIndex = 24;
            BuildPlansButton.Text = "Build Plans";
            BuildPlansButton.UseVisualStyleBackColor = false;
            BuildPlansButton.Click += BuildPlansButton_Click;
            // 
            // UpdateWorker
            // 
            UpdateWorker.DoWork += UpdateWorker_DoWork;
            UpdateWorker.RunWorkerCompleted += UpdateWorker_RunWorkerCompleted;
            // 
            // CheckInternetBGWorker
            // 
            CheckInternetBGWorker.DoWork += CheckInternetBGWorker_DoWork;
            CheckInternetBGWorker.RunWorkerCompleted += CheckInternetBGWorker_RunWorkerCompleted;
            // 
            // DocumentationLabel
            // 
            DocumentationLabel.AutoSize = true;
            DocumentationLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            DocumentationLabel.LinkColor = Color.FromArgb(128, 255, 255);
            DocumentationLabel.Location = new Point(197, 413);
            DocumentationLabel.Name = "DocumentationLabel";
            DocumentationLabel.Size = new Size(118, 20);
            DocumentationLabel.TabIndex = 25;
            DocumentationLabel.TabStop = true;
            DocumentationLabel.Text = "Documentation";
            DocumentationLabel.LinkClicked += DocumentationLabel_LinkClicked;
            // 
            // LPOfferButton
            // 
            LPOfferButton.Cursor = Cursors.Hand;
            LPOfferButton.Enabled = false;
            LPOfferButton.FlatAppearance.BorderColor = Color.Gray;
            LPOfferButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            LPOfferButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            LPOfferButton.ForeColor = Color.FromArgb(234, 234, 234);
            LPOfferButton.Location = new Point(142, 134);
            LPOfferButton.Margin = new Padding(3, 2, 3, 2);
            LPOfferButton.MaximumSize = new Size(120, 120);
            LPOfferButton.Name = "LPOfferButton";
            LPOfferButton.Size = new Size(120, 50);
            LPOfferButton.TabIndex = 26;
            LPOfferButton.Text = "LP Offers";
            LPOfferButton.UseVisualStyleBackColor = false;
            LPOfferButton.Click += LPOfferButton_Click;
            // 
            // ThemePickerButton
            // 
            ThemePickerButton.Cursor = Cursors.Hand;
            ThemePickerButton.FlatAppearance.BorderColor = Color.Gray;
            ThemePickerButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            ThemePickerButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            ThemePickerButton.ForeColor = Color.FromArgb(234, 234, 234);
            ThemePickerButton.Location = new Point(9, 350);
            ThemePickerButton.Margin = new Padding(3, 2, 3, 2);
            ThemePickerButton.MaximumSize = new Size(120, 120);
            ThemePickerButton.Name = "ThemePickerButton";
            ThemePickerButton.Size = new Size(120, 50);
            ThemePickerButton.TabIndex = 27;
            ThemePickerButton.Text = "Theme Picker";
            ThemePickerButton.UseVisualStyleBackColor = false;
            ThemePickerButton.Click += ThemePickerButton_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            linkLabel1.LinkColor = Color.FromArgb(128, 255, 255);
            linkLabel1.Location = new Point(73, 445);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(175, 20);
            linkLabel1.TabIndex = 28;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Reset Theme to Default";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // HunterIntelButton
            // 
            HunterIntelButton.Cursor = Cursors.Hand;
            HunterIntelButton.FlatAppearance.BorderColor = Color.Gray;
            HunterIntelButton.FlatAppearance.MouseDownBackColor = Color.Cyan;
            HunterIntelButton.FlatAppearance.MouseOverBackColor = Color.Teal;
            HunterIntelButton.ForeColor = Color.FromArgb(234, 234, 234);
            HunterIntelButton.Location = new Point(142, 80);
            HunterIntelButton.Margin = new Padding(3, 2, 3, 2);
            HunterIntelButton.MaximumSize = new Size(120, 120);
            HunterIntelButton.Name = "HunterIntelButton";
            HunterIntelButton.Size = new Size(120, 50);
            HunterIntelButton.TabIndex = 29;
            HunterIntelButton.Text = "Hunter Intel";
            HunterIntelButton.UseVisualStyleBackColor = false;
            HunterIntelButton.Click += HunterIntelButton_Click;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            ClientSize = new Size(397, 491);
            Controls.Add(HunterIntelButton);
            Controls.Add(linkLabel1);
            Controls.Add(ThemePickerButton);
            Controls.Add(LPOfferButton);
            Controls.Add(DocumentationLabel);
            Controls.Add(BuildPlansButton);
            Controls.Add(ShoppingListButton);
            Controls.Add(FreyaLinkLabel);
            Controls.Add(label10);
            Controls.Add(PriceHistoryButton);
            Controls.Add(AbyssTrackerButton);
            Controls.Add(MarketBrowserButton);
            Controls.Add(DefaultsButtonClick);
            Controls.Add(SystemFinderButton);
            Controls.Add(LootAppraisalButton);
            Controls.Add(PlanetPlannerButton);
            Controls.Add(BlueprintBrowserButton);
            Controls.Add(menuStrip1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eve Helper";
            FormClosing += MainScreen_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Objects.Custom_Controls.EveHelperButton BlueprintBrowserButton;
        private Objects.Custom_Controls.EveHelperButton PlanetPlannerButton;
        private Objects.Custom_Controls.EveHelperButton LootAppraisalButton;
        private Objects.Custom_Controls.EveHelperButton SystemFinderButton;
        private Objects.Custom_Controls.EveHelperButton DefaultsButtonClick;
        private Objects.Custom_Controls.EveHelperButton MarketBrowserButton;
        private Objects.Custom_Controls.EveHelperButton AbyssTrackerButton;
        private Objects.Custom_Controls.EveHelperButton PriceHistoryButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private LinkLabel FreyaLinkLabel;
        private Label label10;
        private ToolStripMenuItem backupFilesToolStripMenuItem;
        private ToolStripMenuItem updateEveDataToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker InitLongLoadingWorker;
        private Objects.Custom_Controls.EveHelperButton ShoppingListButton;
        private Objects.Custom_Controls.EveHelperButton BuildPlansButton;
        private ToolStripMenuItem importFIlesToolStripMenuItem;
        private ToolStripMenuItem reportIssueToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker UpdateWorker;
        private System.ComponentModel.BackgroundWorker CheckInternetBGWorker;
        private LinkLabel DocumentationLabel;
        private Objects.Custom_Controls.EveHelperButton LPOfferButton;
        private Objects.Custom_Controls.EveHelperButton ThemePickerButton;
        private LinkLabel linkLabel1;
        private Objects.Custom_Controls.EveHelperButton HunterIntelButton;
    }
}