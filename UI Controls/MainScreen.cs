using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
