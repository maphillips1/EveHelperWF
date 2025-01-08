using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using System.Data;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class OptimizedBuildDetailsControl : Objects.FormBase
    {
        private OptimizedBuild OptimizedBuild;
        public OptimizedBuildDetailsControl(OptimizedBuild optimizedBuild)
        {
            InitializeComponent();
            this.OptimizedBuild = optimizedBuild;
            DatabindControls();
        }

        private void DatabindControls()
        {
            if (this.OptimizedBuild != null)
            {
                OutcomeNameLabel.Text = OptimizedBuild.BuiltOrReactedName;
                RunsNeededLabel.Text = OptimizedBuild.RunsNeeded.ToString("N0");
                TotalQuantityLabel.Text = OptimizedBuild.TotalQuantityNeeded.ToString("N0");
                BatchesNeededLabel.Text = OptimizedBuild.BatchesNeeded.ToString("N0");
                MaxRunsLabel.Text = OptimizedBuild.MaxRunsPerBatch.ToString("N0");
                WasteLabel.Text = OptimizedBuild.ExtraOutput.ToString("N0");
                JobCostLabel.Text = CommonHelper.FormatIsk(OptimizedBuild.JobCost);
                TotalCostLabel.Text = CommonHelper.FormatIsk(OptimizedBuild.TotalBuildCost);
                SetMaterialAndProductionCostLabel();
                BuildTimeLabel();
                BuildTreeView();
                SetInputVolumeLabel();
            }
        }

        private void BuildTimeLabel()
        {
            long timeNeeded = OptimizedBuild.RunsNeeded * OptimizedBuild.TimePerRun;
            TotalTimeLabel.Text = ScreenHelper.BlueprintBrowserHelper.FormatTimeAsString(timeNeeded);
        }

        private void BuildTreeView()
        {
            InputMatsTreeView.Nodes.Clear();
            TreeNode tn;
            TreeNode pricePerNode;
            TreeNode priceTotalNode;
            foreach (MaterialsWithMarketData mat in OptimizedBuild.InputMaterials.OrderBy(x => x.materialName))
            {
                tn = new TreeNode();
                tn.Text = "  " + mat.quantityTotal.ToString("N0") + " x " + mat.materialName;
                tn.ForeColor = BuildPlanHelper.GetForeColorForMaterialCategory(mat);
                tn.Expand();

                pricePerNode = new TreeNode();
                pricePerNode.Text = "Price Per Item: " + CommonHelper.FormatIsk(mat.pricePer);
                pricePerNode.ForeColor = Color.White;
                tn.Nodes.Add(pricePerNode);

                priceTotalNode = new TreeNode();
                priceTotalNode.Text = "Total Price: " + CommonHelper.FormatIsk(mat.priceTotal);
                priceTotalNode.ForeColor = Color.White;
                tn.Nodes.Add(priceTotalNode);

                InputMatsTreeView.Nodes.Add(tn);
            }
        }

        private void SetMaterialAndProductionCostLabel()
        {
            MaterialCostLabel.Text = CommonHelper.FormatIsk(OptimizedBuild.MaterialCost);
            decimal totalcost = OptimizedBuild.TotalBuildCost;
            decimal costPerItem = totalcost / OptimizedBuild.TotalQuantityNeeded;
            ProductCostLabel.Text = CommonHelper.FormatIsk(costPerItem);
        }

        private void SetInputVolumeLabel()
        {
            decimal totalVolume = 0;

            InventoryType inputType;
            foreach (MaterialsWithMarketData input in OptimizedBuild.InputMaterials)
            {
                inputType = CommonHelper.InventoryTypes.Find(x => x.typeId == input.materialTypeID);
                totalVolume += (inputType.volume * input.quantityTotal);
            }

            InputVolumeLabel.Text = totalVolume.ToString("N2") + " m3";
        }
    }
}
