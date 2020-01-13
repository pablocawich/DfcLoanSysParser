using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("guarantors")]
    public class Guarantor
    {
        public int Id { get; set; }

        [JsonProperty("guarantor_personal")]
        public GuarantorPersonal GuarantorPersonal { get; set; }

        public int GuarantorPersonalId { get; set; }

        [JsonProperty("guarantor_financial")]
        public GuarantorFinancial GuarantorFinancial { get; set; }

        public int GuarantorFinancialId { get; set; }
    }
}