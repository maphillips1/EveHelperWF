using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.Objects.Custom_Controls
{
    public partial class PriceHistoryGraph : System.Windows.Forms.Panel
    {
        public PriceHistoryGraph()
        {
            InitializeComponent();
            MinPriceLabel.ForeColor = Color.White;
            MaxPriceLabel.ForeColor = Color.White;
            MiddleValueLabel.ForeColor = Color.White;
            Mid1PriceLabel.ForeColor = Color.White;
            Mid2PriceLabel.ForeColor = Color.White;
        }

        static float[] dashValues = { 5, 2 };
        private Pen AveragePricePen = new Pen(Color.FromArgb(255, 0, 163, 108)) { Width = 5 };
        private Pen ChartLinePen = new Pen(Color.White) { Width = 5 };
        private Pen DashedLinePen = new Pen(Color.White) { Width = 3, DashPattern = dashValues };

        public bool DrawDashedLines { get; set; }

        private double MinPrice { get; set; }
        private double Mid1Price { get; set; }
        private double MiddleValue { get; set; }
        private double Mid2Price { get; set; }
        private double MaxPrice { get; set; }
        private DateTime MinDate { get; set; }
        private DateTime MaxDate { get; set; }
        private int LabelWidth = 75;
        private int LabelHeight = 20;

        private Label MinPriceLabel = new Label();
        private Label MaxPriceLabel = new Label();
        private Label MiddleValueLabel = new Label();
        private Label Mid1PriceLabel = new Label();
        private Label Mid2PriceLabel = new Label();


        private int m_SelectedTimePeriod = 0;
        public int SelectedTimePeriod
        {
            get
            {
                return m_SelectedTimePeriod;
            }
            set
            {
                m_SelectedTimePeriod = value;
                this.Refresh();
            }
        }

        private List<ESIPriceHistory> m_PriceHistoryDataSource = new List<ESIPriceHistory>();

        public List<ESIPriceHistory> PriceHistoryDataSource
        {
            get
            {
                return m_PriceHistoryDataSource;
            }
            set
            {
                m_PriceHistoryDataSource = value;
                this.Refresh();
            }
        }
        private List<ESIPriceHistory> FilteredPriceHistoryDataSource { get; set; }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (PriceHistoryDataSource != null)
            {
                if (FilterDataSource())
                {
                    SetPriceValues();
                    DrawGraph();
                }
            }
        }

        private bool FilterDataSource()
        {
            DateTime startingDate = GetDateForTimePeriod();
            FilteredPriceHistoryDataSource = PriceHistoryDataSource.FindAll(x => DateTime.Parse(x.date) > startingDate);
            return FilteredPriceHistoryDataSource != null && FilteredPriceHistoryDataSource.Count > 0;
        }

        private void SetPriceValues()
        {
            MinPrice = FilteredPriceHistoryDataSource.OrderBy(x => x.lowest).ToList()[0].lowest;
            MaxPrice = FilteredPriceHistoryDataSource.OrderByDescending(x => x.highest).ToList()[0].highest;
            MiddleValue = MaxPrice - ((MaxPrice - MinPrice) / 2);
            Mid1Price = (MiddleValue - ((MiddleValue - MinPrice) / 2));
            Mid2Price = MaxPrice - ((MaxPrice + MinPrice) / 2);
        }

        private DateTime GetDateForTimePeriod()
        {
            DateTime date = new DateTime(2003, 1, 1);

            switch (SelectedTimePeriod)
            {
                case (int)Enums.Enums.PriceHistoryTimePeriod.Week:
                    date = System.DateTime.Now.AddDays(-7);
                    break;
                case (int)Enums.Enums.PriceHistoryTimePeriod.ThirtyDays:
                    date = System.DateTime.Now.AddDays(-30);
                    break;
                case (int)Enums.Enums.PriceHistoryTimePeriod.SixtyDays:
                    date = System.DateTime.Now.AddDays(-60);
                    break;
                case (int)Enums.Enums.PriceHistoryTimePeriod.NinetyDays:
                    date = System.DateTime.Now.AddDays(-90);
                    break;
                case (int)Enums.Enums.PriceHistoryTimePeriod.SixMonths:
                    date = System.DateTime.Now.AddMonths(-6);
                    break;
                case (int)Enums.Enums.PriceHistoryTimePeriod.OneYear:
                    date = System.DateTime.Now.AddYears(-1);
                    break;
            }

            return date;
        }

        private void DrawGraph()
        {
            setPriceLabelText();
        }

        private void setPriceLabelText()
        {
            MinPriceLabel.Text = GetShortPriceLabelFromPrice(MinPrice);
            MaxPriceLabel.Text = GetShortPriceLabelFromPrice(MaxPrice);
            MiddleValueLabel.Text = GetShortPriceLabelFromPrice(MiddleValue);
            Mid1PriceLabel.Text = GetShortPriceLabelFromPrice(Mid1Price);
            Mid2PriceLabel.Text = GetShortPriceLabelFromPrice(Mid2Price);
        }

        private string GetShortPriceLabelFromPrice(double price)
        {
            string formattedLabel = "";

            if (price >= 1000000000)
            {
                formattedLabel = Math.Round(price / 1000000000).ToString() + " B";
            }
            else if (price >= 1000000)
            {
                formattedLabel = Math.Round(price / 1000000).ToString() + " M";
            }
            else if (price >= 1000)
            {
                formattedLabel = Math.Round(price / 1000).ToString() + " K";
            }
            else
            {
                formattedLabel = Math.Round(price).ToString(); 
            }


            return formattedLabel;
        }
    }
}
