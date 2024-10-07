using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using System.ComponentModel;
using System.Text;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class ShoppingListControl : Objects.FormBase
    {
        string[] fileNames = null;
        List<ComboListItem> ComboItems = new List<ComboListItem>();
        Objects.ShoppingList theShoppingList = null;
        string ShoppingListFileName;
        InventoryType selectedType;
        BindingList<InventoryType> foundTypes = null;

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
            LoadShoppingListGrid();
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
                    ShoppingListCombo.SelectedIndex = 0;
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
                foundTypes = new BindingList<InventoryType>();
                string searchText = "'" + ItemSearchTextBox.Text + "%'";
                List<InventoryType> searchResults = Database.SQLiteCalls.InventoryTypeSearchForMarket(searchText);
                foreach (InventoryType invType in searchResults)
                {
                    foundTypes.Add(invType);
                }
                DatabindGridView<BindingList<InventoryType>>(ItemSearchResultsGrid, foundTypes);

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

        private void CopyToClipboard_Click(object sender, EventArgs e)
        {
            if (theShoppingList != null && theShoppingList.ShoppinglistItems.Count > 0)
            {
                bool showBoughtItemMessage = false;
                StringBuilder sb = new StringBuilder();
                foreach (ShoppingListItem item in theShoppingList.ShoppinglistItems)
                {
                    if (!item.Bought)
                    {
                        sb.AppendLine(item.typeName + " " + item.Quantity);
                    }
                    else
                    {
                        showBoughtItemMessage = true;
                    }
                }
                Clipboard.SetText(sb.ToString());
                if (showBoughtItemMessage)
                {
                    MessageBox.Show("Items marked as bought are not copied tot he clipboard.");
                }
            }
        }
        #endregion

        #region "Methods"
        private void LoadShoppingListCombo()
        {
            ShoppingListCombo.DataSource = null;
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
            theShoppingList = null;
            string selectedFileName = GetSelectedFileName();
            if (!String.IsNullOrWhiteSpace(selectedFileName))
            {
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.ShoppingListsDirectory, selectedFileName);
                if (!string.IsNullOrEmpty(content))
                {
                    theShoppingList = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.ShoppingList>(content);
                }
                LoadShoppingListGrid();
            }
            else
            {
                ShoppingListGrid.DataSource = null;
            }
        }

        private string GetSelectedFileName()
        {
            int selectedFile = Convert.ToInt32(ShoppingListCombo.SelectedValue);

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

        private void LoadShoppingListGrid()
        {
            ShoppingListGrid.DataSource = null;
            DatabindGridView<List<ShoppingListItem>>(ShoppingListGrid, theShoppingList.ShoppinglistItems);
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
            LoadShoppingListGrid();
        }

        private void ShoppingListGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.theShoppingList != null)
            {
                SaveShoppingList();
            }
        }

        private void ShoppingListGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ShoppingListGrid.CurrentCell.ColumnIndex == 1 ||
                ShoppingListGrid.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ShppingListGrid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(e.Value)))
            {
                e.Value = 0;
            }
        }

        private void ShoppingListGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.Value = 0;
            }
        }

        private void ShoppingListGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.theShoppingList != null && 
                (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(e.FormattedValue)))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter a value before leaving the cell.");
                }
            }
        }

        private void ShoppingListyGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (this.theShoppingList != null)
            {
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
    }
}
