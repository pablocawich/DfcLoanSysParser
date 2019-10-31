using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("guarantor_personal")]
    public class GuarantorPersonal
    {
        [JsonProperty("customers.sex")]
        public string CustomersSex { get; set; }

        [JsonProperty("customers.mailing_address1")]
        public string CustomersMailingAddress1 { get; set; }

        [JsonProperty("customers.mailingtown")]
        public string CustomersMailingtown { get; set; }

        [JsonProperty("customers.typeofid")]
        public string CustomersTypeofid { get; set; }

        [JsonProperty("customers.mailing_address2")]
        public string CustomersMailingAddress2 { get; set; }

        [JsonProperty("customers.mailingcountry")]
        public string CustomersMailingcountry { get; set; }

        [JsonProperty("customers.idnumber")]
        public string CustomersIdnumber { get; set; }

        [JsonProperty("customers.lastname")]
        public string CustomersLastname { get; set; }

        [JsonProperty("customers.birthdate")]
        public string CustomersBirthdate { get; set; }

        [JsonProperty("customers.firstname")]
        public string CustomersFirstname { get; set; }

        [JsonProperty("customers.middlename")]
        public string CustomersMiddlename { get; set; }

        [JsonProperty("customers.marriedstatus")]
        public string CustomersMarriedstatus { get; set; }

        [JsonProperty("customers.nationality")]
        public string CustomersNationality { get; set; }

        [JsonProperty("customers.next_kin")]
        public string CustomersNextKin { get; set; }

        [JsonProperty("customers.emailname")]
        public string CustomersEmailname { get; set; }

        [JsonProperty("customers.relationshipkin")]
        public string CustomersRelationshipkin { get; set; }

        [JsonProperty("customers.homephone")]
        public string CustomersHomephone { get; set; }

        [JsonProperty("customers.otherphone")]
        public string CustomersOtherphone { get; set; }

        [JsonProperty("customers.workphone")]
        public string CustomersWorkphone { get; set; }

        [JsonProperty("customers.mobilphone")]
        public string CustomersMobilphone { get; set; }
    }
}