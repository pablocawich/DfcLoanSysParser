using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using JsonParseApp.Models;
using Newtonsoft.Json;

namespace JsonParseApp.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext _context;

        public HomeController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        //this should be modal/partial
        [HttpPost]
        public ActionResult JsonFileData(HttpPostedFileBase myFile)
        {
            //return this.Json(new { data = 21, success = true, message = $"" }, JsonRequestBehavior.AllowGet);
            var loan = new StudentLoan();

            //file type should be 'application/json'
            string fileName = myFile.FileName;
            if (myFile != null && myFile.ContentLength > 0)
            {
                // get contents to string
                string str = (new StreamReader(myFile.InputStream)).ReadToEnd();

                // deserializes string into object
                try
                {
                    loan = JsonConvert.DeserializeObject<StudentLoan>(str);                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //return Json(new { success = false, message = $"Error thrown in DB: {e.Message}" });
                    //Console.WriteLine(e);
                }

            }
            //return Json(new { success = true, partialStuff = PartialView("_JsonLoanData", loan), message = $"Edsf" });
            return PartialView("_JsonLoanData", loan);
        }

        [HttpPost]
        public ActionResult MapAndInsertValue(StudentLoan loan)
        {

            return View("");
        }


    }
}