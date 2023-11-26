using FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class BackupFiles : Objects.FormBase
    {
        private string AbyssRunFileName = Path.Combine(Enums.Enums.AbyssRunDirectory, "AbyssRuns.json");

        private string TrackedTypeFileName = Path.Combine(Enums.Enums.TrackedTypeDirectory, "TrackedTypes.json");

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
                MessageBox.Show("Backup Complete");
            }
        }
        #endregion

        #region "Methods"
        private void BackupAbyssRuns(string selectedPath)
        {
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.AbyssRunDirectory, AbyssRunFileName);
            if (fileContent != null)
            {
                AbyssRunFileName = Path.Combine(selectedPath, AbyssRunFileName);
                FileIO.FileHelper.SaveFileContent(selectedPath, AbyssRunFileName, fileContent);
            }
        }

        private void BackupPriceHistory(string selectedPath)
        {
            string[] priceHistoryFiles = Directory.GetFiles(Enums.Enums.CachedPriceHistory);
            if (priceHistoryFiles != null && priceHistoryFiles.Count() > 0)
            {
                string fileContent = null;
                string actualFileName;
                string newFileName;
                foreach (string fileName in priceHistoryFiles)
                {
                    fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedPriceHistory, fileName);
                    if (fileContent != null)
                    {
                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(selectedPath, actualFileName);
                        FileHelper.SaveFileContent(selectedPath, newFileName, fileContent);
                    }
                }
            }
        }

        private void BackupTrackedItems(string selectedPath)
        {
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.TrackedTypeDirectory, TrackedTypeFileName);
            if (fileContent != null)
            {
                TrackedTypeFileName = Path.Combine(selectedPath, TrackedTypeFileName);
                FileIO.FileHelper.SaveFileContent(selectedPath, TrackedTypeFileName, fileContent);
            }
        }

        private void BackupDefaultValues(string selectedPath)
        {
            string fileName = Path.Combine(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedFormValuesDirectory, fileName);
            if (fileContent != null)
            {
                CachedFormValuesFileName = Path.Combine(selectedPath, CachedFormValuesFileName);
                FileIO.FileHelper.SaveFileContent(selectedPath, CachedFormValuesFileName, fileContent);
            }
        }
        #endregion
    }

}
