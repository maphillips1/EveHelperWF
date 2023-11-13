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
        private const string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private const string CachedFormValuesFileName = "form_values.json";

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

            string combinedFileName = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            string content = FileIO.FileHelper.GetCachedFileContent(CachedFormValuesDirectory, combinedFileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                DefaultFormValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.DefaultFormValue>(content);
            }
            if (DefaultFormValues == null) { DefaultFormValues = new Objects.DefaultFormValue(); }
        }

        private void LoadCombos()
        {
            //Main
            InputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInputPriceTypeItems();
            InputOrderTypeCombo.DisplayMember = "Value";
            InputOrderTypeCombo.ValueMember = "Key";

            OutputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetOutputPriceTypeItems();
            OutputOrderTypeCombo.DisplayMember = "Value";
            OutputOrderTypeCombo.ValueMember = "Key";

            //Manufacturing
            SystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingSolarSystemItems();
            SystemCombo.DisplayMember = "Value";
            SystemCombo.ValueMember = "Key";

            StructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            StructureCombo.DisplayMember = "Value";
            StructureCombo.ValueMember = "Key";

            StructureMERigCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingStructureMERigs();
            StructureMERigCombo.DisplayMember = "Value";
            StructureMERigCombo.ValueMember = "Key";

            StructureTERigCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingStructureTERigs();
            StructureTERigCombo.DisplayMember = "Value";
            StructureTERigCombo.ValueMember = "Key";

            ImplantCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetManufacturingImplantItems();
            ImplantCombo.DisplayMember = "Value";
            ImplantCombo.ValueMember = "Key";

            //Invention
            InventionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionSolarSystemItems();
            InventionSolarSystemCombo.DisplayMember = "Value";
            InventionSolarSystemCombo.ValueMember = "Key";

            InventionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems();
            InventionStructureCombo.DisplayMember = "Value";
            InventionStructureCombo.ValueMember = "Key";

            InventionStructureCostRigCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionStructureCostRigs();
            InventionStructureCostRigCombo.DisplayMember = "Value";
            InventionStructureCostRigCombo.ValueMember = "Key";

            InventionStructureTimeRigCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInventionStructureTERigs();
            InventionStructureTimeRigCombo.DisplayMember = "Value";
            InventionStructureTimeRigCombo.ValueMember = "Key";

            InventionDecryptorCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetDecryptors();
            InventionDecryptorCombo.DisplayMember = "typeName";
            InventionDecryptorCombo.ValueMember = "typeID";

            //Reactions
            ReactionSolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetReactionSolarSystemItems();
            ReactionSolarSystemCombo.DisplayMember = "Value";
            ReactionSolarSystemCombo.ValueMember = "Key";

            ReactionStructureCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetRefineryComboItems();
            ReactionStructureCombo.DisplayMember = "Value";
            ReactionStructureCombo.ValueMember = "Key";

            ReactionStructureMERig.DataSource = ScreenHelper.BlueprintBrowserHelper.GetReactionStructureMERigs();
            ReactionStructureMERig.DisplayMember = "Value";
            ReactionStructureMERig.ValueMember = "Key";

            ReactionStructureTERig.DataSource = ScreenHelper.BlueprintBrowserHelper.GetReactionStructureTERigs();
            ReactionStructureTERig.DisplayMember = "Value";
            ReactionStructureTERig.ValueMember = "Key";
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
            }
        }

        private void SaveFormValues()
        {
            //Main
            DefaultFormValues.RunsUpDownValue = Convert.ToDecimal(RunsUpDown.Value);
            DefaultFormValues.InputTypeComboValue = Convert.ToInt32(InputOrderTypeCombo.SelectedValue);
            DefaultFormValues.OutputTypeComboValue = Convert.ToInt32(OutputOrderTypeCombo.SelectedValue);
            DefaultFormValues.InventBlueprintCheckboxValue = InventBlueprintCheckbox.Checked;

            //Manufacturing
            DefaultFormValues.ManufacturingMEValue = Convert.ToDecimal(MEUpDown.Value);
            DefaultFormValues.ManufacturingTEValue = Convert.ToDecimal(TEUpDown.Value);
            DefaultFormValues.ManufacturingSystemValue = Convert.ToInt32(SystemCombo.SelectedValue);
            DefaultFormValues.ManufacturingStructureValue = Convert.ToInt32(StructureCombo.SelectedValue);
            DefaultFormValues.ManufacturingStructureMERigValue = Convert.ToInt32(StructureMERigCombo.SelectedValue);
            DefaultFormValues.ManufacturingStructureTERigValue = Convert.ToInt32(StructureTERigCombo.SelectedValue);
            DefaultFormValues.ManufacturingTaxValue = Convert.ToDecimal(TaxUpDown.Value);
            DefaultFormValues.ManufacturingImplantValue = Convert.ToInt32(ImplantCombo.SelectedValue);
            DefaultFormValues.BuildComponentsValue = BuildComponentCheckbox.Checked;
            DefaultFormValues.CompMEValue = Convert.ToDecimal(CompMEUpDown.Value);
            DefaultFormValues.CompTEValue = Convert.ToDecimal(CompTEUpDown.Value);

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
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFormValues();

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(DefaultFormValues);
            string filename = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            FileIO.FileHelper.SaveCachedFile(CachedFormValuesDirectory, filename, content);

            this.Close();
        }
    }
}
