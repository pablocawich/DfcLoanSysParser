using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("guarantors")]
    public class Guarantor
    {
       // public int Id { get; set; }

        [JsonProperty("guarantor_personal")]
        public GuarantorPersonal GuarantorPersonal { get; set; }
        public int GuarantorPersonalId { get; set; }

        [JsonProperty("guarantor_financial")]
        public GuarantorFinancial GuarantorFinancial { get; set; }

        public int GuarantorFinancialId { get; set; }

        //will be used to store the guarantor's Id should in case it already exist in DPAC
        [StringLength(10)]
        [DisplayName("DPAC Customer ID")]
        public string ApplicantId { get; set; }

    }
}