﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Harmadik_LINQ
{
    public partial class Form1 : Form
    {

        List<Country> countries = new List<Country>();
        List<Ramen> ramens = new List<Ramen>();

        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");
        }

        void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                string orszag = sor[2];
                //Lamda szintakszis: var ered = countries.Where(i => i.Name.Equals(orszag)).FirstOrDefault(); //FirstOrDefaul NULL értéket ad, ha nincs találat
                AddCountry(orszag);
            }
            sr.Close();
        

            void AddCountry(string orszag)
            {
                var ered = (from c in countries where c.Name.Equals(orszag) select c).FirstOrDefault();
                if (ered == null)
                {
                    ered = new Country
                    {
                        ID = countries.Count,
                        Name = orszag
                    };
                    countries.Add(ered);
                }
            }
        }
    }
}
