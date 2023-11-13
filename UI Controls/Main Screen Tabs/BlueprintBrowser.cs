using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using System;
using System.Diagnostics;
using System.Text;

namespace EveHelperWF
{
    public partial class BlueprintBrowser : Objects.FormBase
    {
        #region "Static Variables"
        private const string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private const string CachedFormValuesFileName = "form_values.json";
        private static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();

        private static Objects.InventoryTypes SelectedType = null;
        private static List<Objects.IndustryActivityTypes> IndustryActivityTypes = null;

        private static List<Objects.IndustryActivitySkill> ManuSkills = null;
        private static List<Objects.IndustryActivitySkill> ResMESkills = null;
        private static List<Objects.IndustryActivitySkill> ResTESkills = null;
        private static List<Objects.IndustryActivitySkill> CopySkills = null;
        private static List<Objects.IndustryActivitySkill> ReverseEngSkills = null;
        private static List<Objects.IndustryActivitySkill> InventionSkills = null;
        private static List<Objects.IndustryActivitySkill> ReactionSkills = null;

        private static List<Objects.MaterialsWithMarketData> ManuMats = null;
        private static List<Objects.MaterialsWithMarketData> ResMEMats = null;
        private static List<Objects.MaterialsWithMarketData> ResTEMats = null;
        private static List<Objects.MaterialsWithMarketData> CopyMats = null;
        private static List<Objects.MaterialsWithMarketData> ReverseEngMats = null;
        private static List<Objects.MaterialsWithMarketData> InventionMats = null;
        private static List<Objects.MaterialsWithMarketData> ReactionMats = null;

        private static List<Objects.IndustryActivityProduct> ManuProds = null;
        private static List<Objects.IndustryActivityProduct> ResMEProds = null;
        private static List<Objects.IndustryActivityProduct> ResTEProds = null;
        private static List<Objects.IndustryActivityProduct> CopyProds = null;
        private static List<Objects.IndustryActivityProduct> ReverseEngProds = null;
        private static List<Objects.IndustryActivityProduct> InventionProds = null;
        private static List<Objects.IndustryActivityProduct> ReactionProds = null;

        //Time
        private static Int64 ManufacturingTotalTime = 0;
        private static Int64 ReactionTotalTime = 0;
        private static Int64 InventionTotalTime = 0;
        //Component Time
        private static Int64 ManufacturingTotalComponentTime = 0;
        //Input Price
        private static decimal ManufacturingTotalInputPrice = 0;
        private static decimal ReactionTotalInputPrice = 0;
        private static decimal InventionTotalInputPrice = 0;
        //Run Time
        private static Int64 TotalManufacturingJobTime = 0;
        private static Int64 TotalReactionJobTime = 0;
        private static Int64 TotalInventionJobTime = 0;
        //Job Cost
        private static Decimal TotalManufacturingJobCost = 0;
        private static Decimal TotalReactionJobCost = 0;
        private static Decimal TotalInventionJobCost = 0;
        //Output Price
        private static Decimal TotalManufacturingOutputPrice = 0;
        private static Decimal TotalReactionOutputPrice = 0;
        //Input Volume
        private static Decimal TotalManufacturingInputVolume = 0;
        private static Decimal TotalReactionInputVolume = 0;
        private static Decimal TotalInventionInputVolume = 0;
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

        //Invention Specific
        private static Decimal FinalInventionProbability = 0;
        private static int InventionRuns = 0;
        private static int InventionME = 0;
        private static int InventionTE = 0;

        private static bool IsInit = true;

        //Images
        private static byte[] BlueprintImage = null;
        private static byte[] ManufacturingImage = null;
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

            if (!BlueprintInitBackgroundWorker.IsBusy)
            {
                BlueprintInitBackgroundWorker.RunWorkerAsync();
            }

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
        }

