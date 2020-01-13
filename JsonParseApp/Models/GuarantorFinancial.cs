using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("guarantor_financial")]
    public class GuarantorFinancial
    {
        public int Id { get; set; }

        [JsonProperty("customers.indusgrp")]
        public string CustomersIndusgrp { get; set; }

        [Display(Name = "Depends")]
        [JsonProperty("customers.depends")]
        public string CustomersDepends { get; set; }

        [Display(Name = "Business Place")]
        [JsonProperty("customers.businessplace")]
        public string CustomersBusinessplace { get; set; }

        [Display(Name = "Employment Status")]
        [JsonProperty("customers.empstatus")]
        public string CustomersEmpstatus { get; set; }
        
        [Display(Name = "Employed From Date")]
        [JsonProperty("customers.employfrom")]
        public string CustomersEmployfrom { get; set; }

        [Display(Name = "Occupation")]
        [JsonProperty("customers.occupation")]
        public string CustomersOccupation { get; set; }

        [Display(Name = "Home Status")]
        [JsonProperty("customers.home_status")]
        public string CustomersHomeStatus { get; set; }

        [Display(Name = "Number in House")]
        [JsonProperty("customers.num_inhouse")]
        public string CustomersNumInhouse { get; set; }

        [Display(Name = "Years in Address")]
        [JsonProperty("customers.yearsaddr")]
        public string CustomersYearsaddr { get; set; }

        [JsonProperty("asset")]
        public IList<Asset> Asset { get; set; }

        [JsonProperty("liabilities")]
        public IList<Liability> Liabilities { get; set; }

        [JsonProperty("selfemployed")]
        public IList<SelfEmployed> Selfemployed { get; set; }

        [JsonProperty("grossannualfamilyincome")]
        public IList<GrossAnnualFamilyIncome> GrossAnnualFamilyIncome { get; set; }
    }
}