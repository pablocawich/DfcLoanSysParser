using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("minor_profile")]
    public class MinorProfile
    {
        public int Id { get; set; }

        [JsonProperty("customers.sex")]
        [DisplayName("Sex")]
        public string CustomersSex { get; set; }

        [JsonProperty("customers.city")]
        [DisplayName("City")]
        public string CustomersCity { get; set; }

        [JsonProperty("customers.area")]
        [DisplayName("Area")]
        public string CustomersArea { get; set; }

        [JsonProperty("customers.idtype")]
        [DisplayName("ID Type")]
        public string CustomersIdtype { get; set; }

        [JsonProperty("customers.street")]
        [DisplayName("Street")]
        public string CustomersStreet { get; set; }

        [JsonProperty("customers.country")]
        [DisplayName("Country")]
        public string CustomersCountry { get; set; }

        [JsonProperty("customers.idnumber")]
        [DisplayName("ID Number")]
        public string CustomersIdnumber { get; set; }

        [JsonProperty("customers.lastname")]
        [DisplayName("Last Name")]
        public string CustomersLastname { get; set; }

        [JsonProperty("customers.firstname")]
        [DisplayName("First Name")]
        public string CustomersFirstname { get; set; }

        [JsonProperty("customers.middlename")]
        [DisplayName("Middle Name")]
        public string CustomersMiddlename { get; set; }

        [JsonProperty("customers.uploadidimage")]
        [DisplayName("Uploaded Image")]
        public string CustomersUploadidimage { get; set; }

        [JsonProperty("customers.belizeanresident")]
        [DisplayName("Belizean Resident")]
        public string CustomersBelizeanresident { get; set; }

        [JsonProperty("customers.email")]
        [DisplayName("Email")]
        public string CustomersEmail { get; set; }

        [JsonProperty("customers.full_name")]
        [DisplayName("Full Name")]
        public string CustomersFullName { get; set; }

        [JsonProperty("customers.homephone")]
        [DisplayName("Home Phone")]
        public string CustomersHomephone { get; set; }

        [JsonProperty("customers.relationborrower")]
        [DisplayName("Relationship to Borrower")]
        public string CustomersRelationborrower { get; set; }

        [JsonProperty("customers.birthdate")]
        [DisplayName("Birthdate")]
        public string CustomersBirthdate { get; set; }
    }
}