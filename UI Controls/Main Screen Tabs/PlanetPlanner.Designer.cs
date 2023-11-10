namespace EveHelperWF
{
    partial class PlanetPlanner
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
            OutputTreeView.BackColor = Color.FromArgb(54, 57, 53);
            OutputTreeView.ForeColor = SystemColors.ControlLight;
            OutputTreeView.HotTracking = true;
            OutputTreeView.Location = new Point(12, 12);
            OutputTreeView.Name = "OutputTreeView";
            OutputTreeView.Size = new Size(270, 1014);
            OutputTreeView.TabIndex = 0;
            OutputTreeView.AfterSelect += OutputTreeView_AfterSelect;
            // 
            // SchematicNameLabel
            // 
            SchematicNameLabel.AutoSize = true;
            SchematicNameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            SchematicNameLabel.Location = new Point(294, 12);
            SchematicNameLabel.Name = "SchematicNameLabel";
            SchematicNameLabel.Size = new Size(202, 35);
            SchematicNameLabel.TabIndex = 1;
            SchematicNameLabel.Text = "Schematic Name";
            // 
            // BubbleTreePanel
            // 
            BubbleTreePanel.AutoScroll = true;
            BubbleTreePanel.BackColor = SystemColors.AppWorkspace;
            BubbleTreePanel.BorderStyle = BorderStyle.Fixed3D;
            BubbleTreePanel.Location = new Point(288, 122);
            BubbleTreePanel.Name = "BubbleTreePanel";
            BubbleTreePanel.Size = new Size(1282, 904);
            BubbleTreePanel.TabIndex = 2;
            // 
            // PIOutputImagePanel
            // 
            PIOutputImagePanel.BackColor = Color.Transparent;
            PIOutputImagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            PIOutputImagePanel.Location = new Point(0, 2);
            PIOutputImagePanel.Name = "PIOutputImagePanel";
            PIOutputImagePanel.Size = new Size(64, 64);
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
            SchematicSummaryPanel.Location = new Point(288, 50);
            SchematicSummaryPanel.Name = "SchematicSummaryPanel";
            SchematicSummaryPanel.Size = new Size(1282, 66);
            SchematicSummaryPanel.TabIndex = 3;
            // 
            // InputBuyTotalLabel
            // 
            InputBuyTotalLabel.AutoSize = true;
            InputBuyTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            InputBuyTotalLabel.Location = new Point(876, 34);
            InputBuyTotalLabel.Name = "InputBuyTotalLabel";
            InputBuyTotalLabel.Size = new Size(88, 23);
            InputBuyTotalLabel.TabIndex = 15;
            InputBuyTotalLabel.Text = "Price Total";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(698, 34);
            label5.Name = "label5";
            label5.Size = new Size(150, 23);
            label5.TabIndex = 14;
            label5.Text = "Input Buy / Cycle: ";
            // 
            // InputSellTotalLabel
            // 
            InputSellTotalLabel.AutoSize = true;
            InputSellTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            InputSellTotalLabel.Location = new Point(876, 6);
            InputSellTotalLabel.Name = "InputSellTotalLabel";
            InputSellTotalLabel.Size = new Size(88, 23);
            InputSellTotalLabel.TabIndex = 13;
            InputSellTotalLabel.Text = "Price Total";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(698, 6);
            label8.Name = "label8";
            label8.Size = new Size(153, 23);
            label8.TabIndex = 12;
            label8.Text = "Input Sell / Cycle : ";
            // 
            // BuyPriceTotalLabel
            // 
            BuyPriceTotalLabel.AutoSize = true;
            BuyPriceTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            BuyPriceTotalLabel.Location = new Point(538, 34);
            BuyPriceTotalLabel.Name = "BuyPriceTotalLabel";
            BuyPriceTotalLabel.Size = new Size(88, 23);
            BuyPriceTotalLabel.TabIndex = 11;
            BuyPriceTotalLabel.Text = "Price Total";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(396, 34);
            label6.Name = "label6";
            label6.Size = new Size(104, 23);
            label6.TabIndex = 10;
            label6.Text = "Buy / Cycle: ";
            // 
            // SellPriceTotalLabel
            // 
            SellPriceTotalLabel.AutoSize = true;
            SellPriceTotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SellPriceTotalLabel.Location = new Point(538, 6);
            SellPriceTotalLabel.Name = "SellPriceTotalLabel";
            SellPriceTotalLabel.Size = new Size(88, 23);
            SellPriceTotalLabel.TabIndex = 7;
            SellPriceTotalLabel.Text = "Price Total";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(396, 6);
            label4.Name = "label4";
            label4.Size = new Size(107, 23);
            label4.TabIndex = 6;
            label4.Text = "Sell / Cycle : ";
            // 
            // OutputVolumeLabel
            // 
            OutputVolumeLabel.AutoSize = true;
            OutputVolumeLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            OutputVolumeLabel.Location = new Point(266, 34);
            OutputVolumeLabel.Name = "OutputVolumeLabel";
            OutputVolumeLabel.Size = new Size(68, 23);
            OutputVolumeLabel.TabIndex = 3;
            OutputVolumeLabel.Text = "Volume";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(90, 34);
            label2.Name = "label2";
            label2.Size = new Size(118, 23);
            label2.TabIndex = 2;
            label2.Text = "Total Volume :";
            // 
            // OutputQuantLabel
            // 
            OutputQuantLabel.AutoSize = true;
            OutputQuantLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            OutputQuantLabel.Location = new Point(266, 6);
            OutputQuantLabel.Name = "OutputQuantLabel";
            OutputQuantLabel.Size = new Size(58, 23);
            OutputQuantLabel.TabIndex = 1;
            OutputQuantLabel.Text = "Quant";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(90, 6);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 0;
            label1.Text = "Output Quantity : ";
            // 
            // CycleTimeLabel
            // 
            CycleTimeLabel.AutoSize = true;
            CycleTimeLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            CycleTimeLabel.Location = new Point(603, 12);
            CycleTimeLabel.Name = "CycleTimeLabel";
            CycleTimeLabel.Size = new Size(134, 35);
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
            PerfectPlanetsListLabel.AutoSize = true;
            PerfectPlanetsListLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PerfectPlanetsListLabel.Location = new Point(1576, 135);
            PerfectPlanetsListLabel.Name = "PerfectPlanetsListLabel";
            PerfectPlanetsListLabel.Size = new Size(41, 28);
            PerfectPlanetsListLabel.TabIndex = 5;
            PerfectPlanetsListLabel.Text = "List";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1576, 101);
            label7.Name = "label7";
            label7.Size = new Size(163, 28);
            label7.TabIndex = 6;
            label7.Text = "Minimum Planets";
            // 
            // SolarSystemSearchButton
            // 
            SolarSystemSearchButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SolarSystemSearchButton.ForeColor = Color.Black;
            SolarSystemSearchButton.Location = new Point(1576, 50);
            SolarSystemSearchButton.Name = "SolarSystemSearchButton";
            SolarSystemSearchButton.Size = new Size(169, 29);
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
            // PlanetPlanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
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
            Name = "PlanetPlanner";
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