//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JsonParseApp.Models.DpacDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class customers_financial
    {
        public string officerid { get; set; }
        public string fbonumbr { get; set; }
        public Nullable<decimal> income1 { get; set; }
        public Nullable<decimal> income2 { get; set; }
        public Nullable<decimal> income3 { get; set; }
        public Nullable<decimal> income4 { get; set; }
        public string income4spec { get; set; }
        public int finanalyid { get; set; }
        public string payfrequency { get; set; }
        public string risk_level { get; set; }
        public Nullable<System.DateTime> declarationdate { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
