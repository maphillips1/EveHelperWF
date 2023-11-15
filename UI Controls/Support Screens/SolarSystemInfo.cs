using EveHelperWF.Database;
using EveHelperWF.Objects;
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
    public partial class SolarSystemInfo : Objects.FormBase
    {
        private List<Planet> planets = new List<Planet>();
        private List<StationInfo> stations = new List<StationInfo>();
        private SolarSystem solarSystem = null;
        private List<SolarSystemJump> solarSystemJumps = new List<SolarSystemJump>();
        private EveHelperWF.Objects.CostIndice costIndice = null;

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

            foreach (SolarSystemJump jump in solarSystemJumps)
            {
                if (jump.isRegional)
                {
                    sb.AppendLine(jump.security.ToString() + " " + jump.solarSystemName + " - Regional");
                }
                else
                {
                    sb.AppendLine(jump.security.ToString() + " " + jump.solarSystemName);
                }

            }
            BorderSystemsListLabel.Text = sb.ToString();
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
    }
}
