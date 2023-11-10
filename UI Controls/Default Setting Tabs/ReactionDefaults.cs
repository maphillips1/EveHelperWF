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
    public partial class ReactionDefaults : Objects.FormBase
    {
        public static Objects.DefaultFormValue DefaultFormValues = new Objects.DefaultFormValue();
        private const string CachedFormValuesDirectory = @"C:\Temp\EveHelper\FormValues\";
        private const string CachedFormValuesFileName = "form_values.json";

        public ReactionDefaults(Objects.DefaultFormValue defaultFormValue)
        {
            DefaultFormValues = defaultFormValue;
            InitializeComponent();
            LoadCombos();
            LoadDefaults();
        }

        private void LoadCombos()
        {
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

        private void LoadDefaults()
        {
            ReactionSolarSystemCombo.SelectedValue = DefaultFormValues.ReactionsSystemValue;
            ReactionStructureCombo.SelectedValue = DefaultFormValues.ReactionStructureValue;
            ReactionStructureMERig.SelectedValue = DefaultFormValues.ReactionStructureMERigValue;
            ReactionStructureTERig.SelectedValue = DefaultFormValues.ReactionStructureTERigValue;
            ReactionTaxUpDown.Value = DefaultFormValues.ReactionTaxValue;
        }

        private void ReactionDefaults_FormClosing(object sender, FormClosingEventArgs e)
        {
            DefaultFormValues.ReactionsSystemValue = Convert.ToInt32(ReactionSolarSystemCombo.SelectedValue);
            DefaultFormValues.ReactionStructureValue = Convert.ToInt32(ReactionStructureCombo.SelectedValue);
            DefaultFormValues.ReactionStructureMERigValue = Convert.ToInt32(ReactionStructureMERig.SelectedValue);
            DefaultFormValues.ReactionStructureTERigValue = Convert.ToInt32(ReactionStructureTERig.SelectedValue);
            DefaultFormValues.ReactionTaxValue = Convert.ToDecimal(ReactionTaxUpDown.Value);


            string content = Newtonsoft.Json.JsonConvert.SerializeObject(DefaultFormValues);
            string filename = string.Concat(CachedFormValuesDirectory, CachedFormValuesFileName);
            FileIO.FileHelper.SaveCachedFile(CachedFormValuesDirectory, filename, content);
        }
    }
}
