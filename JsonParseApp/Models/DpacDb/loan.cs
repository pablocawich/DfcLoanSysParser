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
    
    public partial class loan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loan()
        {
            this.fxrefbors = new HashSet<fxrefbor>();
            this.studentln_borr = new HashSet<studentln_borr>();
        }
    
        public string appnumber { get; set; }
        public Nullable<decimal> flanumbr { get; set; }
        public string fbonumbr { get; set; }
        public string officerid { get; set; }
        public Nullable<System.DateTime> appldate { get; set; }
        public decimal flatloan { get; set; }
        public Nullable<decimal> flagpval { get; set; }
        public decimal flatermm { get; set; }
        public decimal flaicrat { get; set; }
        public decimal flafxins { get; set; }
        public string loanpurp { get; set; }
        public decimal loanstatus { get; set; }
        public decimal flaptype { get; set; }
        public Nullable<System.DateTime> date_pend { get; set; }
        public Nullable<System.DateTime> date_rejec { get; set; }
        public Nullable<System.DateTime> date_appr { get; set; }
        public Nullable<System.DateTime> date_reg { get; set; }
        public string decisionby { get; set; }
        public Nullable<bool> venture { get; set; }
        public Nullable<bool> jventure { get; set; }
        public string grantname { get; set; }
        public Nullable<decimal> grantamt { get; set; }
        public string agency_name { get; set; }
        public string fladescr { get; set; }
        public Nullable<decimal> flaesins { get; set; }
        public decimal flagptmt { get; set; }
        public decimal flaicmet { get; set; }
        public Nullable<bool> flarebat { get; set; }
        public Nullable<System.DateTime> flainsud { get; set; }
        public Nullable<decimal> flainsup { get; set; }
        public decimal flalpmet { get; set; }
        public Nullable<decimal> flalprat { get; set; }
        public Nullable<decimal> flalpval { get; set; }
        public decimal flaltype { get; set; }
        public string flapadr1 { get; set; }
        public string flapadr2 { get; set; }
        public string flapdesc { get; set; }
        public string flarpmet { get; set; }
        public string flalocat { get; set; }
        public string flasecto { get; set; }
        public string flasubsc { get; set; }
        public Nullable<bool> flacofee { get; set; }
        public string flauser1 { get; set; }
        public string flauser2 { get; set; }
        public string flauser3 { get; set; }
        public string flauser4 { get; set; }
        public string flauser5 { get; set; }
        public string flauser6 { get; set; }
        public string flatiers { get; set; }
        public string flaictyp { get; set; }
        public Nullable<System.DateTime> flaanvdt { get; set; }
        public string flacurncy { get; set; }
        public Nullable<decimal> flrerate { get; set; }
        public string fd_fdamt { get; set; }
        public Nullable<bool> flainher { get; set; }
        public Nullable<bool> flaconso { get; set; }
        public string user_lact { get; set; }
        public Nullable<System.DateTime> date_lact { get; set; }
        public Nullable<decimal> appr_level { get; set; }
        public Nullable<decimal> flapstep { get; set; }
        public Nullable<decimal> flanstep { get; set; }
        public Nullable<decimal> flamostp { get; set; }
        public Nullable<decimal> flamtcon { get; set; }
        public Nullable<decimal> flalncons { get; set; }
        public string app_type { get; set; }
        public Nullable<decimal> year_length { get; set; }
        public string flapaddr3 { get; set; }
        public Nullable<decimal> regularpayment { get; set; }
        public Nullable<decimal> skippedpayment { get; set; }
        public string skippedmonths { get; set; }
        public Nullable<System.DateTime> date_canc { get; set; }
        public Nullable<decimal> consolidateamt { get; set; }
        public Nullable<decimal> consol_newamtreq { get; set; }
        public string branchid { get; set; }
        public string repay_cycle { get; set; }
        public Nullable<bool> fladelet { get; set; }
        public string prevloannumber { get; set; }
        public string projectdirections { get; set; }
        public Nullable<System.DateTime> inquirydate { get; set; }
        public Nullable<decimal> refinanceamt { get; set; }
        public Nullable<bool> activatetype3monthlyseries { get; set; }
    
        public virtual customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fxrefbor> fxrefbors { get; set; }
        public virtual studentln studentln { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<studentln_borr> studentln_borr { get; set; }
    }
}
