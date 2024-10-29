using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers
{
    public class LoanController : Controller
    {
        //Get Loan Types
        public ActionResult LoanTypes()
        {
            return View();
        }

        #region Apply Loan
        public ActionResult Apply()
        {
            if (string.IsNullOrEmpty(LoginInfo.UserID))
            {
                ModelState.AddModelError("Priority", "Please Login First!");
                return RedirectToAction("Login", "Customer", new { errorMessage = "Please Login First!" });
            }
            Loan loan = new Loan();
            return View(loan);
        }

        [HttpPost]
        public ActionResult Apply(Loan loan)
        {
            loan.UpdateCustomerInfoAndAddLoanInfo(loan);
            return RedirectToAction("RegisterGuarantor", "Guarantor" );
        }
        #endregion

        #region Apply Loan Admin
        public ActionResult ApplyAdmin()
        {
            Loan loan = new Loan();
            return View(loan);
        }

        [HttpPost]
        public ActionResult ApplyAdmin(Loan loan)
        {
            loan.UpdateCustomerInfoAndAddLoanInfo(loan);
            return RedirectToAction("RegisterGuarantor", "Guarantor");
        }
        #endregion

        #region Get Loan Application List
        public ActionResult LoanApplicationList(Loan loan)
        {
            loan.GetLoanApplicationList(loan);
            ViewBag.Msg = ViewBag.Message;
            return View(loan);
        }

        [HttpPost]
        public ActionResult LoanApplicationList(string status)
        {
            Loan loan = new Loan();
            loan.SearchByStatus(status);
            return View(loan);
        }

        #endregion



        #region "Update"

        public ActionResult UpdateLoanApplication(int loanApplicationID)
        {
         
            Loan loan = new Loan();
            loan.LoanEntity.LoanApplicationID = loanApplicationID;
            loan.GetLoanApplication(loan);
            return View(loan);
        }

        [HttpPost]
        public ActionResult UpdateLoanApplication(Loan loan)
        {
            if (loan.LoanEntity.JudgementStatus == JudgementStatus.Approve)
            {
                loan.ApproveLoanProcess(loan);
            }
            else
            {
                loan.UpdateData(loan);
            }
           
            return RedirectToAction("/LoanApplicationList"); 
        }
        #endregion

      

    }
}