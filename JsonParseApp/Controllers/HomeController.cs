using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using JsonParseApp.Models;
using JsonParseApp.Models.DpacDb;
using JsonParseApp.ViewModel;
using Newtonsoft.Json;

namespace JsonParseApp.Controllers
{
    public class HomeController : Controller
    {
     /*   private MyDbContext _context;

        public HomeController()
        {
            _context = new MyDbContext();
        }*/

        /*protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }*/

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

            /*var viewModel = new StudentLoanViewModel()
            {
                StudentLoan = loan
            };*/
            //return Json(new { success = true, partialStuff = PartialView("_JsonLoanData", loan), message = $"Edsf" });
            return PartialView("_JsonLoanData", loan);
        }

        [HttpPost]
        public ActionResult SaveLoanValues(StudentLoan studentLoan)
        {
            //capturing posted data from client (controller/server)
            var education = studentLoan.EducationProgramData;
            var minorProfile = studentLoan.MinorProfile;
            var guarantors = studentLoan.Guarantors;
            var applicant = studentLoan.LoanApplicantProfile;
            var loanConfig = studentLoan.LoanConfig;


            //validate values with respect to constraints on the mapped DPAC fields
            //As discussed prior to development, validation should not be thorough as this was to supposedly be done by the student portal development team 
            ValidateEducationData(education);

            //Throw an exception should validation fail and alert client

            //commence mapping should validity not be compromised

            //save data via db context

            //Notify client of successful operation


            return Content("Your values have been received by the server where processing will take place and have your data readily inserted into DPAC");
        }

        public void ValidateEducationData(EducationProgramData edu)
        {

            return;
        }

        public JsonResult CheckForCustomerInDpac(string id)
        {
            //call the stored procedure that will look for the id in dpac 
            if (String.IsNullOrEmpty(id))
                return Json(new { success = false, message = $"string value is empty or null" }, JsonRequestBehavior.AllowGet);

            if (id.Length > 10)
            {
                return Json(new { success = false, message = $"string {id} length has exceeded the DPAC customer Id threshold" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string idMod = id.ToUpper();

                using (var newCont = new DPACEntities())
                {
                    var execGetCustomerName = newCont.GetCustomerName(idMod).SingleOrDefault();

                    if (execGetCustomerName == null)
                        return Json(new { success = false, message = $"{idMod} could not be located in DPAC" }, JsonRequestBehavior.AllowGet);

                   
                    if (execGetCustomerName.Count() != 0)
                    {
                        return Json(new { success = true, message = $"{execGetCustomerName}" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = $"Unfortunately, the id: {id} could not be located in DPAC" }, JsonRequestBehavior.AllowGet);
                    }

                }
                //return Json(new { success = true, message = $"string: {id} In terms of length, looks okay" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}