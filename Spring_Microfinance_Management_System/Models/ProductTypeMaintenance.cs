using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class ProductTypeMaintenance:BaseDA
    {
       

            public ProductTypeMaintenance()
            {
                this.ProductTypeEntity = new BaseTB_ProductTypeEntity();              
                this.ProductTypeList = new List<BaseTB_ProductTypeEntity>();
                this.InterestRateList = new List<BaseTB_InterestRateEntity>();
                this.DelayInterestRateList = new List<BaseTB_DelayInterestRateEntity>();
            }
            public BaseTB_ProductTypeEntity ProductTypeEntity { get; set; }

            public List<BaseTB_InterestRateEntity> InterestRateList { get; set; }

            public List<BaseTB_DelayInterestRateEntity> DelayInterestRateList { get; set; }

            public List<BaseTB_ProductTypeEntity> ProductTypeList { get; set; }

        #region Get Product, Interest and Delay Interest
        public ResultStatus GetProductInterestDelayInterest()
        {
            ResultStatus result = new ResultStatus();
            BaseTB_ProductType product = new BaseTB_ProductType();
            this.ProductTypeList=product.GetDataList();

            BaseTB_InterestRate interestRate = new BaseTB_InterestRate();
            this.InterestRateList=interestRate.GetDataList();
            
            BaseTB_DelayInterestRate delayinterestRate = new BaseTB_DelayInterestRate();
            this.DelayInterestRateList=delayinterestRate.GetDataList();

            return result;
        }
        #endregion

        #region "Get Data"
        public void GetData(int productTypeID)
            {
                BaseTB_ProductType productType = new BaseTB_ProductType();
                this.ProductTypeEntity = productType.GetData(productTypeID);
            }
            #endregion

            #region "Get Data List"
            public void GetDataList()
            {
                BaseTB_ProductType productType = new BaseTB_ProductType();
                this.ProductTypeList = productType.GetDataList();
            }
            #endregion

            #region "Add Data"
            public void AddData(BaseTB_ProductTypeEntity entityInfo)
            {
                BaseTB_ProductType productType = new BaseTB_ProductType();
                using (var con = DataBase.GetConnection())
                using (var tran = DataBase.GetTransaction(con))
                {
                    try
                    {

                        this.StampCreated(entityInfo);
                        productType.DataInsert(con, tran, entityInfo);

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }

                }
            }
            #endregion

            #region "Update Data"
            public void UpdateData(BaseTB_ProductTypeEntity entityInfo)
            {
                BaseTB_ProductType productType = new BaseTB_ProductType();
                using (var con = DataBase.GetConnection())
                using (var tran = DataBase.GetTransaction(con))
                {
                    try
                    {

                        this.StampUpdated(entityInfo);
                        productType.DataUpdate(con, tran, entityInfo);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }

                }
            }
            #endregion

            #region "Delete Data"
            public void DeleteData(int productTypeID)
            {
                BaseTB_ProductType productType = new BaseTB_ProductType();
                using (var con = DataBase.GetConnection())
                using (var tran = DataBase.GetTransaction(con))
                {
                    try
                    {

                        productType.DataDelete(
                            con, tran, productTypeID);

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }

                }
            }
            #endregion

        }


    }
