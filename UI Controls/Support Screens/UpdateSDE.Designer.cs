namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class UpdateSDE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateSDE));
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            UpdateSDEButton = new Button();
            panel1 = new Panel();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(551, 25);
            label1.TabIndex = 0;
            label1.Text = "How to update the Eve Static Data for a new Eve Online release";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 56);
            label2.Name = "label2";
            label2.Size = new Size(460, 23);
            label2.TabIndex = 1;
            label2.Text = "1.) Download the file named \"sqlite-latest.sqlite.bz2 \" from ";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            linkLabel1.LinkColor = Color.Gold;
            linkLabel1.Location = new Point(465, 56);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(93, 23);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Fuzzworks";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 267);
            label3.Name = "label3";
            label3.Size = new Size(483, 23);
            label3.TabIndex = 3;
            label3.Text = "2.) Using WinRar or 7Zip, extract the file you just downloaded";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(11, 301);
            label4.Name = "label4";
            label4.Size = new Size(751, 23);
            label4.TabIndex = 4;
            label4.Text = "3.) Once it is done extracting, locate the file named \"sqlite-latest.sqlite\". This is the file you need. ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(11, 436);
            label6.Name = "label6";
            label6.Size = new Size(512, 23);
            label6.TabIndex = 6;
            label6.Text = "5.) Done. You will need to close out any tools that you had open. ";
            // 
            // UpdateSDEButton
            // 
            UpdateSDEButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            UpdateSDEButton.ForeColor = Color.Black;
            UpdateSDEButton.Location = new Point(124, 386);
            UpdateSDEButton.Name = "UpdateSDEButton";
            UpdateSDEButton.Size = new Size(225, 40);
            UpdateSDEButton.TabIndex = 7;
            UpdateSDEButton.Text = "Update Static Data";
            UpdateSDEButton.UseVisualStyleBackColor = true;
            UpdateSDEButton.Click += UpdateSDEButton_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Location = new Point(37, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(521, 165);
            panel1.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.BackColor = Enums.Enums.BackgroundColor;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(12, 330);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(750, 50);
            textBox1.TabIndex = 9;
            textBox1.Text = "4.) Open EveHelper by right clicking and \"Run as Administrator\" and then click the \"Update Static Data\" button below and select the file from step 3.";
            // 
            // UpdateSDE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 539);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(UpdateSDEButton);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpdateSDE";
            Text = "Self-Update";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label4;
        private Label label6;
        private Button UpdateSDEButton;
        private Panel panel1;
        private TextBox textBox1;
    }
}