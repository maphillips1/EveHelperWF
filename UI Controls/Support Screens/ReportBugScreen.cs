using EveHelperWF.Objects;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class ReportBugScreen : Objects.FormBase
    {
        StringBuilder validationMessage = new StringBuilder();
        public ReportBugScreen()
        {
            InitializeComponent();
            LoadCombo();
        }

        private void LoadCombo()
        {
            List<ComboListItem> comboListItems = new List<ComboListItem>();
            comboListItems.Add(new ComboListItem(0, ""));
            comboListItems.Add(new ComboListItem(1, "Blueprints"));
            comboListItems.Add(new ComboListItem(2, "Planetary Interaction"));
            comboListItems.Add(new ComboListItem(3, "Market Browser"));
            comboListItems.Add(new ComboListItem(4, "Abyss Tracker"));
            comboListItems.Add(new ComboListItem(5, "Loot Appraisal"));
            comboListItems.Add(new ComboListItem(6, "System Finder"));
            comboListItems.Add(new ComboListItem(7, "Price History Utility"));
            comboListItems.Add(new ComboListItem(8, "Configure Defaults"));
            comboListItems.Add(new ComboListItem(9, "Shopping List"));
            comboListItems.Add(new ComboListItem(10, "Build Plans"));
            comboListItems.Add(new ComboListItem(11, "Main Screen"));

            comboListItems = comboListItems.OrderBy(x => x.value).ToList();

            ToolCombobox.DisplayMember = "value";
            ToolCombobox.ValueMember = "key";
            ToolCombobox.DataSource = comboListItems;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInfo())
            {
                BuildSendReport();
            }
            else
            {
                string errorText = validationMessage.ToString();
                if (!string.IsNullOrWhiteSpace(errorText) )
                {
                    MessageBox.Show(errorText, "Missing Values");
                }
            }
        }

        private bool ValidateInfo()
        {
            bool valid = true;
            int comboValue = Convert.ToInt32(ToolCombobox.SelectedValue);
            validationMessage.Clear();
            if ( comboValue <= 0)
            {
                valid = false;
                validationMessage.AppendLine("Select which tool or screen is erroring.");
            }
            if (String.IsNullOrWhiteSpace(TypeIssueTextBox.Text) )
            {
                valid = false;
                validationMessage.AppendLine("Fill in Type of Issue");
            }
            if (string.IsNullOrWhiteSpace(DetailsTextBox.Text))
            {
                valid = false;
                validationMessage.AppendLine("I need details to fix the issue.");
            }

            return valid;
        }

        private void BuildSendReport()
        {
            string title = ToolCombobox.Text + " - " + TypeIssueTextBox.Text;
            string body = DetailsTextBox.Text;

            string issueURL = GitHub_Calls.GitHubCalls.CreateIssue(title, body);
            if (!string.IsNullOrWhiteSpace(issueURL) )
            {
                DialogResult showResult =  MessageBox.Show("Your issue has been created. " +
                    "To track the issue, visit the URL " +
                    issueURL +
                    " . Do you want to go to your issue?",
                    "Report Submitted",
                    MessageBoxButtons.YesNo);
                if (showResult == DialogResult.Yes)
                {
                    string issueLink = String.Format(issueURL);
                    ProcessStartInfo startInfo = new ProcessStartInfo(issueLink);
                    startInfo.UseShellExecute = true;
                    Process.Start(startInfo);
                }
            }
            else
            {
                MessageBox.Show("Unable to send bug report. " +
                    "Kind of embarrassing. Can't even report a " +
                    "fucking issue in this app. You can send an email to " +
                    """thebestspamfilterever@gmail.com""" + ". " +
                    "Yes, that is a real email address I have access to. " +
                    "No I'm not kidding. Yes, it gets laughs at stores.", "Big Oof");
            }
        }
    }
}
