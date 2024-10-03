using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class ESILPOfferRequiredItem
    {
        public int quantity {  get; set; }
        public int type_id { get; set; }
        public string typeName { get; set; }

        public decimal sellValue { get; set; }
        public string totalSellValue
        {
            get
            {
                if (sellValue > 0)
                {
                    decimal totalValue = sellValue * quantity;
                    return CommonHelper.FormatIskShortened(totalValue);
                }
                return "0";
            }
        }
    }
}
