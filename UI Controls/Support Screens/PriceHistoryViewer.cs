﻿using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using System.ComponentModel;
using System.Data;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class PriceHistoryViewer : Objects.FormBase
    {
        private int SelectedTypeId = 0;
        private int RegionId = 0;
        private List<Objects.ESIPriceHistory> PriceHistory = new List<ESIPriceHistory>();


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
            PriceHistory = MarketBrowserHelper.GetPriceHistoryForRegionAndType(RegionId, SelectedTypeId);

            PriceHistoryControl.DatabindPriceHistory(PriceHistory);
        }

        private void LoadImage()
        {
            GetImageBackgroundWorker.RunWorkerAsync(argument: SelectedTypeId);
        }
        #endregion

        #region "Background Worker"
        private void GetImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[]? iamge = null;
            int selectedTypeID = Convert.ToInt32(e.Argument);

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
