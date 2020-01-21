using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JsonParseApp.Models
{
    
    [JsonObject("education_program_data")]
    public class EducationProgramData
    {
        //public int Id { get; set; }

        [DisplayName("Qual1")]
        [JsonProperty("studentln.qual1")]
        public string StudentlnQual1 { get; set; }

        [DisplayName("Duration")]
        [JsonProperty("studentln.duration")]
        public string StudentlnDuration { get; set; }

        [DisplayName("Level")]
        [JsonProperty("studentln.level")]
        public string StudentlnLevel { get; set; }

        [DisplayName("Course")]
        [JsonProperty("studentln.course")]
        public string StudentlnCourse { get; set; }

        [DisplayName("Past School")]
        [JsonProperty("studentln.pastschool1")]
        public string StudentlnPastschool1 { get; set; }

        [DisplayName("Past Level/Qualification")]
        [JsonProperty("studentln.pastqual1")]
        public string StudentlnPastqual1 { get; set; }

        [DisplayName("School")]
        [JsonProperty("studentln.school")]
        public string StudentlnSchool { get; set; }

        [JsonProperty("Studentln_borr")]
        public IList<StudentlnBorr> StudentlnBorr { get; set; }
   
    }
}