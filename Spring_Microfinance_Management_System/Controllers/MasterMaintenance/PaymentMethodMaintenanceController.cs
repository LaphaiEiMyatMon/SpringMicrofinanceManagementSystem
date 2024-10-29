using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers.MasterMaintenance
{
    public class PaymentMethodMaintenanceController : Controller
    {
        #region "List"
        public ActionResult PaymentMethodList()
        {
            PaymentMethodMaintenance paymentMethod = new PaymentMethodMaintenance();
            paymentMethod.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(paymentMethod);
        }
        #endregion

        #region "Create"
        public ActionResult AddPaymentMethod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPaymentMethod(PaymentMethodMaintenance paymentMethod)
        {
            paymentMethod.AddData(paymentMethod);
            ViewBag.Message = "Successfully Saved!";
            return View(paymentMethod);
        }
        #endregion

        #region "Update"

        public ActionResult EditPaymentMethod(int paymentMethodID)
        {
            PaymentMethodMaintenance paymentMethod = new PaymentMethodMaintenance();
            paymentMethod.GetData(paymentMethodID);
            return View(paymentMethod);
        }

        [HttpPost]
        public ActionResult EditPaymentMethod(PaymentMethodMaintenance model)
        {

            model.UpdateData(model.PaymentMethodEntity);
            ViewBag.Message = "Successfully Updated";
            return View(model);
        }
        #endregion

        #region "Delete"
        public ActionResult DeletePaymentMethod(int paymentMethodID)
        {
            PaymentMethodMaintenance paymentMethod = new PaymentMethodMaintenance();
            paymentMethod.DeleteData(paymentMethodID);
            return RedirectToAction("/PaymentMethodList");
        }

        #endregion
    }
}