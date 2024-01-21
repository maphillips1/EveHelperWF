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
    public partial class AddBuildPlanScreen : Objects.FormBase
    {
        public AddBuildPlanScreen()
        {
            InitializeComponent();
            LoadCombo();
        }

        private void LoadCombo()
        {
            List<ComboListItem> comboItems = new List<ComboListItem>();
            
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
            if (PlanNameTextBox.Text.Length > 0 &&
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
