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
            label4 = new Label();
            KillSystemListBox = new ListBox();
            label8 = new Label();
            ShipPanel = new Panel();
            TopShipsTreeView = new TreeView();
            label12 = new Label();
            BasicDataPanel.SuspendLayout();
            TopSystemsPanel.SuspendLayout();
            ShipPanel.SuspendLayout();
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
            BasicDataPanel.Location = new Point(3, 42);
            BasicDataPanel.Name = "BasicDataPanel";
            BasicDataPanel.Size = new Size(227, 373);
            BasicDataPanel.TabIndex = 1;
            // 
            // DangerRatingLabel
            // 
            DangerRatingLabel.AutoSize = true;
            DangerRatingLabel.Location = new Point(144, 189);
            DangerRatingLabel.Name = "DangerRatingLabel";
            DangerRatingLabel.Size = new Size(82, 15);
            DangerRatingLabel.TabIndex = 12;
            DangerRatingLabel.Text = "Danger Rating";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 189);
            label10.Name = "label10";
            label10.Size = new Size(108, 15);
            label10.TabIndex = 11;
            label10.Text = "ZKill Danger Rating";
            // 
            // IsCynoPilotLabel
            // 
            IsCynoPilotLabel.AutoSize = true;
            IsCynoPilotLabel.Location = new Point(144, 155);
            IsCynoPilotLabel.Name = "IsCynoPilotLabel";
            IsCynoPilotLabel.Size = new Size(73, 15);
            IsCynoPilotLabel.TabIndex = 10;
            IsCynoPilotLabel.Text = "Is Cyno Pilot";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 155);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 9;
            label6.Text = "Is Cyno Pilot";
            // 
            // LostValueLabel
            // 
            LostValueLabel.AutoSize = true;
            LostValueLabel.Location = new Point(144, 119);
            LostValueLabel.Name = "LostValueLabel";
            LostValueLabel.Size = new Size(41, 15);
            LostValueLabel.TabIndex = 8;
            LostValueLabel.Text = "Losses";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 119);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 7;
            label7.Text = "Lost Value";
            // 
            // DestroyedValueLabel
            // 
            DestroyedValueLabel.AutoSize = true;
            DestroyedValueLabel.Location = new Point(144, 88);
            DestroyedValueLabel.Name = "DestroyedValueLabel";
            DestroyedValueLabel.Size = new Size(41, 15);
            DestroyedValueLabel.TabIndex = 6;
            DestroyedValueLabel.Text = "Losses";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 88);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 5;
            label5.Text = "Destroyed Value";
            // 
            // LossCountLabel
            // 
            LossCountLabel.AutoSize = true;
            LossCountLabel.Location = new Point(144, 57);
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
            label3.Location = new Point(3, 57);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 2;
            label3.Text = "Losses";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 29);
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
            TopSystemsPanel.Controls.Add(label4);
            TopSystemsPanel.Controls.Add(KillSystemListBox);
            TopSystemsPanel.Controls.Add(label8);
            TopSystemsPanel.Location = new Point(247, 42);
            TopSystemsPanel.Name = "TopSystemsPanel";
            TopSystemsPanel.Size = new Size(200, 373);
            TopSystemsPanel.TabIndex = 2;
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
            // KillSystemListBox
            // 
            KillSystemListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            KillSystemListBox.FormattingEnabled = true;
            KillSystemListBox.HorizontalScrollbar = true;
            KillSystemListBox.ItemHeight = 15;
            KillSystemListBox.Location = new Point(1, 64);
            KillSystemListBox.Name = "KillSystemListBox";
            KillSystemListBox.Size = new Size(194, 304);
            KillSystemListBox.TabIndex = 2;
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
            ShipPanel.Location = new Point(474, 42);
            ShipPanel.Name = "ShipPanel";
            ShipPanel.Size = new Size(200, 373);
            ShipPanel.TabIndex = 3;
            // 
            // TopShipsTreeView
            // 
            TopShipsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TopShipsTreeView.Location = new Point(3, 64);
            TopShipsTreeView.Name = "TopShipsTreeView";
            TopShipsTreeView.Size = new Size(194, 304);
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
            // HunterIntelCharacterStats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(ShipPanel);
            Controls.Add(TopSystemsPanel);
            Controls.Add(BasicDataPanel);
            Controls.Add(NameLabel);
            Name = "HunterIntelCharacterStats";
            Size = new Size(677, 418);
            BasicDataPanel.ResumeLayout(false);
            BasicDataPanel.PerformLayout();
            TopSystemsPanel.ResumeLayout(false);
            TopSystemsPanel.PerformLayout();
            ShipPanel.ResumeLayout(false);
            ShipPanel.PerformLayout();
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
        private ListBox KillSystemListBox;
        private Panel ShipPanel;
        private Label label12;
        private TreeView TopShipsTreeView;
        private Label DangerRatingLabel;
        private Label label10;
    }
}
