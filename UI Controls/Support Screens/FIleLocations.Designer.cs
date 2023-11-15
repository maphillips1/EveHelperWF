namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class FIleLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIleLocations));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SQLiteLabel = new Label();
            AbyssRunLabel = new Label();
            PriceHistoryLabel = new Label();
            TrackedItemsLabel = new Label();
            label5 = new Label();
            DefaultFormValuesLabel = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(170, 23);
            label1.TabIndex = 0;
            label1.Text = "SQLite SDE Database";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(184, 23);
            label2.TabIndex = 1;
            label2.Text = "Price History Directory";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(30, 96);
            label3.Name = "label3";
            label3.Size = new Size(166, 23);
            label3.TabIndex = 2;
            label3.Text = "Abyss Run Directory";
            // 
            // SQLiteLabel
            // 
            SQLiteLabel.AutoSize = true;
            SQLiteLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            SQLiteLabel.Location = new Point(222, 9);
            SQLiteLabel.Name = "SQLiteLabel";
            SQLiteLabel.Size = new Size(67, 23);
            SQLiteLabel.TabIndex = 3;
            SQLiteLabel.Text = "[SQLite]";
            // 
            // AbyssRunLabel
            // 
            AbyssRunLabel.AutoSize = true;
            AbyssRunLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            AbyssRunLabel.Location = new Point(222, 96);
            AbyssRunLabel.Name = "AbyssRunLabel";
            AbyssRunLabel.Size = new Size(96, 23);
            AbyssRunLabel.TabIndex = 4;
            AbyssRunLabel.Text = "[Abyss Run]";
            // 
            // PriceHistoryLabel
            // 
            PriceHistoryLabel.AutoSize = true;
            PriceHistoryLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            PriceHistoryLabel.Location = new Point(222, 56);
            PriceHistoryLabel.Name = "PriceHistoryLabel";
            PriceHistoryLabel.Size = new Size(112, 23);
            PriceHistoryLabel.TabIndex = 5;
            PriceHistoryLabel.Text = "[Price History]";
            // 
            // TrackedItemsLabel
            // 
            TrackedItemsLabel.AutoSize = true;
            TrackedItemsLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            TrackedItemsLabel.Location = new Point(222, 141);
            TrackedItemsLabel.Name = "TrackedItemsLabel";
            TrackedItemsLabel.Size = new Size(122, 23);
            TrackedItemsLabel.TabIndex = 7;
            TrackedItemsLabel.Text = "[Tracked Items]";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(4, 141);
            label5.Name = "label5";
            label5.Size = new Size(192, 23);
            label5.TabIndex = 6;
            label5.Text = "Tracked Items Directory";
            // 
            // DefaultFormValuesLabel
            // 
            DefaultFormValuesLabel.AutoSize = true;
            DefaultFormValuesLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            DefaultFormValuesLabel.Location = new Point(222, 187);
            DefaultFormValuesLabel.Name = "DefaultFormValuesLabel";
            DefaultFormValuesLabel.Size = new Size(169, 23);
            DefaultFormValuesLabel.TabIndex = 9;
            DefaultFormValuesLabel.Text = "[Default Form Values]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(47, 187);
            label6.Name = "label6";
            label6.Size = new Size(149, 23);
            label6.TabIndex = 8;
            label6.Text = "Defaults Directory";
            // 
            // FIleLocations
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 450);
            Controls.Add(DefaultFormValuesLabel);
            Controls.Add(label6);
            Controls.Add(TrackedItemsLabel);
            Controls.Add(label5);
            Controls.Add(PriceHistoryLabel);
            Controls.Add(AbyssRunLabel);
            Controls.Add(SQLiteLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FIleLocations";
            Text = "File Locations";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label SQLiteLabel;
        private Label AbyssRunLabel;
        private Label PriceHistoryLabel;
        private Label TrackedItemsLabel;
        private Label label5;
        private Label DefaultFormValuesLabel;
        private Label label6;
    }
}