using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers.MasterMaintenance
{
    public class DelayInterestRateMaintenanceController : Controller
    {
        #region "List"
        public ActionResult DelayInterestRateList()
        {
            DelayInterestRateMaintenance delayInterestRate = new DelayInterestRateMaintenance();
            delayInterestRate.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(delayInterestRate);
        }
        #endregion

        #region "Create"
        public ActionResult AddDelayInterestRate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDelayInterestRate(BaseTB_DelayInterestRateEntity delayInterestRateEntity)
        {
            DelayInterestRateMaintenance InterestRate = new DelayInterestRateMaintenance();
            InterestRate.AddData(delayInterestRateEntity);
            ViewBag.Message = "Successfully Created";
            return DelayInterestRateList();
        }
        #endregion

        #region "Update"

        public ActionResult EditDelayInterestRate(int delayInterestRateID)
        {
            DelayInterestRateMaintenance delayInterestRate = new DelayInterestRateMaintenance();
            delayInterestRate.GetData(delayInterestRateID);
            return View(delayInterestRate);
        }

        [HttpPost]
        public ActionResult EditDelayInterestRate(BaseTB_DelayInterestRateEntity delayInterestRateEntity)
        {
            DelayInterestRateMaintenance delayInterestRate = new DelayInterestRateMaintenance();
            delayInterestRate.UpdateData(delayInterestRateEntity);
            ViewBag.Message = "Successfully Updated";
            return DelayInterestRateList();
        }
        #endregion

        #region "Delete"
        public ActionResult DeleteDelayInterestRate(int delayInterestRateID)
        {
            DelayInterestRateMaintenance delayInterestRate = new DelayInterestRateMaintenance();
            delayInterestRate.DeleteData(delayInterestRateID);
            return RedirectToAction("ProductManagement", "ProductTypeMaintenance");
        }

        #endregion
    }
}