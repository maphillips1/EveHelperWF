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
    public partial class EditMultiBuildPlanProduct : Objects.FormBase
    {
        FinalProduct FinalProduct;
        public EditMultiBuildPlanProduct(FinalProduct finalProduct)
        {
            InitializeComponent();
            this.Text = "Edit Product - " + finalProduct.finalProductTypeName;
            FinalProduct = finalProduct;
            LoadScreen();
        }

        private void LoadScreen()
        {
            AdditionalCostNumeric.Value = FinalProduct.additionalCosts;
            RunsPerCopyNumeric.Value = FinalProduct.RunsPerCopy;
            NumCopiesNumeric.Value = FinalProduct.NumOfCopies;
            CustomSellPriceNumeric.Value = FinalProduct.customSellPrice;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (FinalProduct != null)
            {
                FinalProduct.additionalCosts = AdditionalCostNumeric.Value;
                FinalProduct.RunsPerCopy = (int)RunsPerCopyNumeric.Value;
                FinalProduct.NumOfCopies = (int)NumCopiesNumeric.Value;
                FinalProduct.customSellPrice = CustomSellPriceNumeric.Value;
                DialogResult = DialogResult.OK;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
