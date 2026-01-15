namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class ShippingCalculator
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
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            Label label6;
            CostMCubed = new NumericUpDown();
            IskPercentage = new NumericUpDown();
            FuelCost = new NumericUpDown();
            AdditionalCost = new NumericUpDown();
            TotalCostLabel = new Label();
            VolumeNumeric = new NumericUpDown();
            CollateralNumeric = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)CostMCubed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IskPercentage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FuelCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdditionalCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VolumeNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CollateralNumeric).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 96);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 0;
            label1.Text = "Cost per m3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 136);
            label2.Name = "label2";
            label2.Size = new Size(151, 21);
            label2.TabIndex = 1;
            label2.Text = "Isk Value Percentage";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 176);
            label3.Name = "label3";
            label3.Size = new Size(74, 21);
            label3.TabIndex = 2;
            label3.Text = "Fuel Cost";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 216);
            label4.Name = "label4";
            label4.Size = new Size(116, 21);
            label4.TabIndex = 3;
            label4.Text = "Additional Cost";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 18);
            label5.Name = "label5";
            label5.Size = new Size(63, 21);
            label5.TabIndex = 9;
            label5.Text = "Volume";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 57);
            label6.Name = "label6";
            label6.Size = new Size(76, 21);
            label6.TabIndex = 11;
            label6.Text = "Collateral";
            // 
            // CostMCubed
            // 
            CostMCubed.DecimalPlaces = 2;
            CostMCubed.Location = new Point(212, 96);
            CostMCubed.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            CostMCubed.Name = "CostMCubed";
            CostMCubed.Size = new Size(120, 23);
            CostMCubed.TabIndex = 4;
            CostMCubed.ThousandsSeparator = true;
            CostMCubed.ValueChanged += Numeric_ValueChanged;
            // 
            // IskPercentage
            // 
            IskPercentage.DecimalPlaces = 2;
            IskPercentage.Location = new Point(212, 136);
            IskPercentage.Name = "IskPercentage";
            IskPercentage.Size = new Size(120, 23);
            IskPercentage.TabIndex = 5;
            IskPercentage.ThousandsSeparator = true;
            IskPercentage.ValueChanged += Numeric_ValueChanged;
            // 
            // FuelCost
            // 
            FuelCost.DecimalPlaces = 2;
            FuelCost.Location = new Point(212, 176);
            FuelCost.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            FuelCost.Name = "FuelCost";
            FuelCost.Size = new Size(120, 23);
            FuelCost.TabIndex = 6;
            FuelCost.ThousandsSeparator = true;
            FuelCost.ValueChanged += Numeric_ValueChanged;
            // 
            // AdditionalCost
            // 
            AdditionalCost.DecimalPlaces = 2;
            AdditionalCost.Location = new Point(212, 216);
            AdditionalCost.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            AdditionalCost.Name = "AdditionalCost";
            AdditionalCost.Size = new Size(120, 23);
            AdditionalCost.TabIndex = 7;
            AdditionalCost.ThousandsSeparator = true;
            AdditionalCost.ValueChanged += Numeric_ValueChanged;
            // 
            // TotalCostLabel
            // 
            TotalCostLabel.AutoSize = true;
            TotalCostLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalCostLabel.ForeColor = Color.Gold;
            TotalCostLabel.Location = new Point(114, 276);
            TotalCostLabel.Name = "TotalCostLabel";
            TotalCostLabel.Size = new Size(99, 25);
            TotalCostLabel.TabIndex = 8;
            TotalCostLabel.Text = "Total Cost";
            // 
            // VolumeNumeric
            // 
            VolumeNumeric.DecimalPlaces = 2;
            VolumeNumeric.Location = new Point(212, 18);
            VolumeNumeric.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            VolumeNumeric.Name = "VolumeNumeric";
            VolumeNumeric.Size = new Size(120, 23);
            VolumeNumeric.TabIndex = 10;
            VolumeNumeric.ThousandsSeparator = true;
            VolumeNumeric.ValueChanged += Numeric_ValueChanged;
            // 
            // CollateralNumeric
            // 
            CollateralNumeric.DecimalPlaces = 2;
            CollateralNumeric.Location = new Point(212, 57);
            CollateralNumeric.Maximum = new decimal(new int[] { 276447232, 23283, 0, 0 });
            CollateralNumeric.Name = "CollateralNumeric";
            CollateralNumeric.Size = new Size(120, 23);
            CollateralNumeric.TabIndex = 12;
            CollateralNumeric.ThousandsSeparator = true;
            // 
            // ShippingCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CollateralNumeric);
            Controls.Add(label6);
            Controls.Add(VolumeNumeric);
            Controls.Add(label5);
            Controls.Add(TotalCostLabel);
            Controls.Add(AdditionalCost);
            Controls.Add(FuelCost);
            Controls.Add(IskPercentage);
            Controls.Add(CostMCubed);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ShippingCalculator";
            Size = new Size(451, 338);
            ((System.ComponentModel.ISupportInitialize)CostMCubed).EndInit();
            ((System.ComponentModel.ISupportInitialize)IskPercentage).EndInit();
            ((System.ComponentModel.ISupportInitialize)FuelCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdditionalCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)VolumeNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)CollateralNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown CostMCubed;
        private NumericUpDown IskPercentage;
        private NumericUpDown FuelCost;
        private NumericUpDown AdditionalCost;
        private Label TotalCostLabel;
        private NumericUpDown VolumeNumeric;
        private NumericUpDown CollateralNumeric;
    }
}
