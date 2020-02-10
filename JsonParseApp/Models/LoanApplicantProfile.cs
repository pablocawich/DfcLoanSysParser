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
        [DisplayName("DPAC Customer ID")]
       public string ApplicantId { get; set; }

       [DisplayName("Sex")]
        [JsonProperty("customers.sex")]
        public string CustomersSex { get; set; }

       /* [DisplayName("date of birth")]
        [JsonProperty("customers.dateofbirth")]
        public DateTime? DOB { get; set; }*/

        [DisplayName("Mailing Address 2")]
        [JsonProperty("customers.mailing_address2")]
        public string CustomersMailingAddress2 { get; set; }

        [DisplayName("Id Type")]
        [JsonProperty("customers.typeofid")]
        public string CustomersTypeofid { get; set; }

        [DisplayName("Mailing Address 1")]
        [JsonProperty("customers.mailing_address1")]
        public string CustomersMailingAddress1 { get; set; }

        [DisplayName("Mailing Country")]
        [JsonProperty("customers.mailingcountry")]
        public string CustomersMailingcountry { get; set; }

        [DisplayName("Id Number")]
        [JsonProperty("customers.idnumber")]
        public string CustomersIdnumber { get; set; }

        [DisplayName("Last Name")]
        [JsonProperty("customers.lastname")]
        public string CustomersLastname { get; set; }

        [DisplayName("First Name")]
        [JsonProperty("customers.firstname")]
        public string CustomersFirstname { get; set; }

        [DisplayName("Middle Name")]
        [JsonProperty("customers.middlename")]
        public string CustomersMiddlename { get; set; }

        [DisplayName("Nationality")]
        [JsonProperty("customers.nationality")]
        public string CustomersNationality { get; set; }

        [DisplayName("Business place")]
        [JsonProperty("customers.businessplace")]
        public string CustomersBusinessplace { get; set; }

        [DisplayName("Employ From")]
        [JsonProperty("customers.employfrom")]
        public string CustomersEmployfrom { get; set; }

        [DisplayName("Occupation")]
        [JsonProperty("customers.occupation")]
        public string CustomersOccupation { get; set; }

        [DisplayName("Income 1")]
        [JsonProperty("customers_financial.income1")]
        public string CustomersFinancialIncome1 { get; set; }

        [DisplayName("Depends")]
        [JsonProperty("customers.depends")]
        public string CustomersDepends { get; set; }

        [DisplayName("Employee Status")]
        [JsonProperty("customers.empstatus")]
        public string CustomersEmpstatus { get; set; }

        [DisplayName("Home Status")]
        [JsonProperty("customers.home_status")]
        public string CustomersHomeStatus { get; set; }

        [DisplayName("Number In House")]
        [JsonProperty("customers.num_inhouse")]
        public string CustomersNumInhouse { get; set; }

        [DisplayName("Years In Address")]
        [JsonProperty("customers.yearsaddr")]
        public string CustomersYearsaddr { get; set; }

        [DisplayName("Next Kin")]
        [JsonProperty("customers.next_kin")]
        public string CustomersNextKin { get; set; }

        [DisplayName("Email")]
        [JsonProperty("customers.emailname")]
        public string CustomersEmailname { get; set; }

        [DisplayName("Home phone")]
        [JsonProperty("customers.homephone")]
        public string CustomersHomephone { get; set; }

        [DisplayName("Relationship Kin")]
        [JsonProperty("customers.relationshipkin")]
        public string CustomersRelationshipkin { get; set; }

        [DisplayName("Other Phone")]
        [JsonProperty("customers.otherphone")]
        public string CustomersOtherphone { get; set; }

        [DisplayName("Work phone")]
        [JsonProperty("customers.workphone")]
        public string CustomersWorkphone { get; set; }

        [DisplayName("Mobile Phone")]
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