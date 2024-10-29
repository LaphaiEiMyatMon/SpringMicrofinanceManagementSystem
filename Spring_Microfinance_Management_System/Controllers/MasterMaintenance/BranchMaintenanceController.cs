using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers.MasterMaintenance
{
    public class BranchMaintenanceController : Controller
    {
        #region "List"
        public ActionResult BranchList()
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.GetDataList();
            ViewBag.Msg = ViewBag.Message;
            return View(branch);
        }
        #endregion

        #region "Create"
        public ActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBranch(BaseTB_BranchEntity branchEntity)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.AddData(branchEntity);
            return RedirectToAction("/BranchList");
        }
        #endregion

        #region "Update"

        public ActionResult EditBranch(int branchNo)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.GetData(branchNo);
            return View(branch);
        }

        [HttpPost]
        public ActionResult EditBranch(BaseTB_BranchEntity branchEntity)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.UpdateData(branchEntity);
            ViewBag.Message = "Successfully Updated";
            return RedirectToAction("/BranchList");
        }
        #endregion

        #region "Delete"
        public ActionResult DeleteBranch(int branchNo)
        {
            BranchMaintenance branch = new BranchMaintenance();
            branch.DeleteData(branchNo);
            ViewBag.Message = "Successfully Deleted";
            return RedirectToAction("/BranchList");
        }

        #endregion

    }
}