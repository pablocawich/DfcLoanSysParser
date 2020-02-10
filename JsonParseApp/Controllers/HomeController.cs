using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using JsonParseApp.Models;
using JsonParseApp.Models.DpacDb;
using JsonParseApp.ViewModel;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using DbEntityValidationException = System.Data.Entity.Validation.DbEntityValidationException;

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

        public ActionResult SuccessPage()
        {
            return View("SuccessPageReport");
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
                string idMod = id.ToUpper();//capitalize characters

                using (var newCont = new DPACEntities())
                {
                    var execGetCustomerName = newCont.GetCustomerName(idMod).FirstOrDefault();
                    if (execGetCustomerName == null)
                        return Json(new { success = false, message = $"{idMod} could not be located in DPAC" }, JsonRequestBehavior.AllowGet);


                    if (execGetCustomerName.fbonumbr != null)
                    {
                        return Json(new { success = true, fullname = execGetCustomerName.fbobname, bday = execGetCustomerName.birthdate.ToString() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = $"Unfortunately, the id: {id} could not be located in DPAC" }, JsonRequestBehavior.AllowGet);
                    }

                }
                //return Json(new { success = true, message = $"string: {id} In terms of length, looks okay" }, JsonRequestBehavior.AllowGet);

            }
        }

        public bool ValidateCustomerPostId(string id)
        {
            bool exists = false;

            if (!string.IsNullOrEmpty(id))
            {
                id = id.ToUpper();
                using (var newCont = new DPACEntities())
                {
                    var execGetCustomerName = newCont.GetCustomerName(id).FirstOrDefault();
                    if (execGetCustomerName == null)
                        return false;

                    exists = (execGetCustomerName.fbonumbr != null) ? true : false;
                 
                }
            }         

            return exists;
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
                var userList = new List<fuserid>();
                // get contents to string
                string str = (new StreamReader(myFile.InputStream)).ReadToEnd();
                using (var dpac = new DPACEntities())
                {
                     userList = dpac.fuserids.Where(u => u.accs_code == "CDST" || u.accs_code == "EUCO" && u.enabled == true).ToList();
                    // deserializes string into object
                   
                }

                try
                {
                    loan = JsonConvert.DeserializeObject<StudentLoan>(str);
                    loan.LoanConfig.UserIds = userList;
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
            /*var education = studentLoan.EducationProgramData;
            var minorProfile = studentLoan.MinorProfile;
            var guarantors = studentLoan.Guarantors;
            var applicant = studentLoan.LoanApplicantProfile;
            var loanConfig = studentLoan.LoanConfig;*/
            if (!ModelState.IsValid)
            {
                String messages = String.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage + " " + v.Exception));
                return Content(messages);
            }

            var resultViewModel = ProcessStudentLoanForDbEntry(studentLoan);

            //Determine whether posted customers are sent with id. Further eliminate the information since the customer already exists
            
            //validate values with respect to constraints on the mapped DPAC fields
            //As discussed prior to development, validation should not be thorough as this was to supposedly be done by the student portal development team 
          
            //Throw an exception should validation fail and alert client

            //commence mapping should validity not be compromised

            //save data via db context

            //Notify client of successful operation


            return View("SuccessPageReport", resultViewModel);
        }

        public LoanInsertionResult ProcessStudentLoanForDbEntry(StudentLoan loan)
        {
            string minorId = null;
            string applicantId;
            List<string> guarantorIds =  new List<string>();

            string LoanApplicationId;

            //result container
            CustomerEntityValidator loanApplicantResult = new CustomerEntityValidator();
            CustomerEntityValidator minorProfileResult = new CustomerEntityValidator();
            List<CustomerEntityValidator> guarantorResults = new List<CustomerEntityValidator>();
          

            var loanConfigResult = new Application();
            var studentDataResult = new Application();
            bool crossReferenceMinorResult = false;

            IList<bool> crossReferenceGuarantorResults = new List<bool>();
            //Loan applicant Operations
            if (loan.LoanApplicantProfile.ApplicantId == null)
            {
                var appId = new CustomerDbHandler(loan.LoanApplicantProfile.CustomersFirstname, loan.LoanApplicantProfile.CustomersLastname, loan.LoanApplicantProfile.CustomersMiddlename);
                appId.CreateCustomerId();
               // string id = appId.CustomerId;
                loanApplicantResult = SaveLoanApplicant(loan.LoanApplicantProfile, appId.CustomerId, appId.ParsedName);

                applicantId = null;
            }
            else
            {
                applicantId = (ValidateCustomerPostId(loan.LoanApplicantProfile.ApplicantId))? loan.LoanApplicantProfile.ApplicantId.ToUpper() : null;
                loanApplicantResult.CustomerId = (applicantId != null) ? applicantId : null;
                loanApplicantResult.Customer = (applicantId != null) ? true : false;
                //simply discards the posted info and retains the given ID, also run further validation on Id
            }

            //Minor profile operations
            if (loan.MinorProfile != null)
            {
                if (loan.MinorProfile.MinorId == null)
                {
                    var minorCustomer = new CustomerDbHandler(loan.MinorProfile.CustomersFirstname, loan.MinorProfile.CustomersLastname, loan.MinorProfile.CustomersMiddlename);
                    minorCustomer.CreateCustomerId();

                    minorProfileResult = SaveMinorProfile(loan.MinorProfile, minorCustomer.CustomerId, minorCustomer.ParsedName);
                }
                else
                {
                    minorId = (ValidateCustomerPostId(loan.MinorProfile.MinorId)) ? loan.MinorProfile.MinorId.ToUpper() : null;
                    minorProfileResult.CustomerId = (minorId != null)? minorId : null;
                    minorProfileResult.Customer = (minorId != null) ? true : false;
                }
            }

        
            //Guarantor Operations 
            if (loan.Guarantors != null)
            {              
                foreach (var guarantor in loan.Guarantors)
                {
                    if (guarantor.ApplicantId == null)
                    {
                        var g = new CustomerDbHandler(guarantor.GuarantorPersonal.CustomersFirstname, guarantor.GuarantorPersonal.CustomersLastname, guarantor.GuarantorPersonal.CustomersMiddlename);
                        g.CreateCustomerId();

                        guarantorResults.Add(SaveGuarantor(guarantor, g.CustomerId, g.ParsedName));
                    }
                    else
                    {
                        if (ValidateCustomerPostId(guarantor.ApplicantId.ToUpper()))
                        {
                            guarantorIds.Add(guarantor.ApplicantId.ToUpper());
                            guarantorResults.Add(new CustomerEntityValidator()
                            {
                                CustomerId = guarantor.ApplicantId.ToUpper(),
                                Customer = true,
                                IsExistingGuarantor = true,
                            });
                        }
                        
                    }
                }
            }
          
            //Loan configuration operations
            if (loan.LoanConfig != null)
            {
                string globAppId;
                var application = new Application();
                if (application.CreateApplicationId())
                {
                    if (string.IsNullOrEmpty(applicantId)) {

                        LoanApplicationId = application.ApplicationId;

                        loanConfigResult = SaveLoanConfiguration(loan.LoanConfig, LoanApplicationId, loanApplicantResult.CustomerId, loan.LoanConfig.OfficerId);
                    }
                    else
                    {
                        loanConfigResult = SaveLoanConfiguration(loan.LoanConfig, application.ApplicationId, applicantId, loan.LoanConfig.OfficerId);
                      //  globAppId = loanConfigResult.ApplicationId;
                    }
                }

                

                //Education Program Data operations
                if (loan.EducationProgramData != null && loanConfigResult.ApplicationSuccess)
                {
                   studentDataResult = SaveEducationProgramData(loan.EducationProgramData, loanConfigResult.ApplicationId, applicantId);
                }               

            }

            //Finally, linking the entities into a relational model
            if (minorId == null && loanConfigResult.ApplicationSuccess)
            {
                if (minorProfileResult.Customer && loanConfigResult.ApplicationSuccess)
                    crossReferenceMinorResult =  CrossReferenceEntity(minorProfileResult.CustomerId, "S", loanConfigResult.ApplicationId);
            }
            else
            {
                crossReferenceMinorResult = CrossReferenceEntity(minorId, "S", loanConfigResult.ApplicationId);

            }

            if (loanConfigResult.ApplicationSuccess)
            {
                foreach (var guarantorRes in guarantorResults)
                {
                    if (guarantorRes.Customer && !(guarantorRes.IsExistingGuarantor))
                    {
                       crossReferenceGuarantorResults.Add(CrossReferenceEntity(guarantorRes.CustomerId, "G", loanConfigResult.ApplicationId));
                    }
                    
                }

                if (guarantorIds.Any())
                {
                    foreach(var g in guarantorIds)
                    {
                        crossReferenceGuarantorResults.Add(CrossReferenceEntity(g, "G", loanConfigResult.ApplicationId));

                    }
                }

            }

            return new LoanInsertionResult()
            {
                Applicant = loanApplicantResult,
                Minor = minorProfileResult,
                Guarantors = guarantorResults,

                LoanApplication = loanConfigResult,
                StudentInformation = studentDataResult,

                CrossReferenceOperation = crossReferenceMinorResult,
                CrossRefGuarantorOperation = crossReferenceGuarantorResults
            };
        }

        public CustomerEntityValidator SaveLoanApplicant(LoanApplicantProfile applicant, string applicantId, string parsedName)
        {
            //declarations 
            List<individual_financials> assetList = new List<individual_financials>();
            List<individual_financials> liabilityList = new List<individual_financials>();
            customers_financial grossFamilyIncome = new customers_financial();

            var saveOrderTrack = new CustomerEntityValidator();


            //definitions
            var loanApplicant = new customer()
            {
                ctype = "IL",//default val
                fbobkind = "IL",//default val
                prefix = (Convert.ToDecimal(applicant.CustomersSex) == 1) ? "Mr" : "Ms",
                fbonumbr = applicantId,
                appldate = DateTime.Now,
                firstname = applicant.CustomersFirstname,
                middlename = applicant.CustomersMiddlename,
                lastname = applicant.CustomersLastname,
                fbobname = ($"{applicant.CustomersFirstname} {applicant.CustomersMiddlename} {applicant.CustomersLastname}"),
                sex = Convert.ToDecimal(applicant.CustomersSex),
                mailing_address1 = applicant.CustomersMailingAddress1,
                fbobadr1 = applicant.CustomersMailingAddress1,
                fbobadr2 = applicant.CustomersMailingAddress2,
                mailing_address2 = applicant.CustomersMailingAddress2,
                mailingcountry = applicant.CustomersMailingcountry,
                typeofid = applicant.CustomersTypeofid,
                idnumber = applicant.CustomersIdnumber,
                nationality = applicant.CustomersNationality,
                businessplace = applicant.CustomersBusinessplace,
                employfrom = (DateTime.TryParse(applicant.CustomersEmployfrom, out DateTime date)) ? date: (DateTime?)null,
                //Format: 1/07/2019 ---(string.IsNullOrWhiteSpace(applicant.CustomersEmployfrom))? null: applicant.CustomersEmployfrom
                occupation = applicant.CustomersOccupation,
                //customer_financial.income1
                depends = Convert.ToDecimal(applicant.CustomersDepends),
                empstatus = Convert.ToDecimal(applicant.CustomersEmpstatus),
                home_status = applicant.CustomersHomeStatus,//mortgage
                num_inhouse = Convert.ToDecimal(applicant.CustomersNumInhouse),
                yearsaddr = Convert.ToDecimal(applicant.CustomersYearsaddr),
                next_kin = applicant.CustomersNextKin,
                relationshipkin = applicant.CustomersRelationshipkin,
                emailname = applicant.CustomersEmailname,
                homephone = applicant.CustomersHomephone,
                otherphone = applicant.CustomersOtherphone,
                workphone = applicant.CustomersWorkphone,
                mobilphone = applicant.CustomersMobilphone,
                spousename = "",
            };

            //prepping assets in a list
            if (applicant.Asset != null)
            {
                foreach (var asset in applicant.Asset)
                {
                    assetList.Add(new individual_financials()
                    { 
                        fbonumbr = applicantId,
                        code = asset.IndividualFinancialsCode,
                        amount = Convert.ToDecimal(asset.IndividualFinancialsAmount),
                        description = asset.IndividualFinancialsDescription
                    });
                }
            }

            //prepping liabilities
            if (applicant.Liabilities != null)
            {
                foreach (var liability in applicant.Liabilities)
                {
                    liabilityList.Add(new individual_financials()
                    {
                        fbonumbr = applicantId,
                        code = liability.IndividualFinancialsCode,
                        amount = Convert.ToDecimal(liability.IndividualFinancialsAmount),
                        description = liability.IndividualFinancialsDescription
                    });
                }
            }          

            //gross family income
            if (applicant.GrossAnnualFamilyIncome != null)
            {
                var g = applicant.GrossAnnualFamilyIncome.FirstOrDefault();
                grossFamilyIncome = new customers_financial()
                {
                    fbonumbr = applicantId,
                    income2 = Convert.ToDecimal(g.CustomersFinancialIncome2),
                    income4 = Convert.ToDecimal(g.CustomersFinancialIncome4)
                };
               
            }

            //database operations  which will save the above entities into, you guessed it, the database
            using (var ctx = new DPACEntities())
            {
                try
                {
                    ctx.customers.Add(loanApplicant);
                    if (ctx.SaveChanges() > 0)
                    {
                        ctx.SaveChanges();
                        ctx.updateCustCode(parsedName);
                        saveOrderTrack.Customer = true;
                        saveOrderTrack.CustomerId = applicantId;
                    }

                    
                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.Customer = false;
                    saveOrderTrack.CustomerErrMessage = e.Message;
                }
                //saving assets
                try
                {
                    if (assetList.Any() && saveOrderTrack.Customer)
                    {
                        foreach (var asset in assetList)
                        {
                            ctx.individual_financials.Add(asset);
                        }

                        if (ctx.SaveChanges() > 0)
                            saveOrderTrack.Asset = true;
                    }
                    
                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.Asset = false;
                    saveOrderTrack.AssetErrMessage = e.Message;
                }
                //saving liabilities
                try
                {
                    if (liabilityList.Any() && saveOrderTrack.Customer)
                    {
                        foreach (var liabilities in liabilityList)
                        {
                            ctx.individual_financials.Add(liabilities);
                        }
                       
                    }
                    if (ctx.SaveChanges() > 0)
                        saveOrderTrack.Liability = true;

                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.Liability = false;
                    saveOrderTrack.LiabilityErrMessage = e.Message;
                }
                //saving gross family income
                try
                {
                    if (!grossFamilyIncome.fbonumbr.IsNullOrWhiteSpace() && saveOrderTrack.Customer)
                    {
                        ctx.customers_financial.Add(grossFamilyIncome);      
                                         
                    }

                    if (ctx.SaveChanges() > 0)
                        saveOrderTrack.GrossFamilyIncome = true;
                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.GrossFamilyIncome = false;
                    saveOrderTrack.GrossFamilyErrMessage = e.Message;
                }

            }

            return saveOrderTrack;

        }

        public CustomerEntityValidator SaveMinorProfile(MinorProfile minorProfile,string minorId, string parsedName) 
        {
            var saveTrackOrder = new CustomerEntityValidator();

            var minorApplicant = new customer()
            {
                ctype = "IL",
                fbobkind = "IL",
                fbonumbr = minorId,
                appldate = DateTime.Now,
                firstname = minorProfile.CustomersFirstname,
                middlename = minorProfile.CustomersMiddlename,
                lastname = minorProfile.CustomersLastname,
                fbobname = ($"{minorProfile.CustomersFirstname} {minorProfile.CustomersMiddlename} {minorProfile.CustomersLastname}"),
                sex = Convert.ToDecimal(minorProfile.CustomersSex),//is a string in the system     
                typeofid = minorProfile.CustomersIdtype,
                idnumber = minorProfile.CustomersIdnumber,
                mailingcountry = minorProfile.CustomersCountry,
                town = minorProfile.CustomersCity,
                fbobadr1 = minorProfile.CustomersArea, 
                nationality = minorProfile.CustomersCountry,
                relationshipkin = minorProfile.CustomersRelationborrower,
                emailname = minorProfile.CustomersEmail,
                homephone = minorProfile.CustomersHomephone,
              
                birthdate = DateTime.Parse(minorProfile.CustomersBirthdate),

            };

            //Database insert operations
            using (var dpac = new DPACEntities())
            {
                        
                try
                {
                    dpac.customers.Add(minorApplicant);
                    if (dpac.SaveChanges() > 0)
                    {
                        saveTrackOrder.Customer = true;
                        saveTrackOrder.CustomerId = minorId;
                        dpac.updateCustCode(parsedName);
                        //dpac.FMS_InsertIntoFxrefbor(minorId, "S", DateTime.Now, "AN2019-00120");
                    }
                    
                }
                catch (DbEntityValidationException e)
                {
                    saveTrackOrder.Customer = false;
                    saveTrackOrder.CustomerErrMessage = e.Message;
                }

            }

            return saveTrackOrder;
        }

        public CustomerEntityValidator SaveGuarantor(Guarantor guarantor, string guarantorId, string parsedName) 
        {
            //declarations ----------

            List<individual_financials> assetList = new List<individual_financials>();
            List<individual_financials> liabilityList = new List<individual_financials>();
            var grossFamilyIncome = new customers_financial();

            var saveOrderTrack = new CustomerEntityValidator();

            //------------ Definitions 
            var guarantorRec = new customer()
            {
                ctype = "IL",
                fbobkind = "IL",
                fbonumbr = guarantorId,
                appldate = DateTime.Now,
                firstname = guarantor.GuarantorPersonal.CustomersFirstname,
                middlename = guarantor.GuarantorPersonal.CustomersMiddlename,
                lastname = guarantor.GuarantorPersonal.CustomersLastname,
                fbobname = $"{guarantor.GuarantorPersonal.CustomersFirstname} {guarantor.GuarantorPersonal.CustomersMiddlename} {guarantor.GuarantorPersonal.CustomersLastname}",
                sex = Convert.ToDecimal(guarantor.GuarantorPersonal.CustomersSex),//is a string in the system
                mailing_address1 = guarantor.GuarantorPersonal.CustomersMailingAddress1,
                typeofid = guarantor.GuarantorPersonal.CustomersTypeofid,
                mailing_address2 = guarantor.GuarantorPersonal.CustomersMailingAddress2,
                mailingcountry = guarantor.GuarantorPersonal.CustomersMailingcountry,
                idnumber = guarantor.GuarantorPersonal.CustomersIdnumber,
                nationality = guarantor.GuarantorPersonal.CustomersMailingcountry,
                birthdate = DateTime.Parse(guarantor.GuarantorPersonal.CustomersBirthdate),
                next_kin = guarantor.GuarantorPersonal.CustomersNextKin,
                relationshipkin = guarantor.GuarantorPersonal.CustomersRelationshipkin,
                emailname = guarantor.GuarantorPersonal.CustomersEmailname,
                homephone = guarantor.GuarantorPersonal.CustomersHomephone,
                otherphone = guarantor.GuarantorPersonal.CustomersOtherphone,
                workphone = guarantor.GuarantorPersonal.CustomersWorkphone,
                mobilphone = guarantor.GuarantorPersonal.CustomersMobilphone,
                spousename = "",
                //Customer Financial
                indusgrp = "",
                depends = Convert.ToDecimal(guarantor.GuarantorFinancial.CustomersDepends),
                empstatus = Convert.ToDecimal(guarantor.GuarantorFinancial.CustomersEmpstatus),
                home_status = guarantor.GuarantorFinancial.CustomersHomeStatus,//Live Rent free
                num_inhouse = Convert.ToDecimal(guarantor.GuarantorFinancial.CustomersNumInhouse),
                yearsaddr = Convert.ToDecimal(guarantor.GuarantorFinancial.CustomersYearsaddr)
            };

            if (guarantor.GuarantorFinancial.Asset != null) 
            {
                foreach (var asset in guarantor.GuarantorFinancial.Asset)
                {
                    assetList.Add(new individual_financials()
                    {
                        fbonumbr = guarantorId,
                        code = asset.IndividualFinancialsCode,
                        amount = Convert.ToDecimal(asset.IndividualFinancialsAmount),
                        description = asset.IndividualFinancialsDescription
                    });
                }       
            }

            if (guarantor.GuarantorFinancial.Liabilities != null)
            {
                foreach (var liability in guarantor.GuarantorFinancial.Liabilities)
                {
                    liabilityList.Add(new individual_financials()
                    {
                        fbonumbr = guarantorId,
                        code = liability.IndividualFinancialsCode,
                        amount = Convert.ToDecimal(liability.IndividualFinancialsAmount),
                        description = liability.IndividualFinancialsDescription
                    });
                }
            }

            if (guarantor.GuarantorFinancial.GrossAnnualFamilyIncome != null)
            {
                var g = guarantor.GuarantorFinancial.GrossAnnualFamilyIncome.FirstOrDefault();
                grossFamilyIncome = new customers_financial()
                {
                    fbonumbr = guarantorId,
                    income2 = Convert.ToDecimal(g.CustomersFinancialIncome2),
                    income4 = Convert.ToDecimal(g.CustomersFinancialIncome4)
                };
            }

            //Database insert operations
            using (var dpac = new DPACEntities()) 
            {
                try
                {
                    dpac.customers.Add(guarantorRec);
                    if (dpac.SaveChanges() > 0)
                    {
                        saveOrderTrack.Customer = true;
                        saveOrderTrack.CustomerId = guarantorId;
                        dpac.updateCustCode(parsedName);
                    }
                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.Customer = false;
                    saveOrderTrack.CustomerErrMessage = e.Message;
                }
                
                //---- asset
                try
                {
                    if (guarantor.GuarantorFinancial.Asset != null && saveOrderTrack.Customer) 
                    {
                        foreach (var g in assetList) {
                            dpac.individual_financials.Add(g);
                        }
                    }

                    if (dpac.SaveChanges() > 0)
                    {
                        saveOrderTrack.Asset = true;
                    }

                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.Asset = false;
                    saveOrderTrack.AssetErrMessage = e.Message;
                }

                //--- liabilites
                try
                {
                    if (guarantor.GuarantorFinancial.Liabilities != null && saveOrderTrack.Customer)
                    {
                        foreach (var l in liabilityList)
                        {
                            dpac.individual_financials.Add(l);
                        }                      
                    }
                    if(dpac.SaveChanges() > 0)
                        saveOrderTrack.Liability = true;
                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.Liability = false;
                    saveOrderTrack.LiabilityErrMessage = e.Message;
                }

                // ----- gross family income

                try
                {
                    if (guarantor.GuarantorFinancial.GrossAnnualFamilyIncome != null && saveOrderTrack.Customer)
                    {
                        dpac.customers_financial.Add(grossFamilyIncome);
                        
                    }
                    if (dpac.SaveChanges() > 0)
                    {
                        saveOrderTrack.GrossFamilyIncome = true;
                    }
                   
                }
                catch (DbEntityValidationException e)
                {
                    saveOrderTrack.GrossFamilyIncome = false;
                    saveOrderTrack.GrossFamilyErrMessage = e.Message;
                }
            }

            return saveOrderTrack;
        }

        public Application SaveLoanConfiguration(LoanConfig loan, string applicationId, string customerId, string officerId)
        {
            var applicationInfo = new Application();

            var loanConfig = new loan()
            {
                //a generate loan number function  must be called generated based  
                fbonumbr = customerId,
                appnumber = applicationId,//must be autogenerated
                officerid = loan.OfficerId, 
                app_type = "NL",
                appldate = DateTime.Parse(loan.LoansAppldate),
                branchid = loan.LoansBranchid,
                fladescr = loan.LoansFladescr,
                flaesins = Convert.ToDecimal(loan.LoansFlaesins),
                flafxins = Convert.ToDecimal(loan.LoansFlafxins),
                flagptmt = Convert.ToDecimal(loan.LoansFlagptmt),
                flagpval = Convert.ToDecimal(loan.LoansFlagpval),
                flaicmet = Convert.ToDecimal(loan.LoansFlaicmet),
                flaicrat = Convert.ToDecimal(loan.LoansFlaicrat),
                flainsud = DateTime.Parse(loan.LoansFlainsud),
                flainsup = Convert.ToDecimal(loan.LoansFlainsup),
                flalocat = loan.LoansFlalocat,
                flalpmet = Convert.ToDecimal(loan.LoansFlalpmet),
                flaltype = Convert.ToDecimal(loan.LoansFlaltype),
                flaptype = Convert.ToDecimal(loan.LoansFlaptype),
                flarpmet = loan.LoansFlarpmet,
                flasecto = loan.LoansFlasecto,
                flasubsc = loan.LoansFlasubsc,
                flatloan = Convert.ToDecimal(loan.LoansFlatloan),
                flatermm = Convert.ToDecimal(loan.LoansFlattermm),
                flacurncy = loan.LoansFlacurrncy,
                inquirydate = DateTime.Parse(loan.LoansInquirydate),
                repay_cycle = loan.LoansRepayCycle,
                year_length = Convert.ToDecimal(loan.LoansYearLength),
                refinanceamt = Convert.ToDecimal(loan.LoansRefinanceamt),
                consolidateamt = Convert.ToDecimal(loan.LoansConsolidateamt),
                consol_newamtreq = Convert.ToDecimal(loan.LoansConsolNewamtreq),
            };

            using (var dpac = new DPACEntities())
            {
                try
                {
                    dpac.loans.Add(loanConfig);
                    if (dpac.SaveChanges() > 0)
                    {
                        applicationInfo.ApplicationSuccess = true;
                        applicationInfo.ApplicationId = applicationId;
                    }
                }
                catch (DbEntityValidationException e)
                {
                    applicationInfo.ApplicationSuccess = false;
                    applicationInfo.ErrorMessage = e.Message;
                }
            }

            return applicationInfo;

        }

        public Application SaveEducationProgramData(EducationProgramData edu, string applicationNumber, string applicantId) 
        {
            List<studentln_borr> studentlnBorrs = new List<studentln_borr>();
            var educationDataResult = new Application();

            var studentLn = new studentln()
            {
                appnumber = applicationNumber,
                qual1 = edu.StudentlnQual1,
                duration = Convert.ToDecimal(edu.StudentlnDuration),
                level = edu.StudentlnLevel,
                course = edu.StudentlnCourse,
                pastschool1 = edu.StudentlnPastschool1,
                pastqual1 = edu.StudentlnPastqual1,
                school = edu.StudentlnSchool
            };

            if (edu.StudentlnBorr != null)
            {
                foreach (var lnBorr in edu.StudentlnBorr)
                {
                    studentlnBorrs.Add(new studentln_borr()
                    {
                        //idnum => PK, will be automatically incremented upon creation
                        appnumber = applicationNumber,
                        itemval = lnBorr.StudentlnBorrItemval,//books and supplies
                        aiditem = Convert.ToDecimal(lnBorr.StudentlnBorrAiditem)
                    });
                }
            }

            using (var dpac = new DPACEntities()) 
            {
                try
                {
                    dpac.studentlns.Add(studentLn);
                    if (dpac.SaveChanges() > 0)
                    {
                        educationDataResult.StudentDataSuccess = true;
                        educationDataResult.ApplicationId = applicationNumber;
                    }
                }
                catch (DbEntityValidationException e)
                {
                    educationDataResult.StudentDataSuccess = false;
                    educationDataResult.SaveEducationErrMessage = e.Message;
                }

                try
                {
                    if (studentlnBorrs.Any() && educationDataResult.StudentDataSuccess)
                    {
                        foreach (var lnBorr in studentlnBorrs)
                        {
                            dpac.studentln_borr.Add(lnBorr);
                        }
                    }

                    if (dpac.SaveChanges() > 0)
                        educationDataResult.StudentLnBorr = true;


                }
                catch (DbEntityValidationException e)
                {
                    educationDataResult.StudentLnBorr = false;
                    educationDataResult.StudentLnBorrErrMessage = e.Message;
                }
            }

            return educationDataResult;
        }

        public bool CrossReferenceEntity(string customerId, string customerType,string applicationNum)
        {
            bool success = false;

            using (var dpac = new DPACEntities())
            {
                try
                {
                    dpac.FMS_InsertIntoFxrefbor(customerId,customerType, DateTime.Now,  applicationNum);
                    success = true;
                }
                catch (DbEntityValidationException e)
                {
                   
                }
            }

            return success;
        }
    }
}