using EveHelperWF.Objects;
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

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class AddEditStructureProfile : Objects.FormBase
    {
        EveHelperWF.Objects.StructureProfile profileInEdit = null;
        public AddEditStructureProfile(EveHelperWF.Objects.StructureProfile profileToEdit)
        {
            InitializeComponent();
            profileInEdit = profileToEdit;
            LoadCombos();
            LoadProfile();
        }

        private void LoadCombos()
        {
            //Make sure it's been loaded. 
            ScreenHelper.BlueprintBrowserHelper.Init();

            SolarSystemCombo.DataSource = ScreenHelper.BlueprintBrowserHelper.GetAllSolarSystemComboItems();
            SolarSystemCombo.DisplayMember = "Value";
            SolarSystemCombo.ValueMember = "Key";

            List<ComboListItem> structures = new List<ComboListItem>();
            structures.AddRange(ScreenHelper.BlueprintBrowserHelper.GetEngineeringStructureItems());
            structures.AddRange(ScreenHelper.BlueprintBrowserHelper.GetRefineryComboItems());

            StructureTypeCombo.DataSource = structures;
            StructureTypeCombo.DisplayMember = "Value";
            StructureTypeCombo.ValueMember = "Key";

            MERigCombo.BindingContext = new BindingContext();
            MERigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            MERigCombo.DisplayMember = "Value";
            MERigCombo.ValueMember = "Key";

            TERigCombo.BindingContext = new BindingContext();
            TERigCombo.DataSource = CommonHelper.GetStructureBonusComboItems();
            TERigCombo.DisplayMember = "Value";
            TERigCombo.ValueMember = "Key";
        }

        private void LoadProfile()
        {
            ProfileNameTextBox.Text = profileInEdit.profileName;
            SolarSystemCombo.SelectedValue = profileInEdit.solarSystemID;
            StructureTypeCombo.SelectedValue = profileInEdit.structureTypeId;
            MERigCombo.SelectedValue = profileInEdit.MERig;
            TERigCombo.SelectedValue = profileInEdit.TERig;
            TaxAmountNumeric.Value = profileInEdit.taxAmount;
        }

        public void Save(ref EveHelperWF.Objects.StructureProfile profileToSave)
        {
            profileToSave.profileName = ProfileNameTextBox.Text;
            profileToSave.solarSystemID = Convert.ToInt32(SolarSystemCombo.SelectedValue);
            profileToSave.structureTypeId = Convert.ToInt32(StructureTypeCombo.SelectedValue);
            profileToSave.MERig = Convert.ToInt32(MERigCombo.SelectedValue);
            profileToSave.TERig = Convert.ToInt32(TERigCombo.SelectedValue);
            profileToSave.taxAmount = TaxAmountNumeric.Value;
        }
    }
}
