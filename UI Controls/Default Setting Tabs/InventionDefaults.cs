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
    public partial class InventionDefaults : Objects.FormBase
    {
        public static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();
        private const string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private const string CachedFormValuesFileName = "form_values.json";

        public InventionDefaults(Objects.DefaultFormValue defaultFormValue)
        {
            DefaultFormValues = defaultFormValue;
            InitializeComponent();
            LoadCombos();
            LoadDefaults();
        }

        private void LoadCombos()
        {
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
        }

        private void LoadDefaults()
        {
            InventionSolarSystemCombo.SelectedValue = DefaultFormValues.InventionSystemValue;
            InventionStructureCombo.SelectedValue = DefaultFormValues.InventionStructureValue;
            InventionStructureCostRigCombo.SelectedValue = DefaultFormValues.InventionStructureCostRigValue;
            InventionStructureTimeRigCombo.SelectedValue = DefaultFormValues.InventionStructureTimeRigValue;
            InventionDecryptorCombo.SelectedValue = DefaultFormValues.InventionDecryptorValue;
            InventionTaxUpDown.Value = DefaultFormValues.InventionTaxValue;
        }

        private void InventionsDefaults_FormClosing(object sender, FormClosingEventArgs e)
        {
            DefaultFormValues.InventionSystemValue = Convert.ToInt32(InventionSolarSystemCombo.SelectedValue);
            DefaultFormValues.InventionStructureValue = Convert.ToInt32(InventionStructureCombo.SelectedValue);
            DefaultFormValues.InventionStructureCostRigValue = Convert.ToInt32(InventionStructureCostRigCombo.SelectedValue);
            DefaultFormValues.InventionStructureTimeRigValue = Convert.ToInt32(InventionStructureTimeRigCombo.SelectedValue);
            DefaultFormValues.InventionDecryptorValue = Convert.ToInt32(InventionDecryptorCombo.SelectedValue);
            DefaultFormValues.InventionTaxValue = Convert.ToDecimal(InventionTaxUpDown.Value);


            string content = Newtonsoft.Json.JsonConvert.SerializeObject(DefaultFormValues);
            string filename = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            FileIO.FileHelper.SaveCachedFile(CachedFormValuesDirectory, filename, content);
        }
    }
}
