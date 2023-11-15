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
        private static string AbyssRunDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                         "AbyssRuns\\");
        private string AbyssRunFileName = Path.Combine(AbyssRunDirectory, "AbyssRuns.json");

        private static string PriceHistoryDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                     "PriceHistory\\");

        private static string TrackedTypeDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                     "TrackedTypes\\");
        private string TrackedTypeFileName = Path.Combine(TrackedTypeDirectory, "TrackedTypes.json");


        private string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private static string CachedFormValuesFileName = "form_values.json";

        public BackupFiles()
        {
            InitializeComponent();
        }

        private void BackupFilesButton_Click(object sender, EventArgs e)
        {
            DialogResult result = BackupFilesDialog.ShowDialog();
         
            if(result == DialogResult.OK)
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

        private void BackupAbyssRuns(string selectedPath)
        {
            string fileContent = FileIO.FileHelper.GetCachedFileContent(AbyssRunDirectory, AbyssRunFileName);
            if (fileContent != null)
            {
                AbyssRunFileName =  Path.Combine(selectedPath, "AbyssRuns.json");
                FileIO.FileHelper.SaveCachedFile(selectedPath, AbyssRunFileName, fileContent);
            }
        }

        private void BackupPriceHistory(string selectedPath)
        {
            string[] priceHistoryFiles = Directory.GetFiles(PriceHistoryDirectory);
            if (priceHistoryFiles != null && priceHistoryFiles.Count() > 0)
            {
                string fileContent = null;
                string actualFileName;
                string newFileName;
                foreach(string fileName in priceHistoryFiles)
                {
                    fileContent = FileIO.FileHelper.GetCachedFileContent(PriceHistoryDirectory, fileName);
                    if (fileContent != null)
                    {
                        actualFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, (fileName.Length - fileName.LastIndexOf("\\") - 1));
                        newFileName = Path.Combine(selectedPath, actualFileName);
                        FileHelper.SaveCachedFile(selectedPath, newFileName, fileContent);
                    }
                }
            }
        }

        private void BackupTrackedItems(string selectedPath)
        {
            string fileContent = FileIO.FileHelper.GetCachedFileContent(TrackedTypeDirectory, TrackedTypeFileName);
            if (fileContent != null)
            {
                TrackedTypeFileName = Path.Combine(selectedPath, "TrackedTypes.json");
                FileIO.FileHelper.SaveCachedFile(selectedPath, TrackedTypeFileName, fileContent);
            }
        }

        private void BackupDefaultValues(string selectedPath)
        {
            string fileName = Path.Combine(CachedFormValuesDirectory, CachedFormValuesFileName);
            string fileContent = FileIO.FileHelper.GetCachedFileContent(CachedFormValuesDirectory, fileName);
            if (fileContent != null)
            {
                CachedFormValuesFileName = Path.Combine(selectedPath, CachedFormValuesFileName);
                FileIO.FileHelper.SaveCachedFile(selectedPath, CachedFormValuesFileName, fileContent);
            }
        }
    }

}
