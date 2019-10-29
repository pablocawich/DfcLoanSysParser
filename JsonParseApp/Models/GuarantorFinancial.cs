using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class GuarantorFinancial
    {
        public string IndusGrp { get; set; }
        public string Depends { get; set; }
        public string EmpStatus { get; set; }
        public string HomeStatus { get; set; }
        public string NumInHouse { get; set; }
        public string YearsAddr { get; set; }
        public IList<GuarantorAsset> GuarantorAssets { get; set; }
        public IList<GuarantorLiability> GuarantorLiabilities { get; set; }
        public IList<GuarantorSelfEmployed> GuarantorSelfEmployed { get; set; }
        public IList<GuarantorGrossAnnualFamilyIncome> GrossAnnualFamilyIncome { get; set; }
    }
}