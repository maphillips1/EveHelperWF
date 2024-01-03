using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class PriceHistoryViewer : Objects.FormBase
    {
        private int SelectedTypeId = 0;
        private int RegionId = 0;
        private BindingList<Objects.ESIPriceHistory> PriceHistory = new BindingList<ESIPriceHistory>();


        #region "Init"
        public PriceHistoryViewer(int selectedTypeId, int regionID, string selectedTypeName)
        {
            InitializeComponent();
            SelectedTypeId = selectedTypeId;
            RegionId = regionID;
            PriceHistoryForLabel.Text = "Price History for " + selectedTypeName;
            LoadPriceHistory();
            LoadImage();
        }

        private void LoadPriceHistory()
        {
            List<ESIPriceHistory> history = MarketBrowserHelper.GetPriceHistoryForRegionAndType(RegionId, SelectedTypeId);
            if (history == null) { history = new List<ESIPriceHistory>(); }
            foreach (ESIPriceHistory priceHistory in history)
            {
                PriceHistory.Add(priceHistory);
            }

            DatabindGridView<List<ESIPriceHistory>>(PriceHistoryGridView, PriceHistory.OrderByDescending(x => x.date).ToList());
        }

        private void LoadImage()
        {
            GetImageBackgroundWorker.RunWorkerAsync(argument: SelectedTypeId);
        }
        #endregion

        #region "Background Worker"
        private void GetImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] iamge = null;
            int selectedTypeID = (int)(e.Argument);

            if (selectedTypeID > 0)
            {
                iamge = ESIImageServer.GetImageForType(selectedTypeID, "icon");
            }

            e.Result = iamge;
        }

        private void GetImageBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            byte[] imageBytes = null;
            if (e.Result != null)
            {
                imageBytes = (byte[])e.Result;
            }
            bool imageSet = false; ;
            if (imageBytes != null && imageBytes.Length > 0)
            {
                MemoryStream memStream = new MemoryStream();
                memStream.Write(imageBytes, 0, imageBytes.Length);
                this.SelectedItemImagePanel.BackgroundImage = Image.FromStream(memStream);

            }
            if (imageSet)
            {
                this.SelectedItemImagePanel.BackgroundImage = null;
            }
        }
        #endregion
    }
}
