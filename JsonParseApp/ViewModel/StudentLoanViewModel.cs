using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonParseApp.Models;
using Newtonsoft.Json;

namespace JsonParseApp.ViewModel
{
    public class StudentLoanViewModel
    {
        [JsonProperty("education_program_data")]
        public EducationProgramData EducationProgramData { get; set; }
        
       

        [JsonProperty("minor_profile")]
        public MinorProfile MinorProfile { get; set; }

        [JsonProperty("loan_applicant_profile")]
        public LoanApplicantProfile LoanApplicantProfile { get; set; }

        [JsonProperty("guarantors")]
        public IList<Guarantor> Guarantors { get; set; }

        [JsonProperty("loan_config")]
        public LoanConfig LoanConfig { get; set; }
    }
}