using EveHelperWF.Database;
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
    public partial class MultiBuildPlansControl : Objects.FormBase
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

        private MultiBuildPlan currentBuildPlan;
        string CurrentFileName;
        private bool isLoading = false;
        private OptimizedBuildDetailsControl DetailsControl;
        private bool PriceInfoSet = true;
        private decimal FinalProductSellOrderPrice;
        private decimal FinalProductBuyOrderPrice;
        private bool IgnoreTextChangedEvent;
        private bool IsResetting;
        BindingList<KeyValuePair<string, string>> FileNames = new BindingList<KeyValuePair<string, string>>();

        //Material List
        private static List<Objects.MaterialsWithMarketData> MaterialList = null;

        #region "Init"
        public MultiBuildPlansControl()
        {
            isLoading = true;
            InitializeComponent();
            BlueprintBrowserHelper.Init();
            MultiBuildPlanHelper.Init();
            LoadIndySettingCombos();
            LoadControl();
            ShowHideTabPage((int)TabPages.Summary);
            isLoading = false;
            BuildPlanDetailsControl.ClearCompletedButton.Click += BuildPlannDetailsControl_ClearCompletedBuilds_Click;
            BuildPlanDetailsControl.OptimizedBuildTreeView.AfterCheck += BuildPLansDetailsControl_OptimizedBuildTreeView_AfterCheck;
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
                    FileIO.FileHelper.DeleteFile(Enums.Enums.MultiBuildPlansDirectory, CurrentFileName);
                    LoadControl();
                }
            }
        }

        private void NewBuildPlanButton_Click(object sender, EventArgs e)
        {
            AddMultiBuildPlanProduct addBuildPlanScreen = new AddMultiBuildPlanProduct(true);
            addBuildPlanScreen.StartPosition = FormStartPosition.CenterScreen;

            if (addBuildPlanScreen.ShowDialog() == DialogResult.OK)
            {
                if (WaitForWorkers())
                {
                    this.currentBuildPlan = new MultiBuildPlan();
                    this.currentBuildPlan.BuildPlanName = addBuildPlanScreen.PlanNameTextBox.Text + ".json";
                    FinalProduct finalProduct = new FinalProduct();
                    finalProduct.finalProductTypeId = (Int32)addBuildPlanScreen.ProductCombo.SelectedValue;
                    InventoryType fpType = CommonHelper.InventoryTypes.Find(x => x.typeId == finalProduct.finalProductTypeId);
                    finalProduct.finalProductTypeName = fpType.typeName;
                    finalProduct.RunsPerCopy = 1;
                    finalProduct.NumOfCopies = 1;
                    finalProduct.blueprintOrReactionTypeId = SQLiteCalls.GetBlueprintByProductTypeID(finalProduct.finalProductTypeId);
                    this.currentBuildPlan.FinalProducts.Add(finalProduct);
                    CurrentFileName = Enums.Enums.MultiBuildPlansDirectory + this.currentBuildPlan.BuildPlanName;
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

        private void IndustrySettings_ValueChanged(object sender, EventArgs e)
        {
            if (this.currentBuildPlan != null && !isLoading)
            {
                this.isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                SaveIndustrySettings();
                RunCalcs();
                this.Cursor = Cursors.Default;
                this.isLoading = false;
            }
        }

        private void BuildPLansDetailsControl_OptimizedBuildTreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Action != TreeViewAction.Unknown)
            {
                int optimizedTypeId = Convert.ToInt32(e.Node.Tag);
                if (optimizedTypeId > 0)
                {
                    if (e.Node.Checked)
                    {
                        if (!this.currentBuildPlan.completedBuilds.Contains(optimizedTypeId))
                        {
                            this.currentBuildPlan.completedBuilds.Add(optimizedTypeId);
                        }
                        else
                        {
                            if (this.currentBuildPlan.completedBuilds.Contains(optimizedTypeId))
                            {
                                this.currentBuildPlan.completedBuilds.Remove(optimizedTypeId);
                            }
                        }
                    }
                }
                BuildPlanDetailsControl.UpdateCompletedBuildsList(this.currentBuildPlan.completedBuilds);
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
                this.currentBuildPlan.CombinedMats.ForEach(x => mats.Add(new ESIMarketType { typeID = x.materialTypeID, quantity = x.quantityTotal }));
                List<ESIMarketType> pricedMats;

                ProgressLabel.Text = "Getting Market Data";
                pricedMats = ESIMarketData.GetPriceForItemListWithQuantityAsync(mats, currentBuildPlan.IndustrySettings.InputOrderType, (long)Enums.Enums.TheForgeRegionId).Result;

                foreach (ESIMarketType mat in pricedMats)
                {
                    this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == mat.typeID).pricePer = mat.pricePer;
                }
                ProgressLabel.Text = "Done.";
                MultiBuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.FinalProducts,
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
                    MultiBuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                              mats,
                                                                              this.currentBuildPlan.FinalProducts,
                                                                              this.currentBuildPlan);
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
                        if ((int)BVC.MakeItemCombo.SelectedValue == 0)
                        {
                            bpInfo.Manufacture = false;
                            bpInfo.React = false;
                        }
                        else if ((int)BVC.MakeItemCombo.SelectedValue == 1)
                        {
                            bpInfo.Manufacture = true;
                            bpInfo.React = true;
                        }
                        if (BVC.StructureProfileCombo.SelectedValue != null)
                        {
                            bpInfo.StructureProfileId = (int)BVC.StructureProfileCombo.SelectedValue;
                        }
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
                    if (BVC.StructureProfileCombo.SelectedValue != null)
                    {
                        bpInfo.StructureProfileId = (int)BVC.StructureProfileCombo.SelectedValue;
                    }
                    bool excludeFP = BVC.ExcludeFPCheckbox.Checked;

                    SetAllBlueprintValues(bpInfo.ME, bpInfo.TE, bpInfo.MaxRuns, (int)BVC.MakeItemCombo.SelectedValue, excludeFP, bpInfo.StructureProfileId);
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
                    SetAllReactionValues(bpInfo.MaxRuns, (int)BVC.MakeItemCombo.SelectedValue, excludeFP, bpInfo.StructureProfileId);
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
            }
        }

        private void MostProfitableButton_Click(object sender, EventArgs e)
        {
            if (!this.isLoading && this.currentBuildPlan != null)
            {
                DetermineMostProfitableBuild();
            }
        }

        private void BuildPlannDetailsControl_ClearCompletedBuilds_Click(object? sender, EventArgs e)
        {
            if (this.currentBuildPlan != null)
            {
                this.currentBuildPlan.completedBuilds?.Clear();
                BuildPlanDetailsControl.LoadDetailsControl(this.currentBuildPlan.OptimizedBuilds,
                                   this.currentBuildPlan.InputMaterials,
                                   this.currentBuildPlan.BlueprintStore,
                                   this.currentBuildPlan.OptimumBuildGroups,
                                   this.currentBuildPlan.completedBuilds);
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
            string[] directoryFileNames = FileIO.FileHelper.GetFileNamesInDirectory(Enums.Enums.MultiBuildPlansDirectory);


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
            FileIO.FileHelper.SaveFileContent(Enums.Enums.MultiBuildPlansDirectory, fullFileName, content);
        }

        private void LoadBuildPlanFromFile()
        {
            currentBuildPlan = null;
            string? selectedFileName = (string?)BuildPlanCombo.SelectedValue;
            if (!String.IsNullOrWhiteSpace(selectedFileName))
            {
                CurrentFileName = selectedFileName;
                string content = FileIO.FileHelper.GetFileContent(Enums.Enums.MultiBuildPlansDirectory, selectedFileName);
                if (!string.IsNullOrEmpty(content))
                {
                    currentBuildPlan = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.MultiBuildPlan>(content);
                }
            }
        }

        private void LoadUIForBuildPlan()
        {
            if (currentBuildPlan != null)
            {
                this.SuspendLayout();
                if (this.currentBuildPlan.CombinedMats == null)
                {
                    RunCalcs();
                }

                //Ensure we have the minimum information to run the calcs
                EnsureCalculationHelperClass();
                EnsureInputMaterials();
                EnsureMinimumRunsAndCopies();
                EnsureBlueprintStore();
                EnsureCurrentInventory();

                //Load Blueprint Store
                LoadBlueprintStoreTreeView();

                TaxInputCheckbox.Checked = this.currentBuildPlan.IndustrySettings.TaxInputs;
                TaxFinalProductCheckbox.Checked = this.currentBuildPlan.IndustrySettings.TaxOutputs;

                LoadProductImage();
                LoadBasicInfo();
                LoadIndySettings();
                LoadFinalProductMarketInfo();
                LoadMaterialsPriceTreeView();
                LoadMostExpensiveGridView();

                //Build Details Load
                MultiBuildPlanHelper.SetControlNames(this.currentBuildPlan.InputMaterials);
                BuildPlanDetailsControl.LoadDetailsControl(this.currentBuildPlan.OptimizedBuilds,
                                   this.currentBuildPlan.InputMaterials,
                                   this.currentBuildPlan.BlueprintStore,
                                   this.currentBuildPlan.OptimumBuildGroups,
                                   this.currentBuildPlan.completedBuilds);

                SetSummaryInformation();
                LoadPlanetaryMaterialsPage();
                LoadCurrentInventoryPage();

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
            bool shouldSave = false;
            foreach (FinalProduct fp in this.currentBuildPlan.FinalProducts)
            {
                //Runs Per Copy minimum
                if (fp.RunsPerCopy <= 0)
                {
                    fp.RunsPerCopy = 1;
                    shouldSave = true;
                }
                //Num Copies Minimum
                if (fp.NumOfCopies <= 0)
                {
                    fp.NumOfCopies = 1;
                    shouldSave = true;
                }
            }
            if (shouldSave) { SaveBuildPlan(); }
        }

        private void EnsureBlueprintStore()
        {
            if (this.currentBuildPlan.BlueprintStore == null)
            {
                this.currentBuildPlan.BlueprintStore = new List<BlueprintInfo>();
            }
            List<BlueprintInfo> bpInfos = this.currentBuildPlan.BlueprintStore;
            if (MultiBuildPlanHelper.BuildBlueprintStore(ref this.currentBuildPlan, currentBuildPlan.InputMaterials))
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
            if (this.currentBuildPlan != null)
            {
                NotesTextBox.Text = this.currentBuildPlan.BuildPlanNotes;
            }
        }

        private void LoadFinalProductMarketInfo()
        {
            foreach (FinalProduct fp in currentBuildPlan.FinalProducts)
            {
                decimal sellOrderPrice = ESIMarketData.GetSellOrderPriceAsync(fp.finalProductTypeId, Enums.Enums.TheForgeRegionId).Result;
                decimal buyOrderPrice = ESIMarketData.GetBuyOrderPriceAsync(fp.finalProductTypeId, Enums.Enums.TheForgeRegionId).Result;
                fp.jitaSellPrice = sellOrderPrice;
                fp.jitaBuyPrice = buyOrderPrice;
            }
        }

        private void EnsureInputMaterials()
        {
            //Only Load this infor the first time. 
            //Once it's been loaded once, the build plan controls take over. 
            if (this.currentBuildPlan != null &&
                    (this.currentBuildPlan.InputMaterials == null || this.currentBuildPlan.InputMaterials.Count == 0))
            {
                foreach (FinalProduct fp in this.currentBuildPlan.FinalProducts)
                {
                    LoadInputMaterialsForProduct(fp.blueprintOrReactionTypeId);
                }
                SaveBuildPlan();

            }
        }

        private void LoadInputMaterialsForProduct(int blueprintOrReactionTypeId)
        {
            List<IndustryActivityMaterials> manufacturingMaterials =
                Database.SQLiteCalls.GetIndustryActivityMaterials(blueprintOrReactionTypeId, Enums.Enums.ActivityManufacturing);
            List<IndustryActivityMaterials> reactionMaterials =
                Database.SQLiteCalls.GetIndustryActivityMaterials(blueprintOrReactionTypeId, Enums.Enums.ActivityReactions);

            this.currentBuildPlan.InputMaterials = new List<MaterialsWithMarketData>();

            foreach (IndustryActivityMaterials material in manufacturingMaterials)
            {
                AddMaterialToInputs(material);

            }
            foreach (IndustryActivityMaterials material in reactionMaterials)
            {
                AddMaterialToInputs(material);
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
            calculationHelperClass.ManufacturingImplantTypeID = defaultFormValues.ManufacturingImplantValue;
            calculationHelperClass.ManufacturingFacilityTax = defaultFormValues.ManufacturingTaxValue;
            calculationHelperClass.ME = (int)defaultFormValues.ManufacturingMEValue;
            calculationHelperClass.TE = (int)defaultFormValues.ManufacturingTEValue;
            calculationHelperClass.CompME = (int)defaultFormValues.CompMEValue;
            calculationHelperClass.CompTE = (int)defaultFormValues.CompTEValue;
            calculationHelperClass.ManufacturingStructureRigBonus = new StructureRigBonus();
            calculationHelperClass.ManufacturingStructureRigBonus.RigMEBonus = defaultFormValues.ManufacturingStructureMERigValue;
            calculationHelperClass.ManufacturingStructureRigBonus.RigTEBonus = defaultFormValues.ManufacturingStructureTERigValue;
            calculationHelperClass.MaxManufacturingTime = defaultFormValues.MaxManufacturingTime;

            //Reactions Values
            calculationHelperClass.ReactionSolarSystemID = defaultFormValues.ReactionsSystemValue;
            calculationHelperClass.ReactionsStructureTypeID = defaultFormValues.ReactionStructureValue;
            calculationHelperClass.ReactionsFacilityTax = defaultFormValues.ReactionTaxValue;
            calculationHelperClass.ReactionStructureRigBonus = new StructureRigBonus();
            calculationHelperClass.ReactionStructureRigBonus.RigMEBonus = defaultFormValues.ReactionStructureMERigValue;
            calculationHelperClass.ReactionStructureRigBonus.RigTEBonus = defaultFormValues.ReactionStructureTERigValue;
            calculationHelperClass.MaxReactionTime = defaultFormValues.MaxReactionTime;

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

            calculationHelperClass.TaxInputs = true;
            calculationHelperClass.TaxOutputs = true;
            return calculationHelperClass;
        }

        private void AddMaterialToInputs(IndustryActivityMaterials material)
        {
            MaterialsWithMarketData currentMat = this.currentBuildPlan.InputMaterials.Find(x => x.materialTypeID == material.materialTypeID);
            if (currentMat == null) 
            { 
                currentMat = new MaterialsWithMarketData();
                currentMat.materialTypeID = material.materialTypeID;
                currentMat.materialName = material.materialName;
                currentMat.Buildable = material.isManufacturable;
                currentMat.Reactable = material.isReactable;
                currentMat.quantity = material.quantity;
                this.currentBuildPlan.InputMaterials.Add(currentMat);
            }
            else
            {
                currentMat.quantity += material.quantity;
            }
        }

        private void RunCalcs()
        {
            //Reset before calcs. 
            this.currentBuildPlan.CombinedMats = new List<MaterialsWithMarketData>();
            List<MaterialsWithMarketData> localMats = new List<MaterialsWithMarketData>();
            MultiBuildPlanHelper.RunBuildPlanCalcs(ref this.currentBuildPlan, ref localMats);
            this.currentBuildPlan.CombinedMats = localMats;
            MultiBuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                 this.currentBuildPlan.AllItems,
                                                                 this.currentBuildPlan.FinalProducts,
                                                                 this.currentBuildPlan);
            LoadUIForBuildPlan();
            SaveBuildPlan();
        }

        private void ResetControls()
        {
            this.IsResetting = true;
            this.SuspendLayout();
            NotesTextBox.Text = string.Empty;
            BPTreeView.Nodes.Clear();
            FinalProductGridView.DataSource = null;
            MaterialsPriceTreeView.Nodes.Clear();
            MostExpensiveGridView.DataSource = null;
            this.ResumeLayout();
            this.IsResetting = false;
            CurrentInventoryGrid.DataSource = null;
            TotalPlanCostLabel.Text = "";

            BuildPlanDetailsControl.ResetControls();
            BuildPlanPlanetMaterialsControl.ResetControl();
        }

        private void CopyInputsToClipboard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            InventoryTypeWithQuantity currentInventory;
            long quantityNeeded = 0;
            foreach (MaterialsWithMarketData mat in this.currentBuildPlan.CombinedMats)
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
                    if (!MultiBuildPlanHelper.IsItemMade(currentBuildPlan.BlueprintStore, mat.materialTypeID))
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
                this.MaxManufacturingTimeUpDown.Value = this.currentBuildPlan.IndustrySettings.MaxManufacturingTime;

                //Reactions
                this.ReactionSolarSystemCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID;
                this.ReactionStructureCombo.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID;
                this.ReactionTaxUpDown.Value = this.currentBuildPlan.IndustrySettings.ReactionsFacilityTax;
                this.ReactionStructureMERig.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus;
                this.ReactionStructureTERig.SelectedValue = this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus;
                this.MaxReactionTimeUpDown.Value = this.currentBuildPlan.IndustrySettings.MaxReactionTime;

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
                    this.currentBuildPlan.IndustrySettings.MaxManufacturingTime = (Int32)(this.MaxManufacturingTimeUpDown.Value);
                    break;
                case 1:
                    this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID = (Int32)(this.ReactionSolarSystemCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionSolarSystemID);
                    this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID = (Int32)(this.ReactionStructureCombo.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionsStructureTypeID);
                    this.currentBuildPlan.IndustrySettings.ReactionsFacilityTax = (decimal)this.ReactionTaxUpDown.Value;
                    this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus = (Int32)(this.ReactionStructureMERig.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigMEBonus);
                    this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus = (Int32)(this.ReactionStructureTERig.SelectedValue ?? this.currentBuildPlan.IndustrySettings.ReactionStructureRigBonus.RigTEBonus);
                    this.currentBuildPlan.IndustrySettings.MaxReactionTime = (Int32)(this.MaxReactionTimeUpDown.Value);
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

        private void SetSummaryInformation()
        {
            if (this.currentBuildPlan != null)
            {
                InventoryType invType = null;
                decimal totalPlanCost = 0;
                foreach (FinalProduct fp in currentBuildPlan.FinalProducts)
                {
                    invType = CommonHelper.InventoryTypes.Find(x => x.typeId == fp.finalProductTypeId);
                    fp.totalOutcomeVolume = fp.TotalOutcome * invType.volume;
                    OptimizedBuild optimumBuild = this.currentBuildPlan.OptimizedBuilds.Find(x => x.BuiltOrReactedTypeId == fp.finalProductTypeId);
                    if (optimumBuild != null)
                    {
                        decimal totalJobCost = 0;
                        this.currentBuildPlan.OptimizedBuilds.ForEach(x => totalJobCost += x.JobCost);
                        decimal outcomePricePer = fp.customSellPrice;
                        if (outcomePricePer <= 0)
                        {
                            if (this.currentBuildPlan.IndustrySettings.OutputOrderType == (int)(Enums.Enums.OrderType.Sell))
                            {
                                outcomePricePer = fp.jitaSellPrice;
                            }
                            else
                            {
                                outcomePricePer = fp.jitaBuyPrice;
                            }
                        }

                        //Taxes when selling on Market
                        decimal outcomeSellTaxes = CommonHelper.CalculateTaxAndFees(outcomePricePer,
                                                                                   (int)(Enums.Enums.OrderType.Sell),
                                                                                   this.currentBuildPlan.IndustrySettings.AccountingSkill,
                                                                                   this.currentBuildPlan.IndustrySettings.BrokersSkill);

                        decimal outcomeBuyTaxes = CommonHelper.CalculateTaxAndFees(outcomePricePer,
                                                                                   (int)(Enums.Enums.OrderType.Buy),
                                                                                   this.currentBuildPlan.IndustrySettings.AccountingSkill,
                                                                                   this.currentBuildPlan.IndustrySettings.BrokersSkill);
                        if (!TaxFinalProductCheckbox.Checked)
                        {
                            outcomeSellTaxes = 0;
                            outcomeBuyTaxes = 0;
                        }

                        fp.CostPerItem = optimumBuild.PricePerItem;

                        decimal totalCostPerItem = optimumBuild.PricePerItem;
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

                        fp.profit = profit;
                        totalPlanCost += (fp.TotalRuns * fp.CostPerItem);
                    }
                }
                TotalPlanCostLabel.Text = $"Total Plan Cost: {CommonHelper.FormatIsk(totalPlanCost)}";
                FinalProductGridView.DatabindGridView(this.currentBuildPlan.FinalProducts);
            }
        }

        private void LoadMaterialsPriceTreeView()
        {
            MaterialsPriceTreeView.Nodes.Clear();
            TreeNode tn;
            this.currentBuildPlan.CombinedMats = this.currentBuildPlan.CombinedMats.OrderBy(x => x.materialName).ToList();
            MaterialsWithMarketData pricedMat;
            TreeNode marketGroupNode;
            TreeNode pricePer;
            TreeNode priceTotal;
            TreeNode volumeNode;

            Dictionary<string, List<MaterialsWithMarketData>> groupedMaterials = MultiBuildPlanHelper.GroupInputMaterials(this.currentBuildPlan.CombinedMats);

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
                    tn.ForeColor = MultiBuildPlanHelper.GetForeColorForMaterialCategory(mat);
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
            this.currentBuildPlan.CombinedMats = this.currentBuildPlan.CombinedMats.OrderByDescending(x => x.priceTotal).ToList();
            MostExpensiveGridView.DatabindGridView(this.currentBuildPlan.CombinedMats);
        }

        private void LoadPlanetaryMaterialsPage()
        {
            BuildPlanPlanetMaterialsControl.LoadPlanetMaterialsControl(this.currentBuildPlan.CurrentInventory, this.currentBuildPlan.CombinedMats);
        }

        private void LoadCurrentInventoryPage()
        {
            CurrentInventoryGrid.DatabindGridView(this.currentBuildPlan.CurrentInventory);
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
            fpNode.Text = "Final Products";
            fpNode.Expand();

            foreach (FinalProduct fp in currentBuildPlan.FinalProducts)
            {

                BlueprintInfo BPInfo = currentBuildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == fp.blueprintOrReactionTypeId);
                TreeNode productNode = new TreeNode();
                productNode.Text = BPInfo.BlueprintName;
                productNode.Tag = BPInfo.BlueprintTypeId;
                if (BPInfo.IsManufactured)
                {
                    TreeNode MENode = new TreeNode();
                    MENode.Text = "ME: " + BPInfo.ME;
                    productNode.Nodes.Add(MENode);

                    TreeNode TENode = new TreeNode();
                    TENode.Text = "TE: " + BPInfo.TE;
                    productNode.Nodes.Add(TENode);
                }
                if (BPInfo.StructureProfileId > 0)
                {

                    ComboListItem profile = MultiBuildPlanHelper.GetStructureProfileComboItems().Find(x => x.key == BPInfo.StructureProfileId);
                    if (profile != null)
                    {
                        productNode.Nodes.Add("Structure Profile: " + profile.value);
                    }
                }
                fpNode.Nodes.Add(productNode);
            }
            BPTreeView.Nodes.Add(fpNode);
        }

        private void LoadManufcaturingNodes()
        {

            List<BlueprintInfo> manufacturingBPs = this.currentBuildPlan.BlueprintStore.FindAll(x => x.IsManufactured);

            if (manufacturingBPs.Count > 0)
            {
                manufacturingBPs = manufacturingBPs.OrderBy(x => x.BlueprintName).ToList();
                TreeNode manufactureNode = new TreeNode();
                manufactureNode.Text = "Blueprints";
                TreeNode manuNode;
                FinalProduct fp = null;
                foreach (BlueprintInfo bp in manufacturingBPs)
                {
                    fp = currentBuildPlan.FinalProducts.Find(x => x.blueprintOrReactionTypeId == bp.BlueprintTypeId);
                    if (fp == null)
                    {
                        manuNode = new TreeNode();
                        manuNode.Tag = bp.BlueprintTypeId;
                        manuNode.Text = bp.BlueprintName;
                        manuNode.Name = bp.BlueprintTypeId.ToString();

                        BuildChildNodes(bp, ref manuNode);
                        manufactureNode.Nodes.Add(manuNode);
                    }
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
            if (bpInfo.StructureProfileId > 0)
            {
                ComboListItem profile = MultiBuildPlanHelper.GetStructureProfileComboItems().Find(x => x.key == bpInfo.StructureProfileId);
                if (profile != null)
                {
                    parentNode.Nodes.Add("Structure Profile: " + profile.value);
                }
            }
        }

        private void LoadReactionNodes()
        {
            List<BlueprintInfo> reactions = this.currentBuildPlan.BlueprintStore.FindAll(x => x.IsReacted);

            if (reactions.Count > 0)
            {
                reactions = reactions.OrderBy(x => x.BlueprintName).ToList();
                TreeNode ReactionsNode = new TreeNode();
                ReactionsNode.Text = "Reactions";
                TreeNode reactionNode;
                FinalProduct fp = null;
                foreach (BlueprintInfo bp in reactions)
                {
                    fp = currentBuildPlan.FinalProducts.Find(x => x.blueprintOrReactionTypeId == bp.BlueprintTypeId);
                    if (fp == null)
                    {
                        reactionNode = new TreeNode();
                        reactionNode.Tag = bp.BlueprintTypeId;
                        reactionNode.Text = bp.BlueprintName;
                        reactionNode.Name = bp.BlueprintTypeId.ToString();

                        BuildChildNodes(bp, ref reactionNode);

                        ReactionsNode.Nodes.Add(reactionNode);
                    }
                }
                BPTreeView.Nodes.Add(ReactionsNode);
            }
        }

        private void SetAllBlueprintValues(int me, int te, int maxRuns, int makeItemSelection, bool excludeFP, int structureProfileId)
        {
            FinalProduct fp = null;
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                if (bpInfo.IsManufactured)
                {
                    fp = currentBuildPlan.FinalProducts.Find(x => x.blueprintOrReactionTypeId == bpInfo.BlueprintTypeId);
                    if (excludeFP && fp != null)
                    {
                        continue;
                    }
                    this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == bpInfo.ProductTypeId).pricePer = 0;
                    bpInfo.ME = me;
                    bpInfo.TE = te;
                    bpInfo.MaxRuns = maxRuns;
                    bpInfo.StructureProfileId = structureProfileId;
                    if (makeItemSelection == 0)
                    {
                        bpInfo.Manufacture = false;
                    }
                    else if (makeItemSelection == 1)
                    {
                        bpInfo.Manufacture = true;
                    }
                }
            }
        }

        private void SetAllReactionValues(int maxRuns, int makeItemSelection, bool excludeFP, int structureProfileId)
        {
            FinalProduct fp = null;
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                if (bpInfo.IsReacted)
                {
                    bpInfo.StructureProfileId = structureProfileId;
                    fp = currentBuildPlan.FinalProducts.Find(x => x.blueprintOrReactionTypeId == bpInfo.BlueprintTypeId);
                    if (excludeFP && fp != null)
                    {
                        continue;
                    }
                    this.currentBuildPlan.AllItems.Find(x => x.materialTypeID == bpInfo.ProductTypeId).pricePer = 0;
                    bpInfo.MaxRuns = maxRuns;
                    if (makeItemSelection == 0)
                    {
                        bpInfo.React = false;
                    }
                    else if (makeItemSelection == 1)
                    {
                        bpInfo.React = true;
                    }
                }
            }
        }

        private void ExportPrices(string fileName)
        {
            StringBuilder exportBuilder = new StringBuilder();
            exportBuilder.AppendLine("Type ID, Type Name, Price Per Item, Total Needed");
            this.currentBuildPlan.CombinedMats = this.currentBuildPlan.CombinedMats.OrderBy(x => x.materialName).ToList();
            MaterialsWithMarketData pricedMat;
            foreach (MaterialsWithMarketData item in this.currentBuildPlan.CombinedMats)
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
                        MultiBuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.FinalProducts,
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
            //if (this.currentBuildPlan != null && this.currentBuildPlan.finalProductTypeID > 0)
            //{
            //    if (LoadProductImageBackgroundWorker.CancellationPending)
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        bpImage = ESIImageServer.GetImageForType(this.currentBuildPlan.finalProductTypeID, "icon");
            //    }
            //}
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
                    imageSet = true;
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
                MultiBuildPlanHelper.SetPriceInformationOnOptimizedBuilds(this.currentBuildPlan.OptimizedBuilds,
                                                                     this.currentBuildPlan.AllItems,
                                                                     this.currentBuildPlan.FinalProducts,
                                                                     this.currentBuildPlan);
                SaveBuildPlan();
                this.PriceInfoSet = true;
                ProgressLabel.Text = "";
                LoadUIForBuildPlan();
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
            }
        }

        private void DetermineMostProfitableBuild()
        {
            this.isLoading = true;
            this.Cursor = Cursors.WaitCursor;

            ProgressLabel.Text = "Setting all BP's/Reactions to build = true";
            foreach (BlueprintInfo bpInfo in this.currentBuildPlan.BlueprintStore)
            {
                bpInfo.React = true;
                bpInfo.Manufacture = true;
            }
            ProgressLabel.Text = "Running calcs with build all = true";

            RunCalcs();

            ProgressLabel.Text = "Done running calcs with build all = true";

            ProgressLabel.Text = "Updating all prices with jata value";
            UpdatePricesJitaButton_Click(this, new EventArgs());
            this.Cursor = Cursors.WaitCursor;

            ESIMarketType eSIMarketType = new ESIMarketType();
            BlueprintInfo blueprintInfo = new BlueprintInfo();

            //Need to go in order of build groups. 
            List<int> orderedKeys = this.currentBuildPlan.OptimumBuildGroups.Keys.OrderBy(x => x).ToList();
            int numBuildGroups = orderedKeys.Count;
            int counter = 0;
            int key = 0;
            ProgressLabel.Text = "Running optimum build calcs";
            while (counter < numBuildGroups)
            {
                key = orderedKeys[counter];
                FinalProduct fp = null;
                foreach (OptimizedBuild optimizedBuild in this.currentBuildPlan.OptimumBuildGroups[key])
                {
                    ProgressLabel.Text = $"Processing build group {key} / {numBuildGroups}";
                    fp = this.currentBuildPlan.FinalProducts.Find(x => x.blueprintOrReactionTypeId == optimizedBuild.BlueprintOrReactionTypeID);
                    if (fp == null)
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


            ProgressLabel.Text = "Optimum Build Determined. Updating Build Plan";
            LoadBlueprintStoreTreeView();

            this.Cursor = Cursors.Default;
            this.isLoading = false;
            ProgressLabel.Text = "";
            MessageBox.Show("Build plan has been updated to be as profitable as possible", "Build Plan Updated"); ;
        }

        #endregion

        private void AddFinalProductButton_Click(object sender, EventArgs e)
        {
            AddMultiBuildPlanProduct addProducctScren = new AddMultiBuildPlanProduct(false);
            addProducctScren.ShowDialog();

            if (addProducctScren.DialogResult == DialogResult.OK)
            {
                int productTypeId = (int)addProducctScren.ProductCombo.SelectedValue;
                FinalProduct fp = currentBuildPlan.FinalProducts.Find(x => x.finalProductTypeId == productTypeId);
                InventoryType finalProduct;
                if (fp == null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    finalProduct = CommonHelper.InventoryTypes.Find(x => x.typeId == productTypeId);
                    fp = new FinalProduct();
                    fp.finalProductTypeId = productTypeId;
                    fp.blueprintOrReactionTypeId = SQLiteCalls.GetBlueprintByProductTypeID(productTypeId);
                    fp.RunsPerCopy = 1;
                    fp.NumOfCopies = 1;
                    fp.finalProductTypeName = finalProduct.typeName;
                    this.currentBuildPlan.FinalProducts.Add(fp);
                    LoadInputMaterialsForProduct(fp.blueprintOrReactionTypeId);
                    MultiBuildPlanHelper.BuildBlueprintStore(ref this.currentBuildPlan, this.currentBuildPlan.InputMaterials);

                    RunCalcs();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("You are already building this product", "Product Exists");
                }
            }
        }

        private void EditFinalProductButton_Click(object sender, EventArgs e)
        {
            if (currentBuildPlan != null)
            {
                if (FinalProductGridView.SelectedRows?.Count > 0)
                {
                    FinalProduct fp = this.currentBuildPlan.FinalProducts[FinalProductGridView.SelectedRows[0].Index];
                    EditMultiBuildPlanProduct editScreen = new EditMultiBuildPlanProduct(fp);
                    editScreen.StartPosition = FormStartPosition.CenterScreen;
                    editScreen.ShowDialog();

                    if (editScreen.DialogResult == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        RunCalcs();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void DeleteFinalProduct_Click(object sender, EventArgs e)
        {
            if (currentBuildPlan != null)
            {
                if (FinalProductGridView.SelectedRows?.Count > 0)
                {
                    FinalProduct fp = this.currentBuildPlan.FinalProducts[FinalProductGridView.SelectedRows[0].Index];
                    if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.currentBuildPlan.FinalProducts.Remove(fp);
                        
                        this.Cursor = Cursors.WaitCursor;
                        RunCalcs();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }
    }
}
