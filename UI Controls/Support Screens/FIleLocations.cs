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
        public FIleLocations()
        {
            InitializeComponent();
            SetLabels();
        }

        private void SetLabels()
        {
            SQLiteLabel.Text = Database.SQLiteCalls.GetSQLiteDirectory();
            AbyssRunLabel.Text = Enums.Enums.AbyssRunDirectory;
            PriceHistoryLabel.Text =   Enums.Enums.CachedPriceHistory;
            TrackedItemsLabel.Text = Enums.Enums.TrackedTypeDirectory;
            DefaultFormValuesLabel.Text = Enums.Enums.CachedFormValuesDirectory;
        }
    }
}
