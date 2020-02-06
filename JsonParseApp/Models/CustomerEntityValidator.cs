using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class CustomerEntityValidator
    {
        public string CustomerId { get; set; }

        public bool Customer { get; set; }
        public string CustomerErrMessage { get; set; }

        public bool Asset { get; set; }
        public string AssetErrMessage { get; set; }

        public bool Liability { get; set; }
        public string LiabilityErrMessage { get; set; }

        public bool GrossFamilyIncome { get; set; }
        public string GrossFamilyErrMessage { get; set; }
    }
}