using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class Guarantor
    {
        public GuarantorPersonal GuarantorPersonal { get; set; }
        public GuarantorFinancial GuarantorFinancial { get; set; }
    }
}