namespace EveHelperWF
{
    partial class MainDefaults
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RunsUpDown = new System.Windows.Forms.NumericUpDown();
            this.InputOrderTypeCombo = new System.Windows.Forms.ComboBox();
            this.OutputOrderTypeCombo = new System.Windows.Forms.ComboBox();
            this.InventBlueprintCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.RunsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(174, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Runs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(59, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input Order Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(42, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Output Order Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(66, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Invent Blueprint";
            // 
            // RunsUpDown
            // 
            this.RunsUpDown.Location = new System.Drawing.Point(272, 43);
            this.RunsUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.RunsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RunsUpDown.Name = "RunsUpDown";
            this.RunsUpDown.Size = new System.Drawing.Size(180, 31);
            this.RunsUpDown.TabIndex = 1;
            this.RunsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // InputOrderTypeCombo
            // 
            this.InputOrderTypeCombo.FormattingEnabled = true;
            this.InputOrderTypeCombo.Location = new System.Drawing.Point(272, 93);
            this.InputOrderTypeCombo.Name = "InputOrderTypeCombo";
            this.InputOrderTypeCombo.Size = new System.Drawing.Size(182, 33);
            this.InputOrderTypeCombo.TabIndex = 2;
            // 
            // OutputOrderTypeCombo
            // 
            this.OutputOrderTypeCombo.FormattingEnabled = true;
            this.OutputOrderTypeCombo.Location = new System.Drawing.Point(272, 154);
            this.OutputOrderTypeCombo.Name = "OutputOrderTypeCombo";
            this.OutputOrderTypeCombo.Size = new System.Drawing.Size(182, 33);
            this.OutputOrderTypeCombo.TabIndex = 2;
            // 
            // InventBlueprintCheckbox
            // 
            this.InventBlueprintCheckbox.AutoSize = true;
            this.InventBlueprintCheckbox.Location = new System.Drawing.Point(272, 223);
            this.InventBlueprintCheckbox.Name = "InventBlueprintCheckbox";
            this.InventBlueprintCheckbox.Size = new System.Drawing.Size(22, 21);
            this.InventBlueprintCheckbox.TabIndex = 3;
            this.InventBlueprintCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 288);
            this.Controls.Add(this.InventBlueprintCheckbox);
            this.Controls.Add(this.OutputOrderTypeCombo);
            this.Controls.Add(this.InputOrderTypeCombo);
            this.Controls.Add(this.RunsUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainDefaults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Defaults";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDefaults_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RunsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown RunsUpDown;
        private ComboBox InputOrderTypeCombo;
        private ComboBox OutputOrderTypeCombo;
        private CheckBox InventBlueprintCheckbox;
    }
}