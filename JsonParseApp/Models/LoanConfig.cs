using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("loan_config")]
    public class LoanConfig
    {
        //public int Id { get; set; }

        [JsonProperty("loans.app_type")]
        public string LoansAppType { get; set; }

        [JsonProperty("loans.appldate")]
        public string LoansAppldate { get; set; }

        [JsonProperty("loans.branchid")]
        public string LoansBranchid { get; set; }

        [JsonProperty("loans.fladescr")]
        public string LoansFladescr { get; set; }

        [JsonProperty("loans.flaesins")]
        public string LoansFlaesins { get; set; }

        [JsonProperty("loans.flafxins")]
        public string LoansFlafxins { get; set; }

        [JsonProperty("loans.flagptmt")]
        public string LoansFlagptmt { get; set; }

        [JsonProperty("loans.flagpval")]
        public string LoansFlagpval { get; set; }

        [JsonProperty("loans.flaicmet")]
        public string LoansFlaicmet { get; set; }

        [JsonProperty("loans.flaicrat")]
        public string LoansFlaicrat { get; set; }

        [JsonProperty("loans.flainsud")]
        public string LoansFlainsud { get; set; }

        [JsonProperty("loans.flainsup")]
        public string LoansFlainsup { get; set; }

        [JsonProperty("loans.flalocat")]
        public string LoansFlalocat { get; set; }

        [JsonProperty("loans.flalpmet")]
        public string LoansFlalpmet { get; set; }

        [JsonProperty("loans.flaltype")]
        public string LoansFlaltype { get; set; }

        [JsonProperty("loans.flaptype")]
        public string LoansFlaptype { get; set; }

        [JsonProperty("loans.flarpmet")]
        public string LoansFlarpmet { get; set; }

        [JsonProperty("loans.flasecto")]
        public string LoansFlasecto { get; set; }

        [JsonProperty("loans.flasubsc")]
        public string LoansFlasubsc { get; set; }

        [JsonProperty("loans.flatloan")]
        public string LoansFlatloan { get; set; }

        [JsonProperty("loans.flattermm")]
        public string LoansFlattermm { get; set; }

        [JsonProperty("loans.flacurrncy")]
        public string LoansFlacurrncy { get; set; }

        [JsonProperty("loans.inquirydate")]
        public string LoansInquirydate { get; set; }

        [JsonProperty("loans.repay_cycle")]
        public string LoansRepayCycle { get; set; }

        [JsonProperty("loans.year_length")]
        public string LoansYearLength { get; set; }

        [JsonProperty("loans.refinanceamt")]
        public string LoansRefinanceamt { get; set; }

        [JsonProperty("loans.consolidateamt")]
        public string LoansConsolidateamt { get; set; }

        [JsonProperty("loans.consol_newamtreq")]
        public string LoansConsolNewamtreq { get; set; }

        [JsonProperty("loans.principal_interest")]
        public string LoansPrincipalInterest { get; set; }
    }
}