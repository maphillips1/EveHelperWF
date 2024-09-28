using EveHelperWF.Database;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using System.Diagnostics;
using System.Text;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class SolarSystemInfo : Objects.FormBase
    {
        private List<Planet> planets = new List<Planet>();
        private List<StationInfo> stations = new List<StationInfo>();
        private SolarSystem solarSystem = null;
        private List<SolarSystemJump> solarSystemJumps = new List<SolarSystemJump>();
        private EveHelperWF.Objects.CostIndice costIndice = null;

        #region "Init"
        public SolarSystemInfo(SolarSystem passedInSystem)
        {
            InitializeComponent();
            solarSystem = passedInSystem;

            if (passedInSystem.solarSystemID > 0)
            {
                GetPlanets(passedInSystem.solarSystemID);
                GetStations(passedInSystem.solarSystemID);
                GetStargates(passedInSystem.solarSystemID);
                GetBeltCount(passedInSystem.solarSystemID);
                GetMoonCount(passedInSystem.solarSystemID);
                GetCostIndice(passedInSystem.solarSystemID);
                SetSystemInfo();
            }
        }

        private void GetPlanets(int solarSystemID)
        {
            planets = SQLiteCalls.GetPlanetsForSystem(solarSystemID);

            BuildPlanetsLabel();
        }

        private void GetStations(int solarSystemID)
        {
            stations = SQLiteCalls.GetStationsForSystem(solarSystemID);

            BuildStationsLabel();
        }

        private void GetStargates(int solarSystemID)
        {
            solarSystemJumps = SQLiteCalls.GetSolarSystemJumps(solarSystemID);

            BuildJumpLabel();
        }

        private void GetBeltCount(int solarSystemID)
        {
            int beltCount = SQLiteCalls.GetAsteroidBeltCount(solarSystemID);

            NumBeltsLabel.Text = "Number of Asteroid Belts : " + beltCount.ToString();
        }

        private void GetMoonCount(int solarSystemID)
        {
            int moonCount = SQLiteCalls.GetMoonCount(solarSystemID);

            MoonCountLabel.Text = "Number of Moons : " + moonCount.ToString();
        }

        private void GetCostIndice(int solarSystemID)
        {
            costIndice = ESI_Calls.ESIIndustry.GetCostIndicesForSystem(solarSystemID);

            BuildCostIndiceLabel();
        }
        #endregion

        #region "Events"
        private void ZKillLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string zKillURL = String.Format("https://zkillboard.com/system/{0}/", solarSystem.solarSystemID);
            ProcessStartInfo startInfo = new ProcessStartInfo(zKillURL);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void DotlanLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string dotLanURL = String.Format("https://evemaps.dotlan.net/system/{0}/", solarSystem.solarSystemName);
            ProcessStartInfo startInfo = new ProcessStartInfo(dotLanURL);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
        #endregion

        #region "Methods"
        private void BuildPlanetsLabel()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Planet planet in planets)
            {
                sb.AppendLine(planet.itemName + " - " + planet.typeName);
            }

            PlanetListLabel.Text = sb.ToString();
            PlanetsLabel.Text = "Planets (" + planets.Count.ToString() + ")";
        }

        private void BuildStationsLabel()
        {
            StringBuilder sb = new StringBuilder();
            foreach (StationInfo station in stations)
            {
                sb.AppendLine(station.factionName + " - " + station.stationName);
            }

            StationsListLabel.Text = sb.ToString();
            StationsLabel.Text = "Stations (" + stations.Count().ToString() + ")";
        }

        private void SetSystemInfo()
        {

            SolarSystemNameLabel.Text = solarSystem.solarSystemName;
            ConstellationLabel.Text = "Constellation: " + solarSystem.constellationName;
            RegionLabel.Text = "Region : " + solarSystem.regionName;
            SecurityLabel.Text = "Security: " + Math.Round(solarSystem.security, 1).ToString();
            FactionLabel.Text = SQLiteCalls.GetSolarSystemFaction(solarSystem.solarSystemID);
            ZKillLabel.Text = "ZKillboard";
            DotlanLabel.Text = "Dotlan";
        }

        private void BuildJumpLabel()
        {
            StringBuilder sb = new StringBuilder();

            LinkLabel systemLinkLabel = null;
            SolarSystem borderSystem = null;
            string linkText = "";
            int currentY = 10;
            foreach (SolarSystemJump jump in solarSystemJumps)
            {
                if (jump.isRegional)
                {
                    linkText = (jump.security.ToString() + " " + jump.solarSystemName + " - Regional");
                }
                else
                {
                    linkText = (jump.security.ToString() + " " + jump.solarSystemName);
                }

                systemLinkLabel = new LinkLabel();

                borderSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == jump.toSolarSystemId);
                if (borderSystem != null)
                {
                    switch (Math.Round(borderSystem.security, 1))
                    {
                        case decimal n when n < (decimal)(0.1):
                            systemLinkLabel.LinkColor = Color.IndianRed;
                            break;
                        case decimal n when n < (decimal)(0.5) && n > (decimal)(0.0):
                            systemLinkLabel.LinkColor = Color.DarkOrange;
                            break;
                        default:
                            systemLinkLabel.LinkColor = Color.Green;
                            break;
                    }
                }
                systemLinkLabel.Text = linkText;
                systemLinkLabel.Tag = jump.toSolarSystemId;
                systemLinkLabel.Click += new EventHandler(SolarSystemLinkClicked);
                systemLinkLabel.Location = new Point(10, currentY);
                currentY += 20;
                BorderingSystemsPanel.Controls.Add(systemLinkLabel);
            }
        }

        private void BuildCostIndiceLabel()
        {
            StringBuilder sb = new StringBuilder();

            if (costIndice != null && costIndice.cost_indices != null)
            {
                foreach (CostIndiceActivity indiceActivity in costIndice.cost_indices)
                {
                    sb.AppendLine(indiceActivity.activity + " - " + String.Format("{0:P2}.", indiceActivity.cost_index));

                }
            }
            SystemCostIndexLabel.Text = sb.ToString();
        }

        private void SolarSystemLinkClicked(object sender, EventArgs e)
        {
            LinkLabel linkLabel = (LinkLabel) sender;
            if (linkLabel.Tag != null)
            {
                long solarSystemId = (long)(linkLabel.Tag);
                if (solarSystemId > 0)
                {
                    SolarSystemInfo borderInfo = new SolarSystemInfo(CommonHelper.SolarSystemList.Find(x => x.solarSystemID == solarSystemId)); ;
                    borderInfo.StartPosition = FormStartPosition.CenterParent;
                    borderInfo.Show();
                }
            }
        }
        #endregion
    }
}
