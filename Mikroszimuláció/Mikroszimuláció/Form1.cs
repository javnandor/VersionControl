using Mikroszimuláció.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszimuláció
{
    public partial class Form1 : Form
    {
        List<Person> Population;
        List<BirthProbabilities> BirthProbabilities;
        List<DeathProbabilities> DeathProbabilities;

        Random rng = new Random(1234);

    public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Users\nandor.javorszki\Documents\Asztal\Suli\5.félév\IRF\Mikroszim\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Users\nandor.javorszki\Documents\Asztal\Suli\5.félév\IRF\Mikroszim\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Users\nandor.javorszki\Documents\Asztal\Suli\5.félév\IRF\Mikroszim\halál.csv");
            
            for (int year = 2005; year <= 2024; year++)
            {

                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }
                    int nbrOfMales = (from x in Population
                                      where x.Gender == Gender.Male && x.IsAlive
                                      select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }


        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> result = new List<Person>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    Person P = new Person();
                    P.BirthYear = int.Parse(items[0]);
                    P.Gender = (Gender)Enum.Parse(typeof(Gender), items[1]);
                    P.NbrOfChildren = int.Parse(items[2]);
                    result.Add(P);
                    //P.Gender = items[1] == "1" ? Gender.Male : Gender.Female;
                }
            }
            return result;
        }

        public List<BirthProbabilities> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbabilities> result = new List<BirthProbabilities>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    BirthProbabilities P = new BirthProbabilities();
                    P.Age = int.Parse(items[0]);
                    P.NbrOfChildren = int.Parse(items[1]);
                    P.P = double.Parse(items[2]);
                    result.Add(P);
                }
            }
            return result;
        }
            public List<DeathProbabilities> GetDeathProbabilities(string csvpath)
            {
                List<DeathProbabilities> result = new List<DeathProbabilities>();
                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] items = line.Split(';');
                        DeathProbabilities P = new DeathProbabilities();
                        P.Gender = (Gender)Enum.Parse(typeof(Gender), items[0]);
                        P.Age = int.Parse(items[1]);
                        P.P = double.Parse(items[2]);

                        result.Add(P);
                    }
                }
                return result;
            }
        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;
            byte age = (byte)(year - person.BirthYear);
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.P).FirstOrDefault();
            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.P).FirstOrDefault();
                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(újszülött);
                }
            }
        }
    }
}
