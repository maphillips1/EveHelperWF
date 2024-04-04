using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using System.ComponentModel;
using System.Data;
using System.IO.Pipes;
using System.Text;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class BuildPlansControl : Objects.FormBase
    {
        private BuildPlan currentBuildPlan;
        private BindingList<ComboListItem> FileComboItems = new BindingList<ComboListItem>();
        string[] FileNames;
        string CurrentFileName;
        private InventoryType FinalProductType;
        private bool m_isLoading = false;
        private bool isLoading
        {
            get
            {
                return m_isLoading;
            }
            set
            {
                m_isLoading = value;
            }
        }
        private List<Control> DetailFlowsControls = new List<Control>();
        private OptimizedBuildDetailsControl DetailsControl;
        private bool PriceInfoSet = true;
        private List<PlanetMaterial> UniquePlanetMaterials;
        private decimal FinalProductSellOrderPrice;
        private decimal FinalProductBuyOrderPrice;

        //Material List
        private static List<Objects.MaterialsWithMarketData> MaterialList = null;

        #region "Init"
        public BuildPlansControl()
        {
            isLoading = true;
            InitializeComponent();
            BlueprintBrowserHelper.Init();
            LoadIndySettingCombos();
            LoadControl();
            isLoading = false;
        }

        public BuildPlansControl(BuildPlan buildPlan)
        {
            isLoading = true;
            InitializeComponent();
            this.currentBuildPlan = buildPlan;
            SaveBuildPlan();
            BlueprintBrowserHelper.Init();
            LoadIndySettingCombos();
            LoadControl();
            ComboListItem comboListItem = FileComboItems.ToList().Find(x => x.value.Contains(buildPlan.BuildPlanName.Replace(".json", "")));
            if (comboListItem != null)
            {
                BuildPlanCombo.SelectedValue = comboListItem.key;
            }
            isLoading = false;
        }
        #endregion

        #region "Events"

        private void BuildPlanCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                LoadBuildPlanFromFile();
                LoadUIForBuildPlan();
                this.Cursor = Cursors.Default;
                isLoading = false;
            }
        }

        private void SaveNotesButton_Click(object sender, EventArgs e)
        {
            if (currentBuildPlan != null)
            {
                this.currentBuildPlan.BuildPlanNotes = NotesTextBox.Text;
                SaveBuildPlan();
                MessageBox.Show("Saved!", "Saved");
            }
        }

        private void DeleteBuildPlanButton_Click(object sender, EventArgs e)
        {
            if (currentBuildPlan != null && !string.IsNullOrWhiteSpace(CurrentFileName))
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    currentBuildPlan = null;
                    FileIO.FileHelper.DeleteFile(Enums.Enums.BuildPlanDirectory, CurrentFileName);
                    LoadControl();
                }
            }
        }

        private void NewBuildPlanButton_Click(object sender, EventArgs e)
        {
            AddBuildPlanScreen addBuildPlanScreen = new AddBuildPlanScreen();
            addBuildPlanScreen.StartPosition = FormStartPosition.CenterScreen;

            if (addBuildPlanScreen.ShowDialog() == DialogResult.OK)
            {
                this.currentBuildPlan = new BuildPlan();
                this.currentBuildPlan.BuildPlanName = addBuildPlanScreen.PlanNameTextBox.Text + ".json";
                this.currentBuildPlan.finalProductTypeID = (Int32)addBuildPlanScreen.ProductCombo.SelectedValue;
                this.currentBuildPlan.RunsPerCopy = 1;
                this.currentBuildPlan.NumOfCopies = 1;
                SaveBuildPlan();
                LoadFileCombo();
                ComboListItem comboListItem = FileComboItems.ToList().Find(x => x.value.Contains(addBuildPlanScreen.PlanNameTextBox.Text));
                if (comboListItem != null)
                {
                    BuildPlanCombo.SelectedValue = comboListItem.key;
                }
            }
        }

        private void BuildPlansControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                SaveBuildPlan();
            }
        }

        private void RunsPerCopy_Leave(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                this.currentBuildPlan.RunsPerCopy = (Int32)(RunsPerCopyUpDown.Value);
                this.currentBuildPlan.IndustrySettings.Runs = (Int32)RunsPerCopyUpDown.Value;
                SaveBuildPlan();
                RunCalcs();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void NumCopies_Leave(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                this.currentBuildPlan.NumOfCopies = (Int32)(NumberCopiesUpDown.Value);
                this.currentBuildPlan.IndustrySettings.NumCopies = (Int32)NumberCopiesUpDown.Value;
                SaveBuildPlan();
                RunCalcs();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            CopyInputsToClipboard();
        }

        private void Numeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                if (numericUpDown.Minimum < 0)
                {
                    numericUpDown.Value = 0;
                }
                else
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                }
                //TODO: Recalc BP Cost Totals, but don't redo entire Calcs
            }
        }

        private void AdditionalCostsNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.currentBuildPlan.additionalCosts = (decimal)AdditionalCostsNumeric.Value;
                OptimizedBuild optimizedBuild = this.currentBuildPlan.OptimizedBuilds.Find(x => x.BuiltOrReactedTypeId == FinalProductType.typeId);
                if (optimizedBuild != null)
                {
                    optimizedBuild.AdditionalCost = this.currentBuildPlan.additionalCosts;
                    optimizedBuild.TotalBuildCost = optimizedBuild.MaterialCost + optimizedBuild.JobCost + optimizedBuild.AdditionalCost;
                    optimizedBuild.PricePerItem = (optimizedBuild.TotalBuildCost / optimizedBuild.RunsNeeded);
                    SetSummaryInformation();
                }
                SaveBuildPlan();
                this.isLoading = false;
                //TODO: Recalc BP Cost Totals, but don't redo entire Calcs
            }
        }

        private void IndustrySettings_ValueChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                SaveIndustrySettings();
                SaveBuildPlan();
                RunCalcs();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void CollapseAll_Click(object sender, EventArgs e)
        {
            MaterialsTreeView.CollapseAll();
        }

        private void OptimizedBuildTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Action != TreeViewAction.Unknown)
            {
                int optimizedTypeId = Convert.ToInt32(e.Node.Tag);
                if (optimizedTypeId > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (!PriceInfoSet)
                    {
                        int waitCount = 0;
                        while (!PriceInfoSet && waitCount < 10)
                        {
                            //wait until price info is set
                            Thread.Sleep(500);
                            waitCount++;
                        }
                    }
                    OptimizedBuild optimizedBuild = this.currentBuildPlan.OptimizedBuilds.Find(x => x.BuiltOrReactedTypeId == optimizedTypeId);
                    if (optimizedBuild != null)
                    {
                        DetailsControl = new OptimizedBuildDetailsControl(optimizedBuild);
                        DetailsControl.ShowDialog();
                    }
                    this.Cursor = Cursors.Default;
                    OptimizedBuildTreeView.SelectedNode = null;
                }
            }
        }

        private void InputOrderTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.currentBuildPlan.IndustrySettings.InputOrderType = Convert.ToInt32(InputOrderTypeCombo.SelectedValue);
                RunCalcs();
            }
        }

        private void OutputOrderTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.currentBuildPlan.IndustrySettings.OutputOrderType = Convert.ToInt32(OutputOrderTypeCombo.SelectedValue);
                RunCalcs();
            }
        }

        private void UpdatePricesJitaButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                List<MaterialsWithMarketData> mats = this.currentBuildPlan.AllItems;
                int totalMats = mats.Count;
                int currentMat = 1;
                decimal progress;
                foreach (MaterialsWithMarketData mat in mats)
                {
                    progress = (decimal)currentMat / (decimal)totalMats;
                    ProgressLabel.Text = "Getting Market Data... " + progress.ToString("P");
                    mat.pricePer = ESIMarketData.GetSellOrderPrice(mat.materialTypeID, Enums.Enums.TheForgeRegionId);
                    currentMat++;

                }
                ProgressLabel.Text = "Done.";
                BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.finalProductTypeID,
                                                                     this.currentBuildPlan.additionalCosts,
                                                                     this.currentBuildPlan);
                SetSummaryInformation();
                LoadMaterialsPriceTreeView();
                ProgressLabel.Text = "";
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void MaterialsPriceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!isLoading && e.Node.Tag != null && e.Action != TreeViewAction.Unknown)
            {
                this.isLoading = true;
                int typeID = Convert.ToInt32(e.Node.Tag);
                List<MaterialsWithMarketData> mats = this.currentBuildPlan.AllItems;
                MaterialsWithMarketData currentMat = mats.Find(x => x.materialTypeID == typeID);

                SetPriceControl spc = new SetPriceControl(currentMat.pricePer);
                spc.StartPosition = FormStartPosition.CenterScreen;
                if (spc.ShowDialog() == DialogResult.OK)
                {
                    decimal price = (decimal)(spc.PricePerItem.Value);
                    currentMat.pricePer = price;
                    BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds, mats, this.currentBuildPlan.finalProductTypeID, this.currentBuildPlan.additionalCosts, this.currentBuildPlan);
                    SaveBuildPlan();
                    SetSummaryInformation();
                    LoadMaterialsPriceTreeView();
                }
                MaterialsPriceTreeView.SelectedNode = null;
                this.isLoading = false;
            }
        }

        private void BPTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading && e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Tag != null)
                {
                    int bpTypeId = Convert.ToInt32(e.Node.Tag);
                    BlueprintInfo bpInfo = this.currentBuildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == bpTypeId);

                    BlueprintValueControl BVC = new BlueprintValueControl(bpInfo);
                    BVC.StartPosition = FormStartPosition.CenterScreen;
                    if (BVC.ShowDialog() == DialogResult.OK)
                    {
                        bpInfo.ME = (int)BVC.MEUpDown.Value;
                        bpInfo.TE = (int)BVC.TEUpDown.Value;
                        bpInfo.MaxRuns = (int)BVC.MaxRunsUpDown.Value;
                        bpInfo.Manufacture = BVC.MakeItemCheckbox.Checked;
                        bpInfo.React = BVC.MakeItemCheckbox.Checked;
                        SaveBuildPlan();
                        isLoading = true;
                        e.Node.Nodes.Clear();
                        TreeNode parentNode = e.Node;
                        BuildChildNodes(bpInfo, ref parentNode);
                        RunCalcs();
                        isLoading = false;
                    }
                    BPTreeView.SelectedNode = null;
                }
            }
        }

        private void SetBlueprintButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                BlueprintInfo bpInfo = new BlueprintInfo();
                bpInfo.IsManufactured = true;
                bpInfo.MaxRuns = 99999;

                BlueprintValueControl BVC = new BlueprintValueControl(bpInfo);
                BVC.StartPosition = FormStartPosition.CenterScreen;
                if (BVC.ShowDialog() == DialogResult.OK)
                {
                    isLoading = true;
                    bpInfo.ME = (int)BVC.MEUpDown.Value;
                    bpInfo.TE = (int)BVC.TEUpDown.Value;
                    bpInfo.MaxRuns = (int)BVC.MaxRunsUpDown.Value;
                    bpInfo.Manufacture = BVC.MakeItemCheckbox.Checked;
                    SetAllBlueprintValues(bpInfo.ME, bpInfo.TE, bpInfo.MaxRuns, bpInfo.Manufacture);
                    SaveBuildPlan();
                    LoadBlueprintStoreTreeView();
                    RunCalcs();
                    isLoading = false;
                }
            }
        }

        private void SetReactionsButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                BlueprintInfo bpInfo = new BlueprintInfo();
                bpInfo.IsReacted = true;
                bpInfo.MaxRuns = 99999;

                BlueprintValueControl BVC = new BlueprintValueControl(bpInfo);
                BVC.StartPosition = FormStartPosition.CenterScreen;
                if (BVC.ShowDialog() == DialogResult.OK)
                {
                    isLoading = true;
                    bpInfo.MaxRuns = (int)BVC.MaxRunsUpDown.Value;
                    SetAllReactionValues(bpInfo.MaxRuns, BVC.MakeItemCheckbox.Checked);
                    SaveBuildPlan();
                    LoadBlueprintStoreTreeView();
                    RunCalcs();
                    isLoading = false;
                }
            }
        }
        #endregion

        #region "Methods"

        private void LoadControl()
        {
            ProgressLabel.Text = "";
            LoadFileCombo();
            LoadUIForBuildPlan();
        }

        private void LoadIndySettingCombos()
        {
            //Solar Systems
            ManufacturingSystemCombo.BindingContext = new BindingContext();
            ManufacturingSystemCombo.DisplayMember = "solarSystemName";
            ManufacturingSystemCombo.ValueMember = "solarSystemID";
            ManufacturingSystemCombo.DataSource = CommonHelper.SolarSystemList;

            List<Objects.SolarSystem> lowAndNullSystems = CommonHelper.SolarSystemList.FindAll(x => Math.Round(x.security, 1) < Convert.ToDecimal(0.5));
            ReactionSolarSystemCombo.BindingContext = new BindingContext();
            ReactionSolarSystemCombo.DisplayMember = "solarSystemName";
            ReactionSolarSystemCombo.ValueMember = "solarSystemID";
            ReactionSolarSystemCombo.DataSource = lowAndNullSystems;

            //Structures
            ManufacturingStructureCombo.BindingContext = new BindingContext();
            ManufacturingStructureCombo.DisplayMember = "value";
            ManufacturingStructureCombo.ValueMember = "key";
            ManufacturingStructureCombo.DataSource = BlueprintBrowserHelper.GetEngineeringStructureItems();

            ReactionStructureCombo.BindingContext = new BindingContext();
            ReactionStructureCombo.DisplayMember = "Value";
            ReactionStructureCombo.ValueMember = "Key";
            ReactionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetRefineryComboItems();

            //Structure Rigs
            ManufacturingStructureMERigCombo.BindingContext = new BindingContext();
            ManufacturingStructureMERigCombo.DisplayMember = "Value";
            ManufacturingStructureMERigCombo.ValueMember = "Key";
            ManufacturingStructureMERigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();

            ManufacturingStructureTERigCombo.BindingContext = new BindingContext();
            ManufacturingStructureTERigCombo.DisplayMember = "Value";
            ManufacturingStructureTERigCombo.ValueMember = "Key";
            ManufacturingStructureTERigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();

            ReactionStructureMERig.BindingContext = new BindingContext();
            ReactionStructureMERig.DisplayMember = "Value";
            ReactionStructureMERig.ValueMember = "Key";
            ReactionStructureMERig.DataSource = CommonHelper.GetStructureBonusComboItems();

            ReactionStructureTERig.BindingContext = new BindingContext();
            ReactionStructureTERig.DisplayMember = "Value";
            ReactionStructureTERig.ValueMember = "Key";
            ReactionStructureTERig.DataSource = CommonHelper.GetStructureBonusComboItems();

            //Implants
            ImplantCombo.BindingContext = new BindingContext();
            ImplantCombo.DisplayMember = "Value";
            ImplantCombo.ValueMember = "Key";
            ImplantCombo.DataSource = BlueprintBrowserHelper.GetManufacturingImplantItems();

            //Orders
            InputOrderTypeCombo.BindingContext = new BindingContext();
            InputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetPriceTypeComboItems();
            InputOrderTypeCombo.DisplayMember = "Value";
            InputOrderTypeCombo.ValueMember = "Key";

            OutputOrderTypeCombo.BindingContext = new BindingContext();
            OutputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetPriceTypeComboItems();
            OutputOrderTypeCombo.DisplayMember = "Value";
            OutputOrderTypeCombo.ValueMember = "Key";
        }

        private void LoadFileCombo()
        {
            FileComboItems.Clear();
            FileComboItems.Add(new ComboListItem { key = 0, value = string.Empty });
            FileNames = FileIO.FileHelper.GetFileNamesInDirectory(Enums.Enums.BuildPlanDirectory);
            if (FileNames.Length > 0)
            {
                string comboName = "";
                int lastSlashIndex;
                int lastDotIndex;
                int count = 1;
                foreach (string file in FileNames)
                {
                    lastSlashIndex = file.LastIndexOf('\\');
                    lastDotIndex = file.LastIndexOf(".");
                    comboName = file.Substring(lastSlashIndex + 1, lastDotIndex - 1 - lastSlashIndex);
                    FileComboItems.Add(new ComboListItem { key = count, value = comboName });
                    count++;
                }
            }
            BuildPlanCombo.ValueMember = "key";
            BuildPlanCombo.DisplayMember = "value";
            BuildPlanCombo.DataSource = FileComboItems;
            BuildPlanCombo.SelectedIndex = 0;
        }

        private void SaveBuildPlan()
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(currentBuildPlan);
            string fullFileName = Enums.Enums.BuildPlanDirectory + currentBuildPlan.BuildPlanName;
            FileIO.FileHelper.SaveFileContent(Enums.Enums.BuildPlanDirectory, fullFileName, content);
        }

        private void LoadBuildPlanFromFile()
        {
            currentBuildPlan = null;
            string selectedFileName = GetSelectedFileName();
            if (!String.IsNullOrWhiteSpace(selectedFileName))
            {
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.BuildPlanDirectory, selectedFileName);
                if (!string.IsNullOrEmpty(content))
                {
                    currentBuildPlan = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.BuildPlan>(content);
                }
            }
        }

        private string GetSelectedFileName()
        {
            if (BuildPlanCombo.SelectedIndex > 0)
            {
                int selectedFile = Convert.ToInt32(BuildPlanCombo.SelectedValue);

                if (selectedFile > 0)
                {
                    ComboListItem comboListItem = FileComboItems.ToList().Find(x => x.key == selectedFile);

                    if (comboListItem != null)
                    {
                        string fileName = FileNames.ToList().Find(x => x.Contains(comboListItem.value));
                        if (!string.IsNullOrWhiteSpace(fileName))
                        {
                            CurrentFileName = fileName;
                            return fileName;
                        }
                    }
                }
            }
            return "";
        }

        private void LoadUIForBuildPlan()
        {
            if (currentBuildPlan != null)
            {
                this.SuspendLayout();
                FinalProductType = CommonHelper.InventoryTypes.Find(x => x.typeId == this.currentBuildPlan.finalProductTypeID);
                //Ensure we have the minimum information to run the calcs
                EnsureCalculationHelperClass();
                EnsureInputMaterials();
                EnsureMinimumRunsAndCopies();
                EnsureBlueprintStore();

                //Load Blueprint Store
                LoadBlueprintStoreTreeView();

                //Run the calcs
                RunCalcs();

                //Load All the info on the screen
                this.ResumeLayout();
            }
            else
            {
                ResetControls();
            }
        }

        private void EnsureMinimumRunsAndCopies()
        {
            //Runs Per Copy minimum
            if (this.currentBuildPlan.RunsPerCopy < RunsPerCopyUpDown.Minimum)
            {
                this.currentBuildPlan.RunsPerCopy = (Int32)RunsPerCopyUpDown.Minimum;
                this.currentBuildPlan.IndustrySettings.RunsPerCopy = this.currentBuildPlan.RunsPerCopy;
                SaveBuildPlan();
            }
            //Num Copies Minimum
            if (this.currentBuildPlan.NumOfCopies < NumberCopiesUpDown.Minimum)
            {
                this.currentBuildPlan.NumOfCopies = (Int32)NumberCopiesUpDown.Minimum;
                this.currentBuildPlan.IndustrySettings.NumCopies = this.currentBuildPlan.NumOfCopies;
                SaveBuildPlan();
            }
        }

        private void EnsureBlueprintStore()
        {
            if (this.currentBuildPlan.BlueprintStore == null)
            {
                this.currentBuildPlan.BlueprintStore = new List<BlueprintInfo>();
            }
            List<BlueprintInfo> bpInfos = this.currentBuildPlan.BlueprintStore;
            if (BuildPlanHelper.BuildBlueprintStore(ref this.currentBuildPlan, currentBuildPlan.InputMaterials))
            {
                SaveBuildPlan();
            }
        }

        private void LoadProductImage()
        {
            if (!LoadProductImageBackgroundWorker.IsBusy)
            {
                LoadProductImageBackgroundWorker.RunWorkerAsync();
            }
        }

        private void LoadBasicInfo()
        {
            if (FinalProductType != null)
            {
                ProductLabel.Text = FinalProductType.typeName;
                NotesTextBox.Text = this.currentBuildPlan.BuildPlanNotes;
                DetailsProductLabel.Text = FinalProductType.typeName + " x " + this.currentBuildPlan.TotalOutcome;
                RunsPerCopyUpDown.Value = this.currentBuildPlan.RunsPerCopy;
                NumberCopiesUpDown.Value = this.currentBuildPlan.NumOfCopies;
                AdditionalCostsNumeric.Value = this.currentBuildPlan.additionalCosts;
                OutcomeQuantityLabel.Text = this.currentBuildPlan.TotalOutcome.ToString("N0");
            }
        }

        private void LoadFinalProductMarketInfo()
        {
            List<ESIPriceHistory> priceHistory = ScreenHelper.MarketBrowserHelper.GetPriceHistoryForRegionAndType(Enums.Enums.TheForgeRegionId, FinalProductType.typeId);
            if (priceHistory != null)
            {
                DatabindGridView<List<ESIPriceHistory>>(PriceHistoryGridView, priceHistory.OrderByDescending(x => x.date).ToList());
            }
            decimal sellOrderPrice = ESIMarketData.GetSellOrderPrice(FinalProductType.typeId, Enums.Enums.TheForgeRegionId);
            decimal buyOrderPrice = ESIMarketData.GetBuyOrderPrice(FinalProductType.typeId, Enums.Enums.TheForgeRegionId);
            JitaSellLabel.Text = CommonHelper.FormatIsk(sellOrderPrice);
            JitaBuyLabel.Text = CommonHelper.FormatIsk(buyOrderPrice);
            FinalProductSellOrderPrice = sellOrderPrice;
            FinalProductBuyOrderPrice = buyOrderPrice;
        }

        private void EnsureInputMaterials()
        {
            //Only Load this infor the first time. 
            //Once it's been loaded once, the build plan controls take over. 
            if (this.currentBuildPlan != null &&
                    (this.currentBuildPlan.InputMaterials == null || this.currentBuildPlan.InputMaterials.Count == 0))
            {
                List<IndustryActivityMaterials> manufacturingMaterials =
                    Database.SQLiteCalls.GetIndustryActivityMaterials(this.currentBuildPlan.parentBlueprintOrReactionTypeID, Enums.Enums.ActivityManufacturing);
                List<IndustryActivityMaterials> reactionMaterials =
                    Database.SQLiteCalls.GetIndustryActivityMaterials(this.currentBuildPlan.parentBlueprintOrReactionTypeID, Enums.Enums.ActivityReactions);

                this.currentBuildPlan.InputMaterials = new List<MaterialsWithMarketData>();

                foreach (IndustryActivityMaterials material in manufacturingMaterials)
                {
                    AddMaterialToInputs(material);

                }
                foreach (IndustryActivityMaterials material in reactionMaterials)
                {
                    AddMaterialToInputs(material);
                }
                SaveBuildPlan();
            }
        }



        private void EnsureCalculationHelperClass()
        {
            if (this.currentBuildPlan != null)
            {
                bool saveBuildPlan = false;
                if (this.currentBuildPlan.IndustrySettings == null)
                {
                    Objects.DefaultFormValue defaultFormValues = LoadDefaultsFromFile();
                    this.currentBuildPlan.IndustrySettings = BuildCalculationHelperClassFromDefaults(defaultFormValues);
                    saveBuildPlan = true;
                }
                if (this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID == 0)
                {
                    this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID = Enums.Enums.JitaSystemId;
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID == 0)
                {
                    this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID = Enums.Enums.OldManStarSystem;
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID == 0)
                {
                    //Athanor
                    this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID = 35835;
                }

                if (this.currentBuildPlan.IndustrySettings.InventionSolarSystemID == 0)
                {
                    this.currentBuildPlan.IndustrySettings.InventionSolarSystemID = Enums.Enums.JitaSystemId;
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.IndustrySettings.CopyingSolarSystemID == 0)
                {
                    this.currentBuildPlan.IndustrySettings.CopyingSolarSystemID = Enums.Enums.JitaSystemId;
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.IndustrySettings.MESolarSystemID == 0)
                {
                    this.currentBuildPlan.IndustrySettings.MESolarSystemID = Enums.Enums.JitaSystemId;
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.IndustrySettings.TESolarSystemID == 0)
                {
                    this.currentBuildPlan.IndustrySettings.TESolarSystemID = Enums.Enums.JitaSystemId;
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.parentBlueprintOrReactionTypeID <= 0)
                {
                    this.currentBuildPlan.parentBlueprintOrReactionTypeID = Database.SQLiteCalls.GetBlueprintByProductTypeID(FinalProductType.typeId);
                    saveBuildPlan = true;
                }

                if (this.currentBuildPlan.IndustrySettings.InputOrderType <= 0)
                {
                    this.currentBuildPlan.IndustrySettings.InputOrderType = (int)Enums.Enums.OrderType.Sell;
                }
                if (this.currentBuildPlan.IndustrySettings.OutputOrderType <= 0)
                {
                    this.currentBuildPlan.IndustrySettings.OutputOrderType = (int)(Enums.Enums.OrderType.Sell);
                }

                if (saveBuildPlan)
                {
                    SaveBuildPlan();
                }
            }

        }

        private Objects.DefaultFormValue LoadDefaultsFromFile()
        {

            string combinedFileName = string.Concat(Enums.Enums.CachedFormValuesDirectory, "form_values.json");
            string content = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedFormValuesDirectory, combinedFileName);
            Objects.DefaultFormValue defaultFormValues = new Objects.DefaultFormValue();
            if (!string.IsNullOrWhiteSpace(content))
            {
                defaultFormValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.DefaultFormValue>(content);
            }
            if (defaultFormValues == null) { defaultFormValues = new Objects.DefaultFormValue(); }
            return defaultFormValues;
        }

        private CalculationHelperClass BuildCalculationHelperClassFromDefaults(Objects.DefaultFormValue defaultFormValues)
        {
            CalculationHelperClass calculationHelperClass = new CalculationHelperClass();

            //Manufacturing Values
            calculationHelperClass.ManufacturingSolarSystemID = defaultFormValues.ManufacturingSystemValue;
            calculationHelperClass.ManufacturingStructureTypeID = defaultFormValues.ManufacturingStructureValue;
            calculationHelperClass.ManufacturingStructureRigBonus = new StructureRigBonus();
            calculationHelperClass.ManufacturingImplantTypeID = defaultFormValues.ManufacturingImplantValue;
            calculationHelperClass.ManufacturingFacilityTax = defaultFormValues.ManufacturingTaxValue;
            calculationHelperClass.ME = (int)defaultFormValues.ManufacturingMEValue;
            calculationHelperClass.TE = (int)defaultFormValues.ManufacturingTEValue;
            calculationHelperClass.CompME = (int)defaultFormValues.CompMEValue;
            calculationHelperClass.CompTE = (int)defaultFormValues.CompTEValue;
            calculationHelperClass.ManufacturingStructureRigBonus.RigMEBonus = defaultFormValues.ManufacturingStructureMERigValue;
            calculationHelperClass.ManufacturingStructureRigBonus.RigTEBonus = defaultFormValues.ManufacturingStructureTERigValue;

            //Reactions Values
            calculationHelperClass.ReactionSolarSystemID = defaultFormValues.ReactionsSystemValue;
            calculationHelperClass.ReactionsStructureTypeID = defaultFormValues.ReactionStructureValue;
            calculationHelperClass.ReactionsFacilityTax = defaultFormValues.ReactionTaxValue;
            calculationHelperClass.ReactionStructureRigBonus = new StructureRigBonus();
            calculationHelperClass.ReactionStructureRigBonus.RigMEBonus = defaultFormValues.ReactionStructureMERigValue;
            calculationHelperClass.ReactionStructureRigBonus.RigTEBonus = defaultFormValues.ReactionStructureTERigValue;

            //Invention Values
            calculationHelperClass.InventBlueprint = defaultFormValues.InventBlueprintValue;
            calculationHelperClass.InventionSolarSystemID = defaultFormValues.InventionSystemValue;
            calculationHelperClass.InventionFacilityTax = defaultFormValues.InventionTaxValue;
            calculationHelperClass.InventionDecryptorId = defaultFormValues.InventionDecryptorValue;
            calculationHelperClass.InventionStructureRigBonus = new StructureRigBonus();
            calculationHelperClass.InventionStructureRigBonus.RigMEBonus = defaultFormValues.InventionStructureCostRigValue;
            calculationHelperClass.InventionStructureRigBonus.RigTEBonus = defaultFormValues.InventionStructureTimeRigValue;

            //Skills
            calculationHelperClass.AccountingSkill = defaultFormValues.AccountingSKill;
            calculationHelperClass.BrokersSkill = defaultFormValues.BrokersSkill;
            return calculationHelperClass;
        }

        private void AddMaterialToInputs(IndustryActivityMaterials material)
        {
            this.currentBuildPlan.InputMaterials.Add(new MaterialsWithMarketData
            {
                materialTypeID = material.materialTypeID,
                materialName = material.materialName,
                Buildable = material.isManufacturable,
                Reactable = material.isReactable,
                quantity = material.quantity,
            });
        }

        private void RunCalcs()
        {
            BuildPlanHelper.CalculateIndustryValues(ref this.currentBuildPlan);
            List<MaterialsWithMarketData> allItems = this.currentBuildPlan.AllItems;
            BuildPlanHelper.BuildAllItems(this.currentBuildPlan.InputMaterials, ref allItems);
            this.currentBuildPlan.AllItems = allItems;
            RunOptimumBuildCalc();
            if (!EnsurePriceData()){
                BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.finalProductTypeID,
                                                                     this.currentBuildPlan.additionalCosts,
                                                                     this.currentBuildPlan);
            }
            LoadUIAfterCalcs();
        }

        private void RunOptimumBuildCalc()
        {
            BuildPlanHelper.DetermineOptimumBuild(this.currentBuildPlan.InputMaterials, this.currentBuildPlan);
            SaveBuildPlan();
        }

        private void ResetControls()
        {
            this.SuspendLayout();

            NotesTextBox.Text = string.Empty;
            ProductLabel.Text = string.Empty;
            DatabindGridView<List<ESIPriceHistory>>(PriceHistoryGridView, new List<ESIPriceHistory>());
            JitaBuyLabel.Text = string.Empty;
            JitaSellLabel.Text = string.Empty;
            FinalProductImagePanel.BackgroundImage = null;
            AdditionalCostsNumeric.Value = AdditionalCostsNumeric.Minimum;
            MaterialsTreeView.Nodes.Clear();
            OptimizedBuildTreeView.Nodes.Clear();
            TotalManufacturingSlotsLabel.Text = string.Empty;
            TotalReactionSlotsLabel.Text = string.Empty;
            MaterialsPriceTreeView.Nodes.Clear();
            OutcomeQuantityLabel.Text = "";
            ProductionCostUnitLabel.Text = "";
            InputVolumeLabel.Text = "";
            OutcomeVolumeLabel.Text = "";
            DetailsProductLabel.Text = "";
            DetailsImagePanel.BackgroundImage = null;
            HeaderCostUnitLabel.Text = "";
            PlanetMaterialsTreeView.Nodes.Clear();
            BPTreeView.Nodes.Clear();
            IskNeededForPlanLabel.Text = "";
            ProfitLabel.Text = "";
            FinalSellPriceNumeric.Value = FinalSellPriceNumeric.Minimum;
            CostBreakdownTextBox.Text = "";
            leftoverMatsValueLabel.Text = "";
            this.ResumeLayout();
        }

        private void CopyInputsToClipboard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
            CombineMatsFromOptimizedBuilds(ref combinedMats, this.currentBuildPlan.OptimizedBuilds);

            foreach (MaterialsWithMarketData mat in combinedMats)
            {
                if (!BuildPlanHelper.IsItemMade(currentBuildPlan.BlueprintStore, mat.materialTypeID))
                {
                    stringBuilder.AppendLine(mat.materialName + " " + mat.quantityTotal);
                }
            }
            Clipboard.SetText(stringBuilder.ToString());
        }

        private void LoadIndySettings()
        {
            if (this.currentBuildPlan != null && this.currentBuildPlan.IndustrySettings != null)
            {
                //Manufacturing
                this.ManufacturingSystemCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID;
                this.ManufacturingStructureCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingStructureTypeID;
                this.ManufacturingStructureMERigCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigMEBonus;
                this.ManufacturingStructureTERigCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigTEBonus;
                this.ManufacturingTaxUpDown.Value = this.currentBuildPlan.IndustrySettings.ManufacturingFacilityTax;
                this.ImplantCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingImplantTypeID;

                //Reactions
                this.ReactionSolarSystemCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID;
                this.ReactionStructureCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID;
                this.ReactionTaxUpDown.Value = this.currentBuildPlan.IndustrySettings.ReactionsFacilityTax;
                this.ReactionStructureMERig.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus;
                this.ReactionStructureTERig.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus;

                //Skills
                this.AccountingLevelUpDown.Value = this.currentBuildPlan.IndustrySettings.AccountingSkill;
                this.BrokerRelationsLevelUpDown.Value = this.currentBuildPlan.IndustrySettings.BrokersSkill;

                //Order Types
                this.InputOrderTypeCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.InputOrderType;
                this.OutputOrderTypeCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.OutputOrderType;
            }
        }

        private void SaveIndustrySettings()
        {
            switch (DefaultsTabContainer.SelectedIndex)
            {
                case 0:
                    this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID = (int)(this.ManufacturingSystemCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID);
                    this.currentBuildPlan.IndustrySettings.ManufacturingStructureTypeID = (Int32)(this.ManufacturingStructureCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingStructureTypeID);
                    this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigMEBonus = (Int32)(this.ManufacturingStructureMERigCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigMEBonus);
                    this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigTEBonus = (Int32)(this.ManufacturingStructureTERigCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigTEBonus);
                    this.currentBuildPlan.IndustrySettings.ManufacturingFacilityTax = (decimal)(this.ManufacturingTaxUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.ManufacturingImplantTypeID = (Int32)(this.ImplantCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingImplantTypeID);

                    break;
                case 1:
                    this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID = (Int32)(this.ReactionSolarSystemCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID);
                    this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID = (Int32)(this.ReactionStructureCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID);
                    this.currentBuildPlan.IndustrySettings.ReactionsFacilityTax = (decimal)this.ReactionTaxUpDown.Value;
                    this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus = (Int32)(this.ReactionStructureMERig.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus);
                    this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus = (Int32)(this.ReactionStructureTERig.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus);

                    break;
                case 2:
                    this.currentBuildPlan.IndustrySettings.AccountingSkill = (Int32)(this.AccountingLevelUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.BrokersSkill = (Int32)(this.BrokerRelationsLevelUpDown.Value);
                    break;
                case 3:
                    this.currentBuildPlan.IndustrySettings.InputOrderType = (Int32)(this.InputOrderTypeCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.InputOrderType);
                    this.currentBuildPlan.IndustrySettings.OutputOrderType = (Int32)(this.InputOrderTypeCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.OutputOrderType);
                    break;
                default:
                    break;
            }
        }

        private void LoadDetailsPage(bool fromBuildReactAllChecked)
        {
            DetailsPage.SuspendLayout();
            if (this.currentBuildPlan != null)
            {
                if (this.currentBuildPlan.InputMaterials != null && this.currentBuildPlan.InputMaterials.Count > 0)
                {
                    BuildIndustryTreeView();
                }
            }
            DetailsPage.ResumeLayout();
        }

        private void BuildIndustryTreeView()
        {
            BuildPlanHelper.SetControlNames(this.currentBuildPlan.InputMaterials);
            MaterialsTreeView.Nodes.Clear();
            MaterialsTreeView.Nodes.AddRange(AddMaterialsToTreeView(this.currentBuildPlan.InputMaterials).ToArray());
        }

        private List<TreeNode> AddMaterialsToTreeView(List<MaterialsWithMarketData> materialsToBind)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            List<MaterialsWithMarketData> orderedList = materialsToBind.OrderBy(x => x.materialName).ToList();
            TreeNode node;
            StringBuilder sb = new StringBuilder();
            foreach (MaterialsWithMarketData inputMaterial in orderedList)
            {
                sb = new StringBuilder();

                node = new TreeNode();
                node.Tag = inputMaterial.controlName;

                sb.Append("  " + inputMaterial.quantityTotal.ToString("N0") + " x " + inputMaterial.materialName);

                if (inputMaterial.Buildable || inputMaterial.Reactable)
                {
                    BlueprintInfo bpInfo = currentBuildPlan.BlueprintStore.Find(x => x.ProductTypeId == inputMaterial.materialTypeID);
                    if (bpInfo != null)
                    {
                        if (bpInfo.Manufacture || bpInfo.React)
                        {
                            node.Expand();
                            if (inputMaterial.ChildMaterials.Count > 0)
                            {
                                sb.Append(" | Runs Needed: " + inputMaterial.RunsNeeded.ToString("N0"));
                                node.Nodes.AddRange(AddMaterialsToTreeView(inputMaterial.ChildMaterials).ToArray());
                            }
                        }
                    }
                }
                node.Text = sb.ToString();
                node.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(inputMaterial);
                nodes.Add(node);
            }
            return nodes;
        }

        private void LoadOptimumBuildSchedule()
        {
            Dictionary<int, List<OptimizedBuild>> optimumBuildGroups = this.currentBuildPlan.OptimumBuildGroups;
            BuildOptimumBuildTreeView(optimumBuildGroups);
            int manufacturingCount = this.currentBuildPlan.OptimizedBuilds.FindAll(x => x.isBuilt).Sum(x => x.BatchesNeeded);
            int reactionCount = this.currentBuildPlan.OptimizedBuilds.FindAll(x => x.isReacted).Sum(x => x.BatchesNeeded);
            TotalManufacturingSlotsLabel.Text = manufacturingCount.ToString("N0");
            TotalReactionSlotsLabel.Text = reactionCount.ToString("N0");
        }

        private void BuildOptimumBuildTreeView(Dictionary<int, List<OptimizedBuild>> optimumBuildGroups)
        {
            OptimizedBuildTreeView.Nodes.Clear();
            if (optimumBuildGroups != null)
            {
                TreeNode keyNode;
                TreeNode treeNode;
                foreach (int key in optimumBuildGroups.Keys)
                {
                    keyNode = new TreeNode();
                    keyNode.Text = "Build Group " + key.ToString();

                    foreach (OptimizedBuild build in optimumBuildGroups[key].OrderBy(x => x.BuiltOrReactedName))
                    {
                        treeNode = new TreeNode();
                        treeNode.Text = build.TotalQuantityNeeded.ToString("N0") + " x " + build.BuiltOrReactedName + " | Runs Needed: " + build.RunsNeeded;
                        treeNode.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(build);
                        treeNode.Tag = build.BuiltOrReactedTypeId;
                        if (build.BatchesNeeded > 1)
                        {
                            treeNode.Text += " | Max Runs/Batch " + build.MaxRunsPerBatch + " | Batches Needed | " + build.BatchesNeeded;
                        }

                        AddTreeNodesForInputMats(build.InputMaterials, ref treeNode);
                        keyNode.Nodes.Add(treeNode);
                    }
                    OptimizedBuildTreeView.Nodes.Add(keyNode);
                }
            }
        }

        private void AddTreeNodesForInputMats(List<MaterialsWithMarketData> inputMats, ref TreeNode parentTreeNode)
        {
            TreeNode treeNode;
            List<MaterialsWithMarketData> orderedMats = inputMats.OrderBy(x => x.materialName).ToList();
            foreach (MaterialsWithMarketData mat in orderedMats)
            {
                treeNode = new TreeNode();
                treeNode.Text = "  " + mat.quantityTotal.ToString("N0") + " x " + mat.materialName;
                treeNode.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(mat);
                parentTreeNode.Nodes.Add(treeNode);
            }
        }

        private bool EnsurePriceData()
        {
            bool needToSetData = false;
            if (this.currentBuildPlan != null && this.isLoading)
            {
                if (!EnsurePriceWorker.IsBusy)
                {
                    List<MaterialsWithMarketData> matsForPriceSetting = this.currentBuildPlan.AllItems;
                    matsForPriceSetting = matsForPriceSetting.FindAll(x => x.pricePer <= 0);
                    if (matsForPriceSetting.Count > 0)
                    {
                        needToSetData = true;
                        this.PriceInfoSet = false;
                        this.ProgressLabel.Text = "Price Information is Loading. This may take some time.";
                        EnsurePriceWorker.RunWorkerAsync(matsForPriceSetting);
                    }
                }
            }
            return needToSetData;
        }

        private void CombineMatsFromOptimizedBuilds(ref List<MaterialsWithMarketData> outputList, List<OptimizedBuild> optimizedBuilds)
        {
            MaterialsWithMarketData existingMat;
            OptimizedBuild buildPlan;
            foreach (OptimizedBuild build in optimizedBuilds)
            {
                foreach (MaterialsWithMarketData input in build.InputMaterials)
                {
                    buildPlan = optimizedBuilds.Find(x => x.BuiltOrReactedTypeId == input.materialTypeID);
                    if (buildPlan == null)
                    {
                        existingMat = outputList.Find(x => x.materialTypeID == input.materialTypeID);
                        if (existingMat == null)
                        {
                            existingMat = new MaterialsWithMarketData();
                            existingMat.materialTypeID = input.materialTypeID;
                            existingMat.quantityTotal = input.quantityTotal;
                            existingMat.materialName = input.materialName;
                            existingMat.pricePer = input.pricePer;
                            existingMat.Buildable = input.Buildable;
                            existingMat.Reactable = input.Reactable;
                            outputList.Add(existingMat);
                        }
                        else
                        {
                            existingMat.quantityTotal += input.quantityTotal;
                        }
                        existingMat.priceTotal = existingMat.pricePer * existingMat.quantityTotal;
                    }
                }
            }
        }

        private void SetSummaryInformation()
        {
            if (this.currentBuildPlan != null)
            {
                OutcomeQuantityLabel.Text = this.currentBuildPlan.TotalOutcome.ToString("N0");
                decimal finalVolume = this.currentBuildPlan.TotalOutcome * FinalProductType.volume;
                OutcomeVolumeLabel.Text = finalVolume.ToString("N2");
                OptimizedBuild optimumBuild = this.currentBuildPlan.OptimizedBuilds.Find(x => x.BuiltOrReactedTypeId == FinalProductType.typeId);
                if (optimumBuild != null)
                {
                    decimal totalJobCost = 0;
                    this.currentBuildPlan.OptimizedBuilds.ForEach(x => totalJobCost += x.JobCost);
                    List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
                    CombineMatsFromOptimizedBuilds(ref combinedMats, this.currentBuildPlan.OptimizedBuilds);
                    decimal outcomePricePer = currentBuildPlan.finalSellPrice;
                    if (outcomePricePer <= 0)
                    {
                        if (this.currentBuildPlan.IndustrySettings.OutputOrderType == (int)(Enums.Enums.OrderType.Sell))
                        {
                            outcomePricePer = FinalProductSellOrderPrice;
                        }
                        else
                        {
                            outcomePricePer = FinalProductBuyOrderPrice;
                        }
                    }
                    decimal inputMaterialCostBeforeTax = combinedMats.Sum(x => x.priceTotal);
                    decimal totalInputPrice = inputMaterialCostBeforeTax;
                    decimal totalInputTaxes = CommonHelper.CalculateTaxAndFees(totalInputPrice,
                                                                               this.currentBuildPlan.IndustrySettings,
                                                                               this.currentBuildPlan.IndustrySettings.InputOrderType);
                    IskNeededForPlanLabel.Text = CommonHelper.FormatIsk(totalInputPrice + totalInputTaxes + totalJobCost + currentBuildPlan.additionalCosts);
                    decimal inputTaxPerItem = totalInputTaxes / optimumBuild.TotalQuantityNeeded;
                    
                    decimal outcomeSellTaxes = CommonHelper.CalculateTaxAndFees(outcomePricePer,
                                                                                this.currentBuildPlan.IndustrySettings,
                                                                                (int)Enums.Enums.OrderType.Sell);
                    
                    decimal outcomeBuyTaxes = CommonHelper.CalculateTaxAndFees(outcomePricePer,
                                                                                this.currentBuildPlan.IndustrySettings,
                                                                                (int)Enums.Enums.OrderType.Buy);
                    
                    ProductionCostUnitLabel.Text = CommonHelper.FormatIsk(optimumBuild.PricePerItem);

                    //decimal totalCostPerItem = (totalInputPrice / optimumBuild.TotalQuantityNeeded) + (totalJobCost / optimumBuild.TotalQuantityNeeded) + (currentBuildPlan.additionalCosts / optimumBuild.TotalQuantityNeeded);
                    decimal totalCostPerItem = optimumBuild.PricePerItem;
                    totalCostPerItem += inputTaxPerItem;
                    decimal profit = 0;
                    string outputOrderTypeString;
                    decimal totalOutComeTaxes;
                    decimal totalOutcomeIskBeforeTax;

                    if (this.currentBuildPlan.IndustrySettings.OutputOrderType == (int)(Enums.Enums.OrderType.Sell))
                    {
                        outputOrderTypeString = "Sell";
                        totalCostPerItem += outcomeSellTaxes;
                        totalOutComeTaxes = (outcomeSellTaxes * optimumBuild.TotalQuantityNeeded);
                        totalOutcomeIskBeforeTax = (outcomePricePer * optimumBuild.TotalQuantityNeeded);
                        profit = (outcomePricePer * optimumBuild.TotalQuantityNeeded) - (totalCostPerItem * optimumBuild.TotalQuantityNeeded);
                    }
                    else
                    {
                        outputOrderTypeString = "Buy";
                        totalCostPerItem += outcomeBuyTaxes;
                        totalOutComeTaxes = (outcomeBuyTaxes * optimumBuild.TotalQuantityNeeded);
                        totalOutcomeIskBeforeTax = (outcomePricePer * optimumBuild.TotalQuantityNeeded);
                        profit = (outcomePricePer * optimumBuild.TotalQuantityNeeded) - (totalCostPerItem * optimumBuild.TotalQuantityNeeded);
                    }
                    string inputOrderTypeString;
                    if (this.currentBuildPlan.IndustrySettings.InputOrderType == (int)(Enums.Enums.OrderType.Sell))
                    {
                        inputOrderTypeString = "Sell";
                    }
                    else
                    {
                        inputOrderTypeString = "Buy";
                    }
                    HeaderCostUnitLabel.Text = CommonHelper.FormatIsk(totalCostPerItem);

                    decimal totalVolume = GetTotalVolumeForMaterials(combinedMats);
                    InputVolumeLabel.Text = totalVolume.ToString("N2") + " m3";

                    ProfitLabel.Text = CommonHelper.FormatIsk(profit);

                    SetCostBreakdownTextBox(inputMaterialCostBeforeTax,
                                            totalInputTaxes,
                                            totalJobCost,
                                            inputOrderTypeString,
                                            outputOrderTypeString,
                                            totalOutComeTaxes,
                                            totalOutcomeIskBeforeTax,
                                            outcomePricePer);
                    decimal wasteValue = BuildPlanHelper.GetValueofWaste(currentBuildPlan);
                    leftoverMatsValueLabel.Text = CommonHelper.FormatIsk(wasteValue);
                }
            }
        }

        private void SetCostBreakdownTextBox(decimal materialCost,
                                            decimal materialTax,
                                            decimal jobCost,
                                            string inputOrderType,
                                            string outputOrderType,
                                            decimal outputTax,
                                            decimal totalOutputIsk,
                                            decimal pricePerItem)
        {
            StringBuilder sb = new StringBuilder();
            decimal totalCost = materialCost + materialTax + jobCost + outputTax + currentBuildPlan.additionalCosts;
            sb.AppendLine("Cost Breakdown for " + FinalProductType.typeName);
            sb.AppendLine("");
            sb.AppendLine("Input Material Costs");
            sb.AppendLine("---------------------");
            sb.AppendLine("Selected Input Order Type:");
            sb.AppendLine("\t" + inputOrderType);
            sb.AppendLine("Cost of input Materials before Taxes:");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(materialCost));
            sb.AppendLine("Tax:");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(materialTax));
            sb.AppendLine("");
            sb.AppendLine("Job Costs");
            sb.AppendLine("---------------------");
            sb.AppendLine("Job costs for all manufacturing and reaction jobs: ");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(jobCost));
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            sb.AppendLine("Additional Costs (user input):");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(currentBuildPlan.additionalCosts));
            sb.AppendLine("");
            sb.AppendLine("Taxes on selling final product");
            sb.AppendLine("---------------------");
            sb.AppendLine("Selected Output Order Type:");
            sb.AppendLine("\t" + outputOrderType);
            sb.AppendLine("Tax:");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(outputTax));
            sb.AppendLine("");
            sb.AppendLine("Total Costs:");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(totalCost));

            sb.AppendLine("");
            sb.AppendLine("Price per Item:");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(pricePerItem));
            if (pricePerItem == FinalSellPriceNumeric.Value)
            {
                sb.AppendLine("Item value manually set by user on Material & Prices page.");
                sb.AppendLine("");
            }
            sb.AppendLine("Total Isk Value of Final Product on market Before Taxes:");
            sb.AppendLine("\t" + CommonHelper.FormatIsk(totalOutputIsk));

            decimal expectedProfit = totalOutputIsk - totalCost;
            if (expectedProfit > 0)
            {
                sb.AppendLine("Expected Profit:");
                sb.AppendLine("\t" + CommonHelper.FormatIsk(totalOutputIsk - totalCost));
            }
            else
            {
                sb.AppendLine("Expected Losses:");
                sb.AppendLine("\t" + CommonHelper.FormatIsk(totalOutputIsk - totalCost));
            }
            CostBreakdownTextBox.Text = sb.ToString();
        }

        private decimal GetTotalVolumeForMaterials(List<MaterialsWithMarketData> materials)
        {
            decimal totalVolume = 0;

            InventoryType inventoryType;
            foreach (MaterialsWithMarketData material in materials)
            {
                inventoryType = CommonHelper.InventoryTypes.Find(x => x.typeId == material.materialTypeID);
                if (inventoryType != null)
                {
                    totalVolume += inventoryType.volume * material.quantityTotal;
                }
            }

            return totalVolume;
        }

        private void LoadMaterialsPriceTreeView()
        {
            FinalSellPriceNumeric.Value = currentBuildPlan.finalSellPrice;

            MaterialsPriceTreeView.Nodes.Clear();
            List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
            CombineMatsFromOptimizedBuilds(ref combinedMats, this.currentBuildPlan.OptimizedBuilds);
            TreeNode tn;
            combinedMats = combinedMats.OrderBy(x => x.materialName).ToList();
            MaterialsWithMarketData pricedMat;
            TreeNode pricePer;
            TreeNode priceTotal;
            foreach (var mat in combinedMats)
            {
                pricedMat = this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == mat.materialTypeID);
                tn = new TreeNode();
                tn.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(mat);
                tn.Text = mat.quantityTotal.ToString("N0") + " x " + mat.materialName;
                tn.Tag = mat.materialTypeID;

                pricePer = new TreeNode();
                pricePer.Text = "Price Per: " + CommonHelper.FormatIsk(pricedMat.pricePer);
                pricePer.ForeColor = Color.White;
                tn.Nodes.Add(pricePer);

                priceTotal = new TreeNode();
                priceTotal.Text = "Price Total: " + CommonHelper.FormatIsk(mat.quantityTotal * pricedMat.pricePer);
                priceTotal.ForeColor = Color.White;
                tn.Nodes.Add(priceTotal);

                MaterialsPriceTreeView.Nodes.Add(tn);
            }
        }

        private void LoadPlanetaryMaterialsPage()
        {
            LoadUniquePlanetMaterials();
            if (UniquePlanetMaterials != null && UniquePlanetMaterials.Count > 0)
            {
                LoadPlanetaryTreeView();
            }
            else
            {
                if (PlanetMaterialsTreeView.Nodes.Count > 0)
                {
                    PlanetMaterialsTreeView.Nodes.Clear();
                }
            }
        }

        private void LoadUniquePlanetMaterials()
        {
            List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
            CombineMatsFromOptimizedBuilds(ref combinedMats, this.currentBuildPlan.OptimizedBuilds);
            UniquePlanetMaterials = new List<PlanetMaterial>();
            InventoryType invType;
            PlanetMaterial existingMat;
            foreach (MaterialsWithMarketData mat in combinedMats)
            {
                invType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                switch (invType.categoryID)
                {
                    case (int)Enums.Enums.InvTypeCategory.PlanetResource:
                    case (int)Enums.Enums.InvTypeCategory.PlanetIndustry:
                    case (int)Enums.Enums.InvTypeCategory.PlanetCommodity:
                        existingMat = UniquePlanetMaterials.Find(x => x.typeID == mat.materialTypeID);
                        if (existingMat != null)
                        {
                            existingMat.quantity += (int)mat.quantityTotal;
                        }
                        else
                        {
                            existingMat = new PlanetMaterial();
                            existingMat.typeID = mat.materialTypeID;
                            existingMat.typeName = mat.materialName;
                            existingMat.quantity = (int)mat.quantityTotal;
                            existingMat.groupName = invType.groupName;
                            existingMat.groupID = invType.groupId;
                            UniquePlanetMaterials.Add(existingMat);
                        }
                        break;
                }
            }
        }

        private void LoadUIAfterCalcs()
        {
            LoadProductImage();
            LoadBasicInfo();
            LoadIndySettings();
            LoadFinalProductMarketInfo();
            LoadMaterialsPriceTreeView();
            LoadDetailsPage(false);
            LoadOptimumBuildSchedule();
            SetSummaryInformation();
            LoadPlanetaryMaterialsPage();
        }

        private void LoadPlanetaryTreeView()
        {
            PlanetMaterialsTreeView.Nodes.Clear();
            TreeNode tn;
            foreach (PlanetMaterial planetMaterial in UniquePlanetMaterials)
            {
                PlanetSchematicsHelper.GetInputsForSchematicRecurseive(planetMaterial);
                tn = BuildTreeViewForPIMatRecursive(planetMaterial);
                PlanetMaterialsTreeView.Nodes.Add(tn);
            }
        }

        private TreeNode BuildTreeViewForPIMatRecursive(PlanetMaterial planetMaterial)
        {
            TreeNode treeNode = new TreeNode();

            treeNode.Text = planetMaterial.typeName;
            if (planetMaterial.quantity > 0)
            {
                treeNode.Text += " x " + planetMaterial.quantity.ToString("N0");
            }

            if (planetMaterial.Inputs != null && planetMaterial.Inputs.Count > 0)
            {
                foreach (PlanetMaterial piInput in planetMaterial.Inputs)
                {
                    treeNode.Nodes.Add(BuildTreeViewForPIMatRecursive(piInput));
                }
            }

            return treeNode;
        }

        private void LoadBlueprintStoreTreeView()
        {
            TreeNode[] copyOfNodes = new TreeNode[BPTreeView.Nodes.Count];
            BPTreeView.Nodes.CopyTo(copyOfNodes, 0);
            BPTreeView.Nodes.Clear();
            LoadFinalProductNode();
            LoadManufcaturingNodes();
            LoadReactionNodes();

        }

        private void LoadFinalProductNode()
        {
            TreeNode fpNode = new TreeNode();
            fpNode.Text = "Final Product: " + FinalProductType.typeName;
            fpNode.Tag = currentBuildPlan.parentBlueprintOrReactionTypeID;
            fpNode.Expand();


            BlueprintInfo BPInfo = currentBuildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == currentBuildPlan.parentBlueprintOrReactionTypeID);
            if (BPInfo.IsManufactured)
            {
                TreeNode MENode = new TreeNode();
                MENode.Text = "ME: " + BPInfo.ME;
                fpNode.Nodes.Add(MENode);

                TreeNode TENode = new TreeNode();
                TENode.Text = "TE: " + BPInfo.TE;
                fpNode.Nodes.Add(TENode);
            }
            BPTreeView.Nodes.Add(fpNode);
        }

        private void LoadManufcaturingNodes()
        {
            List<BlueprintInfo> manufacturingBPs = this.currentBuildPlan.BlueprintStore.FindAll(x => x.IsManufactured && x.BlueprintTypeId != currentBuildPlan.parentBlueprintOrReactionTypeID);

            if (manufacturingBPs.Count > 0)
            {
                manufacturingBPs = manufacturingBPs.OrderBy(x => x.BlueprintName).ToList();
                TreeNode manufactureNode = new TreeNode();
                manufactureNode.Text = "Blueprints";
                TreeNode manuNode;
                foreach (BlueprintInfo bp in manufacturingBPs)
                {
                    manuNode = new TreeNode();
                    manuNode.Tag = bp.BlueprintTypeId;
                    manuNode.Text = bp.BlueprintName;
                    manuNode.Name = bp.BlueprintTypeId.ToString();

                    BuildChildNodes(bp, ref manuNode);
                    manufactureNode.Nodes.Add(manuNode);
                }
                BPTreeView.Nodes.Add(manufactureNode);
            }
        }

        private void BuildChildNodes(BlueprintInfo bpInfo, ref TreeNode parentNode)
        {
            if (bpInfo.IsManufactured)
            {
                parentNode.Nodes.Add("ME: " + bpInfo.ME);
                parentNode.Nodes.Add("TE: " + bpInfo.TE);
            }
            parentNode.Nodes.Add("Make Item: " + (bpInfo.Manufacture || bpInfo.React).ToString());
            parentNode.Nodes.Add("Max Runs: " + bpInfo.MaxRuns);
        }

        private void LoadReactionNodes()
        {
            List<BlueprintInfo> reactions = this.currentBuildPlan.BlueprintStore.FindAll(x => x.IsReacted && x.BlueprintTypeId != currentBuildPlan.parentBlueprintOrReactionTypeID);

            if (reactions.Count > 0)
            {
                reactions = reactions.OrderBy(x => x.BlueprintName).ToList();
                TreeNode ReactionsNode = new TreeNode();
                ReactionsNode.Text = "Reactions";
                TreeNode reactionNode;
                foreach (BlueprintInfo bp in reactions)
                {
                    reactionNode = new TreeNode();
                    reactionNode.Tag = bp.BlueprintTypeId;
                    reactionNode.Text = bp.BlueprintName;
                    reactionNode.Name = bp.BlueprintTypeId.ToString();

                    BuildChildNodes(bp, ref reactionNode);

                    ReactionsNode.Nodes.Add(reactionNode);
                }
                BPTreeView.Nodes.Add(ReactionsNode);
            }
        }

        private void SetAllBlueprintValues(int me, int te, int maxRuns, bool makeItem)
        {
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                if (bpInfo.IsManufactured)
                {
                    bpInfo.ME = me;
                    bpInfo.TE = te;
                    bpInfo.MaxRuns = maxRuns;
                    bpInfo.Manufacture = makeItem;
                }
            }
        }

        private void SetAllReactionValues(int maxRuns, bool makeItem)
        {
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                if (bpInfo.IsReacted)
                {
                    bpInfo.MaxRuns = maxRuns;
                    bpInfo.React = makeItem;
                }
            }
        }
        #endregion

        #region "Background Workers"
        private void LoadProductImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[]? bpImage = null;
            if (this.currentBuildPlan != null && this.currentBuildPlan.finalProductTypeID > 0)
            {
                bpImage = ESIImageServer.GetImageForType(this.currentBuildPlan.finalProductTypeID, "icon");
            }
            e.Result = bpImage;
        }

        private void LoadProductImageBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool imageSet = false;
            byte[] productImage = (byte[])(e.Result);
            if (productImage != null && productImage.Length > 0)
            {
                MemoryStream memstream = new MemoryStream();
                memstream.Write(productImage, 0, productImage.Length);
                FinalProductImagePanel.BackgroundImage = Image.FromStream(memstream);
                DetailsImagePanel.BackgroundImage = Image.FromStream(memstream);
                imageSet = true;
            }
            if (!imageSet)
            {
                FinalProductImagePanel.BackgroundImage = null;
                DetailsImagePanel.BackgroundImage = null;
            }
        }

        private void EnsurePriceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MaterialsWithMarketData> mats = (List<MaterialsWithMarketData>)e.Argument;
            int currentMatCount = 0;
            int totalMats = mats.Count;
            decimal progress = 0;
            foreach (MaterialsWithMarketData mat in mats)
            {
                currentMatCount++;
                BuildPlanHelper.EnsurePricePer(mat, this.currentBuildPlan.IndustrySettings, currentBuildPlan.BlueprintStore);
                progress = Math.Ceiling(((decimal)currentMatCount / (decimal)totalMats) * 100);

                EnsurePriceWorker.ReportProgress((int)progress);
            }
            e.Result = mats;
            //sleep for one seconds to give the main thread time to complete it's work.
            Thread.Sleep(1000);
        }

        private void EnsurePriceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<MaterialsWithMarketData> mats = (List<MaterialsWithMarketData>)(e.Result);
            foreach (MaterialsWithMarketData mat in mats)
            {
                this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == mat.materialTypeID).pricePer = mat.pricePer;
            }
            BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds, 
                                                                 this.currentBuildPlan.AllItems, 
                                                                 FinalProductType.typeId, 
                                                                 this.currentBuildPlan.additionalCosts, 
                                                                 this.currentBuildPlan);
            SaveBuildPlan();
            this.PriceInfoSet = true;
            ProgressLabel.Text = "";
            LoadUIAfterCalcs();
        }

        private void EnsurePriceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            decimal currentProgress = (decimal)e.ProgressPercentage / (decimal)100;
            ProgressLabel.Text = "Getting Market Data Progress: " + currentProgress.ToString("P");
        }
        #endregion

        private void FinalSellPriceNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (currentBuildPlan != null && !isLoading && FinalSellPriceNumeric.Validate())
            {
                currentBuildPlan.finalSellPrice = FinalSellPriceNumeric.Value;
                SetSummaryInformation();
            }
        }
    }
}
