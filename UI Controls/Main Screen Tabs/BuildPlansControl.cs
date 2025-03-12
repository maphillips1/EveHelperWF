using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.Objects.Custom_Controls;
using EveHelperWF.Objects.ESI_Objects.Market_Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using FileIO;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class BuildPlansControl : Objects.FormBase
    {
        enum TabPages
        {
            Summary = 0,
            BPReaction = 1,
            SystemStruct = 2,
            MaterialPrices = 3,
            CurrentInventory = 4,
            BuildDetails = 5,
            PlanetMats = 6,
            CostBreakdown = 7
        }

        private BuildPlan currentBuildPlan;
        string CurrentFileName;
        private InventoryType FinalProductType;
        private bool isLoading = false;
        private OptimizedBuildDetailsControl DetailsControl;
        private bool PriceInfoSet = true;
        private List<PlanetMaterial> UniquePlanetMaterials;
        private decimal FinalProductSellOrderPrice;
        private decimal FinalProductBuyOrderPrice;
        private bool IgnoreTextChangedEvent;
        private bool IsResetting;
        BindingList<KeyValuePair<string, string>> FileNames = new BindingList<KeyValuePair<string, string>>();
        private List<MaterialsWithMarketData> _CombinedMats = new List<MaterialsWithMarketData>();

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
            ShowHideTabPage((int)TabPages.Summary);
            isLoading = false;
        }

        public BuildPlansControl(BuildPlan buildPlan)
        {
            isLoading = true;
            InitializeComponent();
            this.currentBuildPlan = buildPlan;
            CurrentFileName = Enums.Enums.BuildPlanDirectory + this.currentBuildPlan.BuildPlanName;
            SaveBuildPlan();
            BlueprintBrowserHelper.Init();
            LoadIndySettingCombos();
            LoadControl();
            string selectedFileName = FileNames.ToDictionary<string, string>().Keys.ToList().Find(x => x.Equals(buildPlan.BuildPlanName.Replace(".json", "")));
            if (selectedFileName != null)
            {
                BuildPlanCombo.SelectedValue = selectedFileName;
            }
            isLoading = false;
        }
        #endregion

        #region "Events"

        private void BuildPlanCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading && WaitForWorkers())
            {
                isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                if (this.currentBuildPlan != null)
                {
                    SaveBuildPlan();
                }
                this.currentBuildPlan = null;
                ResetControls();
                LoadBuildPlanFromFile();
                LoadUIForBuildPlan();
                this.Cursor = Cursors.Default;
                isLoading = false;
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
                if (WaitForWorkers())
                {
                    this.currentBuildPlan = new BuildPlan();
                    this.currentBuildPlan.BuildPlanName = addBuildPlanScreen.PlanNameTextBox.Text + ".json";
                    this.currentBuildPlan.finalProductTypeID = (Int32)addBuildPlanScreen.ProductCombo.SelectedValue;
                    this.currentBuildPlan.RunsPerCopy = 1;
                    this.currentBuildPlan.NumOfCopies = 1;
                    CurrentFileName = Enums.Enums.BuildPlanDirectory + this.currentBuildPlan.BuildPlanName;
                    SaveBuildPlan();
                    LoadFileCombo();
                    string selectedFileName = FileNames.ToDictionary<string, string>().Keys.ToList().Find(x => x.Equals(addBuildPlanScreen.PlanNameTextBox.Text));
                    if (selectedFileName != null)
                    {
                        BuildPlanCombo.SelectedValue = CurrentFileName;
                    }
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
            if (this.currentBuildPlan != null && !isLoading && !IsResetting)
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
                List<ESIMarketType> mats = new List<ESIMarketType>();
                _CombinedMats.ForEach(x => mats.Add(new ESIMarketType { typeID = x.materialTypeID, quantity = x.quantityTotal }));
                List<ESIMarketType> pricedMats;

                ProgressLabel.Text = "Getting Market Data";
                pricedMats = ESIMarketData.GetPriceForItemListWithQuantityAsync(mats, currentBuildPlan.IndustrySettings.InputOrderType, (long)Enums.Enums.TheForgeRegionId).Result;

                foreach (ESIMarketType mat in pricedMats)
                {
                    this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == mat.typeID).pricePer = mat.pricePer;
                }
                ProgressLabel.Text = "Done.";
                BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.finalProductTypeID,
                                                                     this.currentBuildPlan.additionalCosts,
                                                                     this.currentBuildPlan);
                SetSummaryInformation();
                LoadMaterialsPriceTreeView();
                LoadMostExpensiveGridView();
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
                    LoadMostExpensiveGridView();
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

                    BlueprintValueControl BVC = new BlueprintValueControl(bpInfo, false);
                    BVC.StartPosition = FormStartPosition.CenterScreen;
                    if (BVC.ShowDialog() == DialogResult.OK)
                    {
                        bpInfo.ME = (int)BVC.MEUpDown.Value;
                        bpInfo.TE = (int)BVC.TEUpDown.Value;
                        bpInfo.MaxRuns = (int)BVC.MaxRunsUpDown.Value;
                        bpInfo.Manufacture = BVC.MakeItemCheckbox.Checked;
                        bpInfo.React = BVC.MakeItemCheckbox.Checked;
                        isLoading = true;
                        e.Node.Nodes.Clear();
                        TreeNode parentNode = e.Node;
                        BuildChildNodes(bpInfo, ref parentNode);
                        RunCalcs();
                        SaveBuildPlan();
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
                bpInfo.ME = 10;
                bpInfo.TE = 20;
                bpInfo.BlueprintName = "All Blueprints";

                BlueprintValueControl BVC = new BlueprintValueControl(bpInfo, true);
                BVC.StartPosition = FormStartPosition.CenterScreen;
                if (BVC.ShowDialog() == DialogResult.OK)
                {
                    isLoading = true;
                    bpInfo.ME = (int)BVC.MEUpDown.Value;
                    bpInfo.TE = (int)BVC.TEUpDown.Value;
                    bpInfo.MaxRuns = (int)BVC.MaxRunsUpDown.Value;
                    bpInfo.Manufacture = BVC.MakeItemCheckbox.Checked;
                    bool excludeFP = BVC.ExcludeFPCheckbox.Checked;

                    SetAllBlueprintValues(bpInfo.ME, bpInfo.TE, bpInfo.MaxRuns, bpInfo.Manufacture, excludeFP);
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
                this.Cursor = Cursors.WaitCursor;
                BlueprintInfo bpInfo = new BlueprintInfo();
                bpInfo.IsReacted = true;
                bpInfo.MaxRuns = 99999;
                bpInfo.BlueprintName = "All Reactions";

                BlueprintValueControl BVC = new BlueprintValueControl(bpInfo, true);
                BVC.StartPosition = FormStartPosition.CenterScreen;
                if (BVC.ShowDialog() == DialogResult.OK)
                {
                    isLoading = true;
                    bpInfo.MaxRuns = (int)BVC.MaxRunsUpDown.Value;
                    bool excludeFP = BVC.ExcludeFPCheckbox.Checked;
                    SetAllReactionValues(bpInfo.MaxRuns, BVC.MakeItemCheckbox.Checked, excludeFP);
                    SaveBuildPlan();
                    LoadBlueprintStoreTreeView();
                    RunCalcs();
                    isLoading = false;
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void TaxInputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                this.currentBuildPlan.IndustrySettings.TaxInputs = TaxInputCheckbox.Checked;
                SaveBuildPlan();
                SetSummaryInformation();
            }
        }

        private void TaxFinalProductCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                this.currentBuildPlan.IndustrySettings.TaxOutputs = TaxFinalProductCheckbox.Checked;
                SaveBuildPlan();
                SetSummaryInformation();
            }
        }

        private void FinalSellPriceNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (currentBuildPlan != null && !isLoading && FinalSellPriceNumeric.Validate())
            {
                currentBuildPlan.finalSellPrice = FinalSellPriceNumeric.Value;
                SetSummaryInformation();
            }
        }

        private void SummaryHelpPanel_Click(object sender, EventArgs e)
        {
            BuildPlanSummaryHelp buildPlanSummaryHelp = new BuildPlanSummaryHelp();
            buildPlanSummaryHelp.StartPosition = FormStartPosition.CenterParent;
            buildPlanSummaryHelp.ShowDialog();
        }

        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading && !IsResetting)
            {
                this.currentBuildPlan.BuildPlanNotes = NotesTextBox.Text;
            }
        }

        private void ImportPricesButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                DialogResult result = OpenFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    try
                    {
                        string fileName = OpenFileDialog.FileName;
                        string pathEx = Path.GetExtension(fileName);
                        if (pathEx.ToLowerInvariant().Replace(".", "") == "csv")
                        {
                            ImportPrices(fileName);
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid File Type. Expected CSV, Got " + pathEx);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error ocurred during import: " + ex.Message);
                    }
                }
            }
        }

        private void ExportPricesButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                DialogResult result = SaveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    try
                    {
                        string fileName = SaveFileDialog.FileName;
                        string pathEx = Path.GetExtension(fileName);
                        if (pathEx.ToLowerInvariant().Replace(".", "") == "csv")
                        {
                            ExportPrices(fileName);
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid File Type. Expected CSV, Got " + pathEx);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error ocurred during export: " + ex.Message);
                    }
                }
            }
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.Summary);
        }

        private void BPSettingsButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.BPReaction);
        }

        private void SystemButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.SystemStruct);
        }

        private void MaterialsButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.MaterialPrices);
        }

        private void BuildDetailsButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.BuildDetails);
        }

        private void PlanetMaterialsButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.PlanetMats);
        }

        private void CostBreakdownButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.CostBreakdown);
        }

        private void CurrentInventoryButton_Click(object sender, EventArgs e)
        {
            ShowHideTabPage((int)TabPages.CurrentInventory);
        }

        private void CurrentInventoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                if (!IgnoreTextChangedEvent)
                {
                    IgnoreTextChangedEvent = true;
                    string rawInput = CurrentInventoryTextBox.Text;
                    string formattedText = rawInput.Replace("\r\n", "\n").Replace("\n", "\r\n");
                    CurrentInventoryTextBox.Text = formattedText;
                    string[] inputItems = formattedText.Split("\r\n");
                    if (inputItems != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        List<AppraisedItem> appraisedItems = new List<AppraisedItem>();
                        appraisedItems = AppraisalHelper.ParseTypeIds(inputItems);
                        InventoryTypeWithQuantity inventoryType;
                        foreach (AppraisedItem item in appraisedItems)
                        {
                            if (this.currentBuildPlan.CurrentInventory.Find(x => x.typeID == item.typeID) != null)
                            {
                                this.currentBuildPlan.CurrentInventory.Find(x => x.typeID == item.typeID).quantity = item.quantity;
                            }
                        }
                        if (!this.isLoading)
                        {
                            this.isLoading = true;
                            RunCalcs();
                            this.isLoading = false;
                        }
                        SaveBuildPlan();
                        this.Cursor = Cursors.Default;
                    }

                    IgnoreTextChangedEvent = false;
                }
            }
        }

        private void CurrentInventoryGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                SaveBuildPlan();
                if (!this.isLoading)
                {
                    this.isLoading = true;
                    RunCalcs();
                    this.isLoading = false;
                }
            }
        }

        private void CurrentInventoryGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (CurrentInventoryGrid.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CurrentInventoryGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                if (e.ColumnIndex == 1)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ClearInventoryButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                this.currentBuildPlan.CurrentInventory.ForEach(x => x.quantity = 0);
                if (!this.isLoading)
                {
                    this.isLoading = true;
                    RunCalcs();
                    this.isLoading = false;
                }
                SaveBuildPlan();
            }
        }

        private void ExportBuildListButton_Click(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                DialogResult result = SaveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    try
                    {
                        string fileName = SaveFileDialog.FileName;
                        string pathEx = Path.GetExtension(fileName);
                        if (pathEx.ToLowerInvariant().Replace(".", "") == "csv")
                        {
                            StringBuilder sb = new StringBuilder();
                            if (this.currentBuildPlan != null && this.currentBuildPlan.OptimumBuildGroups != null && this.currentBuildPlan.OptimumBuildGroups.Count > 0)
                            {
                                List<int> orderedKeys = this.currentBuildPlan.OptimumBuildGroups.Keys.OrderBy(x => x).ToList();
                                foreach (int key in orderedKeys)
                                {
                                    sb.AppendLine("Build Group: " + key.ToString());
                                    sb.AppendLine("Material Name, Quantity Needed, Runs Needed, Is Complete");

                                    foreach (OptimizedBuild build in this.currentBuildPlan.OptimumBuildGroups[key].OrderBy(x => x.BuiltOrReactedName))
                                    {
                                        sb.AppendLine(build.BuiltOrReactedName + "," + build.TotalQuantityNeeded + "," + build.RunsNeeded + ", False");
                                    }
                                    sb.AppendLine("");
                                }
                            }
                            FileHelper.SaveFileContent(fileName, sb.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid File Type. Expected CSV, Got " + pathEx);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error ocurred during export: " + ex.Message);
                    }
                }
            }

        }

        private void MostProfitableButton_Click(object sender, EventArgs e)
        {
            if (!this.isLoading && this.currentBuildPlan != null)
            {
                DetermineMostProfitableBuild();
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

            if (CommonHelper.SolarSystemList?.Count <= 0)
            {
                FileHelper.LogError("Build Plan Control is loading and solar system count is " + CommonHelper.SolarSystemList?.Count.ToString(), null);
                FileHelper.LogError("Why is this list empty here?", "");
                MessageBox.Show("Balkr, If this is you, I need you to send me the error text file. To do this, go to the file location below, copy the error log text file, and send it to me in discord. \n" + Enums.Enums.ErrorLogDirectory);
            }
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
            FileNames.Clear();
            FileNames.Add(new KeyValuePair<string, string>("", ""));
            string[] directoryFileNames = FileIO.FileHelper.GetFileNamesInDirectory(Enums.Enums.BuildPlanDirectory);


            if (directoryFileNames.Length > 0)
            {
                string comboName = "";
                int lastSlashIndex;
                int lastDotIndex;
                int count = 1;
                foreach (string file in directoryFileNames)
                {
                    lastSlashIndex = file.LastIndexOf('\\');
                    lastDotIndex = file.LastIndexOf(".");
                    comboName = file.Substring(lastSlashIndex + 1, lastDotIndex - 1 - lastSlashIndex);
                    FileNames.Add(new KeyValuePair<string, string>(comboName, file));
                    count++;
                }
            }
            BuildPlanCombo.ValueMember = "Value";
            BuildPlanCombo.DisplayMember = "Key";
            BuildPlanCombo.DataSource = FileNames.ToList<KeyValuePair<string, string>>();
            BuildPlanCombo.SelectedIndex = 0;
        }

        private void SaveBuildPlan()
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(currentBuildPlan);
            string fullFileName = CurrentFileName;
            FileIO.FileHelper.SaveFileContent(Enums.Enums.BuildPlanDirectory, fullFileName, content);
        }

        private void LoadBuildPlanFromFile()
        {
            currentBuildPlan = null;
            string? selectedFileName = (string?)BuildPlanCombo.SelectedValue;
            if (!String.IsNullOrWhiteSpace(selectedFileName))
            {
                CurrentFileName = selectedFileName;
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.BuildPlanDirectory, selectedFileName);
                if (!string.IsNullOrEmpty(content))
                {
                    currentBuildPlan = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.BuildPlan>(content);
                }
            }
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
                EnsureCurrentInventory();

                //Load Blueprint Store
                LoadBlueprintStoreTreeView();

                //Run the calcs
                RunCalcs();

                TaxInputCheckbox.Checked = this.currentBuildPlan.IndustrySettings.TaxInputs;
                TaxFinalProductCheckbox.Checked = this.currentBuildPlan.IndustrySettings.TaxOutputs;
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

        private void EnsureCurrentInventory()
        {
            InventoryTypeWithQuantity foundType;
            if (currentBuildPlan != null)
            {
                if (currentBuildPlan.CurrentInventory == null)
                {
                    currentBuildPlan.CurrentInventory = new List<InventoryTypeWithQuantity>();
                }
                foreach (BlueprintInfo blueprint in currentBuildPlan.BlueprintStore)
                {
                    List<IndustryActivityMaterials> industryActivityMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(blueprint.BlueprintTypeId, Enums.Enums.ActivityManufacturing);
                    if (industryActivityMaterials?.Count > 0)
                    {
                        foreach (IndustryActivityMaterials material in industryActivityMaterials)
                        {
                            foundType = this.currentBuildPlan.CurrentInventory.Find(x => x.typeID == material.materialTypeID);
                            if (foundType == null)
                            {
                                this.currentBuildPlan.CurrentInventory.Add(new InventoryTypeWithQuantity() { typeID = material.materialTypeID, typeName = material.materialName });
                            }
                        }
                    }
                    industryActivityMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(blueprint.BlueprintTypeId, Enums.Enums.ActivityReactions);
                    if (industryActivityMaterials?.Count > 0)
                    {
                        foreach (IndustryActivityMaterials material in industryActivityMaterials)
                        {
                            foundType = this.currentBuildPlan.CurrentInventory.Find(x => x.typeID == material.materialTypeID);
                            if (foundType == null)
                            {
                                this.currentBuildPlan.CurrentInventory.Add(new InventoryTypeWithQuantity() { typeID = material.materialTypeID, typeName = material.materialName });
                            }
                        }
                    }
                }
            }
            this.currentBuildPlan.CurrentInventory = this.currentBuildPlan.CurrentInventory.OrderBy(x => x.typeName).ToList();
        }

        private void LoadProductImage()
        {
            if (!LoadProductImageBackgroundWorker.IsBusy)
            {
                LoadProductImageBackgroundWorker.RunWorkerAsync();
            }
            while (LoadProductImageBackgroundWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }

        private void LoadBasicInfo()
        {
            if (FinalProductType != null)
            {
                ProductLabel.Text = FinalProductType.typeName;
                NotesTextBox.Text = this.currentBuildPlan.BuildPlanNotes;
                DetailsProductLabel.Text = FinalProductType.typeName + " x " + this.currentBuildPlan.TotalOutcome.ToString("N0");
                RunsPerCopyUpDown.Value = this.currentBuildPlan.RunsPerCopy;
                NumberCopiesUpDown.Value = this.currentBuildPlan.NumOfCopies;
                AdditionalCostsNumeric.Value = this.currentBuildPlan.additionalCosts;
                OutcomeQuantityLabel.Text = this.currentBuildPlan.TotalOutcome.ToString("N0");
            }
        }

        private void LoadFinalProductMarketInfo()
        {
            if (!LoadPriceHistoryBGWorker.IsBusy)
            {
                LoadPriceHistoryBGWorker.RunWorkerAsync(FinalProductType.typeId);
            }
            decimal sellOrderPrice = ESIMarketData.GetSellOrderPriceAsync(FinalProductType.typeId, Enums.Enums.TheForgeRegionId).Result;
            decimal buyOrderPrice = ESIMarketData.GetBuyOrderPriceAsync(FinalProductType.typeId, Enums.Enums.TheForgeRegionId).Result;
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
            calculationHelperClass.ResearchSkill = defaultFormValues.ResearchSkill;
            calculationHelperClass.ReactionsSkill = defaultFormValues.ReactionsSkill;
            calculationHelperClass.IndustrySkill = defaultFormValues.IndustrySkill;
            calculationHelperClass.AdvancedIndustrySkill = defaultFormValues.AdvancedIndustrySkill;
            calculationHelperClass.AdvacnedSmallConstructionSkill = defaultFormValues.AdvacnedSmallConstructionSkill;
            calculationHelperClass.AdvacnedMediumConstructionSkill = defaultFormValues.AdvacnedMediumConstructionSkill;
            calculationHelperClass.AdvacnedLargeConstructionSkill = defaultFormValues.AdvacnedLargeConstructionSkill;
            calculationHelperClass.AdvancedCapitalConstructionSkill = defaultFormValues.AdvancedCapitalConstructionSkill;
            calculationHelperClass.CapitalShipConstructionSkill = defaultFormValues.CapitalShipConstructionSkill;
            calculationHelperClass.AdvancedIndustrialConstructionSkill = defaultFormValues.AdvancedIndustrialConstructionSkill;
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
            //Reset before calcs. 
            _CombinedMats = new List<MaterialsWithMarketData>();
            BuildPlanHelper.RunBuildPlanCalcs(ref this.currentBuildPlan, ref _CombinedMats);
            BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                 this.currentBuildPlan.AllItems,
                                                                 this.currentBuildPlan.finalProductTypeID,
                                                                 this.currentBuildPlan.additionalCosts,
                                                                 this.currentBuildPlan);
            LoadUIAfterCalcs();
            SaveBuildPlan();
        }

        private void ResetControls()
        {
            this.IsResetting = true;
            this.SuspendLayout();
            NotesTextBox.Text = string.Empty;
            ProductLabel.Text = string.Empty;
            PriceHistoryControl.DatabindPriceHistory(new List<ESIPriceHistory>());
            JitaBuyLabel.Text = string.Empty;
            JitaSellLabel.Text = string.Empty;
            FinalProductImagePanel.BackgroundImage = null;
            AdditionalCostsNumeric.Value = AdditionalCostsNumeric.Minimum;
            MaterialsTreeView.Nodes.Clear();
            MostExpensiveGridView.DataSource = null;
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
            FinalSellPriceNumeric.Value = FinalSellPriceNumeric.Minimum;
            IskNeededForPlanLabel.Text = CommonHelper.FormatIsk(0);
            ProfitLabel.Text = CommonHelper.FormatIsk(0);
            leftoverMatsValueLabel.Text = CommonHelper.FormatIsk(0);
            this.ResumeLayout();
            this.IsResetting = false;
            ManuSCILabel.Text = "";
            ReactionSCILabel.Text = "";
            CostBreakdownTextBox.Text = "";
            CurrentInventoryGrid.DataSource = null;
        }

        private void CopyInputsToClipboard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            InventoryTypeWithQuantity currentInventory;
            long quantityNeeded = 0;
            foreach (MaterialsWithMarketData mat in _CombinedMats)
            {
                currentInventory = this.currentBuildPlan.CurrentInventory.Find(x => x.typeID == mat.materialTypeID);
                quantityNeeded = mat.quantityTotal;
                if (currentInventory != null)
                {
                    quantityNeeded -= currentInventory.quantity;
                    if (quantityNeeded < 0) { quantityNeeded = 0; }
                }
                if (quantityNeeded > 0)
                {
                    if (!BuildPlanHelper.IsItemMade(currentBuildPlan.BlueprintStore, mat.materialTypeID))
                    {
                        stringBuilder.AppendLine(mat.materialName + " " + quantityNeeded);
                    }
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
                this.ReactionsSkillUpDown.Value = this.currentBuildPlan.IndustrySettings.ReactionsSkill;
                this.ResearchSkillsUpDown.Value = this.currentBuildPlan.IndustrySettings.ResearchSkill;
                this.IndustrySkillUpDown.Value = this.currentBuildPlan.IndustrySettings.IndustrySkill;
                this.AdvIndustryUpDown.Value = this.currentBuildPlan.IndustrySettings.AdvancedIndustrySkill;
                this.CapConSkillUpDown.Value = this.currentBuildPlan.IndustrySettings.CapitalShipConstructionSkill;
                this.AdvSmallSkillUpDown.Value = this.currentBuildPlan.IndustrySettings.AdvacnedSmallConstructionSkill;
                this.AdvMedUpDown.Value = this.currentBuildPlan.IndustrySettings.AdvacnedMediumConstructionSkill;
                this.AdvLargeUpDown.Value = this.currentBuildPlan.IndustrySettings.AdvacnedLargeConstructionSkill;
                this.AdvCapSkillUpDown.Value = this.currentBuildPlan.IndustrySettings.AdvancedCapitalConstructionSkill;
                this.AdvancedIndustrialConsSkillUpDoan.Value = this.currentBuildPlan.IndustrySettings.AdvancedIndustrialConstructionSkill;

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
                    this.currentBuildPlan.IndustrySettings.ReactionsSkill = (Int32)(this.ReactionsSkillUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.ResearchSkill = (Int32)(this.ResearchSkillsUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.IndustrySkill = (Int32)(this.IndustrySkillUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.AdvancedIndustrySkill = (Int32)(this.AdvIndustryUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.CapitalShipConstructionSkill = (Int32)(this.CapConSkillUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.AdvacnedSmallConstructionSkill = (Int32)(this.AdvSmallSkillUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.AdvacnedMediumConstructionSkill = (Int32)(this.AdvMedUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.AdvacnedLargeConstructionSkill = (Int32)(this.AdvLargeUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.AdvancedCapitalConstructionSkill = (Int32)(this.AdvCapSkillUpDown.Value);
                    this.currentBuildPlan.IndustrySettings.AdvancedIndustrialConstructionSkill = (Int32)(this.AdvancedIndustrialConsSkillUpDoan.Value);
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
            List<MaterialsWithMarketData> orderedList;
            TreeNode node;
            StringBuilder sb = new StringBuilder();

            foreach (MaterialsWithMarketData inputMaterial in materialsToBind)
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
                    decimal inputMaterialCostBeforeTax = _CombinedMats.Sum(x => x.priceTotal);
                    decimal totalInputPrice = inputMaterialCostBeforeTax;
                    decimal totalInputTaxes = CommonHelper.CalculateTaxAndFees(totalInputPrice,
                                                                               this.currentBuildPlan.IndustrySettings,
                                                                               this.currentBuildPlan.IndustrySettings.InputOrderType);
                    decimal inputTaxPerItem = totalInputTaxes / optimumBuild.TotalQuantityNeeded;
                    if (!TaxInputCheckbox.Checked)
                    {
                        totalInputTaxes = 0;
                        inputTaxPerItem = 0;
                    }
                    IskNeededForPlanLabel.Text = CommonHelper.FormatIsk(totalInputPrice + totalInputTaxes + totalJobCost + currentBuildPlan.additionalCosts);

                    //Taxes when selling on Market
                    decimal outcomeSellTaxes = CommonHelper.CalculateTaxAndFees(outcomePricePer,
                                                                                this.currentBuildPlan.IndustrySettings,
                                                                                (int)Enums.Enums.OrderType.Sell);

                    decimal outcomeBuyTaxes = CommonHelper.CalculateTaxAndFees(outcomePricePer,
                                                                                this.currentBuildPlan.IndustrySettings,
                                                                                (int)Enums.Enums.OrderType.Buy);
                    if (!TaxFinalProductCheckbox.Checked)
                    {
                        outcomeSellTaxes = 0;
                        outcomeBuyTaxes = 0;
                    }

                    ProductionCostUnitLabel.Text = CommonHelper.FormatIsk(optimumBuild.PricePerItem);

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

                    decimal totalInputVolume = GetTotalVolumeForMaterials(_CombinedMats);
                    InputVolumeLabel.Text = totalInputVolume.ToString("N2") + " m3";

                    ProfitLabel.Text = CommonHelper.FormatIsk(profit);
                    if (profit < 0)
                    {
                        ProfitLabel.ForeColor = System.Drawing.Color.OrangeRed;
                    }
                    else
                    {
                        ProfitLabel.ForeColor = System.Drawing.Color.LightGreen;
                    }

                    SetCostBreakdownTextBox(inputMaterialCostBeforeTax,
                                            totalInputTaxes,
                                            totalJobCost,
                                            inputOrderTypeString,
                                            outputOrderTypeString,
                                            totalOutComeTaxes,
                                            totalOutcomeIskBeforeTax,
                                            outcomePricePer);


                    if (!WasteValueWorker.IsBusy)
                    {
                        WasteValueWorker.RunWorkerAsync(this.currentBuildPlan);
                    }

                    SetSCILabel();
                }
            }
        }

        private void SetSCILabel()
        {
            if (this.currentBuildPlan != null && this.currentBuildPlan.IndustrySettings != null)
            {
                if (this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID > 0)
                {
                    decimal costIndex = CommonHelper.GetCostIndexForSystemID(this.currentBuildPlan.IndustrySettings.ManufacturingSolarSystemID, Enums.Enums.ActivityManufacturing);
                    ManuSCILabel.Text = costIndex.ToString("P2");
                }
                else
                {
                    ManuSCILabel.Text = "";
                }
                if (this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID > 0)
                {
                    decimal costIndex = CommonHelper.GetCostIndexForSystemID(this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID, Enums.Enums.ActivityReactions);
                    ReactionSCILabel.Text = costIndex.ToString("P2");
                }
                else
                {
                    ReactionSCILabel.Text = "";
                }
            }
            else
            {
                ManuSCILabel.Text = "";
                ReactionSCILabel.Text = "";
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
            TreeNode tn;
            _CombinedMats = _CombinedMats.OrderBy(x => x.materialName).ToList();
            MaterialsWithMarketData pricedMat;
            TreeNode marketGroupNode;
            TreeNode pricePer;
            TreeNode priceTotal;
            TreeNode volumeNode;

            Dictionary<string, List<MaterialsWithMarketData>> groupedMaterials = BuildPlanHelper.GroupInputMaterials(_CombinedMats);

            List<KeyValuePair<string, List<MaterialsWithMarketData>>> orderedMats = groupedMaterials.OrderBy(x => x.Key).ToList();
            InventoryTypeWithQuantity currentInventory;
            long quantityNeeded = 0;
            InventoryType inventoryType;
            decimal totalGroupPrice;
            foreach (KeyValuePair<string, List<MaterialsWithMarketData>> inputGroup in orderedMats)
            {
                totalGroupPrice = 0;
                marketGroupNode = new TreeNode();
                marketGroupNode.Text = inputGroup.Key;
                marketGroupNode.ForeColor = Color.White;

                foreach (MaterialsWithMarketData mat in inputGroup.Value.OrderBy(x => x.materialName))
                {
                    quantityNeeded = mat.quantityTotal;
                    inventoryType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                    currentInventory = this.currentBuildPlan.CurrentInventory.Find(x => x.typeID == mat.materialTypeID);
                    if (currentInventory != null)
                    {
                        quantityNeeded -= currentInventory.quantity;
                        if (quantityNeeded < 0) { quantityNeeded = 0; }
                    }
                    pricedMat = this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == mat.materialTypeID);
                    tn = new TreeNode();
                    tn.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(mat);
                    tn.Text = quantityNeeded.ToString("N0") + " x " + mat.materialName + " Needed";
                    tn.Tag = mat.materialTypeID;

                    pricePer = new TreeNode();
                    pricePer.Text = "Price Per: " + CommonHelper.FormatIsk(pricedMat.pricePer);
                    pricePer.ForeColor = Color.White;
                    tn.Nodes.Add(pricePer);

                    priceTotal = new TreeNode();
                    priceTotal.Text = "Price Total: " + CommonHelper.FormatIsk(quantityNeeded * pricedMat.pricePer);
                    priceTotal.ForeColor = Color.White;
                    totalGroupPrice += (quantityNeeded * pricedMat.pricePer);
                    tn.Nodes.Add(priceTotal);

                    decimal volume = inventoryType.volume * mat.quantityTotal;
                    volumeNode = new TreeNode();
                    volumeNode.ForeColor = Color.White;
                    volumeNode.Text = volume.ToString("N2") + " m3";
                    tn.Nodes.Add(volumeNode);

                    marketGroupNode.Nodes.Add(tn);

                }
                marketGroupNode.Text += " - " + CommonHelper.FormatIskShortened(totalGroupPrice);
                MaterialsPriceTreeView.Nodes.Add(marketGroupNode);
            }
        }

        private void LoadMostExpensiveGridView()
        {
            _CombinedMats = _CombinedMats.OrderByDescending(x => x.priceTotal).ToList();
            MostExpensiveGridView.DatabindGridView(_CombinedMats);
        }

        private void LoadPlanetaryMaterialsPage()
        {
            PlanetMaterialsTreeView.Nodes.Clear();
            LoadUniquePlanetMaterials();
            if (UniquePlanetMaterials?.Count > 0)
            {
                LoadPlanetaryTreeView();
            }
        }

        private void LoadCurrentInventoryPage()
        {
            CurrentInventoryGrid.DatabindGridView(this.currentBuildPlan.CurrentInventory);
        }

        private void LoadUniquePlanetMaterials()
        {
            UniquePlanetMaterials = new List<PlanetMaterial>();
            InventoryType invType;
            PlanetMaterial existingMat;
            foreach (MaterialsWithMarketData mat in _CombinedMats)
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
            LoadMostExpensiveGridView();
            LoadDetailsPage(false);
            LoadOptimumBuildSchedule();
            SetSummaryInformation();
            LoadPlanetaryMaterialsPage();
            LoadCurrentInventoryPage();
        }

        private void LoadPlanetaryTreeView()
        {
            PlanetMaterialsTreeView.Nodes.Clear();
            PlanetMatsTotalTreeview.Nodes.Clear();

            UniquePlanetMaterials = UniquePlanetMaterials.OrderBy(x => x.typeName).ToList();

            TreeNode tn;
            List<PlanetMaterial> totalMats = new List<PlanetMaterial>();
            foreach (PlanetMaterial planetMaterial in UniquePlanetMaterials)
            {
                PlanetSchematicsHelper.GetInputsForSchematicRecurseive(planetMaterial);
                tn = BuildTreeViewForPIMatRecursive(planetMaterial);
                PlanetMaterialsTreeView.Nodes.Add(tn);
                AddTotalPlanetMats(planetMaterial, ref totalMats);
            }

            TreeNode P0_Node = new TreeNode();
            P0_Node.Text = "P0";
            TreeNode P1_Node = new TreeNode();
            P1_Node.Text = "P1";
            TreeNode P2_Node = new TreeNode();
            P2_Node.Text = "P2";
            TreeNode P3_Node = new TreeNode();
            P3_Node.Text = "P3";
            TreeNode P4_Node = new TreeNode();
            P4_Node.Text = "P4";
            if (totalMats.Count > 0)
            {
                totalMats = totalMats.OrderBy(x => x.typeName).ToList();
                foreach (PlanetMaterial material in totalMats)
                {
                    tn = BuildTreeViewForPI(material);

                    switch (material.groupID)
                    {
                        case 1042: //Basic Commodities
                            P1_Node.Nodes.Add(tn);
                            break;
                        case 1034: //Refined Commodities
                            P2_Node.Nodes.Add(tn);
                            break;
                        case 1040: //Specialized Commodities
                            P3_Node.Nodes.Add(tn);
                            break;
                        case 1041: //Advanced Commodities
                            P4_Node.Nodes.Add(tn);
                            break;
                        default:
                            P0_Node.Nodes.Add(tn);
                            break;
                    }
                }
                PlanetMatsTotalTreeview.Nodes.Add(P4_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P3_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P2_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P1_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P0_Node);
            }
        }

        private void AddTotalPlanetMats(PlanetMaterial input, ref List<PlanetMaterial> totals)
        {
            if (totals.Find(x => x.typeID == input.typeID) == null)
            {
                totals.Add(input);
            }
            else
            {
                totals.Find(x => x.typeID == input.typeID).quantity += input.quantity;
            }
            if (input.Inputs.Count > 0)
            {
                foreach (PlanetMaterial child in input.Inputs)
                {
                    AddTotalPlanetMats(child, ref totals);
                }
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

        private TreeNode BuildTreeViewForPI(PlanetMaterial planetMaterial)
        {
            TreeNode treeNode = new TreeNode();

            treeNode.Text = planetMaterial.typeName;
            if (planetMaterial.quantity > 0)
            {
                treeNode.Text += " x " + planetMaterial.quantity.ToString("N0");
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

        private void SetAllBlueprintValues(int me, int te, int maxRuns, bool makeItem, bool excludeFP)
        {
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                if (bpInfo.IsManufactured)
                {
                    if (excludeFP && bpInfo.BlueprintTypeId == currentBuildPlan.parentBlueprintOrReactionTypeID)
                    {
                        continue;
                    }
                    this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == bpInfo.ProductTypeId).pricePer = 0;
                    bpInfo.ME = me;
                    bpInfo.TE = te;
                    bpInfo.MaxRuns = maxRuns;
                    bpInfo.Manufacture = makeItem;
                }
            }
        }

        private void SetAllReactionValues(int maxRuns, bool makeItem, bool excludeFP)
        {
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                if (bpInfo.IsReacted)
                {
                    if (excludeFP && bpInfo.BlueprintTypeId == currentBuildPlan.parentBlueprintOrReactionTypeID)
                    {
                        continue;
                    }
                    this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == bpInfo.ProductTypeId).pricePer = 0;
                    bpInfo.MaxRuns = maxRuns;
                    bpInfo.React = makeItem;
                }
            }
        }

        private void ExportPrices(string fileName)
        {
            StringBuilder exportBuilder = new StringBuilder();
            exportBuilder.AppendLine("Type ID, Type Name, Price Per Item, Total Needed");
            _CombinedMats = _CombinedMats.OrderBy(x => x.materialName).ToList();
            MaterialsWithMarketData pricedMat;
            foreach (MaterialsWithMarketData item in _CombinedMats)
            {
                pricedMat = this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == item.materialTypeID);
                exportBuilder.AppendLine(String.Format("{0}, {1}, {2}, {3}",
                                                        item.materialTypeID,
                                                        item.materialName,
                                                        pricedMat.pricePer,
                                                        item.quantityTotal));
            }
            FileHelper.SaveFileContent(fileName, exportBuilder.ToString());
        }

        private void ImportPrices(string fileName)
        {
            string fileContent = FileIO.FileHelper.GetFileContent(fileName);
            if (!string.IsNullOrWhiteSpace(fileContent))
            {
                StringReader sr = new StringReader(fileContent);
                string headerRow = sr.ReadLine();
                string[] splitString = headerRow.Split(",");
                if (splitString.Length != 4)
                {
                    MessageBox.Show("Something ain't right. The first row is not 4 columns. I exported it with three column. Export the prices, change what you need and import again.");
                }
                else
                {
                    StringBuilder errorBuilder = new StringBuilder();
                    string line;
                    int typeID;
                    decimal pricePerItem;
                    MaterialsWithMarketData currentMat;
                    bool priceSet = false;
                    while ((line = sr.ReadLine()) != null)
                    {
                        splitString = line.Split(",");
                        if (splitString.Length == 4)
                        {

                            if (Int32.TryParse(splitString[0], out typeID))
                            {
                                if (decimal.TryParse(splitString[2], out pricePerItem))
                                {
                                    currentMat = this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == typeID); ;
                                    if (currentMat != null)
                                    {
                                        currentMat.pricePer = pricePerItem;
                                        priceSet = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            errorBuilder.AppendLine("Skipping " + line);
                        }
                    }
                    if (priceSet)
                    {
                        BuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.finalProductTypeID,
                                                                     this.currentBuildPlan.additionalCosts,
                                                                     this.currentBuildPlan);
                        LoadMaterialsPriceTreeView();
                        LoadMostExpensiveGridView();
                        SetSummaryInformation();
                        SaveBuildPlan();
                        if (errorBuilder.Length > 0)
                        {
                            MessageBox.Show("Price Import Completed, but errors were encounters." + Environment.NewLine + errorBuilder.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Price Import Completed.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("File is empty. WTF dude.");
            }

        }

        private bool WaitForWorkers()
        {
            if (LoadProductImageBackgroundWorker.IsBusy)
            {
                LoadProductImageBackgroundWorker.CancelAsync();
            }
            if (WasteValueWorker.IsBusy)
            {
                WasteValueWorker.CancelAsync();
            }
            if (LoadPriceHistoryBGWorker.IsBusy)
            {
                LoadPriceHistoryBGWorker.CancelAsync();
            }
            {

            }
            //give it 50ms to cancel the workers. 
            Thread.Sleep(50);
            return true;
        }

        private void ShowHideTabPage(int visibleTabPage)
        {
            BuildPlanTabControl.SelectTab(visibleTabPage);
        }
        #endregion

        #region "Background Workers"
        private void LoadProductImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[]? bpImage = null;
            if (this.currentBuildPlan != null && this.currentBuildPlan.finalProductTypeID > 0)
            {
                if (LoadProductImageBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    bpImage = ESIImageServer.GetImageForType(this.currentBuildPlan.finalProductTypeID, "icon");
                }
            }
            e.Result = bpImage;
        }

        private void LoadProductImageBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
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
        }

        private void EnsurePriceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MaterialsWithMarketData> mats = (List<MaterialsWithMarketData>)e.Argument;
            if (mats?.Count > 0)
            {

            }
            e.Result = mats;
        }

        private void EnsurePriceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
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
        }

        private void EnsurePriceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            decimal currentProgress = (decimal)e.ProgressPercentage / (decimal)100;
            ProgressLabel.Text = "Getting Market Data Progress: " + currentProgress.ToString("P");
        }

        private void WasteValueWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            decimal wasteValue = 0;
            BuildPlan wasteBP = (BuildPlan)(e.Argument);
            if (wasteBP != null)
            {
                foreach (OptimizedBuild optimizedBuild in wasteBP.OptimizedBuilds)
                {
                    if (WasteValueWorker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (optimizedBuild.ExtraOutput > 0)
                        {
                            decimal buyOrderPrice = ESI_Calls.ESIMarketData.GetBuyOrderPriceAsync(optimizedBuild.BuiltOrReactedTypeId, Enums.Enums.TheForgeRegionId).Result;
                            wasteValue += optimizedBuild.ExtraOutput * buyOrderPrice;
                        }
                    }
                }
            }
            e.Result = wasteValue;
        }

        private void WasteValueWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                decimal wasteValue = (decimal)e.Result;
                leftoverMatsValueLabel.Text = CommonHelper.FormatIsk(wasteValue);
            }
        }

        private void LoadPriceHistoryBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int typeId = (int)(e.Argument);
            List<ESIPriceHistory> priceHistory = ScreenHelper.MarketBrowserHelper.GetPriceHistoryForRegionAndType(Enums.Enums.TheForgeRegionId, typeId);
            if (LoadPriceHistoryBGWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            e.Result = priceHistory;
        }

        private void LoadPriceHistoryBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result != null)
            {
                List<ESIPriceHistory> history = (List<ESIPriceHistory>)(e.Result);
                PriceHistoryControl.DatabindPriceHistory(history);
            }
        }

        private void DetermineMostProfitableBuild()
        {
            this.isLoading = true;
            this.Cursor = Cursors.WaitCursor;

            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                bpInfo.React = true;
                bpInfo.Manufacture = true;
            }

            RunCalcs();

            UpdatePricesJitaButton_Click(this, new EventArgs());
            this.Cursor = Cursors.WaitCursor;

            ESIMarketType eSIMarketType = new ESIMarketType();
            BlueprintInfo blueprintInfo = new BlueprintInfo();

            //Need to go in order of build groups. 
            List<int> orderedKeys = this.currentBuildPlan.OptimumBuildGroups.Keys.OrderBy(x => x).ToList();
            int numBuildGroups = orderedKeys.Count;
            int counter = 0;
            int key = 0;
            while (counter < numBuildGroups)
            {
                key = orderedKeys[counter];
                foreach (OptimizedBuild optimizedBuild in this.currentBuildPlan.OptimumBuildGroups[key])
                {
                    if (optimizedBuild.BuiltOrReactedTypeId != FinalProductType.typeId)
                    {
                        eSIMarketType = new ESIMarketType();
                        eSIMarketType.typeID = optimizedBuild.BuiltOrReactedTypeId;
                        eSIMarketType.quantity = optimizedBuild.TotalQuantityNeeded;

                        eSIMarketType = ESIMarketData.GetPriceForITemAndQuantityAsync(eSIMarketType, this.currentBuildPlan.IndustrySettings.InputOrderType, Enums.Enums.TheForgeRegionId).Result;


                        if (eSIMarketType.pricePer > 0 && !eSIMarketType.quntityNeededExceedsMarket)
                        {
                            blueprintInfo = this.currentBuildPlan.BlueprintStore.Find(x => x.ProductTypeId == optimizedBuild.BuiltOrReactedTypeId);
                            if (eSIMarketType.pricePer < optimizedBuild.PricePerItem)
                            {
                                blueprintInfo.Manufacture = false;
                                blueprintInfo.React = false;
                            }
                            else
                            {
                                blueprintInfo.Manufacture = true;
                                blueprintInfo.React = true;
                            }
                        }
                        else
                        {
                            //If there are none on market, or if the amount we need exceeds market volume.
                            blueprintInfo.Manufacture = true;
                            blueprintInfo.React = true;
                        }

                    }
                }

                RunCalcs();

                //If the number of build groups lowered, you need to not increment. 
                //if it didn't, increment.
                if (this.currentBuildPlan.OptimumBuildGroups.Keys.Count < numBuildGroups)
                {
                    orderedKeys = this.currentBuildPlan.OptimumBuildGroups.Keys.OrderBy(x => x).ToList();
                    numBuildGroups = this.currentBuildPlan.OptimumBuildGroups.Keys.Count;
                }
                else
                {
                    counter += 1;
                }
            }


            SaveBuildPlan();
            LoadBlueprintStoreTreeView();

            this.Cursor = Cursors.Default;
            this.isLoading = false;
            MessageBox.Show("Build plan has been updated to be as profitable as possible", "Build Plan Updated"); ;
        }

        #endregion
    }
}
