//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBEconomy_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class export
    {
        public int Year { get; set; }
        public Nullable<decimal> Export_blnUSD { get; set; }
        public int Country_IdCountry { get; set; }
    
        public virtual country country { get; set; }
    }
}
