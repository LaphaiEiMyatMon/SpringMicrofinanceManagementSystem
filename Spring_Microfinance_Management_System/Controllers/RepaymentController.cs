using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers
{
    public class RepaymentController : Controller
    {
        // GET: Repayment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentMethodList()
        {
            return View();
        }

        public ActionResult RegisterRepayment()
        {
            Repayment repayment = new Repayment();
            return View(repayment);
        }

        [HttpPost]
        public ActionResult RegisterRepayment(Repayment repayment)
        {            
            repayment.RepaymentEntity.RepaymentDate = System.DateTime.Today;
            repayment.RegisterRepayment(repayment);
            return RedirectToAction("RegisterRepayment");
        }


        public ActionResult CreditCard()
        {
            Repayment repayment = new Repayment();
            int customerID = 1002;
            //int customerID =int.Parse(LoginInfo.UserID);
            repayment.GetData(customerID);
            return View(repayment);
        }

        [HttpPost]
        public ActionResult CreditCard(Repayment repayment)
        {         
           
            repayment.RepaymentEntity.PaymentMethod = "CreditCard";
            
            repayment.CalculationProcess(repayment);

            return RedirectToAction("/PaymentMethodList");
        }

       
        public ActionResult Cash()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cash(Repayment repayment)
        {
           
            repayment.RepaymentEntity.PaymentMethod = "Cash";
            repayment.RepaymentEntity.RepaymentDate = System.DateTime.Today;
            if (repayment.RepaymentEntity.CustomerID == 0)
            {
                repayment.RepaymentEntity.CustomerID = int.Parse(LoginInfo.UserID);
            }
            
            repayment.AddData(repayment.RepaymentEntity);

            return View();
        }




        public ActionResult MobileWallet()
        {
            Repayment repayment = new Repayment();
            int customerID = int.Parse(LoginInfo.UserID);
            repayment.GetData(customerID);
            return View(repayment);
        }

        [HttpPost]
        public ActionResult MobileWallet(BaseTB_RepaymentEntity entityInfo)
        {
            Repayment repayment = new Repayment();
            entityInfo.PaymentMethod = "MobileWallet";
            entityInfo.RepaymentDate = System.DateTime.Today;
            if (entityInfo.CustomerID == 0)
            {
                entityInfo.CustomerID = int.Parse(LoginInfo.UserID);
            }
            repayment.AddData(entityInfo);

            return View();
        }

        public ActionResult Bank()
        {
            return View();
        }

        //#region "Update"

        //public ActionResult EditRepayment(int /*repayment*/ID)
        //{
        //    Repayment role = new Repayment();
        //    role.GetData(roleID);
        //    return View(role);
        //}

        //[HttpPost]
        //public ActionResult EditRepayment(BaseTB_RoleEntity roleEntity)
        //{
        //    Repayment role = new Repayment();
        //    role.UpdateData(roleEntity);
        //    ViewBag.Message = "Successfully Updated";
        //    return RoleList();
        //}
        //#endregion

        public ActionResult RepaymentList()
        {
            int customerID = 0;
            Repayment repayment = new Repayment();
            repayment.GetDataList(customerID);
            return View(repayment);
        }

        [HttpPost]
        public ActionResult RepaymentList(int customerID)
        {
            Repayment repayment = new Repayment();
            repayment.GetDataList(customerID);
            return View(repayment);
        }
    }
}