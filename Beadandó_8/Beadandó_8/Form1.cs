using Beadandó_8.Entities;
using Beadandó_8.MNBServiceReference1;
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
using System.Xml;

namespace Beadandó_8
{

    public partial class Form1 : Form
    {
        BindingList<RateData> _rates = new BindingList<RateData>();
        BindingList<string> currencies = new BindingList<string>();


        public Form1()
        {
            InitializeComponent();
            loadCurrencyxml(getCurrencies());
            cmbValuta.DataSource = currencies;
            RefreshData();
        }

        private void RefreshData()
        {
            if (cmbValuta.SelectedItem == null) return;
            _rates.Clear();
            loadXml(getRates());
            dataGridView1.DataSource = _rates;
            makeChart();
        }

        private void makeChart()
        {
            chartRate.DataSource = _rates;
            var sorozatok = chartRate.Series[0];
            sorozatok.ChartType = SeriesChartType.Line;
            sorozatok.XValueMember = "Date";
            sorozatok.YValueMembers = "Value";
            sorozatok.BorderWidth = 2;

            var legend = chartRate.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRate.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void loadXml(string xmlstring)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlstring);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData r = new RateData();
                r.Date = DateTime.Parse(item.GetAttribute("date"));
              
                    var childElement = (XmlElement)item.ChildNodes[0];
                if (childElement != null)
                { 
                    r.Currency = childElement.GetAttribute("curr");

                    var unit = decimal.Parse(childElement.GetAttribute("unit"));
                    var value = decimal.Parse(childElement.InnerText);
                    if (unit != 0)
                        r.Value = value / unit;
                    _rates.Add(r);
                }
            }
        }

        private string getRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var req = new GetExchangeRatesRequestBody();
            {
                req.currencyNames = cmbValuta.SelectedItem.ToString(); // "EUR";
                req.startDate = dateTimeTol.Value.ToString("yyyy-MM-dd"); // "2020-01-01";
                req.endDate = dateTimeIg.Value.ToString("yyyy-MM-dd"); // "2020-06-30";
                var respone = mnbService.GetExchangeRates(req);
                return respone.GetExchangeRatesResult;
            }
        }

        private string getCurrencies()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            GetCurrenciesRequestBody reg = new GetCurrenciesRequestBody();
            var response = mnbService.GetCurrencies(reg);
            return response.GetCurrenciesResult;
        }
        private void paramChanged(object sender, EventArgs e)
        {
            RefreshData();   
        }

        private void loadCurrencyxml(string xmlstring)
        {
            currencies.Clear();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlstring);
            foreach (XmlElement item in xml.DocumentElement.ChildNodes[0])
            {
                string s = item.InnerText;
                currencies.Add(s);
            }

        }
    }
}
