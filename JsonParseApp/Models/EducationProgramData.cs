using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class EducationProgramData
    {
        public int Id { get; set; }
        public string Qual1 { get; set; }
        public byte Duration { get; set; }
        public string Level { get; set; }
        public string Course { get; set; }
        public string PastSchool1 { get; set; }
        public string PastQual1 { get; set; }
        public string School { get; set; }
        public IList<StudentLnBorr> StudentLnBorr { get; set; }
    }
}