        private void LoadDefaultFormValues()
        {
            string combinedFileName = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            string content = FileIO.FileHelper.GetCachedFileContent(CachedFormValuesDirectory, combinedFileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                DefaultFormValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.DefaultFormValue>(content);
                if (DefaultFormValues != null)
                {
                    SetDefaultFormValue();
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
            InventBlueprintCheckbox.Checked = DefaultFormValues.InventBlueprintCheckboxValue;
            SetManufacturingDefaultValues();
            SetReactionDefaultValues();
            SetInventionDefaultValues();
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
        }

        #region "Combo Load Methods"

        private void LoadPriceTypeCombos()
        {
            InputTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInputPriceTypeItems();
            InputTypeCombo.DisplayMember = "Value";
            InputTypeCombo.ValueMember = "Key";
            InputTypeCombo.SelectedValue = 1;

            OutputTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetOutputPriceTypeItems();
            OutputTypeCombo.DisplayMember = "Value";
            OutputTypeCombo.ValueMember = "Key";
            OutputTypeCombo.SelectedValue = 2;
        }

        private void LoadSolarSystemCombos()
        {
            ManuSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingSolarSystemItems();
            ManuSystemCombo.DisplayMember = "Value";
            ManuSystemCombo.ValueMember = "Key";

            ReactionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetReactionSolarSystemItems();
            ReactionSolarSystemCombo.DisplayMember = "Value";
            ReactionSolarSystemCombo.ValueMember = "Key";

            InventionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionSolarSystemItems();
            InventionSolarSystemCombo.DisplayMember = "Value";
            InventionSolarSystemCombo.ValueMember = "Key";
        }

        private void LoadStructureCombos()
        {
            ManuStructCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            ManuStructCombo.DisplayMember = "Value";
            ManuStructCombo.ValueMember = "Key";

            ReactionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetRefineryComboItems();
            ReactionStructureCombo.DisplayMember = "Value";
            ReactionStructureCombo.ValueMember = "Key";

            InventionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionEngineeringStructureItems();
            InventionStructureCombo.DisplayMember = "Value";
            InventionStructureCombo.ValueMember = "Key";
        }

        private void LoadImplantCombos()
        {
            ManuImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingImplantItems();
            ManuImplantCombo.DisplayMember = "Value";
            ManuImplantCombo.ValueMember = "Key";
        }

        private void LoadStructureRigCombos()
        {
            ManuRigMEBonusCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingStructureMERigs();
            ManuRigMEBonusCombo.DisplayMember = "Value";
            ManuRigMEBonusCombo.ValueMember = "Key";

            ManuRigTEBonusCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingStructureTERigs();
            ManuRigTEBonusCombo.DisplayMember = "Value";
            ManuRigTEBonusCombo.ValueMember = "Key";

            ReactionStructureMERig.DataSource = ScreenHelper.BlueprintBrowserHelper.GetReactionStructureMERigs();
            ReactionStructureMERig.DisplayMember = "Value";
            ReactionStructureMERig.ValueMember = "Key";

            ReactionStructureTERig.DataSource = ScreenHelper.BlueprintBrowserHelper.GetReactionStructureTERigs();
            ReactionStructureTERig.DisplayMember = "Value";
            ReactionStructureTERig.ValueMember = "Key";

            InventionStructureCostRigCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionStructureCostRigs();
            InventionStructureCostRigCombo.DisplayMember = "Value";
            InventionStructureCostRigCombo.ValueMember = "Key";

            InventionStructureTimeRigCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionStructureTERigs();
            InventionStructureTimeRigCombo.DisplayMember = "Value";
            InventionStructureTimeRigCombo.ValueMember = "Key";

        }

        private void LoadDecryptorCombo()
        {
            InventionDecryptorCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetDecryptors();
            InventionDecryptorCombo.DisplayMember = "typeName";
            InventionDecryptorCombo.ValueMember = "typeID";
        }

        private void LoadInventionProductsCombo()
        {
            if (InventionProds != null && InventionProds.Count > 0)
            {
                InventionOutcomeBPCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionProductItems(InventionProds);
                InventionOutcomeBPCombo.DisplayMember = "Value";
                InventionOutcomeBPCombo.ValueMember = "Key";
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
            if (TreeViewList.SelectedNode != null)
            {
                TreeNode selectedNode = TreeViewList.SelectedNode;
                if (selectedNode.Tag.ToString().StartsWith("typeID"))
                {
                    if (ScreenHelper.BlueprintBrowserHelper.InventoryTypes != null)
                    {
                        int typeID = 0;
                        typeID = Convert.ToInt32(selectedNode.Tag.ToString().Split("_")[1]);
                        Objects.InventoryTypes invType = ScreenHelper.BlueprintBrowserHelper.InventoryTypes.Find(x => x.typeId == typeID);
                        if (invType != null)
                        {
                            SelectedType = invType;
                            SelectedTypeChanged();
                        }
                    }
                }
            }
        }

        private void RunsUpDown_ValueChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InputTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void OutputTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuMEUpDown_ValueChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuTEUpDown_ValueChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuSystemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuStructCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuRig1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuRig2Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuTaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ManuImplantCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void BuildComponentsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ReactionSolarSystemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ReactionStructureCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ReactionStructureMERig_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ReactionStructureTERig_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ReactionTaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionSolarSystemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionStructureCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionStructureCostRig_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionStructureTimeRigCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionDecryptorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionTaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventBlueprintCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void InventionOutcomeBPCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunNumbers();
        }

        private void ActivityTabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabindSummaryScreen();
        }

        private void DefaultsClosed(object sender, EventArgs e)
        {
            LoadDefaultFormValues();
        }
        #endregion

        #region "Item Selected Methods"
        private void SelectedTypeChanged()
        {
            if (SelectedType != null)
            {
                BlueprintNameLabel.Text = SelectedType.typeName;
                IndustryActivityTypes = Database.SQLiteCalls.GetIndustryActivityTypes(SelectedType.typeId);
                EnableDisableTabsForActivities();
                RunNumbers(true);

                BlueprintImageBackgroundWorker.RunWorkerAsync();
            }
        }

        #region "Calculation Methods"

        private void RunNumbers(bool DBInventionCombo = false)
        {
            if (!IsInit && SelectedType != null)
            {
                this.Cursor = Cursors.WaitCursor;
                StatusLabel.Text = "Loading Materials...";
                GetIndustryActivityMaterials();
                StatusLabel.Text = "Loading Products...";
                GetIndustryActivityProducts();
                if (DBInventionCombo)
                {
                    LoadInventionProductsCombo();
                }
                else
                {
                    InventionOutcomeBPCombo.DisplayMember = "Value";
                    InventionOutcomeBPCombo.ValueMember = "Key";
                }
                StatusLabel.Text = "Running Calcs...";
                CalculateTotals();
                StatusLabel.Text = "Loading Materials...";
                DatabindScreen();
                StatusLabel.Text = "Done;";
                this.Cursor = Cursors.Default;
            }
        }

        private void GetIndustryActivityMaterials()
        {
            int inputType = Convert.ToInt32(InputTypeCombo.SelectedValue);
            int runs = Convert.ToInt32(RunsUpDown.Value);
            bool buildComponents = BuildComponentsCheckbox.Checked;
            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityManufacturing, ref ManuMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityResearchingMaterialEfficiency, ref ResMEMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityResearchingTimeEfficiency, ref ResTEMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityCopying, ref CopyMats, buildComponents);

            ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(IndustryActivityTypes, SelectedType.typeId, Enums.Enums.ActivityReverseEngineering, ref ReverseEngMats, buildComponents);

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
            ReverseEngProds = Database.SQLiteCalls.GetIndustryActivityProducts(SelectedType.typeId, Enums.Enums.ActivityReverseEngineering);
            ScreenHelper.BlueprintBrowserHelper.GetPriceForProduct(outputPriceType, ref ReverseEngProds);
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
                ScreenHelper.BlueprintBrowserHelper.CalculateManufacturingInputQuantAndPrice(ref ManuMats, calculationHelperClass);
                ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref ManuMats);
                ManufacturingTotalTime = ScreenHelper.BlueprintBrowserHelper.CalculateManufacturingTime(IndustryActivityTypes, calculationHelperClass);
                if (calculationHelperClass.BuildComponents)
                {
                    ManufacturingTotalComponentTime = ScreenHelper.BlueprintBrowserHelper.GetComponentManufacturingTime(ManuMats, calculationHelperClass);
                }
                TotalManufacturingJobCost = ScreenHelper.BlueprintBrowserHelper.CalculateManufacturingJobCost(ManuMats, calculationHelperClass);
                TotalManufacturingInputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateTotalVolume(ManuMats, calculationHelperClass);
                TotalManufacturingOutputPrice = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputPrice(ManuProds, calculationHelperClass.Runs, Enums.Enums.ActivityManufacturing);
                TotalManufacturingTaxesAndFees = ScreenHelper.BlueprintBrowserHelper.CalculateTaxAndFees(TotalManufacturingOutputPrice, calculationHelperClass, ManuMats);
                TotalManufacturingOutputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateOutputTotalVolume(ManuProds, calculationHelperClass.Runs, Enums.Enums.ActivityManufacturing);
                TotalOutcomeQuantityManufacturing = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputQuantity(ManuProds, calculationHelperClass.Runs, Enums.Enums.ActivityManufacturing);

