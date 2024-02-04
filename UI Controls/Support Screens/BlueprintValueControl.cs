using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class BlueprintValueControl : Objects.FormBase
    {
        BlueprintInfo BPInfo;
        public BlueprintValueControl(BlueprintInfo bpInfo)
        {
            InitializeComponent();
            this.BPInfo = bpInfo;
            LoadControl();
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
