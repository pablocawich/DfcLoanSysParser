using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("guarantor_personal")]
    public class GuarantorPersonal
    {
       // public int Id { get; set; }

        [DisplayName("Sex")]
        [JsonProperty("customers.sex")]
        public string CustomersSex { get; set; }

        [DisplayName("Mailing Address")]
        [JsonProperty("customers.mailing_address1")]
        public string CustomersMailingAddress1 { get; set; }

        [DisplayName("Mailing Town")]
        [JsonProperty("customers.mailingtown")]
        public string CustomersMailingtown { get; set; }

        [DisplayName("Id Type")]
        [JsonProperty("customers.typeofid")]
        public string CustomersTypeofid { get; set; }

        [DisplayName("Mailing Address 2")]
        [JsonProperty("customers.mailing_address2")]
        public string CustomersMailingAddress2 { get; set; }

        [DisplayName("Mailing Country")]
        [JsonProperty("customers.mailingcountry")]
        public string CustomersMailingcountry { get; set; }

        [DisplayName("Id Number")]
        [JsonProperty("customers.idnumber")]
        public string CustomersIdnumber { get; set; }

        [DisplayName("Last Name")]
        [JsonProperty("customers.lastname")]
        public string CustomersLastname { get; set; }

        [DisplayName("Birthdate")]
        [JsonProperty("customers.birthdate")]
        public string CustomersBirthdate { get; set; }

        [DisplayName("First Name")]
        [JsonProperty("customers.firstname")]
        public string CustomersFirstname { get; set; }

        [DisplayName("Middle Name")]
        [JsonProperty("customers.middlename")]
        public string CustomersMiddlename { get; set; }

        [DisplayName("Married Status")]
        [JsonProperty("customers.marriedstatus")]
        public string CustomersMarriedstatus { get; set; }

        [DisplayName("Nationality")]
        [JsonProperty("customers.nationality")]
        public string CustomersNationality { get; set; }

        [DisplayName("Next Kin")]
        [JsonProperty("customers.next_kin")]
        public string CustomersNextKin { get; set; }

        [DisplayName("Email")]
        [JsonProperty("customers.emailname")]
        public string CustomersEmailname { get; set; }

        [DisplayName("Relationship Kin")]
        [JsonProperty("customers.relationshipkin")]
        public string CustomersRelationshipkin { get; set; }

        [DisplayName("Home Phone")]
        [JsonProperty("customers.homephone")]
        public string CustomersHomephone { get; set; }

        [DisplayName("Other Phone")]
        [JsonProperty("customers.otherphone")]
        public string CustomersOtherphone { get; set; }

        [DisplayName("Work Phone")]
        [JsonProperty("customers.workphone")]
        public string CustomersWorkphone { get; set; }

        [DisplayName("Mobile Phone")]
        [JsonProperty("customers.mobilphone")]
        public string CustomersMobilphone { get; set; }
    }
}