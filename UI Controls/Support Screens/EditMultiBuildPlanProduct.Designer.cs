namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class EditMultiBuildPlanProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMultiBuildPlanProduct));
            AdditionalCostNumeric = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            RunsPerCopyNumeric = new NumericUpDown();
            label3 = new Label();
            NumCopiesNumeric = new NumericUpDown();
            label4 = new Label();
            CustomSellPriceNumeric = new NumericUpDown();
            SaveButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            CancelButton = new EveHelperWF.Objects.Custom_Controls.EveHelperButton();
            label5 = new Label();
            TENumeric = new NumericUpDown();
            label6 = new Label();
            MENumeric = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)AdditionalCostNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RunsPerCopyNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumCopiesNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomSellPriceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TENumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MENumeric).BeginInit();
            SuspendLayout();
            // 
            // AdditionalCostNumeric
            // 
            AdditionalCostNumeric.DecimalPlaces = 2;
            AdditionalCostNumeric.Location = new Point(155, 30);
            AdditionalCostNumeric.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            AdditionalCostNumeric.Name = "AdditionalCostNumeric";
            AdditionalCostNumeric.Size = new Size(321, 23);
            AdditionalCostNumeric.TabIndex = 0;
            AdditionalCostNumeric.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 1;
            label1.Text = "Additional Costs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 3;
            label2.Text = "Runs per Copy";
            // 
            // RunsPerCopyNumeric
            // 
            RunsPerCopyNumeric.Location = new Point(155, 70);
            RunsPerCopyNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            RunsPerCopyNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RunsPerCopyNumeric.Name = "RunsPerCopyNumeric";
            RunsPerCopyNumeric.Size = new Size(321, 23);
            RunsPerCopyNumeric.TabIndex = 2;
            RunsPerCopyNumeric.TextAlign = HorizontalAlignment.Right;
            RunsPerCopyNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(137, 21);
            label3.TabIndex = 5;
            label3.Text = "Number of Copies";
            // 
            // NumCopiesNumeric
            // 
            NumCopiesNumeric.Location = new Point(155, 110);
            NumCopiesNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumCopiesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumCopiesNumeric.Name = "NumCopiesNumeric";
            NumCopiesNumeric.Size = new Size(321, 23);
            NumCopiesNumeric.TabIndex = 4;
            NumCopiesNumeric.TextAlign = HorizontalAlignment.Right;
            NumCopiesNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 230);
            label4.Name = "label4";
            label4.Size = new Size(131, 21);
            label4.TabIndex = 7;
            label4.Text = "Custom Sell Price";
            // 
            // CustomSellPriceNumeric
            // 
            CustomSellPriceNumeric.DecimalPlaces = 2;
            CustomSellPriceNumeric.Location = new Point(155, 230);
            CustomSellPriceNumeric.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            CustomSellPriceNumeric.Name = "CustomSellPriceNumeric";
            CustomSellPriceNumeric.Size = new Size(321, 23);
            CustomSellPriceNumeric.TabIndex = 6;
            CustomSellPriceNumeric.TextAlign = HorizontalAlignment.Right;
            // 
            // SaveButton
            // 
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = Color.FromArgb(234, 234, 234);
            SaveButton.Location = new Point(183, 270);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 37);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.ForeColor = Color.FromArgb(234, 234, 234);
            CancelButton.Location = new Point(281, 270);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 37);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 190);
            label5.Name = "label5";
            label5.Size = new Size(26, 21);
            label5.TabIndex = 13;
            label5.Text = "TE";
            // 
            // TENumeric
            // 
            TENumeric.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            TENumeric.Location = new Point(155, 190);
            TENumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            TENumeric.Name = "TENumeric";
            TENumeric.Size = new Size(321, 23);
            TENumeric.TabIndex = 12;
            TENumeric.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 150);
            label6.Name = "label6";
            label6.Size = new Size(32, 21);
            label6.TabIndex = 11;
            label6.Text = "ME";
            // 
            // MENumeric
            // 
            MENumeric.Location = new Point(155, 150);
            MENumeric.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            MENumeric.Name = "MENumeric";
            MENumeric.Size = new Size(321, 23);
            MENumeric.TabIndex = 10;
            MENumeric.TextAlign = HorizontalAlignment.Right;
            // 
            // EditMultiBuildPlanProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 349);
            Controls.Add(label5);
            Controls.Add(TENumeric);
            Controls.Add(label6);
            Controls.Add(MENumeric);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label4);
            Controls.Add(CustomSellPriceNumeric);
            Controls.Add(label3);
            Controls.Add(NumCopiesNumeric);
            Controls.Add(label2);
            Controls.Add(RunsPerCopyNumeric);
            Controls.Add(label1);
            Controls.Add(AdditionalCostNumeric);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditMultiBuildPlanProduct";
            Text = "Edit Product";
            ((System.ComponentModel.ISupportInitialize)AdditionalCostNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)RunsPerCopyNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumCopiesNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomSellPriceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)TENumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)MENumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown AdditionalCostNumeric;
        private Label label1;
        private Label label2;
        private NumericUpDown RunsPerCopyNumeric;
        private Label label3;
        private NumericUpDown NumCopiesNumeric;
        private Label label4;
        private NumericUpDown CustomSellPriceNumeric;
        private Objects.Custom_Controls.EveHelperButton SaveButton;
        private Objects.Custom_Controls.EveHelperButton CancelButton;
        private Label label5;
        private NumericUpDown TENumeric;
        private Label label6;
        private NumericUpDown MENumeric;
    }
}