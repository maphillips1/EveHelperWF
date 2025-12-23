using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;

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
            List<ComboListItem> list = new List<ComboListItem>();
            list.Add(new ComboListItem() { key = 2, value = "Don't Change" });
            list.Add(new ComboListItem() { key = 0, value = "No" });
            list.Add(new ComboListItem() { key = 1, value = "Yes" });
            MakeItemCombo.DataSource = list;
            MakeItemCombo.DisplayMember = "Value";
            MakeItemCombo.ValueMember = "Key";
            MakeItemCombo.SelectedValue = 2;

            StructureProfileCombo.DataSource = BuildPlanHelper.GetStructureProfileComboItems();
            StructureProfileCombo.DisplayMember = "Value";
            StructureProfileCombo.ValueMember = "Key";
            if (BPInfo.StructureProfileId > 0)
            {
                StructureProfileCombo.SelectedValue = BPInfo.StructureProfileId;
            }

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
