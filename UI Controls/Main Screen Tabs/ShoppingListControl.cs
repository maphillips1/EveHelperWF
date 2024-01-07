using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.DataFormats;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class ShoppingListControl : Objects.FormBase
    {
        string[] fileNames = null;
        List<ComboListItem> ComboItems = new List<ComboListItem>();
        Objects.ShoppingList theShoppingList = null;
        string ShoppingListFileName;
        InventoryTypes selectedType;
        BindingList<InventoryTypes> foundTypes = null;

        #region "Init"
        public ShoppingListControl()
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
            LoadShoppingItemsPanel();
        }

        private void BoughtCheckbox_Checked(Object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string[] checkName = checkBox.Name.Split(new char[] { '_' });
            int typeId = int.Parse(checkName[1]);
            if (typeId > 0)
            {
                theShoppingList.ShoppinglistItems.Find(x => x.typeId == typeId).Bought = checkBox.Checked;
            }
            SaveShoppingList();
            LoadShoppingItemsPanel();
        }

        private void QuantityUpDown_ValueChanged(Object sender, EventArgs e)
        {
            NumericUpDown upDown = (NumericUpDown)sender;
            string[] checkName = upDown.Name.Split(new char[] { '_' });
            int typeId = int.Parse(checkName[1]);
            if (typeId > 0)
            {
                theShoppingList.ShoppinglistItems.Find(x => x.typeId == typeId).Quantity = (int)upDown.Value;
            }
            SaveShoppingList();
        }

        private void PriceUpDown_ValueChanged(Object sender, EventArgs e)
        {
            NumericUpDown upDown = (NumericUpDown)sender;
            string[] checkName = upDown.Name.Split(new char[] { '_' });
            int typeId = int.Parse(checkName[1]);
            if (typeId > 0)
            {
                theShoppingList.ShoppinglistItems.Find(x => x.typeId == typeId).BoughtAtPrice = (int)upDown.Value;
            }
            SaveShoppingList();
        }

        private void Numeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                numericUpDown.Value = 0;
            }
        }

        private void DeleteListButton_Click(object sender, EventArgs e)
        {
            if (theShoppingList != null && !string.IsNullOrWhiteSpace(ShoppingListFileName))
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    theShoppingList = null;
                    FileIO.FileHelper.DeleteFile(Enums.Enums.ShoppingListsDirectory, ShoppingListFileName);
                    LoadShoppingListCombo();
                }
            }
        }

        private void NewListButton_Click(object sender, EventArgs e)
        {
            if (PromptUserForFileName())
            {
                LoadShoppingListCombo();
                int lastSlashIndex = ShoppingListFileName.LastIndexOf('\\');
                int lastDotIndex = ShoppingListFileName.LastIndexOf(".");
                string comboName = ShoppingListFileName.Substring(lastSlashIndex + 1, lastDotIndex - 1 - lastSlashIndex);
                int comboKey = ComboItems.Find(x => x.value.ToLowerInvariant().Equals(comboName.ToLowerInvariant())).key;
                if (comboKey > 0)
                {
                    ShoppingListCombo.SelectedValue = comboKey;
                }

            }
        }

        private void AddItemsButton_Click(object sender, EventArgs e)
        {
            if (ItemSearchResultsGrid.SelectedRows.Count > 0)
            {
                int typeId = 0;
                foreach (DataGridViewRow row in ItemSearchResultsGrid.SelectedRows)
                {
                    typeId = Convert.ToInt32(row.Cells["typeId"].Value);
                    if (typeId > 0)
                    {
                        selectedType = CommonHelper.InventoryTypes.Find(x => x.typeId == typeId);
                        break;
                    }
                }
            }

            if (selectedType != null)
            {
                if (theShoppingList == null)
                {
                    MessageBox.Show("No Shopping list selected. Add a new one or select an existing one", "What List?");
                }
                else
                {
                    QuantityDialog quantityDialog = new QuantityDialog();
                    quantityDialog.StartPosition = FormStartPosition.CenterParent;
                    if (quantityDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        AddSelectedTypeWithQuantity((int)(quantityDialog.QuantityUpDown.Value));
                        MessageBox.Show("Items Added!", "Items Added");
                    }
                    quantityDialog.Dispose();
                }
            }
            else
            {
                MessageBox.Show("You have to select an item to add", "Must Select Item");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemSearchTextBox.Text))
            {
                foundTypes = new BindingList<InventoryTypes>();
                string searchText = "'" + ItemSearchTextBox.Text + "%'";
                List<InventoryTypes> searchResults = Database.SQLiteCalls.InventoryTypeSearchForMarket(searchText);
                foreach (InventoryTypes invType in searchResults)
                {
                    foundTypes.Add(invType);
                }
                DatabindGridView<BindingList<InventoryTypes>>(ItemSearchResultsGrid, foundTypes);

                if (foundTypes.Count <= 0)
                {
                    MessageBox.Show("No items found with that description.", "Whomp Whomp");
                }
            }
            else
            {
                MessageBox.Show("Can't search for everything. Try typing something in the search box.", "Really?");
            }
        }

        private void ItemSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }
        #endregion

        #region "Methods"
        private void LoadShoppingListCombo()
        {
            ComboItems.Clear();
            ComboItems.Add(new ComboListItem { key = 0, value = string.Empty });
            fileNames = FileIO.FileHelper.GetFileNamesInDirectory(Enums.Enums.ShoppingListsDirectory);
            if (fileNames.Length > 0)
            {
                string comboName = "";
                int lastSlashIndex;
                int lastDotIndex;
                int count = 1;
                foreach (string file in fileNames)
                {
                    lastSlashIndex = file.LastIndexOf('\\');
                    lastDotIndex = file.LastIndexOf(".");
                    comboName = file.Substring(lastSlashIndex + 1, lastDotIndex - 1 - lastSlashIndex);
                    ComboItems.Add(new ComboListItem { key = count, value = comboName });
                    count++;
                }
            }
            ShoppingListCombo.DataSource = ComboItems;
            ShoppingListCombo.ValueMember = "key";
            ShoppingListCombo.DisplayMember = "value";
            ShoppingListCombo.DataSource = ComboItems;
        }

        private void LoadShoppingList()
        {
            ShoppingListItemsPanel.Controls.Clear();
            theShoppingList = null;
            string selectedFileName = GetSelectedFileName();
            if (!String.IsNullOrWhiteSpace(selectedFileName))
            {
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.ShoppingListsDirectory, selectedFileName);
                if (!string.IsNullOrEmpty(content))
                {
                    theShoppingList = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.ShoppingList>(content);
                }
                LoadShoppingItemsPanel();
            }
        }

        private string GetSelectedFileName()
        {
            int selectedFile = (int)ShoppingListCombo.SelectedValue;

            if (selectedFile > 0)
            {
                ComboListItem comboListItem = ComboItems.Find(x => x.key == selectedFile);

                if (comboListItem != null)
                {
                    string fileName = fileNames.ToList().Find(x => x.Contains(comboListItem.value));
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        ShoppingListFileName = fileName;
                        return fileName;
                    }
                }
            }
            return "";
        }

        private void LoadShoppingItemsPanel()
        {
            ShoppingListItemsPanel.Controls.Clear();
            if (theShoppingList != null && theShoppingList.ShoppinglistItems.Count > 0)
            {
                int currentY = 5;
                string controlName = "";

                foreach (ShoppingListItem item in theShoppingList.ShoppinglistItems)
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
                        ShoppingListItemsPanel.Controls.Add(BuildPriceUpDown(currentY, item.BoughtAtPrice, controlName));
                        currentY += 40;
                    }
                }
            }
        }
        private Label BuildTypeLabel(int currentY, string typeName, string controlName)
        {
            Label typeLabel = new Label();
            typeLabel.Name = controlName + "_TypeLabel";
            typeLabel.Text = typeName;
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(65, currentY);
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
            boughtCheckbox.CheckedChanged += new EventHandler(BoughtCheckbox_Checked);
            boughtCheckbox.Text = "Bought";
            return boughtCheckbox;
        }

        private Label BuildQuantityLabel(int currentY, string controlName)
        {
            Label quantityLabel = new Label();
            quantityLabel.Name = controlName + "_QuantityLabel";
            quantityLabel.Text = "Quantity";
            quantityLabel.Size = new Size(70, 25);
            quantityLabel.Location = new Point(65, currentY);
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
            quantityUpDown.Location = new System.Drawing.Point(155, currentY);
            quantityUpDown.ValueChanged += new EventHandler(QuantityUpDown_ValueChanged);
            quantityUpDown.KeyUp += new KeyEventHandler(Numeric_KeyUp);
            return quantityUpDown;
        }

        private Label BuildPriceLabel(int currentY, string controlName)
        {
            Label priceLabel = new Label();
            priceLabel.Name = controlName + "_PriceLabel";
            priceLabel.Text = "Price";
            priceLabel.Size = new Size(50, 25);
            priceLabel.Location = new Point(300, currentY);
            priceLabel.ForeColor = Color.White;

            return priceLabel;
        }

        private NumericUpDown BuildPriceUpDown(int currentY, double price, string controlName)
        {

            NumericUpDown boughtPriceUpDown = new NumericUpDown();
            boughtPriceUpDown.Name = controlName + "_PriceUpDown";
            boughtPriceUpDown.Size = new System.Drawing.Size(125, 90);
            boughtPriceUpDown.Maximum = 100000000000;
            boughtPriceUpDown.Value = (decimal)price;
            boughtPriceUpDown.Location = new System.Drawing.Point(360, currentY);
            boughtPriceUpDown.ValueChanged += new EventHandler(PriceUpDown_ValueChanged);
            boughtPriceUpDown.KeyUp += new KeyEventHandler(Numeric_KeyUp);
            return boughtPriceUpDown;
        }

        private void SaveShoppingList()
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(theShoppingList);
            FileIO.FileHelper.SaveFileContent(Enums.Enums.ShoppingListsDirectory, ShoppingListFileName, content);
        }

        public bool PromptUserForFileName()
        {
            bool success = false;
            FileNameDialog fileNameDialog = new FileNameDialog("Shopping List Name");
            fileNameDialog.StartPosition = FormStartPosition.CenterParent;
            if (fileNameDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = Enums.Enums.ShoppingListsDirectory + fileNameDialog.FileNameTextBox.Text + ".json";
                theShoppingList = new Objects.ShoppingList();
                ShoppingListFileName = fileName;
                SaveShoppingList();
                success = true;
            }
            fileNameDialog.Dispose();
            return success;
        }

        private void AddSelectedTypeWithQuantity(int quantity)
        {

            ShoppingListItem item = theShoppingList.ShoppinglistItems.Find(x => x.typeId == selectedType.typeId);
            if (item == null)
            {
                item = new ShoppingListItem();
                item.Quantity = quantity;
                item.typeId = selectedType.typeId;
                item.typeName = selectedType.typeName;
                item.groupName = selectedType.groupName;
                item.volume = selectedType.volume;
                item.graphicId = selectedType.graphicId;
                item.basePrice = selectedType.basePrice;
                theShoppingList.ShoppinglistItems.Add(item);
            }
            else
            {
                if (item.Bought)
                {
                    item.Quantity = quantity;
                    item.Bought = false;
                }
                else
                {
                    item.Quantity += quantity;
                }
            }
            SaveShoppingList();
            LoadShoppingItemsPanel();
        }
        #endregion
    }
}
