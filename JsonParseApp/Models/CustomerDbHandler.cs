using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JsonParseApp.Models.DpacDb;
using Microsoft.Ajax.Utilities;

namespace JsonParseApp.Models
{
    public class CustomerDbHandler
    {
        public string CustomerId { get; set; }

        public string ParsedName { get; set; }
        //-----------------------------------------------------------

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        //----------------------------End property declaration--------

        //----------------------------Begin method implementation ---

        public CustomerDbHandler(string firstName, string lastName, string middleName)//constructor 
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string ParseNameForCode(string firstName, string lastName)
        {

            string fInitial = firstName.Substring(0, 1).ToUpper();

            string lCode = (lastName.Length < 4) ? lastName.ToUpper() : lastName.Substring(0, 4).ToUpper();

            //joining formatted first and last name string
            string code = lCode + fInitial;

            return code;
        }

        //Determines a customer id
        public void CreateCustomerId()
        {
            //creating database connection
            using (var ctx = new DPACEntities())
            {
                string finalVal = "";
                string idNameFormat = ParseNameForCode(this.FirstName, this.LastName);//Parses to give format i.e. PIXAI 
                var customerNumCode = ctx.GetIvorPixabajCustomerCode(idNameFormat).SingleOrDefault();

                //if  nada was found, it would signify a new customer
                if (customerNumCode == null)
                {
                    finalVal = idNameFormat + "00001";
                }
                else
                {
                    string tempNumCode = "00000";//default num code
                    string num = customerNumCode.NextID;//value need to 

                    string newNumCode = tempNumCode.Substring(0, tempNumCode.Length - num.Length);

                    finalVal = idNameFormat + newNumCode + (Int32.Parse(num)+1);
                }

                this.ParsedName = idNameFormat;
                this.CustomerId = finalVal;
                //return finalVal;
            }

        }
    }
}