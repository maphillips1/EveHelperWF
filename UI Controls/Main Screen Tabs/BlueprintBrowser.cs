using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using EveHelperWF.UI_Controls.Support_Screens;
using System.Diagnostics;
using System.Text;

namespace EveHelperWF
{
    public partial class BlueprintBrowser : Objects.FormBase
    {
        #region "Static Variables"
        private const string CachedFormValuesFileName = "form_values.json";
        private static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();

        private static Objects.InventoryType SelectedType = null;
        private static List<Objects.IndustryActivityTypes> IndustryActivityTypes = null;

        private static List<Objects.IndustryActivitySkill> ManuSkills = null;
        private static List<Objects.IndustryActivitySkill> ResMESkills = null;
        private static List<Objects.IndustryActivitySkill> ResTESkills = null;
        private static List<Objects.IndustryActivitySkill> CopySkills = null;
        private static List<Objects.IndustryActivitySkill> InventionSkills = null;
        private static List<Objects.IndustryActivitySkill> ReactionSkills = null;

        private static List<Objects.MaterialsWithMarketData> ManuMats = null;
        private static List<Objects.MaterialsWithMarketData> ResMEMats = null;
        private static List<Objects.MaterialsWithMarketData> ResTEMats = null;
        private static List<Objects.MaterialsWithMarketData> CopyMats = null;
        private static List<Objects.MaterialsWithMarketData> InventionMats = null;
        private static List<Objects.MaterialsWithMarketData> ReactionMats = null;

        private static List<Objects.IndustryActivityProduct> ManuProds = null;
        private static List<Objects.IndustryActivityProduct> ResMEProds = null;
        private static List<Objects.IndustryActivityProduct> ResTEProds = null;
        private static List<Objects.IndustryActivityProduct> CopyProds = null;
        private static List<Objects.IndustryActivityProduct> InventionProds = null;
        private static List<Objects.IndustryActivityProduct> ReactionProds = null;

        //Time
        private static Int64 ManufacturingTotalTime = 0;
        private static Int64 ReactionTotalTime = 0;
        private static Int64 InventionTotalTime = 0;
        private static Int64 ResMETime = 0;
        private static Int64 ResTETime = 0;
        private static Int64 ResCopyTime = 0;
        //Component Time
        private static Int64 ManufacturingTotalComponentTime = 0;
        //Input Price
        private static decimal ManufacturingTotalInputPrice = 0;
        private static decimal ReactionTotalInputPrice = 0;
        private static decimal InventionTotalInputPrice = 0;
        private static decimal METotalInputPrice = 0;
        private static decimal TETotalInputPrice = 0;
        private static decimal CopyingTotalInputPrice = 0;
        //Run Time
        private static Int64 TotalManufacturingJobTime = 0;
        private static Int64 TotalReactionJobTime = 0;
        private static Int64 TotalInventionJobTime = 0;
        //Job Cost
        private static Decimal TotalManufacturingJobCost = 0;
        private static Decimal TotalReactionJobCost = 0;
        private static Decimal TotalInventionJobCost = 0;
        private static decimal TotalMEJobCost = 0;
        private static decimal TotalTEJobCost = 0;
        private static decimal TotalCopyJobCost = 0;
        //Output Price
        private static Decimal TotalManufacturingOutputPrice = 0;
        private static Decimal TotalReactionOutputPrice = 0;
        //Input Volume
        private static Decimal TotalManufacturingInputVolume = 0;
        private static Decimal TotalReactionInputVolume = 0;
        private static Decimal TotalInventionInputVolume = 0;
        private static decimal TotalMEInputVolume = 0;
        private static decimal TotalTEInputVolume = 0;
        private static decimal TotalCopyInputVolume = 0;
        //Output Volume
        private static Decimal TotalManufacturingOutputVolume = 0;
        private static Decimal TotalReactionOutputVolume = 0;
        private static Decimal TotalInventionOutputVolume = 0;
        //Outcome Quantity
        private static int TotalOutcomeQuantityManufacturing = 0;
        private static int TotalReactionOutcomeQuantity = 0;
        private static int TotalInventionOutcomeQuantity = 0;
        //Taxes and Fees
        private static Decimal TotalManufacturingTaxesAndFees = 0;
        private static Decimal TotalReactionTaxesAndFees = 0;
        private static Decimal TotalInventionTaxesAndFees = 0;
        private static decimal TotalMETaxesAndFees = 0;
        private static decimal TotalTETaxesAndFees = 0;
        private static decimal TotalCopyTaxesAndFees = 0;

        //Invention Specific
        private static Decimal FinalInventionProbability = 0;
        private static int InventionRuns = 0;
        private static int InventionME = 0;
        private static int InventionTE = 0;
        private static bool IsInit = true;
        private static decimal TotalInventionInputCost;

        //Images
        private static byte[] BlueprintImage = null;
        private static byte[] ManufacturingImage = null;

        //Ignore Event
        private static bool IgnoreChangedEvent = false;
        #endregion

        #region "MAIN"
        public BlueprintBrowser()
        {
            IsInit = true;
            InitializeComponent();
            ScreenHelper.BlueprintBrowserHelper.Init();
            LoadUpDowns();
            LoadCombos();
            BuildTreeView();
            LoadDefaultFormValues();
            ResetSummaryLabel();

            IsInit = false;
        }
        #endregion

        #region "Initial Data Loading"
        private void BuildTreeView()
        {
            List<TreeNode> list = ScreenHelper.BlueprintBrowserHelper.BuildBlueprintTreeView();
            TreeViewList.Nodes.Clear();
            list.ForEach(x => TreeViewList.Nodes.Add(x));
            TreeViewList.Sort();
        }

        private void LoadCombos()
        {
            LoadPriceTypeCombos();
            LoadSolarSystemCombos();
            LoadStructureCombos();
            LoadImplantCombos();
            LoadStructureRigCombos();
            LoadDecryptorCombo();
            InventionOutcomeBPCombo.DisplayMember = "Value";
            InventionOutcomeBPCombo.ValueMember = "Key";
        }

        private void LoadDefaultFormValues()
        {
            string combinedFileName = string.Concat(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
            string content = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedFormValuesDirectory, combinedFileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                DefaultFormValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.DefaultFormValue>(content);
                if (DefaultFormValues != null)
                {
                    SetDefaultFormValue();
                    ShowHideFieldsForStructureType();
                }
            }
        }

        private void SetDefaultFormValue()
        {
            //Main
            if (DefaultFormValues.RunsUpDownValue > 0)
            {
                RunsUpDown.Value = DefaultFormValues.RunsUpDownValue;
            }
            InputTypeCombo.SelectedValue = DefaultFormValues.InputTypeComboValue;
            OutputTypeCombo.SelectedValue = DefaultFormValues.OutputTypeComboValue;
            SetManufacturingDefaultValues();
            SetReactionDefaultValues();
            SetInventionDefaultValues();
            SetDefaultCopyValues();
            SetDefaultMEValues();
            SetDefaultTEValues();
        }

        private void SetManufacturingDefaultValues()
        {
            ManuMEUpDown.Value = DefaultFormValues.ManufacturingMEValue;
            ManuTEUpDown.Value = DefaultFormValues.ManufacturingTEValue;
            ManuTaxUpDown.Value = DefaultFormValues.ManufacturingTaxValue;
            ManuSystemCombo.SelectedValue = DefaultFormValues.ManufacturingSystemValue;
            ManuStructCombo.SelectedValue = DefaultFormValues.ManufacturingStructureValue;
            ManuRigMEBonusCombo.SelectedValue = DefaultFormValues.ManufacturingStructureMERigValue;
            ManuRigTEBonusCombo.SelectedValue = DefaultFormValues.ManufacturingStructureTERigValue;
            ManuImplantCombo.SelectedValue = DefaultFormValues.ManufacturingImplantValue;
            BuildComponentsCheckbox.Checked = DefaultFormValues.BuildComponentsValue;
            CompMEUpDown.Value = DefaultFormValues.CompMEValue;
            CompTEUpDown.Value = DefaultFormValues.CompTEValue;
            ManuInventDecryptorCombo.SelectedValue = DefaultFormValues.InventionDecryptorValue;
            InventBlueprintCheckbox.Checked = DefaultFormValues.InventBlueprintCheckboxValue;
        }

        private void SetReactionDefaultValues()
        {
            ReactionSolarSystemCombo.SelectedValue = DefaultFormValues.ReactionsSystemValue;
            ReactionStructureCombo.SelectedValue = DefaultFormValues.ReactionStructureValue;
            ReactionStructureMERig.SelectedValue = DefaultFormValues.ReactionStructureMERigValue;
            ReactionStructureTERig.SelectedValue = DefaultFormValues.ReactionStructureTERigValue;
            ReactionTaxUpDown.Value = DefaultFormValues.ReactionTaxValue;
        }

        private void SetInventionDefaultValues()
        {
            InventionSolarSystemCombo.SelectedValue = DefaultFormValues.InventionSystemValue;
            InventionStructureCombo.SelectedValue = DefaultFormValues.InventionStructureValue;
            InventionStructureCostRigCombo.SelectedValue = DefaultFormValues.InventionStructureCostRigValue;
            InventionStructureTimeRigCombo.SelectedValue = DefaultFormValues.InventionStructureTimeRigValue;
            InventionTaxUpDown.Value = DefaultFormValues.InventionTaxValue;
            InventionDecryptorCombo.SelectedValue = DefaultFormValues.InventionDecryptorValue;
            DataCore1SkillUpDown.Value = DefaultFormValues.Datacore1SkillLevel;
            Datacore2SkillUpDown.Value = DefaultFormValues.Datacore2SkillLevel;
            EncryptionStarshipSkillUpDown.Value = DefaultFormValues.EncryptionStarshipSkillLevel;
        }

        private void SetDefaultCopyValues()
        {
            CopyNumCopiesUpDown.Value = DefaultFormValues.CopyNumCopies;
            CopyRunsCopyUpDown.Value = DefaultFormValues.CopyRunsCopy;
            CopySystemCombo.SelectedValue = DefaultFormValues.CopySystemID;
            CopyStructureCombo.SelectedValue = DefaultFormValues.CopyStructureTypeId;
            CopyTimeRigCombo.SelectedValue = DefaultFormValues.CopyStructureRig;
            CopyTaxUpDown.Value = DefaultFormValues.CopyTax;
            CopyImplantCombo.SelectedValue = DefaultFormValues.CopyImplantTypeID;
        }

        private void SetDefaultMEValues()
        {
            MEFromLevelUpDown.Value = DefaultFormValues.MEFromLevel;
            METoLevelUpDown.Value = DefaultFormValues.METoLevel;
            MESystemCombo.SelectedValue = DefaultFormValues.MESystemID;
            MEStructureCombo.SelectedValue = DefaultFormValues.MEStructureTypeID;
            METimeRigCombo.SelectedValue = DefaultFormValues.MEStructureRIg;
            METaxUpDown.Value = DefaultFormValues.METax;
            MEImplantCombo.SelectedValue = DefaultFormValues.MEImplantTypeID;
        }

