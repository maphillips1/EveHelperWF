using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using EveHelperWF.UI_Controls.Support_Screens;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Reflection;

namespace EveHelperWF.UI_Controls
{
    public partial class MainScreen : Objects.FormBase
    {
        ConfigureDefaults? configureDefaults;
        AbyssTracker? abyssTracker;
        BackupFiles? backupFiles;
        FIleLocations? fIleLocations;
        PriceHistoryUtility? priceHistoryUtility;
        LootAppraisal? lootAppraisal;
        ShoppingListControl? shoppingList;
        BuildPlansControl? buildPlans;
        HunterIntel hunterIntel;
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        const int SW_RESTORE = 9;

        public MainScreen()
        {
            Enums.Enums.BackgroundColor = Properties.Settings.Default.BackgroundColor;

            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " v" + version.Major + "." + version.Minor + "." + version.Build + "-Beta";

            CheckForOtherInstance();

            if (!InitLongLoadingWorker.IsBusy)
            {
                InitLongLoadingWorker.RunWorkerAsync();
            }

            if (!UpdateWorker.IsBusy)
            {
                UpdateWorker.RunWorkerAsync();
            }

            if (!CheckInternetBGWorker.IsBusy)
            {
                CheckInternetBGWorker.RunWorkerAsync();
            }

            this.BringToFront();

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

        private void CheckForUpdates(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Tuple<bool, Objects.GitHub_Objects.Release> ShouldUpdate = GitHub_Calls.GitHubCalls.CheckForUpdate();
            e.Result = ShouldUpdate;
        }

        private bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
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
            CommonHelper.Init();
            CommonHelper.InitLongLoading();
        }

        private void ShoppingListButton_Click(object sender, EventArgs e)
        {
            if (shoppingList == null || shoppingList.IsDisposed) { shoppingList = new ShoppingListControl(); }
            shoppingList.StartPosition = FormStartPosition.CenterScreen;
            shoppingList.Show();
            shoppingList.BringToFront();
        }

        private void BuildPlansButton_Click(object sender, EventArgs e)
        {
            if (buildPlans == null || buildPlans.IsDisposed) { buildPlans = new BuildPlansControl(); }
            buildPlans.StartPosition = FormStartPosition.CenterScreen;
            buildPlans.Show();
            buildPlans.BringToFront();
        }

        private void importFIlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFiles importFiles = new ImportFiles();
            importFiles.StartPosition = FormStartPosition.CenterParent;
            importFiles.ShowDialog();
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportBugScreen reportBugScreen = new ReportBugScreen();
            reportBugScreen.StartPosition = FormStartPosition.CenterParent;
            reportBugScreen.ShowDialog();
        }

        private void UpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForUpdates(sender, e);
        }

        private void UpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tuple<bool, Objects.GitHub_Objects.Release> ShouldUpdate = (Tuple<bool, Objects.GitHub_Objects.Release>)e.Result;

            if (ShouldUpdate != null && ShouldUpdate.Item1)
            {
                UpdateMessageBox newReleaseScreen = new UpdateMessageBox(ShouldUpdate.Item2);
                newReleaseScreen.StartPosition = FormStartPosition.CenterParent;
                newReleaseScreen.Show();
                newReleaseScreen.BringToFront();
            }
        }

        private void CheckInternetBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool hasInternet = CheckForInternetConnection();

            e.Result = hasInternet;
        }

        private void CheckInternetBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool hasInternet = (bool)e.Result;
            if (!hasInternet)
            {
                MessageBox.Show("Unable to connect to the internet. Check your connection.");
            }
        }

        private void DocumentationLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string docLabel = String.Format("https://maphillips1.github.io/EveHelperWF/");
            ProcessStartInfo startInfo = new ProcessStartInfo(docLabel);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void LPOfferButton_Click(object sender, EventArgs e)
        {
            LPStore lPStore = new LPStore();
            lPStore.StartPosition = FormStartPosition.CenterParent;
            lPStore.Show();
            lPStore.BringToFront();
        }

        private void InitLongLoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AbyssTrackerButton.Enabled = true;
            BlueprintBrowserButton.Enabled = true;
            BuildPlansButton.Enabled = true;
            LootAppraisalButton.Enabled = true;
            LPOfferButton.Enabled = true;
            MarketBrowserButton.Enabled = true;
            PlanetPlannerButton.Enabled = true;
            PriceHistoryButton.Enabled = true;
            DefaultsButtonClick.Enabled = true;
            ShoppingListButton.Enabled = true;
            SystemFinderButton.Enabled = true;
        }

        private void ThemePickerButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();


            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Enums.Enums.BackgroundColor = colorDialog.Color;
                Properties.Settings.Default.BackgroundColor = Enums.Enums.BackgroundColor;
                this.BackColor = colorDialog.Color;
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.BackgroundColor = Enums.Enums.BackgroundColor;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Enums.Enums.BackgroundColor = Color.FromArgb(21, 21, 21);
            this.BackColor = Enums.Enums.BackgroundColor;
            Properties.Settings.Default.BackgroundColor = Enums.Enums.BackgroundColor;
        }

        private void HunterIntelButton_Click(object sender, EventArgs e)
        {
            if (hunterIntel == null)
            {
                hunterIntel = new HunterIntel();
                hunterIntel.StartPosition = FormStartPosition.CenterScreen;
                hunterIntel.WindowState = FormWindowState.Maximized;
                hunterIntel.Show();
                hunterIntel.BringToFront();
            }
            else
            {
                hunterIntel.BringToFront();
            }
        }
    }
}
