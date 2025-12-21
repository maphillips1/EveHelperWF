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
    public partial class BuildPlanPlanetMaterialsTab : Objects.Custom_Controls.UserControlBase
    {
        private List<PlanetMaterial> UniquePlanetMaterials;
        List<InventoryTypeWithQuantity> CurrentInventory;
        List<MaterialsWithMarketData> CombinedMats;

        public BuildPlanPlanetMaterialsTab()
        {
            InitializeComponent();
        }

        public void LoadPlanetMaterialsControl(List<InventoryTypeWithQuantity> currentInventory,
                                               List<MaterialsWithMarketData> combinedMats)
        {
            this.CurrentInventory = currentInventory;
            this.CombinedMats = combinedMats;

            PlanetMaterialsTreeView.Nodes.Clear();
            LoadUniquePlanetMaterials();
            if (UniquePlanetMaterials?.Count > 0)
            {
                LoadPlanetaryTreeView();
            }
        }

        private void LoadPlanetaryTreeView()
        {
            PlanetMaterialsTreeView.Nodes.Clear();
            PlanetMatsTotalTreeview.Nodes.Clear();

            UniquePlanetMaterials = UniquePlanetMaterials.OrderBy(x => x.typeName).ToList();

            TreeNode tn;
            List<PlanetMaterial> totalMats = new List<PlanetMaterial>();
            InventoryTypeWithQuantity currentInventoryAmount = null;
            foreach (PlanetMaterial planetMaterial in UniquePlanetMaterials)
            {
                currentInventoryAmount = this.CurrentInventory.Find(x => x.typeID == planetMaterial.typeID);
                if (currentInventoryAmount != null)
                {
                    if (currentInventoryAmount.quantity >= planetMaterial.quantity)
                    {
                        //If we already have all that we need, skip.
                        continue;
                    }
                }
                PlanetSchematicsHelper.GetInputsForSchematicRecurseive(planetMaterial);
                tn = BuildTreeViewForPIMatRecursive(planetMaterial);
                PlanetMaterialsTreeView.Nodes.Add(tn);
                AddTotalPlanetMats(planetMaterial, ref totalMats);
            }

            TreeNode P0_Node = new TreeNode();
            P0_Node.Text = "P0";
            TreeNode P1_Node = new TreeNode();
            P1_Node.Text = "P1";
            TreeNode P2_Node = new TreeNode();
            P2_Node.Text = "P2";
            TreeNode P3_Node = new TreeNode();
            P3_Node.Text = "P3";
            TreeNode P4_Node = new TreeNode();
            P4_Node.Text = "P4";
            if (totalMats.Count > 0)
            {
                totalMats = totalMats.OrderBy(x => x.typeName).ToList();
                foreach (PlanetMaterial material in totalMats)
                {
                    tn = BuildTreeViewForPI(material);

                    switch (material.groupID)
                    {
                        case 1042: //Basic Commodities
                            P1_Node.Nodes.Add(tn);
                            break;
                        case 1034: //Refined Commodities
                            P2_Node.Nodes.Add(tn);
                            break;
                        case 1040: //Specialized Commodities
                            P3_Node.Nodes.Add(tn);
                            break;
                        case 1041: //Advanced Commodities
                            P4_Node.Nodes.Add(tn);
                            break;
                        default:
                            P0_Node.Nodes.Add(tn);
                            break;
                    }
                }
                PlanetMatsTotalTreeview.Nodes.Add(P4_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P3_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P2_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P1_Node);
                PlanetMatsTotalTreeview.Nodes.Add(P0_Node);
            }
        }

        private void AddTotalPlanetMats(PlanetMaterial input, ref List<PlanetMaterial> totals)
        {
            if (totals.Find(x => x.typeID == input.typeID) == null)
            {
                totals.Add(input);
            }
            else
            {
                totals.Find(x => x.typeID == input.typeID).quantity += input.quantity;
            }
            if (input.Inputs.Count > 0)
            {
                foreach (PlanetMaterial child in input.Inputs)
                {
                    AddTotalPlanetMats(child, ref totals);
                }
            }
        }

        private TreeNode BuildTreeViewForPIMatRecursive(PlanetMaterial planetMaterial)
        {
            TreeNode treeNode = new TreeNode();

            treeNode.Text = planetMaterial.typeName;
            if (planetMaterial.quantity > 0)
            {
                treeNode.Text += " x " + planetMaterial.quantity.ToString("N0");
            }

            if (planetMaterial.Inputs != null && planetMaterial.Inputs.Count > 0)
            {
                foreach (PlanetMaterial piInput in planetMaterial.Inputs)
                {
                    treeNode.Nodes.Add(BuildTreeViewForPIMatRecursive(piInput));
                }
            }

            return treeNode;
        }

        private TreeNode BuildTreeViewForPI(PlanetMaterial planetMaterial)
        {
            TreeNode treeNode = new TreeNode();

            treeNode.Text = planetMaterial.typeName;
            if (planetMaterial.quantity > 0)
            {
                treeNode.Text += " x " + planetMaterial.quantity.ToString("N0");
            }


            return treeNode;
        }

        private void LoadUniquePlanetMaterials()
        {
            UniquePlanetMaterials = new List<PlanetMaterial>();
            InventoryType invType;
            PlanetMaterial existingMat;
            foreach (MaterialsWithMarketData mat in CombinedMats)
            {
                invType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                switch (invType.categoryID)
                {
                    case (int)Enums.Enums.InvTypeCategory.PlanetResource:
                    case (int)Enums.Enums.InvTypeCategory.PlanetIndustry:
                    case (int)Enums.Enums.InvTypeCategory.PlanetCommodity:
                        existingMat = UniquePlanetMaterials.Find(x => x.typeID == mat.materialTypeID);
                        if (existingMat != null)
                        {
                            existingMat.quantity += (int)mat.quantityTotal;
                        }
                        else
                        {
                            existingMat = new PlanetMaterial();
                            existingMat.typeID = mat.materialTypeID;
                            existingMat.typeName = mat.materialName;
                            existingMat.quantity = (int)mat.quantityTotal;
                            existingMat.groupName = invType.groupName;
                            existingMat.groupID = invType.groupId;
                            UniquePlanetMaterials.Add(existingMat);
                        }
                        break;
                }
            }
        }

        public void ResetControl()
        {
            if (UniquePlanetMaterials != null)
            {
                UniquePlanetMaterials.Clear();
            }
            if (CurrentInventory != null)
            {
                CurrentInventory.Clear();
            }
            if (CombinedMats != null)
            {
                CombinedMats.Clear();
            }
            PlanetMaterialsTreeView.Nodes.Clear();
            PlanetMatsTotalTreeview.Nodes.Clear();
        }
    }
}
