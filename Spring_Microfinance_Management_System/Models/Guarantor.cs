using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring_Microfinance_Management_System.Models.Base;

namespace Spring_Microfinance_Management_System.Models
{
    public class Guarantor:BaseDA
    {
        public Guarantor()
        {
            this.GuarantorEntity = new BaseTB_GuarantorEntity();
        }

        public BaseTB_GuarantorEntity GuarantorEntity { get; set; }

        #region "Add Data"
        public ResultStatus AddData(Guarantor entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Guarantor guarantor = new BaseTB_Guarantor();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
                    this.GuarantorEntity = entityInfo.GuarantorEntity;

                    this.StampCreated(this.GuarantorEntity);
                    guarantor.DataInsert(con, tran, this.GuarantorEntity);

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
                return result;

            }
        }
        #endregion

        #region "Update Data"
        public ResultStatus UpdateData(Guarantor entityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Guarantor guarantor = new BaseTB_Guarantor();
            using (var con = DataBase.GetConnection())
            using (var tran = DataBase.GetTransaction(con))
            {
                try
                {
            
                    this.StampCreated(entityInfo.GuarantorEntity);
                    guarantor.DataUpdate(con, tran, entityInfo.GuarantorEntity);

                    tran.Commit();
                }
                catch (Exception exp)
                {
                    tran.Rollback();
                    result.Message = exp.Message;
                }
                return result;

            }
        }
        #endregion
    }
}