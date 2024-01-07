using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls
{
    public partial class MainScreen : Objects.FormBase
    {
        ConfigureDefaults configureDefaults;
        AbyssTracker abyssTracker;
        BackupFiles backupFiles;
        FIleLocations fIleLocations;
        PriceHistoryUtility priceHistoryUtility;
        LootAppraisal lootAppraisal;
        ShoppingListControl shoppingList;
        System.Threading.Mutex objMutex;
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        const int SW_RESTORE = 9;

        public MainScreen()
        {
            CheckForOtherInstance();
            CheckForUpdates();
            InitializeComponent();
            CommonHelper.Init();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " v" + version.Major + "." + version.Minor + "." + version.Build + "-Beta";

            if (!InitLongLoadingWorker.IsBusy)
            {
                InitLongLoadingWorker.RunWorkerAsync();
            }
        }

        //Ensures that we only ever have one instance of EveHelper open at a given time. 
        //You can have some tools open as many times as you want, but we only ever want one
        //instance of eve helper. 
        private void CheckForOtherInstance()
        {
            Process[] currentEveHelperInstance = System.Diagnostics.Process.GetProcessesByName(
                    System.IO.Path.GetFileNameWithoutExtension(
                        System.Reflection.Assembly.GetEntryAssembly().Location));
            if (currentEveHelperInstance.Count() > 1)
            {
                Process otherInstance = currentEveHelperInstance.ToList().First(x => x.Id != Process.GetCurrentProcess().Id);
                IntPtr handle = otherInstance.MainWindowHandle;
                if (IsIconic(handle))
                {
                    ShowWindow(handle, SW_RESTORE);
                }

                SetForegroundWindow(handle);
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            }
        }

        private void CheckForUpdates()
        {
            Tuple<bool, Objects.GitHub_Objects.Release> ShouldUpdate = GitHub_Calls.GitHubCalls.CheckForUpdate();
            if (ShouldUpdate.Item1)
            {
                UpdateMessageBox newReleaseScreen = new UpdateMessageBox(ShouldUpdate.Item2);
                newReleaseScreen.StartPosition = FormStartPosition.CenterParent;
                newReleaseScreen.ShowDialog();
            }
        }

        private void BlueprintBrowserButton_Click(object sender, EventArgs e)
        {
            BlueprintBrowser blueprintBrowser = new BlueprintBrowser();
            blueprintBrowser.StartPosition = FormStartPosition.CenterScreen;
            blueprintBrowser.Show();
        }

        private void PlanetPlannerButton_Click(object sender, EventArgs e)
        {
            PlanetaryIndustry planetPlanner = new PlanetaryIndustry();
            planetPlanner.StartPosition = FormStartPosition.CenterScreen;
            planetPlanner.Show();
        }

        private void LootAppraisalButton_Click(object sender, EventArgs e)
        {
            if (lootAppraisal == null || lootAppraisal.IsDisposed) { lootAppraisal = new LootAppraisal(); }
            lootAppraisal.StartPosition = FormStartPosition.CenterScreen;
            lootAppraisal.Show();
            lootAppraisal.BringToFront();
        }

        private void SystemFinderButton_Click(object sender, EventArgs e)
        {
            SystemFinder systemFinder = new SystemFinder();
            systemFinder.StartPosition = FormStartPosition.CenterScreen;
            systemFinder.Show();
        }

        private void DefaultsButtonClick_Click(object sender, EventArgs e)
        {
            if (configureDefaults == null || configureDefaults.IsDisposed) { configureDefaults = new ConfigureDefaults(); }
            configureDefaults.StartPosition = FormStartPosition.CenterScreen;
            configureDefaults.Show();
            configureDefaults.BringToFront();
        }

        private void MarketBrowserButton_Click(object sender, EventArgs e)
        {
            MarketBrowser marketBrowser = new MarketBrowser();
            marketBrowser.StartPosition = FormStartPosition.CenterScreen;
            marketBrowser.Show();
        }

        private void AbyssTrackerButton_Click(object sender, EventArgs e)
        {
            if (abyssTracker == null || abyssTracker.IsDisposed) { abyssTracker = new AbyssTracker(); }
            abyssTracker.StartPosition = FormStartPosition.CenterScreen;
            abyssTracker.Show();
            abyssTracker.BringToFront();
        }

        private void FuzzworksLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fuzzLabel = String.Format("https://www.fuzzwork.co.uk/");
            ProcessStartInfo startInfo = new ProcessStartInfo(fuzzLabel);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void PriceHistoryButton_Click(object sender, EventArgs e)
        {
            if (priceHistoryUtility == null || priceHistoryUtility.IsDisposed) { priceHistoryUtility = new PriceHistoryUtility(); }
            priceHistoryUtility.StartPosition = FormStartPosition.CenterScreen;
            priceHistoryUtility.Show();
            priceHistoryUtility.BringToFront();
        }

        private void fileLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fIleLocations == null || fIleLocations.IsDisposed) { fIleLocations = new FIleLocations(); }
            fIleLocations.StartPosition = FormStartPosition.CenterScreen;
            fIleLocations.Show();
            fIleLocations.BringToFront();
        }

        private void backupFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backupFiles == null || backupFiles.IsDisposed) { backupFiles = new BackupFiles(); }
            backupFiles.StartPosition = FormStartPosition.CenterScreen;
            backupFiles.Show();
            backupFiles.BringToFront();
        }

        private void FreyaLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string freyaLink = String.Format("https://evewho.com/character/96542763");
            ProcessStartInfo startInfo = new ProcessStartInfo(freyaLink);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void updateEveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSDE updateSDE = new UpdateSDE();
            updateSDE.StartPosition = FormStartPosition.CenterParent;
            updateSDE.Show();
        }

        private void InitLongLoadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CommonHelper.InitLongLoading();
        }

        private void ShoppingListButton_Click(object sender, EventArgs e)
        {
            if (shoppingList == null || shoppingList.IsDisposed) { shoppingList = new ShoppingListControl(); }
            shoppingList.StartPosition = FormStartPosition.CenterScreen;
            shoppingList.Show();
            shoppingList.BringToFront();
        }
    }
}
