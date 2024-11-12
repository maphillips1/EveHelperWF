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
        List<Killmail> Kills = new List<Killmail>();
        List<ESI_KillMail> ESI_Kills = new List<ESI_KillMail>();
        List<Killmail> Losses = new List<Killmail>();
        List<ESI_KillMail> ESI_Losses = new List<ESI_KillMail>();

        List<long> CynoFieldIDs = new List<long>() { 28646, 21096  };
        long industrialCynoId = 52694;



        List<ESI_KillMail> killsWIthCynos = new List<ESI_KillMail>();
        List<ESI_KillMail> LossedWithIndyCyno = new List<ESI_KillMail>();
        List<ESI_KillMail> KillsWithShipsCynoCapable = new List<ESI_KillMail>();

        public HunterIntelCharacterStats(UniverseIdSearchResultItem characterResult)
        {
            InitializeComponent();
            itemForStats = characterResult;
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
            LoadZkillKills();
            LoadZkillLosses();
            ConvertZkillMailsToESIKillMails();
            DatabindScreen();
        }

        private void LoadZkillKills()
        {
            List<Killmail> killmails = ZKill_Calls.Zkill_Calls.LoadCharacterKills(itemForStats.id);
            if (killmails != null)
            {
                Kills = killmails;
            }
        }

        private void LoadZkillLosses()
        {
            List<Killmail> killmails = ZKill_Calls.Zkill_Calls.LoadCharacterLosses(itemForStats.id);
            if (killmails != null)
            {
                Losses = killmails;
            }
        }

        private void ConvertZkillMailsToESIKillMails()
        {
            if (!ConvertZkillBackgroundWorker.IsBusy)
            {
                ConvertZkillBackgroundWorker.RunWorkerAsync();
            }
        }

        private void DatabindScreen()
        {
            NameLabel.Text = itemForStats.name;
            KillCountLabel.Text = Kills.Count.ToString("N0");
            LossCountLabel.Text = Losses.Count.ToString("N0");

            double destroyedValue = 0;
            Kills.ForEach(x => destroyedValue += x.zkb.totalValue);

            double LostValue = 0;
            Losses.ForEach(x => LostValue += x.zkb.totalValue);

            DestroyedValueLabel.Text = CommonHelper.FormatIskShortened((decimal)destroyedValue);
            LostValueLabel.Text = CommonHelper.FormatIskShortened((decimal)LostValue);

            if (killsWIthCynos.Count == 0 && LossedWithIndyCyno.Count > 0)
            {
                IsCynoPilotLabel.Text = "True, Industrial Only";
            }
            else
            {
                IsCynoPilotLabel.Text = (killsWIthCynos?.Count > 0).ToString();
            }

        }

        private void ConvertZkillBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<List<ESI_KillMail>, List<ESI_KillMail>> result = null;

            List<ESI_KillMail> convertedKills = ESI_Calls.ESIKillMail.ConvertZkillToESIKillMails(Kills).Result;
            List<ESI_KillMail> convertedLosses = null;
            if (!ConvertZkillBackgroundWorker.CancellationPending)
            {
                convertedLosses = ESI_Calls.ESIKillMail.ConvertZkillToESIKillMails(Losses).Result;
            }
            e.Result = new Tuple<List<ESI_KillMail>, List<ESI_KillMail>>(convertedKills, convertedLosses);
        }

        private void ConvertZkillBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            Tuple<List<ESI_KillMail>, List<ESI_KillMail>> result = (Tuple<List<ESI_KillMail>, List<ESI_KillMail>>)e.Result;

            if (result.Item1 != null)
            {
                ESI_Kills.AddRange(result.Item1);
            }
            if (result.Item2 != null)
            {
                ESI_Losses.AddRange(result.Item2);
            }
            FindKillsWithCyno();

            DatabindScreen();
        }

        private void FindKillsWithCyno()
        {
            killsWIthCynos = ESI_Losses.FindAll(x => x.victim.items?.FindAll(y => CynoFieldIDs.Contains(y.item_type_id))?.Count > 0);
            LossedWithIndyCyno = ESI_Losses.FindAll(x => x.victim.items?.FindAll(y => y.item_type_id == industrialCynoId)?.Count > 0);
        }
    }
}
