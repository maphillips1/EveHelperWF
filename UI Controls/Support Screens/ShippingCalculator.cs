using EveHelperWF.ScreenHelper;
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
    public partial class ShippingCalculator : Objects.Custom_Controls.UserControlBase
    {

        private decimal totalVolume = 0;
        private decimal price = 0;

        public ShippingCalculator()
        {
            InitializeComponent();
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            this.totalVolume = VolumeNumeric.Value;
            this.price = CollateralNumeric.Value;
            CalculateShippingCost();
        }

        public void SetVolumeAndPrice(decimal volume, decimal price)
        {
            this.totalVolume = volume;
            this.VolumeNumeric.Value = volume;
            this.price = price;
            this.CollateralNumeric.Value = price;
            CalculateShippingCost();
        }

        private void CalculateShippingCost()
        {
            decimal costPerm3 = CostMCubed.Value * totalVolume;
            decimal collaterCost = (IskPercentage.Value / 100) * price;

            decimal totalCost = costPerm3 + collaterCost + FuelCost.Value + AdditionalCost.Value;

            TotalCostLabel.Text = CommonHelper.FormatIsk(totalCost);
        }
    }
}
