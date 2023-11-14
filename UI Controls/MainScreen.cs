using EveHelperWF.Objects;
using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls
{
    public partial class MainScreen : Objects.FormBase
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void BlueprintBrowserButton_Click(object sender, EventArgs e)
        {
            BlueprintBrowser blueprintBrowser = new BlueprintBrowser();
            blueprintBrowser.StartPosition = FormStartPosition.CenterScreen;
            blueprintBrowser.Show();
        }

        private void PlanetPlannerButton_Click(object sender, EventArgs e)
        {
            PlanetPlanner planetPlanner = new PlanetPlanner();
            planetPlanner.StartPosition = FormStartPosition.CenterScreen;
            planetPlanner.Show();
        }

        private void LootAppraisalButton_Click(object sender, EventArgs e)
        {
            LootAppraisal lootAppraisal = new LootAppraisal();
            lootAppraisal.StartPosition = FormStartPosition.CenterScreen;
            lootAppraisal.Show();
        }

        private void SystemFinderButton_Click(object sender, EventArgs e)
        {
            SystemFinder systemFinder = new SystemFinder();
            systemFinder.StartPosition = FormStartPosition.CenterScreen;
            systemFinder.Show();
        }

        private void DefaultsButtonClick_Click(object sender, EventArgs e)
        {
            ConfigureDefaults configureDefaults = new ConfigureDefaults();
            configureDefaults.StartPosition = FormStartPosition.CenterScreen;
            configureDefaults.Show();
        }

        private void MarketBrowserButton_Click(object sender, EventArgs e)
        {
            MarketBrowser marketBrowser = new MarketBrowser();
            marketBrowser.StartPosition = FormStartPosition.CenterScreen;
            marketBrowser.Show();
        }

        private void AbyssTrackerButton_Click(object sender, EventArgs e)
        {
            AbyssTracker abyssTracker = new AbyssTracker();
            abyssTracker.StartPosition = FormStartPosition.CenterScreen;
            abyssTracker.Show();
        }

        private void FuzzworksLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string dotLanURL = String.Format("https://www.fuzzwork.co.uk/");
            ProcessStartInfo startInfo = new ProcessStartInfo(dotLanURL);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void PriceHistoryButton_Click(object sender, EventArgs e)
        {
            PriceHistoryUtility priceHistoryUtility = new PriceHistoryUtility();
            priceHistoryUtility.StartPosition = FormStartPosition.CenterScreen;
            priceHistoryUtility.Show();
        }
    }
}
