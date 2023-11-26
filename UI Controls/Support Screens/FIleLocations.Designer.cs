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
            panel1 = new Panel();
            PriceHistoryLabel = new LinkLabel();
            AbyssRunLabel = new LinkLabel();
            TrackedItemsLabel = new LinkLabel();
            DefaultFormValuesLabel = new LinkLabel();
            SQLiteLabel = new LinkLabel();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(PriceHistoryLabel);
            panel1.Controls.Add(AbyssRunLabel);
            panel1.Controls.Add(TrackedItemsLabel);
            panel1.Controls.Add(DefaultFormValuesLabel);
            panel1.Controls.Add(SQLiteLabel);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(783, 262);
            panel1.TabIndex = 0;
            // 
            // PriceHistoryLabel
            // 
            PriceHistoryLabel.AutoSize = true;
            PriceHistoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            PriceHistoryLabel.LinkColor = Color.Gold;
            PriceHistoryLabel.Location = new Point(221, 58);
            PriceHistoryLabel.Name = "PriceHistoryLabel";
            PriceHistoryLabel.Size = new Size(111, 20);
            PriceHistoryLabel.TabIndex = 23;
            PriceHistoryLabel.TabStop = true;
            PriceHistoryLabel.Text = "[Price History]";
            PriceHistoryLabel.LinkClicked += PriceHistoryLabel_LinkClicked;
            // 
            // AbyssRunLabel
            // 
            AbyssRunLabel.AutoSize = true;
            AbyssRunLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AbyssRunLabel.LinkColor = Color.Gold;
            AbyssRunLabel.Location = new Point(221, 99);
            AbyssRunLabel.Name = "AbyssRunLabel";
            AbyssRunLabel.Size = new Size(95, 20);
            AbyssRunLabel.TabIndex = 22;
            AbyssRunLabel.TabStop = true;
            AbyssRunLabel.Text = "[Abyss Run]";
            AbyssRunLabel.LinkClicked += AbyssRunLabel_LinkClicked;
            // 
            // TrackedItemsLabel
            // 
            TrackedItemsLabel.AutoSize = true;
            TrackedItemsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TrackedItemsLabel.LinkColor = Color.Gold;
            TrackedItemsLabel.Location = new Point(221, 143);
            TrackedItemsLabel.Name = "TrackedItemsLabel";
            TrackedItemsLabel.Size = new Size(119, 20);
            TrackedItemsLabel.TabIndex = 21;
            TrackedItemsLabel.TabStop = true;
            TrackedItemsLabel.Text = "[Tracked Items]";
            TrackedItemsLabel.LinkClicked += TrackedItemsLabel_LinkClicked;
            // 
            // DefaultFormValuesLabel
            // 
            DefaultFormValuesLabel.AutoSize = true;
            DefaultFormValuesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DefaultFormValuesLabel.LinkColor = Color.Gold;
            DefaultFormValuesLabel.Location = new Point(221, 190);
            DefaultFormValuesLabel.Name = "DefaultFormValuesLabel";
            DefaultFormValuesLabel.Size = new Size(163, 20);
            DefaultFormValuesLabel.TabIndex = 20;
            DefaultFormValuesLabel.TabStop = true;
            DefaultFormValuesLabel.Text = "[Default Form Values]";
            DefaultFormValuesLabel.LinkClicked += DefaultFormValuesLabel_LinkClicked;
            // 
            // SQLiteLabel
            // 
            SQLiteLabel.AutoSize = true;
            SQLiteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SQLiteLabel.LinkColor = Color.Gold;
            SQLiteLabel.Location = new Point(221, 11);
            SQLiteLabel.Name = "SQLiteLabel";
            SQLiteLabel.Size = new Size(102, 20);
            SQLiteLabel.TabIndex = 1;
            SQLiteLabel.TabStop = true;
            SQLiteLabel.Text = "[SQLite Path]";
            SQLiteLabel.LinkClicked += SQLiteLabel_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(46, 187);
            label6.Name = "label6";
            label6.Size = new Size(149, 23);
            label6.TabIndex = 18;
            label6.Text = "Defaults Directory";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(3, 141);
            label5.Name = "label5";
            label5.Size = new Size(192, 23);
            label5.TabIndex = 16;
            label5.Text = "Tracked Items Directory";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(29, 96);
            label3.Name = "label3";
            label3.Size = new Size(166, 23);
            label3.TabIndex = 12;
            label3.Text = "Abyss Run Directory";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 56);
            label2.Name = "label2";
            label2.Size = new Size(184, 23);
            label2.TabIndex = 11;
            label2.Text = "Price History Directory";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(25, 9);
            label1.Name = "label1";
            label1.Size = new Size(170, 23);
            label1.TabIndex = 10;
            label1.Text = "SQLite SDE Database";
            // 
            // FIleLocations
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 262);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FIleLocations";
            Text = "File Locations";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private LinkLabel PriceHistoryLabel;
        private LinkLabel DefaultFormValuesLabel;
        private LinkLabel TrackedItemsLabel;
        private LinkLabel SQLiteLabel;
        private LinkLabel AbyssRunLabel;
    }
}