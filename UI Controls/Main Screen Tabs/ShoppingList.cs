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

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class ShoppingList : Objects.FormBase
    {
        string[] fileNames = null;
        List<ComboListItem> comboItems = new List<ComboListItem>();
        Objects.ShoppingList shoppingList = new Objects.ShoppingList();

        #region "Init"
        public ShoppingList()
        {
            InitializeComponent();
            LoadShoppingListCombo();
        }
        #endregion

        #region "Events"
        private void ShoppinglListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShoppingList();
        }

        private void ShowBoughtItemsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ShoppingListItemsPanel.Controls.Clear();
            LoadShoppingItemsPanel();
        }
        #endregion

        #region "Methods"
        private void LoadShoppingListCombo()
        {
            fileNames = FileIO.FileHelper.GetFileNamesInDirectory(Enums.Enums.ShoppingListsDirectory);
            if (fileNames.Length > 0)
            {
                string comboName = "";
                int lastSlashIndex;
                int lastDotIndex;
                int count = 0;
                foreach (string file in fileNames)
                {
                    lastSlashIndex = file.LastIndexOf('\\');
                    lastDotIndex = file.LastIndexOf(".");
                    comboName = file.Substring(lastSlashIndex + 1, lastDotIndex - 1 - lastSlashIndex);
                    comboItems.Add(new ComboListItem { key = count, value = comboName });
                    count++;
                }
            }
            ShoppingListCombo.DataSource = comboItems;
            ShoppingListCombo.ValueMember = "key";
            ShoppingListCombo.DisplayMember = "value";
        }

        private void LoadShoppingList()
        {
            ShoppingListItemsPanel.Controls.Clear();
            string selectedFileName = GetSelectedFileName();
            if (!String.IsNullOrWhiteSpace(selectedFileName))
            {
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.ShoppingListsDirectory, selectedFileName);
                if (!string.IsNullOrEmpty(content))
                {
                    shoppingList = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.ShoppingList>(content);
                }
                LoadShoppingItemsPanel();
            }
        }

        private string GetSelectedFileName()
        {
            int selectedFile = (int)ShoppingListCombo.SelectedValue;

            if (selectedFile > 0)
            {
                ComboListItem comboListItem = comboItems.Find(x => x.key == selectedFile);

                if (comboListItem != null)
                {
                    string fileName = fileNames.ToList().Find(x => x.Contains(comboListItem.value));
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        return fileName;
                    }
                }
            }
            return "";
        }

        private void LoadShoppingItemsPanel()
        {
            if (shoppingList != null && shoppingList.ShoppinglistItems.Count > 0)
            {
                int currentY = 5;
                string controlName = "";

                foreach (ShoppingListItem item in shoppingList.ShoppinglistItems)
                {
                    if (ShowBoughtItemsCheckbox.Checked || !item.Bought)
                    {
                        controlName = "Type_" + item.typeId.ToString();
                        ShoppingListItemsPanel.Controls.Add(BuildTypeLabel(currentY, item.typeName, controlName));
                        currentY += 30;
                        ShoppingListItemsPanel.Controls.Add(BuildBoughtCheckBox(currentY, item.Bought, controlName));
                        ShoppingListItemsPanel.Controls.Add(BuildQuantityLabel(currentY, controlName));
                        ShoppingListItemsPanel.Controls.Add(BuildQuantityUpDown(currentY, item.Quantity, controlName));
                        ShoppingListItemsPanel.Controls.Add(BuildPriceLabel(currentY, controlName));
                        ShoppingListItemsPanel.Controls.Add(BuildPriceUpDown(currentY, item.Quantity, controlName));
                        currentY += 30;
                    }
                }
            }
        }
        private Label BuildTypeLabel(int currentY, string typeName, string controlName)
        {
            Label typeLabel = new Label();
            typeLabel.Name = controlName + "_TypeLabel";
            typeLabel.Text = typeName;
            int xSize = typeName.Length * 7 - (typeName.Length % 25);
            typeLabel.Size = new Size(xSize, 25);
            typeLabel.Location = new Point(35, currentY);
            typeLabel.ForeColor = Color.Gold;

            return typeLabel;
        }

        private CheckBox BuildBoughtCheckBox(int currentY, bool bought, string controlName)
        {
            CheckBox boughtCheckbox = new CheckBox();
            boughtCheckbox.Name = controlName + "_BoughtCheckbox";
            boughtCheckbox.Checked = bought;
            boughtCheckbox.Size = new Size(20, 25);
            boughtCheckbox.Location = new Point(5, currentY);
            boughtCheckbox.ForeColor = Color.White;
            return boughtCheckbox;
        }

        private Label BuildQuantityLabel(int currentY, string controlName)
        {
            Label quantityLabel = new Label();
            quantityLabel.Name = controlName + "_QuantityLabel";
            quantityLabel.Text = "Quantity";
            quantityLabel.Size = new Size(55, 25);
            quantityLabel.Location = new Point(35, currentY);
            quantityLabel.ForeColor = Color.White;

            return quantityLabel;
        }

        private NumericUpDown BuildQuantityUpDown(int currentY, int quantity, string controlName)
        {

            NumericUpDown quantityUpDown = new NumericUpDown();
            quantityUpDown.Name = controlName + "_QuantityUpDown";
            quantityUpDown.Size = new System.Drawing.Size(125, 90);
            quantityUpDown.Maximum = 100000000000;
            quantityUpDown.Value = quantity;
            quantityUpDown.Location = new System.Drawing.Point(95, currentY);
            return quantityUpDown;
        }

        private Label BuildPriceLabel(int currentY, string controlName)
        {
            Label priceLabel = new Label();
            priceLabel.Name = controlName + "_PriceLabel";
            priceLabel.Text = "Price";
            priceLabel.Size = new Size(35, 25);
            priceLabel.Location = new Point(225, currentY);
            priceLabel.ForeColor = Color.White;

            return priceLabel;
        }

        private NumericUpDown BuildPriceUpDown(int currentY, double price, string controlName)
        {

            NumericUpDown quantityUpDown = new NumericUpDown();
            quantityUpDown.Name = controlName + "_PriceUpDown";
            quantityUpDown.Size = new System.Drawing.Size(125, 90);
            quantityUpDown.Maximum = 100000000000;
            quantityUpDown.Value = (decimal)price;
            quantityUpDown.Location = new System.Drawing.Point(265, currentY);
            return quantityUpDown;
        }
        #endregion
    }
}
