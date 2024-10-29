using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class DelayInterestRateMaintenance:BaseDA
    {
        public DelayInterestRateMaintenance()
        {
            this.DelayInterestRateEntity = new BaseTB_DelayInterestRateEntity();
            this.DelayInterestRateList = new List<BaseTB_DelayInterestRateEntity>();
        }
        public BaseTB_DelayInterestRateEntity DelayInterestRateEntity { get; set; }

        public List<BaseTB_DelayInterestRateEntity> DelayInterestRateList { get; set; }

        #region "Get Data"
        public void GetData(int delayInterestRateID)
        {
            BaseTB_DelayInterestRate role = new BaseTB_DelayInterestRate();
            this.DelayInterestRateEntity = role.GetData(delayInterestRateID);
        }
        #endregion

        #region "Get Data List"
        public void GetDataList()
        {
            BaseTB_DelayInterestRate role = new BaseTB_DelayInterestRate();
            this.DelayInterestRateList = role.GetDataList();
        }
        #endregion

        #region "Add Data"
        public void AddData(BaseTB_DelayInterestRateEntity entityInfo)
        {
            BaseTB_DelayInterestRate role = new BaseTB_DelayInterestRate();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampCreated(entityInfo);
                    entityInfo.CreatedAt = DateTime.Now;
                    role.DataInsert(con, tran, entityInfo);

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
        public void UpdateData(BaseTB_DelayInterestRateEntity entityInfo)
        {
            BaseTB_DelayInterestRate role = new BaseTB_DelayInterestRate();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampCreated(entityInfo);
                    role.DataUpdate(con, tran, entityInfo);

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
        public void DeleteData(int delayInterestRateID)
        {
            BaseTB_DelayInterestRate role = new BaseTB_DelayInterestRate();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    role.DataDelete(
                        con, tran, delayInterestRateID);

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