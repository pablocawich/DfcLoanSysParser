using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class LoanApplicantProfile
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public string MailingAddress2 { get; set; }
        public string TypeOfId { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingCountry { get; set; }
        public string IdNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Nationality { get; set; }
        public string BusinessPlace { get; set; }
        public DateTime? EmployFrom { get; set; }
        public string Occupation { get; set; }
        public string Income1 { get; set; }
        public string Depends { get; set; }
        public string EmpStatus { get; set; }
        public string HomeStatus { get; set; }
        public string NumInHouse { get; set; }
        public string YearsAddr { get; set; }
        public string NextKin { get; set; }
        public string EmailName { get; set; }
        public string HomePhone { get; set; }
        public string RelationshipKin { get; set; }
        public string OtherPhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilPhone { get; set; }
        public IList<Asset> Asset { get; set; }
        public IList<Liability> Liabilities { get; set; }
        public IList<GrossAnnualFamilyIncome> GrossAnnualFamilyIncome { get; set; }
    }
}