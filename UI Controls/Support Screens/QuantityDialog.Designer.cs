namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class QuantityDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantityDialog));
            SaveButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            QuantityUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)QuantityUpDown).BeginInit();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(12, 69);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.ForeColor = Color.Black;
            CancelButton.Location = new Point(119, 69);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "Quantity";
            // 
            // QuantityUpDown
            // 
            QuantityUpDown.Location = new Point(74, 30);
            QuantityUpDown.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            QuantityUpDown.Name = "QuantityUpDown";
            QuantityUpDown.Size = new Size(120, 23);
            QuantityUpDown.TabIndex = 3;
            QuantityUpDown.ThousandsSeparator = true;
            QuantityUpDown.KeyDown += QuantityUpDown_KeyDown;
            QuantityUpDown.KeyUp += Numeric_KeyUp;
            // 
            // QuantityDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(219, 125);
            Controls.Add(QuantityUpDown);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "QuantityDialog";
            Text = "File Name";
            ((System.ComponentModel.ISupportInitialize)QuantityUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SaveButton;
        private Button CancelButton;
        private Label label1;
        public NumericUpDown QuantityUpDown;
    }
}