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
using System.Windows.Forms.DataVisualization.Charting;

namespace EveHelperWF.Objects.Custom_Controls
{
    public partial class PriceHistory : UserControl
    {
        private bool _isLoading = false;
        private List<ESIPriceHistory> priceHistories = new List<ESIPriceHistory>();
        private Dictionary<DateTime, double> avgSeries = new Dictionary<DateTime, double>();
        private Dictionary<DateTime, double> lowSeries = new Dictionary<DateTime, double>();
        private Dictionary<DateTime, double> highSeries = new Dictionary<DateTime, double>();

        public PriceHistory()
        {
            _isLoading = true;
            InitializeComponent();
            DatabindCombo();
            _isLoading = false;
            this.BackColor = Enums.Enums.BackgroundColor;
            this.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);
            
        }

        private void DatabindCombo()
        {
            List<ComboListItem> comboListItems = new List<ComboListItem>();

            comboListItems.Add(new ComboListItem() { value = "30 Days", key = 1 });
            comboListItems.Add(new ComboListItem() { value = "60 Days", key = 2 });
            comboListItems.Add(new ComboListItem() { value = "90 Days", key = 3 });
            comboListItems.Add(new ComboListItem() { value = "6 month", key = 4 });
            comboListItems.Add(new ComboListItem() { value = "1 year", key = 5 });
            comboListItems.Add(new ComboListItem() { value = "All", key = 6 });

            DateRangeCombo.DisplayMember = "value";
            DateRangeCombo.ValueMember = "key";
            DateRangeCombo.DataSource = comboListItems;
            DateRangeCombo.SelectedValue = 1;
        }

        public void DatabindPriceHistory(List<ESIPriceHistory> priceHistory)
        {
            priceHistories.Clear();
            priceHistories.AddRange(priceHistory);
            priceHistories = priceHistories.OrderByDescending(x => x.date).ToList();
            DateTime firstDate = GetFirstDate();
            List<ESIPriceHistory> filteredPriceHistories = priceHistories.FindAll(x => DateTime.ParseExact(x.date, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture) >= firstDate);
            DatabindGridView(filteredPriceHistories);
            BuildChart(filteredPriceHistories);
        }

        private void DatabindGridView(List<ESIPriceHistory> filteredPriceHistories)
        {
            PriceHistoryGridView.DatabindGridView(filteredPriceHistories);
        }

        private void BuildChart(List<ESIPriceHistory> filteredPriceHistories)
        {
            filteredPriceHistories = filteredPriceHistories.OrderBy(x => x.date).ToList();

            if (filteredPriceHistories.Count > 0)
            {
                List<ESIPriceHistory> nonZeroHistories = filteredPriceHistories.FindAll(x => x.lowest > 0);
                double minYValue = nonZeroHistories.Min(x => x.lowest);
                minYValue = minYValue * 0.9;
                double maxYValue = nonZeroHistories.Max(x => x.highest);
                maxYValue = maxYValue * 1.1;

                PriceHistoryChart.ChartAreas[0].AxisY.Minimum = minYValue;
                PriceHistoryChart.ChartAreas[0].AxisY.Maximum = maxYValue;
                PriceHistoryChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N2}";

                PriceHistoryChart.ChartAreas[0].BackColor = Enums.Enums.BackgroundColor;
                PriceHistoryChart.ChartAreas[0].BackSecondaryColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

                PriceHistoryChart.Series["Average"].XValueMember = "date";
                PriceHistoryChart.Series["Low"].XValueMember = "date";
                PriceHistoryChart.Series["High"].XValueMember = "date";

                PriceHistoryChart.Series["Average"].YValueMembers = "average";
                PriceHistoryChart.Series["Low"].YValueMembers = "lowest";
                PriceHistoryChart.Series["High"].YValueMembers = "highest";

                int step = (int)Math.Round((decimal)(filteredPriceHistories.Count / 10));
                if (step > 1)
                {
                    for (int i = 0; i < filteredPriceHistories.Count; i += step)
                    {

                        PriceHistoryChart.Series["Average"].Points.Add(i, filteredPriceHistories[i].average);
                        PriceHistoryChart.Series["Low"].Points.Add(i, filteredPriceHistories[i].lowest);
                        PriceHistoryChart.Series["High"].Points.Add(i, filteredPriceHistories[i].highest);
                    }
                }
                else
                {
                    int i = 0;
                    foreach (ESIPriceHistory priceHistory in filteredPriceHistories)
                    {
                        PriceHistoryChart.Series["Average"].Points.Add(i, filteredPriceHistories[i].average);
                        PriceHistoryChart.Series["Low"].Points.Add(i, filteredPriceHistories[i].lowest);
                        PriceHistoryChart.Series["High"].Points.Add(i, filteredPriceHistories[i].highest);
                        i++;
                    }
                }
            }

            PriceHistoryChart.DataSource = filteredPriceHistories;
        }

        private DateTime GetFirstDate()
        {
            DateTime firstDate = new DateTime();

            switch (DateRangeCombo.SelectedValue)
            {
                case 1:
                    firstDate = DateTime.Now.AddDays(-30);
                    break;
                case 2:
                    firstDate = DateTime.Now.AddDays(-60);
                    break;
                case 3:
                    firstDate = DateTime.Now.AddDays(-90);
                    break;
                case 4:
                    firstDate = DateTime.Now.AddMonths(-6);
                    break;
                case 5:
                    firstDate = DateTime.Now.AddYears(-1);
                    break;
                default:
                    firstDate = new DateTime(1800, 1, 1);
                    break;
            }

            return firstDate;
        }

        private void DateRangeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
            {
                DateTime firstDate = GetFirstDate();
                List<ESIPriceHistory> filteredPriceHistories = priceHistories.FindAll(x => DateTime.ParseExact(x.date, "yyyy-MM-dd",
                                           System.Globalization.CultureInfo.InvariantCulture) >= firstDate);
                DatabindGridView(filteredPriceHistories);
                BuildChart(filteredPriceHistories);
            }
        }
    }
}
