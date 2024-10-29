using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers.MasterMaintenance
{
    public class StaffMaintenanceController : Controller
    {
        #region "List"
        public ActionResult StaffList()
        {
            StaffMaintenance staff = new StaffMaintenance();
            staff.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(staff);
        }
        #endregion

        #region "Create"
        public ActionResult AddNewStaff()
        {
            StaffMaintenance staff = new StaffMaintenance();
            return View(staff);
        }

        [HttpPost]
        public ActionResult AddNewStaff(BaseTB_StaffEntity staffEntity)
        {
            StaffMaintenance staff = new StaffMaintenance();
            byte[] imageBytes;
            using (var binaryReader = new BinaryReader(staffEntity.FileBase.InputStream))
            {
                imageBytes = binaryReader.ReadBytes(staffEntity.FileBase.ContentLength);
            }

            string base64String = Convert.ToBase64String(imageBytes);
            staffEntity.ProfilePicture = base64String;
            staff.AddData(staffEntity);
            ViewBag.Message = "Successfully Created";
            return View(staff);
        }
        #endregion
        
        #region "Update"

        public ActionResult UpdateStaff(string staffID)
        {
            StaffMaintenance staff = new StaffMaintenance();
            staff.GetData(staffID);
            return View(staff);
        }

        [HttpPost]
        public ActionResult UpdateStaff(BaseTB_StaffEntity staffEntity)
        {
            StaffMaintenance staff = new StaffMaintenance();
            staff.UpdateData(staffEntity);
            ViewBag.Message = "Successfully Updated";
            return StaffList();
        }
        #endregion

        #region "Login"
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(StaffMaintenance model)

        {        
            ResultStatus result = new ResultStatus();
            result = model.GetUser(model);
            if (result.Status == false)
            {
                this.ModelState.AddModelError("Priority", "Login failed.");
                return this.View(model);
            } 
            return RedirectToAction("LoanApplicationList", "Loan");
        }
        #endregion

        #region "Dashboard"
        public ActionResult Dashboard()
        {
            
            return View();
        }

        #endregion

    }
}