        private void SetDefaultTEValues()
        {
            TEFromLevelUpDown.Value = DefaultFormValues.TEFromLevel;
            TEToLevelUpDown.Value = DefaultFormValues.TEToLevel;
            TESystemCombo.SelectedValue = DefaultFormValues.TESystemID;
            TEStructureCombo.SelectedValue = DefaultFormValues.TEStructureTypeID;
            TEStructRigCombo.SelectedValue = DefaultFormValues.TEStructureRIg;
            TETaxUpDown.Value = DefaultFormValues.TETax;
            TEImplantCombo.SelectedValue = DefaultFormValues.TEImplantTypeID;
        }

        #region "Combo Load Methods"

        private void LoadPriceTypeCombos()
        {
            InputTypeCombo.BindingContext = new BindingContext();
            InputTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetPriceTypeComboItems();
            InputTypeCombo.DisplayMember = "Value";
            InputTypeCombo.ValueMember = "Key";
            InputTypeCombo.SelectedValue = 1;

            OutputTypeCombo.BindingContext = new BindingContext();
            OutputTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetPriceTypeComboItems();
            OutputTypeCombo.DisplayMember = "Value";
            OutputTypeCombo.ValueMember = "Key";
            OutputTypeCombo.SelectedValue = 2;
        }

        private void LoadSolarSystemCombos()
        {
            ManuSystemCombo.BindingContext = new BindingContext();
            ManuSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            ManuSystemCombo.DisplayMember = "Value";
            ManuSystemCombo.ValueMember = "Key";

            ReactionSolarSystemCombo.BindingContext = new BindingContext();
            ReactionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetLowAndNullSecComboItems();
            ReactionSolarSystemCombo.DisplayMember = "Value";
            ReactionSolarSystemCombo.ValueMember = "Key";

            InventionSolarSystemCombo.BindingContext = new BindingContext();
            InventionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            InventionSolarSystemCombo.DisplayMember = "Value";
            InventionSolarSystemCombo.ValueMember = "Key";

            MESystemCombo.BindingContext = new BindingContext();
            MESystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            MESystemCombo.DisplayMember = "Value";
            MESystemCombo.ValueMember = "Key";

            TESystemCombo.BindingContext = new BindingContext();
            TESystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            TESystemCombo.DisplayMember = "Value";
            TESystemCombo.ValueMember = "Key";

            CopySystemCombo.BindingContext = new BindingContext();
            CopySystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            CopySystemCombo.DisplayMember = "Value";
            CopySystemCombo.ValueMember = "Key";
        }

        private void LoadStructureCombos()
        {
            ManuStructCombo.BindingContext = new BindingContext();
            ManuStructCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            ManuStructCombo.DisplayMember = "Value";
            ManuStructCombo.ValueMember = "Key";

            ReactionStructureCombo.BindingContext = new BindingContext();
            ReactionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetRefineryComboItems();
            ReactionStructureCombo.DisplayMember = "Value";
            ReactionStructureCombo.ValueMember = "Key";

            InventionStructureCombo.BindingContext = new BindingContext();
            InventionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            InventionStructureCombo.DisplayMember = "Value";
            InventionStructureCombo.ValueMember = "Key";

            MEStructureCombo.BindingContext = new BindingContext();
            MEStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            MEStructureCombo.DisplayMember = "Value";
            MEStructureCombo.ValueMember = "Key";

            TEStructureCombo.BindingContext = new BindingContext();
            TEStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            TEStructureCombo.DisplayMember = "Value";
            TEStructureCombo.ValueMember = "Key";

            CopyStructureCombo.BindingContext = new BindingContext();
            CopyStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            CopyStructureCombo.DisplayMember = "Value";
            CopyStructureCombo.ValueMember = "Key";
        }

        private void LoadImplantCombos()
        {
            ManuImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingImplantItems();
            ManuImplantCombo.DisplayMember = "Value";
            ManuImplantCombo.ValueMember = "Key";

            MEImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetMEIMplentItems();
            MEImplantCombo.DisplayMember = "Value";
            MEImplantCombo.ValueMember = "Key";

            TEImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetTEImplantItems();
            TEImplantCombo.DisplayMember = "Value";
            TEImplantCombo.ValueMember = "Key";

            CopyImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetCopyImplantItems();
            CopyImplantCombo.DisplayMember = "Value";
            CopyImplantCombo.ValueMember = "Key";
        }

        private void LoadStructureRigCombos()
        {
            ManuRigMEBonusCombo.BindingContext = new BindingContext();
            ManuRigMEBonusCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            ManuRigMEBonusCombo.DisplayMember = "Value";
            ManuRigMEBonusCombo.ValueMember = "Key";

            ManuRigTEBonusCombo.BindingContext = new BindingContext();
            ManuRigTEBonusCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            ManuRigTEBonusCombo.DisplayMember = "Value";
            ManuRigTEBonusCombo.ValueMember = "Key";

            ReactionStructureMERig.BindingContext = new BindingContext();
            ReactionStructureMERig.DataSource = CommonHelper.GetStructureBonusComboItems();
            ReactionStructureMERig.DisplayMember = "Value";
            ReactionStructureMERig.ValueMember = "Key";

            ReactionStructureTERig.BindingContext = new BindingContext();
            ReactionStructureTERig.DataSource = CommonHelper.GetStructureBonusComboItems();
            ReactionStructureTERig.DisplayMember = "Value";
            ReactionStructureTERig.ValueMember = "Key";

            InventionStructureCostRigCombo.BindingContext = new BindingContext();
            InventionStructureCostRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            InventionStructureCostRigCombo.DisplayMember = "Value";
            InventionStructureCostRigCombo.ValueMember = "Key";

            InventionStructureTimeRigCombo.BindingContext = new BindingContext();
            InventionStructureTimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            InventionStructureTimeRigCombo.DisplayMember = "Value";
            InventionStructureTimeRigCombo.ValueMember = "Key";

            METimeRigCombo.BindingContext = new BindingContext();
            METimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            METimeRigCombo.DisplayMember = "Value";
            METimeRigCombo.ValueMember = "Key";

            TEStructRigCombo.BindingContext = new BindingContext();
            TEStructRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            TEStructRigCombo.DisplayMember = "Value";
            TEStructRigCombo.ValueMember = "Key";

            CopyTimeRigCombo.BindingContext = new BindingContext();
            CopyTimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            CopyTimeRigCombo.DisplayMember = "Value";
            CopyTimeRigCombo.ValueMember = "Key";

        }

        private void LoadDecryptorCombo()
        {
            InventionDecryptorCombo.BindingContext = new BindingContext();
            InventionDecryptorCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetDecryptors();
            InventionDecryptorCombo.DisplayMember = "typeName";
            InventionDecryptorCombo.ValueMember = "typeID";

            ManuInventDecryptorCombo.BindingContext = new BindingContext();
            ManuInventDecryptorCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetDecryptors();
            ManuInventDecryptorCombo.DisplayMember = "typeName";
            ManuInventDecryptorCombo.ValueMember = "typeID";
        }

        private void LoadInventionProductsCombo()
        {
            if (InventionProds != null && InventionProds.Count > 0)
            {
                InventionOutcomeBPCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionProductItems(InventionProds);
            }
        }

        #endregion

        private void LoadUpDowns()
        {
            RunsUpDown.Value = 1;
        }


        #endregion "Initial Data Loading"

