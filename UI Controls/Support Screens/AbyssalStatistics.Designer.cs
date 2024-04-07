namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class AbyssalStatistics
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
            components = new System.ComponentModel.Container();
            Label label1;
            Label label2;
            Label label3;
            Panel panel1;
            Label label11;
            Label label10;
            Label label5;
            Label label8;
            Label label7;
            Label label6;
            Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbyssalStatistics));
            LootFlowPanel = new FlowLayoutPanel();
            NumRunsLabel = new Label();
            AverageLootRunLabel = new Label();
            ProfitLabel = new Label();
            LootValueLabel = new Label();
            FilamentCostLabel = new Label();
            SuccessRateLabel = new Label();
            ShipClassCombo = new ComboBox();
            FilamentCombo = new ComboBox();
            ToolTipControl = new ToolTip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label11 = new Label();
            label10 = new Label();
            label5 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(55, 21);
            label1.TabIndex = 0;
            label1.Text = "Filters:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Ship Class";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 3;
            label3.Text = "Filament";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(LootFlowPanel);
            panel1.Controls.Add(NumRunsLabel);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(AverageLootRunLabel);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(ProfitLabel);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(LootValueLabel);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(FilamentCostLabel);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(SuccessRateLabel);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(264, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(657, 495);
            panel1.TabIndex = 5;
            // 
            // LootFlowPanel
            // 
            LootFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LootFlowPanel.AutoScroll = true;
            LootFlowPanel.FlowDirection = FlowDirection.TopDown;
            LootFlowPanel.Location = new Point(273, 49);
            LootFlowPanel.Name = "LootFlowPanel";
            LootFlowPanel.Size = new Size(381, 443);
            LootFlowPanel.TabIndex = 16;
            LootFlowPanel.TabStop = true;
            LootFlowPanel.WrapContents = false;
            // 
            // NumRunsLabel
            // 
            NumRunsLabel.AutoSize = true;
            NumRunsLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            NumRunsLabel.Location = new Point(140, 9);
            NumRunsLabel.Name = "NumRunsLabel";
            NumRunsLabel.Size = new Size(76, 20);
            NumRunsLabel.TabIndex = 15;
            NumRunsLabel.Text = "Num Runs";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(19, 9);
            label11.Name = "label11";
            label11.Size = new Size(71, 20);
            label11.TabIndex = 14;
            label11.Text = "# of Runs";
            // 
            // AverageLootRunLabel
            // 
            AverageLootRunLabel.AutoSize = true;
            AverageLootRunLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            AverageLootRunLabel.Location = new Point(140, 259);
            AverageLootRunLabel.Name = "AverageLootRunLabel";
            AverageLootRunLabel.Size = new Size(70, 20);
            AverageLootRunLabel.TabIndex = 13;
            AverageLootRunLabel.Text = "Loot/Run";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(19, 259);
            label10.Name = "label10";
            label10.Size = new Size(103, 20);
            label10.TabIndex = 12;
            label10.Text = "Avg. Loot/Run";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(273, 12);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 11;
            label5.Text = "Loot Drops";
            // 
            // ProfitLabel
            // 
            ProfitLabel.AutoSize = true;
            ProfitLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ProfitLabel.Location = new Point(140, 209);
            ProfitLabel.Name = "ProfitLabel";
            ProfitLabel.Size = new Size(45, 20);
            ProfitLabel.TabIndex = 9;
            ProfitLabel.Text = "Profit";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(19, 209);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 8;
            label8.Text = "Profit";
            // 
            // LootValueLabel
            // 
            LootValueLabel.AutoSize = true;
            LootValueLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LootValueLabel.Location = new Point(140, 159);
            LootValueLabel.Name = "LootValueLabel";
            LootValueLabel.Size = new Size(79, 20);
            LootValueLabel.TabIndex = 7;
            LootValueLabel.Text = "Loot Value";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(19, 159);
            label7.Name = "label7";
            label7.Size = new Size(79, 20);
            label7.TabIndex = 6;
            label7.Text = "Loot Value";
            // 
            // FilamentCostLabel
            // 
            FilamentCostLabel.AutoSize = true;
            FilamentCostLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FilamentCostLabel.Location = new Point(140, 106);
            FilamentCostLabel.Name = "FilamentCostLabel";
            FilamentCostLabel.Size = new Size(99, 20);
            FilamentCostLabel.TabIndex = 5;
            FilamentCostLabel.Text = "Filament Cost";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(19, 109);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 4;
            label6.Text = "Filament Cost";
            // 
            // SuccessRateLabel
            // 
            SuccessRateLabel.AutoSize = true;
            SuccessRateLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            SuccessRateLabel.Location = new Point(140, 59);
            SuccessRateLabel.Name = "SuccessRateLabel";
            SuccessRateLabel.Size = new Size(93, 20);
            SuccessRateLabel.TabIndex = 3;
            SuccessRateLabel.Text = "Success Rate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(19, 59);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 2;
            label4.Text = "Success Rate";
            // 
            // ShipClassCombo
            // 
            ShipClassCombo.FormattingEnabled = true;
            ShipClassCombo.Location = new Point(93, 72);
            ShipClassCombo.Name = "ShipClassCombo";
            ShipClassCombo.Size = new Size(165, 23);
            ShipClassCombo.TabIndex = 2;
            ShipClassCombo.SelectedIndexChanged += ShipClassCombo_SelectedIndexChanged;
            // 
            // FilamentCombo
            // 
            FilamentCombo.FormattingEnabled = true;
            FilamentCombo.Location = new Point(93, 112);
            FilamentCombo.Name = "FilamentCombo";
            FilamentCombo.Size = new Size(165, 23);
            FilamentCombo.TabIndex = 4;
            FilamentCombo.SelectedIndexChanged += FilamentCombo_SelectedIndexChanged;
            // 
            // AbyssalStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(933, 519);
            Controls.Add(panel1);
            Controls.Add(FilamentCombo);
            Controls.Add(label3);
            Controls.Add(ShipClassCombo);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AbyssalStatistics";
            Text = "Abyssal Statistics";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ShipClassCombo;
        private ComboBox FilamentCombo;
        private Panel panel1;
        private Label SuccessRateLabel;
        private Label ProfitLabel;
        private Label LootValueLabel;
        private Label FilamentCostLabel;
        private Label AverageLootRunLabel;
        private Label NumRunsLabel;
        private FlowLayoutPanel LootFlowPanel;
        private ToolTip ToolTipControl;
    }
}