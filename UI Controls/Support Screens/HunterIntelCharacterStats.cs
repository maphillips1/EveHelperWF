using EveHelperWF.Objects;
using EveHelperWF.Objects.ESI_Objects;
using EveHelperWF.Objects.ESI_Objects.KillMail;
using EveHelperWF.Objects.ZKill_Objects;
using EveHelperWF.ScreenHelper;
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
    public partial class HunterIntelCharacterStats : UserControl
    {
        UniverseIdSearchResultItem itemForStats;
        ZKillStats Stats = new ZKillStats();
        List<Killmail> Losses = new List<Killmail>();
        List<ESI_KillMail> ESI_Losses = new List<ESI_KillMail>();

        Dictionary<long, int> KillSystemCount = new Dictionary<long, int>();
        Dictionary<long, int> LossSystemCount = new Dictionary<long, int>();

        List<long> CynoFieldIDs = new List<long>() { 28646, 21096 };
        long industrialCynoId = 52694;

        List<ESI_KillMail> LossedWithIndyCyno = new List<ESI_KillMail>();
        List<ESI_KillMail> LossesWithCynos = new List<ESI_KillMail>();

        public HunterIntelCharacterStats(UniverseIdSearchResultItem characterResult)
        {
            InitializeComponent();
            itemForStats = characterResult;
            KillSystemListBox.BackColor = Enums.Enums.BackgroundColor;
            KillSystemListBox.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);
            
            TopShipsTreeView.BackColor = Enums.Enums.BackgroundColor;
            TopShipsTreeView.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            LoadStats();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackColor = Enums.Enums.BackgroundColor;
            this.ForeColor = CommonHelper.GetInvertedColor(this.BackColor);
            base.OnPaint(e);
        }

        private void LoadStats()
        {
            this.Cursor = Cursors.WaitCursor;
            LoadZKillStats();
            LoadZkillLosses();
            //ConvertZkillMailsToESIKillMails();
            DatabindScreen();
            this.Cursor = Cursors.Default;
        }

        private void LoadZKillStats()
        {
            Stats = ZKill_Calls.Zkill_Calls.LoadStats("characterID", itemForStats.id);
        }

        private void LoadZkillLosses()
        {
            List<Killmail> killmails = ZKill_Calls.Zkill_Calls.LoadCharacterLosses(itemForStats.id);
            if (killmails != null)
            {
                Losses = killmails;
            }
            ESI_Losses = ESI_Calls.ESIKillMail.ConvertZkillToESIKillMails(Losses).Result;
        }

        private void DatabindScreen()
        {
            NameLabel.Text = itemForStats.name;
            KillCountLabel.Text = Stats.shipsDestroyed.ToString("N0");
            LossCountLabel.Text = Stats.shipsLost.ToString("N0");
            DangerRatingLabel.Text = Stats.dangerRatio.ToString("N0");
            DestroyedValueLabel.Text = CommonHelper.FormatIskShortened((decimal)Stats.iskDestroyed);
            LostValueLabel.Text = CommonHelper.FormatIskShortened((decimal)Stats.iskLost);

            SetCynoField();
            SetTopSystems();
            SetTopShips();
        }

        private void SetCynoField()
        {
            FindKillsWithCyno();
            if (LossesWithCynos.Count == 0 && LossedWithIndyCyno.Count > 0)
            {
                IsCynoPilotLabel.Text = "Yes, Industrial Only";
            }
            else
            {
                bool isCynoPilot = (LossesWithCynos?.Count > 0 || LossedWithIndyCyno?.Count > 0);
                IsCynoPilotLabel.Text = "Yes";
            }
        }

        private void SetTopSystems()
        {
            ZkillTopLists topSystems = Stats.topLists?.Find(x => x.type.Equals("solarSystem"));
            if (topSystems != null)
            {
                List<string> topSystemsList = new List<string>();
                SolarSystem solarSystem = new SolarSystem();
                foreach (ZkillTopListsValues systems in topSystems.values)
                {
                    solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == systems.solarSystemID);
                    if (solarSystem != null)
                    {
                        topSystemsList.Add("System: " + solarSystem.solarSystemName + " , Kills: " + systems.kills.ToString("N0") + ", Region: " + solarSystem.regionName);
                    }
                }
                KillSystemListBox.DataSource = topSystemsList;  
            }
        }

        private void SetTopShips()
        {
            TopShipsTreeView.Nodes.Clear();
            ZkillTopLists topShips = Stats.topLists?.Find(x => x.type.Equals("shipType"));
            if (topShips != null)
            {
                InventoryType shipInvType;
                foreach (ZkillTopListsValues shipTypes in topShips.values)
                {
                    shipInvType = CommonHelper.InventoryTypes.Find(x => x.typeId == shipTypes.shipTypeID);
                    if (shipInvType != null)
                    {
                        TopShipsTreeView.Nodes.Add(shipInvType.typeName + " , Kills: " + shipTypes.kills.ToString("N0"));
                    }
                }
            }
        }

        private void FindKillsWithCyno()
        {
            LossesWithCynos = ESI_Losses.FindAll(x => x.victim.items?.FindAll(y => CynoFieldIDs.Contains(y.item_type_id))?.Count > 0);
            LossedWithIndyCyno = ESI_Losses.FindAll(x => x.victim.items?.FindAll(y => y.item_type_id == industrialCynoId)?.Count > 0);
        }
    }
}
