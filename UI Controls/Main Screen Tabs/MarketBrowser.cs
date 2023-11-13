using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class MarketBrowser : Objects.FormBase
    {
        private List<Objects.Region> regions = new List<Objects.Region>();
        private List<Objects.SolarSystem> solarSystems = new List<Objects.SolarSystem>();
        private int SelectedTypeID;
        private InventoryTypeWIthMarketOrders selectedTypeMarketOrders = null;
        private List<ESIPriceHistory> priceHistory = new List<ESIPriceHistory>();

        public MarketBrowser()
        {
            MarketBrowserHelper.Init();
            InitializeComponent();
            LoadRegions();
            LoadTreeView();
        }

        private void LoadRegions()
        {
            regions = Database.SQLiteCalls.LoadRegions();
            RegionCombo.DisplayMember = "regionName";
            RegionCombo.ValueMember = "regionID";
            RegionCombo.DataSource = regions;
            RegionCombo.SelectedValue = ScreenHelper.Enums.TheForgeRegionId;

            //Default to the forge and jita. Most people wnat this. 
            LoadSystems(ScreenHelper.Enums.TheForgeRegionId);
            SystemCombo.SelectedValue = ScreenHelper.Enums.JitaSystemId;
        }

        private void LoadSystems(int regionID)
        {
            solarSystems = Database.SQLiteCalls.GetSolarSystemsForRegionID(regionID);
            solarSystems.Add(new Objects.SolarSystem());
            solarSystems = solarSystems.OrderBy(x => x.solarSystemName).ToList();

            SystemCombo.DisplayMember = "solarSystemName";
            SystemCombo.ValueMember = "solarSystemID";
            SystemCombo.DataSource = solarSystems;
        }

        private void LoadTreeView()
        {
            MarketListTreeView.Nodes.Clear();
            List<TreeNode> treeNodes = ScreenHelper.MarketBrowserHelper.BuildTreeView();
            MarketListTreeView.Nodes.AddRange(treeNodes.ToArray());
            MarketListTreeView.Sort();
        }

        private void JitaButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = ScreenHelper.Enums.TheForgeRegionId;
            LoadSystems(ScreenHelper.Enums.TheForgeRegionId);
            SystemCombo.SelectedValue = ScreenHelper.Enums.JitaSystemId;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void AmarrButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = ScreenHelper.Enums.DomainRegionID;
            LoadSystems(ScreenHelper.Enums.DomainRegionID);
            SystemCombo.SelectedValue = ScreenHelper.Enums.AmarrSystemID;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void RensButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = ScreenHelper.Enums.HeimatarRegionID;
            LoadSystems(ScreenHelper.Enums.HeimatarRegionID);
            SystemCombo.SelectedValue = ScreenHelper.Enums.RensSystemID;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void DodixieButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = ScreenHelper.Enums.SinqLiason;
            LoadSystems(ScreenHelper.Enums.SinqLiason);
            SystemCombo.SelectedValue = ScreenHelper.Enums.DodixieSystemID;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void LoadMarketData(int selectedTypeId)
        {
            int regionID = (int)RegionCombo.SelectedValue;
            int systemID = (int)SystemCombo.SelectedValue;
            selectedTypeMarketOrders = ScreenHelper.MarketBrowserHelper.GetMarketOrders(selectedTypeId, regionID, systemID);
        }

        private void MarketListTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (MarketListTreeView.SelectedNode != null)
            {
                TreeNode selectedNode = MarketListTreeView.SelectedNode;
                if (selectedNode.Tag.ToString().StartsWith("typeID"))
                {
                    if (ScreenHelper.MarketBrowserHelper.InventoryTypes != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        SelectedTypeID = Convert.ToInt32(selectedNode.Tag.ToString().Split("_")[1]);

                        LoadDataForSelectedType();

                        if (!SelectedItemImageWorker.IsBusy)
                        {
                            SelectedItemImageWorker.RunWorkerAsync(argument: SelectedTypeID);
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void DatabindGrids()
        {
            if (selectedTypeMarketOrders != null)
            {
                this.BuyOrdersGridView.DataSource = selectedTypeMarketOrders.BuyOrders;
                this.SellOrdersGridView.DataSource = selectedTypeMarketOrders.SellOrders;
            }
            if (priceHistory != null)
            {
                PriceHistoryGridView.DataSource = priceHistory;
            }
        }

        private void SelectedItemImageWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            byte[] iamge = null;
            int selectedTypeID = (int)(e.Argument);

            if (selectedTypeID > 0)
            {
                iamge = ESIImageServer.GetImageForType(selectedTypeID, "icon");
            }

            e.Result = iamge;
        }

        private void SelectedItemImageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void LoadDataForSelectedType()
        {
            int regionID = (int)RegionCombo.SelectedValue;
            LoadMarketData(SelectedTypeID);
            MarketBrowserHelper.FillInventoryTypeInformation(ref selectedTypeMarketOrders);
            SelectedItemLabel.Text = selectedTypeMarketOrders.typeName;
            priceHistory = MarketBrowserHelper.GetPriceHistoryForRegionAndType(regionID, SelectedTypeID);
            DatabindGrids();
        }

        private void RegionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int regionID = (int)RegionCombo.SelectedValue;
            LoadSystems(regionID);
            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void SystemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void TheraButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = ScreenHelper.Enums.TheraRegion;
            LoadSystems(ScreenHelper.Enums.TheraRegion);
            SystemCombo.SelectedValue = ScreenHelper.Enums.TheraSystem;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }
    }
}
