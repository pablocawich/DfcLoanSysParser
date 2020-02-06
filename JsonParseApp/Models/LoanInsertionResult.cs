using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class LoanInsertionResult
    {
        public CustomerEntityValidator Applicant { get; set; }

        public CustomerEntityValidator Minor { get; set; }

        public IList<CustomerEntityValidator> Guarantors { get; set; }

        public Application LoanApplication { get; set; }

        public Application StudentInformation { get; set; }

        public bool CrossReferenceOperation { get; set; }

        public IList<bool> CrossRefGuarantorOperation { get; set; }
    }
}