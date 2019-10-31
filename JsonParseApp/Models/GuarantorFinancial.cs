using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("guarantor_financial")]
    public class GuarantorFinancial
    {
        [JsonProperty("customers.indusgrp")]
        public string CustomersIndusgrp { get; set; }

        [JsonProperty("customers.depends")]
        public string CustomersDepends { get; set; }

        [JsonProperty("customers.empstatus")]
        public string CustomersEmpstatus { get; set; }

        [JsonProperty("customers.home_status")]
        public string CustomersHomeStatus { get; set; }

        [JsonProperty("customers.num_inhouse")]
        public string CustomersNumInhouse { get; set; }

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