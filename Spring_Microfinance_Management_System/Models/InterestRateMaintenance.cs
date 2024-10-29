using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class InterestRateMaintenance:BaseDA
    {
        public InterestRateMaintenance()
        {
            this.InterestRateEntity = new BaseTB_InterestRateEntity();
            this.InterestRateList = new List<BaseTB_InterestRateEntity>();
        }
        public BaseTB_InterestRateEntity InterestRateEntity { get; set; }

        public List<BaseTB_InterestRateEntity> InterestRateList { get; set; }

        #region "Get Data"
        public void GetData(int interestRateID)
        {
            BaseTB_InterestRate role = new BaseTB_InterestRate();
            this.InterestRateEntity = role.GetData(interestRateID);
        }
        #endregion

        #region "Get Data List"
        public void GetDataList()
        {
            BaseTB_InterestRate role = new BaseTB_InterestRate();
            this.InterestRateList = role.GetDataList();
        }
        #endregion

        #region "Add Data"
        public void AddData(BaseTB_InterestRateEntity entityInfo)
        {
            BaseTB_InterestRate role = new BaseTB_InterestRate();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {

                    this.StampCreated(entityInfo);
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
        public void UpdateData(BaseTB_InterestRateEntity entityInfo)
        {
            BaseTB_InterestRate role = new BaseTB_InterestRate();
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
        public void DeleteData(int interestRateID)
        {
            BaseTB_InterestRate role = new BaseTB_InterestRate();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    
                    role.DataDelete(
                        con, tran, interestRateID);

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