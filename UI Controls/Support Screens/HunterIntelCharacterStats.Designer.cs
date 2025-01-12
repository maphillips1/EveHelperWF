namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class HunterIntelCharacterStats
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
            NameLabel = new Label();
            BasicDataPanel = new Panel();
            EdencomLossLabel = new Label();
            label18 = new Label();
            MarauderLossLabel = new Label();
            label16 = new Label();
            PvELossLabel = new Label();
            label15 = new Label();
            SoloLabel = new Label();
            label14 = new Label();
            AvgAttackersLabel = new Label();
            label13 = new Label();
            DangerRatingLabel = new Label();
            label10 = new Label();
            IsCynoPilotLabel = new Label();
            label6 = new Label();
            LostValueLabel = new Label();
            label7 = new Label();
            DestroyedValueLabel = new Label();
            label5 = new Label();
            LossCountLabel = new Label();
            KillCountLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            TopSystemsPanel = new Panel();
            KillSystemTreeView = new TreeView();
            label4 = new Label();
            label8 = new Label();
            ShipPanel = new Panel();
            TopShipsTreeView = new TreeView();
            label12 = new Label();
            LoadLossesWorker = new System.ComponentModel.BackgroundWorker();
            panel1 = new Panel();
            RecentLossesTreeView = new TreeView();
            label9 = new Label();
            ZKillLabel = new LinkLabel();
            panel2 = new Panel();
            TopRegionsTreeView = new TreeView();
            label11 = new Label();
            label17 = new Label();
            CorpAllianceBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            SecurityStatusLabel = new Label();
            AgeLabel = new Label();
            BasicDataPanel.SuspendLayout();
            TopSystemsPanel.SuspendLayout();
            ShipPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(3, 9);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(53, 21);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Name";
            // 
            // BasicDataPanel
            // 
            BasicDataPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BasicDataPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BasicDataPanel.BorderStyle = BorderStyle.FixedSingle;
            BasicDataPanel.Controls.Add(EdencomLossLabel);
            BasicDataPanel.Controls.Add(label18);
            BasicDataPanel.Controls.Add(MarauderLossLabel);
            BasicDataPanel.Controls.Add(label16);
            BasicDataPanel.Controls.Add(PvELossLabel);
            BasicDataPanel.Controls.Add(label15);
            BasicDataPanel.Controls.Add(SoloLabel);
            BasicDataPanel.Controls.Add(label14);
            BasicDataPanel.Controls.Add(AvgAttackersLabel);
            BasicDataPanel.Controls.Add(label13);
            BasicDataPanel.Controls.Add(DangerRatingLabel);
            BasicDataPanel.Controls.Add(label10);
            BasicDataPanel.Controls.Add(IsCynoPilotLabel);
            BasicDataPanel.Controls.Add(label6);
            BasicDataPanel.Controls.Add(LostValueLabel);
            BasicDataPanel.Controls.Add(label7);
            BasicDataPanel.Controls.Add(DestroyedValueLabel);
            BasicDataPanel.Controls.Add(label5);
            BasicDataPanel.Controls.Add(LossCountLabel);
            BasicDataPanel.Controls.Add(KillCountLabel);
            BasicDataPanel.Controls.Add(label3);
            BasicDataPanel.Controls.Add(label2);
            BasicDataPanel.Controls.Add(label1);
            BasicDataPanel.Location = new Point(3, 75);
            BasicDataPanel.Name = "BasicDataPanel";
            BasicDataPanel.Size = new Size(227, 340);
            BasicDataPanel.TabIndex = 1;
            // 
            // EdencomLossLabel
            // 
            EdencomLossLabel.AutoSize = true;
            EdencomLossLabel.Location = new Point(144, 230);
            EdencomLossLabel.Name = "EdencomLossLabel";
            EdencomLossLabel.Size = new Size(57, 15);
            EdencomLossLabel.TabIndex = 22;
            EdencomLossLabel.Text = "Edencom";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(3, 230);
            label18.Name = "label18";
            label18.Size = new Size(94, 15);
            label18.TabIndex = 21;
            label18.Text = "Edencom Losses";
            // 
            // MarauderLossLabel
            // 
            MarauderLossLabel.AutoSize = true;
            MarauderLossLabel.Location = new Point(144, 210);
            MarauderLossLabel.Name = "MarauderLossLabel";
            MarauderLossLabel.Size = new Size(63, 15);
            MarauderLossLabel.TabIndex = 20;
            MarauderLossLabel.Text = "Marauders";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(3, 210);
            label16.Name = "label16";
            label16.Size = new Size(95, 15);
            label16.TabIndex = 19;
            label16.Text = "Marauder Losses";
            // 
            // PvELossLabel
            // 
            PvELossLabel.AutoSize = true;
            PvELossLabel.Location = new Point(144, 190);
            PvELossLabel.Name = "PvELossLabel";
            PvELossLabel.Size = new Size(63, 15);
            PvELossLabel.TabIndex = 18;
            PvELossLabel.Text = "PvE Losses";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(3, 190);
            label15.Name = "label15";
            label15.Size = new Size(124, 15);
            label15.TabIndex = 17;
            label15.Text = "Drone PvE Ship Losses";
            // 
            // SoloLabel
            // 
            SoloLabel.AutoSize = true;
            SoloLabel.Location = new Point(144, 170);
            SoloLabel.Name = "SoloLabel";
            SoloLabel.Size = new Size(61, 15);
            SoloLabel.TabIndex = 16;
            SoloLabel.Text = "Solo Label";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(3, 170);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 15;
            label14.Text = "Solo Ratio";
            // 
            // AvgAttackersLabel
            // 
            AvgAttackersLabel.AutoSize = true;
            AvgAttackersLabel.Location = new Point(144, 150);
            AvgAttackersLabel.Name = "AvgAttackersLabel";
            AvgAttackersLabel.Size = new Size(83, 15);
            AvgAttackersLabel.TabIndex = 14;
            AvgAttackersLabel.Text = "Avg. Attackers";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(3, 150);
            label13.Name = "label13";
            label13.Size = new Size(102, 15);
            label13.TabIndex = 13;
            label13.Text = "Average Attackers";
            // 
            // DangerRatingLabel
            // 
            DangerRatingLabel.AutoSize = true;
            DangerRatingLabel.Location = new Point(144, 130);
            DangerRatingLabel.Name = "DangerRatingLabel";
            DangerRatingLabel.Size = new Size(82, 15);
            DangerRatingLabel.TabIndex = 12;
            DangerRatingLabel.Text = "Danger Rating";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 130);
            label10.Name = "label10";
            label10.Size = new Size(108, 15);
            label10.TabIndex = 11;
            label10.Text = "ZKill Danger Rating";
            // 
            // IsCynoPilotLabel
            // 
            IsCynoPilotLabel.AutoSize = true;
            IsCynoPilotLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            IsCynoPilotLabel.Location = new Point(144, 110);
            IsCynoPilotLabel.Name = "IsCynoPilotLabel";
            IsCynoPilotLabel.Size = new Size(74, 15);
            IsCynoPilotLabel.TabIndex = 10;
            IsCynoPilotLabel.Text = "Is Cyno Pilot";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(3, 110);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 9;
            label6.Text = "Is Cyno Pilot";
            // 
            // LostValueLabel
            // 
            LostValueLabel.AutoSize = true;
            LostValueLabel.Location = new Point(144, 90);
            LostValueLabel.Name = "LostValueLabel";
            LostValueLabel.Size = new Size(41, 15);
            LostValueLabel.TabIndex = 8;
            LostValueLabel.Text = "Losses";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 90);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 7;
            label7.Text = "Lost Value";
            // 
            // DestroyedValueLabel
            // 
            DestroyedValueLabel.AutoSize = true;
            DestroyedValueLabel.Location = new Point(144, 70);
            DestroyedValueLabel.Name = "DestroyedValueLabel";
            DestroyedValueLabel.Size = new Size(41, 15);
            DestroyedValueLabel.TabIndex = 6;
            DestroyedValueLabel.Text = "Losses";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 70);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 5;
            label5.Text = "Destroyed Value";
            // 
            // LossCountLabel
            // 
            LossCountLabel.AutoSize = true;
            LossCountLabel.Location = new Point(144, 50);
            LossCountLabel.Name = "LossCountLabel";
            LossCountLabel.Size = new Size(41, 15);
            LossCountLabel.TabIndex = 4;
            LossCountLabel.Text = "Losses";
            // 
            // KillCountLabel
            // 
            KillCountLabel.AutoSize = true;
            KillCountLabel.Location = new Point(144, 29);
            KillCountLabel.Name = "KillCountLabel";
            KillCountLabel.Size = new Size(28, 15);
            KillCountLabel.TabIndex = 3;
            KillCountLabel.Text = "Kills";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 50);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 2;
            label3.Text = "Losses";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "Kills";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(-1, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Basic Data";
            // 
            // TopSystemsPanel
            // 
            TopSystemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TopSystemsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopSystemsPanel.BorderStyle = BorderStyle.FixedSingle;
            TopSystemsPanel.Controls.Add(KillSystemTreeView);
            TopSystemsPanel.Controls.Add(label4);
            TopSystemsPanel.Controls.Add(label8);
            TopSystemsPanel.Location = new Point(245, 75);
            TopSystemsPanel.Name = "TopSystemsPanel";
            TopSystemsPanel.Size = new Size(200, 172);
            TopSystemsPanel.TabIndex = 2;
            // 
            // KillSystemTreeView
            // 
            KillSystemTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            KillSystemTreeView.Location = new Point(-1, 64);
            KillSystemTreeView.Name = "KillSystemTreeView";
            KillSystemTreeView.Size = new Size(200, 107);
            KillSystemTreeView.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 39);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 3;
            label4.Text = "Kills";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 1);
            label8.Name = "label8";
            label8.Size = new Size(119, 15);
            label8.TabIndex = 1;
            label8.Text = "Recent Top Systems";
            // 
            // ShipPanel
            // 
            ShipPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ShipPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ShipPanel.BorderStyle = BorderStyle.FixedSingle;
            ShipPanel.Controls.Add(TopShipsTreeView);
            ShipPanel.Controls.Add(label12);
            ShipPanel.Location = new Point(465, 75);
            ShipPanel.Name = "ShipPanel";
            ShipPanel.Size = new Size(200, 340);
            ShipPanel.TabIndex = 3;
            // 
            // TopShipsTreeView
            // 
            TopShipsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TopShipsTreeView.HideSelection = false;
            TopShipsTreeView.HotTracking = true;
            TopShipsTreeView.Location = new Point(-1, 64);
            TopShipsTreeView.Name = "TopShipsTreeView";
            TopShipsTreeView.Size = new Size(200, 275);
            TopShipsTreeView.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(3, 1);
            label12.Name = "label12";
            label12.Size = new Size(102, 15);
            label12.TabIndex = 1;
            label12.Text = "Recent Top Ships";
            // 
            // LoadLossesWorker
            // 
            LoadLossesWorker.WorkerSupportsCancellation = true;
            LoadLossesWorker.DoWork += LodLossesWorker_DoWork;
            LoadLossesWorker.RunWorkerCompleted += LodLossesWorker_RunWorkerCompleted;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(RecentLossesTreeView);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(685, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 340);
            panel1.TabIndex = 4;
            // 
            // RecentLossesTreeView
            // 
            RecentLossesTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            RecentLossesTreeView.Location = new Point(-1, 64);
            RecentLossesTreeView.Name = "RecentLossesTreeView";
            RecentLossesTreeView.Size = new Size(200, 275);
            RecentLossesTreeView.TabIndex = 2;
            RecentLossesTreeView.AfterSelect += RecentLossesTreeView_AfterSelect;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 1);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 1;
            label9.Text = "Recent Losses";
            // 
            // ZKillLabel
            // 
            ZKillLabel.AutoSize = true;
            ZKillLabel.Location = new Point(7, 29);
            ZKillLabel.Name = "ZKillLabel";
            ZKillLabel.Size = new Size(29, 15);
            ZKillLabel.TabIndex = 5;
            ZKillLabel.TabStop = true;
            ZKillLabel.Text = "Zkill";
            ZKillLabel.LinkClicked += ZKillLabel_LinkClicked;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(TopRegionsTreeView);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label17);
            panel2.Location = new Point(245, 253);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 162);
            panel2.TabIndex = 6;
            // 
            // TopRegionsTreeView
            // 
            TopRegionsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TopRegionsTreeView.Location = new Point(-1, 64);
            TopRegionsTreeView.Name = "TopRegionsTreeView";
            TopRegionsTreeView.Size = new Size(200, 97);
            TopRegionsTreeView.TabIndex = 4;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(3, 39);
            label11.Name = "label11";
            label11.Size = new Size(29, 15);
            label11.TabIndex = 3;
            label11.Text = "Kills";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(3, 1);
            label17.Name = "label17";
            label17.Size = new Size(117, 15);
            label17.TabIndex = 1;
            label17.Text = "Recent Top Regions";
            // 
            // CorpAllianceBackgroundWorker
            // 
            CorpAllianceBackgroundWorker.WorkerSupportsCancellation = true;
            CorpAllianceBackgroundWorker.DoWork += CorpAllianceBackgroundWorker_DoWork;
            CorpAllianceBackgroundWorker.RunWorkerCompleted += CorpAllianceBackgroundWorker_RunWorkerCompleted;
            // 
            // SecurityStatusLabel
            // 
            SecurityStatusLabel.AutoSize = true;
            SecurityStatusLabel.Location = new Point(7, 49);
            SecurityStatusLabel.Name = "SecurityStatusLabel";
            SecurityStatusLabel.Size = new Size(84, 15);
            SecurityStatusLabel.TabIndex = 8;
            SecurityStatusLabel.Text = "Security Status";
            // 
            // AgeLabel
            // 
            AgeLabel.AutoSize = true;
            AgeLabel.Location = new Point(202, 49);
            AgeLabel.Name = "AgeLabel";
            AgeLabel.Size = new Size(28, 15);
            AgeLabel.TabIndex = 9;
            AgeLabel.Text = "Age";
            // 
            // HunterIntelCharacterStats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(AgeLabel);
            Controls.Add(SecurityStatusLabel);
            Controls.Add(panel2);
            Controls.Add(ZKillLabel);
            Controls.Add(panel1);
            Controls.Add(ShipPanel);
            Controls.Add(TopSystemsPanel);
            Controls.Add(BasicDataPanel);
            Controls.Add(NameLabel);
            Name = "HunterIntelCharacterStats";
            Size = new Size(904, 418);
            BasicDataPanel.ResumeLayout(false);
            BasicDataPanel.PerformLayout();
            TopSystemsPanel.ResumeLayout(false);
            TopSystemsPanel.PerformLayout();
            ShipPanel.ResumeLayout(false);
            ShipPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Panel BasicDataPanel;
        private Label LossCountLabel;
        private Label KillCountLabel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label LostValueLabel;
        private Label label7;
        private Label DestroyedValueLabel;
        private Label label5;
        private Label IsCynoPilotLabel;
        private Label label6;
        private Panel TopSystemsPanel;
        private Label label8;
        private Label label4;
        private Panel ShipPanel;
        private Label label12;
        private TreeView TopShipsTreeView;
        private Label DangerRatingLabel;
        private Label label10;
        private System.ComponentModel.BackgroundWorker LoadLossesWorker;
        private TreeView KillSystemTreeView;
        private Panel panel1;
        private TreeView RecentLossesTreeView;
        private Label label9;
        private LinkLabel ZKillLabel;
        private Label AvgAttackersLabel;
        private Label label13;
        private Label SoloLabel;
        private Label label14;
        private Label PvELossLabel;
        private Label label15;
        private Label EdencomLossLabel;
        private Label label18;
        private Label MarauderLossLabel;
        private Label label16;
        private Panel panel2;
        private TreeView TopRegionsTreeView;
        private Label label11;
        private Label label17;
        private System.ComponentModel.BackgroundWorker CorpAllianceBackgroundWorker;
        private Label SecurityStatusLabel;
        private Label AgeLabel;
    }
}
