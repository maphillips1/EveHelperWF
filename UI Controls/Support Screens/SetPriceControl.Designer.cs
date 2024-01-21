namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class SetPriceControl
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
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPriceControl));
            PricePerItem = new NumericUpDown();
            SaveButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)PricePerItem).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(45, 27);
            label1.Name = "label1";
            label1.Size = new Size(112, 21);
            label1.TabIndex = 0;
            label1.Text = "Price Per Item: ";
            // 
            // PricePerItem
            // 
            PricePerItem.DecimalPlaces = 2;
            PricePerItem.Location = new Point(163, 30);
            PricePerItem.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            PricePerItem.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PricePerItem.Name = "PricePerItem";
            PricePerItem.Size = new Size(120, 23);
            PricePerItem.TabIndex = 1;
            PricePerItem.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SaveButton
            // 
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(82, 79);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.ForeColor = Color.Black;
            CancelButton.Location = new Point(179, 79);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SetPriceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 150);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(PricePerItem);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SetPriceControl";
            Text = "Price Per Item";
            ((System.ComponentModel.ISupportInitialize)PricePerItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public NumericUpDown PricePerItem;
        private Button SaveButton;
        private Button CancelButton;
    }
}