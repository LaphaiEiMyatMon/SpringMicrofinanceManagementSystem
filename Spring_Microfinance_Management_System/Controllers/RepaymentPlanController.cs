using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;

namespace Spring_Microfinance_Management_System.Controllers
{
    public class RepaymentPlanController : Controller
    {
        // GET: RepaymentPlan
        public ActionResult GetRepaymentPlan(RepaymentPlan plan)
        {  
            int customerID = int.Parse(LoginInfo.UserID);     
            plan.GetRepaymentPlanList(customerID);
            return View(plan);
        }
    }
}