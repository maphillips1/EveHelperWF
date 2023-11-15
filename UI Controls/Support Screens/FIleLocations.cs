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
    public partial class FIleLocations : Objects.FormBase
    {
        private string SQLiteDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                                         "SQLite FIles\\");
        private string AbyssRunDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                         "AbyssRuns\\");
        private string PriceHistoryDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                     "PriceHistory\\");
        private string TrackedTypeDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                     "TrackedTypes\\");
        private string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";

        public FIleLocations()
        {
            InitializeComponent();
            SetLabels();
        }

        private void SetLabels()
        {
            SQLiteLabel.Text = SQLiteDirectory;
            AbyssRunLabel.Text = AbyssRunDirectory;
            PriceHistoryLabel.Text = PriceHistoryDirectory;
            TrackedItemsLabel.Text = TrackedTypeDirectory;
            DefaultFormValuesLabel.Text = CachedFormValuesDirectory;
        }
    }
}
