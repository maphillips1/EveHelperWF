using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.UI_Controls.Support_Screens;
using FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class StructureProfile : Objects.FormBase
    {
        List<EveHelperWF.Objects.StructureProfile> profiles = new List<EveHelperWF.Objects.StructureProfile>();
        public EveHelperWF.Objects.StructureProfile profileInEdit = null;
        AddEditStructureProfile addEditScreen = null;
        bool isAdd = false;
        public StructureProfile()
        {
            InitializeComponent();
            profiles = CommonHelper.structureProfiles;
            DatabindGridView<List<EveHelperWF.Objects.StructureProfile>>(StructureProfilesGrid, profiles);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.profileInEdit = new EveHelperWF.Objects.StructureProfile();
            profiles.Add(this.profileInEdit);
            addEditScreen = new AddEditStructureProfile(this.profileInEdit);
            addEditScreen.SaveButton.Click += SaveButton_Click;
            addEditScreen.CancelButton.Click += CancelButton_Click;
            isAdd = true;
            addEditScreen.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (StructureProfilesGrid.SelectedRows.Count <= 0)
            {
                return;
            }
            profileInEdit = profiles.Find(x => x.profileName == StructureProfilesGrid.SelectedRows[0].Cells[0].Value.ToString());
            if (profileInEdit != null)
            {
                addEditScreen = new AddEditStructureProfile(this.profileInEdit);
                addEditScreen.SaveButton.Click += SaveButton_Click;
                addEditScreen.CancelButton.Click += CancelButton_Click;
                isAdd = false;
                addEditScreen.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            isAdd = false;
            if (StructureProfilesGrid.SelectedRows.Count <= 0)
            {
                return;
            }
            profileInEdit = profiles.Find(x => x.profileName == StructureProfilesGrid.SelectedRows[0].Cells[0].Value.ToString());
            if (profileInEdit != null)
            {
                profiles.Remove(profileInEdit);
                string allText = Newtonsoft.Json.JsonConvert.SerializeObject(profiles);
                string fileName = Enums.Enums.StructureProfilesDirectory + "StructureProfiles.json";
                FileHelper.SaveFileContent(Enums.Enums.StructureProfilesDirectory, fileName, allText);
                StructureProfilesGrid.DataSource = null;
                DatabindGridView<List<EveHelperWF.Objects.StructureProfile>>(StructureProfilesGrid, profiles);
            }
        }

        private void StructureProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            profiles.RemoveAll(x => x.profileId == 0);
            string fileName = Enums.Enums.StructureProfilesDirectory + "StructureProfiles.json";
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(profiles);
            FileHelper.SaveFileContent(fileName, content);
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            addEditScreen.Save(ref profileInEdit);
            bool continueSave = true;
            if (isAdd)
            {
                if (profiles.FindAll(x => x.profileName.ToLowerInvariant().Trim() == profileInEdit.profileName.ToLowerInvariant().Trim())?.Count > 1)
                {
                    MessageBox.Show("Error: A structure profile already exists with that name.", "Save Error");
                    continueSave = false;
                }
                else
                {
                    int maxId = 0;
                    foreach (EveHelperWF.Objects.StructureProfile profile in profiles)
                    {
                        maxId = Math.Max(maxId, profile.profileId);
                    }
                    profileInEdit.profileId = maxId + 1;
                }
            }
            if (continueSave)
            {
                addEditScreen.Close();
                string allText = Newtonsoft.Json.JsonConvert.SerializeObject(profiles);
                string fileName = Enums.Enums.StructureProfilesDirectory + "StructureProfiles.json";
                FileHelper.SaveFileContent(Enums.Enums.StructureProfilesDirectory, fileName, allText);
                DatabindGridView<List<EveHelperWF.Objects.StructureProfile>>(StructureProfilesGrid, profiles);
                CommonHelper.LoadStructureProfiles();
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            if (isAdd)
            {
                profiles.Remove(profileInEdit);
            }
        }

        private void StructureProfilesGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                        int systemId = (int)(e.Value);
                        SolarSystem solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == systemId);
                        if (solarSystem != null)
                        {
                            e.Value = solarSystem.solarSystemName;
                        }
                        break;
                    case 2:
                        int structureTypeId = (int)(e.Value);
                        EveHelperWF.Objects.InventoryType structureType = CommonHelper.InventoryTypes.Find(x => x.typeId == structureTypeId);
                        if (structureType != null)
                        {
                            e.Value = structureType.typeName;
                        }
                        break;
                    case 3:
                    case 4:
                        ComboListItem bonusItem = CommonHelper.GetStructureBonusComboItems().Find(x => x.key == (int)e.Value);
                        if (bonusItem != null)
                        {
                            e.Value = bonusItem.value;
                        }
                        break;
                }
            }
        }
    }
}
