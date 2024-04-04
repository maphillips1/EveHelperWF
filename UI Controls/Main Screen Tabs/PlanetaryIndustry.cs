using EveHelperWF.Database;
using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EveHelperWF
{
    public partial class PlanetaryIndustry : Objects.FormBase
    {

        private List<PlanetMaterial> planetOutputTypes = new List<PlanetMaterial>();
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private PlanetMaterial SelectedType;
        private List<PlanetMaterial> RawResources = new List<PlanetMaterial>();
        #region "Init"
        public PlanetaryIndustry()
        {
            PlanetSchematicsHelper.Init();
            InitializeComponent();
            int maxHeight = Screen.PrimaryScreen.Bounds.Height;
            int maxWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Width = maxWidth - 100;
            this.Height = maxHeight - 200;
            OutputTreeView.Height = this.Height - 70;
            BubbleTreePanel.Height = this.Height - 200;
            LoadSchematics();
            BuildTreeview();
        }

        private void LoadSchematics()
        {
            planetOutputTypes = ScreenHelper.PlanetSchematicsHelper.GetAllOutputs();
        }

        private void BuildTreeview()
        {
            OutputTreeView.Nodes.Clear();

            Dictionary<int, string> mainGroups = new Dictionary<int, string>();
            List<TreeNode> mainNodes = new List<TreeNode>();

            TreeNode tempTreeNode = null;
            TreeNode parentTreeNode = null;
            foreach (PlanetMaterial outputType in planetOutputTypes)
            {
                if (!mainGroups.Keys.Contains(outputType.groupID))
                {
                    mainGroups.Add(outputType.groupID, outputType.groupName);
                    tempTreeNode = new TreeNode();
                    tempTreeNode.Text = outputType.groupName;
                    tempTreeNode.Tag = "groupID_" + outputType.groupID.ToString();
                    mainNodes.Add(tempTreeNode);
                }

                parentTreeNode = mainNodes.First(x => (string)x.Tag == "groupID_" + outputType.groupID.ToString());
                if (parentTreeNode != null)
                {
                    tempTreeNode = new TreeNode();
                    tempTreeNode.Text = outputType.typeName;
                    tempTreeNode.Tag = "typeID_" + outputType.typeID.ToString();
                    parentTreeNode.Nodes.Add(tempTreeNode);
                }
            }

            OutputTreeView.Nodes.AddRange(mainNodes.ToArray());
            OutputTreeView.Sort();
        }
        #endregion

        #region "Events"
        private void OutputTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (OutputTreeView.SelectedNode != null && e.Action != TreeViewAction.Unknown)
            {
                TreeNode selectedNode = OutputTreeView.SelectedNode;
                if (selectedNode.Tag.ToString().StartsWith("typeID"))
                {
                    if (GetPricesBackgroundWorker.IsBusy)
                    {
                        GetPricesBackgroundWorker.CancelAsync();
                        _resetEvent.WaitOne();
                    }
                    int typeID = 0;
                    typeID = Convert.ToInt32(selectedNode.Tag.ToString().Split("_")[1]);
                    PlanetMaterial selectedOutput = planetOutputTypes.First(x => x.typeID == typeID);
                    LoadDetails(selectedOutput);

                    if (!PIOutputImageWorker.IsBusy)
                    {
                        PIOutputImageWorker.RunWorkerAsync(argument: typeID);
                    }
                }
            }
        }

        private void PlanetPlanner_Resize(object sender, EventArgs e)
        {
            OutputTreeView.Height = this.Height - 70;
            BubbleTreePanel.Height = this.Height - 200;
            if (this.SelectedType != null)
            {
                BuildInputScreen(this.SelectedType);
            }
        }

        private void SolarSystemSearchButton_Click(object sender, EventArgs e)
        {
            SystemFinder planetSystemFinder = new SystemFinder();
            planetSystemFinder.Show();
        }
        #endregion

        #region "Helper Methods"
        private void LoadDetails(PlanetMaterial selectedType)
        {
            SchematicNameLabel.Text = selectedType.typeName;
            TimeSpan cycleTime = TimeSpan.FromSeconds(selectedType.cycleTime);
            CycleTimeLabel.Text = String.Format("{0} H : {1} mm", cycleTime.Hours, cycleTime.Minutes);
            OutputQuantLabel.Text = selectedType.quantity.ToString();
            OutputVolumeLabel.Text = (selectedType.volume * selectedType.quantity).ToString();

            PlanetSchematicsHelper.GetInputsForSchematicRecurseive(selectedType);
            BuildInputScreen(selectedType);
            SetPerfectPlanetsLabel(selectedType);

            SetPriceLabelLoad();
            if (!GetPricesBackgroundWorker.IsBusy)
            {
                GetPricesBackgroundWorker.RunWorkerAsync(argument: selectedType);
            }
            this.SelectedType = selectedType;
        }


        private void BuildInputScreen(PlanetMaterial selectedType)
        {
            System.Windows.Forms.Control.ControlCollection controls = BubbleTreePanel.Controls;
            EventHandlerList eventHandlerList = null;
            foreach (Control item in controls)
            {
                eventHandlerList =
                        (EventHandlerList)typeof(Control).GetProperty(
                            "Events",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(item, null);
                if (eventHandlerList != null)
                {
                    typeof(EventHandlerList).GetMethod("Dispose").Invoke(eventHandlerList, null);
                }
                item.Dispose();
            }
            System.GC.Collect();
            BubbleTreePanel.Controls.Clear();
            int verticalMiddle = (int)Math.Floor((decimal)(BubbleTreePanel.Height / 2));
            Label outputTextBox = BuildPlanetItemTextbox(selectedType);
            outputTextBox.Location = new Point(10, verticalMiddle);
            BubbleTreePanel.Controls.Add(outputTextBox);
            UniqueResourcesLabel.Text = "";
            RawResources.Clear();

            BuildInputScreenRecursive(selectedType, 220, 0, BubbleTreePanel.Height);

            StringBuilder uniqueRSSSB = new StringBuilder();
            foreach (PlanetMaterial rawRSS in RawResources)
            {
                uniqueRSSSB.AppendLine(rawRSS.typeName);
            }
            UniqueResourcesLabel.Text = uniqueRSSSB.ToString();
        }

        private void BuildInputScreenRecursive(PlanetMaterial selectedType, int currentXAxisPoint, int minY, int maxY)
        {

            int heightPerInput = (int)Math.Floor((decimal)((maxY - minY) / selectedType.Inputs.Count));

            int currentVertMidPoint = (int)Math.Floor((decimal)((maxY - minY) / 2));

            Label inputTextBox = null;
            int currentY = minY;
            foreach (PlanetMaterial input in selectedType.Inputs)
            {
                inputTextBox = BuildPlanetItemTextbox(input);
                inputTextBox.Location = new Point(currentXAxisPoint, currentY + (heightPerInput / 2));
                BubbleTreePanel.Controls.Add(inputTextBox);
                if (input.Inputs.Count > 0)
                {
                    BuildInputScreenRecursive(input, currentXAxisPoint + 210, currentY, currentY + heightPerInput);
                }
                else
                {
                    inputTextBox = BuildT0PlanetType(input);
                    inputTextBox.Location = new Point(currentXAxisPoint + 210, currentY + (heightPerInput / 2));
                    BubbleTreePanel.Controls.Add(inputTextBox);
                    if (RawResources.Find(x => x.typeID == input.typeID) == null)
                    {
                        RawResources.Add(input);
                    }
                }
                currentY += heightPerInput;
            }
        }

        private Label BuildPlanetItemTextbox(PlanetMaterial type)
        {
            Label outputTextBox = new Label();
            StringBuilder sb = new StringBuilder();
            string level = PlanetSchematicsHelper.GetLevelFromGroupName(type.groupName);
            sb.AppendLine(level + " - " + type.typeName);

            outputTextBox.Text = sb.ToString();
            //outputTextBox.Multiline = true;
            //outputTextBox.ReadOnly = true;
            outputTextBox.Width = 200;
            outputTextBox.Height = 40;
            outputTextBox.Anchor = AnchorStyles.Top;
            outputTextBox.BorderStyle = BorderStyle.FixedSingle;
            switch (type.groupID)
            {
                case (int)Enums.Enums.PlanetMatTierGroupId.T0_Gas:
                    outputTextBox.BackColor = System.Drawing.Color.AntiqueWhite;
                    outputTextBox.ForeColor = System.Drawing.Color.Black;
                    break;
                case (int)Enums.Enums.PlanetMatTierGroupId.T0_Solid:
                    outputTextBox.BackColor = System.Drawing.Color.AntiqueWhite;
                    outputTextBox.ForeColor = System.Drawing.Color.Black;
                    break;
                case (int)Enums.Enums.PlanetMatTierGroupId.T0_Organic:
                    outputTextBox.BackColor = System.Drawing.Color.AntiqueWhite;
                    outputTextBox.ForeColor = System.Drawing.Color.Black;
                    break;
                case (int)Enums.Enums.PlanetMatTierGroupId.T1:
                    outputTextBox.BackColor = System.Drawing.Color.OrangeRed;
                    outputTextBox.ForeColor = System.Drawing.Color.White;
                    break;
                case (int)Enums.Enums.PlanetMatTierGroupId.T2:
                    outputTextBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    outputTextBox.ForeColor = System.Drawing.Color.Black;
                    break;
                case (int)Enums.Enums.PlanetMatTierGroupId.T3:
                    outputTextBox.BackColor = System.Drawing.Color.LightGreen;
                    outputTextBox.ForeColor = System.Drawing.Color.Black;
                    break;
                case (int)Enums.Enums.PlanetMatTierGroupId.T4:
                    outputTextBox.BackColor = System.Drawing.Color.Green;
                    outputTextBox.ForeColor = System.Drawing.Color.Black;
                    break;
            }
            return outputTextBox;
        }

        private Label BuildT0PlanetType(PlanetMaterial type)
        {
            Label planetType = new Label();
            string level = PlanetSchematicsHelper.GetLevelFromGroupName(type.groupName);

            //outputTextBox.Multiline = true;
            //outputTextBox.ReadOnly = true;
            planetType.Width = 200;
            planetType.Height = 40;
            planetType.Anchor = AnchorStyles.Top;
            planetType.BorderStyle = BorderStyle.FixedSingle;
            planetType.BackColor = System.Drawing.Color.LightGray;
            planetType.ForeColor = System.Drawing.Color.Black;

            planetType.Text = String.Join(", ", PlanetSchematicsHelper.PlanetsForTypeID[type.typeID]);
            return planetType;
        }

        private void GetPricesForAllItemsRecursive(PlanetMaterial selectedType, List<PlanetMaterial> inputs)
        {
            if (!GetPricesBackgroundWorker.CancellationPending)
            {
                ScreenHelper.PlanetSchematicsHelper.GetPrices(selectedType);
                if (inputs != null)
                {
                    foreach (PlanetMaterial input in inputs)
                    {
                        ScreenHelper.PlanetSchematicsHelper.GetPrices(input);
                    }
                }
            }
        }

        private void SetPricesOnScreen(PlanetMaterial selectedType, List<PlanetMaterial> inputs)
        {
            SellPriceTotalLabel.Text = selectedType.sellPriceTotal.ToString("C");

            decimal inputSellTotal = 0;
            foreach (PlanetMaterial input in inputs)
            {
                inputSellTotal += input.sellPriceTotal;
            }
            InputSellTotalLabel.Text = inputSellTotal.ToString("C");


            BuyPriceTotalLabel.Text = selectedType.buyPriceTotal.ToString("C");
            decimal inputBuyTotal = 0;
            foreach (PlanetMaterial input in inputs)
            {
                inputBuyTotal += input.buyPriceTotal;
            }
            InputBuyTotalLabel.Text = inputBuyTotal.ToString("C");
        }

        private void SetPriceLabelLoad()
        {
            SellPriceTotalLabel.Text = "Loading..";
            InputSellTotalLabel.Text = "Loading..";

            BuyPriceTotalLabel.Text = "Loading..";
            InputBuyTotalLabel.Text = "Loading..";
        }

        private void SetPerfectPlanetsLabel(PlanetMaterial selectedType)
        {
            StringBuilder labelBuilder = new StringBuilder();
            List<string> perfectPlanets = PlanetSchematicsHelper.GetPerfectPlanetsForType(selectedType);
            foreach (string planet in perfectPlanets)
            {
                labelBuilder.AppendLine(planet);
            }
            PerfectPlanetsListLabel.Text = labelBuilder.ToString();
        }
        #endregion

        #region "BackgroundWorker"
        private void GetPricesBackgroundWorker_DoWork(Object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                PlanetMaterial selectedType = (PlanetMaterial)e.Argument;

                GetPricesForAllItemsRecursive(selectedType, selectedType.Inputs);

                e.Result = selectedType;
                _resetEvent.Set();
            }
        }
        private void GetPricesBackgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            // check error, check cancel, then use result
            if (e.Error != null)
            {
                // handle the error
            }
            else if (e.Cancelled)
            {
                _resetEvent.Set();
            }
            else
            {
                if (e.Result != null)
                {
                    PlanetMaterial selectedType = (PlanetMaterial)(e.Result);
                    SetPricesOnScreen(selectedType, selectedType.Inputs);
                }
            }
        }

        private void PIOutputImageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[]? image = null;

            int typeID = (int)(e.Argument);

            if (typeID > 0)
            {
                image = ESIImageServer.GetImageForType(typeID, "icon");
            }

            e.Result = image;
        }

        private void PIOutputImageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            byte[] imag = null;
            if (e.Result != null)
            {
                imag = (byte[])e.Result;
            }
            bool imageSet = false;

            if (imag != null)
            {
                MemoryStream memStream = new MemoryStream();
                memStream.Write(imag, 0, imag.Length);
                PIOutputImagePanel.BackgroundImage = Image.FromStream(memStream);
                imageSet = true;
            }

            if (!imageSet)
            {
                PIOutputImagePanel.BackgroundImage = null;
            }
        }

        #endregion
    }
}
