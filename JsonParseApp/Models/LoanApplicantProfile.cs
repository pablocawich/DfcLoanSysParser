using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("loan_applicant_profile")]
    public class LoanApplicantProfile
    {
        // public int Id { get; set; }
        [StringLength(10)]
        [DisplayName("Loan Applicant Id")]
       public string ApplicantId { get; set; }

       [JsonProperty("customers.sex")]
        public string CustomersSex { get; set; }

        [JsonProperty("customers.mailing_address2")]
        public string CustomersMailingAddress2 { get; set; }

        [JsonProperty("customers.typeofid")]
        public string CustomersTypeofid { get; set; }

        [JsonProperty("customers.mailing_address1")]
        public string CustomersMailingAddress1 { get; set; }

        [JsonProperty("customers.mailingcountry")]
        public string CustomersMailingcountry { get; set; }

        [JsonProperty("customers.idnumber")]
        public string CustomersIdnumber { get; set; }

        [JsonProperty("customers.lastname")]
        public string CustomersLastname { get; set; }

        [JsonProperty("customers.firstname")]
        public string CustomersFirstname { get; set; }

        [JsonProperty("customers.middlename")]
        public string CustomersMiddlename { get; set; }

        [JsonProperty("customers.nationality")]
        public string CustomersNationality { get; set; }

        [JsonProperty("customers.businessplace")]
        public string CustomersBusinessplace { get; set; }

        [JsonProperty("customers.employfrom")]
        public string CustomersEmployfrom { get; set; }

        [JsonProperty("customers.occupation")]
        public string CustomersOccupation { get; set; }

        [JsonProperty("customers_financial.income1")]
        public string CustomersFinancialIncome1 { get; set; }

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

        [JsonProperty("customers.next_kin")]
        public string CustomersNextKin { get; set; }

        [JsonProperty("customers.emailname")]
        public string CustomersEmailname { get; set; }

        [JsonProperty("customers.homephone")]
        public string CustomersHomephone { get; set; }

        [JsonProperty("customers.relationshipkin")]
        public string CustomersRelationshipkin { get; set; }

        [JsonProperty("customers.otherphone")]
        public string CustomersOtherphone { get; set; }

        [JsonProperty("customers.workphone")]
        public string CustomersWorkphone { get; set; }

        [JsonProperty("customers.mobilphone")]
        public string CustomersMobilphone { get; set; }

        [JsonProperty("asset")]
        public IList<Asset> Asset { get; set; }

        [JsonProperty("liabilities")]
        public IList<Liability> Liabilities { get; set; }

        [JsonProperty("grossannualfamilyincome")]
        public IList<GrossAnnualFamilyIncome> GrossAnnualFamilyIncome { get; set; }
    }
}