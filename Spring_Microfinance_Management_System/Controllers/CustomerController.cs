namespace Spring_Microfinance_Management_System.Controllers
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;


    public class CustomerController : Controller
    {
        #region "Customer Home Page"
        public ActionResult CustomerHomePage()
        {
            ViewBag.Message = "Dashboard Page";
            return View();
        }

        #endregion

        #region "Register"
        public ActionResult Register()
        {
            ViewBag.Message = "Register Page";
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {          
            customer.AddData(customer);
            ViewBag.Message = "Successfully Register";
            return View();
        }
        #endregion

        #region "Register By Admin"
        public ActionResult RegisterByAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterByAdmin(Customer entityInfo)
        {
            Customer customer = new Customer();
            customer.AddData(entityInfo);
            ViewBag.Message = "Successfully Register";
            return View();
        }
        #endregion

        #region "Get Customer List"
        public ActionResult GetCustomerList()
        {
            Customer customer = new Customer();
            customer.GetDataList(customer);
            return View(customer);
        }

        [HttpPost]
        public ActionResult GetCustomerList(Customer customer)
        {
            customer.GetDataList(customer);
            return View(customer);
        }

        public ActionResult AddRequireInfo()
        {
            return View();
        }
        #endregion

        #region "Login"
        public ActionResult Login(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.Message = errorMessage;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer model)

        {
            model.Email = model.CustomerEntity.Email;
            model.Password = model.CustomerEntity.Password;
            ResultStatus result = new ResultStatus();
            result = model.GetUser(model);
            if (result.Status==false)
            {
                this.ModelState.AddModelError("Priority", "Login failed.");
                return this.View(model);
            }
            
            return RedirectToAction("CustomerHomePage", "Customer");
        }
        #endregion

        #region "Loan Type"
        public ActionResult LoanTypes()
        {
            return View();
        }
        #endregion

        #region "Update"
        public ActionResult UpdateCustomer(int customerID)
        {
            Customer customer = new Customer();
            customer.GetData(customerID);
            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            
            customer.UpdateData(customer.CustomerEntity);
            return View();
        }
        #endregion


    }
}