using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class AddFromFitForm : EveHelperWF.Objects.FormBase
    {
        public List<FinalProduct> finalProductBlueprints = new List<FinalProduct>();
        bool formattingText = false;
        public AddFromFitForm()
        {
            InitializeComponent();
        }

        private void FitTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FitTextBox.Text.Length > 0 && !formattingText)
            {
                formattingText = true;

                string[] lines = FitTextBox.Text.Split("\r\n", StringSplitOptions.None);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string itemName;
                        string quantityRegex = "x[0-9]+";
                        Match regMatch = Regex.Match(line, quantityRegex);
                        if (regMatch.Success)
                        {
                            itemName = line.Substring(0, (line.Length - regMatch.Length));
                        }
                        else
                        {
                            itemName = line;
                        }
                        InventoryType inventoryType = CommonHelper.InventoryTypes.Find(x => x.typeName == itemName.Trim());

                        if (inventoryType != null)
                        {
                            int bpTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(inventoryType.typeId);
                            if (bpTypeId > 0)
                            {
                                FinalProduct existingProduct = finalProductBlueprints.Find(x => x.blueprintOrReactionTypeId == bpTypeId);
                                if (existingProduct == null)
                                {
                                    FinalProduct bpInfo = new FinalProduct();
                                    bpInfo.blueprintOrReactionTypeId = bpTypeId;
                                    if (regMatch.Success)
                                    {
                                        string value = regMatch.Value;
                                        value = value.Substring(1, value.Length - 1);
                                        bpInfo.TotalOutcome = Convert.ToInt32(value);
                                        List<IndustryActivityProduct> industryActivityProduct = new List<IndustryActivityProduct>();
                                        if (IsMaterialManufactured(bpInfo.finalProductTypeId))
                                        {
                                            industryActivityProduct = Database.SQLiteCalls.GetIndustryActivityProducts(bpTypeId, "manufacturing");
                                        }
                                        else
                                        {
                                            industryActivityProduct = Database.SQLiteCalls.GetIndustryActivityProducts(bpTypeId, "reaction");
                                        }
                                        if (industryActivityProduct.Count > 0)
                                        {
                                            bpInfo.RunsPerCopy = (int)Math.Ceiling((decimal)bpInfo.TotalOutcome / (decimal)industryActivityProduct[0].quantity);
                                        }
                                        else
                                        {
                                            bpInfo.RunsPerCopy = 1;
                                        }
                                    }
                                    else
                                    {
                                        bpInfo.TotalOutcome = 1;
                                        bpInfo.RunsPerCopy = 1;
                                    }
                                    bpInfo.finalProductTypeId = inventoryType.typeId;
                                    bpInfo.NumOfCopies = 1;
                                    bpInfo.finalProductTypeName = inventoryType.typeName;
                                    finalProductBlueprints.Add(bpInfo);
                                }
                                else
                                {
                                    existingProduct.RunsPerCopy += 1;
                                }
                            }
                        }
                    }
                }

                formattingText = false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(Object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private static bool IsMaterialReacted(int materialTypeID)
        {
            bool reacted = false;

            List<IndustryActivityProduct> products = Database.SQLiteCalls.GetIndustryActivityProducts(materialTypeID, Enums.Enums.ActivityReactions);

            if (products.Count > 0)
            {
                reacted = true;
            }

            return reacted;
        }

        private static bool IsMaterialManufactured(int materialTypeID)
        {
            bool manufactured = false;

            List<IndustryActivityProduct> products = Database.SQLiteCalls.GetIndustryActivityProducts(materialTypeID, Enums.Enums.ActivityManufacturing);

            if (products.Count > 0)
            {
                manufactured = true;
            }

            return manufactured;
        }
    }
}
