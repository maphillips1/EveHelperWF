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
        FinalProduct finalProduct;
        public bool ReRunCalcs = false;
        public EditMultiBuildPlanProduct(FinalProduct finalProduct)
        {
            InitializeComponent();
            this.Text = "Edit Product - " + finalProduct.finalProductTypeName;
            this.finalProduct = finalProduct;
            LoadScreen();
        }

        private void LoadScreen()
        {
            AdditionalCostNumeric.Value = finalProduct.additionalCosts;
            RunsPerCopyNumeric.Value = finalProduct.RunsPerCopy;
            NumCopiesNumeric.Value = finalProduct.NumOfCopies;
            CustomSellPriceNumeric.Value = finalProduct.customSellPrice;
            MENumeric.Value = finalProduct.ME;
            TENumeric.Value = finalProduct.TE;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (finalProduct != null)
            {
                if (finalProduct.NumOfCopies != (int)(NumCopiesNumeric.Value) ||
                    finalProduct.RunsPerCopy != (int)(RunsPerCopyNumeric.Value) ||
                    finalProduct.ME != (int)(MENumeric.Value) ||
                    finalProduct.TE != (int)(TENumeric.Value) ||
                    finalProduct.additionalCosts != AdditionalCostNumeric.Value)
                {
                    ReRunCalcs = true;
                }

                finalProduct.additionalCosts = AdditionalCostNumeric.Value;
                finalProduct.RunsPerCopy = (int)RunsPerCopyNumeric.Value;
                finalProduct.NumOfCopies = (int)NumCopiesNumeric.Value;
                finalProduct.TotalOutcome = (int)(finalProduct.RunsPerCopy * finalProduct.NumOfCopies);
                finalProduct.customSellPrice = CustomSellPriceNumeric.Value;
                finalProduct.ME = (int)MENumeric.Value;
                finalProduct.TE = (int)TENumeric.Value;
                
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
