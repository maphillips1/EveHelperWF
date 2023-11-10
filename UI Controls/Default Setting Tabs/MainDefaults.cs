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
    public partial class MainDefaults : Objects.FormBase
    {
        public static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();
        private const string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private const string CachedFormValuesFileName = "form_values.json";

        public MainDefaults(Objects.DefaultFormValue defaultFormValues)
        {
            DefaultFormValues = defaultFormValues;
            InitializeComponent();
            LoadCombos();
            LoadDefaults();
        }

        private void LoadCombos()
        {
            InputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetInputPriceTypeItems();
            InputOrderTypeCombo.DisplayMember = "Value";
            InputOrderTypeCombo.ValueMember = "Key";

            OutputOrderTypeCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetOutputPriceTypeItems();
            OutputOrderTypeCombo.DisplayMember = "Value";
            OutputOrderTypeCombo.ValueMember = "Key";
        }

        private void LoadDefaults()
        {
            if (DefaultFormValues.RunsUpDownValue > 0)
            {
                RunsUpDown.Value = DefaultFormValues.RunsUpDownValue;
            }
            InputOrderTypeCombo.SelectedValue = DefaultFormValues.InputTypeComboValue;
            OutputOrderTypeCombo.SelectedValue = DefaultFormValues.OutputTypeComboValue;
            InventBlueprintCheckbox.Checked = DefaultFormValues.InventBlueprintCheckboxValue;
        }

        private void MainDefaults_FormClosing(object sender, FormClosingEventArgs e)
        {
            DefaultFormValues.RunsUpDownValue = Convert.ToDecimal(RunsUpDown.Value);
            DefaultFormValues.InputTypeComboValue = Convert.ToInt32(InputOrderTypeCombo.SelectedValue);
            DefaultFormValues.OutputTypeComboValue = Convert.ToInt32(OutputOrderTypeCombo.SelectedValue);
            DefaultFormValues.InventBlueprintCheckboxValue = InventBlueprintCheckbox.Checked;

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(DefaultFormValues);
            string filename = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            FileIO.FileHelper.SaveCachedFile(CachedFormValuesDirectory, filename, content);
        }
    }
}
