namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    partial class ConfigureDefaults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDefaults));
            DefaultsTabContainer = new TabControl();
            MainDefaultTabPage = new TabPage();
            InventBlueprintCheckbox = new CheckBox();
            OutputOrderTypeCombo = new ComboBox();
            InputOrderTypeCombo = new ComboBox();
            RunsUpDown = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ManufacturingDefaultsTabPage = new TabPage();
            BuildComponentCheckbox = new CheckBox();
            StructureTERigCombo = new ComboBox();
            StructureMERigCombo = new ComboBox();
            StructureCombo = new ComboBox();
            ImplantCombo = new ComboBox();
            SystemCombo = new ComboBox();
            TEUpDown = new NumericUpDown();
            CompTEUpDown = new NumericUpDown();
            CompMEUpDown = new NumericUpDown();
            TaxUpDown = new NumericUpDown();
            MEUpDown = new NumericUpDown();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            InventionDefaultsTabPage = new TabPage();
            InventionTaxUpDown = new NumericUpDown();
            InventionDecryptorCombo = new ComboBox();
            InventionStructureTimeRigCombo = new ComboBox();
            InventionStructureCostRigCombo = new ComboBox();
            InventionStructureCombo = new ComboBox();
            InventionSolarSystemCombo = new ComboBox();
            label32 = new Label();
            label31 = new Label();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label27 = new Label();
            ReactionsDefaultTabPage = new TabPage();
            label26 = new Label();
            ReactionTaxUpDown = new NumericUpDown();
            ReactionStructureTERig = new ComboBox();
            label20 = new Label();
            ReactionStructureMERig = new ComboBox();
            label19 = new Label();
            ReactionStructureCombo = new ComboBox();
            label18 = new Label();
            label17 = new Label();
            ReactionSolarSystemCombo = new ComboBox();
            SaveButton = new Button();
            DefaultsTabContainer.SuspendLayout();
            MainDefaultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RunsUpDown).BeginInit();
            ManufacturingDefaultsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TEUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CompTEUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CompMEUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TaxUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MEUpDown).BeginInit();
            InventionDefaultsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InventionTaxUpDown).BeginInit();
            ReactionsDefaultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReactionTaxUpDown).BeginInit();
            SuspendLayout();
            // 
            // DefaultsTabContainer
            // 
            DefaultsTabContainer.Controls.Add(MainDefaultTabPage);
            DefaultsTabContainer.Controls.Add(ManufacturingDefaultsTabPage);
            DefaultsTabContainer.Controls.Add(InventionDefaultsTabPage);
            DefaultsTabContainer.Controls.Add(ReactionsDefaultTabPage);
            DefaultsTabContainer.Dock = DockStyle.Bottom;
            DefaultsTabContainer.Location = new Point(0, 73);
            DefaultsTabContainer.Name = "DefaultsTabContainer";
            DefaultsTabContainer.SelectedIndex = 0;
            DefaultsTabContainer.Size = new Size(769, 357);
            DefaultsTabContainer.TabIndex = 0;
            // 
            // MainDefaultTabPage
            // 
            MainDefaultTabPage.BackColor = Color.FromArgb(2, 23, 38);
            MainDefaultTabPage.Controls.Add(InventBlueprintCheckbox);
            MainDefaultTabPage.Controls.Add(OutputOrderTypeCombo);
            MainDefaultTabPage.Controls.Add(InputOrderTypeCombo);
            MainDefaultTabPage.Controls.Add(RunsUpDown);
            MainDefaultTabPage.Controls.Add(label4);
            MainDefaultTabPage.Controls.Add(label3);
            MainDefaultTabPage.Controls.Add(label2);
            MainDefaultTabPage.Controls.Add(label1);
            MainDefaultTabPage.Location = new Point(4, 29);
            MainDefaultTabPage.Name = "MainDefaultTabPage";
            MainDefaultTabPage.Padding = new Padding(3);
            MainDefaultTabPage.Size = new Size(761, 324);
            MainDefaultTabPage.TabIndex = 0;
            MainDefaultTabPage.Text = "Main";
            // 
            // InventBlueprintCheckbox
            // 
            InventBlueprintCheckbox.AutoSize = true;
            InventBlueprintCheckbox.Location = new Point(191, 164);
            InventBlueprintCheckbox.Margin = new Padding(2);
            InventBlueprintCheckbox.Name = "InventBlueprintCheckbox";
            InventBlueprintCheckbox.Size = new Size(18, 17);
            InventBlueprintCheckbox.TabIndex = 12;
            InventBlueprintCheckbox.UseVisualStyleBackColor = true;
            // 
            // OutputOrderTypeCombo
            // 
            OutputOrderTypeCombo.FormattingEnabled = true;
            OutputOrderTypeCombo.Location = new Point(191, 109);
            OutputOrderTypeCombo.Margin = new Padding(2);
            OutputOrderTypeCombo.Name = "OutputOrderTypeCombo";
            OutputOrderTypeCombo.Size = new Size(146, 28);
            OutputOrderTypeCombo.TabIndex = 10;
            // 
            // InputOrderTypeCombo
            // 
            InputOrderTypeCombo.FormattingEnabled = true;
            InputOrderTypeCombo.Location = new Point(191, 60);
            InputOrderTypeCombo.Margin = new Padding(2);
            InputOrderTypeCombo.Name = "InputOrderTypeCombo";
            InputOrderTypeCombo.Size = new Size(146, 28);
            InputOrderTypeCombo.TabIndex = 11;
            // 
            // RunsUpDown
            // 
            RunsUpDown.Location = new Point(191, 20);
            RunsUpDown.Margin = new Padding(2);
            RunsUpDown.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            RunsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RunsUpDown.Name = "RunsUpDown";
            RunsUpDown.Size = new Size(144, 27);
            RunsUpDown.TabIndex = 9;
            RunsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(26, 160);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 23);
            label4.TabIndex = 5;
            label4.Text = "Invent Blueprint";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(7, 109);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(163, 23);
            label3.TabIndex = 6;
            label3.Text = "Output Order Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(20, 60);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(148, 23);
            label2.TabIndex = 7;
            label2.Text = "Input Order Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(112, 20);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(48, 23);
            label1.TabIndex = 8;
            label1.Text = "Runs";
            // 
            // ManufacturingDefaultsTabPage
            // 
            ManufacturingDefaultsTabPage.BackColor = Color.FromArgb(2, 23, 38);
            ManufacturingDefaultsTabPage.Controls.Add(BuildComponentCheckbox);
            ManufacturingDefaultsTabPage.Controls.Add(StructureTERigCombo);
            ManufacturingDefaultsTabPage.Controls.Add(StructureMERigCombo);
            ManufacturingDefaultsTabPage.Controls.Add(StructureCombo);
            ManufacturingDefaultsTabPage.Controls.Add(ImplantCombo);
            ManufacturingDefaultsTabPage.Controls.Add(SystemCombo);
            ManufacturingDefaultsTabPage.Controls.Add(TEUpDown);
            ManufacturingDefaultsTabPage.Controls.Add(CompTEUpDown);
            ManufacturingDefaultsTabPage.Controls.Add(CompMEUpDown);
            ManufacturingDefaultsTabPage.Controls.Add(TaxUpDown);
            ManufacturingDefaultsTabPage.Controls.Add(MEUpDown);
            ManufacturingDefaultsTabPage.Controls.Add(label11);
            ManufacturingDefaultsTabPage.Controls.Add(label10);
            ManufacturingDefaultsTabPage.Controls.Add(label9);
            ManufacturingDefaultsTabPage.Controls.Add(label8);
            ManufacturingDefaultsTabPage.Controls.Add(label7);
            ManufacturingDefaultsTabPage.Controls.Add(label6);
            ManufacturingDefaultsTabPage.Controls.Add(label5);
            ManufacturingDefaultsTabPage.Controls.Add(label12);
            ManufacturingDefaultsTabPage.Controls.Add(label13);
            ManufacturingDefaultsTabPage.Controls.Add(label14);
            ManufacturingDefaultsTabPage.Controls.Add(label15);
            ManufacturingDefaultsTabPage.Location = new Point(4, 29);
            ManufacturingDefaultsTabPage.Name = "ManufacturingDefaultsTabPage";
            ManufacturingDefaultsTabPage.Padding = new Padding(3);
            ManufacturingDefaultsTabPage.Size = new Size(761, 324);
            ManufacturingDefaultsTabPage.TabIndex = 1;
            ManufacturingDefaultsTabPage.Text = "Manufacturing";
            // 
            // BuildComponentCheckbox
            // 
            BuildComponentCheckbox.AutoSize = true;
            BuildComponentCheckbox.Location = new Point(490, 116);
            BuildComponentCheckbox.Margin = new Padding(2);
            BuildComponentCheckbox.Name = "BuildComponentCheckbox";
            BuildComponentCheckbox.Size = new Size(18, 17);
            BuildComponentCheckbox.TabIndex = 25;
            BuildComponentCheckbox.UseVisualStyleBackColor = true;
            // 
            // StructureTERigCombo
            // 
            StructureTERigCombo.FormattingEnabled = true;
            StructureTERigCombo.Location = new Point(160, 245);
            StructureTERigCombo.Margin = new Padding(2);
            StructureTERigCombo.Name = "StructureTERigCombo";
            StructureTERigCombo.Size = new Size(146, 28);
            StructureTERigCombo.TabIndex = 24;
            // 
            // StructureMERigCombo
            // 
            StructureMERigCombo.FormattingEnabled = true;
            StructureMERigCombo.Location = new Point(160, 199);
            StructureMERigCombo.Margin = new Padding(2);
            StructureMERigCombo.Name = "StructureMERigCombo";
            StructureMERigCombo.Size = new Size(146, 28);
            StructureMERigCombo.TabIndex = 23;
            // 
            // StructureCombo
            // 
            StructureCombo.FormattingEnabled = true;
            StructureCombo.Location = new Point(160, 155);
            StructureCombo.Margin = new Padding(2);
            StructureCombo.Name = "StructureCombo";
            StructureCombo.Size = new Size(146, 28);
            StructureCombo.TabIndex = 22;
            // 
            // ImplantCombo
            // 
            ImplantCombo.FormattingEnabled = true;
            ImplantCombo.Location = new Point(490, 64);
            ImplantCombo.Margin = new Padding(2);
            ImplantCombo.Name = "ImplantCombo";
            ImplantCombo.Size = new Size(146, 28);
            ImplantCombo.TabIndex = 21;
            // 
            // SystemCombo
            // 
            SystemCombo.FormattingEnabled = true;
            SystemCombo.Location = new Point(160, 111);
            SystemCombo.Margin = new Padding(2);
            SystemCombo.Name = "SystemCombo";
            SystemCombo.Size = new Size(146, 28);
            SystemCombo.TabIndex = 20;
            // 
            // TEUpDown
            // 
            TEUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            TEUpDown.Location = new Point(160, 64);
            TEUpDown.Margin = new Padding(2);
            TEUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            TEUpDown.Minimum = new decimal(new int[] { 20, 0, 0, int.MinValue });
            TEUpDown.Name = "TEUpDown";
            TEUpDown.Size = new Size(144, 27);
            TEUpDown.TabIndex = 18;
            // 
            // CompTEUpDown
            // 
            CompTEUpDown.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            CompTEUpDown.Location = new Point(491, 199);
            CompTEUpDown.Margin = new Padding(2);
            CompTEUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            CompTEUpDown.Name = "CompTEUpDown";
            CompTEUpDown.Size = new Size(144, 27);
            CompTEUpDown.TabIndex = 17;
            // 
            // CompMEUpDown
            // 
            CompMEUpDown.Location = new Point(491, 155);
            CompMEUpDown.Margin = new Padding(2);
            CompMEUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            CompMEUpDown.Name = "CompMEUpDown";
            CompMEUpDown.Size = new Size(144, 27);
            CompMEUpDown.TabIndex = 16;
            // 
            // TaxUpDown
            // 
            TaxUpDown.DecimalPlaces = 2;
            TaxUpDown.Location = new Point(490, 18);
            TaxUpDown.Margin = new Padding(2);
            TaxUpDown.Name = "TaxUpDown";
            TaxUpDown.Size = new Size(144, 27);
            TaxUpDown.TabIndex = 19;
            // 
            // MEUpDown
            // 
            MEUpDown.Location = new Point(160, 15);
            MEUpDown.Margin = new Padding(2);
            MEUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            MEUpDown.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            MEUpDown.Name = "MEUpDown";
            MEUpDown.Size = new Size(144, 27);
            MEUpDown.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(402, 199);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(82, 23);
            label11.TabIndex = 13;
            label11.Text = "Comp TE";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(396, 155);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(88, 23);
            label10.TabIndex = 12;
            label10.Text = "Comp ME";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(330, 111);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(158, 23);
            label9.TabIndex = 11;
            label9.Text = "Build Components";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(410, 63);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(73, 23);
            label8.TabIndex = 10;
            label8.Text = "Implant";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(442, 18);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(37, 23);
            label7.TabIndex = 9;
            label7.Text = "Tax";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(14, 249);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(141, 23);
            label6.TabIndex = 8;
            label6.Text = "Structure TE Rig";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(8, 199);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(147, 23);
            label5.TabIndex = 7;
            label5.Text = "Structure ME Rig";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(66, 155);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(85, 23);
            label12.TabIndex = 6;
            label12.Text = "Structure";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(82, 111);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(68, 23);
            label13.TabIndex = 5;
            label13.Text = "System";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(118, 63);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(29, 23);
            label14.TabIndex = 14;
            label14.Text = "TE";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(113, 18);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(35, 23);
            label15.TabIndex = 4;
            label15.Text = "ME";
            // 
            // InventionDefaultsTabPage
            // 
            InventionDefaultsTabPage.BackColor = Color.FromArgb(2, 23, 38);
            InventionDefaultsTabPage.Controls.Add(InventionTaxUpDown);
            InventionDefaultsTabPage.Controls.Add(InventionDecryptorCombo);
            InventionDefaultsTabPage.Controls.Add(InventionStructureTimeRigCombo);
            InventionDefaultsTabPage.Controls.Add(InventionStructureCostRigCombo);
            InventionDefaultsTabPage.Controls.Add(InventionStructureCombo);
            InventionDefaultsTabPage.Controls.Add(InventionSolarSystemCombo);
            InventionDefaultsTabPage.Controls.Add(label32);
            InventionDefaultsTabPage.Controls.Add(label31);
            InventionDefaultsTabPage.Controls.Add(label30);
            InventionDefaultsTabPage.Controls.Add(label29);
            InventionDefaultsTabPage.Controls.Add(label28);
            InventionDefaultsTabPage.Controls.Add(label27);
            InventionDefaultsTabPage.Location = new Point(4, 29);
            InventionDefaultsTabPage.Name = "InventionDefaultsTabPage";
            InventionDefaultsTabPage.Size = new Size(761, 324);
            InventionDefaultsTabPage.TabIndex = 2;
            InventionDefaultsTabPage.Text = "Invention";
            // 
            // InventionTaxUpDown
            // 
            InventionTaxUpDown.DecimalPlaces = 2;
            InventionTaxUpDown.Location = new Point(150, 224);
            InventionTaxUpDown.Margin = new Padding(2);
            InventionTaxUpDown.Name = "InventionTaxUpDown";
            InventionTaxUpDown.Size = new Size(144, 27);
            InventionTaxUpDown.TabIndex = 27;
            // 
            // InventionDecryptorCombo
            // 
            InventionDecryptorCombo.FormattingEnabled = true;
            InventionDecryptorCombo.Location = new Point(150, 180);
            InventionDecryptorCombo.Margin = new Padding(2);
            InventionDecryptorCombo.Name = "InventionDecryptorCombo";
            InventionDecryptorCombo.Size = new Size(146, 28);
            InventionDecryptorCombo.TabIndex = 22;
            // 
            // InventionStructureTimeRigCombo
            // 
            InventionStructureTimeRigCombo.FormattingEnabled = true;
            InventionStructureTimeRigCombo.Location = new Point(150, 140);
            InventionStructureTimeRigCombo.Margin = new Padding(2);
            InventionStructureTimeRigCombo.Name = "InventionStructureTimeRigCombo";
            InventionStructureTimeRigCombo.Size = new Size(146, 28);
            InventionStructureTimeRigCombo.TabIndex = 23;
            // 
            // InventionStructureCostRigCombo
            // 
            InventionStructureCostRigCombo.FormattingEnabled = true;
            InventionStructureCostRigCombo.Location = new Point(150, 97);
            InventionStructureCostRigCombo.Margin = new Padding(2);
            InventionStructureCostRigCombo.Name = "InventionStructureCostRigCombo";
            InventionStructureCostRigCombo.Size = new Size(146, 28);
            InventionStructureCostRigCombo.TabIndex = 24;
            // 
            // InventionStructureCombo
            // 
            InventionStructureCombo.FormattingEnabled = true;
            InventionStructureCombo.Location = new Point(150, 54);
            InventionStructureCombo.Margin = new Padding(2);
            InventionStructureCombo.Name = "InventionStructureCombo";
            InventionStructureCombo.Size = new Size(146, 28);
            InventionStructureCombo.TabIndex = 25;
            // 
            // InventionSolarSystemCombo
            // 
            InventionSolarSystemCombo.FormattingEnabled = true;
            InventionSolarSystemCombo.Location = new Point(150, 16);
            InventionSolarSystemCombo.Margin = new Padding(2);
            InventionSolarSystemCombo.Name = "InventionSolarSystemCombo";
            InventionSolarSystemCombo.Size = new Size(146, 28);
            InventionSolarSystemCombo.TabIndex = 26;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label32.Location = new Point(113, 224);
            label32.Margin = new Padding(2, 0, 2, 0);
            label32.Name = "label32";
            label32.Size = new Size(33, 20);
            label32.TabIndex = 16;
            label32.Text = "Tax";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label31.Location = new Point(67, 182);
            label31.Margin = new Padding(2, 0, 2, 0);
            label31.Name = "label31";
            label31.Size = new Size(80, 20);
            label31.TabIndex = 17;
            label31.Text = "Decryptor";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label30.Location = new Point(9, 142);
            label30.Margin = new Padding(2, 0, 2, 0);
            label30.Name = "label30";
            label30.Size = new Size(140, 20);
            label30.TabIndex = 18;
            label30.Text = "Structure Time Rig";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label29.Location = new Point(13, 99);
            label29.Margin = new Padding(2, 0, 2, 0);
            label29.Name = "label29";
            label29.Size = new Size(136, 20);
            label29.TabIndex = 19;
            label29.Text = "Structure Cost Rig";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label28.Location = new Point(73, 61);
            label28.Margin = new Padding(2, 0, 2, 0);
            label28.Name = "label28";
            label28.Size = new Size(74, 20);
            label28.TabIndex = 20;
            label28.Text = "Structure";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label27.Location = new Point(49, 18);
            label27.Margin = new Padding(2, 0, 2, 0);
            label27.Name = "label27";
            label27.Size = new Size(99, 20);
            label27.TabIndex = 21;
            label27.Text = "Solar System";
            // 
            // ReactionsDefaultTabPage
            // 
            ReactionsDefaultTabPage.BackColor = Color.FromArgb(2, 23, 38);
            ReactionsDefaultTabPage.Controls.Add(label26);
            ReactionsDefaultTabPage.Controls.Add(ReactionTaxUpDown);
            ReactionsDefaultTabPage.Controls.Add(ReactionStructureTERig);
            ReactionsDefaultTabPage.Controls.Add(label20);
            ReactionsDefaultTabPage.Controls.Add(ReactionStructureMERig);
            ReactionsDefaultTabPage.Controls.Add(label19);
            ReactionsDefaultTabPage.Controls.Add(ReactionStructureCombo);
            ReactionsDefaultTabPage.Controls.Add(label18);
            ReactionsDefaultTabPage.Controls.Add(label17);
            ReactionsDefaultTabPage.Controls.Add(ReactionSolarSystemCombo);
            ReactionsDefaultTabPage.Location = new Point(4, 29);
            ReactionsDefaultTabPage.Name = "ReactionsDefaultTabPage";
            ReactionsDefaultTabPage.Size = new Size(761, 324);
            ReactionsDefaultTabPage.TabIndex = 3;
            ReactionsDefaultTabPage.Text = "Reactions";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label26.Location = new Point(97, 204);
            label26.Margin = new Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new Size(33, 20);
            label26.TabIndex = 39;
            label26.Text = "Tax";
            // 
            // ReactionTaxUpDown
            // 
            ReactionTaxUpDown.DecimalPlaces = 2;
            ReactionTaxUpDown.Location = new Point(139, 203);
            ReactionTaxUpDown.Margin = new Padding(2);
            ReactionTaxUpDown.Name = "ReactionTaxUpDown";
            ReactionTaxUpDown.Size = new Size(144, 27);
            ReactionTaxUpDown.TabIndex = 38;
            // 
            // ReactionStructureTERig
            // 
            ReactionStructureTERig.FormattingEnabled = true;
            ReactionStructureTERig.Location = new Point(139, 163);
            ReactionStructureTERig.Margin = new Padding(2);
            ReactionStructureTERig.Name = "ReactionStructureTERig";
            ReactionStructureTERig.Size = new Size(146, 28);
            ReactionStructureTERig.TabIndex = 37;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(10, 163);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(122, 20);
            label20.TabIndex = 36;
            label20.Text = "Structure TE Rig";
            // 
            // ReactionStructureMERig
            // 
            ReactionStructureMERig.FormattingEnabled = true;
            ReactionStructureMERig.Location = new Point(139, 115);
            ReactionStructureMERig.Margin = new Padding(2);
            ReactionStructureMERig.Name = "ReactionStructureMERig";
            ReactionStructureMERig.Size = new Size(146, 28);
            ReactionStructureMERig.TabIndex = 35;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(5, 115);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(127, 20);
            label19.TabIndex = 34;
            label19.Text = "Structure ME Rig";
            // 
            // ReactionStructureCombo
            // 
            ReactionStructureCombo.FormattingEnabled = true;
            ReactionStructureCombo.Location = new Point(139, 69);
            ReactionStructureCombo.Margin = new Padding(2);
            ReactionStructureCombo.Name = "ReactionStructureCombo";
            ReactionStructureCombo.Size = new Size(146, 28);
            ReactionStructureCombo.TabIndex = 33;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(57, 69);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(74, 20);
            label18.TabIndex = 32;
            label18.Text = "Structure";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(33, 20);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.RightToLeft = RightToLeft.No;
            label17.Size = new Size(99, 20);
            label17.TabIndex = 31;
            label17.Text = "Solar System";
            // 
            // ReactionSolarSystemCombo
            // 
            ReactionSolarSystemCombo.FormattingEnabled = true;
            ReactionSolarSystemCombo.Location = new Point(139, 18);
            ReactionSolarSystemCombo.Margin = new Padding(2);
            ReactionSolarSystemCombo.Name = "ReactionSolarSystemCombo";
            ReactionSolarSystemCombo.Size = new Size(146, 28);
            ReactionSolarSystemCombo.TabIndex = 30;
            // 
            // SaveButton
            // 
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(12, 12);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ConfigureDefaults
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 430);
            Controls.Add(SaveButton);
            Controls.Add(DefaultsTabContainer);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigureDefaults";
            Text = "Configure Defaults";
            DefaultsTabContainer.ResumeLayout(false);
            MainDefaultTabPage.ResumeLayout(false);
            MainDefaultTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RunsUpDown).EndInit();
            ManufacturingDefaultsTabPage.ResumeLayout(false);
            ManufacturingDefaultsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TEUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CompTEUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CompMEUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)TaxUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MEUpDown).EndInit();
            InventionDefaultsTabPage.ResumeLayout(false);
            InventionDefaultsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InventionTaxUpDown).EndInit();
            ReactionsDefaultTabPage.ResumeLayout(false);
            ReactionsDefaultTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ReactionTaxUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl DefaultsTabContainer;
        private TabPage MainDefaultTabPage;
        private TabPage ManufacturingDefaultsTabPage;
        private TabPage InventionDefaultsTabPage;
        private TabPage ReactionsDefaultTabPage;
        private CheckBox InventBlueprintCheckbox;
        private ComboBox OutputOrderTypeCombo;
        private ComboBox InputOrderTypeCombo;
        private NumericUpDown RunsUpDown;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button SaveButton;
        private CheckBox BuildComponentCheckbox;
        private ComboBox StructureTERigCombo;
        private ComboBox StructureMERigCombo;
        private ComboBox StructureCombo;
        private ComboBox ImplantCombo;
        private ComboBox SystemCombo;
        private NumericUpDown TEUpDown;
        private NumericUpDown CompTEUpDown;
        private NumericUpDown CompMEUpDown;
        private NumericUpDown TaxUpDown;
        private NumericUpDown MEUpDown;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private NumericUpDown InventionTaxUpDown;
        private ComboBox InventionDecryptorCombo;
        private ComboBox InventionStructureTimeRigCombo;
        private ComboBox InventionStructureCostRigCombo;
        private ComboBox InventionStructureCombo;
        private ComboBox InventionSolarSystemCombo;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private NumericUpDown ReactionTaxUpDown;
        private ComboBox ReactionStructureTERig;
        private Label label20;
        private ComboBox ReactionStructureMERig;
        private Label label19;
        private ComboBox ReactionStructureCombo;
        private Label label18;
        private Label label17;
        private ComboBox ReactionSolarSystemCombo;
    }
}