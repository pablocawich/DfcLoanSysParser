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
    
    public partial class studentln_borr
    {
        public int idnum { get; set; }
        public string appnumber { get; set; }
        public string itemval { get; set; }
        public Nullable<decimal> aiditem { get; set; }
        public Nullable<decimal> borritem { get; set; }
    
        public virtual loan loan { get; set; }
    }
}
