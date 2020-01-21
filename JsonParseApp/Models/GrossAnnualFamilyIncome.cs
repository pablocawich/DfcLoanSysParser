using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("grossannualfamilyincome")]
    public class GrossAnnualFamilyIncome
    {
        //public int Id { get; set; }

        public LoanApplicantProfile LoanApplicantProfile { get; set; }
        public int? LoanApplicantProfileId { get; set; }

        public GuarantorFinancial GuarantorFinancial { get; set; }
        public int? GuarantorFinancialId { get; set; }

        [Display(Name = "Income 4")]
        [JsonProperty("customers_financial.income4")]
        public string CustomersFinancialIncome4 { get; set; }

        [Display(Name = "Occupation 2")]
        [JsonProperty("customer.secondoccupation")]
        public string CustomerSecondoccupation { get; set; }

        [Display(Name = "Income 2")]
        [JsonProperty("customers_financial.income2")]
        public string CustomersFinancialIncome2 { get; set; }

        [Display(Name = "Income 3")]
        [JsonProperty("customers_financial.income3")]
        public string CustomersFinancialIncome3 { get; set; }

        [Display(Name = "Income 1")]
        [JsonProperty("customers_financial.income1")]
        public string CustomersFinancialIncome1 { get; set; }
    }
}