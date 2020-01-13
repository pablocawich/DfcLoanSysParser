using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonParseApp.Models;

namespace JsonParseApp.ViewModel
{
    public class LoanItemsViewModel
    {
        public StudentLoan StudentLoan { get; set; }

        public int ErrCount { get; set; }

        public List<string> ErrorList { get; set; }
    }
}