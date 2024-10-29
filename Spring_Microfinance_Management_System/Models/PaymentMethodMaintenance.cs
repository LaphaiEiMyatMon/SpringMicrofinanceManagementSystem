using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class PaymentMethodMaintenance:BaseDA
    {
        
            public PaymentMethodMaintenance()
            {
                this.PaymentMethodEntity = new BaseTB_PaymentMethodEntity();
                this.PaymentMethodList = new List<BaseTB_PaymentMethodEntity>();
            }
            public BaseTB_PaymentMethodEntity PaymentMethodEntity { get; set; }

            public List<BaseTB_PaymentMethodEntity> PaymentMethodList { get; set; }

            #region "Get Data"
            public void GetData(int paymentMethodID)
            {
                BaseTB_PaymentMethod paymentMethod = new BaseTB_PaymentMethod();
                this.PaymentMethodEntity = paymentMethod.GetData(paymentMethodID);
            }
            #endregion

            #region "Get Data List"
            public void GetDataList()
            {
                BaseTB_PaymentMethod paymentMethod = new BaseTB_PaymentMethod();
                this.PaymentMethodList = paymentMethod.GetDataList();
            }
            #endregion

            #region "Add Data"
            public void AddData(PaymentMethodMaintenance paymentMethod)
            {
            this.PaymentMethodEntity = paymentMethod.PaymentMethodEntity;
                BaseTB_PaymentMethod basePaymentMethod = new BaseTB_PaymentMethod();
                using (var con = DataBase.GetConnection())
                using (var tran = DataBase.GetTransaction(con))
                {
                    try
                    {

                    this.StampCreated(this.PaymentMethodEntity);
                    
                    basePaymentMethod.DataInsert(con, tran, this.PaymentMethodEntity);

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
            public void UpdateData(BaseTB_PaymentMethodEntity entityInfo)
            {
                BaseTB_PaymentMethod paymentMethod = new BaseTB_PaymentMethod();
                using (var con = DataBase.GetConnection())
                using (var tran = DataBase.GetTransaction(con))
                {
                    try
                    {

                        this.StampCreated(entityInfo);
                        paymentMethod.DataUpdate(con, tran, entityInfo);

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
            public void DeleteData(int paymentMethodID)
            {
                BaseTB_PaymentMethod paymentMethod = new BaseTB_PaymentMethod();
                using (var con = DataBase.GetConnection())
                using (var tran = DataBase.GetTransaction(con))
                {
                    try
                    {
                        paymentMethod.DataDelete(
                            con, tran, paymentMethodID);

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