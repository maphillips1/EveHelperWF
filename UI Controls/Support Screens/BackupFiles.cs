using FileIO;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class BackupFiles : Objects.FormBase
    {
        private string AbyssRunFileName = "AbyssRuns.json";

        private string TrackedTypeFileName = "TrackedTypes.json";

        private static string CachedFormValuesFileName = "form_values.json";

        #region "Init"
        public BackupFiles()
        {
            InitializeComponent();
        }
        #endregion

        #region "Events"
        private void BackupFilesButton_Click(object sender, EventArgs e)
        {
            DialogResult result = BackupFilesDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string SelectedPath = BackupFilesDialog.SelectedPath;

                if (AbyssRunsCheckbox.Checked)
                {
                    BackupAbyssRuns(SelectedPath);
                }

                if (PriceHistoryCheckbox.Checked)
                {
                    BackupPriceHistory(SelectedPath);
                }

                if (TrackedItemsCheckbox.Checked)
                {
                    BackupTrackedItems(SelectedPath);
                }

                if (DefaultValuesCheckbox.Checked)
                {
                    BackupDefaultValues(SelectedPath);
                }

                if (BuildPlansCheckbox.Checked)
                {
                    BackupBuildPlans(SelectedPath);
                }

                if (ShoppingListCheckbox.Checked)
                {
                    BackupShoppingPlans(SelectedPath);
                }
                MessageBox.Show("Backup Complete");
            }
        }
        #endregion

        #region "Methods"
        private void BackupAbyssRuns(string selectedPath)
        {
            string fullAbyssFileName = Path.Combine(Enums.Enums.AbyssRunDirectory, AbyssRunFileName);
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.AbyssRunDirectory, fullAbyssFileName);
            if (fileContent != null)
            {
                string newFileName = Path.Combine(selectedPath, AbyssRunFileName);
                FileIO.FileHelper.SaveFileContent(selectedPath, newFileName, fileContent);
            }
        }

        private void BackupPriceHistory(string selectedPath)
        {
            string[] priceHistoryFiles = Directory.GetFiles(Enums.Enums.CachedPriceHistory);
            if (priceHistoryFiles != null && priceHistoryFiles.Count() > 0)
            {
                string selectedPathWithSubFolder = Path.Combine(selectedPath, "PriceHistories");
                string fileContent = null;
                string actualFileName;
                string newFileName;
                foreach (string fileName in priceHistoryFiles)
                {
                    fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedPriceHistory, fileName);
                    if (fileContent != null)
                    {
                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(selectedPathWithSubFolder, actualFileName);
                        FileHelper.SaveFileContent(selectedPathWithSubFolder, newFileName, fileContent);
                    }
                }
            }
        }

        private void BackupTrackedItems(string selectedPath)
        {
            string fullTrackedItemsFileName = Path.Combine(Enums.Enums.TrackedTypeDirectory, TrackedTypeFileName);
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.TrackedTypeDirectory, fullTrackedItemsFileName);
            if (fileContent != null)
            {
                string newFileName = Path.Combine(selectedPath, TrackedTypeFileName);
                FileIO.FileHelper.SaveFileContent(selectedPath, newFileName, fileContent);
            }
        }

        private void BackupDefaultValues(string selectedPath)
        {
            string fileName = Path.Combine(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedFormValuesDirectory, fileName);
            if (fileContent != null)
            {
                string newFileName = Path.Combine(selectedPath, CachedFormValuesFileName);
                FileIO.FileHelper.SaveFileContent(selectedPath, newFileName, fileContent);
            }
        }

        private void BackupBuildPlans(string selectedPath)
        {
            string[] BuildPlanFiles = Directory.GetFiles(Enums.Enums.BuildPlanDirectory);
            if (BuildPlanFiles != null && BuildPlanFiles.Count() > 0)
            {
                string selectedPathWithSubFolder = Path.Combine(selectedPath, "BuildPlans");
                string fileContent = null;
                string actualFileName;
                string newFileName;
                foreach (string fileName in BuildPlanFiles)
                {
                    fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.BuildPlanDirectory, fileName);
                    if (fileContent != null)
                    {
                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(selectedPathWithSubFolder, actualFileName);
                        FileHelper.SaveFileContent(selectedPathWithSubFolder, newFileName, fileContent);
                    }
                }
            }
        }

        private void BackupShoppingPlans(string selectedPath)
        {
            string[] ShoppingPlanFiles = Directory.GetFiles(Enums.Enums.ShoppingListsDirectory);
            if (ShoppingPlanFiles != null && ShoppingPlanFiles.Count() > 0)
            {
                string selectedPathWithSubFolder = Path.Combine(selectedPath, "ShoppingLists");
                string fileContent = null;
                string actualFileName;
                string newFileName;
                foreach (string fileName in ShoppingPlanFiles)
                {
                    fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.ShoppingListsDirectory, fileName);
                    if (fileContent != null)
                    {
                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(selectedPathWithSubFolder, actualFileName);
                        FileHelper.SaveFileContent(selectedPathWithSubFolder, newFileName, fileContent);
                    }
                }
            }
        }
        #endregion
    }

}
