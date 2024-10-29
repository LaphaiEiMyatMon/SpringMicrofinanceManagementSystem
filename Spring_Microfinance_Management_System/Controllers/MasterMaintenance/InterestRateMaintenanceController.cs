using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers.MasterMaintenance
{
    public class InterestRateMaintenanceController : Controller
    {
        #region "List"
        public ActionResult InterestRateList()
        {
            InterestRateMaintenance interestRate = new InterestRateMaintenance();
            interestRate.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(interestRate);
        }
        #endregion

        #region "Create"
        public ActionResult AddInterestRate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInterestRate(BaseTB_InterestRateEntity interestRateEntity)
        {
            InterestRateMaintenance InterestRate = new InterestRateMaintenance();
            InterestRate.AddData(interestRateEntity);
            ViewBag.Message = "Successfully Saved";
            return View(InterestRate); 
        }
        #endregion

        #region "Update"

        public ActionResult EditInterestRate(int interestRateID)
        {
            InterestRateMaintenance interestRate = new InterestRateMaintenance();
            interestRate.GetData(interestRateID);
            return View(interestRate);
        }

        [HttpPost]
        public ActionResult EditInterestRate(BaseTB_InterestRateEntity interestRateEntity)
        {
            InterestRateMaintenance interestRate = new InterestRateMaintenance();
            interestRate.UpdateData(interestRateEntity);
            ViewBag.Message = "Successfully Updated";
            return View(interestRate);
        }
        #endregion

        #region "Delete"
        public ActionResult DeleteInterestRate(int interestRateID)
        {
            InterestRateMaintenance interestRate = new InterestRateMaintenance();
            interestRate.DeleteData(interestRateID);
            return RedirectToAction("ProductManagement", "ProductTypeMaintenance");
        }

        #endregion
    }
}