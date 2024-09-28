
namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class SetPriceControl : Objects.FormBase
    {
        public SetPriceControl(decimal price)
        {
            InitializeComponent();
            this.PricePerItem.Value = price;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PricePerItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveButton_Click(sender, e);
            }
        }
    }
}
