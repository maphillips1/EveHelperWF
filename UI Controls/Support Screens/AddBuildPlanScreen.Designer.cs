namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class AddBuildPlanScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBuildPlanScreen));
            label1 = new Label();
            PlanNameTextBox = new TextBox();
            ProductCombo = new ComboBox();
            label2 = new Label();
            AddButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 0;
            label1.Text = "Build Plan Name";
            // 
            // PlanNameTextBox
            // 
            PlanNameTextBox.Location = new Point(154, 11);
            PlanNameTextBox.Name = "PlanNameTextBox";
            PlanNameTextBox.Size = new Size(297, 23);
            PlanNameTextBox.TabIndex = 1;
            // 
            // ProductCombo
            // 
            ProductCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            ProductCombo.DropDownHeight = 150;
            ProductCombo.FormattingEnabled = true;
            ProductCombo.IntegralHeight = false;
            ProductCombo.ItemHeight = 15;
            ProductCombo.Location = new Point(154, 66);
            ProductCombo.Name = "ProductCombo";
            ProductCombo.Size = new Size(297, 23);
            ProductCombo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 64);
            label2.Name = "label2";
            label2.Size = new Size(121, 21);
            label2.TabIndex = 3;
            label2.Text = "Product to Build";
            // 
            // AddButton
            // 
            AddButton.ForeColor = Color.Black;
            AddButton.Location = new Point(69, 126);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(121, 45);
            AddButton.TabIndex = 4;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.ForeColor = Color.Black;
            CancelButton.Location = new Point(284, 126);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(121, 45);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddBuildPlanScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 257);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(label2);
            Controls.Add(ProductCombo);
            Controls.Add(PlanNameTextBox);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddBuildPlanScreen";
            Text = "New Build Plan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public TextBox PlanNameTextBox;
        public ComboBox ProductCombo;
        private Label label2;
        private Button AddButton;
        private Button CancelButton;
    }
}