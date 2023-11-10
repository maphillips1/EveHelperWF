using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF
{
    public partial class ManufacturingDefaults : Objects.FormBase
    {
        public static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();
        private const string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private const string CachedFormValuesFileName = "form_values.json";

        public ManufacturingDefaults(Objects.DefaultFormValue defaultFormValues)
        {
            DefaultFormValues = defaultFormValues;
            InitializeComponent();
            LoadCombos();
            LoadDefaults();
        }

        private void LoadCombos()
        {
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

        }

        private void LoadDefaults()
        {
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
        }

        private void ManufacturingDefaults_Closing(object sender, EventArgs e)
        {
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

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(DefaultFormValues);
            string filename = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            FileIO.FileHelper.SaveCachedFile(CachedFormValuesDirectory, filename, content);
        }
    }
}
