using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("minor_profile")]
    public class MinorProfile
    {
        [JsonProperty("customers.sex")]
        public string CustomersSex { get; set; }

        [JsonProperty("customers.area")]
        public string CustomersArea { get; set; }

        [JsonProperty("customers.idtype")]
        public string CustomersIdtype { get; set; }

        [JsonProperty("customers.street")]
        public string CustomersStreet { get; set; }

        [JsonProperty("customers.country")]
        public string CustomersCountry { get; set; }

        [JsonProperty("customers.idnumber")]
        public string CustomersIdnumber { get; set; }

        [JsonProperty("customers.lastname")]
        public string CustomersLastname { get; set; }

        [JsonProperty("customers.firstname")]
        public string CustomersFirstname { get; set; }

        [JsonProperty("customers.middlename")]
        public string CustomersMiddlename { get; set; }

        [JsonProperty("customers.uploadidimage")]
        public string CustomersUploadidimage { get; set; }

        [JsonProperty("customers.belizeanresident")]
        public string CustomersBelizeanresident { get; set; }

        [JsonProperty("customers.email")]
        public string CustomersEmail { get; set; }

        [JsonProperty("customers.full_name")]
        public string CustomersFullName { get; set; }

        [JsonProperty("customers.homephone")]
        public string CustomersHomephone { get; set; }

        [JsonProperty("customers.relationborrower")]
        public string CustomersRelationborrower { get; set; }

        [JsonProperty("customers.birthdate")]
        public string CustomersBirthdate { get; set; }
    }
}