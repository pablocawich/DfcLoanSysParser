using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("grossannualfamilyincome")]
    public class GrossAnnualFamilyIncome
    {
        [JsonProperty("customers_financial.income4")]
        public string CustomersFinancialIncome4 { get; set; }

        [JsonProperty("customer.secondoccupation")]
        public string CustomerSecondoccupation { get; set; }

        [JsonProperty("customers_financial.income2")]
        public string CustomersFinancialIncome2 { get; set; }

        [JsonProperty("customers_financial.income3")]
        public string CustomersFinancialIncome3 { get; set; }

        [JsonProperty("customers_financial.income1")]
        public string CustomersFinancialIncome1 { get; set; }
    }
}