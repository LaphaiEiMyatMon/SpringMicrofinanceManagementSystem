using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring_Microfinance_Management_System.Models;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Controllers.MasterMaintenance
{
    public class ProductTypeMaintenanceController : Controller
    {
        
        #region "List"
            public ActionResult ProductTypeList()
            {
                ProductTypeMaintenance productType = new ProductTypeMaintenance();
                productType.GetDataList();
                ViewBag.Msg = ViewBag.Message;
                return View(productType);
            }
        #endregion


        public ActionResult ProductManagement()
        {
            ProductTypeMaintenance productType = new ProductTypeMaintenance();
            productType.GetProductInterestDelayInterest();
            ViewBag.Msg = ViewBag.Message;
            return View(productType);
        }


        #region "Create"
        public ActionResult AddProductType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProductType(ProductTypeMaintenance productType)           
        {
            BaseTB_ProductTypeEntity entityInfo = new BaseTB_ProductTypeEntity();
            entityInfo = productType.ProductTypeEntity;
            productType.AddData(entityInfo);
            ViewBag.Message = "Successfully Created";
            return ProductManagement();
        }
        #endregion

        #region "Update"

        public ActionResult EditProductType(int productTypeID)
            {
                ProductTypeMaintenance productType = new ProductTypeMaintenance();
                productType.GetData(productTypeID);
                return View(productType);
            }

        [HttpPost]
        public ActionResult EditProductType(ProductTypeMaintenance productType)
        {
            productType.UpdateData(productType.ProductTypeEntity);
            ViewBag.Message = "Successfully Updated";
            return View(productType);
        }
        #endregion

        #region "Delete"
        public ActionResult DeleteProductType(int productTypeID)
         {
                ProductTypeMaintenance productType = new ProductTypeMaintenance();
                productType.DeleteData(productTypeID);
                return RedirectToAction("/ProductManagement");
         }

        #endregion



    }

}