using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using FileIO;
using System.Data;
using System.Text;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class BuildPlanDetailsTab : Objects.Custom_Controls.UserControlBase
    {

        OptimizedBuildDetailsControl DetailsControl = null;
        List<OptimizedBuild> CurrentOptimizedBuilds = null;
        List<MaterialsWithMarketData> CurrentInputMaterials = null;
        List<BlueprintInfo> CurrentBlueprintStore = null;
        Dictionary<int, List<OptimizedBuild>> CurrentOptimumBuildGroups = null;
        List<int> CompletedBuilds = new List<int>();

        public BuildPlanDetailsTab()
        {
            InitializeComponent();
        }

        public void LoadDetailsControl(List<OptimizedBuild> optimizedBuilds,
                                   List<MaterialsWithMarketData> inputMaterials,
                                   List<BlueprintInfo> blueprintStore,
                                   Dictionary<int, List<OptimizedBuild>> optimumBuildGroups,
                                   List<int> completedBuilds,
                                   string finalProductTypeName,
                                   int totalOutcome)
        {
            this.CurrentOptimizedBuilds = optimizedBuilds;
            this.CurrentInputMaterials = inputMaterials;
            this.CurrentBlueprintStore = blueprintStore;
            this.CurrentOptimumBuildGroups = optimumBuildGroups;
            this.CompletedBuilds = completedBuilds;

            MaterialsTreeView.Nodes.Clear();
            MaterialsTreeView.Nodes.AddRange(AddMaterialsToTreeView(this.CurrentInputMaterials).ToArray());
            DetailsProductLabel.Text = finalProductTypeName + " x " + totalOutcome.ToString("N0");
            LoadOptimumBuildSchedule();
        }

        public void UpdateCompletedBuildsList(List<int> completedBuilds)
        {
            this.CompletedBuilds = completedBuilds;
        }

        #region "Events"
        private void CollapseAll_Click(object sender, EventArgs e)
        {
            MaterialsTreeView.CollapseAll();
        }

        private void OptimizedBuildTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Action != TreeViewAction.Unknown)
            {
                int optimizedTypeId = Convert.ToInt32(e.Node.Tag);
                if (optimizedTypeId > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    OptimizedBuild optimizedBuild = this.CurrentOptimizedBuilds.Find(x => x.BuiltOrReactedTypeId == optimizedTypeId);
                    if (optimizedBuild != null)
                    {
                        DetailsControl = new OptimizedBuildDetailsControl(optimizedBuild);
                        DetailsControl.ShowDialog();
                    }
                    this.Cursor = Cursors.Default;
                    OptimizedBuildTreeView.SelectedNode = null;
                }
            }
        }

        private void ExportBuildListButton_Click(object sender, EventArgs e)
        {
            DialogResult result = SaveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string fileName = SaveFileDialog.FileName;
                    string pathEx = Path.GetExtension(fileName);
                    if (pathEx.ToLowerInvariant().Replace(".", "") == "csv")
                    {
                        StringBuilder sb = new StringBuilder();
                        if (this.CurrentOptimumBuildGroups != null && this.CurrentOptimumBuildGroups.Count > 0)
                        {
                            List<int> orderedKeys = this.CurrentOptimumBuildGroups.Keys.OrderBy(x => x).ToList();
                            foreach (int key in orderedKeys)
                            {
                                sb.AppendLine("Build Group: " + key.ToString());
                                sb.AppendLine("Material Name, Quantity Needed, Runs Needed, Is Complete");

                                foreach (OptimizedBuild build in this.CurrentOptimumBuildGroups[key].OrderBy(x => x.BuiltOrReactedName))
                                {
                                    sb.AppendLine(build.BuiltOrReactedName + "," + build.TotalQuantityNeeded + "," + build.RunsNeeded + ", False");
                                }
                                sb.AppendLine("");
                            }
                        }
                        FileHelper.SaveFileContent(fileName, sb.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Error: Invalid File Type. Expected CSV, Got " + pathEx);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error ocurred during export: " + ex.Message);
                }
            }
        }

        private void CollapseAllButton_Click(object sender, EventArgs e)
        {
            MaterialsTreeView.CollapseAll();
        }
        #endregion

        public void ResetControls()
        {
            MaterialsTreeView.Nodes.Clear();
            OptimizedBuildTreeView.Nodes.Clear();
            TotalManufacturingSlotsLabel.Text = string.Empty;
            TotalReactionSlotsLabel.Text = string.Empty;
            DetailsProductLabel.Text = "";
            DetailsImagePanel.BackgroundImage = null;
        }

        private List<TreeNode> AddMaterialsToTreeView(List<MaterialsWithMarketData> materialsToBind)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            List<MaterialsWithMarketData> orderedList;
            TreeNode node;
            StringBuilder sb = new StringBuilder();

            foreach (MaterialsWithMarketData inputMaterial in materialsToBind)
            {
                sb = new StringBuilder();

                node = new TreeNode();
                node.Tag = inputMaterial.controlName;

                sb.Append("  " + inputMaterial.quantityTotal.ToString("N0") + " x " + inputMaterial.materialName);

                if (inputMaterial.Buildable || inputMaterial.Reactable)
                {
                    BlueprintInfo bpInfo = CurrentBlueprintStore.Find(x => x.ProductTypeId == inputMaterial.materialTypeID);
                    if (bpInfo != null)
                    {
                        if (bpInfo.Manufacture || bpInfo.React)
                        {
                            node.Expand();
                            if (inputMaterial.ChildMaterials.Count > 0)
                            {
                                sb.Append(" | Runs Needed: " + inputMaterial.RunsNeeded.ToString("N0"));
                                node.Nodes.AddRange(AddMaterialsToTreeView(inputMaterial.ChildMaterials).ToArray());
                            }
                        }
                    }
                }
                node.Text = sb.ToString();
                node.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(inputMaterial);

                nodes.Add(node);
            }
            return nodes;
        }

        private void LoadOptimumBuildSchedule()
        {
            BuildOptimumBuildTreeView(this.CurrentOptimumBuildGroups);
            int manufacturingCount = this.CurrentOptimizedBuilds.FindAll(x => x.isBuilt).Sum(x => x.BatchesNeeded);
            int reactionCount = this.CurrentOptimizedBuilds.FindAll(x => x.isReacted).Sum(x => x.BatchesNeeded);
            TotalManufacturingSlotsLabel.Text = manufacturingCount.ToString("N0");
            TotalReactionSlotsLabel.Text = reactionCount.ToString("N0");
        }

        private void BuildOptimumBuildTreeView(Dictionary<int, List<OptimizedBuild>> optimumBuildGroups)
        {
            OptimizedBuildTreeView.Nodes.Clear();
            if (optimumBuildGroups != null)
            {
                TreeNode keyNode;
                TreeNode treeNode;
                foreach (int key in optimumBuildGroups.Keys)
                {
                    keyNode = new TreeNode();
                    keyNode.Text = "Build Group " + key.ToString();

                    foreach (OptimizedBuild build in optimumBuildGroups[key].OrderBy(x => x.BuiltOrReactedName))
                    {
                        treeNode = new TreeNode();
                        treeNode.Text = build.TotalQuantityNeeded.ToString("N0") + " x " + build.BuiltOrReactedName + " | Runs Needed: " + build.RunsNeeded;
                        treeNode.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(build);
                        treeNode.Tag = build.BuiltOrReactedTypeId;
                        treeNode.Checked = this.CompletedBuilds.Contains(build.BuiltOrReactedTypeId);
                        if (build.BatchesNeeded > 1)
                        {
                            treeNode.Text += " | Max Runs/Batch " + build.MaxRunsPerBatch + " | Batches Needed | " + build.BatchesNeeded;
                        }

                        AddTreeNodesForInputMats(build.InputMaterials, ref treeNode);
                        keyNode.Nodes.Add(treeNode);
                    }
                    OptimizedBuildTreeView.Nodes.Add(keyNode);
                }
            }
        }

        private void AddTreeNodesForInputMats(List<MaterialsWithMarketData> inputMats, ref TreeNode parentTreeNode)
        {
            TreeNode treeNode;
            List<MaterialsWithMarketData> orderedMats = inputMats.OrderBy(x => x.materialName).ToList();
            foreach (MaterialsWithMarketData mat in orderedMats)
            {
                treeNode = new TreeNode();
                treeNode.Text = "  " + mat.quantityTotal.ToString("N0") + " x " + mat.materialName;
                treeNode.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(mat);
                parentTreeNode.Nodes.Add(treeNode);
            }
        }

        public void LoadImage(Image? image)
        {
            DetailsImagePanel.BackgroundImage = image;
        }
    }
}
