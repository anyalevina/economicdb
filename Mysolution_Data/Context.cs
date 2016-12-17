using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysolution_Data
{
   public  class Context:DbContext
    {
        public Context()
            :base("mylocalserver1")
            
        {
            
        }
      

        public DbSet<country> country { get; set; }
        public DbSet<export> export { get; set; }
        public DbSet<gdp> gdp { get; set; }
        public DbSet<gdpgrowth> gdpgrowth { get; set; }
        public DbSet<import1> import1 { get; set; }
        public DbSet<inflation> inflation { get; set; }
        public DbSet<national_debt> national_debt { get; set; }
        public DbSet<population> population { get; set; }
        public DbSet<unemployment> unemployment { get; set; }

    }
}
