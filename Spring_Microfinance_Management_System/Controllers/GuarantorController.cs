using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;

namespace Spring_Microfinance_Management_System.Controllers
{
    public class GuarantorController : Controller
    {
        // GET: Guarantor
        public ActionResult RegisterGuarantor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterGuarantor(Guarantor guarantor)
        {
            if (guarantor.GuarantorEntity.CustomerID == 0)
            {
                guarantor.GuarantorEntity.CustomerID = int.Parse(LoginInfo.UserID);
            }
            
            guarantor.AddData(guarantor);
            return View();
        }
    }
}