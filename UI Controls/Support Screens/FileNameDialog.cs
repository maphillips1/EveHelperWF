namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class FileNameDialog : Objects.FormBase
    {
        public FileNameDialog(string FileNameLabelText)
        {
            InitializeComponent();
            this.label1.Text = FileNameLabelText;
            this.FileNameTextBox.Left = this.label1.Bounds.Right;
            this.CancelButton.Left = this.FileNameTextBox.Bounds.Right - (this.CancelButton.Width * 2);
            this.ActiveControl = FileNameTextBox;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string fileName = FileIO.FileHelper.ReplaceInvalidChars(this.FileNameTextBox.Text);
            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Invalid File Name", "Invalid File Name");
            }
            else
            {
                FileNameTextBox.Text = fileName;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FileNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveButton_Click(sender, e);
            }
        }
    }
}
