
namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class QuantityDialog : Objects.FormBase
    {
        public QuantityDialog()
        {
            InitializeComponent();
            this.ActiveControl = QuantityUpDown;
            QuantityUpDown.Select(0, QuantityUpDown.Text.Length);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int quantity = (int)QuantityUpDown.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Value must be greater than 0", "Invalid Value");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Numeric_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                numericUpDown.Value = 0;
            }
        }

        private void QuantityUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveButton_Click(sender, e);
            }
        }
    }
}
