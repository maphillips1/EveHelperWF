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

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class FIleLocations : Objects.FormBase
    {
        public FIleLocations()
        {
            InitializeComponent();
            SetLabels();
        }

        private void SetLabels()
        {
            SQLiteLabel.Text = Database.SQLiteCalls.GetSQLiteDirectory();
            AbyssRunLabel.Text = Enums.Enums.AbyssRunDirectory;
            PriceHistoryLabel.Text = Enums.Enums.CachedPriceHistory;
            TrackedItemsLabel.Text = Enums.Enums.TrackedTypeDirectory;
            DefaultFormValuesLabel.Text = Enums.Enums.CachedFormValuesDirectory;
            BuildPlansLinkLabel.Text = Enums.Enums.BuildPlanDirectory;
            ShoppingListsLinkLabel.Text = Enums.Enums.ShoppingListsDirectory;
        }

        private void SQLiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Database.SQLiteCalls.GetSQLiteDirectory());
        }

        private void PriceHistoryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Enums.Enums.CachedPriceHistory);
        }

        private void AbyssRunLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Enums.Enums.AbyssRunDirectory);
        }

        private void TrackedItemsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Enums.Enums.TrackedTypeDirectory);
        }

        private void DefaultFormValuesLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Enums.Enums.CachedFormValuesDirectory);
        }

        private void OpenFileExplorerToDirectory(string path)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path);
            psi.Arguments = path;
            psi.FileName = "explorer.exe";
            Process.Start(psi);
        }

        private void BuildPlansLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Enums.Enums.BuildPlanDirectory);
        }

        private void ShoppingListsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileExplorerToDirectory(Enums.Enums.ShoppingListsDirectory);
        }
    }
}
