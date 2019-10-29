using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class StudentLoanSystem
    {
        public EducationProgramData EducationProgramData { get; set; }
        public MinorProfile MinorProfile { get; set; }
        public LoanApplicantProfile LoanApplicantProfile { get; set; }
        public IList<Guarantor> Guarantors { get; set; }
        public LoanConfig LoanConfig { get; set; }
    }
}