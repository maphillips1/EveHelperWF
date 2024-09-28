using EveHelperWF.Objects;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class BlueprintValueControl : Objects.FormBase
    {
        BlueprintInfo BPInfo;
        public BlueprintValueControl(BlueprintInfo bpInfo, bool showExcludeFP)
        {
            InitializeComponent();
            this.BPInfo = bpInfo;
            LoadControl();
            ExcludeFPCheckbox.Visible = showExcludeFP;
            ExcludeFPLabel.Visible = showExcludeFP;
            this.Text = bpInfo.BlueprintName;
        }

        private void LoadControl()
        {
            if (this.BPInfo.IsReacted)
            {
                MELabel.Visible = false;
                MEUpDown.Visible = false;
                TELabel.Visible = false;
                TEUpDown.Visible = false;
            }

            MEUpDown.Value = BPInfo.ME;
            TEUpDown.Value = BPInfo.TE;
            MaxRunsUpDown.Value = BPInfo.MaxRuns;
            MakeItemCheckbox.Checked = BPInfo.Manufacture || BPInfo.React;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Numeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveButton_Click(sender, new EventArgs());
            }
        }
    }
}
