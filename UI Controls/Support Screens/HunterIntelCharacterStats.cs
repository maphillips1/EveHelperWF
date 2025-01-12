using EveHelperWF.Objects;
using EveHelperWF.Objects.ESI_Objects;
using EveHelperWF.Objects.ESI_Objects.KillMail;
using EveHelperWF.Objects.ZKill_Objects;
using EveHelperWF.ScreenHelper;
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

        List<int> PvEShips = new List<int>() { 17918, 17715, 12005 };
        List<int> Marauders = new List<int>() { 28659, 28710, 28665, 28661 };
        List<int> Edencom = new List<int>() { 54732, 54733 };
        string corpName = "";
        string allianceName = "";
        double securityStatus = 0;
        DateTime BirthDate;

        public HunterIntelCharacterStats(UniverseIdSearchResultItem characterResult)
        {
            InitializeComponent();
            //Cancel previous query
            if (LoadLossesWorker.IsBusy)
            {
                LoadLossesWorker.CancelAsync();
                Thread.Sleep(1000);
            }
            itemForStats = characterResult;
            KillSystemTreeView.BackColor = Enums.Enums.BackgroundColor;
            KillSystemTreeView.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            TopShipsTreeView.BackColor = Enums.Enums.BackgroundColor;
            TopShipsTreeView.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            RecentLossesTreeView.BackColor = Enums.Enums.BackgroundColor;
            RecentLossesTreeView.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            TopRegionsTreeView.BackColor = Enums.Enums.BackgroundColor;
            TopRegionsTreeView.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            ZKillLabel.LinkColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            IsCynoPilotLabel.Text = "No";

            LoadStats();
            LoadCharInfo();
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
            //ConvertZkillMailsToESIKillMails();
            DatabindScreen();

            //Wait for it to finish
            if (LoadLossesWorker.IsBusy)
            {
                Thread.Sleep(1000);
            }

            LoadLossesWorker.RunWorkerAsync();

            this.Cursor = Cursors.Default;
        }

        private void LoadCharInfo()
        {
            if (CorpAllianceBackgroundWorker.IsBusy)
            {
                Thread.Sleep(200);
            }
            CorpAllianceBackgroundWorker.RunWorkerAsync(itemForStats.id);
        }

        private void LoadZKillStats()
        {
            Stats = ZKill_Calls.Zkill_Calls.LoadStats("characterID", itemForStats.id);
        }

        private void DatabindScreen()
        {
            NameLabel.Text = itemForStats.name + corpName + allianceName;
            KillCountLabel.Text = Stats.shipsDestroyed.ToString("N0");
            LossCountLabel.Text = Stats.shipsLost.ToString("N0");
            DangerRatingLabel.Text = Stats.dangerRatio.ToString("N0");
            DestroyedValueLabel.Text = CommonHelper.FormatIskShortened((decimal)Stats.iskDestroyed);
            LostValueLabel.Text = CommonHelper.FormatIskShortened((decimal)Stats.iskLost);
            ZKillLabel.Text = "https://zkillboard.com/character/" + itemForStats.id + "/";
            AvgAttackersLabel.Text = Stats.avgGangSize.ToString("N0");
            SoloLabel.Text = Stats.soloRatio.ToString();
            SecurityStatusLabel.Text = Math.Round(securityStatus,2).ToString();
            if (securityStatus > 0)
            {
                SecurityStatusLabel.ForeColor = Color.LightGreen;
            }
            else
            {
                SecurityStatusLabel.ForeColor = Color.OrangeRed;
            }

            SetCynoField();
            SetTopSystems();
            SetTopShips();
            SetRecentLosses();
            SetPvELossLabel();
            SetAge();
        }

        private void SetCynoField()
        {
            FindLossesWithCyno();
            if (LossesWithCynos.Count == 0 && LossedWithIndyCyno.Count > 0)
            {
                IsCynoPilotLabel.Text = "Yes, Industrial Only";
                IsCynoPilotLabel.ForeColor = Color.Gold;
            }
            else
            {
                bool isCynoPilot = (LossesWithCynos?.Count > 0 || LossedWithIndyCyno?.Count > 0);
                if (isCynoPilot)
                {
                    IsCynoPilotLabel.Text = "Yes";
                    IsCynoPilotLabel.ForeColor = Color.IndianRed;
                }

            }
        }

        private void SetAge()
        {
            if (BirthDate != null)
            {
                var result = GetDateDifference(BirthDate, DateTime.Now);
                AgeLabel.Text = $"Years: {result.Years}, Months: {result.Months}, Days: {result.Days}";
                AgeLabel.Left = SecurityStatusLabel.Right + 10;
            }
        }

        private void SetTopSystems()
        {
            KillSystemTreeView.Nodes.Clear();
            Dictionary<long, int> topRegions = new Dictionary<long, int>();
            ZkillTopLists topSystems = Stats.topLists?.Find(x => x.type.Equals("solarSystem"));
            if (topSystems != null && topSystems.values.Count > 0)
            {
                List<string> topSystemsList = new List<string>();
                SolarSystem solarSystem = new SolarSystem();
                TreeNode node;
                TreeNode childNode;
                foreach (ZkillTopListsValues systems in topSystems.values)
                {
                    solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == systems.solarSystemID);
                    if (solarSystem != null)
                    {
                        node = new TreeNode();
                        childNode = new TreeNode();

                        node.Text = solarSystem.solarSystemName;
                        node.Expand();

                        childNode = new TreeNode();
                        childNode.Text = "Kills: " + systems.kills;
                        node.Nodes.Add(childNode);

                        childNode = new TreeNode();
                        childNode.Text = "Region: " + solarSystem.regionName;
                        node.Nodes.Add(childNode);

                        KillSystemTreeView.Nodes.Add(node);

                        if (!topRegions.Keys.Contains(solarSystem.regionID))
                        {
                            topRegions.Add(solarSystem.regionID, systems.kills);
                        }
                        else
                        {
                            topRegions[solarSystem.regionID] += systems.kills;
                        }
                    }
                }
            }
            else
            {
                TreeNode node = new TreeNode();
                node.Text = "None";
                KillSystemTreeView.Nodes.Add(node);
            }

            SetTopRegions(topRegions);
        }

        private void SetTopRegions(Dictionary<long, int> topRegions)
        {
            TopRegionsTreeView.Nodes.Clear();
            if (topRegions.Count > 0)
            {
                TreeNode node;
                TreeNode childNode;
                SolarSystem solarSystem;
                foreach (long regionID in topRegions.Keys)
                {
                    solarSystem = CommonHelper.SolarSystemList.Find(x => x.regionID == regionID);
                    node = new TreeNode();
                    childNode = new TreeNode();

                    node.Text = solarSystem.regionName;
                    TopRegionsTreeView.Nodes.Add(node);
                }
            }
            else
            {
                TreeNode node = new TreeNode();
                node.Text = "None";
                TopRegionsTreeView.Nodes.Add(node);
            }
        }

        private void SetTopShips()
        {
            TopShipsTreeView.Nodes.Clear();
            ZkillTopLists topShips = Stats.topLists?.Find(x => x.type.Equals("shipType"));
            if (topShips != null && topShips.values.Count > 0)
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
            else
            {
                TreeNode node = new TreeNode();
                node.Text = "None";
                TopShipsTreeView.Nodes.Add(node);
            }
        }

        private void SetRecentLosses()
        {
            RecentLossesTreeView.Nodes.Clear();

            int max = Math.Min(20, ESI_Losses.Count);
            ESI_KillMail eSI_KillMail;
            Killmail zkillMail;
            TreeNode node;
            TreeNode childNode;
            InventoryType invType;
            bool isCyno = false;
            for (int i = 0; i < max; i++)
            {
                isCyno = false;
                eSI_KillMail = ESI_Losses[i];
                zkillMail = Losses.Find(x => x.killmail_id == eSI_KillMail.killmail_id);

                invType = CommonHelper.InventoryTypes.Find(x => x.typeId == eSI_KillMail.victim.ship_type_id);

                if (invType != null)
                {
                    node = new TreeNode();
                    node.Text = invType.typeName;
                    node.Expand();

                    if (eSI_KillMail.victim.items.Find(
                            x => CynoFieldIDs.Contains(x.item_type_id) ||
                            x.item_type_id == industrialCynoId) != null)
                    {
                        node.ForeColor = Color.MediumVioletRed;
                        node.Text += " : Cyno ship!";
                        isCyno = true;
                    }

                    childNode = new TreeNode();
                    childNode.Text = eSI_KillMail.killmail_time.ToString();
                    node.Nodes.Add(childNode);

                    childNode = new TreeNode();
                    childNode.Text = "ZKill Link";
                    childNode.ForeColor = Color.LightBlue;
                    childNode.Tag = "https://zkillboard.com/kill/" + eSI_KillMail.killmail_id + "/";
                    node.Nodes.Add(childNode);

                    childNode = new TreeNode();
                    childNode.Text = invType.groupName;
                    node.Nodes.Add(childNode);

                    //Cyno being red is more important than "Valuable Kill"
                    if (zkillMail != null && !isCyno)
                    {
                        childNode = new TreeNode();
                        childNode.Text = CommonHelper.FormatIskShortened((decimal)zkillMail.zkb.totalValue);
                        node.Nodes.Add(childNode);

                        if (zkillMail.zkb.totalValue > 1000000000)
                        {
                            node.Text += " : >1B";
                            node.ForeColor = Color.LightGreen;
                        }
                    }

                    RecentLossesTreeView.Nodes.Add(node);
                }
            }

            if (RecentLossesTreeView.Nodes.Count > 0)
            {
                RecentLossesTreeView.SelectedNode = RecentLossesTreeView.Nodes[0];
            }
        }

        private void FindLossesWithCyno()
        {
            LossesWithCynos = ESI_Losses.FindAll(x => x.victim.items?.FindAll(y => CynoFieldIDs.Contains(y.item_type_id))?.Count > 0);
            LossedWithIndyCyno = ESI_Losses.FindAll(x => x.victim.items?.FindAll(y => y.item_type_id == industrialCynoId)?.Count > 0);
        }

        private void LodLossesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Killmail> killmails = LoadZkillLosses();
            List<ESI_KillMail> eSI_KillMails = new List<ESI_KillMail>();
            if (!LoadLossesWorker.CancellationPending)
            {
                eSI_KillMails = LoadESIKillMails(killmails);
            }
            if (killmails == null)
            {
                killmails = new List<Killmail>();
            }
            if (eSI_KillMails == null)
            {
                eSI_KillMails = new List<ESI_KillMail>();
            }
            e.Result = new Tuple<List<Killmail>, List<ESI_KillMail>>(killmails, eSI_KillMails);
        }

        private void SetPvELossLabel()
        {
            int DroneShipsLossCount = 0;
            int MarauderLossCount = 0;
            int edenComLossCount = 0;
            if (ESI_Losses != null)
            {

                foreach (ESI_KillMail killMail in ESI_Losses)
                {
                    if (PvEShips.Contains(killMail.victim.ship_type_id))
                    {
                        DroneShipsLossCount++;
                    }
                    else if (Marauders.Contains(killMail.victim.ship_type_id))
                    {
                        MarauderLossCount++;
                    }
                    else if (Edencom.Contains(killMail.victim.ship_type_id))
                    {
                        edenComLossCount++;
                    }
                }
            }
            PvELossLabel.Text = DroneShipsLossCount.ToString("N0");
            MarauderLossLabel.Text = MarauderLossCount.ToString("N0");
            EdencomLossLabel.Text = edenComLossCount.ToString("N0");
        }

        private List<Killmail> LoadZkillLosses()
        {
            List<Killmail> killmails = ZKill_Calls.Zkill_Calls.LoadCharacterLosses(itemForStats.id);
            return killmails;
        }

        private List<ESI_KillMail> LoadESIKillMails(List<Killmail> killmails)
        {
            return ESI_Calls.ESIKillMail.ConvertZkillToESIKillMails(killmails).Result;
        }

        private void LodLossesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                Tuple<List<Killmail>, List<ESI_KillMail>> killMailResult = (Tuple<List<Killmail>, List<ESI_KillMail>>)(e.Result);
                Losses = killMailResult.Item1;
                ESI_Losses = killMailResult.Item2;
                DatabindScreen();
            }
        }

        private void ZKillLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(ZKillLabel.Text);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void RecentLossesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (RecentLossesTreeView.SelectedNode != null &&
                RecentLossesTreeView.SelectedNode.Tag != null &&
                !string.IsNullOrWhiteSpace(RecentLossesTreeView.SelectedNode.Tag.ToString()))
            {
                string zkillLink = e.Node.Tag.ToString();
                ProcessStartInfo startInfo = new ProcessStartInfo(zkillLink);
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
            }
        }

        private void CorpAllianceBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<string, string> corpAllianceInfo;
            string corp = "", alliance = "";
            if (e.Argument != null && (long)e.Argument > 0)
            {
                Objects.ESI_Objects.ESICharacter esiChar = ESI_Calls.ESICharacter.LoadCharacterForId((long)e.Argument);
                if (esiChar != null && !CorpAllianceBackgroundWorker.CancellationPending)
                {
                    securityStatus = esiChar.SecurityStatus;
                    BirthDate = esiChar.Birthday;
                    if (esiChar.CorporationId > 0)
                    {
                        Objects.ESI_Objects.ESI_Corporation esiCorp = ESI_Calls.ESICorporation.LoadCorporationById(esiChar.CorporationId);
                        if (esiCorp != null)
                        {
                            corp = " > " + esiCorp.Name;
                        }
                    }

                    if (!CorpAllianceBackgroundWorker.CancellationPending && esiChar.AllianceId > 0)
                    {
                        Objects.ESI_Objects.ESI_Alliance esiAlliance = ESI_Calls.ESIAlliance.LoadAllianceById(esiChar.AllianceId);
                        if (esiAlliance != null)
                        {
                            alliance = " > " + esiAlliance.Name;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            corpAllianceInfo = new Tuple<string, string>(corp, alliance);
            e.Result = corpAllianceInfo;
        }

        private void CorpAllianceBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result != null)
            {
                Tuple<string, string> corpAllianceInfo = (Tuple<string, string>)e.Result;
                corpName = corpAllianceInfo.Item1;
                allianceName = corpAllianceInfo.Item2;
                DatabindScreen();
            }
        }
        public (int Years, int Months, int Days) GetDateDifference(DateTime startDate, DateTime endDate)
        {
            // Ensure start date is earlier than end date
            if (startDate > endDate)
            {
                var temp = startDate;
                startDate = endDate;
                endDate = temp;
            }

            // Calculate difference
            int years = endDate.Year - startDate.Year;
            int months = endDate.Month - startDate.Month;
            int days = endDate.Day - startDate.Day;

            // Adjust for negative values
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(endDate.Year, endDate.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return (years, months, days);
        }
    }
}
