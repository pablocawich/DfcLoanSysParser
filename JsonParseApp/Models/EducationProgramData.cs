using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    [JsonObject("education_program_data")]
    public class EducationProgramData
    {
        public int Id { get; set; }

        [JsonProperty("studentln.qual1")]
        public string StudentlnQual1 { get; set; }

        [JsonProperty("studentln.duration")]
        public string StudentlnDuration { get; set; }

        [JsonProperty("studentln.level")]
        public string StudentlnLevel { get; set; }

        [JsonProperty("studentln.course")]
        public string StudentlnCourse { get; set; }

        [JsonProperty("studentln.pastschool1")]
        public string StudentlnPastschool1 { get; set; }

        [JsonProperty("studentln.pastqual1")]
        public string StudentlnPastqual1 { get; set; }

        [JsonProperty("studentln.school")]
        public string StudentlnSchool { get; set; }

        [JsonProperty("Studentln_borr")]
        public IList<StudentlnBorr> StudentlnBorr { get; set; }
   
    }
}