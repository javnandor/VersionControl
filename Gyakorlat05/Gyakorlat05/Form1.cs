﻿using Gyakorlat05.Entities;
using Gyakorlat05.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Gyakorlat05
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Rates;
            //GetRates();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(GetRates());
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData rd = new RateData();
                Rates.Add(rd);
                rd.Currency = item.ChildNodes[0].Attributes["curr"].Value;
                rd.Date = Convert.ToDateTime(item.Attributes["date"].Value);
                decimal unit = Convert.ToDecimal(item.ChildNodes[0].Attributes["unit"].Value);
                decimal value = Convert.ToDecimal(item.ChildNodes[0].InnerText);
                if (unit != 0)
                {
                    rd.Value = value / unit;
                }
                else
                {
                    rd.Value = 0;
                }
            }

        }

        private static string GetRates()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            GetExchangeRatesResponseBody response = mnbService.GetExchangeRates(request);
            string result = response.GetExchangeRatesResult;
            MessageBox.Show(result);
            return result;
        }
    }
}
