using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysolution_Data
{
    public class Repository
    {
        Context c = new Context();
     
        private List<YearlyDynamicsViewModel> ConvertToYearlyDynamicViewModel(IEnumerable<IEconomy> ec)
        {
            var list = new List<YearlyDynamicsViewModel>();
            foreach (var item in ec)
            {
                foreach (var propinf in item.GetType().GetProperties())
                {
                    if (propinf.PropertyType == typeof(Nullable<decimal>))
                        list.Add(new YearlyDynamicsViewModel
                        {
                            Country = item.country.Name,
                            EconomyVar = propinf.GetValue(item) as decimal?
                        });
                }
            }
            return list;
        }
        public List<YearlyDynamicsViewModel>GetLargestEconomiesForYear(int year, int quantity)
        {
            using (c)
            {
                var res0 = (from g in c.gdp
                            orderby g.GDP_blnUSD descending
                            select g)
                            .Take(quantity);
                return ConvertToYearlyDynamicViewModel(res0);

            }
        }
        public List<YearlyDynamicsViewModel> GetFastestGrowingEconomies(int year, int quantity)
        {
            using (c)
            {
                var res0 = (from g in c.gdpgrowth
                            orderby g.GDPGrowth_percent descending
                            select g)
                            .Take(quantity);
                return ConvertToYearlyDynamicViewModel(res0);

            }
        }
        public List<YearlyDynamicsViewModel> GetSlowestGrowingEconomies(int year, int quantity)
        {
            using (c)
            {
                var res0 = (from g in c.gdpgrowth
                            orderby g.GDPGrowth_percent ascending
                            select g)
                            .Take(quantity);
                return ConvertToYearlyDynamicViewModel(res0);

            }
        }
        public List<YearlyDynamicsViewModel> GetSmallestEconomiesForYear(int year, int quantity)
        {
            using (c)
            {
                var res0 = (from g in c.gdp
                            orderby g.GDP_blnUSD ascending
                            select g)
                            .Take(quantity);
                return ConvertToYearlyDynamicViewModel(res0);

            }
        }

        private List<EconomyViewModel> ConvertToViewModel(IEnumerable<IEconomy> ec)
        {
            var list = new List<EconomyViewModel>();
            foreach (var item in ec)
            {
                foreach (var propinf in item.GetType().GetProperties())
                {
                    if (propinf.PropertyType == typeof(Nullable<decimal>))
                        list.Add(new EconomyViewModel
                        {
                            Year = item.Year,
                            EconomyVar = propinf.GetValue(item) as decimal?
                        });
                }
            }
            return list;
        }


        public List<EconomyViewModel> GetExportForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel(res.export.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetInflationForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.inflation.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetunemploymentForCountry(country ob)
        {
            using (var c = new Context())
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.unemployment.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetpopulationForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.population.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetNatDebtForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.national_debt.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetGDPForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.gdp.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetGDPGrowthForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.gdpgrowth.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }
        public List<EconomyViewModel> GetImportForCountry(country ob)
        {
            using (c)
            {
                var res = c.country.FirstOrDefault(c1 => c1.Name == ob.Name);
                if (res != null)
                    return ConvertToViewModel( res.import1.ToList());
                else throw new NullReferenceException("There is no data for this country");

            }
        }

        public List<country> GetListOfCountries()
        {
            using (c)
            {
                var result = (from s in c.country
                              select s).ToList();
                return result;
            }
        }
    }
}
