using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JsonParseApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ProcessJsonFile(HttpPostedFileBase myFile)
        {
            //file type should be 'application/json'
            string fileName = myFile.FileName;
            if (myFile != null && myFile.ContentLength > 0)
            {
                // get contents to string
                string str = (new StreamReader(myFile.InputStream)).ReadToEnd();

                // deserializes string into object
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var d = jss.Deserialize<dynamic>(str);

                // once it's an object, you can use do with it whatever you want
                //return PartialView("_JsonLoanData", str);
               // return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
                return this.Json(new { success = true, message = $"File: {fileName} successfully parsed"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false });
        }

       
    }
}