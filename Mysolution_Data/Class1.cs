using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysolution_Data
{
    public interface IEconomy
    {
        int Year { get; set; }
        int Id { get; set; }
        country country { get; set; }

        
    }
    public partial class unemployment:IEconomy
    {
       
        public int Id { get; set; }

        public int Year { get; set; }
        public Nullable<decimal> Unemployment_percent { get; set; }
        

        public virtual country country { get; set; }
    }
    public partial class population : IEconomy
    {
        
        public int Id { get; set; }
        public int Year { get; set; }
        public Nullable<decimal> Population_mln { get; set; }
      

        public virtual country country { get; set; }
    }
    public partial class national_debt : IEconomy
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public Nullable<decimal> Debt_GDP_percent { get; set; }
        

        public virtual country country { get; set; }
    }
    public partial class inflation : IEconomy
    {
        public int Id { get; set; }
        public int Year { get; set; }
       
        public Nullable<decimal> Inflation_percent { get; set; }

        public virtual country country { get; set; }
    }
    public partial class import1 : IEconomy
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public Nullable<decimal> Import_blnUSD { get; set; }
       

        public virtual country country { get; set; }
    }
    public partial class gdpgrowth : IEconomy
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public Nullable<decimal> GDPGrowth_percent { get; set; }
        

        public virtual country country { get; set; }
    }
    public partial class gdp : IEconomy
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public Nullable<decimal> GDP_blnUSD { get; set; }
        

        public virtual country country { get; set; }
    }
    public partial class export : IEconomy { 
        public int Id { get; set; }
        public int Year { get; set; }
        public Nullable<decimal> Export_blnUSD { get; set; }
        

        public virtual country country { get; set; }
    }
    public partial class country
    {
       
        public country()
        {
            this.export = new HashSet<export>();
            this.gdp = new HashSet<gdp>();
            this.gdpgrowth = new HashSet<gdpgrowth>();
            this.import1 = new HashSet<import1>();
            this.inflation = new HashSet<inflation>();
            this.national_debt = new HashSet<national_debt>();
            this.population = new HashSet<population>();
            this.unemployment = new HashSet<unemployment>();
        }
        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string Name { get; set; }

        public virtual ICollection<export> export { get; set; }
        public virtual ICollection<gdp> gdp { get; set; }
        public virtual ICollection<gdpgrowth> gdpgrowth { get; set; }
        public virtual ICollection<import1> import1 { get; set; }
        public virtual ICollection<inflation> inflation { get; set; }
        public virtual ICollection<national_debt> national_debt { get; set; }
        public virtual ICollection<population> population { get; set; }
        public virtual ICollection<unemployment> unemployment { get; set; }
    }

}
