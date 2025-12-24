using EveHelperWF.Objects;
using System.Text;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class AddMultiBuildPlanProduct : Objects.FormBase
    {
        List<ComboListItem> comboItems = new List<ComboListItem>();
        List<ComboListItem> filteredItems = new List<ComboListItem>();
        bool ShowBuildPLanName;
        public AddMultiBuildPlanProduct(bool showBuildPlanName)
        {
            InitializeComponent();
            LoadCombo();
            ShowBuildPLanName = showBuildPlanName;
            PlanNameLabel.Visible = showBuildPlanName;
            PlanNameTextBox.Visible = showBuildPlanName;
        }

        private void LoadCombo()
        {
            ComboListItem blankItem = new ComboListItem();
            comboItems.Add(blankItem);

            comboItems.AddRange(Database.SQLiteCalls.LoadProductsCombo());

            this.ProductCombo.DisplayMember = "value";
            this.ProductCombo.ValueMember = "key";
            this.ProductCombo.DataSource = comboItems;
            this.ProductCombo.SelectedValue = 0;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if ((PlanNameTextBox.Text.Length > 0 || !ShowBuildPLanName )&&
                    ProductCombo.SelectedValue != null &&
                    ProductCombo.SelectedIndex > 0)
            {
                bool hasInvalidChars = false;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Name cannot contain any of the below chars. ");
                foreach (Char invalidChar in Path.GetInvalidFileNameChars())
                {
                    sb.AppendLine(invalidChar.ToString());
                    if (PlanNameTextBox.Text.Contains(invalidChar))
                    {
                        hasInvalidChars = true;
                    }
                }

                if (hasInvalidChars)
                {
                    MessageBox.Show(sb.ToString(), "Invalid Chars");
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Must enter Plan Name and Product");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
