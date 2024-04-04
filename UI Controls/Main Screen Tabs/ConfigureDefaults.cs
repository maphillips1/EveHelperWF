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

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class ConfigureDefaults : Objects.FormBase
    {
        public static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();
        private const string CachedFormValuesFileName = "form_values.json";

        #region "Init"
        public ConfigureDefaults()
        {
            LoadDefaultsFromFile();
            ScreenHelper.BlueprintBrowserHelper.Init();
            InitializeComponent();
            LoadCombos();
            SetFieldValues();
        }

        private void LoadDefaultsFromFile()
        {

            string combinedFileName = string.Concat(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
            string content = FileIO.FileHelper.GetFileContent(Enums.Enums.CachedFormValuesDirectory, combinedFileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                DefaultFormValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.DefaultFormValue>(content);
            }
            if (DefaultFormValues == null) { DefaultFormValues = new Objects.DefaultFormValue(); }
        }

        private void LoadCombos()
        {
            //Main
            InputOrderTypeCombo.BindingContext = new BindingContext();
            InputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetPriceTypeComboItems();
            InputOrderTypeCombo.DisplayMember = "Value";
            InputOrderTypeCombo.ValueMember = "Key";

            OutputOrderTypeCombo.BindingContext = new BindingContext();
            OutputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetPriceTypeComboItems();
            OutputOrderTypeCombo.DisplayMember = "Value";
            OutputOrderTypeCombo.ValueMember = "Key";

            //Manufacturing
            SystemCombo.BindingContext = new BindingContext();
            SystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            SystemCombo.DisplayMember = "Value";
            SystemCombo.ValueMember = "Key";

            StructureCombo.BindingContext = new BindingContext();
            StructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            StructureCombo.DisplayMember = "Value";
            StructureCombo.ValueMember = "Key";

            StructureMERigCombo.BindingContext = new BindingContext();
            StructureMERigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            StructureMERigCombo.DisplayMember = "Value";
            StructureMERigCombo.ValueMember = "Key";

            StructureTERigCombo.BindingContext = new BindingContext();
            StructureTERigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            StructureTERigCombo.DisplayMember = "Value";
            StructureTERigCombo.ValueMember = "Key";

            ImplantCombo.BindingContext = new BindingContext();
            ImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingImplantItems();
            ImplantCombo.DisplayMember = "Value";
            ImplantCombo.ValueMember = "Key";

            //Invention
            InventionSolarSystemCombo.BindingContext = new BindingContext();
            InventionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            InventionSolarSystemCombo.DisplayMember = "Value";
            InventionSolarSystemCombo.ValueMember = "Key";

            InventionStructureCombo.BindingContext = new BindingContext();
            InventionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            InventionStructureCombo.DisplayMember = "Value";
            InventionStructureCombo.ValueMember = "Key";

            InventionStructureCostRigCombo.BindingContext = new BindingContext();
            InventionStructureCostRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            InventionStructureCostRigCombo.DisplayMember = "Value";
            InventionStructureCostRigCombo.ValueMember = "Key";

            InventionStructureTimeRigCombo.BindingContext = new BindingContext();
            InventionStructureTimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            InventionStructureTimeRigCombo.DisplayMember = "Value";
            InventionStructureTimeRigCombo.ValueMember = "Key";

            InventionDecryptorCombo.BindingContext = new BindingContext();
            InventionDecryptorCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetDecryptors();
            InventionDecryptorCombo.DisplayMember = "typeName";
            InventionDecryptorCombo.ValueMember = "typeID";

            //Reactions
            ReactionSolarSystemCombo.BindingContext = new BindingContext();
            ReactionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetLowAndNullSecComboItems();
            ReactionSolarSystemCombo.DisplayMember = "Value";
            ReactionSolarSystemCombo.ValueMember = "Key";

            ReactionStructureCombo.BindingContext = new BindingContext();
            ReactionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetRefineryComboItems();
            ReactionStructureCombo.DisplayMember = "Value";
            ReactionStructureCombo.ValueMember = "Key";

            ReactionStructureMERig.BindingContext = new BindingContext();
            ReactionStructureMERig.DataSource = CommonHelper.GetStructureBonusComboItems();
            ReactionStructureMERig.DisplayMember = "Value";
            ReactionStructureMERig.ValueMember = "Key";

            ReactionStructureTERig.BindingContext = new BindingContext();
            ReactionStructureTERig.DataSource = CommonHelper.GetStructureBonusComboItems();
            ReactionStructureTERig.DisplayMember = "Value";
            ReactionStructureTERig.ValueMember = "Key";

            //Copying
            CopySystemCombo.BindingContext = new BindingContext();
            CopySystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            CopySystemCombo.DisplayMember = "Value";
            CopySystemCombo.ValueMember = "Key";

            CopyStructureCombo.BindingContext = new BindingContext();
            CopyStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            CopyStructureCombo.DisplayMember = "Value";
            CopyStructureCombo.ValueMember = "Key";

            CopyImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetCopyImplantItems();
            CopyImplantCombo.DisplayMember = "Value";
            CopyImplantCombo.ValueMember = "Key";

            CopyTimeRigCombo.BindingContext = new BindingContext();
            CopyTimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            CopyTimeRigCombo.DisplayMember = "Value";
            CopyTimeRigCombo.ValueMember = "Key";

            //ME
            MESystemCombo.BindingContext = new BindingContext();
            MESystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            MESystemCombo.DisplayMember = "Value";
            MESystemCombo.ValueMember = "Key";

            MEStructureCombo.BindingContext = new BindingContext();
            MEStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            MEStructureCombo.DisplayMember = "Value";
            MEStructureCombo.ValueMember = "Key";

            MEImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetMEIMplentItems();
            MEImplantCombo.DisplayMember = "Value";
            MEImplantCombo.ValueMember = "Key";

            METimeRigCombo.BindingContext = new BindingContext();
            METimeRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            METimeRigCombo.DisplayMember = "Value";
            METimeRigCombo.ValueMember = "Key";

            //TE
            TESystemCombo.BindingContext = new BindingContext();
            TESystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            TESystemCombo.DisplayMember = "Value";
            TESystemCombo.ValueMember = "Key";

            TEStructureCombo.BindingContext = new BindingContext();
            TEStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            TEStructureCombo.DisplayMember = "Value";
            TEStructureCombo.ValueMember = "Key";

            TEImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetTEImplantItems();
            TEImplantCombo.DisplayMember = "Value";
            TEImplantCombo.ValueMember = "Key";

            TEStructRigCombo.BindingContext = new BindingContext();
            TEStructRigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            TEStructRigCombo.DisplayMember = "Value";
            TEStructRigCombo.ValueMember = "Key";




        }

        private void SetFieldValues()
        {
            if (DefaultFormValues != null)
            {
                //Main
                if (DefaultFormValues.RunsUpDownValue > 0)
                {
                    RunsUpDown.Value = DefaultFormValues.RunsUpDownValue;
                }
                InputOrderTypeCombo.SelectedValue = DefaultFormValues.InputTypeComboValue;
                OutputOrderTypeCombo.SelectedValue = DefaultFormValues.OutputTypeComboValue;
                InventBlueprintCheckbox.Checked = DefaultFormValues.InventBlueprintCheckboxValue;

                //Manufacturing
                MEUpDown.Value = DefaultFormValues.ManufacturingMEValue;
                TEUpDown.Value = DefaultFormValues.ManufacturingTEValue;
                SystemCombo.SelectedValue = DefaultFormValues.ManufacturingSystemValue;
                StructureCombo.SelectedValue = DefaultFormValues.ManufacturingStructureValue;
                StructureMERigCombo.SelectedValue = DefaultFormValues.ManufacturingStructureMERigValue;
                StructureTERigCombo.SelectedValue = DefaultFormValues.ManufacturingStructureTERigValue;
                TaxUpDown.Value = DefaultFormValues.ManufacturingTaxValue;
                ImplantCombo.SelectedValue = DefaultFormValues.ManufacturingImplantValue;
                BuildComponentCheckbox.Checked = DefaultFormValues.BuildComponentsValue;
                CompMEUpDown.Value = DefaultFormValues.CompMEValue;
                CompTEUpDown.Value = DefaultFormValues.CompTEValue;

                //Invention
                InventionSolarSystemCombo.SelectedValue = DefaultFormValues.InventionSystemValue;
                InventionStructureCombo.SelectedValue = DefaultFormValues.InventionStructureValue;
                InventionStructureCostRigCombo.SelectedValue = DefaultFormValues.InventionStructureCostRigValue;
                InventionStructureTimeRigCombo.SelectedValue = DefaultFormValues.InventionStructureTimeRigValue;
                InventionDecryptorCombo.SelectedValue = DefaultFormValues.InventionDecryptorValue;
                InventionTaxUpDown.Value = DefaultFormValues.InventionTaxValue;

                //Reactions
                ReactionSolarSystemCombo.SelectedValue = DefaultFormValues.ReactionsSystemValue;
                ReactionStructureCombo.SelectedValue = DefaultFormValues.ReactionStructureValue;
                ReactionStructureMERig.SelectedValue = DefaultFormValues.ReactionStructureMERigValue;
                ReactionStructureTERig.SelectedValue = DefaultFormValues.ReactionStructureTERigValue;
                ReactionTaxUpDown.Value = DefaultFormValues.ReactionTaxValue;

                //Copy
                if (DefaultFormValues.CopyNumCopies > 0)
                {
                    CopyNumCopiesUpDown.Value = DefaultFormValues.CopyNumCopies;
                }
                if (DefaultFormValues.CopyRunsCopy > 0)
                {
                    CopyRunsCopyUpDown.Value = DefaultFormValues.CopyRunsCopy;
                }
                CopySystemCombo.SelectedValue = DefaultFormValues.CopySystemID;
                CopyStructureCombo.SelectedValue = DefaultFormValues.CopyStructureTypeId;
                CopyTimeRigCombo.SelectedValue = DefaultFormValues.CopyStructureRig;
                CopyTaxUpDown.Value = DefaultFormValues.CopyTax;
                CopyImplantCombo.SelectedValue = DefaultFormValues.CopyImplantTypeID;

                //ME
                MEFromLevelUpDown.Value = DefaultFormValues.MEFromLevel;
                if (DefaultFormValues.METoLevel > 0)
                {
                    METoLevelUpDown.Value = DefaultFormValues.METoLevel;
                }
                MESystemCombo.SelectedValue = DefaultFormValues.MESystemID;
                MEStructureCombo.SelectedValue = DefaultFormValues.MEStructureTypeID;
                METimeRigCombo.SelectedValue = DefaultFormValues.MEStructureRIg;
                METaxUpDown.Value = DefaultFormValues.METax;
                MEImplantCombo.SelectedValue = DefaultFormValues.MEImplantTypeID;

                //TE
                TEFromLevelUpDown.Value = DefaultFormValues.TEFromLevel;
                if (DefaultFormValues.TEToLevel > 0)
                {
                    TEToLevelUpDown.Value = DefaultFormValues.TEToLevel;
                }
                TESystemCombo.SelectedValue = DefaultFormValues.TESystemID;
                TEStructureCombo.SelectedValue = DefaultFormValues.TEStructureTypeID;
                TEStructRigCombo.SelectedValue = DefaultFormValues.TEStructureRIg;
                TETaxUpDown.Value = DefaultFormValues.TETax;
                TEImplantCombo.SelectedValue = DefaultFormValues.TEImplantTypeID;

                //Skills
                AccountingLevelUpDown.Value = DefaultFormValues.AccountingSKill;
                BrokerRelationsLevelUpDown.Value = DefaultFormValues.BrokersSkill;
            }
        }
        #endregion

        #region "Events"
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFormValues();

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(DefaultFormValues);
            string filename = string.Concat(Enums.Enums.CachedFormValuesDirectory, CachedFormValuesFileName);
            FileIO.FileHelper.SaveFileContent(Enums.Enums.CachedFormValuesDirectory, filename, content);

            this.Close();
        }
        #endregion

        #region "Methods"
        private void SaveFormValues()
        {
            //Main
            DefaultFormValues.RunsUpDownValue = Convert.ToDecimal(RunsUpDown.Value);
            DefaultFormValues.InputTypeComboValue = Convert.ToInt32(InputOrderTypeCombo.SelectedValue);
            DefaultFormValues.OutputTypeComboValue = Convert.ToInt32(OutputOrderTypeCombo.SelectedValue);
            DefaultFormValues.InventBlueprintCheckboxValue = InventBlueprintCheckbox.Checked;

            //Manufacturing
            DefaultFormValues.ManufacturingMEValue = Convert.ToInt32(MEUpDown.Value);
            DefaultFormValues.ManufacturingTEValue = Convert.ToInt32(TEUpDown.Value);
            DefaultFormValues.ManufacturingSystemValue = Convert.ToInt32(SystemCombo.SelectedValue);
            DefaultFormValues.ManufacturingStructureValue = Convert.ToInt32(StructureCombo.SelectedValue);
            DefaultFormValues.ManufacturingStructureMERigValue = Convert.ToInt32(StructureMERigCombo.SelectedValue);
            DefaultFormValues.ManufacturingStructureTERigValue = Convert.ToInt32(StructureTERigCombo.SelectedValue);
            DefaultFormValues.ManufacturingTaxValue = Convert.ToDecimal(TaxUpDown.Value);
            DefaultFormValues.ManufacturingImplantValue = Convert.ToInt32(ImplantCombo.SelectedValue);
            DefaultFormValues.BuildComponentsValue = BuildComponentCheckbox.Checked;
            DefaultFormValues.CompMEValue = Convert.ToInt32(CompMEUpDown.Value);
            DefaultFormValues.CompTEValue = Convert.ToInt32(CompTEUpDown.Value);

            //Invention
            DefaultFormValues.InventionSystemValue = Convert.ToInt32(InventionSolarSystemCombo.SelectedValue);
            DefaultFormValues.InventionStructureValue = Convert.ToInt32(InventionStructureCombo.SelectedValue);
            DefaultFormValues.InventionStructureCostRigValue = Convert.ToInt32(InventionStructureCostRigCombo.SelectedValue);
            DefaultFormValues.InventionStructureTimeRigValue = Convert.ToInt32(InventionStructureTimeRigCombo.SelectedValue);
            DefaultFormValues.InventionDecryptorValue = Convert.ToInt32(InventionDecryptorCombo.SelectedValue);
            DefaultFormValues.InventionTaxValue = Convert.ToDecimal(InventionTaxUpDown.Value);

            //Reactions
            DefaultFormValues.ReactionsSystemValue = Convert.ToInt32(ReactionSolarSystemCombo.SelectedValue);
            DefaultFormValues.ReactionStructureValue = Convert.ToInt32(ReactionStructureCombo.SelectedValue);
            DefaultFormValues.ReactionStructureMERigValue = Convert.ToInt32(ReactionStructureMERig.SelectedValue);
            DefaultFormValues.ReactionStructureTERigValue = Convert.ToInt32(ReactionStructureTERig.SelectedValue);
            DefaultFormValues.ReactionTaxValue = Convert.ToDecimal(ReactionTaxUpDown.Value);

            //Copy
            DefaultFormValues.CopyNumCopies = Convert.ToInt32(CopyNumCopiesUpDown.Value);
            DefaultFormValues.CopyRunsCopy = Convert.ToInt32(CopyRunsCopyUpDown.Value);
            DefaultFormValues.CopySystemID = Convert.ToInt32(CopySystemCombo.SelectedValue);
            DefaultFormValues.CopyStructureTypeId = Convert.ToInt32(CopyStructureCombo.SelectedValue);
            DefaultFormValues.CopyStructureRig = Convert.ToInt32(CopyTimeRigCombo.SelectedValue);
            DefaultFormValues.CopyTax = Convert.ToDecimal(CopyTaxUpDown.Value);
            DefaultFormValues.CopyImplantTypeID = Convert.ToInt32(CopyImplantCombo.SelectedValue);

            //ME
            DefaultFormValues.MEFromLevel = Convert.ToInt32(MEFromLevelUpDown.Value);
            DefaultFormValues.METoLevel = Convert.ToInt32(METoLevelUpDown.Value);
            DefaultFormValues.MESystemID = Convert.ToInt32(MESystemCombo.SelectedValue);
            DefaultFormValues.MEStructureTypeID = Convert.ToInt32(MEStructureCombo.SelectedValue);
            DefaultFormValues.MEStructureRIg = Convert.ToInt32(METimeRigCombo.SelectedValue);
            DefaultFormValues.METax = Convert.ToDecimal(METaxUpDown.Value);
            DefaultFormValues.MEImplantTypeID = Convert.ToInt32(MEImplantCombo.SelectedValue);

            //TE
            DefaultFormValues.TEFromLevel = Convert.ToInt32(TEFromLevelUpDown.Value);
            DefaultFormValues.TEToLevel = Convert.ToInt32(TEToLevelUpDown.Value);
            DefaultFormValues.TESystemID = Convert.ToInt32(TESystemCombo.SelectedValue);
            DefaultFormValues.TEStructureTypeID = Convert.ToInt32(TEStructureCombo.SelectedValue);
            DefaultFormValues.TEStructureRIg = Convert.ToInt32(TEStructRigCombo.SelectedValue);
            DefaultFormValues.TETax = Convert.ToDecimal(TETaxUpDown.Value);
            DefaultFormValues.TEImplantTypeID = Convert.ToInt32(TEImplantCombo.SelectedValue);

            //Skills
            DefaultFormValues.AccountingSKill = Convert.ToInt32(AccountingLevelUpDown.Value);
            DefaultFormValues.BrokersSkill = Convert.ToInt32(BrokerRelationsLevelUpDown.Value);
        }
        #endregion
    }
}
