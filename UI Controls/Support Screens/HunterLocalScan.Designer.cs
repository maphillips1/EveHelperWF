namespace EveHelperWF.UI_Controls.Support_Screens
{
    partial class HunterLocalScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HunterLocalScan));
            LocalScanTextBox = new TextBox();
            label1 = new Label();
            ResultsGridView = new Objects.Custom_Controls.EveHelperGridView();
            charName = new DataGridViewTextBoxColumn();
            corpName = new DataGridViewTextBoxColumn();
            allianceName = new DataGridViewTextBoxColumn();
            hasCovert = new DataGridViewTextBoxColumn();
            FliesCapital = new DataGridViewTextBoxColumn();
            shipsDestroyed = new DataGridViewTextBoxColumn();
            shipsLost = new DataGridViewTextBoxColumn();
            avgGangSize = new DataGridViewTextBoxColumn();
            dangerRatio = new DataGridViewTextBoxColumn();
            topShipType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
            SuspendLayout();
            // 
            // LocalScanTextBox
            // 
            LocalScanTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LocalScanTextBox.Location = new Point(3, 31);
            LocalScanTextBox.Multiline = true;
            LocalScanTextBox.Name = "LocalScanTextBox";
            LocalScanTextBox.Size = new Size(187, 331);
            LocalScanTextBox.TabIndex = 0;
            LocalScanTextBox.Text = resources.GetString("LocalScanTextBox.Text");
            LocalScanTextBox.TextChanged += LocalScanTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "Local Copy/Paste";
            // 
            // ResultsGridView
            // 
            ResultsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultsGridView.BackgroundColor = Color.FromArgb(21, 21, 21);
            ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsGridView.Columns.AddRange(new DataGridViewColumn[] { charName, corpName, allianceName, hasCovert, FliesCapital, shipsDestroyed, shipsLost, avgGangSize, dangerRatio, topShipType });
            ResultsGridView.EditableColumns = null;
            ResultsGridView.Enabled = false;
            ResultsGridView.GridColor = Color.FromArgb(21, 21, 21);
            ResultsGridView.Location = new Point(201, 31);
            ResultsGridView.Name = "ResultsGridView";
            ResultsGridView.Size = new Size(827, 331);
            ResultsGridView.TabIndex = 2;
            // 
            // charName
            // 
            charName.HeaderText = "Name";
            charName.Name = "charName";
            // 
            // corpName
            // 
            corpName.HeaderText = "Corp";
            corpName.Name = "corpName";
            // 
            // allianceName
            // 
            allianceName.HeaderText = "Alliance";
            allianceName.Name = "allianceName";
            // 
            // hasCovert
            // 
            hasCovert.HeaderText = "Has Covert Kills";
            hasCovert.Name = "hasCovert";
            // 
            // FliesCapital
            // 
            FliesCapital.HeaderText = "Has Capital Kills";
            FliesCapital.Name = "FliesCapital";
            // 
            // shipsDestroyed
            // 
            shipsDestroyed.HeaderText = "Destroyed";
            shipsDestroyed.Name = "shipsDestroyed";
            // 
            // shipsLost
            // 
            shipsLost.HeaderText = "Lost";
            shipsLost.Name = "shipsLost";
            // 
            // avgGangSize
            // 
            avgGangSize.HeaderText = "Avg. Gang Size";
            avgGangSize.Name = "avgGangSize";
            // 
            // dangerRatio
            // 
            dangerRatio.HeaderText = "Zkill Rating";
            dangerRatio.Name = "dangerRatio";
            // 
            // topShipType
            // 
            topShipType.HeaderText = "Recent Top Ship";
            topShipType.Name = "topShipType";
            // 
            // HunterLocalScan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ResultsGridView);
            Controls.Add(label1);
            Controls.Add(LocalScanTextBox);
            Name = "HunterLocalScan";
            Size = new Size(1031, 365);
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LocalScanTextBox;
        private Label label1;
        private Objects.Custom_Controls.EveHelperGridView ResultsGridView;
        private DataGridViewTextBoxColumn charName;
        private DataGridViewTextBoxColumn corpName;
        private DataGridViewTextBoxColumn allianceName;
        private DataGridViewTextBoxColumn hasCovert;
        private DataGridViewTextBoxColumn FliesCapital;
        private DataGridViewTextBoxColumn shipsDestroyed;
        private DataGridViewTextBoxColumn shipsLost;
        private DataGridViewTextBoxColumn avgGangSize;
        private DataGridViewTextBoxColumn dangerRatio;
        private DataGridViewTextBoxColumn topShipType;
    }
}
