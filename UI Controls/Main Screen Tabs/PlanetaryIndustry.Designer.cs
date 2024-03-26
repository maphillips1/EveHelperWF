namespace EveHelperWF
{
    partial class PlanetaryIndustry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanetaryIndustry));
            OutputTreeView = new TreeView();
            SchematicNameLabel = new Label();
            BubbleTreePanel = new Panel();
            PIOutputImagePanel = new Panel();
            SchematicSummaryPanel = new Panel();
            InputBuyTotalLabel = new Label();
            label5 = new Label();
            InputSellTotalLabel = new Label();
            label8 = new Label();
            BuyPriceTotalLabel = new Label();
            label6 = new Label();
            SellPriceTotalLabel = new Label();
            label4 = new Label();
            OutputVolumeLabel = new Label();
            label2 = new Label();
            OutputQuantLabel = new Label();
            label1 = new Label();
            CycleTimeLabel = new Label();
            GetPricesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            PerfectPlanetsListLabel = new Label();
            label7 = new Label();
            SolarSystemSearchButton = new Button();
            PIOutputImageWorker = new System.ComponentModel.BackgroundWorker();
            SchematicSummaryPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OutputTreeView
            // 
            OutputTreeView.BackColor = Color.FromArgb(2, 23, 38);
            OutputTreeView.ForeColor = SystemColors.ControlLight;
            OutputTreeView.HotTracking = true;
            OutputTreeView.Location = new Point(10, 9);
            OutputTreeView.Margin = new Padding(3, 2, 3, 2);
            OutputTreeView.Name = "OutputTreeView";
            OutputTreeView.Size = new Size(237, 762);
            OutputTreeView.TabIndex = 0;
            OutputTreeView.TabStop = false;
            OutputTreeView.AfterSelect += OutputTreeView_AfterSelect;
            // 
            // SchematicNameLabel
            // 
            SchematicNameLabel.AutoSize = true;
            SchematicNameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            SchematicNameLabel.Location = new Point(257, 9);
            SchematicNameLabel.Name = "SchematicNameLabel";
            SchematicNameLabel.Size = new Size(158, 28);
            SchematicNameLabel.TabIndex = 1;
            SchematicNameLabel.Text = "Schematic Name";
            // 
            // BubbleTreePanel
            // 
            BubbleTreePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BubbleTreePanel.AutoScroll = true;
            BubbleTreePanel.BackColor = Color.Black;
            BubbleTreePanel.BorderStyle = BorderStyle.Fixed3D;
            BubbleTreePanel.Location = new Point(252, 94);
            BubbleTreePanel.Margin = new Padding(3, 2, 3, 2);
            BubbleTreePanel.Name = "BubbleTreePanel";
            BubbleTreePanel.Size = new Size(1063, 529);
            BubbleTreePanel.TabIndex = 2;
            // 
            // PIOutputImagePanel
            // 
            PIOutputImagePanel.BackColor = Color.Transparent;
            PIOutputImagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            PIOutputImagePanel.Location = new Point(0, 2);
            PIOutputImagePanel.Margin = new Padding(3, 2, 3, 2);
            PIOutputImagePanel.Name = "PIOutputImagePanel";
            PIOutputImagePanel.Size = new Size(56, 48);
            PIOutputImagePanel.TabIndex = 8;
            // 
            // SchematicSummaryPanel
            // 
            SchematicSummaryPanel.Controls.Add(PIOutputImagePanel);
            SchematicSummaryPanel.Controls.Add(InputBuyTotalLabel);
            SchematicSummaryPanel.Controls.Add(label5);
            SchematicSummaryPanel.Controls.Add(InputSellTotalLabel);
            SchematicSummaryPanel.Controls.Add(label8);
            SchematicSummaryPanel.Controls.Add(BuyPriceTotalLabel);
            SchematicSummaryPanel.Controls.Add(label6);
            SchematicSummaryPanel.Controls.Add(SellPriceTotalLabel);
            SchematicSummaryPanel.Controls.Add(label4);
            SchematicSummaryPanel.Controls.Add(OutputVolumeLabel);
            SchematicSummaryPanel.Controls.Add(label2);
            SchematicSummaryPanel.Controls.Add(OutputQuantLabel);
            SchematicSummaryPanel.Controls.Add(label1);
            SchematicSummaryPanel.Location = new Point(252, 38);
            SchematicSummaryPanel.Margin = new Padding(3, 2, 3, 2);
            SchematicSummaryPanel.Name = "SchematicSummaryPanel";
            SchematicSummaryPanel.Size = new Size(1063, 50);
            SchematicSummaryPanel.TabIndex = 3;
            // 
            // InputBuyTotalLabel
            // 
            InputBuyTotalLabel.AutoSize = true;
            InputBuyTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            InputBuyTotalLabel.Location = new Point(766, 26);
            InputBuyTotalLabel.Name = "InputBuyTotalLabel";
            InputBuyTotalLabel.Size = new Size(71, 19);
            InputBuyTotalLabel.TabIndex = 15;
            InputBuyTotalLabel.Text = "Price Total";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(611, 26);
            label5.Name = "label5";
            label5.Size = new Size(121, 19);
            label5.TabIndex = 14;
            label5.Text = "Input Buy / Cycle: ";
            // 
            // InputSellTotalLabel
            // 
            InputSellTotalLabel.AutoSize = true;
            InputSellTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            InputSellTotalLabel.Location = new Point(766, 4);
            InputSellTotalLabel.Name = "InputSellTotalLabel";
            InputSellTotalLabel.Size = new Size(71, 19);
            InputSellTotalLabel.TabIndex = 13;
            InputSellTotalLabel.Text = "Price Total";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(611, 4);
            label8.Name = "label8";
            label8.Size = new Size(122, 19);
            label8.TabIndex = 12;
            label8.Text = "Input Sell / Cycle : ";
            // 
            // BuyPriceTotalLabel
            // 
            BuyPriceTotalLabel.AutoSize = true;
            BuyPriceTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            BuyPriceTotalLabel.Location = new Point(471, 26);
            BuyPriceTotalLabel.Name = "BuyPriceTotalLabel";
            BuyPriceTotalLabel.Size = new Size(71, 19);
            BuyPriceTotalLabel.TabIndex = 11;
            BuyPriceTotalLabel.Text = "Price Total";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(346, 26);
            label6.Name = "label6";
            label6.Size = new Size(84, 19);
            label6.TabIndex = 10;
            label6.Text = "Buy / Cycle: ";
            // 
            // SellPriceTotalLabel
            // 
            SellPriceTotalLabel.AutoSize = true;
            SellPriceTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SellPriceTotalLabel.Location = new Point(471, 4);
            SellPriceTotalLabel.Name = "SellPriceTotalLabel";
            SellPriceTotalLabel.Size = new Size(71, 19);
            SellPriceTotalLabel.TabIndex = 7;
            SellPriceTotalLabel.Text = "Price Total";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(346, 4);
            label4.Name = "label4";
            label4.Size = new Size(85, 19);
            label4.TabIndex = 6;
            label4.Text = "Sell / Cycle : ";
            // 
            // OutputVolumeLabel
            // 
            OutputVolumeLabel.AutoSize = true;
            OutputVolumeLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            OutputVolumeLabel.Location = new Point(233, 26);
            OutputVolumeLabel.Name = "OutputVolumeLabel";
            OutputVolumeLabel.Size = new Size(55, 19);
            OutputVolumeLabel.TabIndex = 3;
            OutputVolumeLabel.Text = "Volume";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(79, 26);
            label2.Name = "label2";
            label2.Size = new Size(95, 19);
            label2.TabIndex = 2;
            label2.Text = "Total Volume :";
            // 
            // OutputQuantLabel
            // 
            OutputQuantLabel.AutoSize = true;
            OutputQuantLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            OutputQuantLabel.Location = new Point(233, 4);
            OutputQuantLabel.Name = "OutputQuantLabel";
            OutputQuantLabel.Size = new Size(48, 19);
            OutputQuantLabel.TabIndex = 1;
            OutputQuantLabel.Text = "Quant";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(79, 4);
            label1.Name = "label1";
            label1.Size = new Size(123, 19);
            label1.TabIndex = 0;
            label1.Text = "Output Quantity : ";
            // 
            // CycleTimeLabel
            // 
            CycleTimeLabel.AutoSize = true;
            CycleTimeLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            CycleTimeLabel.Location = new Point(598, 7);
            CycleTimeLabel.Name = "CycleTimeLabel";
            CycleTimeLabel.Size = new Size(105, 28);
            CycleTimeLabel.TabIndex = 4;
            CycleTimeLabel.Text = "Cycle Time";
            // 
            // GetPricesBackgroundWorker
            // 
            GetPricesBackgroundWorker.WorkerSupportsCancellation = true;
            GetPricesBackgroundWorker.DoWork += GetPricesBackgroundWorker_DoWork;
            GetPricesBackgroundWorker.RunWorkerCompleted += GetPricesBackgroundWorker_Completed;
            // 
            // PerfectPlanetsListLabel
            // 
            PerfectPlanetsListLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PerfectPlanetsListLabel.AutoSize = true;
            PerfectPlanetsListLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PerfectPlanetsListLabel.Location = new Point(1385, 120);
            PerfectPlanetsListLabel.Name = "PerfectPlanetsListLabel";
            PerfectPlanetsListLabel.Size = new Size(34, 21);
            PerfectPlanetsListLabel.TabIndex = 5;
            PerfectPlanetsListLabel.Text = "List";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1385, 94);
            label7.Name = "label7";
            label7.Size = new Size(132, 21);
            label7.TabIndex = 6;
            label7.Text = "Minimum Planets";
            // 
            // SolarSystemSearchButton
            // 
            SolarSystemSearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SolarSystemSearchButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SolarSystemSearchButton.ForeColor = Color.Black;
            SolarSystemSearchButton.Location = new Point(1380, 64);
            SolarSystemSearchButton.Margin = new Padding(3, 2, 3, 2);
            SolarSystemSearchButton.Name = "SolarSystemSearchButton";
            SolarSystemSearchButton.Size = new Size(148, 24);
            SolarSystemSearchButton.TabIndex = 7;
            SolarSystemSearchButton.Text = "Find Solar Systems";
            SolarSystemSearchButton.UseVisualStyleBackColor = true;
            SolarSystemSearchButton.Click += SolarSystemSearchButton_Click;
            // 
            // PIOutputImageWorker
            // 
            PIOutputImageWorker.DoWork += PIOutputImageWorker_DoWork;
            PIOutputImageWorker.RunWorkerCompleted += PIOutputImageWorker_RunWorkerCompleted;
            // 
            // PlanetaryIndustry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 634);
            Controls.Add(SolarSystemSearchButton);
            Controls.Add(label7);
            Controls.Add(PerfectPlanetsListLabel);
            Controls.Add(CycleTimeLabel);
            Controls.Add(SchematicSummaryPanel);
            Controls.Add(BubbleTreePanel);
            Controls.Add(SchematicNameLabel);
            Controls.Add(OutputTreeView);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PlanetaryIndustry";
            Text = "Planetary Interaction";
            Resize += PlanetPlanner_Resize;
            SchematicSummaryPanel.ResumeLayout(false);
            SchematicSummaryPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView OutputTreeView;
        private Label SchematicNameLabel;
        private Panel BubbleTreePanel;
        private Panel SchematicSummaryPanel;
        private Label label1;
        private Label OutputQuantLabel;
        private Label OutputVolumeLabel;
        private Label label2;
        private Label label4;
        private Label SellPriceTotalLabel;
        private Label BuyPriceTotalLabel;
        private Label label6;
        private Label CycleTimeLabel;
        private Label InputBuyTotalLabel;
        private Label label5;
        private Label InputSellTotalLabel;
        private Label label8;
        private System.ComponentModel.BackgroundWorker GetPricesBackgroundWorker;
        private Label PerfectPlanetsListLabel;
        private Label label7;
        private Button SolarSystemSearchButton;
        private Panel PIOutputImagePanel;
        private System.ComponentModel.BackgroundWorker PIOutputImageWorker;
    }
}