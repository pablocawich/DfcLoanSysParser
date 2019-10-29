using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class MinorProfile
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public string Area { get; set; }
        public string IdType { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string IdNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string UploadIdImage { get; set; }
        public string BelizeanResident { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string HomePhone { get; set; }
        public string RelationBorrower { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}