using EveHelperWF.Objects;
using FileIO;
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
    public partial class ImportFiles : Objects.FormBase
    {
        private string AbyssRunFileName = Path.Combine(Enums.Enums.AbyssRunDirectory, "AbyssRuns.json");
        private string TrackedTypeFileName = Path.Combine(Enums.Enums.TrackedTypeDirectory, "TrackedTypes.json");
        private static string CachedFormValuesFileName = "form_values.json";
        string[]? SelectedFileNames;
        public ImportFiles()
        {
            InitializeComponent();
            LoadTypeCombo();
        }

        private void LoadTypeCombo()
        {
            List<ComboListItem> comboListItems = new List<ComboListItem>();
            comboListItems.Add(new ComboListItem(1, "Price History"));
            comboListItems.Add(new ComboListItem(2, "Tracked Types"));
            comboListItems.Add(new ComboListItem(3, "Abyss Runs"));
            comboListItems.Add(new ComboListItem(4, "Default Values"));
            comboListItems.Add(new ComboListItem(5, "Build Plans"));
            comboListItems.Add(new ComboListItem(6, "Shopping Lists"));

            FileTypeCombo.DisplayMember = "value";
            FileTypeCombo.ValueMember = "key";
            FileTypeCombo.DataSource = comboListItems;
        }

        private void SelectFilesButton_Click(object sender, EventArgs e)
        {
            int selectedFileType = Convert.ToInt32(FileTypeCombo.SelectedValue);
            switch (selectedFileType)
            {
                case 1:
                case 5:
                case 6:
                    ImportFileDialog.Multiselect = true;
                    break;
                default:
                    ImportFileDialog.Multiselect = false;
                    break;
            }

            DialogResult result = ImportFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SelectedFileNames = ImportFileDialog.FileNames;
                StringBuilder fileNameSB = new StringBuilder();
                foreach (string fileName in SelectedFileNames)
                {
                    fileNameSB.AppendLine(fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1)));
                }
                FileNamesTextBox.Text = fileNameSB.ToString();
            }
            else
            {
                SelectedFileNames = null;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (SelectedFileNames == null)
            {
                MessageBox.Show("Select some files doofus.");
                return;
            }
            switch (Convert.ToInt32(FileTypeCombo.SelectedValue))
            {
                case 1:
                    ImportPriceHistory();
                    break;

                case 2:
                    ImportTrackedItems();
                    break;

                case 3:
                    ImportAbyssRuns();
                    break;

                case 4:
                    ImportDefaultValues();
                    break;

                case 5:
                    ImportBuildPlans();
                    break;

                case 6:
                    ImportShoppingPlans();
                    break;
            }
            SelectedFileNames = null;
            FileNamesTextBox.Text = "";
            MessageBox.Show("Import Complete!", "Completed");
        }
        private void ImportAbyssRuns()
        {
            string fileContent = fileContent = File.ReadAllText(SelectedFileNames[0]);
            if (fileContent != null)
            {
                try
                {
                    List<AbyssRun> runs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AbyssRun>>(fileContent);
                    string fullFileName = Path.Combine(Enums.Enums.AbyssRunDirectory, AbyssRunFileName);
                    FileIO.FileHelper.SaveFileContent(Enums.Enums.AbyssRunDirectory, fullFileName, fileContent);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Could not import file. Did you select the right file type?", "Failed Import.");
                }
            }
        }

        private void ImportPriceHistory()
        {
            if (SelectedFileNames != null && SelectedFileNames.Count() > 0)
            {
                string fileContent = null;
                string actualFileName;
                string newFileName;
                List<ESIPriceHistory> priceHistory;
                StringBuilder skippedList = new StringBuilder();
                foreach (string fileName in SelectedFileNames)
                {
                    fileContent = File.ReadAllText(fileName);
                    try
                    {
                        if (fileContent != null)
                        {
                            priceHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ESIPriceHistory>>(fileContent);
                            actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                            newFileName = Path.Combine(Enums.Enums.CachedPriceHistory, actualFileName);
                            FileHelper.SaveFileContent(Enums.Enums.CachedPriceHistory, newFileName, fileContent);
                        }
                    }
                    catch(Exception ex)
                    {
                        skippedList.AppendLine("Skipping file: " + fileName);
                    }
                }
                string skippedListString = skippedList.ToString();
                if (!string.IsNullOrEmpty(skippedListString))
                {
                    skippedListString += Environment.NewLine + "Did you select the right file type?";
                    MessageBox.Show(skippedListString, "Files with Incorrect Format.");
                }
            }
        }

        private void ImportTrackedItems()
        {
            string fileContent = File.ReadAllText(SelectedFileNames[0]);
            if (fileContent != null)
            {
                try
                {
                    BindingList<InventoryType> trackedTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<InventoryType>>(fileContent);
                    string fullFileName = Path.Combine(Enums.Enums.TrackedTypeDirectory, TrackedTypeFileName);
                    FileIO.FileHelper.SaveFileContent(Enums.Enums.TrackedTypeDirectory, fullFileName, fileContent);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Could not import file. Did you select the right file type?", "Failed Import.");
                }
            }
        }

        private void ImportDefaultValues()
        {
            string fileName = Path.Combine(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
            string fileContent = File.ReadAllText(SelectedFileNames[0]);
            if (fileContent != null)
            {
                DefaultFormValue defaultFormValue;
                try
                {
                    defaultFormValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultFormValue>(fileContent);
                    string fullFileName = Path.Combine(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
                    FileIO.FileHelper.SaveFileContent(Enums.Enums.CachedFormValuesDirectory, fullFileName, fileContent);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Could not import file. Did you select the right file type?", "Failed Import.");
                }
            }
        }

        private void ImportBuildPlans()
        {
            if (SelectedFileNames != null && SelectedFileNames.Count() > 0)
            {
                string fileContent = null;
                string actualFileName;
                string newFileName;
                BuildPlan buildPlan;
                StringBuilder skippedList = new StringBuilder();
                foreach (string fileName in SelectedFileNames)
                {
                    fileContent = File.ReadAllText(fileName);
                    if (fileContent != null)
                    {
                        try
                        {
                            buildPlan = Newtonsoft.Json.JsonConvert.DeserializeObject<BuildPlan>(fileContent);
                        }
                        catch (Exception ex)
                        {
                            skippedList.AppendLine("Skipping file: " + fileName);
                            continue;
                        }
                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(Enums.Enums.BuildPlanDirectory, actualFileName);
                        FileHelper.SaveFileContent(Enums.Enums.BuildPlanDirectory, newFileName, fileContent);
                    }
                }
                string skippedListString = skippedList.ToString();
                if (!string.IsNullOrEmpty(skippedListString))
                {
                    skippedListString += Environment.NewLine + "Did you select the right file type?";
                    MessageBox.Show(skippedListString, "Files with Incorrect Format.");
                }
            }
        }

        private void ImportShoppingPlans()
        {
            if (SelectedFileNames != null && SelectedFileNames.Count() > 0)
            {
                string fileContent = null;
                string actualFileName;
                string newFileName;
                ShoppingList shoppingList;
                StringBuilder skippedList = new StringBuilder();
                foreach (string fileName in SelectedFileNames)
                {
                    fileContent = File.ReadAllText(fileName);
                    if (fileContent != null)
                    {
                        try
                        {
                            shoppingList = Newtonsoft.Json.JsonConvert.DeserializeObject<ShoppingList>(fileContent);
                        }
                        catch (Exception ex)
                        {
                            skippedList.AppendLine("Skipping file: " + fileName);
                            continue;
                        }

                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(Enums.Enums.ShoppingListsDirectory, actualFileName);
                        FileHelper.SaveFileContent(Enums.Enums.ShoppingListsDirectory, newFileName, fileContent);
                    }
                }
                string skippedListString = skippedList.ToString();
                if (!string.IsNullOrEmpty(skippedListString))
                {
                    skippedListString += Environment.NewLine + "Did you select the right file type?";
                    MessageBox.Show(skippedListString, "Files with Incorrect Format.");
                }
            }
        }
    }
}
