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
        [JsonProperty("guarantor_personal")]
        public GuarantorPersonal GuarantorPersonal { get; set; }

        [JsonProperty("guarantor_financial")]
        public GuarantorFinancial GuarantorFinancial { get; set; }
    }
}