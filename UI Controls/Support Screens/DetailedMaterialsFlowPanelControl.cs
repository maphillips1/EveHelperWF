using EveHelperWF.Objects;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class DetailedMaterialsFlowPanelControl : Objects.FormBase
    {
        public List<MaterialsWithMarketData> Materials;
        public DetailedMaterialsFlowPanelControl(List<MaterialsWithMarketData> mats)
        {
            Materials = mats;
            InitializeComponent();
        }
    }
}
