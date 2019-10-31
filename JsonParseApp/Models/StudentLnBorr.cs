using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("Studentln_borr")]
    public class StudentlnBorr
    {
        public int Id { get; set; }

        public EducationProgramData EducationProgramData { get; set; }
        public int EducationProgramDataId { get; set; }

        [JsonProperty("Studentln_borr.itemval")]
        public string StudentlnBorrItemval { get; set; }

        [JsonProperty("Studentln_borr.aiditem")]
        public string StudentlnBorrAiditem { get; set; }
    }
}