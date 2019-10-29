using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonParseApp.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
    }
}