                if (IsBlueprintInvented() && InventBlueprintCheckbox.Checked)
                {
                    int tech1BlueprintId = Database.SQLiteCalls.GetTech1BlueprintTypeId(SelectedType.typeId);
                    List<Objects.IndustryActivityTypes> inventionIndustryActivityTypes = Database.SQLiteCalls.GetIndustryActivityTypes(tech1BlueprintId);
                    List<Objects.MaterialsWithMarketData> inventionMats = new List<Objects.MaterialsWithMarketData>();

                    ScreenHelper.BlueprintBrowserHelper.GetMatsForTypeAndActivity(inventionIndustryActivityTypes, tech1BlueprintId, Enums.Enums.ActivityInvention, ref inventionMats, false);

                    Objects.CalculationHelperClass defaultInventionHelperClass = BuildDefaultInventionHelperClass(tech1BlueprintId);

                    ScreenHelper.BlueprintBrowserHelper.CalculateInventionInputQuantAndPrice(ref inventionMats, defaultInventionHelperClass);
                    ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(defaultInventionHelperClass.InputOrderType, ref inventionMats);
                    TotalInventionJobCost = ScreenHelper.BlueprintBrowserHelper.CalculateInventionJobCost(defaultInventionHelperClass);
                    FinalInventionProbability = ScreenHelper.BlueprintBrowserHelper.CalculateInventionProbability(defaultInventionHelperClass);
                    int avgTriesForSuccess = Convert.ToInt32(Math.Ceiling(1 / FinalInventionProbability));
                    decimal totalInventionInputPrice = 0;
                    foreach (Objects.MaterialsWithMarketData mat in inventionMats)
                    {
                        mat.quantityTotal = mat.quantityTotal * avgTriesForSuccess;
                        totalInventionInputPrice += mat.priceTotal;
                        mat.priceTotal = mat.priceTotal * avgTriesForSuccess;
                    }
                    ManuMats.AddRange(inventionMats);
                    //Average out invention cost for 100% success rate for at least one blueprint to invent. 
                    //This will avoid under valuing the invention cost. Especially on lower probability BPC's. 
                    TotalManufacturingJobCost += ((totalInventionInputPrice + TotalInventionJobCost) * avgTriesForSuccess);

                }

