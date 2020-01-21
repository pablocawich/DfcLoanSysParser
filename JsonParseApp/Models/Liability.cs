using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("liabilities")]
    public class Liability
    {
       // public int Id { get; set; }

        public LoanApplicantProfile LoanApplicantProfile { get; set; }
        public int? LoanApplicantProfileId { get; set; }

        public GuarantorFinancial GuarantorFinancial { get; set; }
        public int? GuarantorFinancialId { get; set; }

        [Display(Name = "Amount")]
        [JsonProperty("individual_financials.amount")]
        public string IndividualFinancialsAmount { get; set; }

        [Display(Name = "Description")]
        [JsonProperty("individual_financials.description")]
        public string IndividualFinancialsDescription { get; set; }
    }
}