using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers
{
    public partial class RoleMaintenanceController:Controller
    {
        #region "List"
        public ActionResult RoleList()
        {
            RoleMaintenance role = new RoleMaintenance();
            role.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(role);
        }
        #endregion

        #region "Create"
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(BaseTB_RoleEntity roleEntity)
        {
            RoleMaintenance role = new RoleMaintenance();
            role.AddData(roleEntity);
            ViewBag.Message = "Successfully Created";
            return RedirectToAction("/RoleList");
        }
        #endregion

        #region "Update"

        public ActionResult EditRole(int roleID)
        {
            RoleMaintenance role = new RoleMaintenance();
            role.GetData(roleID);
            return View(role);
        }

        [HttpPost]
        public ActionResult EditRole(BaseTB_RoleEntity roleEntity)
        {
            RoleMaintenance role = new RoleMaintenance();
            role.UpdateData(roleEntity);
            ViewBag.Message = "Successfully Updated";
            return RedirectToAction("/RoleList");
        }
        #endregion

        #region "Delete"
        public ActionResult DeleteRole(int roleID)
        {
            RoleMaintenance role = new RoleMaintenance();
            role.DeleteData(roleID);
            ViewBag.Message = "Successfully Deleted";
            return RedirectToAction("/RoleList");
        }
        #endregion






    }
}