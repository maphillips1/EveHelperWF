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


        #region "Init"
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
            RegionCombo.SelectedValue = Enums.Enums.TheForgeRegionId;

            //Default to the forge and jita. Most people wnat this. 
            LoadSystems(Enums.Enums.TheForgeRegionId);
            SystemCombo.SelectedValue = Enums.Enums.JitaSystemId;
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
            MarketListTreeView.SelectedNode = null;
        }
        #endregion

        #region "Events"

        private void JitaButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = Enums.Enums.TheForgeRegionId;
            LoadSystems(Enums.Enums.TheForgeRegionId);
            SystemCombo.SelectedValue = Enums.Enums.JitaSystemId;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void AmarrButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = Enums.Enums.DomainRegionID;
            LoadSystems(Enums.Enums.DomainRegionID);
            SystemCombo.SelectedValue = Enums.Enums.AmarrSystemID;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void RensButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = Enums.Enums.HeimatarRegionID;
            LoadSystems(Enums.Enums.HeimatarRegionID);
            SystemCombo.SelectedValue = Enums.Enums.RensSystemID;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void DodixieButton_Click(object sender, EventArgs e)
        {
            RegionCombo.SelectedValue = Enums.Enums.SinqLiason;
            LoadSystems(Enums.Enums.SinqLiason);
            SystemCombo.SelectedValue = Enums.Enums.DodixieSystemID;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void SearchResultsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = SearchResultsTreeView.SelectedNode;
            AfterSelectHandler(selectedNode);
        }

        private void MarketListTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = MarketListTreeView.SelectedNode;
            AfterSelectHandler(selectedNode);
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
            RegionCombo.SelectedValue = Enums.Enums.TheraRegion;
            LoadSystems(Enums.Enums.TheraRegion);
            SystemCombo.SelectedValue = Enums.Enums.TheraSystem;

            if (SelectedTypeID > 0)
            {
                LoadDataForSelectedType();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchResultsTreeView.Nodes.Clear();
            string searchText = SearchTextBox.Text.ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                List<TreeNode> foundNodes = MarketBrowserHelper.SearchBlueprints(searchText);
                if (foundNodes.Count > 0)
                {
                    SearchResultsTreeView.Nodes.AddRange(foundNodes.ToArray());
                }
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, new EventArgs());
            }
        }

        private void ClearSystemButton_Click(object sender, EventArgs e)
        {
            SystemCombo.SelectedValue = 0;
            SystemCombo_SelectedIndexChanged(sender, e);
        }
        #endregion

        #region "Methods"

        private void LoadMarketData(int selectedTypeId)
        {
            int regionID = (int)RegionCombo.SelectedValue;
            int systemID = (int)SystemCombo.SelectedValue;
            selectedTypeMarketOrders = ScreenHelper.MarketBrowserHelper.GetMarketOrders(selectedTypeId, regionID, systemID);
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
                PriceHistoryGridView.DataSource = priceHistory.OrderByDescending(x => x.date).ToList(); ;
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

        private void AfterSelectHandler(TreeNode selectedNode)
        {
            if (selectedNode != null)
            {
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
        #endregion

        #region "Background Worker"

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
        #endregion

    }
}