                decimal totalPrice = 0;
                foreach (Objects.MaterialsWithMarketData mat in ManuMats)
                {
                    totalPrice += mat.priceTotal;

                }
                ManufacturingTotalInputPrice = totalPrice;
            }

            if (HasReactionActivity())
            {
                ScreenHelper.BlueprintBrowserHelper.CalculateReactionInputQuantAndPrice(ref ReactionMats, calculationHelperClass);
                ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref ReactionMats);
                ReactionTotalTime = ScreenHelper.BlueprintBrowserHelper.CalculateReactionTime(IndustryActivityTypes, calculationHelperClass);
                TotalReactionJobCost = ScreenHelper.BlueprintBrowserHelper.CalculateReactionJobCost(ReactionMats, calculationHelperClass);
                TotalReactionInputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateTotalVolume(ReactionMats, calculationHelperClass);
                TotalReactionOutputPrice = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputPrice(ReactionProds, calculationHelperClass.Runs, Enums.Enums.ActivityReactions);
                TotalReactionTaxesAndFees = ScreenHelper.BlueprintBrowserHelper.CalculateTaxAndFees(TotalReactionOutputPrice, calculationHelperClass, ReactionMats);
                TotalReactionOutputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateOutputTotalVolume(ReactionProds, calculationHelperClass.Runs, Enums.Enums.ActivityReactions);
                TotalReactionOutcomeQuantity = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputQuantity(ReactionProds, calculationHelperClass.Runs, Enums.Enums.ActivityReactions);

                decimal totalPrice = 0;
                foreach (Objects.MaterialsWithMarketData mat in ReactionMats)
                {
                    totalPrice += mat.priceTotal;

                }
                ReactionTotalInputPrice = totalPrice;
            }

            if (HasInventionActivity())
            {
                ScreenHelper.BlueprintBrowserHelper.CalculateInventionInputQuantAndPrice(ref InventionMats, calculationHelperClass);
                ScreenHelper.BlueprintBrowserHelper.GetMatPriceForActivity(calculationHelperClass.InputOrderType, ref InventionMats);
                InventionTotalTime = ScreenHelper.BlueprintBrowserHelper.CalculateInventionTime(IndustryActivityTypes, calculationHelperClass);
                TotalInventionJobCost = ScreenHelper.BlueprintBrowserHelper.CalculateInventionJobCost(calculationHelperClass);
                TotalInventionInputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateTotalVolume(InventionMats, calculationHelperClass);
                TotalInventionTaxesAndFees = ScreenHelper.BlueprintBrowserHelper.CalculateTaxAndFees(0, calculationHelperClass, InventionMats);
                TotalInventionOutputVolume = ScreenHelper.BlueprintBrowserHelper.CalculateOutputTotalVolume(InventionProds, calculationHelperClass.Runs, Enums.Enums.ActivityInvention);
                TotalInventionOutcomeQuantity = ScreenHelper.BlueprintBrowserHelper.CalculateTotalOutputQuantity(InventionProds, calculationHelperClass.Runs, Enums.Enums.ActivityInvention);
                FinalInventionProbability = ScreenHelper.BlueprintBrowserHelper.CalculateInventionProbability(calculationHelperClass);
                InventionRuns = ScreenHelper.BlueprintBrowserHelper.GetInventionRuns(calculationHelperClass, InventionProds);
                InventionME = ScreenHelper.BlueprintBrowserHelper.GetInventionME(calculationHelperClass);
                InventionTE = ScreenHelper.BlueprintBrowserHelper.GetInventionTE(calculationHelperClass);

                decimal totalPrice = 0;
                foreach (Objects.MaterialsWithMarketData mat in InventionMats)
                {
                    totalPrice += mat.priceTotal;

                }
                InventionTotalInputPrice = totalPrice;
            }

            TotalManufacturingJobTime = ManufacturingTotalComponentTime + ManufacturingTotalTime;
            TotalReactionJobTime = ReactionTotalTime;
            TotalInventionJobTime = InventionTotalTime;
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

            //Input Output order type
            helperClass.InputOrderType = Convert.ToInt32(InputTypeCombo.SelectedValue);
            helperClass.OutputOrderType = Convert.ToInt32(OutputTypeCombo.SelectedValue);

            //Implant types
            helperClass.ManufacturingImplantTypeID = Convert.ToInt32(ManuImplantCombo.SelectedValue);

            //Solar Systems
            helperClass.ManufacturingSolarSystemID = Convert.ToInt32(ManuSystemCombo.SelectedValue);
            helperClass.ReactionSolarSystemID = Convert.ToInt32(ReactionSolarSystemCombo.SelectedValue);
            helperClass.InventionSolarSystemID = Convert.ToInt32(InventionSolarSystemCombo.SelectedValue);

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
                helperClass.InventionFacilityTax = 10;
            }
            else
            {
                helperClass.InventionFacilityTax = Convert.ToDecimal(InventionTaxUpDown.Value);
            }

            //Build Components
            helperClass.BuildComponents = BuildComponentsCheckbox.Checked;

            //Decryptor
            helperClass.InventionDecryptorId = Convert.ToInt32(InventionDecryptorCombo.SelectedValue);

            //Invention Outcome BP
            if (InventionOutcomeBPCombo.Items.Count > 0)
            {
                helperClass.InventionProductTypeId = Convert.ToInt32(InventionOutcomeBPCombo.SelectedValue);
            }

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
            helperClass.InventionDecryptorId = DefaultFormValues.InventionDecryptorValue;

            //Invention Outcome BP
            helperClass.InventionProductTypeId = SelectedType.typeId;

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

                ManuInputGrid.DataSource = combinedMats.OrderByDescending(x => x.priceTotal).ToList<Objects.MaterialsWithMarketData>();

                //Total Input Cost Label
                ManuTotalInputCost.Text = ManufacturingTotalInputPrice.ToString("C");

                //Total Volume Label
                ManuInputVolLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalManufacturingInputVolume);

                if (ScreenHelper.BlueprintBrowserHelper.CostIndicies != null && ScreenHelper.BlueprintBrowserHelper.CostIndicies.Count > 0)
                {
                    int solarSystemId = (Int32)ManuSystemCombo.SelectedValue;
                    Objects.CostIndice costIndice = ScreenHelper.BlueprintBrowserHelper.CostIndicies.Find(x => x.solar_system_id == solarSystemId);
                    if (costIndice != null)
                    {
                        decimal costIndex = costIndice.cost_indices.Find(x => x.activity == Objects.CostIndiceActivity.ActivityManufacturing).cost_index;
                        ManufacturingSCILabel.Text = String.Format("{0:P2}.", costIndex);
                    }
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
            ReactionInputGrid.DataSource = combinedMats;
            ReactionInputGrid.Columns[0].Visible = false;
            ReactionInputGrid.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            ReactionInputGrid.Columns[2].Visible = false;
            ReactionInputGrid.Columns[3].DefaultCellStyle.Format = "N";
            ReactionInputGrid.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            ReactionInputGrid.Columns[4].DefaultCellStyle.Format = "N";
            ReactionInputGrid.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            ReactionInputGrid.Columns[5].DefaultCellStyle.Format = "C";
            ReactionInputGrid.Columns[5].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            ReactionInputGrid.Columns[6].DefaultCellStyle.Format = "C";
            ReactionInputGrid.Columns[6].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            ReactionInputGrid.Columns[11].Visible = false;
        }

        private void DatabindReactionLabels()
        {
            ReactionTotalInputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionInputVolume);
            ReactionTotalOuptutVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionOutputVolume);
            ReactionTotalInputCostLabel.Text = ReactionTotalInputPrice.ToString("C");
            ReactionTotalOutcomeIskLabel.Text = TotalReactionOutputPrice.ToString("C");

            if (ScreenHelper.BlueprintBrowserHelper.CostIndicies != null && ScreenHelper.BlueprintBrowserHelper.CostIndicies.Count > 0)
            {
                int solarSystemId = (Int32)ReactionSolarSystemCombo.SelectedValue;
                Objects.CostIndice costIndice = ScreenHelper.BlueprintBrowserHelper.CostIndicies.Find(x => x.solar_system_id == solarSystemId);
                if (costIndice != null)
                {
                    decimal costIndex = costIndice.cost_indices.Find(x => x.activity == Objects.CostIndiceActivity.ACtivityReaction).cost_index;
                    ReactionsSCILabel.Text = String.Format("{0:P2}.", costIndex);
                }
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
            InventionInputGrid.DataSource = InventionMats.OrderBy(x => x.materialName).ToList();
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


            if (ScreenHelper.BlueprintBrowserHelper.CostIndicies != null && ScreenHelper.BlueprintBrowserHelper.CostIndicies.Count > 0)
            {
                int solarSystemId = (Int32)ManuSystemCombo.SelectedValue;
                Objects.CostIndice costIndice = ScreenHelper.BlueprintBrowserHelper.CostIndicies.Find(x => x.solar_system_id == solarSystemId);
                if (costIndice != null)
                {
                    decimal costIndex = costIndice.cost_indices.Find(x => x.activity == Objects.CostIndiceActivity.ActivityInvention).cost_index;
                    InventionSCILabel.Text = String.Format("{0:P2}.", costIndex);

                }
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
                EnableDisablePanel(Enums.Enums.ActivityReverseEngineering, ReverseEngineerPage, ref ReverseEngSkills);
                EnableDisablePanel(Enums.Enums.ActivityInvention, InventionPage, ref InventionSkills);
                EnableDisablePanel(Enums.Enums.ActivityReactions, ReactionPage, ref ReactionSkills);
            }
        }

        private void EnableDisablePanel(int activityID, TabPage tabPage, ref List<Objects.IndustryActivitySkill> skills)
        {
            if (IndustryActivityTypes.Find(x => x.activityID == activityID) != null)
            {
                if (!ActivityTabPanel.TabPages.Contains(tabPage))
                {
                    ActivityTabPanel.TabPages.Add(tabPage);
                    switch (tabPage.Name)
                    {
                        case "ManufacturingPage":
                            SetManufacturingDefaultValues();
                            break;
                        case "ReactionPage":
                            SetReactionDefaultValues();
                            break;
                        case "InventionPage":
                            SetInventionDefaultValues();
                            break;
                    }
                }
                skills = Database.SQLiteCalls.GetINdustryActivitySkills(SelectedType.typeId, activityID);
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

                int productTypeId = (int)InventionOutcomeBPCombo.SelectedValue;
                if (productTypeId <= 0)
                {
                    productTypeId = InventionProds[0].productTypeID;
                }
                if (!InventionImageWorker.IsBusy)
                {
                    InventionImageWorker.RunWorkerAsync(argument: productTypeId);
                }
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
            TotalInputVolumeLabel.Text = "";
            TotalCostLabel.Text = "";
            ROILabel.Text = "";


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
            TotalInputVolumeLabel.Visible = true;
            TotalCostLabel.Visible = true;
            ROILabel.Visible = true;
        }

        private void DatabindManufacturingSumary()
        {
            SummaryTypeLabel.Text = "Manufacturing Summary";
            TotalTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(TotalManufacturingJobTime);
            TotalJobCostLabel.Text = string.Concat("-", TotalManufacturingJobCost.ToString("C"));

            decimal profit = TotalManufacturingOutputPrice - ManufacturingTotalInputPrice - TotalManufacturingJobCost - TotalManufacturingTaxesAndFees;
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
            TotalInputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalManufacturingInputVolume);
            decimal totalCost = ManufacturingTotalInputPrice + TotalManufacturingTaxesAndFees + TotalManufacturingJobCost;
            TotalCostLabel.Text = String.Concat("- ", totalCost.ToString("C"));
            if (totalCost > 0)
            {
                decimal roi = Math.Round(profit / totalCost, 4);
                ROILabel.Text = roi.ToString("P");
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
            TotalInputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalReactionInputVolume);
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
            TotalInputVolumeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatNumber(TotalInventionInputVolume);
            decimal totalCost = InventionTotalInputPrice + TotalInventionTaxesAndFees + TotalInventionJobCost;
            TotalCostLabel.Text = string.Concat("- ", totalCost.ToString("C"));
            ROILabel.Visible = false;
        }
        #endregion

        #endregion

        #region "Background Workers"
        private void BlueprintInitBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ScreenHelper.BlueprintBrowserHelper.InitLongLoading();
        }

        private void BlueprintImageBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            byte[] bpImage = null;
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
            byte[] bpImage = null;
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
            byte[] iamge = null;
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
        #endregion

        private void InventionImageWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            byte[] iamge = null;
            if (HasInventionActivity())
            {
                int outputTypeId = (int)(e.Argument);

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
    }
}