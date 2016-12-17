using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEconomy_Data
{
    class Repository
    {
        state_economyEntities c = new state_economyEntities();
        public List<country> GetListOfCountries()
        {
            using (c)
            {
                return (from s in c.country
                        select s).ToList();

            }
        }
        //далее следует установить проверку ввода , год - только 2005-2015
        //количество не превышает 171
        public List<GDPViewModel> SelectTopEconomiesinYEar(int year, int quantity)
        {
            using (c)
            {
                var result = (from t1 in c.country
                              join t2 in c.gdp
                              on t1.IdCountry equals t2.Country_IdCountry
                              where t2.Year == year
                              orderby t2.GDP_blnUSD descending
                              select new GDPViewModel
                              {
                                  CountryName = t1.Name,
                                  GDP = t2.GDP_blnUSD
                              }).Take(quantity).ToList();
                return result;


            }
        }
        public List<GDPViewModel> SelectBottomEconomiesinYEar(int year, int quantity)
        {
            using (c)
            {
                var result = (from t1 in c.country
                              join t2 in c.gdp
                              on t1.IdCountry equals t2.Country_IdCountry
                              where t2.Year == year
                              orderby t2.GDP_blnUSD ascending
                              select new GDPViewModel
                              {
                                  CountryName = t1.Name,
                                  GDP = t2.GDP_blnUSD
                              }).Take(quantity).ToList();
                return result;


            }
        }
        public List<GDPGrowthViewModel> SelectFastestGrowingEconomiesinYear(int year, int quantity)
        {
            using (c)
            {
                var result = (from t1 in c.country
                              join t2 in c.gdpgrowth
                              on t1.IdCountry equals t2.Country_IdCountry
                              where t2.Year == year
                              orderby t2.GDPGrowth_percent descending
                              select new GDPGrowthViewModel
                              {
                                  CountryName = t1.Name,
                                  GdpGrowth = t2.GDPGrowth_percent
                              }).Take(quantity).ToList();
                return result;
            }
        }
        public List<GDPGrowthViewModel> SelectSlowestGrowingEconomiesinYear(int year, int quantity)
        {
            using (c)
            {
                var result = (from t1 in c.country
                              join t2 in c.gdpgrowth
                              on t1.IdCountry equals t2.Country_IdCountry
                              where t2.Year == year
                              orderby t2.GDPGrowth_percent ascending
                              select new GDPGrowthViewModel
                              {
                                  CountryName = t1.Name,
                                  GdpGrowth = t2.GDPGrowth_percent
                              }).Take(quantity).ToList();
                return result;
            }
        }
        public List<GDPDynamicaViewModel> GetAllYearsGDPforCountry(string countryname)
        {
            using (c)
            {
                var result = (from t1 in c.country
                              join
        t2 in c.gdp
        on t1.IdCountry equals t2.Country_IdCountry
                              where t1.Name == countryname.ToUpper()
                              select new GDPDynamicaViewModel
                              {
                                  GDP = t2.GDP_blnUSD,
                                  Year = t2.Year
                              }).ToList();
                return result;


            }
        }
        public List<string> GetALLYearInflationforCountry(string countryname)
        {
            var list = new List<string>();
            using (c)
            {
                var result = (from t1 in c.country
                              join
                              t2 in c.inflation
                              on t1.IdCountry equals t2.Country_IdCountry
                              where t1.Name == countryname.ToUpper()
                              select new
                              {
                                  Year = t2.Year,
                                  Inflation = t2.Inflation_percent
                              }).ToList();
                foreach (var item in result)
                {
                    list.Add(string.Format("In {0,4} the inflation was {1,6:F2} percent", item.Year, item.Inflation));
                }
                return list;
            }
        }
        public List<string> GetALLYearPopulationforCountry(string countryname)
        {
            var list = new List<string>();
            using (c)
            {
                var result = (from t1 in c.country
                              join
                              t2 in c.population
                              on t1.IdCountry equals t2.Country_IdCountry
                              where t1.Name == countryname.ToUpper()
                              select new
                              {

                                  Year = t2.Year,
                                  Population = t2.Population_mln
                              }).ToList();
                foreach (var item in result)
                {
                    list.Add(string.Format("In {0,4} {1}'s population  was {2,8:F2} million", item.Year, countryname, item.Population));
                }
                return list;
            }
        }
        public List<string> GetALLYearNetExportforCountry(string countryname)
        {
            var list = new List<string>();
            using (c)
            {
                var result = (from
                              t1 in c.country
                              join
                              t2 in c.import1

                              on t1.IdCountry equals t2.Country_IdCountry
                              join t3 in c.export
                              on t2.Country_IdCountry equals t3.Country_IdCountry
                              where t1.Name == countryname.ToUpper()
                              select new
                              {

                                  Year = t2.Year,
                                  NetExport = t3.Export_blnUSD - t2.Import_blnUSD

                              }).ToList();
                foreach (var item in result)
                {
                    list.Add(string.Format("In {0,4} {1}'s net export was {2,6:F2} billion USD", item.Year, countryname, item.NetExport));
                }
                return list;
            }
        }
        public List<string> GetALLYearDebtforCountry(string countryname)
        {
            var list = new List<string>();
            using (c)
            {
                var result = (from
                              t1 in c.country
                              join
                              t2 in c.national_debt

                              on t1.IdCountry equals t2.Country_IdCountry

                              where t1.Name == countryname.ToUpper()
                              select new
                              {

                                  Year = t2.Year,
                                  Debt = t2.Debt_GDP_percent

                              }).ToList();
                foreach (var item in result)
                {
                    list.Add(string.Format("In {0,4} {1}'s national debt constituted {2,6:F2} percent of its GDP ", item.Year, countryname, item.Debt));
                }
                return list;
            }
        }
        public List<string> GetALLYearUnemploymentforCountry(string countryname)
        {
            var list = new List<string>();
            using (c)
            {
                var result = (from
                              t1 in c.country
                              join
                              t2 in c.unemployment

                              on t1.IdCountry equals t2.Country_IdCountry
                              join t3 in c.export
                              on t2.Country_IdCountry equals t3.Country_IdCountry
                              where t1.Name == countryname.ToUpper()
                              select new
                              {

                                  Year = t2.Year,
                                  Unemp = t2.Unemployment_percent

                              }).ToList();
                foreach (var item in result)
                {
                    list.Add(string.Format("In {0,4}, {2,6:F2} percent of {1}'s population were unemployed", item.Year, countryname, item.Unemp));
                }

                return list;
            }
        }
        public List<string> GetALLYearGDPGrowthforCountry(string countryname)
        {
            var list = new List<string>();
            using (c)
            {
                var result = (from
                              t1 in c.country
                              join
                              t2 in c.gdpgrowth

                              on t1.IdCountry equals t2.Country_IdCountry
                              join t3 in c.export
                              on t2.Country_IdCountry equals t3.Country_IdCountry
                              where t1.Name == countryname.ToUpper()
                              select new
                              {

                                  Year = t2.Year,
                                  GDPGrowth = t2.GDPGrowth_percent

                              }).ToList();
                foreach (var item in result)
                {
                    list.Add(string.Format("In {0,4} {1}'s GDP growth constituted {2,6:F2} percent of its GDP ", item.Year, countryname, item.GDPGrowth));
                }
                return list;
            }
        }

        public List<string> GetALLDataForCountryInYear(string countryname, int year)
        {
            if (year < 2005 || year > 2015)
                throw new ArgumentOutOfRangeException("Data only available for years 2005 to 2015!");
            var list = new List<string>();
            using (c)
            {
                var result = (from t1 in c.country
                              join t2 in c.inflation
                              on t1.IdCountry equals t2.Country_IdCountry
                              join t3 in c.export
                              on t2.Country_IdCountry equals t3.Country_IdCountry
                              join t4 in c.import1
                              on t3.Country_IdCountry equals t4.Country_IdCountry
                              join t5 in c.gdp
                              on t4.Country_IdCountry equals t5.Country_IdCountry
                              join t6 in c.gdpgrowth
                              on t5.Country_IdCountry equals t6.Country_IdCountry
                              join t7 in c.national_debt
                              on t6.Country_IdCountry equals t7.Country_IdCountry
                              join t8 in c.population
                              on t7.Country_IdCountry equals t8.Country_IdCountry
                              join t9 in c.unemployment
                              on t8.Country_IdCountry equals t9.Country_IdCountry
                              where (t1.Name == countryname.ToUpper() &&
                              t2.Year == year)
                              select new
                              {
                                  Inf = t2.Inflation_percent,
                                  Exp = t3.Export_blnUSD,
                                  Imp = t4.Import_blnUSD,
                                  GDP = t5.GDP_blnUSD,
                                  GDPGrowth = t6.GDPGrowth_percent,
                                  NatDebt = t7.Debt_GDP_percent,
                                  Pop = t8.Population_mln,
                                  Unemp = t9.Unemployment_percent


                              }).ToList();
                list.Add(string.Format("In {0}, {1}'s Inflation was {2,6:F2} percent",
                    year, countryname, result[0].Inf));
                list.Add(string.Format("In {0}, {1}'s GDP was {2,6:F2} billion USD",
                    year, countryname, result[0].GDP));
                list.Add(string.Format("In {0}, {1}'s GDP growth {2,6:F2} percent",
                    year, countryname, result[0].GDPGrowth));
                list.Add(string.Format("In {0}, {1}'s export was {2,6:F2} billion USD",
                    year, countryname, result[0].Exp));
                list.Add(string.Format("In {0}, {1}'s import was {2,6:F2} billion USD",
                    year, countryname, result[0].Inf));
                list.Add(string.Format("In {0}, {1}'s national debt was {2,6:F2} percent of GDP",
                    year, countryname, result[0].NatDebt));
                list.Add(string.Format("In {0}, {1}'s unemployment was {2,6:F2} percent",
                    year, countryname, result[0].Unemp));
                list.Add(string.Format("In {0}, {1}'s population was {2,6:F2} million",
                    year, countryname, result[0].Pop));
                return list;
            }


        }
    }
}
