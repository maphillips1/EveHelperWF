using System.Diagnostics;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class UpdateMessageBox : Objects.FormBase
    {
        Objects.GitHub_Objects.Release ReleaseInfo = null;

        public UpdateMessageBox(Objects.GitHub_Objects.Release newRelease)
        {
            InitializeComponent();
            ReleaseInfo = newRelease;
            DataBindScreen();
        }

        private void DataBindScreen()
        {
            if (ReleaseInfo != null)
            {
                ReleaseLinkLabel.Text = ReleaseInfo.html_url;
                UpdateTextLabel.Text = "A new version of EveHelper is available. Click the link below to download version " + ReleaseInfo.tag_name;
                ReleaseNotesTextBox.Text = ReleaseInfo.body;
            }
        }

        private void ReleaseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string UpdateLink = ReleaseLinkLabel.Text;
            ProcessStartInfo startInfo = new ProcessStartInfo(UpdateLink);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
    }
}
