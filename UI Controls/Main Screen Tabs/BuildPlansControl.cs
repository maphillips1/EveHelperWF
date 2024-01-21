using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Net.Security;
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
        private bool isLoading = false;
        private List<Control> DetailFlowsControls = new List<Control>();
        private OptimizedBuildDetailsControl DetailsControl;
        private bool PriceInfoSet = true;

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
            this.currentBuildPlan = buildPlan;
            BlueprintBrowserHelper.Init();
            LoadIndySettingCombos();
            LoadControl();
            isLoading = false;
        }
        #endregion

        #region "Events"

        private void BuildPlanCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            isLoading = true;
            this.Cursor = Cursors.WaitCursor;
            LoadBuildPlanFromFile();
            LoadUIForBuildPlan();
            this.Cursor = Cursors.Default;
            isLoading = false;
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

        private void RunsPerCopy_ValueChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                this.currentBuildPlan.RunsPerCopy = (Int32)(RunsPerCopyUpDown.Value);
                this.currentBuildPlan.IndustrySettings.Runs = (Int32)RunsPerCopyUpDown.Value;
                SaveBuildPlan();
                LoadUIForBuildPlan();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void NumCopies_ValueChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                this.currentBuildPlan.NumOfCopies = (Int32)(NumberCopiesUpDown.Value);
                this.currentBuildPlan.IndustrySettings.NumCopies = (Int32)NumberCopiesUpDown.Value;
                SaveBuildPlan();
                LoadUIForBuildPlan();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
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
                LoadUIForBuildPlan();
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
                LoadUIForBuildPlan();
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
                LoadUIForBuildPlan();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void BuildRectAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                BuildPlanHelper.SetBuildReactAllRecursive(this.currentBuildPlan.InputMaterials, BuildRectAllCheckbox.Checked);
                RunOptimumBuildCalc();
                LoadDetailsPage(true);
                LoadOptimumBuildSchedule();
                EnsurePriceData();
                SetSummaryInformation();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void MaterialsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;


                // The code only executes if the user caused the checked state to change.
                if (e.Action != TreeViewAction.Unknown)
                {
                    string controlName = (string)e.Node.Tag;
                    if (SetBuildOrReactRecurisve(controlName, e.Node.Checked, this.currentBuildPlan.InputMaterials))
                    {
                        SaveBuildPlan();
                        //TODO Call Financials Code
                        LoadDetailsPage(false);
                        RunOptimumBuildCalc();
                        LoadOptimumBuildSchedule();
                    }
                }
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
            if (e.Node.Tag != null)
            {
                int optimizedTypeId = (int)(e.Node.Tag);
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

            InventionSolarSystemCombo.BindingContext = new BindingContext();
            InventionSolarSystemCombo.DisplayMember = "solarSystemName";
            InventionSolarSystemCombo.ValueMember = "solarSystemID";
            InventionSolarSystemCombo.DataSource = CommonHelper.SolarSystemList;

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

            InventionStructureCombo.BindingContext = new BindingContext();
            InventionStructureCombo.DisplayMember = "value";
            InventionStructureCombo.ValueMember = "key";
            InventionStructureCombo.DataSource = BlueprintBrowserHelper.GetEngineeringStructureItems();

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

            InventionStructureCostRigCombo.BindingContext = new BindingContext();
            InventionStructureCostRigCombo.DisplayMember = "Value";
            InventionStructureCostRigCombo.ValueMember = "Key";
            InventionStructureCostRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();

            InventionStructureTimeRigCombo.BindingContext = new BindingContext();
            InventionStructureTimeRigCombo.DisplayMember = "Value";
            InventionStructureTimeRigCombo.ValueMember = "Key";
            InventionStructureTimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();

            //Implants
            ImplantCombo.BindingContext = new BindingContext();
            ImplantCombo.DisplayMember = "Value";
            ImplantCombo.ValueMember = "Key";
            ImplantCombo.DataSource = BlueprintBrowserHelper.GetManufacturingImplantItems();

            //Decryptor
            InventionDecryptorCombo.BindingContext = new BindingContext();
            InventionDecryptorCombo.ValueMember = "typeID";
            InventionDecryptorCombo.DisplayMember = "typeName";
            InventionDecryptorCombo.DataSource = BlueprintBrowserHelper.GetDecryptors();

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
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.ShoppingListsDirectory, selectedFileName);
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
                int selectedFile = (int)BuildPlanCombo.SelectedValue;

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
                EnsureInputMaterials();
                EnsureCalculationHelperClass();
                EnsureMinimumRunsAndCopies();

                //Run the calcs
                RunCalcs();

                if (!EnsurePriceData())
                {
                    List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
                    CombineMats(ref combinedMats, this.currentBuildPlan.InputMaterials);
                    BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds, 
                                                                         combinedMats, 
                                                                         FinalProductType.typeId, 
                                                                         this.currentBuildPlan.additionalCosts);
                }


                //Load All the info on the screen
                LoadProductImage();
                LoadBasicInfo();
                LoadIndySettings();
                LoadFinalProductMarketInfo();
                LoadDetailsPage(true);
                LoadOptimumBuildSchedule();
                SetSummaryInformation();
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

            //Reactions Values
            calculationHelperClass.ReactionSolarSystemID = defaultFormValues.ReactionsSystemValue;
            calculationHelperClass.ReactionsStructureTypeID = defaultFormValues.ReactionStructureValue;
            calculationHelperClass.ReactionsFacilityTax = defaultFormValues.ReactionTaxValue;
            calculationHelperClass.ReactionStructureRigBonus = new StructureRigBonus();

            //Invention Values
            calculationHelperClass.InventBlueprint = defaultFormValues.InventBlueprintValue;
            calculationHelperClass.InventionSolarSystemID = defaultFormValues.InventionSystemValue;
            calculationHelperClass.InventionFacilityTax = defaultFormValues.InventionTaxValue;
            calculationHelperClass.InventionDecryptorId = defaultFormValues.InventionDecryptorValue;
            calculationHelperClass.InventionStructureRigBonus = new StructureRigBonus();

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
            RunOptimumBuildCalc();
        }

        private void RunOptimumBuildCalc()
        {
            this.currentBuildPlan.OptimizedBuilds = BuildPlanHelper.DetermineOptimumBuild(this.currentBuildPlan.InputMaterials, this.currentBuildPlan);
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
            ClearShoppingListControls();

            this.ResumeLayout();
        }

        private void ClearShoppingListControls()
        {
            System.Windows.Forms.Control.ControlCollection controls = ShoppingListItemsPanel.Controls;
            CommonHelper.DisposeAllControlsInCollection(controls);
            foreach (Control control in controls)
            {
                ShoppingListItemsPanel.Controls.Remove(control);
            }
            System.GC.Collect();
        }

        private void CopyInputsToClipboard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
            CombineMats(ref combinedMats, this.currentBuildPlan.InputMaterials);

            foreach (MaterialsWithMarketData mat in combinedMats)
            {
                if (!mat.Build && !mat.React)
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
                this.MEUpDown.Value = this.currentBuildPlan.IndustrySettings.ME;
                this.TEUpDown.Value = this.currentBuildPlan.IndustrySettings.TE;
                this.ManufacturingSystemCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID;
                this.ManufacturingStructureCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingStructureTypeID;
                this.ManufacturingStructureMERigCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigMEBonus;
                this.ManufacturingStructureTERigCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigTEBonus;
                this.ManufacturingTaxUpDown.Value = this.currentBuildPlan.IndustrySettings.ManufacturingFacilityTax;
                this.ImplantCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ManufacturingImplantTypeID;
                this.CompMEUpDown.Value = this.currentBuildPlan.IndustrySettings.CompME;
                this.CompTEUpDown.Value = this.currentBuildPlan.IndustrySettings.CompTE;

                //Reactions
                this.ReactionSolarSystemCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID;
                this.ReactionStructureCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID;
                this.ReactionTaxUpDown.Value = this.currentBuildPlan.IndustrySettings.ReactionsFacilityTax;
                this.ReactionStructureMERig.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus;
                this.ReactionStructureTERig.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus;

                //Inventions
                this.InventionSolarSystemCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.InventionSolarSystemID;
                this.InventionStructureCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.InventionStructureTypeID;
                this.InventionStructureCostRigCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.InventionStructureRigBonus.RigMEBonus;
                this.InventionStructureTimeRigCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.InventionStructureRigBonus.RigTEBonus;
                this.InventionTaxUpDown.Value = this.currentBuildPlan.IndustrySettings.InventionFacilityTax;
                this.InventionDecryptorCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.InventionDecryptorId;

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
                    this.currentBuildPlan.IndustrySettings.ME = (Int32)this.MEUpDown.Value;
                    this.currentBuildPlan.IndustrySettings.TE = (Int32)this.TEUpDown.Value;
                    this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID = (int)(this.ManufacturingSystemCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID);
                    this.currentBuildPlan.IndustrySettings.ManufacturingStructureTypeID = (Int32)(this.ManufacturingStructureCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingStructureTypeID);
                    this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigMEBonus = (Int32)(this.ManufacturingStructureMERigCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigMEBonus);
                    this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigTEBonus = (Int32)(this.ManufacturingStructureTERigCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingStructureRigBonus.RigTEBonus);
                    this.currentBuildPlan.IndustrySettings.ManufacturingFacilityTax = (decimal)(this.ManufacturingTaxUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.ManufacturingImplantTypeID = (Int32)(this.ImplantCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ManufacturingImplantTypeID);
                    this.currentBuildPlan.IndustrySettings.CompME = (Int32)this.CompMEUpDown.Value;
                    this.currentBuildPlan.IndustrySettings.CompTE = (Int32)this.CompTEUpDown.Value;

                    break;
                case 1:
                    this.currentBuildPlan.IndustrySettings.InventionSolarSystemID = (Int32)(this.InventionSolarSystemCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.InventionSolarSystemID);
                    this.currentBuildPlan.IndustrySettings.InventionStructureTypeID = (Int32)(this.InventionStructureCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.InventionStructureTypeID);
                    this.currentBuildPlan.IndustrySettings.InventionStructureRigBonus.RigMEBonus = (Int32)(this.InventionStructureCostRigCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.InventionStructureRigBonus.RigMEBonus);
                    this.currentBuildPlan.IndustrySettings.InventionStructureRigBonus.RigTEBonus = (Int32)(this.InventionStructureTimeRigCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.InventionStructureRigBonus.RigTEBonus);
                    this.currentBuildPlan.IndustrySettings.InventionFacilityTax = (decimal)(this.InventionTaxUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.InventionDecryptorId = (Int32)(InventionDecryptorCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.InventionDecryptorId);

                    break;
                case 2:
                    this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID = (Int32)(this.ReactionSolarSystemCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID);
                    this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID = (Int32)(this.ReactionStructureCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID);
                    this.currentBuildPlan.IndustrySettings.ReactionsFacilityTax = (decimal)this.ReactionTaxUpDown.Value;
                    this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus = (Int32)(this.ReactionStructureMERig.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus);
                    this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus = (Int32)(this.ReactionStructureTERig.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus);

                    break;
                case 3:
                    this.currentBuildPlan.IndustrySettings.AccountingSkill = (Int32)(this.AccountingLevelUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.BrokersSkill = (Int32)(this.BrokerRelationsLevelUpDown.Value);

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
                    BuildIndustryGraph();
                }
                if (!fromBuildReactAllChecked)
                {
                    BuildRectAllCheckbox.Checked = BuildPlanHelper.IsAllMaterialsBuildOrReacted(this.currentBuildPlan.InputMaterials);
                }
            }
            DetailsPage.ResumeLayout();
        }

        private void BuildIndustryGraph()
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

                if (inputMaterial.Build || inputMaterial.React)
                {
                    node.Checked = true;
                    node.Expand();
                    if (inputMaterial.ChildMaterials.Count > 0)
                    {
                        sb.Append(" | Runs Needed: " + inputMaterial.RunsNeeded.ToString("N0"));
                        node.Nodes.AddRange(AddMaterialsToTreeView(inputMaterial.ChildMaterials).ToArray());
                    }
                }
                node.Text = sb.ToString();
                node.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(inputMaterial);
                nodes.Add(node);
            }
            return nodes;
        }

        private bool SetBuildOrReactRecurisve(string controlName, bool value, List<MaterialsWithMarketData> mats)
        {
            if (!string.IsNullOrEmpty(controlName))
            {
                foreach (MaterialsWithMarketData mat in mats)
                {
                    if (mat.controlName.ToLowerInvariant().Equals(controlName.ToLowerInvariant()))
                    {
                        if (mat.Buildable) { mat.Build = value; return true; }
                        if (mat.Reactable) { mat.React = value; return true; }
                    }
                    else
                    {
                        if (mat.ChildMaterials.Count > 0)
                        {
                            if (SetBuildOrReactRecurisve(controlName, value, mat.ChildMaterials))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void LoadOptimumBuildSchedule()
        {
            Dictionary<int, List<OptimizedBuild>> optimumBuildGroups = BuildPlanHelper.GetOptimumBuildGroups(this.currentBuildPlan.OptimizedBuilds);
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
                    keyNode.Text = "Batch " + key.ToString();

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
                    List<MaterialsWithMarketData> matsForPriceSetting = new List<MaterialsWithMarketData>();
                    CombineMats(ref matsForPriceSetting, this.currentBuildPlan.InputMaterials);
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

        private void CombineMats(ref List<MaterialsWithMarketData> outputList, List<MaterialsWithMarketData> inputList)
        {
            MaterialsWithMarketData copyMat;
            foreach (MaterialsWithMarketData mat in inputList)
            {
                if (!mat.Build && !mat.React)
                {
                    copyMat = outputList.Find(x => x.materialTypeID == mat.materialTypeID);
                    if (copyMat == null)
                    {
                        copyMat = new MaterialsWithMarketData();
                        copyMat.materialTypeID = mat.materialTypeID;
                        copyMat.materialName = mat.materialName;
                        copyMat.quantityTotal = mat.quantityTotal;
                        copyMat.pricePer = mat.pricePer;
                        copyMat.priceTotal = mat.priceTotal;
                        outputList.Add(copyMat);
                    }
                    else
                    {
                        copyMat.quantityTotal += mat.quantityTotal;
                    }
                }
                CombineMats(ref outputList, mat.ChildMaterials);
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
                    List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
                    CombineMats(ref combinedMats, this.currentBuildPlan.InputMaterials);
                    decimal totalInputPrice = BuildPlanHelper.GetTotalInputPrice(combinedMats);
                    decimal totalInputTaxes = CommonHelper.CalculateTaxAndFees(totalInputPrice, 
                                                                               this.currentBuildPlan.IndustrySettings, 
                                                                               this.currentBuildPlan.IndustrySettings.InputOrderType);
                    InputTaxLabel.Text = CommonHelper.FormatIsk(totalInputTaxes);
                    decimal outcomeSellTaxes = CommonHelper.CalculateTaxAndFees(optimumBuild.PricePerItem,
                                                                                this.currentBuildPlan.IndustrySettings,
                                                                                (int)Enums.Enums.OrderType.Sell);
                    OutputSellTaxes.Text = "Sell Order: " + CommonHelper.FormatIsk(outcomeSellTaxes);
                    decimal outcomeBuyTaxes = CommonHelper.CalculateTaxAndFees(optimumBuild.PricePerItem,
                                                                                this.currentBuildPlan.IndustrySettings,
                                                                                (int)Enums.Enums.OrderType.Buy);
                    OutputBuyTaxes.Text = "Buy order: " + CommonHelper.FormatIsk(outcomeBuyTaxes);

                    ProductionCostUnitLabel.Text = CommonHelper.FormatIsk(optimumBuild.PricePerItem);
                }
            }
        }
        #endregion

        #region "Background Workers"
        private void LoadProductImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] bpImage = null;
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
                BuildPlanHelper.EnsurePricePer(mat, this.currentBuildPlan.IndustrySettings);
                progress = Math.Ceiling((decimal)(currentMatCount / totalMats) * 100);

                EnsurePriceWorker.ReportProgress((int)progress);
            }
            e.Result = mats;
            //sleep for two seconds to give the main thread time to complete it's work.
            Thread.Sleep(2000);
        }

        private void EnsurePriceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<MaterialsWithMarketData> mats = (List<MaterialsWithMarketData>)(e.Result);
            BuildPlanHelper.SetPricePerRecursive(this.currentBuildPlan.InputMaterials, mats);
            BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds, mats, FinalProductType.typeId, this.currentBuildPlan.additionalCosts);
            SaveBuildPlan();
            this.PriceInfoSet = true;
            ProgressLabel.Text = "";
            SetSummaryInformation();
        }

        private void EnsurePriceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int currentProgress = e.ProgressPercentage;
            ProgressLabel.Text = "Current Market Progress: " + currentProgress.ToString("P");
        }
        #endregion
    }
}