        #region "Form Events"
        private void TreeViewList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeViewList.SelectedNode != null && e.Action != TreeViewAction.Unknown)
            {
                TreeViewSelectionChanged(TreeViewList.SelectedNode);
                TreeViewList.SelectedNode = null;
            }
        }

        private void SearchResultsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SearchResultsTreeView.SelectedNode != null && e.Action != TreeViewAction.Unknown)
            {
                TreeViewSelectionChanged(SearchResultsTreeView.SelectedNode);
                SearchResultsTreeView.SelectedNode = null;
            }
        }

        private void TreeViewSelectionChanged(TreeNode selectedNode)
        {
            if (selectedNode != null)
            {
                if (selectedNode.Tag.ToString().StartsWith("typeID"))
                {
                    if (CommonHelper.InventoryTypes != null)
                    {
                        int typeID = 0;
                        typeID = Convert.ToInt32(selectedNode.Tag.ToString().Split("_")[1]);
                        Objects.InventoryType invType = CommonHelper.InventoryTypes.Find(x => x.typeId == typeID);
                        if (invType != null)
                        {
                            SelectedType = invType;
                            SelectedTypeChanged();
                        }
                    }
                }
            }
        }

        private void Generic_ItemChanged(object sender, EventArgs e)
        {
            if (!IsInit && !IgnoreChangedEvent)
            {
                ShowHideFieldsForStructureType();
                RunNumbers();
            }
        }

        private void ActivityTabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabindSummaryScreen();
        }

        private void InventBlueprintCheckbox_CheckedChanged(object sender, EventArgs e)
        {

            if (!IsInit && SelectedType != null)
            {
                SetDefaultManufacturingMETEValuesForBP();

                RunNumbers();
            }
        }

        private void ManuInventDecryptorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsInit && SelectedType != null)
            {
                SetDefaultManufacturingMETEValuesForBP();

                RunNumbers();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Length > 2)
            {
                SearchResultsTreeView.Nodes.Clear();
                string searchText = SearchTextBox.Text.ToLowerInvariant();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    List<TreeNode> foundNodes = BlueprintBrowserHelper.SearchBlueprints(searchText);
                    if (foundNodes.Count > 0)
                    {
                        SearchResultsTreeView.Nodes.AddRange(foundNodes.ToArray());
                    }
                }
            }
        }

        private void Numeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                numericUpDown.Value = 0;
            }
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            CopyMatsToClipboard();
        }

        private void CreateBuildPlanButton_Click(object sender, EventArgs e)
        {
            FileNameDialog fnd = new FileNameDialog("Name for Build Plan");
            if (fnd.ShowDialog() == DialogResult.OK)
            {
                BuildPlan newBuildPlan = new BuildPlan();
                newBuildPlan.BuildPlanName = fnd.FileNameTextBox.Text + ".json";
                newBuildPlan.finalProductTypeID = ManuProds[0].productTypeID;
                newBuildPlan.RunsPerCopy = Convert.ToInt32(RunsUpDown.Value);
                newBuildPlan.NumOfCopies = 1;
                BuildPlansControl buildPlansControl = new BuildPlansControl(newBuildPlan);
                buildPlansControl.Show(this.Owner);
            }
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchButton_Click(sender, new EventArgs());
        }

        private void TaxInputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedType != null)
            {
                RunNumbers();
            }
        }

        private void TaxOutputsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedType != null)
            {
                RunNumbers();
            }
        }
        #endregion

        #region "Item Selected Methods"
        private void SelectedTypeChanged()
        {
            if (SelectedType != null)
            {
                SetupValuesForBlueprintInvention();
                //Set Label
                BlueprintNameLabel.Text = SelectedType.typeName;
                //Load Activity Types
                IndustryActivityTypes = Database.SQLiteCalls.GetIndustryActivityTypes(SelectedType.typeId);
                //Show Hide Tabs
                EnableDisableTabsForActivities();
                this.Refresh();
                //Run Numbers
                RunNumbers(true);

                if (!BlueprintImageBackgroundWorker.IsBusy)
                {
                    BlueprintImageBackgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void SetupValuesForBlueprintInvention()
        {
            if (IsBlueprintInvented())
            {
                InventBlueprintCheckbox.Visible = true;
                ManuInventDecryptorLabel.Visible = true;
                ManuInventDecryptorCombo.Visible = true;
                InventedFromLabel.Visible = true;
                InventedFromLabelLabel.Visible = true;

                SetDefaultManufacturingMETEValuesForBP();
            }
            else
            {
                InventBlueprintCheckbox.Visible = false;
                ManuInventDecryptorLabel.Visible = false;
                ManuInventDecryptorCombo.Visible = false;
                InventedFromLabel.Visible = false;
                InventedFromLabelLabel.Visible = false;
                InventedFromLabel.Text = "";

                ManuMEUpDown.Enabled = true;
                ManuTEUpDown.Enabled = true;
            }
        }

        private void SetDefaultManufacturingMETEValuesForBP()
        {

            if (InventBlueprintCheckbox.Checked)
            {
                ManuMEUpDown.Enabled = false;
                ManuTEUpDown.Enabled = false;

                int defaultME = 2;
                int defaultTE = 4;

                if (ManuInventDecryptorCombo.SelectedValue != null && Convert.ToInt32(ManuInventDecryptorCombo.SelectedValue) > 0)
                {
                    Objects.Decryptor decryptor = BlueprintBrowserHelper.Decryptors.Find(x => x.typeID == Convert.ToInt32(ManuInventDecryptorCombo.SelectedValue));
                    if (decryptor != null)
                    {
                        defaultME += decryptor.meModifier;
                        defaultTE += decryptor.teModifier;
                    }
                }
                IgnoreChangedEvent = true;
                ManuMEUpDown.Value = defaultME;
                ManuTEUpDown.Value = defaultTE;
                IgnoreChangedEvent = false;
            }
            else
            {
                ManuMEUpDown.Enabled = true;
                ManuTEUpDown.Enabled = true;
            }
        }

        private void ShowHideFieldsForStructureType()
        {
            IgnoreChangedEvent = true;
            //Manufacturing
            if (ManuStructCombo.SelectedValue != null && Convert.ToInt32(ManuStructCombo.SelectedValue) <= 0)
            {
                StructureMERigLabel.Visible = false;
                ManuRigMEBonusCombo.Visible = false;

                ManuRig2Label.Visible = false;
                ManuRigTEBonusCombo.Visible = false;

                manuTaxLabel.Visible = false;
                ManuTaxUpDown.Visible = false;
            }
            else
            {
                StructureMERigLabel.Visible = true;
                ManuRigMEBonusCombo.Visible = true;

                ManuRig2Label.Visible = true;
                ManuRigTEBonusCombo.Visible = true;

                manuTaxLabel.Visible = true;
                ManuTaxUpDown.Visible = true;
            }
            //Reactions
            if (ReactionStructureCombo.SelectedValue != null && Convert.ToInt32(ReactionStructureCombo.SelectedValue) <= 0)
            {
                ReactionStructMERigLabel.Visible = false;
                ReactionStructureMERig.Visible = false;

                ReactionStructTERigLabel.Visible = false;
                ReactionStructureTERig.Visible = false;

                ReactionTaxLabel.Visible = false;
                ReactionTaxUpDown.Visible = false;
            }
            else
            {
                ReactionStructMERigLabel.Visible = true;
                ReactionStructureMERig.Visible = true;

                ReactionStructTERigLabel.Visible = true;
                ReactionStructureTERig.Visible = true;

                ReactionTaxLabel.Visible = true;
                ReactionTaxUpDown.Visible = true;
            }

            //Invention
            if (InventionStructureCombo.SelectedValue != null && Convert.ToInt32(InventionStructureCombo.SelectedValue) <= 0)
            {
                InventionStructMERigLabel.Visible = false;
                InventionStructureCostRigCombo.Visible = false;

                InventionStructTERigLabel.Visible = false;
                InventionStructureTimeRigCombo.Visible = false;

                InventionTaxLabel.Visible = false;
                InventionTaxUpDown.Visible = false;
            }
            else
            {
                InventionStructMERigLabel.Visible = true;
                InventionStructureCostRigCombo.Visible = true;

                InventionStructTERigLabel.Visible = true;
                InventionStructureTimeRigCombo.Visible = true;

                InventionTaxLabel.Visible = true;
                InventionTaxUpDown.Visible = true;
            }

            //ME Research
            if (MEStructureCombo.SelectedValue != null && Convert.ToInt32(MEStructureCombo.SelectedValue) <= 0)
            {
                MEStructRigLabel.Visible = false;
                METimeRigCombo.Visible = false;

                METaxLabel.Visible = false;
                METaxUpDown.Visible = false;
            }
            else
            {
                MEStructRigLabel.Visible = true;
                METimeRigCombo.Visible = true;

                METaxLabel.Visible = true;
                METaxUpDown.Visible = true;
            }

            //TE Research
            if (TEStructureCombo.SelectedValue != null && Convert.ToInt32(TEStructureCombo.SelectedValue) <= 0)
            {
                TEStructureRigLabel.Visible = false;
                TEStructRigCombo.Visible = false;

                TETaxLabel.Visible = false;
                TETaxUpDown.Visible = false;
            }
            else
            {
                TEStructureRigLabel.Visible = true;
                TEStructRigCombo.Visible = true;

                TETaxLabel.Visible = true;
                TETaxUpDown.Visible = true;
            }

            //Copying
            if (CopyStructureCombo.SelectedValue != null && Convert.ToInt32(CopyStructureCombo.SelectedValue) <= 0)
            {
                CopyRigLabel.Visible = false;
                CopyTimeRigCombo.Visible = false;

                CopyTaxLabel.Visible = false;
                CopyTaxUpDown.Visible = false;
            }
            else
            {
                CopyRigLabel.Visible = true;
                CopyTimeRigCombo.Visible = true;

                CopyTaxLabel.Visible = true;
                CopyTaxUpDown.Visible = true;
            }

            IgnoreChangedEvent = false;
        }

        #region "Calculation Methods"

        private void RunNumbers(bool DBInventionCombo = false)
        {
            if (!IsInit && SelectedType != null)
            {
                this.Cursor = Cursors.WaitCursor;

                Stopwatch sw = Stopwatch.StartNew();
                StatusLabel.Text = "Loading Materials..";
                GetIndustryActivityMaterials();
                sw.Stop();
                Debug.WriteLine(string.Format("Loading Activity Materials took {0} seconds and {1} milliseconds",
                                                sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));

                sw.Restart();
                StatusLabel.Text = "Loading Products..";
                GetIndustryActivityProducts();
                sw.Stop();
                Debug.WriteLine(string.Format("Loading Activity Products took {0} seconds and {1} milliseconds",
                                                sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));

                sw.Start();
                StatusLabel.Text = "Running Calcs..";
                CalculateTotals();
                sw.Stop();
                Debug.WriteLine(string.Format("Running Calcs took {0} seconds and {1} milliseconds",
                                                sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));

                LoadInventionCombo(DBInventionCombo);

                sw.Restart();
                StatusLabel.Text = "Databinding Screens..";
                DatabindScreen();
                sw.Stop();
                Debug.WriteLine(string.Format("Databind screen took {0} seconds and {1} milliseconds",
                                                sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));

                StatusLabel.Text = "Done;";
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadInventionCombo(bool DBInventionCombo)
        {
            if (DBInventionCombo)
            {
                LoadInventionProductsCombo();
            }
            else
            {
                InventionOutcomeBPCombo.DisplayMember = "Value";
                InventionOutcomeBPCombo.ValueMember = "Key";
            }
        }

        private void GetIndustryActivityMaterials()
        {
            bool buildComponents = BuildComponentsCheckbox.Checked;

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityManufacturing, ref ManuMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityResearchingMaterialEfficiency, ref ResMEMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityResearchingTimeEfficiency, ref ResTEMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityCopying, ref CopyMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityInvention, ref InventionMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityReactions, ref ReactionMats, buildComponents);

        }

        private void GetIndustryActivityProducts()
        {
            int outputPriceType = Convert.ToInt32(OutputTypeCombo.SelectedValue);
            ManuProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityManufacturing);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref ManuProds);

            ResMEProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityResearchingMaterialEfficiency);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref ResMEProds);

            ResTEProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityResearchingTimeEfficiency);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref ResTEProds);

            CopyProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityCopying);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref CopyProds);

            InventionProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityInvention);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref InventionProds);

            ReactionProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityReactions);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref ReactionProds);
        }

        private static bool HasManufacturingActivity()
        {
            bool hasManuJob = false;

            if (ManuProds != null && ManuProds.Count > 0)
            {
                hasManuJob = true;
            }

            return hasManuJob;
        }

        private static bool HasReactionActivity()
        {
            bool hasReactProd = false;

            if (ReactionProds != null && ReactionProds.Count > 0)
            {
                hasReactProd = true;
            }

            return hasReactProd;
        }

        private static bool HasInventionActivity()
        {
            bool hasInventionActivity = false;
            if (InventionProds != null && InventionProds.Count > 0)
            {
                hasInventionActivity = true;
            }
            return hasInventionActivity;
        }

        private static bool HasMEResearchActivity()
        {
            bool hasActivity = false;

            if (IndustryActivityTypes.Find(x => x.activityName == Enums.Enums.ActivityResearchingMaterialEfficiency) != null)
            {
                hasActivity = true;
            }

            return hasActivity;
        }

        private static bool HasTEResearchActivity()
        {
            bool hasActivity = false;

            if (IndustryActivityTypes.Find(x => x.activityName == Enums.Enums.ActivityResearchingTimeEfficiency) != null)
            {
                hasActivity = true;
            }

            return hasActivity;
        }

        private static bool HasCopyResearchActivity()
        {
            bool hasActivity = false;

            if (IndustryActivityTypes.Find(x => x.activityName == Enums.Enums.ActivityCopying) != null)
            {
                hasActivity = true;
            }

            return hasActivity;
        }

        private static bool IsBlueprintInvented()
        {
            bool isBlueprintInvented = false;

            isBlueprintInvented = Database.SQLiteCalls.IsBlueprintInvented(SelectedType.typeId);

            return isBlueprintInvented;
        }

        private void CalculateTotals()
        {
            ResetTotals();
            Objects.CalculationHelperClass calculationHelperClass = BuildHelperClass();

            if (HasManufacturingActivity())
            {
                CalculateManufacturingTotals(calculationHelperClass);
            }

            if (HasReactionActivity())
            {
                CalculateReactionsTotals(calculationHelperClass);
            }

            if (HasInventionActivity())
            {
                CalculateInventionTotals(calculationHelperClass);
            }

            if (HasMEResearchActivity())
            {
                CalculateMETotals(calculationHelperClass);
            }

            if (HasTEResearchActivity())
            {
                CalculateTETotals(calculationHelperClass);
            }

            if (HasCopyResearchActivity())
            {
                CalculateCopyTotals(calculationHelperClass);
            }

            TotalManufacturingJobTime = ManufacturingTotalComponentTime + ManufacturingTotalTime;
            TotalReactionJobTime = ReactionTotalTime;
            TotalInventionJobTime = InventionTotalTime;
        }

        private void CalculateManufacturingTotals(Objects.CalculationHelperClass calculationHelperClass)
        {
            ScreenHelper.BlueprintBrowserHelper.CalculateManufacturingInputQuantAndPrice(ref ManuMats, calculationHelperClass);
            ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref ManuMats, calculationHelperClass.BuildComponents);
            ManufacturingTotalTime = ScreenHelper.BlueprintBrowserHelper.CalculateManufacturingTime(IndustryActivityTypes, calculationHelperClass);
            if (calculationHelperClass.BuildComponents)
            {
                ManufacturingTotalComponentTime = ScreenHelper.BlueprintBrowserHelper.GetComponentManufacturingTime(ManuMats, calculationHelperClass);
            }
            TotalManufacturingJobCost = ScreenHelper.CommonHelper.CalculateManufacturingJobCost(ManuMats, calculationHelperClass, calculationHelperClass.Runs);
            TotalManufacturingInputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateTotalVolume(ManuMats, calculationHelperClass, calculationHelperClass.BuildComponents);
            TotalManufacturingOutputPrice = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputPrice(ManuProds, calculationHelperClass.Runs, Enums.Enums.ActivityManufacturing);
            if (TaxOutputsCheckbox.Checked)
            {
                TotalManufacturingTaxesAndFees = CommonHelper.CalculateTaxAndFees(TotalManufacturingOutputPrice, calculationHelperClass, calculationHelperClass.OutputOrderType);
            }
            else
            {
                TotalManufacturingTaxesAndFees = 0;
            }
            decimal totalPrice = 0;
            foreach (MaterialsWithMarketData mat in ManuMats)
            {
                totalPrice += mat.priceTotal;
            }
            if (TaxInputCheckbox.Checked)
            {
                TotalManufacturingTaxesAndFees += CommonHelper.CalculateTaxAndFees(totalPrice, calculationHelperClass, calculationHelperClass.InputOrderType);
            }
            TotalManufacturingOutputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateOutputTotalVolume(ManuProds, calculationHelperClass.Runs, Enums.Enums.ActivityManufacturing);
            TotalOutcomeQuantityManufacturing = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputQuantity(ManuProds, calculationHelperClass.Runs, Enums.Enums.ActivityManufacturing);

            if (IsBlueprintInvented() && InventBlueprintCheckbox.Checked)
            {
                int tech1BlueprintId = Database.SQLiteCalls.GetTech1BlueprintTypeId(SelectedType.typeId);
                InventoryType tech1BlueprintType = CommonHelper.InventoryTypes.Find(x => x.typeId == tech1BlueprintId);
                if (tech1BlueprintType != null)
                {
                    InventedFromLabel.Text = tech1BlueprintType.typeName;
                }
                List<Objects.IndustryActivityTypes> inventionIndustryActivityTypes = Database.SQLiteCalls.GetIndustryActivityTypes(tech1BlueprintId);
                List<Objects.MaterialsWithMarketData> inventionMats = new List<Objects.MaterialsWithMarketData>();

                ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(inventionIndustryActivityTypes, tech1BlueprintId, Enums.Enums.ActivityInvention, ref inventionMats, false);

                Objects.CalculationHelperClass defaultInventionHelperClass = BuildDefaultInventionHelperClass(tech1BlueprintId);

                ScreenHelper.BlueprintBrowserHelper.CalculateInventionInputQuantAndPrice(ref inventionMats, defaultInventionHelperClass);
                ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(defaultInventionHelperClass.InputOrderType, ref inventionMats, calculationHelperClass.BuildComponents);
                TotalInventionJobCost = ScreenHelper.BlueprintBrowserHelper.CalculateInventionJobCost(ManuMats, defaultInventionHelperClass);
                FinalInventionProbability = ScreenHelper.BlueprintBrowserHelper.CalculateInventionProbability(defaultInventionHelperClass);
                int avgTriesForSuccess = Convert.ToInt32(Math.Ceiling(1 / FinalInventionProbability));
                TotalInventionInputCost = 0;
                foreach (Objects.MaterialsWithMarketData mat in inventionMats)
                {
                    mat.quantityTotal = mat.quantityTotal * avgTriesForSuccess;
                    TotalInventionInputCost += mat.priceTotal;
                    mat.priceTotal = mat.priceTotal * avgTriesForSuccess;
                }
                ManuMats.AddRange(inventionMats);
                //Average out invention cost for 100% success rate for at least one blueprint to invent. 
                //This will avoid under valuing the invention cost. Especially on lower probability BPC's. 
            }
            ManufacturingTotalInputPrice = totalPrice;
        }

        private void CalculateReactionsTotals(Objects.CalculationHelperClass calculationHelperClass)
        {
            CommonHelper.PerformReactionMECalculations(ref ReactionMats, calculationHelperClass, calculationHelperClass.Runs);
            ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref ReactionMats, calculationHelperClass.BuildComponents);
            ReactionTotalTime = ScreenHelper.BlueprintBrowserHelper.CalculateReactionTime(IndustryActivityTypes, calculationHelperClass);
            TotalReactionJobCost = ScreenHelper.CommonHelper.CalculateReactionJobCost(ReactionMats, calculationHelperClass, calculationHelperClass.Runs);
            TotalReactionInputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateTotalVolume(ReactionMats, calculationHelperClass, calculationHelperClass.BuildComponents);
            TotalReactionOutputPrice = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputPrice(ReactionProds, calculationHelperClass.Runs, Enums.Enums.ActivityReactions);
            if (TaxOutputsCheckbox.Checked)
            {
                TotalReactionTaxesAndFees = CommonHelper.CalculateTaxAndFees(TotalReactionOutputPrice, calculationHelperClass, calculationHelperClass.OutputOrderType);
            }
            else
            {
                TotalReactionTaxesAndFees = 0;
            }

            decimal TotalMatPrice = 0;
            foreach (MaterialsWithMarketData mat in ReactionMats)
            {
                TotalMatPrice += mat.priceTotal;
            }
            if (TaxInputCheckbox.Checked)
            {
                TotalReactionTaxesAndFees += CommonHelper.CalculateTaxAndFees(TotalMatPrice, calculationHelperClass, calculationHelperClass.InputOrderType);
            }
            TotalReactionOutputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateOutputTotalVolume(ReactionProds, calculationHelperClass.Runs, Enums.Enums.ActivityReactions);
            TotalReactionOutcomeQuantity = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputQuantity(ReactionProds, calculationHelperClass.Runs, Enums.Enums.ActivityReactions);

            ReactionTotalInputPrice = 0;
            foreach (Objects.MaterialsWithMarketData mat in ReactionMats)
            {
                ReactionTotalInputPrice += mat.priceTotal;

            }
        }

        private void CalculateInventionTotals(Objects.CalculationHelperClass calculationHelperClass)
        {
            ScreenHelper.BlueprintBrowserHelper.CalculateInventionInputQuantAndPrice(ref InventionMats, calculationHelperClass);
            ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref InventionMats, calculationHelperClass.BuildComponents);
            InventionTotalTime = ScreenHelper.BlueprintBrowserHelper.CalculateInventionTime(IndustryActivityTypes, calculationHelperClass);
            TotalInventionJobCost = ScreenHelper.BlueprintBrowserHelper.CalculateInventionJobCost(ManuMats, calculationHelperClass);
            TotalInventionInputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateTotalVolume(InventionMats, calculationHelperClass, calculationHelperClass.BuildComponents);
            TotalInventionTaxesAndFees = 0;
            decimal TotalMatPrice = 0;
            foreach (MaterialsWithMarketData mat in InventionMats)
            {
                TotalMatPrice += mat.priceTotal;
            }
            if (TaxInputCheckbox.Checked)
            {
                TotalInventionTaxesAndFees += CommonHelper.CalculateTaxAndFees(TotalMatPrice, calculationHelperClass, calculationHelperClass.InputOrderType);
            }
            TotalInventionOutputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateOutputTotalVolume(InventionProds, calculationHelperClass.Runs, Enums.Enums.ActivityInvention);
            TotalInventionOutcomeQuantity = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputQuantity(InventionProds, calculationHelperClass.Runs, Enums.Enums.ActivityInvention);
            FinalInventionProbability = ScreenHelper.BlueprintBrowserHelper.CalculateInventionProbability(calculationHelperClass);
            InventionRuns = ScreenHelper.BlueprintBrowserHelper.GetInventionRuns(calculationHelperClass, InventionProds);
            InventionME = ScreenHelper.BlueprintBrowserHelper.GetInventionME(calculationHelperClass);
            InventionTE = ScreenHelper.BlueprintBrowserHelper.GetInventionTE(calculationHelperClass);

            InventionTotalInputPrice = 0;
            foreach (Objects.MaterialsWithMarketData mat in InventionMats)
            {
                InventionTotalInputPrice += mat.priceTotal;

            }
        }

        private void CalculateMETotals(Objects.CalculationHelperClass calculationHelperClass)
        {
            long baseTime = IndustryActivityTypes.Find(x => x.activityName == Enums.Enums.ActivityResearchingMaterialEfficiency).time;
            ScreenHelper.BlueprintBrowserHelper.GetMETETotalInputMats(ref ResMEMats, calculationHelperClass.MEFromLevel, calculationHelperClass.METoLevel);
            ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref ResMEMats, calculationHelperClass.BuildComponents);
            ResMETime = BlueprintBrowserHelper.GetMeResearchTime(baseTime, calculationHelperClass);
            TotalMEJobCost = BlueprintBrowserHelper.GetMEJobCost(calculationHelperClass, ManuMats);
            TotalMEInputVolume = BlueprintBrowserHelper.CalculateTotalVolume(ResMEMats, calculationHelperClass, calculationHelperClass.BuildComponents);
            TotalMETaxesAndFees = 0;
            decimal TotalMatPrice = 0;
            foreach (MaterialsWithMarketData mat in ResMEMats)
            {
                TotalMatPrice += mat.priceTotal;
            }
            if (TaxInputCheckbox.Checked)
            {
                TotalMETaxesAndFees += CommonHelper.CalculateTaxAndFees(TotalMatPrice, calculationHelperClass, calculationHelperClass.InputOrderType);
            }
            METotalInputPrice = 0;
            foreach (Objects.MaterialsWithMarketData mat in ResMEMats)
            {
                METotalInputPrice += mat.priceTotal;
            }
        }

        private void CalculateTETotals(Objects.CalculationHelperClass calculationHelperClass)
        {
            long baseTime = IndustryActivityTypes.Find(x => x.activityName == Enums.Enums.ActivityResearchingTimeEfficiency).time;
            int teFromLevel = calculationHelperClass.TEFromLevel / 2;
            int teToLevel = calculationHelperClass.TEToLevel / 2;
            ScreenHelper.BlueprintBrowserHelper.GetMETETotalInputMats(ref ResTEMats, teFromLevel, teToLevel);
            ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref ResTEMats, calculationHelperClass.BuildComponents);
            ResTETime = BlueprintBrowserHelper.GetTEResearchTime(baseTime, calculationHelperClass);
            TotalTEJobCost = BlueprintBrowserHelper.GetTEJobCost(calculationHelperClass, ManuMats);
            TotalTEInputVolume = BlueprintBrowserHelper.CalculateTotalVolume(ResTEMats, calculationHelperClass, calculationHelperClass.BuildComponents);
            TotalTETaxesAndFees = 0;
            decimal TotalMatPrice = 0;
            foreach (MaterialsWithMarketData mat in ResTEMats)
            {
                TotalMatPrice += mat.priceTotal;
            }
            if (TaxInputCheckbox.Checked)
            {
                TotalMETaxesAndFees += CommonHelper.CalculateTaxAndFees(TotalMatPrice, calculationHelperClass, calculationHelperClass.InputOrderType);
            }
            TETotalInputPrice = 0;
            foreach (Objects.MaterialsWithMarketData mat in ResTEMats)
            {
                TETotalInputPrice += mat.priceTotal;
            }
        }

        private void CalculateCopyTotals(Objects.CalculationHelperClass calculationHelperClass)
        {
            long baseTime = IndustryActivityTypes.Find(x => x.activityName == Enums.Enums.ActivityCopying).time;
            ScreenHelper.BlueprintBrowserHelper.GetCopyingTotalMats(ref CopyMats, calculationHelperClass);
            ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref CopyMats, calculationHelperClass.BuildComponents);
            ResCopyTime = BlueprintBrowserHelper.GetCopyingTime(baseTime, calculationHelperClass);
            TotalCopyJobCost = BlueprintBrowserHelper.GetCopyJobCost(calculationHelperClass, ManuMats);
            TotalCopyInputVolume = BlueprintBrowserHelper.CalculateTotalVolume(CopyMats, calculationHelperClass, calculationHelperClass.BuildComponents);
            TotalCopyTaxesAndFees = 0;
            CopyingTotalInputPrice = 0;
            foreach (Objects.MaterialsWithMarketData mat in CopyMats)
            {
                CopyingTotalInputPrice += mat.priceTotal;
            }
            if (TaxInputCheckbox.Checked)
            {
                TotalCopyTaxesAndFees += CommonHelper.CalculateTaxAndFees(CopyingTotalInputPrice, calculationHelperClass, calculationHelperClass.InputOrderType);
            }
        }

        private void ResetTotals()
        {
            //Time
            ManufacturingTotalTime = 0;
            ReactionTotalTime = 0;
            InventionTotalTime = 0;
            //Component Time
            ManufacturingTotalComponentTime = 0;
            //Input Price
            ManufacturingTotalInputPrice = 0;
            ReactionTotalInputPrice = 0;
            InventionTotalInputPrice = 0;
            //Run Time
            TotalManufacturingJobTime = 0;
            TotalReactionJobTime = 0;
            TotalInventionJobTime = 0;
            //Job Cost
            TotalManufacturingJobCost = 0;
            TotalReactionJobCost = 0;
            TotalInventionJobCost = 0;
            //Output Price
            TotalManufacturingOutputPrice = 0;
            TotalReactionOutputPrice = 0;
            //Input Volume
            TotalManufacturingInputVolume = 0;
            TotalReactionInputVolume = 0;
            TotalInventionInputVolume = 0;
            //Output Volume
            TotalManufacturingOutputVolume = 0;
            TotalReactionOutputVolume = 0;
            TotalInventionOutputVolume = 0;
            //Outcome Quantity
            TotalOutcomeQuantityManufacturing = 0;
            TotalReactionOutcomeQuantity = 0;
            TotalInventionOutcomeQuantity = 0;
            //Taxes and Fees
            TotalManufacturingTaxesAndFees = 0;
            TotalReactionTaxesAndFees = 0;
            TotalInventionTaxesAndFees = 0;

            //Invention Specific
            FinalInventionProbability = 0;
            InventionRuns = 0;
            InventionME = 0;
            InventionTE = 0;
        }

        private Objects.CalculationHelperClass BuildHelperClass()
        {
            Objects.CalculationHelperClass helperClass = new Objects.CalculationHelperClass();

            //Selected Type
            helperClass.SelectedTypeID = SelectedType.typeId;

            //Invent Blueprint
            helperClass.InventBlueprint = InventBlueprintCheckbox.Checked;

            //Runs
            helperClass.Runs = Convert.ToInt32(RunsUpDown.Value);

            //Manufacturing ME TE
            helperClass.ME = Convert.ToInt32(ManuMEUpDown.Value);
            helperClass.TE = Convert.ToInt32(ManuTEUpDown.Value);
            helperClass.CompME = Convert.ToInt32(CompMEUpDown.Value);
            helperClass.CompTE = Convert.ToInt32(CompTEUpDown.Value);

            //Structure Types
            helperClass.ManufacturingStructureTypeID = Convert.ToInt32(ManuStructCombo.SelectedValue);
            helperClass.ReactionsStructureTypeID = Convert.ToInt32(ReactionStructureCombo.SelectedValue);
            helperClass.InventionStructureTypeID = Convert.ToInt32(InventionStructureCombo.SelectedValue);
            helperClass.MEStructureTypeID = Convert.ToInt32(MEStructureCombo.SelectedValue);
            helperClass.TEStructureTypeID = Convert.ToInt32(TEStructureCombo.SelectedValue);
            helperClass.CopyingStructureTypeID = Convert.ToInt32(CopyStructureCombo.SelectedValue);

            //Structure Rigs
            helperClass.ManufacturingStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.ManufacturingStructureTypeID > 0)
            {
                helperClass.ManufacturingStructureRigBonus.RigMEBonus = Convert.ToInt32(ManuRigMEBonusCombo.SelectedValue);
                helperClass.ManufacturingStructureRigBonus.RigTEBonus = Convert.ToInt32(ManuRigTEBonusCombo.SelectedValue);
            }
            helperClass.ReactionStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.ReactionsStructureTypeID > 0)
            {
                helperClass.ReactionStructureRigBonus.RigMEBonus = Convert.ToInt32(ReactionStructureMERig.SelectedValue);
                helperClass.ReactionStructureRigBonus.RigTEBonus = Convert.ToInt32(ReactionStructureTERig.SelectedValue);
            }
            helperClass.InventionStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.InventionStructureTypeID > 0)
            {
                helperClass.InventionStructureRigBonus.RigMEBonus = Convert.ToInt32(InventionStructureCostRigCombo.SelectedValue);
                helperClass.InventionStructureRigBonus.RigTEBonus = Convert.ToInt32(InventionStructureTimeRigCombo.SelectedValue);
            }
            helperClass.MEStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.MEStructureTypeID > 0)
            {
                helperClass.MEStructureRigBonus.RigTEBonus = Convert.ToInt32(METimeRigCombo.SelectedValue);
            }
            helperClass.TEStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.TEStructureTypeID > 0)
            {
                helperClass.TEStructureRigBonus.RigTEBonus = Convert.ToInt32(TEStructRigCombo.SelectedValue);
            }
            helperClass.CopyStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.CopyingStructureTypeID > 0)
            {
                helperClass.CopyStructureRigBonus.RigTEBonus = Convert.ToInt32(CopyTimeRigCombo.SelectedValue);
            }

            //Input Output order type
            helperClass.InputOrderType = Convert.ToInt32(InputTypeCombo.SelectedValue);
            helperClass.OutputOrderType = Convert.ToInt32(OutputTypeCombo.SelectedValue);


            //Implant types
            helperClass.ManufacturingImplantTypeID = Convert.ToInt32(ManuImplantCombo.SelectedValue);
            helperClass.MEImplantTypeID = Convert.ToInt32(MEImplantCombo.SelectedValue);
            helperClass.TEImplantTypeID = Convert.ToInt32(TEImplantCombo.SelectedValue);
            helperClass.CopyImplantTypeID = Convert.ToInt32(CopyImplantCombo.SelectedValue);

            //Solar Systems
            helperClass.ManufacturingSolarSystemID = Convert.ToInt32(ManuSystemCombo.SelectedValue);
            helperClass.ReactionSolarSystemID = Convert.ToInt32(ReactionSolarSystemCombo.SelectedValue);
            helperClass.InventionSolarSystemID = Convert.ToInt32(InventionSolarSystemCombo.SelectedValue);
            helperClass.MESolarSystemID = Convert.ToInt32(MESystemCombo.SelectedValue);
            helperClass.TESolarSystemID = Convert.ToInt32(TESystemCombo.SelectedValue);
            helperClass.CopyingSolarSystemID = Convert.ToInt32(CopySystemCombo.SelectedValue);

            //Facility Tax
            if (Convert.ToInt32(ManuStructCombo.SelectedValue) == 0)
            {
                //10% NPC Station tax.
                helperClass.ManufacturingFacilityTax = 10;
            }
            else
            {
                helperClass.ManufacturingFacilityTax = Convert.ToDecimal(ManuTaxUpDown.Value);
            }
            helperClass.ReactionsFacilityTax = Convert.ToDecimal(ReactionTaxUpDown.Value);
            if (Convert.ToInt32(InventionStructureCombo.SelectedValue) == 0)
            {
                //NPC Facility Tax
                helperClass.InventionFacilityTax = 10;
            }
            else
            {
                helperClass.InventionFacilityTax = Convert.ToDecimal(InventionTaxUpDown.Value);
            }
            if (Convert.ToInt32(MEStructureCombo.SelectedValue) == 0)
            {
                //NPE Facility Tax
                helperClass.MEFacilityTax = (decimal).25;
            }
            else
            {
                helperClass.MEFacilityTax = Convert.ToDecimal(METaxUpDown.Value);
            }
            if (Convert.ToInt32(TEStructureCombo.SelectedValue) == 0)
            {
                //NPE Facility Tax
                helperClass.TEFacilityTax = (decimal).25;
            }
            else
            {
                helperClass.TEFacilityTax = Convert.ToDecimal(TETaxUpDown.Value);
            }
            if (Convert.ToInt32(CopyStructureCombo.SelectedValue) == 0)
            {
                //NPE Facility Tax
                helperClass.CopyingFacilityTax = (decimal).25;
            }
            else
            {
                helperClass.CopyingFacilityTax = Convert.ToDecimal(CopyTaxUpDown.Value);
            }

            //Build Components
            helperClass.BuildComponents = BuildComponentsCheckbox.Checked;

            //Decryptor
            helperClass.InventionDecryptorId = Convert.ToInt32(InventionDecryptorCombo.SelectedValue);

            //Invention Outcome BP
            if (InventionProds.Count > 0)
            {
                if (InventionOutcomeBPCombo.SelectedValue != null)
                {
                    helperClass.InventionProductTypeId = Convert.ToInt32(InventionOutcomeBPCombo.SelectedValue);
                }
                else
                {
                    helperClass.InventionProductTypeId = InventionProds[0].productTypeID;
                }
            }

            //ME and TE From TO Level
            helperClass.MEFromLevel = (int)MEFromLevelUpDown.Value;
            helperClass.METoLevel = (int)METoLevelUpDown.Value;
            helperClass.TEFromLevel = (int)TEFromLevelUpDown.Value;
            helperClass.TEToLevel = (int)TEToLevelUpDown.Value;

            //Copies and Runs per copy
            helperClass.NumCopies = (int)CopyNumCopiesUpDown.Value;
            helperClass.RunsPerCopy = (int)CopyRunsCopyUpDown.Value;


            //Skills
            helperClass.AccountingSkill = DefaultFormValues.AccountingSKill;
            helperClass.BrokersSkill = DefaultFormValues.BrokersSkill;
            helperClass.ResearchSkill = DefaultFormValues.ResearchSkill;
            helperClass.ReactionsSkill = DefaultFormValues.ReactionsSkill;
            helperClass.IndustrySkill = DefaultFormValues.IndustrySkill;
            helperClass.AdvancedIndustrySkill = DefaultFormValues.AdvancedIndustrySkill;
            helperClass.CapitalShipConstructionSkill = DefaultFormValues.CapitalShipConstructionSkill;
            helperClass.AdvacnedSmallConstructionSkill = DefaultFormValues.AdvacnedSmallConstructionSkill;
            helperClass.AdvacnedMediumConstructionSkill = DefaultFormValues.AdvacnedMediumConstructionSkill;
            helperClass.AdvacnedLargeConstructionSkill = DefaultFormValues.AdvacnedLargeConstructionSkill;
            helperClass.AdvancedCapitalConstructionSkill = DefaultFormValues.AdvancedCapitalConstructionSkill;
            helperClass.AdvancedIndustrialConstructionSkill = DefaultFormValues.AdvancedIndustrialConstructionSkill;
            helperClass.Datacore1SkillLevel = Convert.ToInt32(DataCore1SkillUpDown.Value);
            helperClass.Datacore2SkillLevel = Convert.ToInt32(Datacore2SkillUpDown.Value);
            helperClass.EncryptionStarshipSkillLevel = Convert.ToInt32(EncryptionStarshipSkillUpDown.Value);
            return helperClass;
        }

        private Objects.CalculationHelperClass BuildDefaultInventionHelperClass(int typeId)
        {
            Objects.CalculationHelperClass helperClass = new Objects.CalculationHelperClass();

            //Selected Type
            helperClass.SelectedTypeID = typeId;

            //Invent Blueprint
            helperClass.InventBlueprint = InventBlueprintCheckbox.Checked;

            //Runs
            helperClass.Runs = 1;

            //Manufacturing ME TE
            helperClass.ME = Convert.ToInt32(ManuMEUpDown.Value);
            helperClass.TE = Convert.ToInt32(ManuTEUpDown.Value);
            helperClass.CompME = Convert.ToInt32(CompMEUpDown.Value);
            helperClass.CompTE = Convert.ToInt32(CompTEUpDown.Value);

            //Structure Types
            helperClass.InventionStructureTypeID = DefaultFormValues.InventionStructureValue;

            //Structure Rigs
            helperClass.InventionStructureRigBonus = new Objects.StructureRigBonus();
            if (helperClass.InventionStructureTypeID > 0)
            {
                helperClass.InventionStructureRigBonus.RigMEBonus = DefaultFormValues.InventionStructureCostRigValue;
                helperClass.InventionStructureRigBonus.RigTEBonus = DefaultFormValues.InventionStructureTimeRigValue;
            }

            //Input Output order type
            helperClass.InputOrderType = Convert.ToInt32(InputTypeCombo.SelectedValue);
            helperClass.OutputOrderType = Convert.ToInt32(OutputTypeCombo.SelectedValue);


            //Solar Systems
            helperClass.InventionSolarSystemID = DefaultFormValues.InventionSystemValue;

            //Facility Tax
            if (helperClass.InventionStructureTypeID == 0)
            {
                helperClass.InventionFacilityTax = 10;
            }
            else
            {
                helperClass.InventionFacilityTax = DefaultFormValues.InventionTaxValue;
            }

            //Decryptor
            helperClass.InventionDecryptorId = Convert.ToInt32(ManuInventDecryptorCombo.SelectedValue);

            //Invention Outcome BP
            helperClass.InventionProductTypeId = SelectedType.typeId;

            helperClass.Datacore1SkillLevel = DefaultFormValues.Datacore1SkillLevel;
            helperClass.Datacore2SkillLevel = DefaultFormValues.Datacore2SkillLevel;
            helperClass.EncryptionStarshipSkillLevel = DefaultFormValues.EncryptionStarshipSkillLevel;

            return helperClass;
        }


        #region "Manufacturing Methods"
        private void DatabindManufacturingSkills()
        {
            if (ManuSkills != null)
            {
                ManuSkillsTextBox.Text = String.Concat("Required Skills ", Environment.NewLine);
                ManuSkillsTextBox.Text = String.Concat(ManuSkillsTextBox.Text, "-----------------", Environment.NewLine);
                foreach (Objects.IndustryActivitySkill skill in ManuSkills)
                {
                    ManuSkillsTextBox.Text = String.Concat(ManuSkillsTextBox.Text, skill.skillName, " ", skill.level, Environment.NewLine, Environment.NewLine);
                }
            }
        }

        private void DatabindManufacturingMaterials()
        {
            if (ManuMats != null)
            {
                //Grid
                List<Objects.MaterialsWithMarketData> combinedMats = ScreenHelper.BlueprintBrowserHelper.CombinedInputMats(ManuMats).OrderBy(x => x.materialName).ToList();

                DatabindGridView<List<MaterialsWithMarketData>>(ManuInputGrid, combinedMats.OrderByDescending(x => x.priceTotal).ToList<Objects.MaterialsWithMarketData>());

                //Total Volume Label
                ManuInputVolLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalManufacturingInputVolume);

                int solarSystemId = Convert.ToInt32(ManuSystemCombo.SelectedValue);
                if (solarSystemId > 0)
                {
                    decimal costIndex = CommonHelper.GetCostIndexForSystemID(solarSystemId, CostIndiceActivity.ActivityManufacturing);
                    ManufacturingSCILabel.Text = String.Format("{0:P2}.", costIndex);
                }
            }
        }

        private void DatabindManufacturingTime()
        {
            ComponentManuTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(ManufacturingTotalComponentTime);
            ManuTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(ManufacturingTotalTime);
        }
        #endregion

        #region "Reaction Methods"

        private void DatabindReactionSkills()
        {
            if (ReactionSkills != null)
            {
                ReactionSkillsTextBox.Text = String.Concat("Required Skills ", Environment.NewLine);
                ReactionSkillsTextBox.Text = String.Concat(ReactionSkillsTextBox.Text, "-----------------", Environment.NewLine);
                foreach (Objects.IndustryActivitySkill skill in ReactionSkills)
                {
                    ReactionSkillsTextBox.Text = String.Concat(ReactionSkillsTextBox.Text, skill.skillName, " ", skill.level, Environment.NewLine, Environment.NewLine);
                }
            }
        }

        private void DatabindReactionMatGrid()
        {
            List<Objects.MaterialsWithMarketData> combinedMats = ScreenHelper.BlueprintBrowserHelper.CombinedInputMats(ReactionMats).OrderBy(x => x.materialName).ToList();
            DatabindGridView<List<Objects.MaterialsWithMarketData>>(ReactionInputGrid, combinedMats);
        }

        private void DatabindReactionLabels()
        {
            ReactionTotalInputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionInputVolume);
            ReactionTotalOuptutVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionOutputVolume);
            ReactionTotalInputCostLabel.Text = ReactionTotalInputPrice.ToString("C");
            ReactionTotalOutcomeIskLabel.Text = TotalReactionOutputPrice.ToString("C");

            int solarSystemId = Convert.ToInt32(ReactionSolarSystemCombo.SelectedValue);
            if (solarSystemId > 0)
            {
                decimal costIndex = CommonHelper.GetCostIndexForSystemID(solarSystemId, Objects.CostIndiceActivity.ACtivityReaction);
                ReactionsSCILabel.Text = String.Format("{0:P2}.", costIndex);
            }
        }
        #endregion

        #region "Invention Methods"

        private void DatabindInventionSkills()
        {
            if (InventionSkills != null)
            {
                InventionSkillsTextbox.Text = String.Concat("Required Skills ", Environment.NewLine);
                InventionSkillsTextbox.Text = String.Concat(InventionSkillsTextbox.Text, "-----------------", Environment.NewLine);
                foreach (Objects.IndustryActivitySkill skill in InventionSkills)
                {
                    InventionSkillsTextbox.Text = String.Concat(InventionSkillsTextbox.Text, skill.skillName, " ", skill.level, Environment.NewLine, Environment.NewLine);
                }
            }
        }

        private void DatabindInventionMatGrid()
        {
            DatabindGridView<List<MaterialsWithMarketData>>(InventionInputGrid, InventionMats.OrderBy(x => x.materialName).ToList());
        }

        private void DatabindInventionLabels()
        {
            InventionTotalInputCostLabel.Text = InventionTotalInputPrice.ToString("C");
            InventionTotalInputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalInventionInputVolume);
            InventionOutputRunsLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(InventionRuns);
            InventionOutputChanceLabel.Text = FinalInventionProbability.ToString("P");

            int decryptorId = Convert.ToInt32(InventionDecryptorCombo.SelectedValue);
            if (decryptorId > 0)
            {
                List<Objects.Decryptor> decryptors = ScreenHelper.BlueprintBrowserHelper.GetDecryptors();
                Objects.Decryptor decryptor = decryptors.Find(x => x.typeID == decryptorId);

                InventionDecProbLabel.Text = decryptor.probMultiplier.ToString("P");
                InventionDecRunLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(decryptor.runModifier);
                InventionDecMELabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(decryptor.meModifier);
                InventionDecTELabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(decryptor.teModifier);
            }
            else
            {
                InventionDecProbLabel.Text = "";
                InventionDecRunLabel.Text = "";
                InventionDecMELabel.Text = "";
                InventionDecTELabel.Text = "";
            }

            InventionOutputMELabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(InventionME);
            InventionOutputTELabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(InventionTE);

            if (FinalInventionProbability > 0)
            {
                int runsFor100 = Convert.ToInt32(Math.Ceiling(1 / FinalInventionProbability));
                InventionRunsFor100Label.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(runsFor100);
            }
            InventionJobCostLabel.Text = TotalInventionJobCost.ToString("C");


            int solarSystemId = (Int32)ManuSystemCombo.SelectedValue;
            if (solarSystemId > 0)
            {
                decimal costIndex = CommonHelper.GetCostIndexForSystemID(solarSystemId, Objects.CostIndiceActivity.ActivityInvention);
                InventionSCILabel.Text = String.Format("{0:P2}.", costIndex);
            }

        }
        #endregion
        #endregion

        #region "Enable Disable Things
        private void EnableDisableTabsForActivities()
        {
            if (SelectedType != null)
            {
                EnableDisablePanel(Enums.Enums.ActivityManufacturing, ManufacturingPage, ref ManuSkills);
                EnableDisablePanel(Enums.Enums.ActivityResearchingMaterialEfficiency, MEResearchPage, ref ResMESkills);
                EnableDisablePanel(Enums.Enums.ActivityResearchingTimeEfficiency, TEResearchPage, ref ResTESkills);
                EnableDisablePanel(Enums.Enums.ActivityCopying, CopyPage, ref CopySkills);
                EnableDisablePanel(Enums.Enums.ActivityInvention, InventionPage, ref InventionSkills);
                EnableDisablePanel(Enums.Enums.ActivityReactions, ReactionPage, ref ReactionSkills);
            }
        }

        private void EnableDisablePanel(string activityName, TabPage tabPage, ref List<Objects.IndustryActivitySkill> skills)
        {
            if (IndustryActivityTypes.Find(x => x.activityName == activityName) != null)
            {
                if (!ActivityTabPanel.TabPages.Contains(tabPage))
                {
                    ActivityTabPanel.TabPages.Add(tabPage);
                }
                skills = Database.SQLiteCalls.GetINdustryActivitySkills(SelectedType.typeId, activityName);
            }
            else
            {
                skills = null;
                ActivityTabPanel.TabPages.Remove(tabPage);
            }
        }
        #endregion

        #region "Databinding Summary Screens"
        private void DatabindScreen()
        {
            //Manufacturing
            if (HasManufacturingActivity())
            {
                DatabindManufacturingSkills();
                DatabindManufacturingMaterials();
                DatabindManufacturingTime();

                if (!ManuImageWorker.IsBusy)
                {
                    ManuImageWorker.RunWorkerAsync();
                }
            }

            //Reactions
            if (HasReactionActivity())
            {
                DatabindReactionSkills();
                DatabindReactionMatGrid();
                DatabindReactionLabels();

                if (!ReactionImageWorker.IsBusy)
                {
                    ReactionImageWorker.RunWorkerAsync();
                }
            }

            //Invention 
            if (HasInventionActivity())
            {
                DatabindInventionSkills();
                DatabindInventionMatGrid();
                DatabindInventionLabels();

                int productTypeId = 0;
                if (InventionOutcomeBPCombo.SelectedValue != null)
                {
                    productTypeId = Convert.ToInt32(InventionOutcomeBPCombo.SelectedValue);
                }
                if (productTypeId <= 0)
                {
                    productTypeId = InventionProds[0].productTypeID;
                }
                if (!InventionImageWorker.IsBusy)
                {
                    InventionImageWorker.RunWorkerAsync(argument: productTypeId);
                }
            }

            if (HasMEResearchActivity())
            {
                DatabindMEResearchLabels();
                DatabindMEResearchMatGrid();
            }

            if (HasTEResearchActivity())
            {
                DatabindTEResearchLabels();
                DatabindTEResearchMatGrid();
            }

            if (HasCopyResearchActivity())
            {
                DatabindCopyResearchLabels();
                DatabindCopyResearchMatGrid();
            }

            //Summaries
            DatabindSummaryScreen();
        }

        private void DatabindSummaryScreen()
        {
            if (SelectedType == null)
            {
                return;
            }

            ResetSummaryLabel();

            if (ActivityTabPanel.SelectedTab == ManufacturingPage && ManuProds != null && ManuProds.Count > 0)
            {
                DatabindManufacturingSumary();
            }
            else if (ActivityTabPanel.SelectedTab == ReactionPage && ReactionProds != null && ReactionProds.Count > 0)
            {
                DatabindReactionSummary();
            }

            else if (ActivityTabPanel.SelectedTab == InventionPage && InventionProds != null && InventionProds.Count > 0)
            {
                DatabindInventionSummary();
            }
            else if (ActivityTabPanel.SelectedTab == MEResearchPage)
            {
                DatabindResearchMESummary();
            }
            else if (ActivityTabPanel.SelectedTab == TEResearchPage)
            {
                DatabindResearchTESummary();
            }
            else if (ActivityTabPanel.SelectedTab == CopyPage)
            {
                DatabindResearchCopySummary();
            }
        }

        private void ResetSummaryLabel()
        {
            SummaryTypeLabel.Text = "";
            TotalTimeLabel.Text = "";
            TotalJobCostLabel.Text = "";
            ProfitLabel.Text = "";
            IskHourLabel.Text = "";
            TotalInputCostLabel.Text = "";
            OutputProdQuantLabel.Text = "";
            OutputPricePerLabel.Text = "";
            TotalOutcomeIskLabel.Text = "";
            TotalOutputVolumeLabel.Text = "";
            TaxFeesLabel.Text = "";
            TotalCostLabel.Text = "";
            ROILabel.Text = "";
            AdditionalBPCostLabel.Text = "";
            InventionCostLabel.Text = "";

            SummaryTypeLabel.Visible = true;
            TotalTimeLabel.Visible = true;
            TotalJobCostLabel.Visible = true;
            ProfitLabel.Visible = true;
            IskHourLabel.Visible = true;
            TotalInputCostLabel.Visible = true;
            OutputProdQuantLabel.Visible = true;
            OutputPricePerLabel.Visible = true;
            TotalOutcomeIskLabel.Visible = true;
            TotalOutputVolumeLabel.Visible = true;
            TaxFeesLabel.Visible = true;
            TotalCostLabel.Visible = true;
            ROILabel.Visible = true;
            InventionCostLabel.Visible = false;
            InventionCostLabelLabel.Visible = false;
            AdditionalBPCostLabel.Visible = false;
        }

        private void DatabindManufacturingSumary()
        {
            SummaryTypeLabel.Text = "Manufacturing Summary";
            TotalTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(TotalManufacturingJobTime);
            TotalJobCostLabel.Text = string.Concat("-", TotalManufacturingJobCost.ToString("C"));
            decimal totalInventionCost = 0;
            if (FinalInventionProbability > 0)
            {
                totalInventionCost = (TotalInventionJobCost + TotalInventionInputCost) * (1 / FinalInventionProbability);
            }
            decimal additionalCosts = (decimal)AdditionalCostsNumeric.Value;
            decimal profit = TotalManufacturingOutputPrice - ManufacturingTotalInputPrice - TotalManufacturingJobCost - TotalManufacturingTaxesAndFees - totalInventionCost - additionalCosts;
            ProfitLabel.Text = profit.ToString("C");
            if (profit < 0)
            {
                ProfitLabel.ForeColor = Color.Tomato;
                IskHourLabel.ForeColor = Color.Tomato;
                ROILabel.ForeColor = Color.Tomato;
            }
            else
            {
                ProfitLabel.ForeColor = Color.YellowGreen;
                IskHourLabel.ForeColor = Color.YellowGreen;
                ROILabel.ForeColor = Color.YellowGreen;
            }
            BlueprintToolTip.SetToolTip(ProfitLabel, "Total Output Price - Input Price - Job Cost - Taxes and fees - Invention Cost - Additional Costs");

            TaxFeesLabel.Text = string.Concat("-", TotalManufacturingTaxesAndFees.ToString("C"));

            decimal profitPerHour = profit;
            decimal hoursInJob = Convert.ToDecimal(Convert.ToDecimal(TotalManufacturingJobTime) / Convert.ToDecimal(3600)); //3600 seconds in an hour;
            if (hoursInJob > 0)
            {
                profitPerHour = profit / hoursInJob;
            }
            IskHourLabel.Text = profitPerHour.ToString("C");
            TotalInputCostLabel.Text = string.Concat("-", ManufacturingTotalInputPrice.ToString("C"));
            OutputProdQuantLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalOutcomeQuantityManufacturing);
            OutputPricePerLabel.Text = ManuProds[0].pricePer.ToString("C");
            TotalOutcomeIskLabel.Text = TotalManufacturingOutputPrice.ToString("C");
            TotalOutputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalManufacturingOutputVolume);

            decimal totalCost = ManufacturingTotalInputPrice + TotalManufacturingTaxesAndFees + TotalManufacturingJobCost;
            TotalCostLabel.Text = String.Concat("- ", totalCost.ToString("C"));
            if (totalCost > 0)
            {
                decimal roi = Math.Round(profit / totalCost, 4);
                ROILabel.Text = roi.ToString("P");
            }

            if (IsBlueprintInvented() && InventBlueprintCheckbox.Checked)
            {
                InventionCostLabel.Visible = true;
                InventionCostLabelLabel.Visible = true;
            }
            else
            {
                InventionCostLabel.Visible = false;
                InventionCostLabelLabel.Visible = false;
            }

            InventionCostLabel.Text = totalInventionCost.ToString("C");
            if (additionalCosts > 0)
            {
                AdditionalBPCostLabel.Visible = true;
                AdditionalBPCostLabel.Text = additionalCosts.ToString("C");
            }
        }

        private void DatabindReactionSummary()
        {
            SummaryTypeLabel.Text = "Reaction Summary";
            TotalTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(TotalReactionJobTime);
            TotalJobCostLabel.Text = string.Concat("-", TotalReactionJobCost.ToString("C"));

            decimal profit = TotalReactionOutputPrice - ReactionTotalInputPrice - TotalReactionJobCost - TotalReactionTaxesAndFees;
            ProfitLabel.Text = profit.ToString("C");
            if (profit < 0)
            {
                ProfitLabel.ForeColor = Color.Tomato;
                IskHourLabel.ForeColor = Color.Tomato;
                ROILabel.ForeColor = Color.Tomato;
            }
            else
            {
                ProfitLabel.ForeColor = Color.YellowGreen;
                IskHourLabel.ForeColor = Color.YellowGreen;
                ROILabel.ForeColor = Color.YellowGreen;
            }

            BlueprintToolTip.SetToolTip(ProfitLabel, "TotalReactionOutputPrice - ReactionTotalInputPrice - TotalReactionJobCost - TotalReactionTaxesAndFees");

            TaxFeesLabel.Text = string.Concat("-", TotalReactionTaxesAndFees.ToString("C"));

            decimal profitPerHour = profit;
            decimal hoursInJob = Convert.ToDecimal(Convert.ToDecimal(TotalReactionJobTime) / Convert.ToDecimal(3600)); //3600 seconds in an hour;
            if (hoursInJob > 0)
            {
                profitPerHour = profit / hoursInJob;
            }
            IskHourLabel.Text = profitPerHour.ToString("C");
            TotalInputCostLabel.Text = string.Concat("-", ReactionTotalInputPrice.ToString("C"));
            OutputProdQuantLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionOutcomeQuantity);
            OutputPricePerLabel.Text = ReactionProds[0].pricePer.ToString("C");
            TotalOutcomeIskLabel.Text = TotalReactionOutputPrice.ToString("C");
            TotalOutputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionOutputVolume);

            decimal totalCost = ReactionTotalInputPrice + TotalReactionTaxesAndFees + TotalReactionJobCost;
            TotalCostLabel.Text = string.Concat("- ", totalCost.ToString("C"));
            decimal roi = Math.Round(profit / totalCost, 4);
            ROILabel.Text = roi.ToString("P");
        }

        private void DatabindInventionSummary()
        {
            SummaryTypeLabel.Text = "Invention Summary";
            TotalTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(TotalInventionJobTime);
            TotalJobCostLabel.Text = string.Concat("-", TotalInventionJobCost.ToString("C"));

            ProfitLabel.Visible = false;
            TaxFeesLabel.Text = string.Concat("-", TotalInventionTaxesAndFees.ToString("C"));

            IskHourLabel.Visible = false;

            TotalInputCostLabel.Text = string.Concat("-", InventionTotalInputPrice.ToString("C"));
            OutputProdQuantLabel.Visible = false;
            OutputPricePerLabel.Visible = false;
            TotalOutcomeIskLabel.Visible = false;
            TotalOutputVolumeLabel.Visible = false;

            decimal totalCost = InventionTotalInputPrice + TotalInventionTaxesAndFees + TotalInventionJobCost;
            TotalCostLabel.Text = string.Concat("- ", totalCost.ToString("C"));
            ROILabel.Visible = false;
        }

        private void DatabindMEResearchLabels()
        {
            //Research Time
            MEResearchTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResMETime);

            //Cost Index Label
            int solarSystemId = Convert.ToInt32(MESystemCombo.SelectedValue);
            if (solarSystemId > 0)
            {
                decimal costIndice = CommonHelper.GetCostIndexForSystemID(solarSystemId, CostIndiceActivity.ActivityME);
                MESystemCostIndexLabel.Text = String.Format("{0:P2}.", costIndice);
            }

            //Total Input Volume Label
            MEInputVolumeLabel.Text = TotalMEInputVolume.ToString("N0");
        }

        private void DatabindMEResearchMatGrid()
        {
            DatabindGridView<List<MaterialsWithMarketData>>(MEMaterialsGrid, ResMEMats.OrderBy(x => x.materialName).ToList());
        }

        private void DatabindResearchMESummary()
        {
            MEResearchTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResMETime);

            SummaryTypeLabel.Text = "ME Research";
            TotalTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResMETime);
            TotalJobCostLabel.Text = TotalMEJobCost.ToString("C");
            IskHourLabel.Text = "";
            TotalInputCostLabel.Text = METotalInputPrice.ToString("C");
            OutputProdQuantLabel.Text = "";
            OutputPricePerLabel.Text = "";
            TotalOutcomeIskLabel.Text = "";
            TotalOutputVolumeLabel.Text = "";
            TaxFeesLabel.Text = TotalMETaxesAndFees.ToString("C");
            TotalCostLabel.Text = "";
            ROILabel.Text = "";


            SummaryTypeLabel.Visible = true;
            TotalTimeLabel.Visible = true;
            TotalJobCostLabel.Visible = true;
            ProfitLabel.Visible = false;
            IskHourLabel.Visible = false;
            TotalInputCostLabel.Visible = true;
            OutputProdQuantLabel.Visible = false;
            OutputPricePerLabel.Visible = false;
            TotalOutcomeIskLabel.Visible = false;
            TotalOutputVolumeLabel.Visible = false;
            TaxFeesLabel.Visible = true;
            TotalCostLabel.Visible = true;
            ROILabel.Visible = false;
        }

        private void DatabindTEResearchLabels()
        {
            //Research Time
            TETimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResTETime);

            //Cost Index Label
            int solarSystemId = Convert.ToInt32(TESystemCombo.SelectedValue);
            if (solarSystemId > 0)
            {
                decimal costIndice = CommonHelper.GetCostIndexForSystemID(solarSystemId, CostIndiceActivity.ActivityTE);
                TESystemCostIndexLabel.Text = String.Format("{0:P2}.", costIndice);
            }

            //Total Input Volume Label
            TEInputVolumeLabel.Text = TotalTEInputVolume.ToString("N0");
        }

        private void DatabindTEResearchMatGrid()
        {
            DatabindGridView<List<MaterialsWithMarketData>>(TEMatGrid, ResTEMats.OrderBy(x => x.materialName).ToList());
        }

        private void DatabindResearchTESummary()
        {
            MEResearchTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResTETime);

            SummaryTypeLabel.Text = "TE Research";
            TotalTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResTETime);
            TotalJobCostLabel.Text = TotalTEJobCost.ToString("C");
            IskHourLabel.Text = "";
            TotalInputCostLabel.Text = TETotalInputPrice.ToString("C");
            OutputProdQuantLabel.Text = "";
            OutputPricePerLabel.Text = "";
            TotalOutcomeIskLabel.Text = "";
            TotalOutputVolumeLabel.Text = "";
            TaxFeesLabel.Text = TotalTETaxesAndFees.ToString("C");
            TotalCostLabel.Text = "";
            ROILabel.Text = "";


            SummaryTypeLabel.Visible = true;
            TotalTimeLabel.Visible = true;
            TotalJobCostLabel.Visible = true;
            ProfitLabel.Visible = false;
            IskHourLabel.Visible = false;
            TotalInputCostLabel.Visible = true;
            OutputProdQuantLabel.Visible = false;
            OutputPricePerLabel.Visible = false;
            TotalOutcomeIskLabel.Visible = false;
            TotalOutputVolumeLabel.Visible = false;
            TaxFeesLabel.Visible = true;
            TotalCostLabel.Visible = true;
            ROILabel.Visible = false;
        }

        private void DatabindCopyResearchLabels()
        {
            //Research Time
            CopyTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResTETime);

            //Cost Index Label
            int solarSystemId = Convert.ToInt32(CopySystemCombo.SelectedValue);
            if (solarSystemId > 0)
            {
                decimal costIndice = CommonHelper.GetCostIndexForSystemID(solarSystemId, CostIndiceActivity.ActivityCOPY);
                CopySystemCostIndexLabel.Text = String.Format("{0:P2}.", costIndice);
            }

            //Total Input Volume Label
            CopyInputVolumeLabel.Text = TotalTEInputVolume.ToString("N0");
        }

        private void DatabindCopyResearchMatGrid()
        {
            DatabindGridView<List<MaterialsWithMarketData>>(CopyMatGrid, CopyMats.OrderBy(x => x.materialName).ToList());
        }

        private void DatabindResearchCopySummary()
        {
            CopyTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResCopyTime);

            SummaryTypeLabel.Text = "Copying";
            TotalTimeLabel.Text = BlueprintBrowserHelper.FormatTimeAsString(ResCopyTime);
            TotalJobCostLabel.Text = TotalCopyJobCost.ToString("C");
            IskHourLabel.Text = "";
            TotalInputCostLabel.Text = CopyingTotalInputPrice.ToString("C");
            OutputProdQuantLabel.Text = "";
            OutputPricePerLabel.Text = "";
            TotalOutcomeIskLabel.Text = "";
            TotalOutputVolumeLabel.Text = "";
            TaxFeesLabel.Text = TotalCopyTaxesAndFees.ToString("C");
            TotalCostLabel.Text = "";
            ROILabel.Text = "";


            SummaryTypeLabel.Visible = true;
            TotalTimeLabel.Visible = true;
            TotalJobCostLabel.Visible = true;
            ProfitLabel.Visible = false;
            IskHourLabel.Visible = false;
            TotalInputCostLabel.Visible = true;
            OutputProdQuantLabel.Visible = false;
            OutputPricePerLabel.Visible = false;
            TotalOutcomeIskLabel.Visible = false;
            TotalOutputVolumeLabel.Visible = false;
            TaxFeesLabel.Visible = true;
            TotalCostLabel.Visible = true;
            ROILabel.Visible = false;
        }
        #endregion

        #endregion

        #region "Methods"
        private void CopyMatsToClipboard()
        {
            StringBuilder sb = new StringBuilder();
            if (ActivityTabPanel.SelectedTab == ManufacturingPage)
            {
                foreach (MaterialsWithMarketData item in ManuMats)
                {
                    sb.AppendLine(item.materialName + " " + item.quantityTotal);
                }
            }
            else if (ActivityTabPanel.SelectedTab == ReactionPage)
            {
                foreach (MaterialsWithMarketData item in ReactionMats)
                {
                    sb.AppendLine(item.materialName + " " + item.quantityTotal);
                }
            }
            else if (ActivityTabPanel.SelectedTab == InventionPage)
            {
                foreach (MaterialsWithMarketData item in InventionMats)
                {
                    sb.AppendLine(item.materialName + " " + item.quantityTotal);
                }
            }
            else if (ActivityTabPanel.SelectedTab == TEResearchPage)
            {
                foreach (MaterialsWithMarketData item in ResTEMats)
                {
                    sb.AppendLine(item.materialName + " " + item.quantityTotal);
                }
            }
            else if (ActivityTabPanel.SelectedTab == MEResearchPage)
            {
                foreach (MaterialsWithMarketData item in ResMEMats)
                {
                    sb.AppendLine(item.materialName + " " + item.quantityTotal);
                }
            }
            Clipboard.SetText(sb.ToString());
        }
        #endregion

        #region "Background Workers"

        private void BlueprintImageBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            byte[]? bpImage = null;
            if (SelectedType != null && SelectedType.typeId > 0)
            {
                bpImage = ESIImageServer.GetImageForType(SelectedType.typeId, "bp");
            }
            e.Result = bpImage;
        }

        private void BlueprintImageBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                BlueprintImage = (byte[])(e.Result);
            }

            bool imageSet = false;
            if (BlueprintImage != null && BlueprintImage.Length > 0)
            {
                MemoryStream memstream = new MemoryStream();
                memstream.Write(BlueprintImage, 0, BlueprintImage.Length);
                this.BlueprintImagePanel.BackgroundImage = Image.FromStream(memstream);
                imageSet = true;
            }
            if (!imageSet)
            {
                BlueprintImagePanel.BackgroundImage = null;
            }
        }

        private void ManuImageWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            byte[]? bpImage = null;
            if (HasManufacturingActivity())
            {
                IndustryActivityProduct activityProduct = ManuProds[0];

                if (activityProduct.productTypeID > 0)
                {
                    bpImage = ESIImageServer.GetImageForType(activityProduct.productTypeID, "icon");
                }
            }
            e.Result = bpImage;
        }

        private void ManuImageWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                ManufacturingImage = (byte[])(e.Result);
            }

            bool imageSet = false;
            if (ManufacturingImage != null && ManufacturingImage.Length > 0)
            {
                MemoryStream memstream = new MemoryStream();
                memstream.Write(ManufacturingImage, 0, ManufacturingImage.Length);
                this.ManufacturingImagePanel.BackgroundImage = Image.FromStream(memstream);
                imageSet = true;
            }
            if (!imageSet)
            {
                ManufacturingImagePanel.BackgroundImage = null;
            }
        }

        private void ReactionImageWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            byte[]? iamge = null;
            if (HasReactionActivity())
            {
                IndustryActivityProduct activityProduct = ReactionProds[0];

                if (activityProduct.productTypeID > 0)
                {
                    iamge = ESIImageServer.GetImageForType(activityProduct.productTypeID, "icon");
                }
            }

            e.Result = iamge;
        }

        private void ReactionImageWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            byte[] image = null;
            if (e.Result != null)
            {
                image = (byte[])(e.Result);
            }

            bool imageSet = false;
            if (image != null && image.Length > 0)
            {
                MemoryStream memstream = new MemoryStream();
                memstream.Write(image, 0, image.Length);
                this.ReactionsImagePanel.BackgroundImage = Image.FromStream(memstream);
                imageSet = true;
            }
            if (!imageSet)
            {
                ReactionsImagePanel.BackgroundImage = null;
            }
        }

        private void InventionImageWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            byte[]? iamge = null;
            if (HasInventionActivity())
            {
                int outputTypeId = Convert.ToInt32(e.Argument);

                if (outputTypeId > 0)
                {
                    iamge = ESIImageServer.GetImageForType(outputTypeId, "bpc");
                }
            }

            e.Result = iamge;
        }

        private void InventionImageWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            byte[] image = null;
            if (e.Result != null)
            {
                image = (byte[])(e.Result);
            }

            bool imageSet = false;
            if (image != null && image.Length > 0)
            {
                MemoryStream memstream = new MemoryStream();
                memstream.Write(image, 0, image.Length);
                this.InventionImagePanel.BackgroundImage = Image.FromStream(memstream);
                imageSet = true;
            }
            if (!imageSet)
            {
                InventionImagePanel.BackgroundImage = null;
            }
        }
        #endregion

    }
}